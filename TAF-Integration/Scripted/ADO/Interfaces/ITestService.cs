using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.ADO;
using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Interfaces
{
    public interface ITestService
    {
        bool UpdateTest(TestCase testCase);

        TestPlan GetTestPlanByName(string testPlanName);

        TestPlan CreateTestPlan(TestPlan testPlan);

        TestSuite GetTestSuiteByName(string testSuiteName, string testPlanId);

        TestSuite CreateTestSuite(TestSuite testSuite);

        List<TestPoint> GetTestPoints(string testPlanId, string testSuiteId, string testCaseId);

        TestRun CreateTestRun(TestRun testRun);

        List<TestResult> GetTestResults(string runID);

        TestResult UpdateResult(TestResult testResult);

        TestRun UpdateRun(TestRun testRun);

        bool AddRunAttachment(Attachment attachment);

        Attachment AddWorkItemAttachment(Attachment attachment);

        WorkItem MapAttachmentToWorkItem(WorkItem defect);

        WorkItem CreateWorkItem(List<WorkItem> workItem);

        List<TestPoint> GetTestPoints(int[] testCaseIds);
    }
}
