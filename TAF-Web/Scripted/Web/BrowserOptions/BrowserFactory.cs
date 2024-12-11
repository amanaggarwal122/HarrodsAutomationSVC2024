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
    public class BrowserFactory
    {
        //use getShape method to get object of type shape 
        public IWebDriver GetBrowser(string browser)
        {
            string browserConfigPath =  GlobalVariables.getbrowserconfigPath();

            if (browser == null)
            {
                return null;
            }

            switch (browser)
            {
                case "chrome":
                    return new ChromeBrowser().StartDriver(browserConfigPath);
                case "ie":
                    return new InternetExplorerBrowser().StartDriver(browserConfigPath);
                case "firefox":
                    return new FirefoxBrowser().StartDriver(browserConfigPath);
                case "opera":
                case "phantom":
                case "edge":
                default:
                    return null;
            }

        }
    }
}
