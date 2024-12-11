//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using SeleniumExtras.PageObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using TAF_Web.Scripted.Web;
//using TAF_GenericUtility.Scripted.Email;
//using HtmlAgilityPack;
//using TAF_Scripting.Test.Common;
//using TAF_Scripting.Test.Scripted.StepDefinitions;
//using TAF_Web.Scripted.Web.BrowserOptions;
//using Keys = System.Windows.Forms.Keys;
//using OpenQA.Selenium.Support.UI;

//namespace TAF_Scripting.Test.Scripted.PageObjects.SVC
//{
//    class HarrodsHomePage
//    {
//        public IWebDriver driver;
//        private Configuration config = null;

//        #region  Constructor
//        public HarrodsHomePage(IWebDriver driver, Configuration configuration)
//        {
//            this.driver = driver;
//            PageFactory.InitElements(this.driver, this);
//            config = configuration;
//        }

//        #endregion

//        #region Elements

//        [FindsBy(How = How.XPath, Using = "//a[text()='Sign up to emails']")]
//        private IWebElement BtnSignUpToEmail;

//        [FindsBy(How = How.XPath, Using = "//input[@id='newsletterForm-email']")]
//        private IWebElement EdtSignUpToEmail;

//        [FindsBy(How = How.XPath, Using = "//button[text()='Sign Up']")]
//        private IWebElement BtnSignUp;
//        public By ParaContainsData(string Data) { return By.XPath("(//p[contains(text(),'" + Data + "')])[1]"); }
//        public By ParaUserDetails(string Details) { return By.XPath("//p[text()='" + Details + "']"); }
//        public By BoldUserDetails(string Details) { return By.XPath("//b[text()='" + Details + "']"); }
//        public By DivConfirmMsg(string Message) { return By.XPath("//div[text()='" + Message + "']"); }
//        public By HeaderConfirmMsg(string Message) { return By.XPath("//h2[text()='" + Message + "']"); }
//        public By MainHeaderConfirmMsg(string Message) { return By.XPath("//h1[text()='" + Message + "']"); }

//        [FindsBy(How = How.XPath, Using = "//input[@id='login']")]
//        private IWebElement EdtYopmailLoginEmail;

//        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Consent']")]
//        private IWebElement YopmailConsentPopUp;

//        [FindsBy(How = How.XPath, Using = "//button[@title='Check Inbox @yopmail.com']/i")]
//        private IWebElement BtnYopmailGoToInbox;

//        [FindsBy(How = How.XPath, Using = "//button[text()='Accept Recommended Cookies & Continue']")]
//        private IWebElement BtnYopmailAcceptCookies;

//        [FindsBy(How = How.XPath, Using = "//*[@title='Check Inbox @yopmail.com']")]
//        private IWebElement BtnCheckInbox;

//        [FindsBy(How = How.Id, Using = "ifinbox")]
//        private IWebElement FrameYopmailInbox;

//        [FindsBy(How = How.Id, Using = "ifmail")]
//        private IWebElement FrameYopmailDescription;

//        //[FindsBy(How = How.XPath, Using = "(//span[text()='Harrods'])[1]")]
//        [FindsBy(How = How.XPath, Using = "//span[text()='Harrods']")]
//        private IWebElement YopmailInboxHarrodsEmail;

//        [FindsBy(How = How.XPath, Using = "//a[text()='Confirm Email']")]
//        private IWebElement YopmailInboxHarrodsConfirmEmailLink;

//        [FindsBy(How = How.XPath, Using = "//span[text()='Harrods']/../following::div[text()='Your Harrods verification code']")]
//        private IWebElement YopmailInboxOTPHarrodsEmail;

//        [FindsBy(How = How.XPath, Using = "//p[text()='Your Harrods verification code is:']/following::p[contains(@style,'bold')]")]
//        private IWebElement YopmailInboxHarrodsOTPValue;

//        public By YopHarrodsSpecificEmail(string item) { return By.XPath("(//span[text()='Harrods Rewards'])[" + item + "]"); }
//        public By YopmailTenpDaySelection(string daytime) { return By.XPath("//p[text()=\"We're pleased to confirm your personal 10% day is booked for " + daytime + "\"]"); }

//        [FindsBy(How = How.XPath, Using = "//div[text()='Your 10% day was cancelled' and @class='ellipsis nw b f18']")]
//        private IWebElement TenPcancelledSubject;

//        [FindsBy(How = How.XPath, Using = "//span[text()='Delete']")]
//        private IWebElement YopmailDeleteEmail;

//        [FindsBy(How = How.XPath, Using = "//span[contains(@class, 'lmf') and text() = 'Harrods Rewards']")]
//        private IWebElement HarrodsRewardsemaillink;

//        [FindsBy(How = How.XPath, Using = "//*[text()='Unsubscribe*']")]
//        private IWebElement Unsubscribelink;

//        [FindsBy(How = How.XPath, Using = "//span[text()='Account Home']")]
//        private IWebElement HarrodsAccountHomeLink;

//        [FindsBy(How = How.XPath, Using = "//span[text()='Rewards Statements']")]
//        private IWebElement HarrodsRewardsStatementsLink;

//        [FindsBy(How = How.XPath, Using = "//button[text()='Join Rewards']")]
//        private IWebElement HarrodsJoinRewardsbtn;

//        [FindsBy(How = How.XPath, Using = "//input[@id='joinRewards-cardNumber']")]
//        private IWebElement HarrodsJoinRewardsCardNumberInput;

//        [FindsBy(How = How.XPath, Using = "//button[text()='Link accounts']")]
//        private IWebElement HarrodsJoinRewardsLinkAccountbtn;

//        [FindsBy(How = How.XPath, Using = "//a[text()='Sign in']")]
//        private IWebElement HarrodsSignInLink;

//        [FindsBy(How = How.XPath, Using = "//*[text()='Email Address']/following::input")]
//        private IWebElement HarrodsUserEmailInput;

//        [FindsBy(How = How.XPath, Using = "//button[@id='forgot-password-button']")]
//        private IWebElement HarrodsSendVerificationbtn;

