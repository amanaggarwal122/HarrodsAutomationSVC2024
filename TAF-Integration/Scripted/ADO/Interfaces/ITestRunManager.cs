using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Interfaces
{
    public interface ITestRunManager
    {
        TestRun CreateTestRun(TestRun testRun);

        List<TestResult> GetTestResults(string runID);

        TestResult UpdateTestResult(TestResult testResult);

        TestRun UpdateTestRun(TestRun testRun);

        bool UpdateAttachment(Attachment attachment);
    }
}

