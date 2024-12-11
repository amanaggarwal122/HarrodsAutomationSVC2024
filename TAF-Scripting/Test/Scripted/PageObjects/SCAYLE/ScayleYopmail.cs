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

namespace TAF_Scripting.Test.Scripted.PageObjects.SCAYLE
{
    class ScayleYopmail
    {
        public IWebDriver driver;
        private Configuration config = null;
        public string Otp;
        #region  Constructor
        public ScayleYopmail(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        [FindsBy(How = How.XPath, Using = "//input[@id='login']")]
        private IWebElement EdtYopmailLoginEmail;

        [FindsBy(How = How.XPath, Using = "//button[text()='Accept Recommended Cookies & Continue']")]
        private IWebElement BtnYopmailAcceptCookies;

        [FindsBy(How = How.XPath, Using = "//*[text()='Ad']")]
        private IWebElement YopmailAdd;

        [FindsBy(How = How.XPath, Using = "//div[text()='Ad']")]
        private IWebElement YopmailSecondAd;

        [FindsBy(How = How.XPath, Using = "//*[text()='Close']")]
        private IWebElement YopmailAddClose;
        //[FindsBy(How = How.XPath, Using = "//p[text()='Consent']")]
        //private IWebElement BtnYopmailAcceptCookies;

        [FindsBy(How = How.XPath, Using = "//button[@title='Check Inbox @yopmail.com']/i")]
        private IWebElement BtnYopmailGoToInbox;

        [FindsBy(How = How.XPath, Using = "//*[text()='6 Digit Verification Code']//following::input[1]")]
        private IWebElement EnterCodetxtbox;

        [FindsBy(How = How.XPath, Using = "//*[@class='harrods-submit-button']")]
        private IWebElement ContinueButton;

        [FindsBy(How = How.Id, Using = "ifinbox")]
        private IWebElement FrameYopmailInbox;

        [FindsBy(How = How.XPath, Using = "//span[text()='Harrods']/../following::div[text()='Your Harrods verification code']")]
        private IWebElement YopmailInboxOTPHarrodsEmail;

        // [FindsBy(How = How.XPath, Using = "//span[text()='Harrods']")]
        [FindsBy(How = How.XPath, Using = "//span[text()='Yes, Subscribe Me']")]
        private IWebElement YopmailInboxHarrodsEmail;

        [FindsBy(How = How.XPath, Using = "//a[text()='Confirm Email']")]
        private IWebElement YopmailInboxHarrodsConfirmEmailLink;

        [FindsBy(How = How.XPath, Using = "//*[text()='Yes, Subscribe Me']")]
        private IWebElement YopmailSubscribemeConfirmEmailLink;

        [FindsBy(How = How.Id, Using = "ifmail")]
        private IWebElement FrameYopmailDescription;

       //[FindsBy(How = How.XPath, Using = "//div[text()='Your Harrods verification code is:']//following::div[3]")]
        [FindsBy(How = How.XPath, Using = "//*[@id='mail']/div/table/tbody/tr/td[2]/div/div/table/tbody/tr[3]/td/div/div/div")]
        private IWebElement YopmailInboxHarrodsOTPValue;

        [FindsBy(How = How.XPath, Using = "//span[text()='Delete']")]
        private IWebElement YopmailDeleteEmail;

        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'lmf') and text() = 'Harrods Rewards']")]
        private IWebElement HarrodsRewardsemaillink;

        [FindsBy(How = How.XPath, Using = "//*[text() = 'Harrods Rewards']")]
        private IWebElement HarrodsRewardsemaillinkNew;

        [FindsBy(How = How.XPath, Using = "//*[text()='Unsubscribe*']")]
        private IWebElement Unsubscribelink;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement BBOTPEmailRadio;

        [FindsBy(How = How.XPath, Using = "//input[@inputmode='numeric']")]
        private IWebElement BBVerifyEmailOTPInput;

        [FindsBy(How = How.XPath, Using = "//div[text()='Your 10% day was cancelled' and @class='ellipsis nw b f18']")]
        private IWebElement TenPcancelledSubject;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Consent']")]
        private IWebElement YopmailConsentPopUp;

        #endregion

