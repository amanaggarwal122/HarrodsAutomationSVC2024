using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Integration.Scripted.Ado.Interfaces;

using TAF_Integration.Scripted.Ado.Models;

namespace TAF_Integration.Scripted.Ado.Implementations
{
    public class TestPlanManager : ITestPlanManager
    {
        IAdoClient _ADOClient = null;

        public TestPlanManager(IAdoClient ADOClient)
        {
            _ADOClient = ADOClient;
        }

        public TestPlan GetTestPlanByName(string testPlanName)
        {
            List<TestPlan> testPlans = _ADOClient.GetTestPlans();
            return testPlans.Find(t => t.Name.ToLower().Equals(testPlanName.ToLower()));
        }

        public TestPlan CreateTestPlan(TestPlan testPlan)
        {
            return _ADOClient.CreateTestPlan(testPlan);
        }
    }
}
