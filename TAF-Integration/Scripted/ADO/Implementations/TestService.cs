using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.Ado.Interfaces;
using TAF_Integration.Scripted.Ado;

using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Implementations
{
    public class TestService : ITestService
    {
        ITestManager _testManager = null;
        ITestPlanManager _testPlanManager = null;
        ITestSuiteManager _testSuiteManager = null;
        ITestRunManager _testRunManager = null;
        IAdoClient _adoClient = null;
        IWorkItemManager _workItemManager = null;


        public TestService()
        {
            _adoClient = new ADOClient();
            _testManager = new TestManager(_adoClient);
            _testPlanManager = new TestPlanManager(_adoClient); ;
            _testSuiteManager = new TestSuiteManager(_adoClient); ;
            _testRunManager = new TestRunManager(_adoClient);
            _workItemManager = new WorkItemManager(_adoClient);
        }


        public bool UpdateTest(TestCase testCase)
        {
            return _testManager.UpdateTestCase(new UpdateTestCase
            {
                planId = testCase.TestPlanId,
                suiteId = testCase.TestSuiteId,
                outcome = testCase.OutCome,
                testpointIds = testCase.TestpointIds
            });
        }

        public TestResult UpdateResult(TestResult testResult)
        {
            return _testRunManager.UpdateTestResult(testResult);
        }

        public TestRun UpdateRun(TestRun testRun)
        {
            return _testRunManager.UpdateTestRun(testRun);
        }

        public bool AddRunAttachment(Attachment attachment)
        {
            return _testRunManager.UpdateAttachment(attachment);
        }

        public TestRun CreateTestRun(TestRun testRun)
        {
            return _testRunManager.CreateTestRun(testRun);
        }

        public TestPlan GetTestPlanByName(string testPlanName)
        {
            return _testPlanManager.GetTestPlanByName(testPlanName);
        }

        public TestPlan CreateTestPlan(TestPlan testPlan)
        {
            return _testPlanManager.CreateTestPlan(testPlan);
        }

        public TestSuite GetTestSuiteByName(string testSuiteName, string testPlanId)
        {
            return _testSuiteManager.GetTestSuiteByName(testSuiteName, testPlanId);
        }

        public TestSuite CreateTestSuite(TestSuite testSuite)
        {
            return _testSuiteManager.CreateTestSuite(testSuite);
        }

        public List<TestPoint> GetTestPoints(string testPlanId, string testSuiteId, string testCaseId)
        {
            return _testManager.GetTestPoints(testPlanId, testSuiteId, testCaseId);
        }

        public List<TestPoint> GetTestPoints(int[] testCaseIds)
        {
            return _testManager.GetTestPoints(testCaseIds);
        }

        public List<TestResult> GetTestResults(string runID)
        {
            return _testRunManager.GetTestResults(runID);
        }

        public WorkItem CreateWorkItem(List<WorkItem> workItem)
        {
            return _workItemManager.CreateWorkItem(workItem);
        }

        public Attachment AddWorkItemAttachment(Attachment attachment)
        {
            return _workItemManager.AddWorkItemAttachment(attachment);
        }

        public WorkItem MapAttachmentToWorkItem(WorkItem workItem)
        {
            return _workItemManager.MapAttachmentToWorkItem(workItem);
        }
    }
}

