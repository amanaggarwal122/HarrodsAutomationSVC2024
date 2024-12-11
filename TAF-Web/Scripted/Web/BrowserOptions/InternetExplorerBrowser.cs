using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using TAF_GenericUtility;

namespace TAF_Web.Scripted.Web.BrowserOptions
{
    public class InternetExplorerBrowser : IBrowser
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IWebDriver StartDriver(string fileName)
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            try
            {
         

                options.IgnoreZoomLevel = true;
                options.EnsureCleanSession = true;
                options.RequireWindowFocus = true;
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.EnablePersistentHover = true;
                SetOptionsFromFile(options, fileName);
                options.AddAdditionalCapability("CapabilityType.ACCEPT_SSL_CERTS", true);
                options.UnhandledPromptBehavior = OpenQA.Selenium.UnhandledPromptBehavior.Ignore;
                options.AddAdditionalCapability("CapabilityType.UNHANDLED_PROMPT_BEHAVIOUR", true);
                options.AddAdditionalCapability("javascriptEnabled", true);
            }
            catch (Exception e)
            {
                log.Error("Error occurred while configuring IExplorer , Exception: " + e);
                Assert.Fail("Error occurred while configuring IExplorer , Exception: " + e);
            }

            return new InternetExplorerDriver(WebDriverPathUtil.GetIEDriverPath(),options);
        }

        private static void SetOptionsFromFile(InternetExplorerOptions options, string fileName)
        {

            Dictionary<string, string> properties = TAF_GenericUtility.ConfigDriver.GetConfigProperties(fileName);

            foreach (var item in properties)
            {
                if (item.Key.ToLower().Contains("ieoptions"))
                {
                    options.AddAdditionalCapability(item.Key.Replace("ie.ieoptions.", ""), item.Value);
                }
            }
        }
    }
}
