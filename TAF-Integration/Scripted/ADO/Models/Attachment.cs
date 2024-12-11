using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Integration.Scripted.Ado.Models
{
    public class Attachment
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string AttachmentType { get; set; }
        public string RunId { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
    }
}
