using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Web.Scripted.Web.BrowserConfig
{
    class PhantomJSBrowser
    {
		public class PhatomJSSettings
		{
			private DesiredCapabilities phantomCapabilities = null;

			public DesiredCapabilities SetOptions(string fileName)
			{
				//PhantomJSOptions options = new PhantomJSOptions();
				//options.AddAdditionalCapability("phantomjs.page.settings.UserAgent", "Mozilla/5.0 (iPad; U; CPU OS 3_2 like Mac OS X;en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Version/4.0.4Mobile/7B334b Safari/531.21.10 ");
				//options.AddAdditionalCapability("takesScreenshot", true); 
				//PhantomJSDriverService services = PhantomJSDriverService.CreateDefaultService(WebDriverPathUtil.GetPhatomJSDriverPath());
				//services.HideCommandPromptWindow = true;
				//services.IgnoreSslErrors = true;
				//services.LoadImages = true;
				//services.SuppressInitialDiagnosticInformation = false;
				//phantomCapabilities.IsJavaScriptEnabled = true;
				//phantomCapabilities.SetCapability(capa)

				return phantomCapabilities;
			}
		}
	}
}
