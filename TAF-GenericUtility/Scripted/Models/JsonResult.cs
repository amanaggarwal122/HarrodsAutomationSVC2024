using System.Text;

namespace TAF_GenericUtility.Scripted.Models
{
    public class JsonResult
    {
        public string Status { get; set; }
        public string Duration { get; set; }
        public StringBuilder ExeptionMessage { get; set; }
    }
}