//        [FindsBy(How = How.XPath, Using = "//a[text()='Forgotten your password?']")]
//        private IWebElement HarrodsForgotPasswordLink;
//        public By LinkHarrodsText(string Message) { return By.XPath("//a[text()='" + Message + "']"); }
//        public By spanHarrodsText(string Message) { return By.XPath("//span[text()='" + Message + "']"); }
//        public By CheckboxRemoveChild(string ChildName) { return By.XPath("(//p[text()='" + ChildName + "']/following::input)[1]"); }

//        [FindsBy(How = How.XPath, Using = " //button[@id='submit-button']")]
//        private IWebElement btnSubmitChild;

//        [FindsBy(How = How.XPath, Using = " //button[@id='leave-miniHarrods-button']")]
//        private IWebElement btnLeaveMiniHarrods;

//        public By ChildDobDetails(string Day, string Month, string Year) { return By.XPath("//p[text()='" + Day + "']/following::p[text()='" + Month + "']/following::p[text()='" + Year + "']"); }

//        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
//        private IWebElement AddChildFirstNameInput;

//        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
//        private IWebElement AddChildLastNameInput;

//        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.day']")]
//        private IWebElement AddChildDOBDaySelect;

//        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.month']")]
//        private IWebElement AddChildDOBMonthSelect;

//        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.year']")]
//        private IWebElement AddChildDOBYearSelect;

//        [FindsBy(How = How.XPath, Using = "//select[@id='newChildForm-relationship']")]
//        private IWebElement AddChildRelationshipSelect;

//        [FindsBy(How = How.XPath, Using = "//select[@id='newChildForm-gender']")]
//        private IWebElement AddChildGenderSelect;

//        [FindsBy(How = How.Id, Using = "leave-miniHarrods-button")]
//        private IWebElement LeaveMiniHarrodsSubscriptionbtn;

//        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
//        private IWebElement BeautyBookingLoginEmail;

//        [FindsBy(How = How.XPath, Using = "//input[@type='password']")]
//        private IWebElement BeautyBookingLoginPassword;

//        [FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[1]")]
//        private IWebElement BeautyBookingSignInbtn;

//        [FindsBy(How = How.Id, Using = "email")]
//        private IWebElement BBOTPEmailRadio;

//        [FindsBy(How = How.XPath, Using = "//input[@inputmode='numeric']")]
//        private IWebElement BBVerifyEmailOTPInput;

//        [FindsBy(How = How.XPath, Using = "//div[@data-test='rewardsTier']/div[1]//p")]
//        public IWebElement UserTier;
//        public By BBUserPersonalName(string item) { return By.XPath("(//input[@type='last-name'])[" + item + "]"); }

//        [FindsBy(How = How.XPath, Using = "//input[@type='tel']")]
//        public IWebElement BBUserPersonalPhone;

//        [FindsBy(How = How.XPath, Using = "//button[text()='View Availability']")]
//        public IWebElement BBBookingViewAvailability;

//        [FindsBy(How = How.XPath, Using = "//select[@class='form-control']")]
//        public IWebElement BBBookingViewAvailTime;

//        [FindsBy(How = How.XPath, Using = "(//button[text()=' Select '])[1]")]
//        public IWebElement BBBookingServiceSelect;

//        [FindsBy(How = How.XPath, Using = "//a[text()=' Checkout ']")]
//        public IWebElement BBBookingCheckout;

//        public By BBBookingAvailableDay(string DateTime) { return By.XPath("(//span[contains(@aria-label,'" + DateTime + "')][@aria-disabled='false'])[1]"); }

//        [FindsBy(How = How.XPath, Using = "//p[text()='Title']/following-sibling::select[@class='form-control']")]
//        public IWebElement BBUserRegTitle;

//        [FindsBy(How = How.XPath, Using = "//input[@type='first-name']")]
//        public IWebElement BBUserRegFirstName;

//        [FindsBy(How = How.XPath, Using = "//input[@type='last-name']")]
//        public IWebElement BBUserRegLastName;

//        [FindsBy(How = How.XPath, Using = "//p[text()='Contact Phone Number']/following-sibling::div//select[@class='form-control']")]
//        public IWebElement BBUserRegCountryCode;

//        [FindsBy(How = How.XPath, Using = "//input[@type='tel']")]
//        public IWebElement BBUserRegPhone;

//        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
//        public IWebElement BBUserRegEmail;

//        [FindsBy(How = How.XPath, Using = "(//input[@type='password'])[1]")]
//        public IWebElement BBUserRegPassword;

//        [FindsBy(How = How.XPath, Using = "(//input[@type='password'])[2]")]
//        public IWebElement BBUserRegVerifyPassword;

//        [FindsBy(How = How.XPath, Using = "//input[@name='checkbox-1']")]
//        public IWebElement BBUserRegEmailConsent;

//        public By BBBookingServiceName(string ServiceName) { return By.XPath("(//span[text()='" + ServiceName + "'])[1]"); }

//        [FindsBy(How = How.XPath, Using = "//button[text()=' Continue to Payment ']")]
//        public IWebElement BBBookingPayment;

//        [FindsBy(How = How.Id, Using = "UserName")]
//        private IWebElement IDSLoginEmail;

//        [FindsBy(How = How.Id, Using = "Password")]
//        private IWebElement IDSLoginPassword;

//        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
//        private IWebElement IDSSignInbtn;

//        [FindsBy(How = How.Id, Using = "RewardsCard")]
//        private IWebElement IDSCustomerRewardsCard;

//        [FindsBy(How = How.XPath, Using = "//span[text()='Search']")]
//        private IWebElement IDSCustomerRewardsCardSearch;

//        [FindsBy(How = How.Id, Using = "Project_Client_Name")]
//        private IWebElement IDSProjectClientName;

//        [FindsBy(How = How.Id, Using = "Project_Client_RewardsCard")]
//        private IWebElement IDSProjectClientRewardsCard;

//        [FindsBy(How = How.Id, Using = "Project_Client_SapCustomerId")]
//        private IWebElement IDSProjectClientSapCustomerId;

//        [FindsBy(How = How.Id, Using = "Project_Client_Telephone")]
//        private IWebElement IDSProjectClientTelephone;

