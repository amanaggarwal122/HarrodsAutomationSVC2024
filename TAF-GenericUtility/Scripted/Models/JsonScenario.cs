using System.Collections.Generic;

namespace TAF_GenericUtility.Scripted.Models
{
    public class JsonScenario : Base
    {
        public List<string> Tags { get; set; }
        public JsonResult Result { get; set; }
        public List<JsonStep> Steps { get; set; }

        public string ScreenshotPath { get; set; }
    }
}