using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.Ado.Interfaces;
using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Implementations
{
    public class TestSuiteManager : ITestSuiteManager
    {
        IAdoClient _ADOClient = null;

        public TestSuiteManager(IAdoClient ADOClient)
        {
            _ADOClient = ADOClient;
        }

        public TestSuite GetTestSuiteByName(string testSuiteName, string testPlanId)
        {
            List<TestSuite> testSuites = _ADOClient.GetTestSuites(testPlanId);
            return testSuites.Find(t => t.Name.ToLower().Equals(testSuiteName.ToLower()));
        }

        public TestSuite CreateTestSuite(TestSuite testSuite)
        {
            return _ADOClient.CreateTestSuite(testSuite);
        }
    }

}
