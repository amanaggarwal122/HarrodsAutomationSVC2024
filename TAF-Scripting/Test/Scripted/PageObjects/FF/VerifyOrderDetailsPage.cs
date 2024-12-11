using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility.Scripted.DataWrite;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;
using TAF_Scripting;
using BoDi;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class VerifyOrderDetailsPage
    {
        public IWebDriver driver;

        #region  Constructor

        public VerifyOrderDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        

        #endregion

        #region Elements		

        [FindsBy(How = How.XPath, Using = "//h1[text()='Thank you for your order']")]
        private IWebElement OrderConfirmation;

        //[FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Your order number')]")]
        [FindsBy(How = How.XPath, Using = "//h3[contains(text(),'rder number')]/following-sibling::h3")]        
        private IWebElement OrderDetail;

        #endregion

        #region Events  

        public void VerifyOrderAndCapturePortalNumber(ScenarioContext scenarioContext, IObjectContainer  objectContainer, FeatureContext featureContext)
        {
            TAFHooks.ApplicationCache.PortalOrderNumber = "";
            if (WebHandlers.Instance.WebElementExists(OrderConfirmation))
            {
                string PortalOrderNumber = WebHandlers.Instance.GetTextOfElement(OrderDetail);
                TAFHooks.ApplicationCache.PortalOrderNumber = PortalOrderNumber;
                TAFHooks.ApplicationCache.OrderCreationDate = DateTime.Now.ToString("dd/MM/yyyy");
                TAFHooks obj = new TAFHooks(objectContainer, scenarioContext, featureContext);
                obj.AttachWebScreenshotToReport(PortalOrderNumber+"_FFWeb");
            }
            





        }

    #endregion

    #region Validation     
    #endregion
}
}
