using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MimeKit.Text;

namespace TAF_GenericUtility.Scripted.Email

{
    public class SMTPClient
    {

        readonly string host;
        readonly SecureSocketOptions secureSocketOptions;
        readonly int port;
        SmtpClient client;

        public SMTPClient(string host, int port,
            SecureSocketOptions secureSocketOptions)
        {
            if (string.IsNullOrEmpty(host))
                throw new Exception("smtp exception : host cannot be empty");

            if (port <= 0)
                throw new Exception("smtp exception : port cannot be empty");

            //if you wanto write to console enable the below line
            //this.client = new ImapClient(new ProtocolLogger(Console.OpenStandardError()));
            this.client = new SmtpClient();
            this.secureSocketOptions = secureSocketOptions;
            this.host = host;
            this.port = port;
        }

        public bool Connect(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                    throw new Exception("smtp exception : username cannot be empty");

                if (string.IsNullOrEmpty(password))
                    throw new Exception("smtp exception : password cannot be empty");

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

        public void Send(MailItem emailMessage, List<string> attachments)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.To.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.From.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.Sender = new MailboxAddress(emailMessage.From.First().Address, emailMessage.From.First().Name);


            message.Subject = emailMessage.Subject;

            var builder = new BodyBuilder();

            builder.TextBody = emailMessage.TextBody == null ? string.Empty : emailMessage.TextBody;
            builder.HtmlBody = emailMessage.HTMLBody == null ? string.Empty : emailMessage.HTMLBody;

            if (attachments != null)
            {
                foreach (string s in attachments)
                {
                    builder.Attachments.Add(s);
                }
            }

            message.Body = builder.ToMessageBody();


            client.Send(message);

            client.Disconnect(true);
        }

    }
}

