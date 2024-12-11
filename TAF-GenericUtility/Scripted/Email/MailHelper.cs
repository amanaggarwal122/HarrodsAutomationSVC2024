using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using MimeKit.Cryptography;

namespace TAF_GenericUtility.Scripted.Email
{
    public class MailHelper
    {
        public List<EmailAddress> GetMailboxes(InternetAddressList addresses)
        {
            if (addresses != null && addresses.Count > 0)
            {
                if (addresses.Mailboxes != null)
                {
                    List<EmailAddress> mailboxes = new List<EmailAddress>();

                    foreach (var mailbox in addresses.Mailboxes)
                    {
                        mailboxes.Add(new EmailAddress { Address = mailbox.Address, Name = mailbox.Name });
                    }

                    return mailboxes;
                }
            }

            return new List<EmailAddress>(); ;
        }

        public MailItem GetMailItem(MimeMessage m)
        {
            return new MailItem
            {
                BCC = GetMailboxes(m.Bcc),
                CC = GetMailboxes(m.Cc),
                From = GetMailboxes(m.From),
                To = GetMailboxes(m.To),
                HTMLBody = m.HtmlBody == null ? string.Empty : m.HtmlBody,
                TextBody = m.TextBody == null ? string.Empty : m.TextBody,
                MailFormat = string.IsNullOrEmpty((m.TextBody == null ? string.Empty : m.TextBody).Trim()) ? EmailFormat.HTML : EmailFormat.Text,
                ReceivedTime = m.Date,
                Subject = m.Subject,
                Attachments = m.Attachments.Any() ? m.Attachments.ToList() : null,
            };
        }

        public void DownloadAttachments(List<MimeEntity> attachments, string folder)
        {
            DownloadAttachments(attachments, folder, string.Empty);
        }
        public void DownloadAttachments(List<MimeEntity> attachments, string folder, string fileToDownLoad)
        {
            foreach (MimeEntity attachment in attachments)
            {
                var fileName = attachment.ContentDisposition?.FileName ?? attachment.ContentType.Name;

                if (fileName.ToLower().Contains(fileToDownLoad.ToLower()))
                {
                    using (var stream = File.Create(Path.Combine(folder, fileName)))
                    {
                        if (attachment is MessagePart)
                        {
                            var rfc822 = (MessagePart)attachment;

                            rfc822.Message.WriteTo(stream);
                        }
                        else
                        {
                            var part = (MimePart)attachment;

                            part.Content.DecodeTo(stream);
                        }
                    }

                    break;
                }
            }
        }

        private static Dictionary<string, string> ExtractBody(
            IEnumerable<MimeEntity> entities,
            MimeMessage msg, bool skipSignature)
        {
            Dictionary<string, string> body = new Dictionary<string, string>();

            foreach (MimeEntity idxBody in entities)
            {
                if (idxBody is TextPart)
                {
                    TextPart tp = idxBody as TextPart;
                    if (idxBody.ContentType.MediaType == "text")
                    {
                        if (idxBody.ContentType.MediaSubtype == "plain")
                        {
                            body["Text"] = tp.Text;
                        }
                        else if (idxBody.ContentType.MediaSubtype == "html")
                        {
                            body["HTML"] = CleanHtml(tp.Text);
                        }
                    }
                }
                else if (idxBody is ApplicationPkcs7Mime)
                {
                    ApplicationPkcs7Mime pkcs7 = idxBody as ApplicationPkcs7Mime;
                    if (pkcs7.SecureMimeType == SecureMimeType.EnvelopedData)
                    {
                        try
                        {
                            MimeEntity entity = pkcs7.Decrypt();
                            ExtractBody(new MimeEntity[] { entity }, msg, skipSignature);
                        }
                        catch (Exception err)
                        {
                            // couldn't decrypt
                            throw new Exception("couldn't decrypt message, exceptions was; '" + err.Message + "'");

                        }
                    }
                }
                else if (!skipSignature && idxBody is MultipartSigned)
                {
                    MultipartSigned signed = idxBody as MultipartSigned;
                    bool valid = false;
                    foreach (IDigitalSignature signature in signed.Verify())
                    {
                        valid = signature.Verify();
                        if (!valid)
                            break;
                    }

                    ExtractBody(new MimeEntity[] { signed }, msg, skipSignature);
                }
                else if (idxBody is Multipart)
                {
                    Multipart mp = idxBody as Multipart;
                    ExtractBody(mp, msg, skipSignature);
                }
                else if (idxBody is MimePart)
                {
                    // this is an attachment

                }
            }
            return body;
        }
        private static string CleanHtml(string html)
        {

            //HtmlDocument doc = new HtmlDocument();

            //doc.LoadHtml(html);
            //doc.DocumentNode.Descendants()
            //    .Where(n => n.Name == "script" || n.Name == "style" || n.Name == "#comment")
            //    .ToList()
            //    .ForEach(n => n.Remove());
            //HtmlNode el = doc.DocumentNode.SelectSingleNode("//body");
            //if (el != null)
            //    return el.InnerHtml;
            //else
            //    return doc.DocumentNode.InnerHtml;


            return html;
        }
    }
}
