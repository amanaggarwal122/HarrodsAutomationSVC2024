using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace TAF_GenericUtility.Scripted.Email
{
    public class MailItem
    {        
        public List<EmailAddress> To { get; set; }
        public List<EmailAddress> CC { get; set; }
        public List<EmailAddress> BCC { get; set; }
        public List<EmailAddress> From { get; set; }
        public DateTimeOffset ReceivedTime { get; set; }
        public string Subject { get; set; } 
        public string HTMLBody { get; set; }
        public string TextBody { get; set; }
        public EmailFormat MailFormat { get; set; }
        public List<MimeEntity> Attachments { get; set; }
        public DateTime? MailDate { get; set; }
    }

    public enum EmailFormat
    {
        Text,
        HTML
    }

    public class EmailAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
