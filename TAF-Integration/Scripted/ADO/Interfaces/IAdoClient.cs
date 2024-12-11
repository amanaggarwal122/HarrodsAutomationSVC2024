using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.Ado;
using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Interfaces
{
    public interface IAdoClient
    {
        List<TestPlan> GetTestPlans();
        List<TestSuite> GetTestSuites(string testPlanId);
        List<TestPoint> GetTestPoints(string testPlanId, string testSuiteId, string testCaseId);
        bool UpdateTest(UpdateTestCase testCase);
        TestPlan CreateTestPlan(TestPlan testPlan);
        TestSuite CreateTestSuite(TestSuite testSuite);

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
