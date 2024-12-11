
using System;
/// <summary>
/// Class used to derive the webdriver
/// </summary>
namespace TAF_Web.Scripted.Web
{
    #region Using  

    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Opera;
    using OpenQA.Selenium.Remote;
    using System;
    using System.IO;
    using System.Threading;
    using TAF_GenericUtility;
    using TAF_Web.Scripted.Web.BrowserOptions;


    #endregion

    public class BrowserDriver
    {
        public static IWebDriver driver { get; set; }
        public static IWebDriver Instance { get; set; }

        //public static RemoteWebDriver thDriver = null;

        //public static ThreadLocal<RemoteWebDriver> thDriver = new ThreadLocal<RemoteWebDriver>();
        public static IWebDriver idriver = null;

        public static string dirPath = ConfigDriver.getDirPath();
        public static string strBinPath = dirPath + @"\bin\Debug\";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public static ThreadLocal<IWebDriver> lthDriver = new ThreadLocal<IWebDriver>();
        public static ThreadLocal<RemoteWebDriver> thDriver = new ThreadLocal<RemoteWebDriver>();

        static string strhostURL = string.Empty;
        static bool strrecordVideo = false;
        static bool strenableVideo = false;
        static bool strenableVNC = false;
        static string strBrowserName = string.Empty;
        static string strBrowserVersion = string.Empty;
        static string strBrowserNameAndVersion = string.Empty;
 
        public static IWebDriver FuncGetWebdriver()
        {
            try
            {
                if (driver == null)
                {
                    strBrowserName = ConfigDriver.Config("browserName").ToLower();
                    log.Info("Current browser:" + strBrowserName);
                }
                else
                {
                    return driver;
                }
                if (!string.IsNullOrEmpty(strBrowserName))
                {
                    log.Info("Browser : " + strBrowserName);
                    BrowserFactory factory = new BrowserFactory();
                    strBrowserName = strBrowserName.ToLower();

                    if (string.IsNullOrEmpty(strBrowserName))
                        Assert.Fail("Please add the configuration for " + strBrowserName + " in the BrowserManger");
                    driver = factory.GetBrowser(strBrowserName);
                    log.Info($"Driver for browser {strBrowserName} initiated");

                }
                //if no browser key value is provided in the app.config
                else
                {
                    Assert.Fail("No browser input key is provided, please check and verify");
                }
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WebConstants.DRIVER_IMPLICIT_WAIT_SECS);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(WebConstants.DRIVER_PAGE_LOAD_WAIT_SECS);
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Window.Maximize();
            }
            catch (Exception e)
            {
                log.Error("Error occurred while configuring webdrivers" + "Exception :" + e);
                Assert.Fail("Webdriver initialisation issues" + "Exception :" + e);
            }
            return driver;
        }
        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns></returns>
        public static IWebDriver FuncGetNgWebdriver()
        {
            throw new NotImplementedException();
        }
        public static void LaunchWebURL(String strURL)
        {
            try
            {
                //GetDriver().Manage().Window.Maximize();
                if (!(strURL.StartsWith("http://") || strURL.StartsWith("https://")))
                    throw new InvalidOperationException("URL is invalid format and cannot open page");
                GetDriver().Navigate().GoToUrl(strURL);
                PageWait();
            }
            catch (Exception e)
            {
                GetDriver().Close();
                log.Error("Error occurred while launching Web URL" + "Exception :" + e);
                Assert.Fail("Error occurred while launching Web URL" + "Exception :" + e);
            }

        }

        public static void RefreshBrowser()
        {
            GetDriver().Navigate().Refresh();
        }
        public static void CloseBrowser()
        {
            try
            {
                GetDriver().Close();
                QuitBrowser();
            }
            catch (Exception e)
            {
                DisposeThreadLocalDriver();
                log.Error("Error occurred while closing browser" + "Exception :" + e);
                Assert.Fail("Error occurred while closing browser" + "Exception :" + e);
            }
        }
        public static void QuitBrowser()
        {
            try
            {
                GetDriver().Quit();
                GetDriver().Dispose();
                driver = null;
                DisposeThreadLocalDriver();
            }
            catch (Exception e)
            {
                DisposeThreadLocalDriver();
                log.Error("Error occurred while quit browser" + "Exception :" + e);
                Assert.Fail("Error occurred while quit browser" + "Exception :" + e);
            }
        }
        public static IWebDriver GetDriver()
        {

            if (driver == null)
            {
                if (thDriver.Value != null)
                {
                    return thDriver.Value;
                }
                else
                {
                    return lthDriver.Value;
                }
            }
            else
            {
                return driver;
            }

        }

