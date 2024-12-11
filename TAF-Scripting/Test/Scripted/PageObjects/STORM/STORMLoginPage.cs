using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    #region Using
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TAF_Web.Scripted.Web;
    #endregion

    public class STORMLoginPage
    {

        public IWebDriver driver;

        #region  Constructor

        public STORMLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		

        [FindsBy(How = How.XPath, Using = "//input[@id='username']")]
        private IWebElement UserName;

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Log in')]")]
        private IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//div[@ng-show='model.errorMessage']")]
        private IWebElement ErrorMessage;

        #endregion

        #region Events  

        public void Login(string userName, string password)
        {
            WebHandlers.Instance.EnterText(UserName, userName, $"Entered {userName} for user name");
            WebHandlers.Instance.EnterText(Password, password, $"Entered ****** for password");
            WebHandlers.Instance.Click(LoginButton, "Login");
        }

        #endregion

        #region Validation   

        public void ValidateLogin()
        {
            WebHandlers.Instance.CheckForError(ErrorMessage, "Invalid username or password.");            
        }


        #endregion
    }
}