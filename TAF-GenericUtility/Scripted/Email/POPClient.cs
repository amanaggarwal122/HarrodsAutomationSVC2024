using MailKit;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.IO;
using MailKit.Net.Pop3;
using System.Security.Authentication;
using MimeKit;
using System.Linq;

namespace TAF_GenericUtility.Scripted.Email

{
    /// <summary>
    /// Read Me : enable low secure app access in gmail
    /// https://myaccount.google.com/lesssecureapps
    /// </summary>
    public class POPClient : IDisposable
    {
        readonly string host;
        readonly SslProtocols sslProtocols;
        readonly int port;
        List<IMessageSummary> messages;
        Pop3Client client;
        MailHelper helper = null;

        public POPClient(string host, int port,
            SslProtocols sslProtocols)
        {

            if (string.IsNullOrEmpty(host))
                throw new Exception("pop3 exception : host cannot be empty");

            if (port <= 0)
                throw new Exception("pop3 exception : port cannot be empty");


            //if you wanto write to console enable the below line
            //this.client = new Pop3Client(new ProtocolLogger(Console.OpenStandardError()));
            this.client = new Pop3Client();
            this.messages = new List<IMessageSummary>();
            this.sslProtocols = sslProtocols;
            this.host = host;
            this.port = port;
            helper = new MailHelper();
        }

        public bool Connect(string username, string password, bool recent)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                    throw new Exception("POP3 exception : username cannot be empty");

                if (string.IsNullOrEmpty(password))
                    throw new Exception("POP3 exception : password cannot be empty");

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.SslProtocols = sslProtocols;
                client.Connect(this.host, this.port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                if (recent)
                    client.Authenticate($"recent:{username}", password);
                else
                    client.Authenticate(username, password);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Dispose()
        {
            client.Disconnect(true);
            client.Dispose();
        }

        public List<MailItem> GetAllMessages(int maxCount = 10)
        {
            try
            {
                List<MailItem> mailItems = GetMailItems(maxCount);

                return mailItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetMessagesBySubject
        /// </summary>
        /// <param name="textToSearch">text to search in subject</param>
        /// <param name="unseen">read/unread</param>
        /// <returns></returns>
        public List<MailItem> GetMessagesBySubject(string textToSearch, int maxCount = 10)
        {
            try
            {
                List<MailItem> mailItems = GetMailItems(maxCount);

                return mailItems.Where(m => m.Subject.ToLower().Contains(textToSearch.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetMessagesByFrom
        /// </summary>
        /// <param name="textToSearch">text to search in subject</param>
        /// <param name="unseen">read/unread</param>
        /// <returns></returns>
        public List<MailItem> GetMessagesByFrom(string textToSearch, int maxCount = 10)
        {
            try
            {
                List<MailItem> mailItems = GetMailItems(maxCount);

                return mailItems.Where(m => m.From.Any(f => f.Address.ToLower().Contains(textToSearch.ToLower()))).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uids"></param>
        /// <returns></returns>
        private List<MailItem> GetMailItems(int maxCount = 10)
        {
            int serverCount = client.GetMessageCount();
            List<MailItem> mailItems = new List<MailItem>();

            for (int i = 0; i < serverCount && i < maxCount; i++)
            {
                var message = client.GetMessage(i);
                mailItems.Add(helper.GetMailItem(message));
                Console.WriteLine(i + ":" + message.Subject);
            }

            client.Disconnect(true);

            return mailItems;
        }

        public void DownloadAttachments(List<MimeEntity> attachments, string folder)
        {
            helper.DownloadAttachments(attachments, folder);
        }
        public void DownloadAttachments(List<MimeEntity> attachments, string folder, string fileToDownLoad)
        {
            helper.DownloadAttachments(attachments, folder, fileToDownLoad);
        }
    }
}
