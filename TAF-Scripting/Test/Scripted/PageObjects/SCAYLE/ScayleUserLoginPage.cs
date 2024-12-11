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
    class ScayleUserLoginPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public ScayleUserLoginPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        //TABS-SCAYLE
        //[FindsBy(How = How.XPath, Using = "(//span[text()='Update Contact Number'])[1]")]
        [FindsBy(How = How.XPath, Using = "(//span[@data-test-id='headline' and text()='Update Contact Number'])[2]")]
        private IWebElement ScayleUpdateContactTabClick;

        [FindsBy(How = How.XPath, Using = "(//span[@data-test-id='headline' and text()='Communication Preferences'])[2]")]
        private IWebElement ScayleCommunicationPerferencesTabClick;

        [FindsBy(How = How.XPath, Using = "(//span[@data-test-id='headline' and text()='Birthday Rewards'])[2]")]
        private IWebElement ScayleBirthdayRewardsTabClick;

        [FindsBy(How = How.XPath, Using = "(//span[@data-test-id='headline' and text()='Manage Address'])[2]")]
        private IWebElement ScayleManageAddressTabClick;

        [FindsBy(How = How.XPath, Using = "(//span[text()='Communication Preferences'])[1]")]
        private IWebElement ScayleCommunicationPreferencesTabClick;

        [FindsBy(How = How.XPath, Using = "(//a[text()='Sign In'])[1]")]
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

        [FindsBy(How = How.XPath, Using = "(//input[@name='username'])[3]")]
        private IWebElement loginEmail;

        [FindsBy(How = How.XPath, Using = "(//*[@name='password'])[5]")]
        private IWebElement loginPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='loginForm-submitButton'][text()='Sign in']")]
        private IWebElement Login1;

        [FindsBy(How = How.XPath, Using = "(//input[@name='username'])[3]")]
        private IWebElement loginEmailAfterRegistration;

        [FindsBy(How = How.XPath, Using = "(//*[@name='password'])[5]")]
        private IWebElement loginPasswordAfterRegistration;

        [FindsBy(How = How.XPath, Using = "//*[@value='Sign in']")]
        private IWebElement LoginAfterRegistration;

        [FindsBy(How = How.XPath, Using = "//p[text()='Points']/ancestor::div/following-sibling::div//descendant::p")]
        private IWebElement ScayleCustomersRewardsPointsDetails;





        //[FindsBy(How = How.XPath, Using = "//Button[text()='Accept & Continue']")]
        //div[@id = 'buttons']/button[2]/span[text()='Agree and close']
        //[FindsBy(How = How.XPath, Using = "//button/span[text()='Agree and close']")]
        [FindsBy(How = How.XPath, Using = "//div[@id = 'buttons']/button[2]/span[text()='Agree and close']")]
        private IWebElement ScayleAgree;

        [FindsBy(How = How.XPath, Using = "//input[@id='newsletterForm-email']")]
        private IWebElement EdtSignUpToEmail;

        [FindsBy(How = How.XPath, Using = "//button[text()='Sign Up']")]
        private IWebElement BtnSignUp;

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign up to emails']")]
        private IWebElement BtnSignUpToEmail;

        [FindsBy(How = How.XPath, Using = "//main/div/div[2]/div/button[text()='Continue to Sign In']")]
        private IWebElement BtnContinueSignIn;

        [FindsBy(How = How.XPath, Using = "//*[@value='Sign in']")]
        private IWebElement Login2;

        [FindsBy(How = How.XPath, Using = "//span[text()='Join Harrods Rewards']")]
        private IWebElement JoinRewardsbtnOnSignInPage;

        [FindsBy(How = How.XPath, Using = "//button[text()='Join Harrods Rewards']")]
        private IWebElement JoinRewardsbtnOnRewardsPage;

        [FindsBy(How = How.XPath, Using = "(//span[@data-test-id='headline'])[2]")]
        private IWebElement Userlogin;

        [FindsBy(How = How.XPath, Using = "//*[@class='font-grotesk font-light text-[16px] tracking-[0] leading-[24px] text-white flex items-center gap-2 mt-2.5']")]
        private IWebElement Rewardadded;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Green')]")]
        private IWebElement RewardTier;

        [FindsBy(How = How.XPath, Using = "//span[text()='Select Day 1']")]
        public IWebElement TenPctDay1Link;

        [FindsBy(How = How.XPath, Using = "//span[text()='Select Day 2']")]
        public IWebElement TenPctDay2Link;

        [FindsBy(How = How.XPath, Using = "(//span[text()='Cancel'])[2]")]
        public IWebElement TenpBookingCancelbtnDay2;

        [FindsBy(How = How.XPath, Using = "(//span[text()='Cancel'])[1]")]
        public IWebElement TenpBookingCancelbtnDay1;

        [FindsBy(How = How.XPath, Using = "//span[text()='Select Date']")]
        public IWebElement TenpBookingSelectionbtn;

        // Current date +9 date selection for booking
        [FindsBy(How = How.XPath, Using = "(//td[@class='relative size-[47px] overflow-hidden text-center text-sm'][@aria-disabled='false'])[9]/div")]
        public IWebElement TenpBookingAvailableDay;

        [FindsBy(How = How.XPath, Using = "(//td[@class='relative size-[47px] overflow-hidden text-center text-sm'][@aria-disabled='false'])[28]")]
        public IWebElement thrityAdvanceBookingDay;

        [FindsBy(How = How.Id, Using = "schedule-selectDate")]
        public IWebElement TenpBookingSelectbtn;

         #endregion
        public By HeadingUserDetails(string Details)
        {
            return By.XPath("//h3[text()='" + Details + "']");
        }
        public By ParaUserDetails(string Details)
        {
            return By.XPath("//p[text()='" + Details + "']");
        }


           // public By BoldUserDetails(string Details)
        public By SpanUserDetails(string Details)
        {
            return By.XPath("//span[text()='" + Details + "']");
        }
        public By BoldUserDetails(string Details)
        {
            return By.XPath("//b[text()='" + Details + "']");
        }
        public By HeaderConfirmMsg(string Message) { return By.XPath("//h2[text()='" + Message + "']"); }
        public By ParaContainsData(string Data) { return By.XPath("(//p[contains(text(),'" + Data + "')])[1]"); }

        public By spanHarrodsText(string Message) { return By.XPath("//span[text()='" + Message + "']"); }

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

        public void InvokeSignInProcessAndEnterOTP(string userName, string password)
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
                if (WebHandlers.Instance.WebElementExists(ScayleAgree))
                    WebHandlers.Instance.Click(ScayleAgree, "Agree Button not visible");
            }
            catch (NoSuchElementException) { }
        }

        public void PerformClickOnContinueToSignIn()
        {

            List<String> tabs = new List<String>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[0]);
            driver.Close();
            driver.SwitchTo().Window(tabs[1]);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(BtnContinueSignIn);
        }

        public void PerformSignInAfterRegistration(string userName, string password)
        {
            //log.Info("Sign In after confirmation.");
            BrowserDriver.Sleep(1000);

            //List<String> tabs = new List<String>(driver.WindowHandles);

            //driver.SwitchTo().Window(tabs[1]);

            WebHandlers.Instance.EnterText(loginEmailAfterRegistration, userName, $"Entered {userName} for login email");
            WebHandlers.Instance.EnterText(loginPasswordAfterRegistration, password, $"Entered ******** for password");
            WebHandlers.Instance.ClickByJsExecutor(LoginAfterRegistration, "Login");
            BrowserDriver.Sleep(10000);

        }

        public void ValidateUserRewardsPointsOnScayle(string RewardsPoint)
        {
            BrowserDriver.Sleep(3000);
            double RewardsPoints = Convert.ToDouble(RewardsPoint);
            string formattedRewardsPoint = RewardsPoints.ToString("N0");
            String rewardPts = driver.FindElement(By.XPath("//p[text()='Points']/ancestor::div/following-sibling::div//descendant::p")).Text;
            Console.WriteLine("Reward Points from the Scayle" + rewardPts);
            char[] charsToTrim = { '<', '!', '-', '>' };
            String trimmedRewardPts = rewardPts.Trim(charsToTrim);
            Assert.AreEqual(formattedRewardsPoint, trimmedRewardPts, "Scayle - Customer rewards points is not showing as expected");
            //Assert.AreEqual(formattedRewardsPoint, WebHandlers.Instance.GetAttribute(ScayleCustomersRewardsPointsDetails, "innerHTML"), "Harrods.com - Customer rewards points is not showing as expected");
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

        public void JoinRewards()
        {
            BrowserDriver.Sleep(10000);
            WebHandlers.Instance.Click(JoinRewardsbtnOnSignInPage);
            BrowserDriver.Sleep(10000);
            WebHandlers.Instance.Click(JoinRewardsbtnOnRewardsPage);
            BrowserDriver.Sleep(10000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(5000);
        }

        public void ValidateJoinRewardsWithoutCardData(string UserName)
        {
            try { Assert.IsTrue(Rewardadded.Displayed, "Rewards/Tier  details not get generated after performing join rewards"); }
            catch { Assert.IsTrue(RewardTier.Displayed, "Not able to join rewards from Scayle without rewards card data "); }

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
        //TC_45

        public void PerformClickOnUpdateContactTab()
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollBy(0, 1000);");
            IWebElement element = driver.FindElement(By.XPath("(//*[text()='Update Contact Number'])[1]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(ScayleUpdateContactTabClick);
            //ScayleUpdateContactTabClick.Click();
            BrowserDriver.Sleep(10000);


        }

        public void PerformClickOnCommunicationPreferencesTab()
        {
            IWebElement element = driver.FindElement(By.XPath("(//*[text()='Communication Preferences'])[1]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(ScayleCommunicationPerferencesTabClick);
            //ScayleUpdateContactTabClick.Click();
            BrowserDriver.Sleep(10000);
            Assert.IsTrue(element.Displayed, "'Communication Preferences' tab is displayed");

        }

        public void PerformClickOnBirthdayRewardsTab()
        {
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollBy(0, 1000);");
            IWebElement element = driver.FindElement(By.XPath("(//*[text()='Update Contact Number'])[1]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(ScayleBirthdayRewardsTabClick);
            //ScayleUpdateContactTabClick.Click();
            BrowserDriver.Sleep(10000);

            // Assert.IsTrue(ScayleBirthdayRewardsTabClick.Displayed, "'Communication Preferences' tab is displayed");

        }

        public void PerformClickOnManageAddressTab()
        {
            IWebElement element = driver.FindElement(By.XPath("(//*[text()='Update Contact Number'])[1]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(ScayleManageAddressTabClick);
            //ScayleUpdateContactTabClick.Click();
            BrowserDriver.Sleep(10000);


        }
        public string Select10pDayTwoFromHarrods()
        {
            //WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
            //WebHandlers.Instance.WebElementExists(driver.FindElement(SpanUserDetails("Day 2")));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(SpanUserDetails("Select Day 2")));
            BrowserDriver.Sleep(2000);
            string AvailableDay = TenpBookingAvailableDay.GetAttribute("innerHTML");

            //Changes as on 5th Aug 2024 : Adding 30 days to booking so that it should not show not consumed on SSC
            //string thirtyDayAdvanceBooking = thrityAdvanceBookingDay.GetAttribute("innerHTML");
            WebHandlers.Instance.Click(TenpBookingAvailableDay);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(TenpBookingSelectionbtn);
            BrowserDriver.Sleep(4000);
            return AvailableDay;
        }

        public string Select10pDayOneFromHarrods()
        {
            //WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
            //BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Day 1")));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(SpanUserDetails("Select Day 1")));
            BrowserDriver.Sleep(2000);
            string AvailableDay = TenpBookingAvailableDay.GetAttribute("innerHTML");

            //Changes as on 5th Aug 2024 : Adding 30 days to booking so that it should not show not consumed on SSC

            //string thirtyDayAdvanceBooking = thrityAdvanceBookingDay.GetAttribute("innerHTML");
            WebHandlers.Instance.Click(TenpBookingAvailableDay);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(TenpBookingSelectionbtn);
            BrowserDriver.Sleep(4000);
            return AvailableDay;
        }
        public string Validate10pDisplayed()

        {
            Boolean displaystatus = false;
            string day1_selecteddate = "";
            string day2_selecteddate = "";
            Boolean day1status;
            try
            {
                day1status = TenPctDay1Link.Displayed;
                if (day1status)
                {
                    day1_selecteddate = Select10pDayOneFromHarrods();
                    day1status = false;
                }
            }
            catch (Exception e)
            {
                day1status = false;
            }
            Boolean day2status;
            try
            {
                day2status = TenPctDay2Link.Displayed;
                if (day2status)
                {
                    day2_selecteddate = Select10pDayTwoFromHarrods();
                    day2status = false;
                }
            }
            catch (Exception e)
            {
                day2status = false;
            }

            BrowserDriver.Sleep(2000);
            if ((!day1status) && (!day2status))
            {
                displaystatus = true;
            }
            Assert.IsTrue(displaystatus, "10 % Discount dates are not displayed");
            Console.WriteLine("Day 2 Date ==> " + day2_selecteddate);
            return day2_selecteddate;
        }

        public void ValidateTenPRemainingDaysAndDate(string RemainingDays, string BookedDate)
        {
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.WebElementExists(driver.FindElement(HeadingUserDetails("10% Discount Days")));
            Assert.IsTrue(driver.FindElement(ParaUserDetails(RemainingDays)).Displayed, "10% dicount remaining days is not showing as expected on Harrods.com");
            // Assert.IsTrue(driver.FindElement(ParaUserDetails(BookedDate)).Displayed, "10% dicount booked date is not showing as expected on Harrods.com");
        }

        public void ValidateTenpDay2BookingAndRemainingDays(string RemainingDays, string[] DayYear)
        {
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.WebElementExists(driver.FindElement(HeadingUserDetails("10% Discount Days")));
            driver.Navigate().Refresh();
            Assert.IsTrue(driver.FindElement(ParaUserDetails(RemainingDays)).Displayed, "10% dicount remaining days is not showing as expected on Harrods.com");
            Assert.IsTrue(driver.FindElement(ParaContainsData(DayYear[0])).Displayed, "10% dicount booked day is not showing as expected on Harrods.com");
            //Assert.IsTrue(driver.FindElement(ParaContainsData(DayYear[1])).Displayed, "10% dicount booked year is not showing as expected on Harrods.com");
        }

        public void Cancel10pDayTwoFromHarrods()
        {
            TenpBookingCancelbtnDay2.Click();
            BrowserDriver.Sleep(5000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(3000);
        }


        public void CancelAll10pDayFromHarrods()
        {
            BrowserDriver.Sleep(5000);

            // Get the initial count of cancel button
            IList<IWebElement> cancelButtons = driver.FindElements(By.XPath("(//span[text()='Cancel'])"));
            int count = cancelButtons.Count;

            // Iterate through each cancel button and click it
            for (int i = count; i > 0; i--)
            {

                cancelButtons = driver.FindElements(By.XPath("(//span[text()='Cancel'])"));

                // Click on the first cancel button in the updated list
                //cancelButtons[i].Click();
                driver.FindElement(By.XPath("(//span[text()='Cancel'])"+"["+i+"]")).Click();

                BrowserDriver.Sleep(7000);
            }

        }
    }
    #endregion
}