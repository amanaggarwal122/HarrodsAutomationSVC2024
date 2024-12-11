using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility;
using TAF_GenericUtility.Scripted.Generic;

namespace TAF_Integration.Scripted.Ado
{
    public class ADOConfiguration
    {
        private string BasePath { get; set; }
        private string ConfigurationFile { get; set; }

        public string BaseUrl { get; set; }
        public string Project { get; set; }
        public string Collection { get; set; }
        public string AuthorizationKey { get; set; }
        public string TestSuiteName { get; set; }
        public string TestPlanName { get; set; }
        public string ProjectKey { get; set; }

        public bool Defect { get; set; }
        public bool Screenshot { get; set; }
        public bool Status { get; set; }


        public Dictionary<String, String> Configuration { get; set; }
        public ADOConfiguration()
        {
            string configFile = "/Resources/Integrations/AzureDevOps/ado.config";
            BasePath = PathUtil.BasePath();
            ConfigurationFile = PathUtil.Combine(BasePath, configFile);
        }

        public ADOConfiguration Init()
        {
            Configuration = ConfigDriver.GetConfigurationValues(ConfigurationFile);

            BaseUrl = Configuration["BaseUrl"];
            Project = Configuration["Project"];
            Collection = Configuration["Collection"];
            AuthorizationKey = Configuration["Authorization"];
            TestSuiteName = Configuration["TestSuite"];
            TestPlanName = Configuration["TestPlan"];
            ProjectKey = Configuration["ProjectKey"];
            Defect = bool.Parse(Configuration["Defect"]);
            Screenshot = bool.Parse(Configuration["Screenshot"]);
            Status = bool.Parse(Configuration["Status"]);

            return this;
        }
    }
}