        public By HeaderConfirmMsg(string Message)
        {
            return By.XPath("//h2[text()='" + Message + "']");
        }
        public By HeaderConfirmMsgs(string Message)
        {
            return By.XPath("(//p[text()=" + Message + "])[1]");
        }

        public By DivConfirmMsg(string Message) { return By.XPath("//div[contains(text(),'" + Message + "')]"); }

        public By YopmailWelcomeFirstName(string FirstName) { return By.XPath("//*[contains(text(),'" + FirstName + "')]"); }

        public By spanHarrodsText(string Message) { return By.XPath("//span[text()='" + Message + "']"); }

        public By YopHarrodsSpecificEmail(string item) { return By.XPath("(//span[text()='Harrods Rewards'])[" + item + "]"); }
        public By YopmailTenpDaySelection(string daytime) { return By.XPath("//p[text()=\"We're pleased to confirm your personal 10% day is booked for " + daytime + "\"]"); }

        public By ParaUserDetails(string Details) { return By.XPath("//p[text()='" + Details + "']"); }
        public void LoginToYopmail(string Email)
        {
            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
            if (BtnYopmailAcceptCookies.Displayed)
            {
                WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
                BrowserDriver.Sleep(3000);
            }

            //Searching for harrods email
            EdtYopmailLoginEmail.SendKeys(Email);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
            BrowserDriver.Sleep(3000);
        }
        //TC_15,TC_180
        public void PerformEmailValidationFromYopmail(string Email)
        {
            //Navigating to yopmail and accepting cookies
            driver.Navigate().GoToUrl(config.YopMailUrl);
            //driver.Navigate().GoToUrl(CommonFunctions.RewriteFarfetchUrl(config.FFLiteVerifyUrl, config));

            WebHandlers.Instance.WaitForPageLoad();

            try
            {
                if (YopmailConsentPopUp.Displayed)
                {
                    //WebHandlers.Instance.Click(YopmailConsentPopUp);
                    YopmailConsentPopUp.Click();
                }
            }
            catch (NoSuchElementException)
            {

            }
            BrowserDriver.Sleep(3000);

            // WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
            try
            {
                if (BtnYopmailAcceptCookies.Displayed)
                {
                    WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
                    BrowserDriver.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

            }
            //To Handle "Ad"  and close the Advertisment.
            try
            {
                if (YopmailAdd.Displayed)
                {
                    WebHandlers.Instance.Click(YopmailAddClose);
                    BrowserDriver.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

            }

            try
            {
                string currentTitle = driver.Title;
                if (currentTitle.Contains("Antivirus"))
                {
                    driver.Navigate().Back();
                    BrowserDriver.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

            }
            BrowserDriver.Sleep(3000);
            //To Handle "Ad"  and close the Advertisment.
            try
            {
                if (YopmailSecondAd.Displayed)
                {
                    WebHandlers.Instance.Click(YopmailAddClose);
                    BrowserDriver.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

            }


            //Searching for harrods email
            EdtYopmailLoginEmail.SendKeys(Email);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
            BrowserDriver.Sleep(3000);



            //Performing user email verification 
            try { 
            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
        }
            catch
            {
                Assert.Fail("CAPTCHA displaying while Performing Email Validation From Yopmail");
            }
            //driver.FindElement(By.XPath("//*[text()='Confirm Email']")).Click();
            try
            { 
            driver.FindElement(By.XPath("//*[@id='mail']/div/table/tbody/tr/td[2]/div/div/table/tbody/tr[3]/td/table/tbody/tr/td/a")).Click();
            }

            catch
            {
                Assert.Fail("Captcha displaying on Yopmail verification");
            }
            BrowserDriver.Sleep(3000);

            //Clicking Continue to sign In on Identity page
           
            BrowserDriver.Sleep(2000);

            //BrowserDriver.LaunchWebURL(CommonFunctions.RewriteFarfetchUrl(config.FFUrl, config));
            // driver.Navigate().GoToUrl(CommonFunctions.RewriteSCAYLEUrl(config.SCAYLEUrl, config));
            //BrowserDriver.Sleep(2000);

            //string VerifiedMessage = "The Harrods Beauty Advent Calendars are here – ";
            // "Thank you for signing up to our emails";
            //WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(HeaderConfirmMsg(VerifiedMessage)));
            //Assert.IsTrue(driver.FindElement(HeaderConfirmMsgs(VerifiedMessage)).Displayed, "Customer email verification success message is not showing on Harrods");
        }

        public string FetchEmailOTPFromYopmail(string Email)
        {
            WebHandlers.Instance.ExecuteScript("window.open()", null);
            string currentWindowHandle = driver.CurrentWindowHandle;
            List<String> tabs = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);
            BrowserDriver.LaunchWebURL(config.YopMailUrl);
            WebHandlers.Instance.WaitForPageLoad();

            try
            {
                if (YopmailConsentPopUp.Displayed)
                {
                    //WebHandlers.Instance.Click(YopmailConsentPopUp);
                    YopmailConsentPopUp.Click();
                }
            }
            catch (NoSuchElementException)
            {

            }
            BrowserDriver.Sleep(3000);

            //WebWaitHelper.Instance.WaitForElement(EdtYopmailLoginEmail);

            //Navigating to yopmail and accepting cookies
            BrowserDriver.Sleep(2000);

            try
            {
                if (BtnYopmailAcceptCookies.Displayed)
                {
                    WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
                    BrowserDriver.Sleep(5000);
                }

            }
            catch (NoSuchElementException)
            {

            }

            try {
                WebHandlers.Instance.ElementPresent(EdtYopmailLoginEmail);
            }

            catch
            {
                Assert.Fail("Captcha displaying on Yopmail while Fetching EmailOTP");
            }
            //Searching for harrods email
            EdtYopmailLoginEmail.Clear();
            EdtYopmailLoginEmail.SendKeys(Email);
            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
            //WebHandlers.Instance.WebElementExists(YopmailInboxOTPHarrodsEmail);
            //WebHandlers.Instance.Click(YopmailInboxOTPHarrodsEmail);
            //WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);

            //Fetching OTP 
            try
            {
                WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
            }

            catch
            {
                Assert.Fail("Captcha displaying on Yopmail while Fetching EmailOTP");
            }
            
            WebHandlers.Instance.WebElementExists(YopmailInboxHarrodsOTPValue);
            //string Otp = YopmailInboxHarrodsOTPValue.GetAttribute("innerText");
            try
            {
                Otp = YopmailInboxHarrodsOTPValue.Text;
            }

            catch
            {
                Assert.Fail("OTP for Email login not displaying on Yopmail");
            }
           
            WebHandlers.Instance.Click(YopmailDeleteEmail);
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);
            driver.Close();
            driver.SwitchTo().Window(tabs[0]);
            return Otp;
        }

        public void EnterCodeinScale()
        {
            WebHandlers.Instance.Click(EnterCodetxtbox);
            EnterCodetxtbox.SendKeys(Otp);
            BrowserDriver.Sleep(2000);
            driver.FindElement(By.XPath("//*[@class='harrods-submit-button']")).Click();
            //WebHandlers.Instance.Click(ContinueButton);
            BrowserDriver.Sleep(5000);
        }

        public void UnsubscribeEmailinFooter(string Email)
        {
            //driver.Navigate().GoToUrl(config.YopMailUrl);
            //Navigating to yopmail and accepting cookies
            driver.Navigate().GoToUrl(config.YopMailUrl);
            //driver.Navigate().GoToUrl(CommonFunctions.RewriteFarfetchUrl(config.FFLiteVerifyUrl, config));

            WebHandlers.Instance.WaitForPageLoad();

            try
            {
                if (YopmailConsentPopUp.Displayed)
                {
                    //WebHandlers.Instance.Click(YopmailConsentPopUp);
                    YopmailConsentPopUp.Click();
                }
            }
            catch (NoSuchElementException)
            {

            }
            BrowserDriver.Sleep(3000);

            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
            try
            {
                if (BtnYopmailAcceptCookies.Displayed)
                {
                    WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
                    BrowserDriver.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

            }
            //To Handle "Ad"  and close the Advertisment.
            try
            {
                if (YopmailAdd.Displayed)
                {
                    WebHandlers.Instance.Click(YopmailAddClose);
                    BrowserDriver.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

            }

            try
            {
                string currentTitle = driver.Title;
                if (currentTitle.Contains("Antivirus"))
                {
                    driver.Navigate().Back();
                    BrowserDriver.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

            }
            BrowserDriver.Sleep(3000);
            //To Handle "Ad"  and close the Advertisment.
            try
            {
                if (YopmailSecondAd.Displayed)
                {
                    WebHandlers.Instance.Click(YopmailAddClose);
                    BrowserDriver.Sleep(3000);
                }
            }
            catch (NoSuchElementException)
            {

            }
            //Searching for harrods email
            EdtYopmailLoginEmail.SendKeys(Email);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
            BrowserDriver.Sleep(3000);

            WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
            WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsEmail);
            WebHandlers.Instance.Click(YopmailInboxHarrodsEmail);
            WebHandlers.Instance.SwithBackFromFrame();
            BrowserDriver.Sleep(2000);

            //Performing user email verification 
            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
            WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsConfirmEmailLink);
            WebHandlers.Instance.Click(YopmailInboxHarrodsConfirmEmailLink);
            BrowserDriver.Sleep(2000);

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            //string UserValidationUrl = YopmailInboxHarrodsConfirmEmailLink.GetAttribute("href");
            //WebHandlers.Instance.Click(YopmailDeleteEmail);
            WebHandlers.Instance.SwithBackFromFrame();
            // driver.Navigate().GoToUrl(UserValidationUrl);
            BrowserDriver.Sleep(2000);
            string VerifiedMessage = "Thank you for signing up to our emails";
            //WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(HeaderConfirmMsg(VerifiedMessage)));
            //Assert.IsTrue(driver.FindElement(HeaderConfirmMsg(VerifiedMessage)).Displayed, "Customer email verification success message is not showing on Harrods");

            driver.Navigate().GoToUrl(config.YopMailUrl);

            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
            //if (BtnYopmailAcceptCookies.Displayed)
            //{
            //    WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
            //    BrowserDriver.Sleep(3000);
            //}
            Console.WriteLine("Email id created --> " + Email);
           // WebHandlers.Instance.EnterText(EdtYopmailLoginEmail, Email + "\n");

            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
            // WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsEmail);
            // WebHandlers.Instance.Click(YopmailInboxHarrodsEmail);
            //WebHandlers.Instance.SwithBackFromFrame();


            for (int i = 0; i <= 20; i++)
            {
                driver.Navigate().Refresh();
                BrowserDriver.Sleep(5000);
            }
            //WebWaitHelper.Instance.WaitForElementPresence(HarrodsRewardsemaillink);
            //Boolean displayed = false;
            //do
            //{
            //    try
            //    {
            //        displayed = HarrodsRewardsemaillink.Displayed;
            //        //HarrodsRewardsemaillink.Displayed && 
            //    }
            //    catch (NoSuchElementException)
            //    {
            //        driver.Navigate().Refresh();
            //    }
            //} while (!displayed);

            BrowserDriver.Sleep(2000);
            // WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
            //WebHandlers.Instance.SwitchToFrame(driver.FindElement(By.Id("ifinbox")));

           //driver.SwitchTo().Frame("ifinbox");
           // WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsEmail);
           // WebHandlers.Instance.Click(YopmailInboxHarrodsEmail);
           // Console.WriteLine(YopmailInboxHarrodsEmail);

           // //WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(By.XPath("//a[text() = 'Harrods Rewards']")));
           // BrowserDriver.Sleep();

           // //if (HarrodsRewardsemaillinkNew.Displayed)
           // //{
           // //    WebHandlers.Instance.Click(HarrodsRewardsemaillinkNew);
           // //}
           // //else
           // //{
           // //    Assert.Fail("Rewards Email is not Generated for the user email " + Email);
           // //}
           // WebHandlers.Instance.SwithBackFromFrame();

            //driver.SwitchTo().Frame("ifmail");
           // WebHandlers.Instance.Click(Unsubscribelink);
           // WebHandlers.Instance.SwithBackFromFrame();
        }

        public void PerformOTPValidationFromYopmail(string UserName)
        {
            if (BBOTPEmailRadio.Displayed)
            {
                WebHandlers.Instance.Click(BBOTPEmailRadio);
                WebHandlers.Instance.Click(driver.FindElement(DivConfirmMsg("Send")));
                BrowserDriver.Sleep(3000);
                WebHandlers.Instance.ElementPresent(BBVerifyEmailOTPInput);

                string OTP = FetchEmailOTPFromYopmail(UserName);
                BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.EnterText(BBVerifyEmailOTPInput, OTP);
                BBVerifyEmailOTPInput.SendKeys(OTP);
                BrowserDriver.Sleep(1000);
                WebHandlers.Instance.Click(driver.FindElement(DivConfirmMsg("Verify")));
                BrowserDriver.Sleep(5000);
                //WebHandlers.Instance.WebElementExists(driver.FindElement(MainHeaderConfirmMsg("Choose a Beauty Department")));
            }
        }

        public void PerformEmailtenpercentDiscountValidation(string Email)
        {
            driver.Navigate().GoToUrl(config.YopMailUrl);
            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);

            if (BtnYopmailAcceptCookies.Displayed)
            {
                WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
                BrowserDriver.Sleep(3000);
            }

            //Searching for harrods email
            EdtYopmailLoginEmail.SendKeys(Email);
            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
            BrowserDriver.Sleep(3000);

            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
            WebWaitHelper.Instance.WaitForElementPresence(TenPcancelledSubject);

            Assert.IsTrue(TenPcancelledSubject.Displayed, "10 percent canncelled message is not displayed");
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(YopmailDeleteEmail, "clicked on Delete Email");

            BrowserDriver.Sleep(2000);

        }

        public void PerformWelcomeEmailValidation(string Email, string UserName, string UserCategory)
        {
            BrowserDriver.Sleep(15000);

            driver.Navigate().GoToUrl(config.YopMailUrl);
            //driver.Navigate().GoToUrl(CommonFunctions.RewriteFarfetchUrl(config.FFLiteVerifyUrl, config));
            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
            if (YopmailConsentPopUp.Displayed)
            {
                //WebHandlers.Instance.Click(YopmailConsentPopUp);
                YopmailConsentPopUp.Click();
            }

            //if (BtnYopmailAcceptCookies.Displayed)
            //{
            //    //WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
            //    BrowserDriver.Sleep(3000);
            //}

            //Searching for harrods email
            EdtYopmailLoginEmail.SendKeys(Email);
            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
            BrowserDriver.Sleep(3000);

            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);

            if (UserCategory == "176_Existing_LoyaltyRewardsGroupAccountCustomer_AddMultipleChild_ValidateWelcomeEmail")
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//div[text()='Welcome to Mini Harrods']")).Displayed, "Welcome email FirstName not displayed ");
            }
            else
            {
                BrowserDriver.Sleep(5000);
                //WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(YopmailWelcomeFirstName(UserName)));

               // Assert.IsTrue(driver.FindElement(YopmailWelcomeFirstName(UserName)).Displayed, "Welcome email FirstName not displayed ");

            }
            BrowserDriver.Sleep(5000);
            // WebHandlers.Instance.Click(YopmailDeleteEmail, "clicked on Delete Email");

            // BrowserDriver.Sleep(2000);

        }

