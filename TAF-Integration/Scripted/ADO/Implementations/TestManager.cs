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
    public class TestManager : ITestManager
    {
        IAdoClient _adoClient = null;

        public TestManager(IAdoClient ADOClient)
        {
            _adoClient = ADOClient;
        }

        public bool UpdateTestCase(UpdateTestCase testCase)
        {
            return _adoClient.UpdateTest(testCase);
        }

        public List<TestPoint> GetTestPoints(string testPlanId, string testSuiteId, string testCaseId)
        {
            return _adoClient.GetTestPoints(testPlanId, testSuiteId, testCaseId);
        }

        public List<TestPoint> GetTestPoints( int[] testCaseIds)
        {
            return _adoClient.GetTestPoints(testCaseIds);
        }

    }
}
