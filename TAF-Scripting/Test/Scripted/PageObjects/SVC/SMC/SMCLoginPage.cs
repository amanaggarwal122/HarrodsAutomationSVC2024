using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using TAF_Web.Scripted.Web;
using OpenQA.Selenium.Support.UI;
using System;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SMC
{
    class SMCLoginPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SMCLoginPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        [FindsBy(How = How.XPath, Using = "//input[@id='j_username']")]
        private IWebElement SMCloginEmail;

        [FindsBy(How = How.XPath, Using = "//div[text()='Continue']")]
        private IWebElement SMCContinueButton;

        [FindsBy(How = How.XPath, Using = "//input[@name='passwd']")]
        private IWebElement SMCloginPassword;

        [FindsBy(How = How.XPath, Using = "//input[@id='idSIButton9']")]
        private IWebElement SMCloginButton;

        //[FindsBy(How = How.XPath, Using = "//div[text()='Contacts and Profiles']")]
        //private IWebElement SMCNavMenuContacts;

        [FindsBy(How = How.XPath, Using = "(//*[name()='path'][@class='HPANavigationSegment'])[4]")]
        private IWebElement SMCNavMenuContacts;

        [FindsBy(How = How.XPath, Using = "//span[text()='Con­tacts']")]
        private IWebElement SMCNavContacts;

        [FindsBy(How = How.XPath, Using = "(//*[text()='Campaigns'])[2]")]
        private IWebElement SMCNavCampaigns;

        #endregion

        #region Events
        public void PerformSMCLogin(string userName, string password)
        {
            WebHandlers.Instance.EnterText(SMCloginEmail, userName, $"Entered {userName} for login email");
            WebHandlers.Instance.ClickByJsExecutor(SMCContinueButton, "Continue");
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.EnterText(SMCloginPassword, password, $"Entered password for login email");
            WebHandlers.Instance.ClickByJsExecutor(SMCloginButton, "Login");
            BrowserDriver.Sleep(5000);
            if (SMCloginButton.Displayed)
                WebHandlers.Instance.ClickByJsExecutor(SMCloginButton, "Remember Yes");
            BrowserDriver.Sleep(9000);

        }

        public void NavigateToSMCContacts()
        {
            WebWaitHelper.Instance.WaitForElementPresence(SMCNavMenuContacts);
            //WebHandlers.Instance.ClickByJsExecutor(SMCNavMenuContacts);
            WebHandlers.Instance.Click(SMCNavMenuContacts);
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.ClickByJsExecutor(SMCNavContacts);
            BrowserDriver.Sleep(5000);
        }
        //TC_276
        public void NavigateToSMCCampaigns()
        {
            //WebHandlers.Instance.ClickByJsExecutor(SMCNavCampaigns);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SMCNavCampaigns);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement campaignsElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("(//*[text()='Campaigns'])[2]")));
            //campaignsElement.Click();
            BrowserDriver.Sleep(5000);
        }

        #endregion
    }
}
