using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using TAF_Web.Scripted.Web;
using OpenQA.Selenium.Support.UI;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.FF
{
    class FFUserMyBeautyPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public FFUserMyBeautyPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion
        //[FindsBy(How = How.XPath, Using = "//input[@type='password']")]
        //private IWebElement BeautyBookingLoginPassword;

        //[FindsBy(How = How.XPath, Using = "//input[@type='email']")]
        //private IWebElement BeautyBookingLoginEmail;

        //[FindsBy(How = How.XPath, Using = "(//button[@type='submit'])[1]")]
        //private IWebElement BeautyBookingSignInbtn;

        [FindsBy(How = How.XPath, Using = "(//input[@type='password'])[11]")]
        private IWebElement BeautyBookingLoginPassword;

        [FindsBy(How = How.XPath, Using = "//*[text()='Email Address']//following::input[1]")]
        private IWebElement BeautyBookingLoginEmail;

        [FindsBy(How = How.XPath, Using = "(//input[@type='submit'])[16]")]
        private IWebElement BeautyBookingSignInbtn;

        [FindsBy(How = How.XPath, Using = "//button[text()='View Availability']")]
        public IWebElement BBBookingViewAvailability;

        [FindsBy(How = How.XPath, Using = "//select[@class='form-control']")]
        public IWebElement BBBookingViewAvailTime;

        [FindsBy(How = How.XPath, Using = "(//button[text()=' Select '])[1]")]
        public IWebElement BBBookingServiceSelect;

        [FindsBy(How = How.XPath, Using = "//a[text()=' Checkout ']")]
        public IWebElement BBBookingCheckout;

        [FindsBy(How = How.XPath, Using = "//p[text()='Title']/following-sibling::select[@class='form-control']")]
        public IWebElement BBUserRegTitle;

        [FindsBy(How = How.XPath, Using = "//input[@type='first-name']")]
        public IWebElement BBUserRegFirstName;

        [FindsBy(How = How.XPath, Using = "//input[@type='last-name']")]
        public IWebElement BBUserRegLastName;

        [FindsBy(How = How.XPath, Using = "//p[text()='Contact Phone Number']/following-sibling::div//select[@class='form-control']")]
        public IWebElement BBUserRegCountryCode;

        [FindsBy(How = How.XPath, Using = "//input[@type='tel']")]
        public IWebElement BBUserRegPhone;

        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
        public IWebElement BBUserRegEmail;

        [FindsBy(How = How.XPath, Using = "(//input[@type='password'])[1]")]
        public IWebElement BBUserRegPassword;

        [FindsBy(How = How.XPath, Using = "(//input[@type='password'])[2]")]
        public IWebElement BBUserRegVerifyPassword;

        [FindsBy(How = How.XPath, Using = "//input[@name='checkbox-1']")]
        public IWebElement BBUserRegEmailConsent;

        [FindsBy(How = How.XPath, Using = "//input[@type='tel']")]
        public IWebElement BBUserPersonalPhone;

        [FindsBy(How = How.XPath, Using = "//button[text()=' Continue to Payment ']")]
        public IWebElement BBBookingPayment;

        public By LinkHarrodsText(string Message) { return By.XPath("//a[text()='" + Message + "']"); }

        #region Elements
        #endregion

        public By spanHarrodsText(string Message) { return By.XPath("//span[text()='" + Message + "']"); }

        public By DivConfirmMsg(string Message) { return By.XPath("//div[contains(text(),'" + Message + "')]"); }

        public By ParaUserDetails(string Details) { return By.XPath("//p[text()='" + Details + "']"); }

        public By BBUserPersonalName(string item) { return By.XPath("(//input[@type='last-name'])[" + item + "]"); }

        public By BBBookingServiceName(string ServiceName) { return By.XPath("(//span[text()='" + ServiceName + "'])[1]"); }

        public By BBBookingAvailableDay(string DateTime) { return By.XPath("(//span[contains(@aria-label,'" + DateTime + "')][@aria-disabled='false'])[1]"); }

        #region Events
        public void BeautyBookingLoginPageGetsDisplayed()
        {
            WebHandlers.Instance.WebElementExists(BeautyBookingLoginPassword);
            WebHandlers.Instance.WaitForPageLoad();
            Assert.IsTrue(BeautyBookingLoginPassword.Displayed, "Beauty booking login page not showing");
            Assert.IsTrue(BeautyBookingLoginEmail.Displayed, "Beauty booking login page not showing");
        }

        public void LoginToBeautyBookingApplication(string UserName, string Password)
        {
           WebHandlers.Instance.EnterText(BeautyBookingLoginEmail, UserName);
            BeautyBookingLoginPassword.SendKeys(Password);
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.EnterText(BeautyBookingLoginPassword, Password);
            WebHandlers.Instance.Click(BeautyBookingSignInbtn);
            BrowserDriver.Sleep(3000);
        }

        public void NavigateToBBUpcomingBookings()
        {
            String mouseHoverScript = "var element = arguments[0]; var mouseEventObj = document.createEvent('MouseEvents'); mouseEventObj.initEvent( 'mouseover', true, true ); element.dispatchEvent(mouseEventObj);";

            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("My Account & Bookings")));
            // WebHandlers.Instance.ExecuteScript(mouseHoverScript, driver.FindElement(spanHarrodsText("My Account & Bookings")));
           // WebHandlers.Instance.Click(driver.FindElement(LinkHarrodsText("Upcoming Bookings")));
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.WebElementExists(driver.FindElement(spanHarrodsText("Your Upcoming Bookings")));
            BrowserDriver.Sleep(2000);
        }

        public void ValidateBBUserBookingsDetails(string[] BookingDetails)
        {
           // Assert.IsTrue(driver.FindElement(spanHarrodsText(BookingDetails[0])).Displayed, "Booking department not showing on the page");
           // Assert.IsTrue(driver.FindElement(DivConfirmMsg(BookingDetails[1])).Displayed, "Booking service not showing on the page");
        }

        public void NavigateToBBPersonalDetails()
        {
            //driver.Navigate().Refresh();
            BrowserDriver.Sleep(10000);
            WebHandlers.Instance.Click(driver.FindElement(LinkHarrodsText("PERSONAL DETAILS")));
            BrowserDriver.Sleep(2000);
          //  WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Edit Your Details")));
            BrowserDriver.Sleep(2000);
        }

        public void ValidateBBUserPersonalDetails(string Username, string Phone)
        {

            string[] words = Username.Split(' ');
            Assert.AreEqual(words[0], driver.FindElement(BBUserPersonalName("1")).GetAttribute("value"), "User first name not showing as expected");
            Assert.AreEqual(words[1], driver.FindElement(BBUserPersonalName("2")).GetAttribute("value"), "User last name not showing as expected");
            //Assert.AreEqual(Phone, BBUserPersonalPhone.GetAttribute("value"), "User phone number is not showing as expected");
        }

        public void PerformBookingFromHarrodsBeautyBooking(string BookingService)
        {
            string BookingDay = DateTime.Now.ToString("MMMM");

            //Performing beauty booking service
            driver.Navigate().GoToUrl(config.BBBookingUrl + BookingService);
            WebHandlers.Instance.WebElementExists(BBBookingViewAvailability);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(BBBookingAvailableDay(BookingDay)));
            SelectElement AppTime = new SelectElement(BBBookingViewAvailTime);
            AppTime.SelectByValue("12:30");
            WebHandlers.Instance.Click(BBBookingViewAvailability);
            WebHandlers.Instance.WebElementExists(BBBookingServiceSelect);
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(BBBookingServiceSelect);
            WebHandlers.Instance.WebElementExists(BBBookingCheckout);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(BBBookingCheckout);
            //WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Register with Harrods")));
            BrowserDriver.Sleep(2000);
        }

        public DateTime NewUserRegistrationFromHarrodsBeautyBooking(string UserName, string Email, string[] PhoneWithCountryCode, bool EmailConsent)
        {
            //Performing user registration from Prespa
            //WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Register with Harrods")));
            SelectElement SelectUserTitle = new SelectElement(BBUserRegTitle);
            SelectUserTitle.SelectByValue("Mr");
            WebHandlers.Instance.EnterText(BBUserRegFirstName, UserName);
            WebHandlers.Instance.EnterText(BBUserRegLastName, UserName + "Lname");
            SelectElement SelectCountry = new SelectElement(BBUserRegCountryCode);
            SelectCountry.SelectByText(PhoneWithCountryCode[0]);
            WebHandlers.Instance.EnterText(BBUserRegPhone, PhoneWithCountryCode[1]);
            WebHandlers.Instance.EnterText(BBUserRegEmail, Email);
            WebHandlers.Instance.EnterText(BBUserRegPassword, config.FFCustomerPassword);
            WebHandlers.Instance.EnterText(BBUserRegVerifyPassword, config.FFCustomerPassword);
            if (EmailConsent)
            {
                Actions action = new Actions(driver);
                action.Click(BBUserRegEmailConsent).Build().Perform();
                //BBUserRegEmailConsent.Click();
            }
            //WebHandlers.Instance.Click(BBUserRegEmailConsent);
            WebHandlers.Instance.Click(driver.FindElement(DivConfirmMsg("Register & Continue")));
            DateTime TimeStamp = DateTime.Now;
            //WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Verify your Harrods account")));
            return TimeStamp;
        }

        public void ValidateNewUserBookingDetailsFromBeautyBookingWebsite(string Email, string BookingService)
        {
            BrowserDriver.Sleep(3000);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(BBBookingCheckout);
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails(" Is this booking for yourself? ")));
            Assert.IsTrue(driver.FindElement(BBBookingServiceName(BookingService)).Displayed, "Booking service name not showing on the page");
            //Assert.IsTrue(BBBookingPayment.Displayed, "Booking payment not showing on the page");
            //Assert.IsTrue(driver.FindElement(spanHarrodsText(Email)).Displayed, "User email not showing under booking details");
        }

        #endregion
    }
}
