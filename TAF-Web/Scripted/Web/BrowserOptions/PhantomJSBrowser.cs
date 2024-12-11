using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace TAF_Web.Scripted.Web.BrowserOptions
{
    public class PhantomJSBrowser : IBrowser
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver StartDriver(string fileName)
        {
            //PhantomJSOptions options = new PhantomJSOptions();
            //options.AddAdditionalCapability("phantomjs.page.settings.UserAgent", "Mozilla/5.0 (iPad; U; CPU OS 3_2 like Mac OS X;en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Version/4.0.4Mobile/7B334b Safari/531.21.10 ");

            //PhantomJSDriverService services = PhantomJSDriverService.CreateDefaultService();
            //services.HideCommandPromptWindow = true;
            //services.IgnoreSslErrors = true;
            //services.LoadImages = true;
            //services.SuppressInitialDiagnosticInformation = false;

            //return new PhantomJSDriver(services,options, TimeSpan.FromSeconds(configuration.CommandTimeout));

            return null;
        }

    }
    
}