//        [FindsBy(How = How.XPath, Using = "(//span[text()='Cancel'])[2]")]
//        private IWebElement IDSProjectCancel;

//        public By YopmailWelcomeFirstName(string FirstName) { return By.XPath("//*[contains(text(),'" + FirstName + "')]"); }

//        [FindsBy(How = How.XPath, Using = "(//div[@class='DayPicker-Day'][@aria-disabled='false']/span)[1]")]
//        public IWebElement TenpBookingAvailableDay;

//        [FindsBy(How = How.Id, Using = "schedule-selectDate")]
//        public IWebElement TenpBookingSelectbtn;

//        [FindsBy(How = How.Id, Using = "discount-days-cancel-button")]
//        public IWebElement TenpBookingCancelbtn;

//        [FindsBy(How = How.XPath, Using = "//*[text()='Day 1']")]
//        public IWebElement TenPctDay1Link;
//        [FindsBy(How = How.XPath, Using = "//*[text()='Day 2']")]
//        public IWebElement TenPctDay2Link;
//        [FindsBy(How = How.XPath, Using = "(//*[text()='Select'])[1]")]
//        public IWebElement TenPctDay1_SelectLink;
//        [FindsBy(How = How.XPath, Using = "(//*[text()='Select'])[2]")]
//        public IWebElement TenPctDay2_SelectLink;
//        #endregion

//        #region Events

//        public void PerformClickOnSignupToEmail()
//        {
//            WebHandlers.Instance.Click(BtnSignUpToEmail);
//        }

//        public void PerformSignupActionFromHarrods(string Email)
//        {
//            WebHandlers.Instance.EnterText(EdtSignUpToEmail, Email);
//            WebHandlers.Instance.Click(BtnSignUp);
//        }

//        public void ValidateSignUpConfirmMessage(string Message)
//        {
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(HeaderConfirmMsg(Message)));
//            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg(Message)).Displayed, "Sign up action confirmation message is not showing on Harrods");
//        }

//        public void PerformEmailValidationFromYopmail(string Email)
//        {
//            //Navigating to yopmail and accepting cookies
//            driver.Navigate().GoToUrl(config.YopMailUrl);
//            //driver.Navigate().GoToUrl(CommonFunctions.RewriteFarfetchUrl(config.FFLiteVerifyUrl, config));
//            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
//            if (BtnYopmailAcceptCookies.Displayed)
//            {
//                WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
//                BrowserDriver.Sleep(3000);
//            }

//            //Searching for harrods email
//            EdtYopmailLoginEmail.SendKeys(Email);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
//            WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsEmail);
//            WebHandlers.Instance.Click(YopmailInboxHarrodsEmail);
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);

//            //Performing user email verification 
//            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
//            WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsConfirmEmailLink);
//            string UserValidationUrl = YopmailInboxHarrodsConfirmEmailLink.GetAttribute("href");
//            WebHandlers.Instance.Click(YopmailInboxHarrodsConfirmEmailLink);
//            BrowserDriver.Sleep(3000);
//            // WebHandlers.Instance.Click(YopmailDeleteEmail);
//            //WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);

//            //BrowserDriver.LaunchWebURL(CommonFunctions.RewriteFarfetchUrl(config.FFUrl, config));
//            driver.Navigate().GoToUrl(CommonFunctions.RewriteFarfetchUrl(config.FFLiteVerifyUrl, config));
//            BrowserDriver.Sleep(2000);

//            string VerifiedMessage = "Thank you for signing up to our emails";
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(HeaderConfirmMsg(VerifiedMessage)));
//            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg(VerifiedMessage)).Displayed, "Customer email verification success message is not showing on Harrods");
//        }

//        public string FetchEmailOTPFromYopmail(string Email)
//        {
//            WebHandlers.Instance.ExecuteScript("window.open()", null);
//            string currentWindowHandle = driver.CurrentWindowHandle;
//            List<String> tabs = new List<String>(driver.WindowHandles);
//            driver.SwitchTo().Window(tabs[1]);
//            BrowserDriver.LaunchWebURL(config.YopMailUrl);
//            WebHandlers.Instance.WaitForPageLoad();

//            try
//            {
//                if (YopmailConsentPopUp.Displayed)
//                {
//                    //WebHandlers.Instance.Click(YopmailConsentPopUp);
//                    YopmailConsentPopUp.Click();
//                }
//            }
//            catch(NoSuchElementException)
//            {

//            }
//            BrowserDriver.Sleep(3000);
            
//            //WebWaitHelper.Instance.WaitForElement(EdtYopmailLoginEmail);

//            //Navigating to yopmail and accepting cookies
//            BrowserDriver.Sleep(2000);

//            try
//            {
//                if (BtnYopmailAcceptCookies.Displayed)
//                {
//                    WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
//                    BrowserDriver.Sleep(5000);
//                }

//            }
//            catch (NoSuchElementException)
//            {

//            }
            

//            //Searching for harrods email
//            EdtYopmailLoginEmail.SendKeys(Email);
//            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
//            WebHandlers.Instance.WebElementExists(YopmailInboxOTPHarrodsEmail);
//            WebHandlers.Instance.Click(YopmailInboxOTPHarrodsEmail);
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);

//            //Fetching OTP 
//            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
//            WebHandlers.Instance.WebElementExists(YopmailInboxHarrodsOTPValue);
//            string Otp = YopmailInboxHarrodsOTPValue.GetAttribute("innerHTML");
//            WebHandlers.Instance.Click(YopmailDeleteEmail);
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            driver.Close();
//            driver.SwitchTo().Window(tabs[0]);
//            return Otp;
//        }

//        public void UnsubscribeEmailinFooter(string Email)
//        {
//            driver.Navigate().GoToUrl(config.YopMailUrl);
//            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
//            if (BtnYopmailAcceptCookies.Displayed)
//            {
//                WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
//                BrowserDriver.Sleep(3000);
//            }
//            Console.WriteLine("Email id created --> " + Email);
//            //Searching for harrods email
//            WebHandlers.Instance.EnterText(EdtYopmailLoginEmail, Email + "\n");
//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.Click(BtnCheckInbox);
//            //BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
//            WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsEmail);
//            WebHandlers.Instance.Click(YopmailInboxHarrodsEmail);
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);

