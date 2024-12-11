using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Integration.Scripted.Ado.Models
{
    public class TestResult
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string OutCome { get; set; }

        public string StackTrace { get; set; }

        public string ErrorMessage { get; set; }

        public string RunId { get; set; }

        public string TestCaseId { get; set; }
    }
}
