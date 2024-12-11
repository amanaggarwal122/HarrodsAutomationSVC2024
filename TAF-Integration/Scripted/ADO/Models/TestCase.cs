namespace TAF_Integration.Scripted.Ado.Models
{
    public class TestCase
    {
        public string Id { get; set; }
        public string TestSuiteId { get; set; }
        public string TestPlanId { get; set; }
        public string OutCome { get; set; }
       
        public string[] TestpointIds { get; set; }
    }
}
