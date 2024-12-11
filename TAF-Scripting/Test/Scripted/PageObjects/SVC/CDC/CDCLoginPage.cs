using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using TAF_Web.Scripted.Web;
using OpenQA.Selenium.Support.UI;
using System.Threading.Tasks;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.CDC
{
    class CDCLoginPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public CDCLoginPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
        private IWebElement CDCloginEmail;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement CDCNextButton;

        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        private IWebElement CDCloginPassword;

        [FindsBy(How = How.XPath, Using = "//input[@id='idSIButton9']")]
        private IWebElement CDCSigninButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Profiles']")]
        private IWebElement CDCNavProfiles;

        #endregion
        public By CDCNavAdminIdentyAccessTree { get => By.XPath("//span[@title='Identity Access']"); }

        #region Events




        public void PerformCDCLogin(string userName, string password)
        {
            WebHandlers.Instance.EnterText(CDCloginEmail, userName, $"Entered {userName} for login email");
            WebHandlers.Instance.ClickByJsExecutor(CDCNextButton, "Next");
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.EnterText(CDCloginPassword, password, $"Entered password for login email");
            WebHandlers.Instance.ClickByJsExecutor(CDCSigninButton, "Login");
            BrowserDriver.Sleep(5000);
            if (CDCSigninButton.Displayed)
                WebHandlers.Instance.ClickByJsExecutor(CDCSigninButton, "Remember Yes");
            BrowserDriver.Sleep(9000);

        }

        public void NavigateToCDCProfiles()
        {
            BrowserDriver.Sleep(3000);
            if (driver.FindElements(CDCNavAdminIdentyAccessTree).Count != 0)
            {
                driver.FindElement(CDCNavAdminIdentyAccessTree).Click();
            }
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(CDCNavProfiles);
        }
        #endregion

    }
}
