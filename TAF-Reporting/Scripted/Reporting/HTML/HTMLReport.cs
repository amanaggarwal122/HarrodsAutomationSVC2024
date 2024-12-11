using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Text;
using System.Reflection;
using TechTalk.SpecFlow;
using System.IO;
using System.Threading;
using NUnit.Framework;
using NUnit.Allure.Core;
using System.Configuration;
using TAF_GenericUtility;
using System.Diagnostics;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Allure.Commons;
using System.Collections.Generic;

namespace TAF_Reporting.HTML
{
    [TestFixture]
    [AllureNUnit]
    public class HTMLReport
    {
        public static bool IsAllure = false;
        public static bool IsExtent = true;
       

        public static void BeforeTest()
        {
            string propertyFile = GlobalVariables.GetscriptmateconfigPath();
            IsAllure = bool.Parse(ConfigDriver.getPropertyValue(propertyFile, "Allure"));

            if (IsAllure)
            {
                AllureReport.BeforeTest_InitializeReport();
            }
            if (IsExtent)
            {
                ExtentReport.BeforeTestRun();
            }
            
        }

        public static void AfterTest()
        {
            if (IsAllure)
            {
                AllureReport.AfterTest_WriteReport();
            }

            if (IsExtent)
            {
                ExtentReport.AfterTestRun();
            }

        }

        public static void beforefeature(string _featureContext)
        {
            ExtentReport.BeforeFeature(_featureContext);
        }

        public static void BeforeScenario(FeatureContext _featureContext,ScenarioContext _scenarioContext)
        {
            if (IsExtent)
            {
                ExtentReport.BeforeScenario(_scenarioContext);
            } 
        }

        public static void AfterScenario(string imagePath)
        {
           
            if (IsAllure)
            {
               AllureReport.AfterScenario_AddReportAttachment(imagePath);
            }
            //if (IsExtent)
            //{
            //    ExtentReport.AfterScenario_AddExtendReportAttachment(imagePath);
            //}

        }

        public static void UpdateTestNameInReport(string TestName, ScenarioContext _ScenarioContext, Dictionary<string,string> Paramters=null)


        {
            AllureReport.SetTestName(TestName, _ScenarioContext, Paramters);
            
        }

        public static void AfterStep(ScenarioContext _scenarioContext)
        {
            if (IsExtent)
            {
                ExtentReport.InsertReportingSteps();
            } 
        }

        public static string dirPath = ConfigDriver.getDirPath();

        //To take the screenshot and attach with the failed Scenario
        public static string TakeScreenshot(IWebDriver driver, ScenarioContext _scenarioContext)
        {
            string[] tags = _scenarioContext.ScenarioInfo.Tags;

            if (_scenarioContext.TestError != null)
            {
                try
                {
                    string fileNameBase = string.Format("Screenshot_{0}_{1}",
                                                     tags.Length > 0 ? tags[0] : string.Empty,
                                                      DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                    string screenshotFolder = Path.Combine(dirPath + GlobalVariables.getScreenShotPath());
                    string filepath = string.Format("{0}\\{1}", screenshotFolder, DateTime.Now.ToString("dd-MM-yyyy"));
                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }
                    //var artifactDirectory = Path.Combine(dirPath + GlobalVariables.getScreenShotPath());
                    //if (!Directory.Exists(artifactDirectory))
                    // Directory.CreateDirectory(artifactDirectory);

                    string pageSource = driver.PageSource;
                    string sourceFilePath = Path.Combine(filepath, fileNameBase + "_source.html");
                    File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                    //Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                    ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                    if (takesScreenshot != null)
                    {
                        var screenshot = takesScreenshot.GetScreenshot();
                        string screenshotFilePath = Path.Combine(filepath, fileNameBase + "_screenshot.png");                        
                        screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);
                        return screenshotFilePath;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while taking screenshot: {0}", ex);
                }
            }
            return string.Empty;
        }

        
    }
}
