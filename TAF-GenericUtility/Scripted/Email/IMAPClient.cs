using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TAF_GenericUtility.Scripted.Email
{
    public class IMAPClient : IDisposable
    {

        readonly string host;
        readonly SecureSocketOptions secureSocketOptions;
        readonly int port;
        ImapClient client;
        MailHelper helper = null;

        public IMAPClient(string host, int port,
            SecureSocketOptions secureSocketOptions)
        {

            if (string.IsNullOrEmpty(host))
                throw new Exception("imap exception : host cannot be empty");

            if (port <= 0)
                throw new Exception("impa exception : port cannot be empty");


            //if you wanto write to console enable the below line
            //this.client = new ImapClient(new ProtocolLogger(Console.OpenStandardError()));
            this.client = new ImapClient();
            this.secureSocketOptions = secureSocketOptions;
            this.host = host;
            this.port = port;
            helper = new MailHelper();
        }

        public bool Connect(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                    throw new Exception("imap exception : username cannot be empty");

                if (string.IsNullOrEmpty(password))
                    throw new Exception("impa exception : password cannot be empty");

                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(this.host, this.port, this.secureSocketOptions);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
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

        public List<MailItem> GetAllMessages()
        {
            try
            {
                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(SearchQuery.All);

                return GetMailItems(uids);
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
        public List<MailItem> GetMessagesBySubject(string textToSearch, bool unseen)
        {
            SearchQuery query = null;
            try
            {
                if (!string.IsNullOrEmpty(textToSearch))
                {
                    query = SearchQuery.SubjectContains(textToSearch);
                }

                if (unseen)
                {
                    query = query.And(SearchQuery.NotSeen);
                }

                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(query);

                return GetMailItems(uids);
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
        public List<MailItem> GetMessagesByFrom(string textToSearch, bool unseen)
        {
            SearchQuery query = null;
            try
            {
                if (!string.IsNullOrEmpty(textToSearch))
                {
                    query = SearchQuery.FromContains(textToSearch);
                }

                if (unseen)
                {
                    query = query.And(SearchQuery.NotSeen);
                }

                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(query);

                return GetMailItems(uids);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// GetMessagesUnread
        /// </summary>
        /// <returns></returns>
        public List<MailItem> GetMessagesUnread()
        {
            SearchQuery query = null;
            try
            {
                query = query.And(SearchQuery.NotSeen);

                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(query);

                return GetMailItems(uids);
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
        private List<MailItem> GetMailItems(IList<UniqueId> uids)
        {
            List<MailItem> mailItems = new List<MailItem>();

            foreach (UniqueId id in uids)
            {
                var m = client.Inbox.GetMessage(id);

                mailItems.Add(helper.GetMailItem(m));
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


