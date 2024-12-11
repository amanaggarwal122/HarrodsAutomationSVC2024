using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TAF_GenericUtility.Scripted.Models;
using TechTalk.SpecFlow;

namespace TAF_Reporting.Json
{
    public class JsonReport
    {
        private static List<JsonScenario> scenarios { get; set; }

        [ThreadStatic]
        private static DateTime _lastStepStart;

        public JsonReport()
        {
        }

        public static void Initialize()
        {
            scenarios = new List<JsonScenario>();
        }

        public static void ScenarioInitialize(ScenarioContext scenarioContext)
        {
            _lastStepStart = DateTime.Now;
            JsonScenario scenario = new JsonScenario
            {
                Name = scenarioContext.ScenarioInfo.Title,
                Tags = scenarioContext.ScenarioInfo.Tags.ToList<string>(),
                Result = new JsonResult(),
                Steps = new List<JsonStep>()
            };

            scenarios.Add(scenario);
        }

        public static void ScenarioStepUpdate(ScenarioContext scenarioContext)
        {
            JsonScenario scenario = scenarios.Find(p => p.Name.Equals(scenarioContext.ScenarioInfo.Title));

            JsonStep jsonStep = new JsonStep
            {
                Name = scenarioContext.StepContext.StepInfo.StepInstance.Text,
                Result = new JsonResult
                {
                    Duration = $"{DateTime.Now.Subtract(_lastStepStart).TotalSeconds:0.0}",
                    Status = scenarioContext.TestError != null ? StatusEnum.Fail : StatusEnum.Pass,
                    ExeptionMessage = new StringBuilder(scenarioContext.TestError == null ? "" : scenarioContext.TestError.Message + scenarioContext.TestError.StackTrace)
                }
            };

            scenario.Steps.Add(jsonStep);
        }

        public static void ScenarioUpdate(ScenarioContext scenarioContext)
        {
            JsonScenario scenario = scenarios.Find(p => p.Name.Equals(scenarioContext.ScenarioInfo.Title));
            StringBuilder stringBuilder = new StringBuilder();
            scenario.Steps.ForEach(step => stringBuilder.Append(string.IsNullOrEmpty(step.Result.ExeptionMessage.ToString().Trim()) ? string.Empty : step.Result.ExeptionMessage.ToString().Trim()));

            scenario.Result = new JsonResult
            {
                Status = scenario.Steps.Any(p => !p.Result.Status.Equals(StatusEnum.Pass)) ? StatusEnum.Fail : StatusEnum.Pass,
                ExeptionMessage = stringBuilder,
                Duration = scenario.Steps.Sum(p => float.Parse(p.Result.Duration)).ToString()
            };
        }

        public static void UpdateScreenshot(ScenarioContext scenarioContext,string filePath)
        {
            JsonScenario scenario = scenarios.Find(p => p.Name.Equals(scenarioContext.ScenarioInfo.Title));
            scenario.ScreenshotPath = filePath;
        }

        public static List<JsonScenario> GetObject()
        {
            return scenarios;
        }
        public static void GenerateReport()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "cucumber.json");
            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, scenarios);
            }
        }
    }
}