//            //Performing user email verification 
//            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
//            WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsConfirmEmailLink);
//            WebHandlers.Instance.Click(YopmailInboxHarrodsConfirmEmailLink);
//            BrowserDriver.Sleep(2000);

//            driver.SwitchTo().Window(driver.WindowHandles[1]);
//            //string UserValidationUrl = YopmailInboxHarrodsConfirmEmailLink.GetAttribute("href");
//            //WebHandlers.Instance.Click(YopmailDeleteEmail);
//            WebHandlers.Instance.SwithBackFromFrame();
//            // driver.Navigate().GoToUrl(UserValidationUrl);
//            BrowserDriver.Sleep(2000);
//            string VerifiedMessage = "Thank you for signing up to our emails";
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(HeaderConfirmMsg(VerifiedMessage)));
//            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg(VerifiedMessage)).Displayed, "Customer email verification success message is not showing on Harrods");

//            driver.Navigate().GoToUrl(config.YopMailUrl);

//            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
//            //if (BtnYopmailAcceptCookies.Displayed)
//            //{
//            //    WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
//            //    BrowserDriver.Sleep(3000);
//            //}
//            Console.WriteLine("Email id created --> " + Email);
//            WebHandlers.Instance.EnterText(EdtYopmailLoginEmail, Email + "\n");

//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
//            // WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsEmail);
//            // WebHandlers.Instance.Click(YopmailInboxHarrodsEmail);
//            //WebHandlers.Instance.SwithBackFromFrame();


//            for (int i = 0; i <= 20; i++)
//            {
//                driver.Navigate().Refresh();
//                BrowserDriver.Sleep(5000);
//            }
//            //WebWaitHelper.Instance.WaitForElementPresence(HarrodsRewardsemaillink);
//            //Boolean displayed = false;
//            //do
//            //{
//            //    try
//            //    {
//            //        displayed = HarrodsRewardsemaillink.Displayed;
//            //        //HarrodsRewardsemaillink.Displayed && 
//            //    }
//            //    catch (NoSuchElementException)
//            //    {
//            //        driver.Navigate().Refresh();
//            //    }
//            //} while (!displayed);

//            BrowserDriver.Sleep(2000);
//            // WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
//            WebHandlers.Instance.SwitchToFrame(driver.FindElement(By.Id("ifinbox")));

//            // driver.SwitchTo().Frame("ifinbox");
//            WebWaitHelper.Instance.WaitForElementPresence(YopmailInboxHarrodsEmail);
//            WebHandlers.Instance.Click(YopmailInboxHarrodsEmail);
//            Console.WriteLine(YopmailInboxHarrodsEmail);
//            if (HarrodsRewardsemaillink.Displayed)
//            {
//                WebHandlers.Instance.Click(HarrodsRewardsemaillink);
//            }
//            else
//            {
//                Assert.Fail("Rewards Email is not Generated for the user email " + Email);
//            }
//            WebHandlers.Instance.SwithBackFromFrame();

//            driver.SwitchTo().Frame("ifmail");
//            WebHandlers.Instance.Click(Unsubscribelink);
//            WebHandlers.Instance.SwithBackFromFrame();
//        }

//        public void PerformJoinRewardsWithoutCardData()
//        {
//            string confirmMessage = "You have successfully joined. Welcome to Harrods Rewards!";
//            WebHandlers.Instance.Click(HarrodsRewardsStatementsLink);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(HarrodsJoinRewardsbtn);
//            BrowserDriver.Sleep(4000);
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(DivConfirmMsg(confirmMessage)));
//        }

//        public void PerformJoinRewardsWithCardData(string CardNumber)
//        {
//            string confirmMessage = "You have successfully joined. Welcome to Harrods Rewards!";
//            WebHandlers.Instance.Click(HarrodsAccountHomeLink);
//            //WebWaitHelper.Instance.WaitForElementPresence(HarrodsJoinRewardsLinkAccountbtn);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(HarrodsJoinRewardsCardNumberInput, CardNumber);
//            WebHandlers.Instance.Click(HarrodsJoinRewardsLinkAccountbtn);
//            BrowserDriver.Sleep(4000);
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(DivConfirmMsg(confirmMessage)));
//        }

//        public void ValidateJoinRewardsWithoutCardData(string UserName)
//        {
//            AccountPage accountPage = new AccountPage(driver);
//            HomePage homePage = new HomePage(driver);
//            string confirmMessage = "You have successfully joined. Welcome to Harrods Rewards!";
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(DivConfirmMsg(confirmMessage)));
//            Assert.IsTrue(driver.FindElement(DivConfirmMsg(confirmMessage)).Displayed, "User is not able to perform join rewards");

//            accountPage.logOut();
//            //homePage.InvokeSignInProcess(UserName, config.FFCustomerPassword);
//            //homePage.ValidateSiginFailure();
//            //Assert.IsTrue(driver.FindElement(ParaUserDetails("Green Tier")).Displayed, "Rewards tier details not get generated after performing join rewards");
//        }
//        public void ValidateJoinRewardsWithCardData(string UserName, string CardNumber)
//        {
//            AccountPage accountPage = new AccountPage(driver);
//            HomePage homePage = new HomePage(driver);
//            string confirmMessage = "You have successfully joined. Welcome to Harrods Rewards!";
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(DivConfirmMsg(confirmMessage)));
//            Assert.IsTrue(driver.FindElement(DivConfirmMsg(confirmMessage)).Displayed, "User is not able to perform join rewards");

//            accountPage.logOut();
//            homePage.InvokeSignInProcess(UserName, config.FFCustomerPassword);
//            homePage.ValidateSiginFailure();
//            Assert.IsTrue(driver.FindElement(ParaUserDetails("Gold Tier")).Displayed, "Rewards tier details not get generated after performing join rewards");
//            Assert.AreEqual(CardNumber, UserTier.Text, "CardNumber is not displayed correcly");
//        }
//        public void PerformForgotPasswordFromHarrods(string UserEmail)
//        {
//            WebHandlers.Instance.ClickByJsExecutor(HarrodsSignInLink);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(HarrodsForgotPasswordLink);
//            BrowserDriver.Sleep(5000);
//            //WebHandlers.Instance.EnterText(HarrodsUserEmailInput, UserEmail);
//            HarrodsUserEmailInput.SendKeys(UserEmail);
//            WebHandlers.Instance.Click(HarrodsSendVerificationbtn);
//            BrowserDriver.Sleep(3000);
//        }

