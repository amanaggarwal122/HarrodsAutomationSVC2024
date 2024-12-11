using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using TAF_Web.Scripted.Web;
using ISearchContext = OpenQA.Selenium.ISearchContext;
using OpenQA.Selenium.Remote;

namespace TAF_Scripting.Test.Common
{
    class ShadowDomHelper
    {
        public IWebDriver driver;
        private IJavaScriptExecutor js;
        private Configuration config = null;

        #region  Constructor
        public ShadowDomHelper(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            this.js = (IJavaScriptExecutor)driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion



        #region Events

        public RemoteWebElement GetShadowElementForFirstDOM(IWebDriver currentDriver,By HostElementofShadowDOM)
        {
            // Find the shadow host element
            var shadowHost = currentDriver.FindElement(HostElementofShadowDOM);

            // Get the shadow root
            var script = "return arguments[0].shadowRoot";
            var shadowRoot = js.ExecuteScript(script, shadowHost);

            // Convert the shadow root to a dictionary to access the elements
            var objDict = (Dictionary<string, object>)shadowRoot;

            // Get the ID of the shadow element
            var id = (string)objDict["shadow-6066-11e4-a52e-4f735466cecf"];

            // Create a RemoteWebDriver instance
           var remoteDriver = (RemoteWebDriver)currentDriver;

            // Return the RemoteWebElement
            return new RemoteWebElement(remoteDriver, id);
        }

        public RemoteWebElement GetShadowElementForNestedDOM(RemoteWebElement currentDriver, By HostElementofShadowDOM)
        {
            // Find the shadow host element
            var shadowHost = currentDriver.FindElement(HostElementofShadowDOM);

            // Get the shadow root
            var script = "return arguments[0].shadowRoot";
            var shadowRoot = js.ExecuteScript(script, shadowHost);

            // Convert the shadow root to a dictionary to access the elements
            var objDict = (Dictionary<string, object>)shadowRoot;

            // Get the ID of the shadow element
            var id = (string)objDict["shadow-6066-11e4-a52e-4f735466cecf"];

            // Create a RemoteWebDriver instance
            var remoteDriver = (RemoteWebDriver)driver;

            // Return the RemoteWebElement
            return new RemoteWebElement(remoteDriver, id);
        }



        public void NavigateToShadowDOMetail()
        {

            // CSS Selector HELP
            //1 : CSS: input[name='username']
            //2 : CSS:input[name='login'][type='submit']
            //3 : Next Sibling CSS: #username + input
            //4 : A link with an “id” that starts with the text “id_prefix_” -- > CSS: a[id^='id_prefix_']

            BrowserDriver.Sleep(3000);
            var js = (IJavaScriptExecutor)driver;

            //To click item in Shadow DOM 1 : 
            var shadowHost = driver.FindElement(By.TagName("main-app"));
            var script = "return arguments[0].shadowRoot";
            var shadowRoot = js.ExecuteScript(script, shadowHost);
            var objDict = (Dictionary<string, object>)shadowRoot;
            var id = (string)objDict["shadow-6066-11e4-a52e-4f735466cecf"];
            var remoteDriver = (RemoteWebDriver)driver;
            var element = new RemoteWebElement(remoteDriver, id);
            var shadowContent = element.FindElement(By.CssSelector("nav > div.fd-side-nav__main-navigation > ul > li:nth-child(2) > ul > li:nth-child(1) > a > span"));
            shadowContent.Click();


            //To click item in Shadow DOM 2 (Where DOM2 inside DOM1 ) : element should be from DOM1 to get inside DOM2
            var shadowHost2 = element.FindElement(By.CssSelector("app-root > fd-busy-indicator > div > div > single-app-page > identity-access-app"));
            var script2 = "return arguments[0].shadowRoot";
            var shadowRoot2 = js.ExecuteScript(script2, shadowHost2);
            var objDict2 = (Dictionary<string, object>)shadowRoot2;
            var id2 = (string)objDict2["shadow-6066-11e4-a52e-4f735466cecf"];
            // var remoteDriver2 = (RemoteWebDriver)driver;
            var element2 = new RemoteWebElement(remoteDriver, id2);

            var shadowContent2 = element2.FindElement(By.CssSelector("ida-user-list-container > div.ida__search-container > ida-search-bar > div > div.search-bar__input > input"));
            shadowContent2.SendKeys("auto_scayle_tc_45_user@yopmail.com");
            var shadowContent3 = element2.FindElement(By.CssSelector("div > div > ida-user-list-container > div.ida__user-list-container > ida-user-list > fd-busy-indicator > table > tbody > tr > td.table-cell--name.fd-table__cell > div > a.fd-link"));
            shadowContent3.Click();


            //To click item in Shadow DOM 3 (Where DOM2 inside DOM2 ) : element should be from DOM2 to get inside DOM3
            var shadowHost3 = element2.FindElement(By.CssSelector("ida-user-profile-container > ida-card:nth-child(3) > fd-layout-panel > fd-layout-panel-body > div:nth-child(2) > ul:nth-child(1) > li.card__control.filled-first-column-item.addresses > ida-card-control-host > ida-complex-data-card-control > div > gigya-casting-editor"));
            var script3 = "return arguments[0].shadowRoot";
            var shadowRoot3 = js.ExecuteScript(script3, shadowHost3);
            var objDict3 = (Dictionary<string, object>)shadowRoot3;
            var id3 = (string)objDict3["shadow-6066-11e4-a52e-4f735466cecf"];
            // var remoteDriver2 = (RemoteWebDriver)driver;
            var element3 = new RemoteWebElement(remoteDriver, id3);

            var shadowContent4 = element3.FindElement(By.CssSelector("gigya-casting-editor-row:nth-child(1) > div > div.gigya-editor__cell.gigya-editor__cell--icons"));

            WebHandlers.Instance.ClickByJsExecutor(shadowContent4);
            //shadowContent4.Click();

            // div.ida__user - list - container > ida - user - list > fd - busy - indicator > table > tbody > tr > td.table - cell--name.fd - table__cell > div > a.fd - link
        }

        public static ISearchContext GetShadowRootElementUsingJavaScript(IWebDriver driver, IWebElement shadowHostElement)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            ISearchContext shadowRootElement = (ISearchContext)js.ExecuteScript("return arguments[0].shadowRoot", shadowHostElement);

            return shadowRootElement;
        }