        public static void DisposeThreadLocalDriver()
        {
            if (thDriver.Value != null)
            {
                thDriver.Value = null;
            }
            else
            {
                lthDriver.Value = null;
            }
        }

        public static void PageWait()
        {
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WebConstants.DRIVER_IMPLICIT_WAIT_SECS);
            GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(WebConstants.DRIVER_PAGE_LOAD_WAIT_SECS);
        }
        public static IWebDriver GetSeleniunGridDriver(String browser)
        {
            try
            {
                Uri uri = null;
                log.Info("Browser : " + browser);
                string strhostURL = ConfigDriver.getPropertyValue(GlobalVariables.GetSeleniumGridConfig(), "hostURL");

                switch (browser)
                {
                    case "chrome":
                        ChromeOptions cOptions = new ChromeOptions();
                        cOptions.AddArgument("no-sandbox");
                        cOptions.AcceptInsecureCertificates = true;
                        uri = new Uri(strhostURL);
                        thDriver.Value = new RemoteWebDriver(uri, cOptions);
                        break;

                    case "firefox":
                        FirefoxOptions fOptions = new FirefoxOptions();
                        fOptions.AcceptInsecureCertificates = true;
                        uri = new Uri(strhostURL);
                        thDriver.Value = new RemoteWebDriver(uri, fOptions);
                        break;

                    case "internet explorer":
                        InternetExplorerOptions iOptions = new InternetExplorerOptions();
                        iOptions.AcceptInsecureCertificates = true;
                        //iOptions.AddAdditionalCapability("version", "78");
                        uri = new Uri(strhostURL);
                        thDriver.Value = new RemoteWebDriver(uri, iOptions);
                        break;

                    case "opera":
                        OperaOptions oOptions = new OperaOptions();
                        oOptions.AcceptInsecureCertificates = true;
                        //oOptions.AddAdditionalCapability("version", "78");
                        uri = new Uri(strhostURL);
                        thDriver.Value = new RemoteWebDriver(uri, oOptions);
                        break;
                }



            }
            catch (Exception ex)
            {
                log.Error(ex.StackTrace);
            }

            return GetDriver();
        }
        public static IWebDriver GetSelenoidWebDriver()
        {
            Uri uri = null;
            string strhostURL = ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "hostURL");
            string strBrowserName = ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "browserName");
            string strBrowserVersion = ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "browserVersion");

            if (strBrowserName == null || strBrowserName.Equals(" "))
            {
                log.Info("Browser name is null, please check the value of browserName in config.properties");
                throw new InvalidOperationException("Browser name is null, please check the value of browserName in config.properties");
            }
            else
            {
                try
                {
                    log.Info("Browser : " + strBrowserName);
                    strBrowserName = strBrowserName.ToLower();

                    DesiredCapabilities capabilities = new DesiredCapabilities(strBrowserName, strBrowserVersion, new Platform(PlatformType.Any));
                    capabilities.SetCapability("enableVNC", true);
                    capabilities.SetCapability("enableVideo", false);
                    capabilities.AcceptInsecureCerts = true;
                    uri = new Uri(strhostURL);

                    switch (strBrowserName)
                    {

                        case "chrome":
                            driver = new RemoteWebDriver(uri, capabilities);
                            break;

                        case "ie":
                            driver = new RemoteWebDriver(uri, capabilities);
                            break;

                        case "firefox":
                            driver = new RemoteWebDriver(uri, capabilities);
                            break;
                    }
                }
                catch (Exception e)
                {
                    log.Error("Error occurred while configuring webdrivers" + "Exception :" + e);
                    Assert.Fail("Webdriver initialisation issues" + "Exception :" + e);
                }

                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WebConstants.DRIVER_IMPLICIT_WAIT_SECS);
                GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(WebConstants.DRIVER_PAGE_LOAD_WAIT_SECS);
                GetDriver().Manage().Cookies.DeleteAllCookies();
                GetDriver().Manage().Window.Maximize();
                return GetDriver();
            }
        }
        public static IWebDriver GetSelenoidDriverParallel(String browser, String version)
        {
            try
            {
                Uri uri = null;

                string strhostURL = ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "hostURL");
                bool strrecordVideo = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "recordVideo"));
                bool strenableVideo = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "enableVideo"));
                bool strenableVNC = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "enableVNC"));
                DesiredCapabilities capabilities = new DesiredCapabilities(browser.ToLower(), version, new Platform(PlatformType.Any));

                switch (browser)
                {
                    case "chrome":
                    case "firefox":
                    case "opera":
                    case "internet explorer":
                        capabilities.SetCapability("enableVNC", true);
                        capabilities.SetCapability("recordVideo", true);
                        capabilities.SetCapability("enableVideo", false);
                        capabilities.AcceptInsecureCerts = true;
                        uri = new Uri(strhostURL);
                        thDriver.Value = new RemoteWebDriver(uri, capabilities);
                        break;
                }

                GetDriver().Manage().Cookies.DeleteAllCookies();
                GetDriver().Manage().Window.Maximize();
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WebConstants.DRIVER_IMPLICIT_WAIT_SECS);
                GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(WebConstants.DRIVER_PAGE_LOAD_WAIT_SECS);

            }
            catch (Exception e)
            {
                log.Error("Error occurred while configuring webdrivers" + "Exception :" + e);
                Assert.Fail("Webdriver initialisation issues" + "Exception :" + e);
            }
            return GetDriver();
        }
        public static IWebDriver GetSelenoidDriverSeq(String browser, String browserVersion)
        {
            try
            {
                Uri url = null;

                if (driver == null)
                {
                    strBrowserName = browser;
                    strBrowserVersion = browserVersion;
                    strBrowserNameAndVersion = ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "browserNameAndVersion");
                    strhostURL = ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "hostURL");
                    strrecordVideo = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "recordVideo"));
                    strenableVideo = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "enableVideo"));
                    strenableVNC = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetSelenoidBrowserConfig(), "enableVNC"));
                }

                if (strBrowserName == null || strBrowserName.Equals(" "))
                {
                    log.Info("Browser name is null, please check the value of browserName in config.properties");
                    throw new InvalidOperationException("Browser name is null, please check the value of browserName in config.properties");
                }
                else
                {
                    log.Info("Browser : " + strBrowserName);
                    strBrowserName = strBrowserName.ToLower();

                    DesiredCapabilities capabilities = new DesiredCapabilities(strBrowserName.ToLower(), strBrowserVersion, new Platform(PlatformType.Any));

                    switch (browser)
                    {
                        case "chrome":
                        case "firefox":
                        case "opera":
                        case "internet explorer":
                            capabilities.SetCapability("enableVNC", true);
                            capabilities.SetCapability("recordVideo", true);
                            capabilities.SetCapability("enableVideo", false);
                            capabilities.AcceptInsecureCerts = true;
                            url = new Uri(strhostURL);
                            thDriver.Value = new RemoteWebDriver(url, capabilities);
                            break;
                    }

                    GetDriver().Manage().Cookies.DeleteAllCookies();
                    GetDriver().Manage().Window.Maximize();
                    GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WebConstants.DRIVER_IMPLICIT_WAIT_SECS);
                    GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(WebConstants.DRIVER_PAGE_LOAD_WAIT_SECS);
                }

            }
            catch (Exception e)
            {
                log.Error("Error occurred while configuring webdrivers" + "Exception :" + e);
                Assert.Fail("Webdriver initialisation issues" + "Exception :" + e);
            }

            return GetDriver();
        }
        public static IWebDriver GetZaleniumDriverParallel(String browser, String version)
        {
            try
            {
                Uri uri = null;

                string strhostURL = ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "hostURL");
                bool strrecordVideo = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "recordVideo"));
                bool strenableVideo = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "enableVideo"));
                bool strenableVNC = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "enableVNC"));
                DesiredCapabilities capabilities = new DesiredCapabilities(browser.ToLower(), version, new Platform(PlatformType.Any));

                switch (browser)
                {
                    case "chrome":
                    case "firefox":
                    case "opera":
                    case "internet explorer":
                        capabilities.SetCapability("enableVNC", strenableVNC);
                        capabilities.SetCapability("recordVideo", strrecordVideo);
                        capabilities.SetCapability("enableVideo", strenableVideo);
                        capabilities.AcceptInsecureCerts = true;
                        uri = new Uri(strhostURL);
                        thDriver.Value = new RemoteWebDriver(uri, capabilities);
                        break;
                }

                GetDriver().Manage().Cookies.DeleteAllCookies();
                GetDriver().Manage().Window.Maximize();
                GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WebConstants.DRIVER_IMPLICIT_WAIT_SECS);
                GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(WebConstants.DRIVER_PAGE_LOAD_WAIT_SECS);

            }
            catch (Exception e)
            {
                log.Error("Error occurred while configuring webdrivers" + "Exception :" + e);
                Assert.Fail("Webdriver initialisation issues" + "Exception :" + e);
            }
            return GetDriver();
        }
        public static IWebDriver GetZaleniumDriverSeq(String browser, String browserVersion)
        {
            try
            {
                Uri url = null;

                if (driver == null)
                {
                    strBrowserName = browser;
                    strBrowserVersion = browserVersion;
                    strBrowserNameAndVersion = ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "browserNameAndVersion");
                    strhostURL = ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "hostURL");
                    strrecordVideo = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "recordVideo"));
                    strenableVideo = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "enableVideo"));
                    strenableVNC = bool.Parse(ConfigDriver.getPropertyValue(GlobalVariables.GetZaleniumBrowserConfig(), "enableVNC"));
                }

                if (strBrowserName == null || strBrowserName.Equals(" "))
                {
                    log.Info("Browser name is null, please check the value of browserName in config.properties");
                    throw new InvalidOperationException("Browser name is null, please check the value of browserName in config.properties");
                }
                else
                {
                    log.Info("Browser : " + strBrowserName);
                    strBrowserName = strBrowserName.ToLower();

                    DesiredCapabilities capabilities = new DesiredCapabilities(strBrowserName.ToLower(), strBrowserVersion, new Platform(PlatformType.Any));

                    switch (browser)
                    {
                        case "chrome":
                        case "firefox":
                        case "opera":
                        case "internet explorer":
                            capabilities.SetCapability("enableVNC", true);
                            capabilities.SetCapability("recordVideo", true);
                            capabilities.SetCapability("enableVideo", false);
                            capabilities.AcceptInsecureCerts = true;
                            url = new Uri(strhostURL);
                            thDriver.Value = new RemoteWebDriver(url, capabilities);
                            break;
                    }

                    GetDriver().Manage().Cookies.DeleteAllCookies();
                    GetDriver().Manage().Window.Maximize();
                    GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WebConstants.DRIVER_IMPLICIT_WAIT_SECS);
                    GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(WebConstants.DRIVER_PAGE_LOAD_WAIT_SECS);
                }

            }
            catch (Exception e)
            {
                log.Error("Error occurred while configuring webdrivers" + "Exception :" + e);
                Assert.Fail("Webdriver initialisation issues" + "Exception :" + e);
            }

            return GetDriver();
        }
        public static IWebDriver GetCuPalDriver()
        {
            try
            {
                BrowserFactory factory = new BrowserFactory();
                string browser = ConfigDriver.Config("browserName").ToLower();

                log.Info("Browser : " + browser);
                lthDriver.Value = factory.GetBrowser(browser);
                log.Info("Thread local driver initiated" + lthDriver);
            }
            catch (Exception e)
            {
                log.Info(e.StackTrace);
            }

            GetDriver().Manage().Cookies.DeleteAllCookies();
            GetDriver().Manage().Window.Maximize();
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WebConstants.DRIVER_IMPLICIT_WAIT_SECS);
            GetDriver().Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(WebConstants.DRIVER_PAGE_LOAD_WAIT_SECS);

            return GetDriver();
        }

        public static void ShowPopup(String message)
        {
            try
            {
                string poup = "function sayHello1(){var infoSpan = document.createElement('div');\r\n" +
                            "infoSpan.id = 'infoSpan';" +
                            "infoSpan.innerHTML = '" + message + "';" +
                            "var style = document.createElement('style');" +
                            "style.innerHTML = '#infoSpan {font-family: Arial;font-size: larger;top: 1px;position: absolute;color: #ffffff;background-color: #ff0000;padding: 20px;;width: 1400px;height: 50px;z-index:2000;}';" +
                            "document.head.appendChild(style);" +
                            "document.body.appendChild(infoSpan);}";

                //((IJavaScriptExecutor)GetDriver()).ExecuteScript($"alert('{message}')");

                //GetDriver().SwitchTo().Alert().Accept();

                IJavaScriptExecutor js = (IJavaScriptExecutor)GetDriver();
                js.ExecuteScript($"{poup} sayHello1();");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Sleep(int milliSecons = 1000)
        {
            System.Threading.Thread.Sleep(milliSecons);
        }

        public static string CreateAuthUrl(String url, String usr, String pwd)
        {
            int p1 = url.IndexOf("://");
            string http = "http://";
            string site = "";

            if (p1 != -1)
            {
                http = url.Substring(0, p1) + "://";
                site = url.Substring(p1 + 3);
            }

            return http + usr + ":" + pwd + "@" + site;
        }

    }
}