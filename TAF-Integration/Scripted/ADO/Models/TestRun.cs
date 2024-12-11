using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Integration.Scripted.Ado.Models
{
    public class TestRun
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PlanId { get; set; }
        public string[] PointIds { get; set; }
        public string Comment { get; set; }
        public string State { get; set; }
        public string ErrorMessage { get; set; }
        public bool Automated { get; set; }
    }
}
