using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAF_Web.Scripted.Web;
using TAF_GenericUtility.Scripted.Email;
using HtmlAgilityPack;
using TAF_Scripting.Test.Common;
using TAF_Scripting.Test.Scripted.StepDefinitions;
using TAF_Web.Scripted.Web.BrowserOptions;
using Keys = System.Windows.Forms.Keys;
using OpenQA.Selenium.Support.UI;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCUserLoginPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SSCUserLoginPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements

        [FindsBy(How = How.Id, Using = "USERNAME_FIELD-inner")]
        private IWebElement SSCloginEmail;

        [FindsBy(How = How.Id, Using = "PASSWORD_FIELD-inner")]
        private IWebElement SSCloginPassword;

        [FindsBy(How = How.Id, Using = "LOGIN_LINK_CONTENT")]
        private IWebElement SSCloginButton;

        #endregion

        #region Events

        public void PerformSSCLogin(string userName, string password)
        {
            WebHandlers.Instance.EnterText(SSCloginEmail, userName, $"Entered {userName} for login email");
            WebHandlers.Instance.EnterText(SSCloginPassword, password, $"Entered password for login email");
            WebHandlers.Instance.ClickByJsExecutor(SSCloginButton, "Login");
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(10000);
        }

        #endregion
    }
}
