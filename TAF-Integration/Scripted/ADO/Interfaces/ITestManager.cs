using System.Collections.Generic;
using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Interfaces
{
    public interface ITestManager
    {
        bool UpdateTestCase(UpdateTestCase testCase);
        List<TestPoint> GetTestPoints(string testPlanId, string testSuiteId, string testCaseId);
        List<TestPoint> GetTestPoints(int[] testCaseIds);
    }
}
