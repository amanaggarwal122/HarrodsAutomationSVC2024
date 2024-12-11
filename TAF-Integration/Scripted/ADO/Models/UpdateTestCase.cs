namespace TAF_Integration.Scripted.Ado.Models
{
    public class UpdateTestCase
    {
        public string planId { get; set; }
        public string suiteId { get; set; }
        public string[] testpointIds { get; set; }
        public string outcome { get; set; }
    }
}