        public void Validate10pEmailContent(string UserName, string DateSelected)
        {
            WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
            int count = driver.FindElements(spanHarrodsText("Harrods Rewards")).Count;
            WebHandlers.Instance.Click(driver.FindElement(YopHarrodsSpecificEmail(count.ToString())));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.SwithBackFromFrame();

            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
            Assert.IsTrue(driver.FindElement(ParaUserDetails("First Name = " + UserName)).Displayed, "User first name not listing on email");
            Assert.IsTrue(driver.FindElement(ParaUserDetails("Last Name = " + UserName + "Lname")).Displayed, "User last name not listing on email");
            Assert.IsTrue(driver.FindElement(ParaUserDetails("Source = OL")).Displayed, "User source details not listing on email");
            WebHandlers.Instance.SwithBackFromFrame();

            WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
            WebHandlers.Instance.Click(driver.FindElement(YopHarrodsSpecificEmail((count - 1).ToString())));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.SwithBackFromFrame();
            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
            Assert.IsTrue(driver.FindElement(ParaUserDetails("Dear " + UserName)).Displayed, "User first name not listing on email");
            Assert.IsTrue(driver.FindElement(YopmailTenpDaySelection(DateSelected)).Displayed, "User 10 percentage discount details not listing on email");
            WebHandlers.Instance.SwithBackFromFrame();
        }
    }
}
