using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using TAF_GenericUtility;
using TAF_GenericUtility.Scripted.dataload;
using TAF_GenericUtility.Scripted.DataWrite;
using TAF_GenericUtility.Scripted.generic;
using TAF_GenericUtility.Scripted.ROI;
using TAF_GenericUtility.Scripted.Screenshot;
using TAF_Reporting.HTML;
using TAF_Reporting.Json;
using TAF_SAP;
using TAF_Scripting.Test.Common;
using TAF_Scripting.Test.Scripted;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;
using TAF_Integration.Scripted.ADO;
using TAF_Scripting.Test.Scripted.StepDefinitions;

namespace TAF_Scripting
{
    [Binding]
    public class TAFHooks
    {
        public static Scenario _scenario;
        public static string Base_Path;
        public static string CDB_Execution;
        public static string Feature_ID;
        public static string hub_Browser;
        public static string Node_URL;
        public static String Project_Name;
        public static String RunID;
        public static string Scenario_Exec_ID;
        public static string Scenario_ID;
        public static string Scenario_Status;
        public static DateTime startTime;
        public static string Step_Comment;
        public static string Step_ID;
        public static string Step_Status;
        public static string Duration;
   
        [ThreadStatic]
        public string setComplexity;
        public string totalhours;
        private readonly FeatureContext _featureContext;
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _ScenarioContext;
        public static ApplicationCache ApplicationCache { get; set; }
        private static object _lockObj = new object();
        private static TAFHooks _instance;
        private static object adoutil;
        private static bool isADOEnabled = false; 

        public TAFHooks(IObjectContainer objectContainer,
            ScenarioContext ScenarioContext,
            FeatureContext featureContext
                    
           )
        {
            this._objectContainer = objectContainer;
            this._ScenarioContext = ScenarioContext;
            this._featureContext = featureContext;

            if (!log4net.LogManager.GetRepository().Configured)
            {
                // log4net not configured
                log4net.Config.XmlConfigurator.Configure();
            }
            string propertyFile = GlobalVariables.GetscriptmateconfigPath();
            isADOEnabled = bool.Parse(ConfigDriver.getPropertyValue(propertyFile, "ADO"));
            //log4net.Config.XmlConfigurator.Configure();

        }

        
        public static TAFHooks GetCurrentInstance()
        {
            return _instance;

        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            Environment.CurrentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            HTMLReport.BeforeTest();

            JsonReport.Initialize();
            ApplicationCache = new ApplicationCache();

            KillDrivers();

        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontextvis)
        {
            //string ff = TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title;
            HTMLReport.beforefeature(featurecontextvis.FeatureInfo.Title);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
           
            HTMLReport.AfterTest();
           
            //ADOUtil.UpdateTestResult(JsonReport.GetObject(), isADOEnabled);

            ApplicationCache = null;

            KillDrivers();
        }

        //[AfterFeature]
        //public static void TearDownReport_feature()
        //{

        //    HTMLReport.AfterTest();

        //    ADOUtil.UpdateTestResult(JsonReport.GetObject(), isADOEnabled);

        //    ApplicationCache = null;

        //    KillDrivers();
        //}

        [AfterStep]
        public void AfterStep()
        {
            HTMLReport.AfterStep(this._ScenarioContext);
            JsonReport.ScenarioStepUpdate(this._ScenarioContext);
        }

        [BeforeStep]
        public void BeforeStep()
        {
            if(_ScenarioContext.TestError!=null)
            {
               // HTMLReport.AfterStep(this._ScenarioContext);
                JsonReport.ScenarioStepUpdate(this._ScenarioContext);
            }           
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            HTMLReport.BeforeScenario(this._featureContext, this._ScenarioContext);
            JsonReport.ScenarioInitialize(this._ScenarioContext);
        }


        [AfterScenario]
        public void SetTestNameInReport()
        {
            // HTMLReport.BeforeScenario(this._featureContext, this._ScenarioContext);
            string name = TestContext.CurrentContext.Test.Name;
           //string Screen_Shot = TakeWebScreenshot();
            HTMLReport.UpdateTestNameInReport(name,_ScenarioContext,ApplicationCache.ReportParameters);
            
            JsonReport.ScenarioUpdate(this._ScenarioContext);
            //AttachWebScreenshotToReport(Screen_Shot);
            ADOUtil.UpdateTestResult(JsonReport.GetObject(), isADOEnabled);
            //Closing the browser window after scenario on failure
            WebCleanUp();
           // KillDrivers();
        }