//        public void ValidateForgotPasswordFromHarrods(string UserEmail)
//        {
//            Assert.IsTrue(driver.FindElement(ParaUserDetails("We have sent an email to:")).Displayed, "Password reset confirmation email not showing");
//            Assert.IsTrue(driver.FindElement(BoldUserDetails(UserEmail)).Displayed, "Verification email not send to Users emailid");
//        }

//        public void ValidateMiniHarrodsBenefitsMembershipCommPreferance()
//        {
//            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg("Stay in Touch")).Displayed, "Stay in Touch - header not showing on Mini Harrods page");
//            Assert.IsTrue(driver.FindElement(LinkHarrodsText("View Communication Preferences ")).Displayed, "View Communication Preferences - link not showing on Mini Harrods page");

//            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg("Mini Harrods Benefits")).Displayed, "Mini Harrods Benefits - header not showing on Mini Harrods page");
//            Assert.IsTrue(driver.FindElement(spanHarrodsText("The Latest News")).Displayed, "The Latest News - benefits message not showing on Mini Harrods page");
//            Assert.IsTrue(driver.FindElement(spanHarrodsText("Birthday 10% Off")).Displayed, "Birthday 10% Off - benefits message not showing on Mini Harrods page");
//            Assert.IsTrue(driver.FindElement(spanHarrodsText("The Harrods Academy")).Displayed, "The Harrods Academy - benefits message not showing on Mini Harrods page");
//            Assert.IsTrue(driver.FindElement(spanHarrodsText("Special Events")).Displayed, "Special Events - benefits message not showing on Mini Harrods page");

//            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg("Mini Harrods Membership")).Displayed, "Mini Harrods Membership - header not showing on Mini Harrods page");
//        }

//        public void RemoveGivenChildFromMiniHarrods(string ChildFullName)
//        {
//            BrowserDriver.Sleep(3000);
//            driver.FindElement(CheckboxRemoveChild(ChildFullName)).Click();
//            btnSubmitChild.Click();
//            BrowserDriver.Sleep(5000);
//        }

//        public void ValidateRemovedChildNotListingOnHarrods(Dictionary<string, string> childData)
//        {
//            Assert.AreEqual(0, driver.FindElements(ParaUserDetails(childData["Name"])).Count, "Child name is showing under mini harrods even after performing remove child");
//            int dobCount = driver.FindElements(ChildDobDetails(childData["DOBDay"], childData["DOBMonth"], childData["DOBYear"])).Count;
//            Assert.AreEqual(0, dobCount, "Child date of birth is showing under mini harrods even after performing remove child");
//        }

//        public void AddAnotherChildfromHarrods(Dictionary<string, string> ChildData)
//        {
//            string[] child_DOB = ChildData["DOB"].Split('.');
//            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Add another child")));
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.WebElementExists(AddChildFirstNameInput);
//            WebHandlers.Instance.EnterText(AddChildFirstNameInput, ChildData["ChildFirstName"]);
//            WebHandlers.Instance.EnterText(AddChildLastNameInput, ChildData["ChildLastName"]);

//            WebHandlers.Instance.MultiSelectByText(AddChildDOBDaySelect, child_DOB[0]);
//            WebHandlers.Instance.MultiSelectByText(AddChildDOBMonthSelect, child_DOB[1]);
//            WebHandlers.Instance.MultiSelectByText(AddChildDOBYearSelect, child_DOB[2]);


//            WebHandlers.Instance.MultiSelectByText(AddChildRelationshipSelect, ChildData["childRelationship"]);
//            WebHandlers.Instance.MultiSelectByText(AddChildGenderSelect, ChildData["childGender"]);
//            btnSubmitChild.Click();
//            //btnLeaveMiniHarrods.Click();
//            BrowserDriver.Sleep(3000);
//        }

//        public void PerformCancelMiniHarrodsSubscription()
//        {
//            WebHandlers.Instance.WebElementExists(driver.FindElement(LinkHarrodsText("Leave Mini Harrods")));
//            WebHandlers.Instance.Click(driver.FindElement(LinkHarrodsText("Leave Mini Harrods")));
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.WebElementExists(LeaveMiniHarrodsSubscriptionbtn);
//            WebHandlers.Instance.Click(LeaveMiniHarrodsSubscriptionbtn);
//            BrowserDriver.Sleep(5000);
//        }

//        public void ValidateCancelMiniHarrodsSubscriptionStatus()
//        {
//            string confirmMessage = "Your Mini Harrods membership has now been cancelled.";
//            WebHandlers.Instance.WebElementExists(driver.FindElement(DivConfirmMsg(confirmMessage)));
//            Assert.IsTrue(driver.FindElement(DivConfirmMsg(confirmMessage)).Displayed, "User is not able to cancel mini harrods subscription");
//        }

//        public void BeautyBookingLoginPageGetsDisplayed()
//        {
//            WebHandlers.Instance.WebElementExists(BeautyBookingLoginPassword);
//            WebHandlers.Instance.WaitForPageLoad();
//            Assert.IsTrue(BeautyBookingLoginPassword.Displayed, "Beauty booking login page not showing");
//            Assert.IsTrue(BeautyBookingLoginEmail.Displayed, "Beauty booking login page not showing");
//        }

//        public void LoginToBeautyBookingApplication(string UserName, string Password)
//        {
//            WebHandlers.Instance.EnterText(BeautyBookingLoginEmail, UserName);
//            BeautyBookingLoginPassword.SendKeys(Password);
//            //WebHandlers.Instance.EnterText(BeautyBookingLoginPassword, Password);
//            WebHandlers.Instance.Click(BeautyBookingSignInbtn);
//            BrowserDriver.Sleep(3000);
//        }

