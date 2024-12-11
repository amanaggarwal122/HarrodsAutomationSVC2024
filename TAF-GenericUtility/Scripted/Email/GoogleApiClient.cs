using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace TAF_GenericUtility.Scripted.Email
{
    public class GoogleApiClient
    {
        readonly string applicationName;
        readonly string email;
        readonly string credentialpath;
        GmailService service = null;

        public GoogleApiClient(string ApplicationName, string email, string credentialPath)
        {
            if (string.IsNullOrEmpty(ApplicationName))
                throw new Exception("google exception : ApplicationName cannot be empty");

            if (string.IsNullOrEmpty(email))
                throw new Exception("google exception : email cannot be empty");

            if (string.IsNullOrEmpty(credentialPath))
                throw new Exception("google exception : credentialPath cannot be empty");


            this.applicationName = ApplicationName;
            this.email = email;
            this.credentialpath = credentialPath;

        }

        public void Connect()
        {
            try
            {
                UserCredential credential;
                string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.MailGoogleCom };

                using (var stream =
                    new FileStream(this.credentialpath, FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        this.email,
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Gmail API service.
                service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = this.applicationName,
                });

               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection to Gmail account failed. Exception : " + ex.Message);
            }
        }

        public List<MailItem> GetEmailsFromInBox(bool onlyUnRead, int maxEmailsToReturn, string searchQuery)
        {

            List<Message> emailList = new List<Message>();
            UsersResource.MessagesResource.ListRequest inboxlistRequest = service.Users.Messages.List(this.email);

            if (onlyUnRead)
                inboxlistRequest.LabelIds = new List<String>() { "UNREAD" };
            else
                inboxlistRequest.LabelIds = new List<String>() { "INBOX" };
            inboxlistRequest.IncludeSpamTrash = false;
            if (!string.IsNullOrEmpty(searchQuery))
                inboxlistRequest.Q = searchQuery;
            inboxlistRequest.MaxResults = maxEmailsToReturn;
            do
            {
                try
                {
                    ListMessagesResponse response = inboxlistRequest.Execute();
                    emailList.AddRange(response.Messages);
                    inboxlistRequest.PageToken = response.NextPageToken;
                    if (emailList.Count >= maxEmailsToReturn)
                        break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Message Retrieval failed: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(inboxlistRequest.PageToken));

            return GetMailItems(emailList);
        }
        private byte[] FromBase64ForUrlString(string base64ForUrlInput)
        {
            int padChars = (base64ForUrlInput.Length % 4) == 0 ? 0 : (4 - (base64ForUrlInput.Length % 4));
            StringBuilder result = new StringBuilder(base64ForUrlInput, base64ForUrlInput.Length + padChars);
            result.Append(String.Empty.PadRight(padChars, '='));
            result.Replace('-', '+');
            result.Replace('_', '/');
            return Convert.FromBase64String(result.ToString());
        }

        private List<MailItem> GetMailItems(List<Message> emailList)
        {
            List<MailItem> result = new List<MailItem>();

            //loop through each email and get what fields you want...   
            foreach (var email in emailList)
            {
                var emailInfoRequest = service.Users.Messages.Get(this.email, email.Id);
                var emailInfoResponse = emailInfoRequest.Execute();
                if (emailInfoResponse != null)
                {
                    string emailfrom = "";
                    DateTime? emaildate = null;
                    string emailsubject = "";
                    string emailbody = "";

                    foreach (var mParts in emailInfoResponse.Payload.Headers)
                    {
                        if (mParts.Name == "Date")
                        {
                            var convertedDate = DateTimeOffset.FromUnixTimeMilliseconds(emailInfoResponse.InternalDate.Value).DateTime;

                            if (TimeZoneInfo.Local.IsDaylightSavingTime(convertedDate))
                            {
                                convertedDate = convertedDate.ToLocalTime();
                            }

                            emaildate = convertedDate;
                        }
                        else if (mParts.Name == "From")
                        {
                            emailfrom = mParts.Value;
                        }
                        else if (mParts.Name == "Subject")
                        {
                            emailsubject = mParts.Value;
                        }
                        if (emaildate != null && emailfrom != "")
                        {
                            foreach (MessagePart p in emailInfoResponse.Payload.Parts)
                            {
                                if (p.MimeType == "text/html")
                                {
                                    byte[] data = FromBase64ForUrlString(p.Body.Data);
                                    emailbody = Encoding.UTF8.GetString(data);
                                }
                            }
                        }
                    }

                    List<EmailAddress> fromList = new List<EmailAddress>();

                    string[] name = emailfrom.Split('<');

                    fromList.Add(new EmailAddress { Address = name[1].Remove(name[1].Length-1,1), Name = name[0].Trim() });

                    List<EmailAddress> ccList = new List<EmailAddress>();
                    //fromList.Add(new EmailAddress { Address = emailfrom, Name = "" });

                    List<EmailAddress> bccList = new List<EmailAddress>();
                    //fromList.Add(new EmailAddress { Address = emailfrom, Name = "" });

                    List<EmailAddress> toList = new List<EmailAddress>();

                    result.Add(new MailItem
                    {
                        BCC = bccList,
                        CC = ccList,
                        From = fromList,
                        To = toList,
                        HTMLBody = emailbody,
                        TextBody = string.Empty,
                        MailFormat = EmailFormat.HTML,
                        MailDate = emaildate,
                        Subject = emailsubject,
                        Attachments = null,
                    });
                }

            }
            return result;
        }
    }
}
