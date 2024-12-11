using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.Ado.Interfaces;
using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Implementations
{
    public class TestRunManager : ITestRunManager
    {
        IAdoClient _adoClient = null;
        public TestRunManager(IAdoClient adoClient)
        {
            _adoClient = adoClient;
        }

        public TestRun CreateTestRun(TestRun testRun)
        {
            return _adoClient.CreateTestRun(testRun);
        }

        public List<TestResult> GetTestResults(string runID)
        {
            return _adoClient.GetTestResults(runID);
        }

        public TestResult UpdateTestResult(TestResult testResult)
        {
            return _adoClient.UpdateResult(testResult);
        }

        public TestRun UpdateTestRun(TestRun testRun)
        {
            return _adoClient.UpdateRun(testRun);
        }

        public bool UpdateAttachment(Attachment attachment)
        {
            return _adoClient.AddRunAttachment(attachment);
        }
    }
}
