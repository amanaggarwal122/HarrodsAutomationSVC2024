using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility;

namespace TAF_Web.Scripted.Web.BrowserOptions
{
    public class FirefoxBrowser : IBrowser
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver StartDriver(string fileName)
        {
            FirefoxOptions options = new FirefoxOptions();
            try
            {                
                options.AcceptInsecureCertificates = true;
                options.SetPreference("javascript.enabled",true);
                options.UnhandledPromptBehavior = OpenQA.Selenium.UnhandledPromptBehavior.Ignore;
                SetOptionsFromFile(options, fileName);
            }
            catch (Exception e)
            {
                log.Error("Error occured while configuring firefox , Exception: " + e);
                Assert.Fail("Error occured while configuring firefox , Exception: " + e);
            }

            return new FirefoxDriver(WebDriverPathUtil.GetGeckoDriverPath(), options);
        }

        private void SetOptionsFromFile(FirefoxOptions options, string fileName)
        {

            Dictionary<string, string> properties = TAF_GenericUtility.ConfigDriver.GetConfigProperties(fileName);

            foreach (var item in properties)
            {
                if (item.Key.ToLower().Contains("firefoxoptions"))
                {
                    options.AddAdditionalCapability(item.Key.Replace("firefox.firefoxoptions.", ""), item.Value);
                }
            }
        }
    }
}

