using Allure.Commons;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using TAF_GenericUtility;
using TAF_GenericUtility.Scripted.Generic;
using TechTalk.SpecFlow;


namespace TAF_Reporting.HTML
{
    public class AllureReport
    {
        //To get the current dir path
        private static string dirPath = ConfigDriver.getDirPath();

        public static AllureLifecycle AllureLifecycle = new AllureLifecycle();


        public static void BeforeTest_InitializeReport()
        {
            using (StreamReader file = File.OpenText(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath) + "\\allureConfig.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jObject = (JObject)JToken.ReadFrom(reader);
                //string x = (jObject["allure"]["directory"]).ToString();
                string path = jObject.SelectToken("allure").SelectToken("directory").ToString();
                path = Path.Combine(dirPath, path);

                DirectoryInfo directory = null;

                String folder = Path.GetDirectoryName(path);
                if (!Directory.Exists(folder))
                {
                    // Try to create the directory.
                    directory = Directory.CreateDirectory(folder);
                }
                else
                {
                    directory = new DirectoryInfo(path);
                }

                directory.EnumerateFiles()
                    .ToList().ForEach(f => f.Delete());

                directory.EnumerateDirectories()
                    .ToList().ForEach(d => d.Delete(true));
            }

            

        }
        public static void SetTestName(string TestName, ScenarioContext _ScenarioContext, Dictionary<string, string> Parameters = null)
        {
            _ScenarioContext.TryGetValue(out TestResult testresult);
           //string name= _ScenarioContext.ScenarioInfo.Title;
           // name=_ScenarioContext.CurrentScenarioBlock.ToString();
            var paramsMatch = Regex.Match(TestName, @"\((.*)\)$");
            if (paramsMatch.Success)
            {

                //AllureLifecycle.Instance.UpdateTestCase(tc =>
                //{
                //    tc.name = TestName; //In order to have different tests in report
                //    tc.historyId = TestName + Guid.NewGuid().ToString(); // or    Guid.NewGuid().ToString()
                //});
                AllureLifecycle.Instance.UpdateTestCase(testresult.uuid, tc =>
                {
                    //tc.links.Add(new Link()
                    //{
                    //    name = "Example link",
                    //    url = "http://example.com"
                    //});
                    foreach (KeyValuePair<string, string> entry in Parameters)
                    {
                      tc.parameters.Add(new Parameter()
                    {
                        name = entry.Key,
                        value = entry.Value
                      });
                    }

                    

                    tc.name += " " + paramsMatch.Groups[0].Value.Replace(",null", string.Empty);
                    tc.historyId = TestContext.CurrentContext.Test.FullName;
                });
            }
           


        }
        public static void AfterScenario_AddReportAttachment(string imagePath)
        {
            //Seems like the same code is repeating below so commenting below codes, have to test and finalize

            //if (!string.IsNullOrEmpty(imagePath))
            //{
            //    byte[] image = Encoding.ASCII.GetBytes(imagePath);
            //    AllureLifecycle.Instance.AddAttachment(Path.GetFileNameWithoutExtension(imagePath), "image/png", imagePath);
            //}

            string[] excelExtensions = new string[] { ".xls", ".xlsx" };

            if (!string.IsNullOrEmpty(imagePath))
            {
                byte[] image = Encoding.ASCII.GetBytes(imagePath);
                if (excelExtensions.Contains(Path.GetExtension(imagePath)))
                {
                    AllureLifecycle.Instance.AddAttachment(Path.GetFileNameWithoutExtension(imagePath), "application/vnd.ms-excel", imagePath);
                }
                else
                {
                    AllureLifecycle.Instance.AddAttachment(Path.GetFileNameWithoutExtension(imagePath), "image/png", imagePath);
                }
            }
        }

        public static void AfterTest_WriteReport()
        {            

            string timeStamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string reportPath = dirPath + GlobalVariables.GetAllureReportPath();

            string allureReportDir = Path.Combine(reportPath, timeStamp);
            Directory.CreateDirectory(allureReportDir);

            using (StreamReader file = File.OpenText(Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath) + "\\allureConfig.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject jObject = (JObject)JToken.ReadFrom(reader);
                //string x = (jObject["allure"]["directory"]).ToString();
                string y = jObject.SelectToken("allure").SelectToken("directory").ToString();
                y = Path.Combine(dirPath, y);


                string allureHome = string.Empty;
                //allureHome = System.Environment.GetEnvironmentVariable("ALLURE_HOME", EnvironmentVariableTarget.User);

                //if (string.IsNullOrEmpty(allureHome))
                //    allureHome = System.Environment.GetEnvironmentVariable("ALLURE_HOME", EnvironmentVariableTarget.Machine);

                //if (!allureHome.Contains("bin"))
                //    allureHome = $"{allureHome}\\bin";
                allureHome = PathUtil.BasePath()+"\\ExternalDll\\allure-commandline-2.13.0\\allure-2.13.0\\bin";
                    
                string command = $"allure generate \"{y}\" --clean -o \"{allureReportDir}\"";
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd.exe", "/c " + command);
                procStartInfo.WorkingDirectory = allureHome;
                procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                procStartInfo.UseShellExecute = false;
                procStartInfo.Verb = "runas";
                Process proStart1 = new Process();
                proStart1.StartInfo = procStartInfo;
                proStart1.Start();

            }
        }

        public static void b4feature()
        {
            FixtureResult fixtureResult = new FixtureResult();
            fixtureResult.name = "vishnufixturename";
            AllureLifecycle.StartBeforeFixture("vishnuguid", "uuidvishnu", fixtureResult);
            AllureLifecycle.StopFixture("uuidvishnu");
        }
    }

    public class ExtentReport
    {
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        public static string ReportPath;

        public static void BeforeTestRun()
        {
            string path1 = ConfigDriver.getDirPath();
            string path = Path.Combine(path1,"Extent-Report") + "\\Report"+DateTime.Now.ToString("MMddmmss") +"\\index.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        public static void BeforeFeature(string _featureContext)
        {
            featureName = extent.CreateTest<Feature>(_featureContext);
            Console.WriteLine("Before Feature Logged");
        }

        public static void BeforeScenario(ScenarioContext _scenarioContext)
        {
            Console.WriteLine("Before Scenario Logged");
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        public static void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "When")
                                scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "Then")
                                scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if(stepType == "And")
                                scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if(ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if(stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if(stepType == "Then") {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if(stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
            }
        }
        
        public static void AfterScenario_AddExtendReportAttachment(String ScreenShotPath = null)
        {
            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenShotPath).Build());
        }

        public void AfterScenario()
        {
            Console.WriteLine("After Scenario Logged");
        }

        public static void AfterTestRun()
        {
            extent.Flush();
        }
    }

}

