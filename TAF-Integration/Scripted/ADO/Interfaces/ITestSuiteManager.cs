using TAF_Integration.Scripted.Ado.Models;
namespace TAF_Integration.Scripted.Ado.Interfaces
{
    public interface ITestSuiteManager
    {
        TestSuite GetTestSuiteByName(string testSuiteName, string testPlanId);
        TestSuite CreateTestSuite(TestSuite testSuite);
    }
}
