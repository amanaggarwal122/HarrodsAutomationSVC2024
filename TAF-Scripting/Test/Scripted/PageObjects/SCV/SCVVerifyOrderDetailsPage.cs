using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;

namespace TAF_Scripting.Test.Scripted.PageObjects.SCV
{
    public class SCVVerifyOrderDetailssPage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver driver;

        #region  Constructor

        public SCVVerifyOrderDetailssPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }



        #endregion

        #region Elements		

        [FindsBy(How = How.XPath, Using = "//*[@id='order-confirmation-container']/div[2]/span[text()='Thank you for placing the order.']")]
        private IWebElement OrderConfirmation;

        [FindsBy(How = How.XPath, Using = "//*[@id='order-confirmation-container']/div[2]/div/div/p[contains(text(),'Order reference:')]")]
        private IWebElement OrderDetail;

        #endregion

        #region Events  

        public void VerifyOrderAndCapturePortalNumber(ScenarioContext scenarioContext, IObjectContainer objectContainer, FeatureContext featureContext)
        {

            // scenarioContext["PortalOrderNumber"] = "";

            TAFHooks.ApplicationCache.PortalOrderNumber = "";

            if (WebHandlers.Instance.WebElementExists(OrderConfirmation))
            {
                string message = WebHandlers.Instance.GetTextOfElement(OrderDetail);
                string PortalOrderNumber = message.Split(new string[] { "Order reference: " }, StringSplitOptions.None)[1];
                // scenarioContext["PortalOrderNumber"] = PortalOrderNumber.Trim();
                TAFHooks.ApplicationCache.PortalOrderNumber = PortalOrderNumber.Trim();
                log.Info($"Order placed successfully, Portal order NUmber: {PortalOrderNumber.Trim()}");
                TAFHooks obj = new TAFHooks(objectContainer, scenarioContext, featureContext);
                obj.AttachWebScreenshotToReport(PortalOrderNumber + "_FFSCV");
            }
        }
        #endregion

       
    }
}