//        public void PerformOTPValidationFromYopmail(string UserName)
//        {
//            if (BBOTPEmailRadio.Displayed)
//            {
//                WebHandlers.Instance.Click(BBOTPEmailRadio);
//                WebHandlers.Instance.Click(driver.FindElement(DivConfirmMsg("Send")));
//                BrowserDriver.Sleep(3000);
//                WebHandlers.Instance.ElementPresent(BBVerifyEmailOTPInput);

//                string OTP = FetchEmailOTPFromYopmail(UserName);
//                BrowserDriver.Sleep(2000);
//                //WebHandlers.Instance.EnterText(BBVerifyEmailOTPInput, OTP);
//                BBVerifyEmailOTPInput.SendKeys(OTP);
//                BrowserDriver.Sleep(1000);
//                WebHandlers.Instance.Click(driver.FindElement(DivConfirmMsg("Verify")));
//                BrowserDriver.Sleep(5000);
//                //WebHandlers.Instance.WebElementExists(driver.FindElement(MainHeaderConfirmMsg("Choose a Beauty Department")));
//            }
//        }

//        public void NavigateToBBUpcomingBookings()
//        {
//            String mouseHoverScript = "var element = arguments[0]; var mouseEventObj = document.createEvent('MouseEvents'); mouseEventObj.initEvent( 'mouseover', true, true ); element.dispatchEvent(mouseEventObj);";

//            WebHandlers.Instance.WebElementExists(driver.FindElement(spanHarrodsText("My Account & Bookings")));
//            WebHandlers.Instance.ExecuteScript(mouseHoverScript, driver.FindElement(spanHarrodsText("My Account & Bookings")));
//            WebHandlers.Instance.Click(driver.FindElement(LinkHarrodsText("Upcoming Bookings")));
//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.WebElementExists(driver.FindElement(spanHarrodsText("Your Upcoming Bookings")));
//            BrowserDriver.Sleep(2000);
//        }

//        public void ValidateBBUserBookingsDetails(string[] BookingDetails)
//        {
//            Assert.IsTrue(driver.FindElement(spanHarrodsText(BookingDetails[0])).Displayed, "Booking department not showing on the page");
//            Assert.IsTrue(driver.FindElement(DivConfirmMsg(BookingDetails[1])).Displayed, "Booking service not showing on the page");
//        }

//        public void NavigateToBBPersonalDetails()
//        {
//            WebHandlers.Instance.Click(driver.FindElement(LinkHarrodsText("PERSONAL DETAILS")));
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Edit Your Details")));
//            BrowserDriver.Sleep(2000);
//        }

//        public void ValidateBBUserPersonalDetails(string Username, string Phone)
//        {

//            string[] words = Username.Split(' ');
//            Assert.AreEqual(words[0], driver.FindElement(BBUserPersonalName("1")).GetAttribute("value"), "User first name not showing as expected");
//            Assert.AreEqual(words[1], driver.FindElement(BBUserPersonalName("2")).GetAttribute("value"), "User last name not showing as expected");
//            Assert.AreEqual(Phone, BBUserPersonalPhone.GetAttribute("value"), "User phone number is not showing as expected");
//        }

//        public void PerformBookingFromHarrodsBeautyBooking(string BookingService)
//        {
//            string BookingDay = DateTime.Now.ToString("MMMM");

//            //Performing beauty booking service
//            driver.Navigate().GoToUrl(config.BBBookingUrl + BookingService);
//            WebHandlers.Instance.WebElementExists(BBBookingViewAvailability);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(BBBookingAvailableDay(BookingDay)));
//            SelectElement AppTime = new SelectElement(BBBookingViewAvailTime);
//            AppTime.SelectByValue("09:00");
//            WebHandlers.Instance.Click(BBBookingViewAvailability);
//            WebHandlers.Instance.WebElementExists(BBBookingServiceSelect);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(BBBookingServiceSelect);
//            WebHandlers.Instance.WebElementExists(BBBookingCheckout);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(BBBookingCheckout);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Register with Harrods")));
//            BrowserDriver.Sleep(2000);
//        }

//        public DateTime NewUserRegistrationFromHarrodsBeautyBooking(string UserName, string Email, string[] PhoneWithCountryCode, bool EmailConsent)
//        {
//            //Performing user registration from Prespa
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Register with Harrods")));
//            SelectElement SelectUserTitle = new SelectElement(BBUserRegTitle);
//            SelectUserTitle.SelectByValue("Mr");
//            WebHandlers.Instance.EnterText(BBUserRegFirstName, UserName);
//            WebHandlers.Instance.EnterText(BBUserRegLastName, UserName + "Lname");
//            SelectElement SelectCountry = new SelectElement(BBUserRegCountryCode);
//            SelectCountry.SelectByText(PhoneWithCountryCode[0]);
//            WebHandlers.Instance.EnterText(BBUserRegPhone, PhoneWithCountryCode[1]);
//            WebHandlers.Instance.EnterText(BBUserRegEmail, Email);
//            WebHandlers.Instance.EnterText(BBUserRegPassword, config.FFCustomerPassword);
//            WebHandlers.Instance.EnterText(BBUserRegVerifyPassword, config.FFCustomerPassword);
//            if (EmailConsent)
//            {
//                Actions action = new Actions(driver);
//                action.Click(BBUserRegEmailConsent).Build().Perform();
//                //BBUserRegEmailConsent.Click();
//            }
//            //WebHandlers.Instance.Click(BBUserRegEmailConsent);
//            WebHandlers.Instance.Click(driver.FindElement(DivConfirmMsg("Register & Continue")));
//            DateTime TimeStamp = DateTime.Now;
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Verify your Harrods account")));
//            return TimeStamp;
//        }

//        public void ValidateNewUserBookingDetailsFromBeautyBookingWebsite(string Email, string BookingService)
//        {
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails(" Is this booking for yourself? ")));
//            Assert.IsTrue(driver.FindElement(BBBookingServiceName(BookingService)).Displayed, "Booking service name not showing on the page");
//            Assert.IsTrue(BBBookingPayment.Displayed, "Booking payment not showing on the page");
//            Assert.IsTrue(driver.FindElement(spanHarrodsText(Email.ToLower())).Displayed, "User email not showing under booking details");
//        }
//        public void PerformEmailtenpercentDiscountValidation(string Email)
//        {
//            driver.Navigate().GoToUrl(config.YopMailUrl);
//            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);