        public void NavigateToCDCCustomers_OtherTrialMethod()
        {
            BrowserDriver.Sleep(3000);

            var scriptExecutor = driver as IJavaScriptExecutor;
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;


            //IMPORTNT - WORKING
            //var element = js.ExecuteScript("return document.querySelector('main-app').shadowRoot.querySelector('span.fd-nested-list__title');");

            var element = js.ExecuteScript("return document.querySelector('main-app').shadowRoot.querySelector('nav > div.fd-side-nav__main-navigation > ul > li:nth-child(1) > div > a > span');");
            js.ExecuteScript("arguments[0].click();", element);

            var element2 = js.ExecuteScript("return document.querySelector('main-app').shadowRoot.querySelector('nav > div.fd-side-nav__main-navigation > ul > li:nth-child(1) > ul > li:nth-child(1) > a > span');");
            js.ExecuteScript("arguments[0].click();", element2);

            var element3 = js.ExecuteScript("return document.querySelector('main-app').shadowRoot.querySelector('#fdp-search-field-input-0');");
            js.ExecuteScript("arguments[0].setAttribute('Search...', 'new value for element');", element3);

            // First Option
            // driver.FindElement(By.CssSelector('main-app /deep/ [text()='Groups']'));

            //other way - Second Option
            //  driver.FindElement(By.CssSelector("main-app/deep/#fdp-search-field-input-0")).SendKeys("aman");

            //OLD
            //WebHandlers.Instance.ClickByJsExecutor(CDCTry2);


            ////As suggested 
            //// 1.Finding shadow host first - normally using FindElement
            //IWebElement ShadowHostElement = driver.FindElement(By.TagName("main-app"));

            ////2. Finding Shadow Root using Shadow Host element - use either one from below

            ////ISearchContext shadowRoot = GetShadowRootElementUsingJavaScript(driver, ShadowHostElement);
            //// ISearchContext shadowRoot = GetShadowRootElement(ShadowHostElement);

            //IWebElement node = shadowRoot.FindElement(By.Id("fdp-search-field-input-0"));
            //node.SendKeys("Something");





            // Locate the shadow host (main-app)
            IWebElement shadowHost = driver.FindElement(By.XPath("/html/body/main-app"));

            // Access the shadow root
            IWebElement shadowRoot2 = (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot", shadowHost);

            //// Locate the button within the shadow DOM
            //IWebElement btn = shadowRoot.FindElement(By.XPath("//span[contains(text() , 'Identity Access')]"));
            //btn.Click();


            //OLD
            //WebHandlers.Instance.ClickByJsExecutor(CDCTry2);

            //BrowserDriver.Sleep(3000);
            //if (driver.FindElements(SSCNavAdminCustomersTree).Count != 0)
            //{
            //    driver.FindElement(SSCNavAdminCustomersTree).Click();
            //}
            //BrowserDriver.Sleep(3000);
            ////WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
            //WebHandlers.Instance.Click(SSCNavCustomers);
            ////try { WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSearchIcon); }
            ////catch { WebHandlers.Instance.Click(SSCNavCustomers); }
            //BrowserDriver.Sleep(4000);
        }

        #endregion
    }
}
