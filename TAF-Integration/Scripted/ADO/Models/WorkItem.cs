using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Integration.Scripted.Ado.Models
{
    public class WorkItem
    {
        public object Type { get; set; }
        public object Op { get; set; }
        public object Path { get; set; }
        public object From { get; set; }
        public object Value { get; set; }
        public object Id { get; set; }
        public object Rel { get; set; }
        public object Url { get; set; }
        public object Comment { get; set; }
    }

    public class WorkItemModel
    { 
        public object op { get; set; }
        public object path { get; set; }
        public object from { get; set; }
        public object value { get; set; } 
    }

    public class Attributes
    {
        public object comment { get; set; }
    }

    public class Value
    {
        public object rel { get; set; }
        public object url { get; set; }
        public object attributes { get; set; }
    }

    public class AttachmentModel
    {
        public object op { get; set; }
        public object path { get; set; }
        public object value { get; set; }
    }
}
