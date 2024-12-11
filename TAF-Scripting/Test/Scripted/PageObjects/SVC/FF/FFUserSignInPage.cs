using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.FF
{
    class FFUserSignInPage
    {
        public IWebDriver driver;
        private Configuration config = null;        

        #region  Constructor
        public FFUserSignInPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign in']")]
        private IWebElement SignIn;

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign in']")]
        private IWebElement HarrodsSignInLink;

        [FindsBy(How = How.XPath, Using = "//a[text()='Forgotten your password?']")]
        private IWebElement HarrodsForgotPasswordLink;

        [FindsBy(How = How.XPath, Using = "//*[text()='Email Address']/following::input")]
        private IWebElement HarrodsUserEmailInput;

        [FindsBy(How = How.XPath, Using = "//button[@id='forgot-password-button']")]
        private IWebElement HarrodsSendVerificationbtn;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-alert']")]
        private IWebElement Error;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-alert']/div")]
        private IWebElement ErrorMessage;

        [FindsBy(How = How.Id, Using = "loginForm-email")]
        private IWebElement loginEmail;

        [FindsBy(How = How.Id, Using = "loginForm-password")]
        private IWebElement loginPassword;
                
        [FindsBy(How = How.XPath, Using = "//*[@id='loginForm-submitButton'][text()='Sign in']")]
        private IWebElement Login1;


        //[FindsBy(How = How.XPath, Using = "//Button[text()='Accept & Continue']")]
        [FindsBy(How = How.XPath, Using = "//button/span[text()='Agree and close']")]
        private IWebElement Accept;
        
        [FindsBy(How = How.XPath, Using = "//input[@id='newsletterForm-email']")]
        private IWebElement EdtSignUpToEmail;

        [FindsBy(How = How.XPath, Using = "//button[text()='Sign Up']")]
        private IWebElement BtnSignUp;

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign up to emails']")]
        private IWebElement BtnSignUpToEmail;

        

        [FindsBy(How = How.XPath, Using = "//button[@data-test='loginForm-submitButton']")]
        private IWebElement Login2;

        #endregion

        public By ParaUserDetails(string Details)
        {
            return By.XPath("//p[text()='" + Details + "']");
        }
        public By BoldUserDetails(string Details)
        {
            return By.XPath("//b[text()='" + Details + "']");
        }
        public By HeaderConfirmMsg(string Message) { return By.XPath("//h2[text()='" + Message + "']"); }
        #region Events

        public void InvokeSignInProcess(string userName, string password)
        {
            //BrowserDriver.Sleep(5000);
            WebHandlers.Instance.ClickByJsExecutor(SignIn);
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.EnterText(loginEmail, userName, $"Entered {userName} for login email");
            WebHandlers.Instance.EnterText(loginPassword, password, $"Entered ******** for password");
            WebHandlers.Instance.ClickByJsExecutor(Login2, "Login");
            BrowserDriver.Sleep(2000);
        }

        public void PerformSignupActionFromHarrods(string Email)
        {
            WebHandlers.Instance.EnterText(EdtSignUpToEmail, Email);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(BtnSignUp);
        }

        public void ClickOnAcceptAndContinue()
        {
            try
            {
                if (WebHandlers.Instance.WebElementExists(Accept))
                    WebHandlers.Instance.ClickByJsExecutor(Accept, "Accept");
            }
            catch (NoSuchElementException) { }
        }

        public void PerformClickOnSignupToEmail()
        {
            WebHandlers.Instance.Click(BtnSignUpToEmail);
        }

        public void ValidateSignUpConfirmMessage(string Message)
        {
            BrowserDriver.Sleep(5000);
           // WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(HeaderConfirmMsg(Message)));
            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg(Message)).Displayed, "Sign up action confirmation message is not showing on Harrods");
        }

        public void PerformForgotPasswordFromHarrods(string UserEmail)
        {
            WebHandlers.Instance.ClickByJsExecutor(HarrodsSignInLink);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(HarrodsForgotPasswordLink);
            BrowserDriver.Sleep(5000);
            //WebHandlers.Instance.EnterText(HarrodsUserEmailInput, UserEmail);
            HarrodsUserEmailInput.SendKeys(UserEmail);
            WebHandlers.Instance.Click(HarrodsSendVerificationbtn);
            BrowserDriver.Sleep(3000);
        }

        public void ValidateForgotPasswordFromHarrods(string UserEmail)
        {
            Assert.IsTrue(driver.FindElement(ParaUserDetails("We have sent an email to:")).Displayed, "Password reset confirmation email not showing");
            Assert.IsTrue(driver.FindElement(BoldUserDetails(UserEmail)).Displayed, "Verification email not send to Users emailid");
        }

        public void SignInAfterConfirmation(string userName, string password)
        {
            //log.Info("Sign In after confirmation.");
            BrowserDriver.Sleep(10000);
            WebHandlers.Instance.EnterText(loginEmail, userName, $"Entered {userName} for login email");
            WebHandlers.Instance.EnterText(loginPassword, password, $"Entered ******** for password");
            WebHandlers.Instance.ClickByJsExecutor(Login1, "Login");
            BrowserDriver.Sleep(10000);

        }

        public void ValidateSigninFailure()
        {
            if (WebHandlers.Instance.WebElementExists(Error))
            {

                List<string> errors = WebHandlers.Instance.GetTextFromMultipleElements(ErrorMessage);

                if (errors.Any())
                {
                    string msg = errors.Aggregate((i, j) => i + ";" + j);
                    Assert.Fail($"Exception occured while login. Error details: " + msg);
                }

            }
        }
        #endregion
    }


}
