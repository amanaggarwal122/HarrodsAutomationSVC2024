using System;
using System.Collections.Generic;
using System.Text;

namespace TAF_GenericUtility
{
    public class GlobalVariables
    {
        /// <summary>
        /// Private variables declaration and initialisation
        /// </summary>
        private static string _harrodsAppConfig = "/HarrodsAppConfig.config";
        private static string _scriptmateconfigPath = "/ScriptmateConfig.config";
        private static string _browserconfigPath = "/Resources/properties/browser.config";
        private static string _directoryPath = "/Resources/properties/";
        private static string _extentreportPath = "\\ScriptmateReport\\Extent\\";
        private static string _allureReportPath = "\\ScriptmateReport\\Allure\\";
        private static string _allureCommandPath = "\\ExternalDll\\allure-commandline-2.13.0\\allure-2.13.0\\bin";
        private static string _screenshotPath = "\\Resources\\Screenshots";
        private static string _scriptmateReportPath = "/ScriptmateReport/";
        private static string _artefactsPath = "\\Resources\\SkriptmateArtefacts\\";
        private static string _propertiesPath = "/Resources/properties";
        private static string _mobConfigPath = "/Resources/MobileConfigurations/";
        private static string _apiPropertiesPath = "/Resources/apiproperties/";
        private static string _roiPropertiesPath = "/Resources/Roi";
        private static string _chatbotPath = "/Resources/Chatbot Properties";


        public static string GetADOConfig()
        {
            return $"{_propertiesPath}/ado.config";
        }
        public static string GetHarrodsConfig()
        {
            return _harrodsAppConfig;
        }

        public static string GetscriptmateconfigPath()
        {
            return _scriptmateconfigPath;
        }

        public static string GetArtefactsPath()
        {
            return _artefactsPath;
        }

        public static string GetAllureCommandPath()
        {
            return _allureCommandPath;
        }

        public static string GetAllureReportPath()
        {
            return _allureReportPath;
        }

        public static string getbrowserconfigPath()
        {
            return _browserconfigPath;
        }

        public static string getdirectoryconfigPath()
        {
            return _directoryPath;
        }

        public static string getExtentReportPath()
        {
            return _extentreportPath;
        }

        public static string getScreenShotPath()
        {
            return _screenshotPath;
        }

        public static string getscriptmateReportPath()
        {
            return _scriptmateReportPath; ;
        }
              
        public static string GetCogmentoConfig()
        {
            return $"{_propertiesPath}/Cogmento.config";
        }
              
        public static string GetConfigAutomationPrac()
        {
            return $"{_propertiesPath}/configAutomationPrac.config";
        }

        public static string GetConfigOrangehrm()
        {
            return $"{_propertiesPath}/configOrangehrm.config";
        }
        public static string GetCrmConfig()
        {
            return $"{_propertiesPath}/crm.config";
        }

        public static string GetJiraZephyrConfig()
        {
            return $"{_propertiesPath}/JiraZephyr.config";
        }

        public static string GetMainFrameConfig()
        {
            return $"{_propertiesPath}/mainframe.config";
        }

        public static string GetReportConfig()
        {
            return $"{_propertiesPath}/report.config";
        }
        public static string GetSeleniumGridConfig()
        {
            return $"{_propertiesPath}/seleniumGrid.config";
        }

        public static string GetSelenoidBrowserConfig()
        {
            return $"{_propertiesPath}/selenoidBrowser.config";
        }

        public static string GetZaleniumBrowserConfig()
        {
            return $"{_propertiesPath}/zaleniumBrowser.config";
        }

        public static string GetROIConfig()
        {
            return $"{_roiPropertiesPath}/ROIGETApi.config";
        }

        public static string GetMobileConfig()
        {
            return $"{_mobConfigPath}";
        }

        public static string GetApiConfig()
        {
            return $"{_apiPropertiesPath}";
        }

        public static string GetPactConfig()
        {
            return $"{_propertiesPath}/pact.config";
        }

        public static string GetPdfConfig()
        {
            return $"{_propertiesPath}/pdf.config";
        }

        public static string GetOcrConfig()
        {
            return $"{_propertiesPath}/ocr.config";
        }

        public static string GetChatBotConfig()
        {
            return $"{_chatbotPath}/chatbot.config";
        }

        public static string GetChatBotJson()
        {
            return $"{_chatbotPath}/AccuracyTest.json";
        }

        public static string GetSelfHealConfig()
        {
            return $"{_propertiesPath}/selfHealing.config";
        }

        public static string GetAppiumConfig()
        {
            return $"{_propertiesPath}/appium.config";
        }

    }
}