//            if (BtnYopmailAcceptCookies.Displayed)
//            {
//                WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
//                BrowserDriver.Sleep(3000);
//            }

//            //Searching for harrods email
//            EdtYopmailLoginEmail.SendKeys(Email);
//            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
//            BrowserDriver.Sleep(3000);

//            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
//            WebWaitHelper.Instance.WaitForElementPresence(TenPcancelledSubject);

//            Assert.IsTrue(TenPcancelledSubject.Displayed, "10 percent canncelled message is not displayed");
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(YopmailDeleteEmail, "clicked on Delete Email");

//            BrowserDriver.Sleep(2000);

//        }

//        public string Validate10pDisplayed()
//        {
//            Boolean displaystatus = false;
//            string day1_selecteddate = "";
//            string day2_selecteddate = "";
//            Boolean day1status;
//            try
//            {
//                day1status = TenPctDay1Link.Displayed;
//                if (day1status)
//                {
//                    day1_selecteddate = Select10pDayOneFromHarrods();
//                    day1status = false;
//                }
//            }
//            catch (Exception e)
//            {
//                day1status = false;
//            }
//            Boolean day2status;
//            try
//            {
//                day2status = TenPctDay2Link.Displayed;
//                if (day2status)
//                {
//                    day2_selecteddate = Select10pDayTwoFromHarrods();
//                    day2status = false;
//                }
//            }
//            catch (Exception e)
//            {
//                day2status = false;
//            }

//            BrowserDriver.Sleep(2000);
//            if ((!day1status) && (!day2status))
//            {
//                displaystatus = true;
//            }
//            Assert.IsTrue(displaystatus, "10 % Discount dates are not displayed");
//            Console.WriteLine("Day 2 Date ==> " + day2_selecteddate);
//            return day2_selecteddate;
//        }

//        public void PerformWelcomeEmailValidation(string Email, string UserName, string UserCategory)
//        {
//            BrowserDriver.Sleep(15000);

//            driver.Navigate().GoToUrl(config.YopMailUrl);
//            //driver.Navigate().GoToUrl(CommonFunctions.RewriteFarfetchUrl(config.FFLiteVerifyUrl, config));
//            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);

//            if (BtnYopmailAcceptCookies.Displayed)
//            {
//                WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
//                BrowserDriver.Sleep(3000);
//            }

//            //Searching for harrods email
//            EdtYopmailLoginEmail.SendKeys(Email);
//            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
//            BrowserDriver.Sleep(3000);

//            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);

//            if (UserCategory == "176_Existing_LoyaltyRewardsGroupAccountCustomer_AddMultipleChild_ValidateWelcomeEmail")
//            {
//                Assert.IsTrue(driver.FindElement(By.XPath("//div[text()='Welcome to Mini Harrods']")).Displayed, "Welcome email FirstName not displayed ");
//            }
//            else
//            {
//                WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(YopmailWelcomeFirstName(UserName)));

//                Assert.IsTrue(driver.FindElement(YopmailWelcomeFirstName(UserName)).Displayed, "Welcome email FirstName not displayed ");

//            }
//            BrowserDriver.Sleep(5000);
//            // WebHandlers.Instance.Click(YopmailDeleteEmail, "clicked on Delete Email");

//            // BrowserDriver.Sleep(2000);

//        }
//        public void IDSLoginPageGetsDisplayed()
//        {
//            WebHandlers.Instance.WebElementExists(IDSLoginPassword);
//            Assert.IsTrue(IDSLoginPassword.Displayed, "IDS login page not showing");
//            Assert.IsTrue(IDSLoginEmail.Displayed, "IDS login username not showing");
//        }

//        public void LoginToIDSApplication(string UserName, string Password)
//        {
//            WebHandlers.Instance.EnterText(IDSLoginEmail, UserName);
//            IDSLoginPassword.SendKeys(Password);
//            WebHandlers.Instance.Click(IDSSignInbtn);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(LinkHarrodsText("Home")));
//            BrowserDriver.Sleep(3000);
//        }

//        public void NavigateToIDSCreateNewProject()
//        {
//            WebHandlers.Instance.Click(driver.FindElement(LinkHarrodsText("Create New Project")));
//            WebHandlers.Instance.WebElementExists(IDSCustomerRewardsCard);
//            BrowserDriver.Sleep(3000);
//        }

//        public void PerformCustomerSearchOnIDS(string RewardsCardNumber)
//        {
//            WebHandlers.Instance.EnterText(IDSCustomerRewardsCard, RewardsCardNumber);
//            WebHandlers.Instance.Click(IDSCustomerRewardsCardSearch);
//            WebHandlers.Instance.WebElementExists(IDSProjectClientName);
//            BrowserDriver.Sleep(3000);
//        }

//        public void ValidateIDSPopulatedWithUserDetails(string SapId, string UserName, string RewardCard, string Phone)
//        {
//            Assert.AreEqual(SapId, IDSProjectClientSapCustomerId.GetAttribute("value"), "User SAP id is not showing as expected on IDS");
//            Assert.AreEqual(UserName, IDSProjectClientName.GetAttribute("value"), "User name is not showing as expected on IDS");
//            Assert.AreEqual(RewardCard, IDSProjectClientRewardsCard.GetAttribute("value"), "User card number is not showing as expected on IDS");
//            Assert.AreEqual(Phone, IDSProjectClientTelephone.GetAttribute("value"), "User phone number is not showing as expected on IDS");
//            WebHandlers.Instance.Click(IDSProjectCancel);
//            BrowserDriver.Sleep(2000);
//        }

//        public void ValidateTenPRemainingDaysAndDate(string RemainingDays, string BookedDate)
//        {
//            BrowserDriver.Sleep(3000);
//            driver.Navigate().Refresh();
//            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
//            driver.Navigate().Refresh();
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("10% Discount Days")));
//            Assert.IsTrue(driver.FindElement(ParaUserDetails(RemainingDays)).Displayed, "10% dicount remaining days is not showing as expected on Harrods.com");
//            Assert.IsTrue(driver.FindElement(ParaUserDetails(BookedDate)).Displayed, "10% dicount booked date is not showing as expected on Harrods.com");
//        }

