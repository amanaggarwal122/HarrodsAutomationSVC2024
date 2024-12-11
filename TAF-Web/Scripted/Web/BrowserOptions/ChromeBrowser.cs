﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility;

namespace TAF_Web.Scripted.Web.BrowserOptions
{
    public class ChromeBrowser: IBrowser
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IWebDriver StartDriver(string fileName)
        {
            //add new  environment            
            ChromeOptions options = new ChromeOptions();
            try
            {
                
                options.LeaveBrowserRunning = true;
                options.AddUserProfilePreference("safebrowsing.enabled", true);
                options.AddUserProfilePreference("credentials_enable_service", false);
                options.AddUserProfilePreference("profile.password_manager_enabled", false);
                options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                options.AddUserProfilePreference("profile.content_settings.pattern_pairs.*.multiple-automatic-downloads", 1);
                options.AddUserProfilePreference("download.prompt_for_download", false);
                SetOptionsFromFile(options, fileName);
                options.AddArgument("no-sandbox");
                options.AddArgument("disable-plugins");
                options.AddArgument("disable-extensions");
                options.AddArgument("allow-running-insecure-content");
                options.AddArgument("ignore-certificate-errors");
                options.AddArgument("--always-authorize-plugins");
                options.AddArgument("--disable-notifications");
                options.AddArgument("disable-infobars");
                options.AddArgument("--test-type");
                //options.AddArgument(@"--user-data-dir=C:\Users\vd143773\AppData\Local\Google\Chrome\User Data\Profile 1");
            }
            catch (Exception e)
            {
                log.Error("Error occurred while initialising chrome browser, Exception :" + e);
                Assert.Fail("Error occurred while initialising chrome browser, Exception :" + e);
            }
            return new ChromeDriver(WebDriverPathUtil.GetChromeDriverPath(), options);
        }

        private static void SetOptionsFromFile(ChromeOptions options, string fileName)
        {
            Dictionary<string, string> properties = TAF_GenericUtility.ConfigDriver.GetConfigProperties(fileName);

            foreach (var item in properties)
            {
                if (item.Key.ToLower().Contains("chromeprefs"))
                {
                    options.AddUserProfilePreference(item.Key.Replace("chrome.chromeprefs.", ""), item.Value);
                }
            }
        }
    }
}