        [AfterScenario("@OrderCreation")]
        public void CaptureOrderDetails()
        {
            ExcelDataWrite excelwrite = new ExcelDataWrite();
            Dictionary<int, List<string>> data = new Dictionary<int, List<string>>();
            Dictionary<int, List<string>> dataSAPDispatch = new Dictionary<int, List<string>>();

            if (_ScenarioContext.TestError != null)
                DataFilesUtil.SaveDataToExcel(ApplicationCache.TestDataFile, ApplicationCache.SheetName, "Status", ApplicationCache.TestCaseID, "FAILED");
          
            else
                DataFilesUtil.SaveDataToExcel(ApplicationCache.TestDataFile, ApplicationCache.SheetName, "Status", ApplicationCache.TestCaseID, "PASSED");

             string output = DataFilesUtil.GetExcelLocation(ApplicationCache.TestDataFile);
            if (ApplicationCache.StormOrderCodes!=null)
            {

                //ExcelDriver excelDriver = new ExcelDriver(output, "TC_SAP_Dispatch");
                //int sapTestID = excelDriver.GetExcelRowsCount();
          
                for (int indx = 0; indx < ApplicationCache.StormOrderCodes.Count; indx++)
                {
     
                    List<string> row = new List<string>();

                    row.Add(ApplicationCache.TestCaseID);                    
                    row.Add(ApplicationCache.PortalOrderNumber);
                    row.Add(ApplicationCache.StormOrderCodes[indx]);
                    row.Add(ApplicationCache.OrderType);
                    row.Add(ApplicationCache.CardNumber);
                    row.Add(ApplicationCache.OrderTotal);
                    row.Add(ApplicationCache.TaxAmount);
                    row.Add(ApplicationCache.OrderCreationDate);
                    row.Add(ApplicationCache.Orderstatus[indx]);
                    row.Add(ApplicationCache.CustomerEmail);
                    row.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                                      
                    data.Add(indx + 1, row);


                    List<string> rowSAPDispatch = new List<string>();

                    string sCode = ApplicationCache.StormOrderCodes[indx];
                    sCode = sCode.Substring(0, 3);
                    //  sCode = string.Concat("SAP_", sCode, "_D", sapTestID);
                    sCode = string.Concat(ApplicationCache.TestCaseID,  "_", sCode);
                    //sapTestID++;
                    rowSAPDispatch.Add(sCode);
                    rowSAPDispatch.Add(ApplicationCache.StormOrderCodes[indx]);
                    string CDate = (ApplicationCache.OrderCreationDate).Replace("/",".");
                   
                    rowSAPDispatch.Add(CDate);
                    dataSAPDispatch.Add(indx + 1, rowSAPDispatch);

                }
            }

            else if(!string.IsNullOrEmpty(ApplicationCache.PortalOrderNumber))
            {
                List<string> row = new List<string>();
                row.Add(ApplicationCache.TestCaseID);
                row.Add(ApplicationCache.PortalOrderNumber);
                row.Add("");
                row.Add(ApplicationCache.OrderType);
                row.Add(ApplicationCache.CardNumber);
                row.Add(ApplicationCache.OrderTotal);
                row.Add(ApplicationCache.TaxAmount);
                row.Add(ApplicationCache.OrderCreationDate);
                row.Add("");
                row.Add(ApplicationCache.CustomerEmail);
                row.Add(DateTime.Now.ToString("dd/MM/yyyy"));

                data.Add( 1, row);
              }
          
         //   ApplicationCache.ExcelPath = output;
        //    excelwrite.WriteToExcel(output, "AllOrders", output, true, data,true);
            DataFilesUtil.SaveMultipleDataToExcel(ApplicationCache.TestDataFile, "AllOrders",  true, data, true);
            if (dataSAPDispatch.Count > 0)
            {
                // excelwrite.WriteToExcel(output, "TC_SAP_Dispatch", output, true, dataSAPDispatch, true);
                DataFilesUtil.SaveMultipleDataToExcel(ApplicationCache.TestDataFile, "TC_SAP_Dispatch",  true, dataSAPDispatch, true);
            }
            JsonReport.ScenarioUpdate(this._ScenarioContext);
        }

        
        [AfterScenario("@Web")]
        public void WebCleanUp()
        {
            string imagePath = string.Empty;
            
            if (_ScenarioContext.TestError != null && BrowserDriver.GetDriver() != null)
            {
                AttachWebScreenshotToReport(ApplicationCache.TestCaseID+"_"+DateTime.Now.ToString("DDMMYYYY_HHMMSS"));
                BrowserDriver.CloseBrowser();
            }

            HTMLReport.AfterScenario(imagePath);

            if (ApplicationCache != null)
            {
                HTMLReport.AfterScenario(ApplicationCache.ExcelPath);
            }
            JsonReport.ScenarioUpdate(this._ScenarioContext);
        }

        [AfterScenario("@SAPDispatch")]
        public void SAPDispatchStatus()
        {
            string imagePath = string.Empty;

            if (_ScenarioContext.TestError != null && SAPDriver.GetCurrentInstance() != null)
            {
                //SAP
               // imagePath = TakeDesktopScreenshot();
                AttachDesktopScreenshotToReport("SAP_Dispatch_Error_" + ApplicationCache.TestCaseID);
                SAPDriver.Instance.CloseAllConnections();
                SAPDriver.Instance.CloseProcess();
                ApplicationCache.SAPStatus = "Failed";
            }
            DataFilesUtil.SaveDataToExcel(ApplicationCache.TestDataFile, ApplicationCache.SheetName, "OrderStatus", ApplicationCache.TestCaseID, ApplicationCache.SAPStatus);
            HTMLReport.AfterScenario(imagePath);
            JsonReport.ScenarioUpdate(this._ScenarioContext);
        }

        
       