//        public void LoginToYopmail(string Email)
//        {
//            WebWaitHelper.Instance.WaitForElementPresence(EdtYopmailLoginEmail);
//            if (BtnYopmailAcceptCookies.Displayed)
//            {
//                WebHandlers.Instance.Click(BtnYopmailAcceptCookies);
//                BrowserDriver.Sleep(3000);
//            }

//            //Searching for harrods email
//            EdtYopmailLoginEmail.SendKeys(Email);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(BtnYopmailGoToInbox);
//            BrowserDriver.Sleep(3000);
//        }

//        public void Validate10pEmailContent(string UserName, string DateSelected)
//        {
//            WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
//            int count = driver.FindElements(spanHarrodsText("Harrods Rewards")).Count;
//            WebHandlers.Instance.Click(driver.FindElement(YopHarrodsSpecificEmail(count.ToString())));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.SwithBackFromFrame();

//            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
//            Assert.IsTrue(driver.FindElement(ParaUserDetails("First Name = " + UserName)).Displayed, "User first name not listing on email");
//            Assert.IsTrue(driver.FindElement(ParaUserDetails("Last Name = " + UserName + "Lname")).Displayed, "User last name not listing on email");
//            Assert.IsTrue(driver.FindElement(ParaUserDetails("Source = OL")).Displayed, "User source details not listing on email");
//            WebHandlers.Instance.SwithBackFromFrame();

//            WebHandlers.Instance.SwitchToFrame(FrameYopmailInbox);
//            WebHandlers.Instance.Click(driver.FindElement(YopHarrodsSpecificEmail((count - 1).ToString())));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.SwithBackFromFrame();
//            WebHandlers.Instance.SwitchToFrame(FrameYopmailDescription);
//            Assert.IsTrue(driver.FindElement(ParaUserDetails("Dear " + UserName)).Displayed, "User first name not listing on email");
//            Assert.IsTrue(driver.FindElement(YopmailTenpDaySelection(DateSelected)).Displayed, "User 10 percentage discount details not listing on email");
//            WebHandlers.Instance.SwithBackFromFrame();
//        }

//        public void ValidateUserChildrenDetails(string[] ChildrenData)
//        {
//            WebHandlers.Instance.WebElementExists(driver.FindElement(MainHeaderConfirmMsg("Mini Harrods")));

//            foreach (string child in ChildrenData)
//                Assert.IsTrue(driver.FindElement(ParaUserDetails(child)).Displayed, child + " name not listing on online mini harrods page");
//        }

//        public string Select10pDayTwoFromHarrods()
//        {
//            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Day 2")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(ParaUserDetails("Day 2")));
//            BrowserDriver.Sleep(2000);
//            string AvailableDay = TenpBookingAvailableDay.GetAttribute("innerHTML");
//            WebHandlers.Instance.Click(TenpBookingAvailableDay);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.Click(TenpBookingSelectbtn);
//            BrowserDriver.Sleep(2000);
//            return AvailableDay;
//        }

//        public string Select10pDayOneFromHarrods()
//        {
//            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Day 1")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(ParaUserDetails("Day 1")));
//            BrowserDriver.Sleep(2000);
//            string AvailableDay = TenpBookingAvailableDay.GetAttribute("innerHTML");
//            WebHandlers.Instance.Click(TenpBookingAvailableDay);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.Click(TenpBookingSelectbtn);
//            BrowserDriver.Sleep(4000);
//            return AvailableDay;
//        }

//        public void ValidateTenpDay2BookingAndRemainingDays(string RemainingDays, string[] DayYear)
//        {
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("10% Discount Days")));
//            Assert.IsTrue(driver.FindElement(ParaUserDetails(RemainingDays)).Displayed, "10% dicount remaining days is not showing as expected on Harrods.com");
//            Assert.IsTrue(driver.FindElement(ParaContainsData(DayYear[0])).Displayed, "10% dicount booked day is not showing as expected on Harrods.com");
//            //Assert.IsTrue(driver.FindElement(ParaContainsData(DayYear[1])).Displayed, "10% dicount booked year is not showing as expected on Harrods.com");
//        }

//        public void Cancel10pDayTwoFromHarrods()
//        {
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.WaitForPageLoad();
//            //WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
//            //driver.FindElement(spanHarrodsText("Account Home")).Click();
//            //WebHandlers.Instance.WebElementExists(TenpBookingCancelbtn);
//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.Click(TenpBookingCancelbtn);
//            TenpBookingCancelbtn.Click();
//            driver.Navigate().Refresh();
//            BrowserDriver.Sleep(3000);

//        }

//        public void ValidateRewardsStatementDetailsFromHarrods(string PointsCreditMode, string TxnId)
//        {
//            AccountPage accountPage = new AccountPage(driver);
//            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Rewards Statements")));
//            WebHandlers.Instance.WebElementExists(driver.FindElement(MainHeaderConfirmMsg("Rewards Statement")));
//            BrowserDriver.Sleep(6000);
//            if (PointsCreditMode == "Miscellaneous")
//                Assert.IsTrue(driver.FindElement(BBBookingServiceName("Manual Rewards Points Adjustment")).Displayed, "Miscellaneous point statement not showing on harrods rewards");
//            else if (PointsCreditMode == "Transfers")
//                Assert.IsTrue(driver.FindElement(BBBookingServiceName("Transfer points to group members")).Displayed, "Transfer point statement not showing on harrods rewards");
//            else if (PointsCreditMode == "Redeemed")
//                Assert.IsTrue(driver.FindElement(BBBookingServiceName("Redemption at POS")).Displayed, "Redeemed point statement not showing on harrods rewards");
//            else if (PointsCreditMode == "Retrospective")
//                Assert.IsTrue(driver.FindElement(BBBookingServiceName("Purchase")).Displayed, "Retrospective point statement not showing on harrods rewards");
//            else if (PointsCreditMode == "Purchase")
//                Assert.IsTrue(driver.FindElement(BBBookingServiceName(TxnId)).Displayed, "Purchase point statement not showing on harrods rewards");

//            accountPage.logOut();
//        }

//        #endregion



//    }
//}
