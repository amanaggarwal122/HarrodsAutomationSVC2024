using TAF_Integration.Scripted.Ado.Models;
namespace TAF_Integration.Scripted.Ado.Interfaces
    
{
    public interface ITestPlanManager
    {
        TestPlan GetTestPlanByName(string testPlanName);
        TestPlan CreateTestPlan(TestPlan testPlan);
    }
}