        [AfterScenario("@SAPStockAdjustment")]
        public void captureSAPStockAdjustmenthStatus()
        {
            string imagePath = string.Empty;


            if (_ScenarioContext.TestError != null && SAPDriver.GetCurrentInstance() != null)
            {
                //SAP
                imagePath = TakeDesktopScreenshot();

                SAPDriver.Instance.CloseAllConnections();
                SAPDriver.Instance.CloseProcess();

            }
            DataFilesUtil.SaveDataToExcel(ApplicationCache.TestDataFile, ApplicationCache.SheetName, "Status", ApplicationCache.TestCaseID, ApplicationCache.SAPStatus);
            HTMLReport.AfterScenario(imagePath);
            JsonReport.ScenarioUpdate(this._ScenarioContext);
        }
        

        [AfterScenario("@SAP")]
        public void SAPCleanUp()
        {
            string imagePath = string.Empty;
           

            if (_ScenarioContext.TestError != null && SAPDriver.GetCurrentInstance() != null)
            {
                //SAP
                imagePath = TakeDesktopScreenshot();

                SAPDriver.Instance.CloseAllConnections();
                SAPDriver.Instance.CloseProcess();

            }



            if (_ScenarioContext.TestError != null)
                DataFilesUtil.SaveDataToExcel(ApplicationCache.TestDataFile, ApplicationCache.SheetName, "Status", ApplicationCache.TestCaseID, "FAILED");

            else
                DataFilesUtil.SaveDataToExcel(ApplicationCache.TestDataFile, ApplicationCache.SheetName, "Status", ApplicationCache.TestCaseID, "PASSED");


            HTMLReport.AfterScenario(imagePath);
            JsonReport.ScenarioUpdate(this._ScenarioContext);

        }

        public  void AttachWebScreenshotToReport(string fileNameBase)
        {        

            var vcs = new VerticalCombineDecorator(new ScreenshotMaker());
            var screen = BrowserDriver.GetDriver().TakeScreenshot(vcs);
            
       
            string screenshotFolder = Path.Combine(HTMLReport.dirPath + GlobalVariables.getScreenShotPath());
            string filepath = string.Format("{0}\\{1}", screenshotFolder, DateTime.Now.ToString("dd-MM-yyyy"));
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
                                  
            string screenshotFilePath = Path.Combine(filepath, fileNameBase + "_screenshot.png");


            File.WriteAllBytes(screenshotFilePath, screen);
            JsonReport.UpdateScreenshot(_ScenarioContext, screenshotFilePath);
            HTMLReport.AfterScenario(screenshotFilePath);
        }
              

        private string TakeWebScreenshot()
        {
            try
            {
                var mainframeTags = this._ScenarioContext.ScenarioInfo.Tags.Where(p => p.CaseInsensitiveContains("mainframe"));
                var desktopTags = this._ScenarioContext.ScenarioInfo.Tags.Where(p => p.CaseInsensitiveContains("desktop"));

                if (!mainframeTags.Any() || !desktopTags.Any())
                {

                    IWebDriver driver = BrowserDriver.GetDriver();
                    if (driver != null)
                    {
                        string path = HTMLReport.TakeScreenshot(BrowserDriver.GetDriver(), _ScenarioContext);
                        JsonReport.UpdateScreenshot(_ScenarioContext, path);
                        return path;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //need to write message
            }
            return string.Empty;
        }

        public static void KillDrivers()
        {
            try
            {



                //Others

                string command = "";

                command += "taskkill /f /im chromedriver.exe";
                //command += " && " + "taskkill /f /im geckodriver.exe";
                //command += " && " + "taskkill /f /im IEDriverServer.exe";
                //command += " && " + "taskkill /f /im Winium.Desktop.Driver.exe";

                Process process = new Process();
                process.StartInfo.Verb = "runas";
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = command; // Note the /c command (*)
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AttachDesktopScreenshotToReport(string FileNameAppender)
        {
            string imagePath = TakeDesktopScreenshot(FileNameAppender);
            JsonReport.UpdateScreenshot(_ScenarioContext, imagePath);
            HTMLReport.AfterScenario(imagePath);
        }

        private string TakeDesktopScreenshot(string FileNameAppender="")
        {
            try
            {

                var sapTags = this._ScenarioContext.ScenarioInfo.Tags.Where(p => p.CaseInsensitiveContains("sap"));


                if (sapTags.Any())
                {
                    ScreenCapture capture = new ScreenCapture();
                    return capture.CaptureScreenToFile(this._ScenarioContext, FileNameAppender);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //need to write message
            }
            return string.Empty;
        }

       

    }
}