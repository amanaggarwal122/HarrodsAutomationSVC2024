using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.AC
{
    class ACLoginPage
    {
        public IWebDriver driver;
        private Configuration config = null;       

        #region  Constructor
        public ACLoginPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email']")]
        private IWebElement ACloginEmail;        

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        private IWebElement ACloginPassword;

        [FindsBy(How = How.Id, Using = "kt_login_signin_submit")]
        private IWebElement ACloginButton;
        #endregion
        public void PerformACLogin(string userName, string password)
        {
            WebHandlers.Instance.EnterText(ACloginEmail, userName, $"Entered {userName} for login email");
            WebHandlers.Instance.EnterText(ACloginPassword, password, $"Entered password for login email");
            WebHandlers.Instance.ClickByJsExecutor(ACloginButton, "Login");
            BrowserDriver.Sleep(10000);
        }
    }
}
