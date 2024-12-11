using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.FF
{
    class FFUserAccountHomePage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private FFUserSignInPage FF_User_SignIn_Page = null;
        private FFHarrodsHomePage FF_HarrodsHome_Page = null;

        #region  Constructor
        public FFUserAccountHomePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;

        }

        #endregion

        #region Elements
        [FindsBy(How = How.XPath, Using = "//span[text()='Rewards Statements']")]
        private IWebElement HarrodsRewardsStatementsLink;

        [FindsBy(How = How.XPath, Using = "//button[text()='Join Rewards']")]
        private IWebElement HarrodsJoinRewardsbtn;

        [FindsBy(How = How.XPath, Using = "//span[text()='Account Home']")]
        private IWebElement HarrodsAccountHomeLink;

        [FindsBy(How = How.XPath, Using = "//input[@id='joinRewards-cardNumber']")]
        private IWebElement HarrodsJoinRewardsCardNumberInput;

        [FindsBy(How = How.XPath, Using = "//button[text()='Link accounts']")]
        private IWebElement HarrodsJoinRewardsLinkAccountbtn;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='rewardsTier']/div[1]//p")]
        public IWebElement UserTier;

        [FindsBy(How = How.XPath, Using = "//*[text()='Day 1']")]
        public IWebElement TenPctDay1Link;

        [FindsBy(How = How.XPath, Using = "//*[text()='Day 2']")]
        public IWebElement TenPctDay2Link;
        // Current date +9 date selection for booking
        [FindsBy(How = How.XPath, Using = "(//div[@class='DayPicker-Day'][@aria-disabled='false']/span)[9]")]
        public IWebElement TenpBookingAvailableDay;

        [FindsBy(How = How.XPath, Using = "(//div[@class='DayPicker-Day'][@aria-disabled='false']/span)[30]")]
        public IWebElement thrityAdvanceBookingDay;

        [FindsBy(How = How.Id, Using = "schedule-selectDate")]
        public IWebElement TenpBookingSelectbtn;

        [FindsBy(How = How.Id, Using = "discount-days-cancel-button")]
        public IWebElement TenpBookingCancelbtn;

        [FindsBy(How = How.XPath, Using = "//span[text()='Points Balance']/following-sibling::span")]
        private IWebElement FFCustomersRewardsPointsDetails;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Account Home']")]
        private IWebElement lnkAccountHome;

        #endregion
        public By DivConfirmMsg(string Message)
        {
            return By.XPath("//div[contains(text(),'" + Message + "')]");
        }

        public By ParaUserDetails(string Details)
        {
            return By.XPath("//p[text()='" + Details + "']");
        }

        public By FFCustomersCurrentTierDetails(string TierValue) { return By.XPath("//p[text()='" + TierValue + "']"); }

        public By ParaContainsData(string Data) { return By.XPath("(//p[contains(text(),'" + Data + "')])[1]"); }

        public By spanHarrodsText(string Message) { return By.XPath("//span[text()='" + Message + "']"); }
        #region Events

        public void InvokeAccountHome()
        {
            WebHandlers.Instance.Click(lnkAccountHome);
            BrowserDriver.Sleep(3000);
        }

        public void PerformJoinRewardsWithoutCardData()
        {
            string confirmMessage = "You have successfully joined. Welcome to Harrods Rewards!";
            WebHandlers.Instance.Click(HarrodsRewardsStatementsLink);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(HarrodsJoinRewardsbtn);
            BrowserDriver.Sleep(4000);
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(DivConfirmMsg(confirmMessage)));
        }

        public void PerformJoinRewardsWithCardData(string CardNumber)
        {
            string confirmMessage = "You have successfully joined. Welcome to Harrods Rewards!";
            WebHandlers.Instance.Click(HarrodsAccountHomeLink);
            //WebWaitHelper.Instance.WaitForElementPresence(HarrodsJoinRewardsLinkAccountbtn);
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.EnterText(HarrodsJoinRewardsCardNumberInput, CardNumber);
            WebHandlers.Instance.Click(HarrodsJoinRewardsLinkAccountbtn);
            BrowserDriver.Sleep(12000);
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(DivConfirmMsg(confirmMessage)));
        }

        public void ValidateJoinRewardsWithoutCardData(string UserName)
        {
            FF_User_SignIn_Page = new FFUserSignInPage(driver, config);
            FF_HarrodsHome_Page = new FFHarrodsHomePage(driver, config);
            string confirmMessage = "You have successfully joined. Welcome to Harrods Rewards!";
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(DivConfirmMsg(confirmMessage)));
            Assert.IsTrue(driver.FindElement(DivConfirmMsg(confirmMessage)).Displayed, "User is not able to perform join rewards");

            FF_HarrodsHome_Page.logOut();
            //homePage.InvokeSignInProcess(UserName, config.FFCustomerPassword);
            //homePage.ValidateSiginFailure();
            //Assert.IsTrue(driver.FindElement(ParaUserDetails("Green Tier")).Displayed, "Rewards tier details not get generated after performing join rewards");
        }

        public void ValidateJoinRewardsWithCardData(string UserName, string CardNumber)
        {
            FF_User_SignIn_Page = new FFUserSignInPage(driver, config);
            FF_HarrodsHome_Page = new FFHarrodsHomePage(driver, config);
            string confirmMessage = "You have successfully joined. Welcome to Harrods Rewards!";
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(DivConfirmMsg(confirmMessage)));
            Assert.IsTrue(driver.FindElement(DivConfirmMsg(confirmMessage)).Displayed, "User is not able to perform join rewards");

            FF_HarrodsHome_Page.logOut();
            FF_User_SignIn_Page.InvokeSignInProcess(UserName, config.FFCustomerPassword);
            FF_User_SignIn_Page.ValidateSigninFailure();
            Assert.IsTrue(driver.FindElement(ParaUserDetails("Gold Tier")).Displayed, "Rewards tier details not get generated after performing join rewards");
            Assert.AreEqual(CardNumber, UserTier.Text, "CardNumber is not displayed correcly");
        }

        public string Select10pDayTwoFromHarrods()
        {
            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Day 2")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(ParaUserDetails("Day 2")));
            BrowserDriver.Sleep(2000);
            string AvailableDay = TenpBookingAvailableDay.GetAttribute("innerHTML");

            //Changes as on 5th Aug 2024 : Adding 30 days to booking so that it should not show not consumed on SSC
            string thirtyDayAdvanceBooking = thrityAdvanceBookingDay.GetAttribute("innerHTML");
            WebHandlers.Instance.Click(TenpBookingAvailableDay);

            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(TenpBookingSelectbtn);
            BrowserDriver.Sleep(2000);
            return AvailableDay;
        }

        public string Select10pDayOneFromHarrods()
        {
            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("Day 1")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(ParaUserDetails("Day 1")));
            BrowserDriver.Sleep(2000);
            string AvailableDay = TenpBookingAvailableDay.GetAttribute("innerHTML");

            //Changes as on 5th Aug 2024 : Adding 30 days to booking so that it should not show not consumed on SSC

            string thirtyDayAdvanceBooking = thrityAdvanceBookingDay.GetAttribute("innerHTML");
            WebHandlers.Instance.Click(TenpBookingAvailableDay);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(TenpBookingSelectbtn);
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
            BrowserDriver.Sleep(3000);
            driver.Navigate().Refresh();
            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("10% Discount Days")));
            Assert.IsTrue(driver.FindElement(ParaUserDetails(RemainingDays)).Displayed, "10% dicount remaining days is not showing as expected on Harrods.com");
           // Assert.IsTrue(driver.FindElement(ParaUserDetails(BookedDate)).Displayed, "10% dicount booked date is not showing as expected on Harrods.com");
        }

        public void ValidateTenpDay2BookingAndRemainingDays(string RemainingDays, string[] DayYear)
        {
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ParaUserDetails("10% Discount Days")));
            driver.Navigate().Refresh();
            Assert.IsTrue(driver.FindElement(ParaUserDetails(RemainingDays)).Displayed, "10% dicount remaining days is not showing as expected on Harrods.com");
            Assert.IsTrue(driver.FindElement(ParaContainsData(DayYear[0])).Displayed, "10% dicount booked day is not showing as expected on Harrods.com");
            //Assert.IsTrue(driver.FindElement(ParaContainsData(DayYear[1])).Displayed, "10% dicount booked year is not showing as expected on Harrods.com");
        }

        public void Cancel10pDayTwoFromHarrods()
        {
            BrowserDriver.Sleep(5000);
            //WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Account Home")));
            //driver.FindElement(spanHarrodsText("Account Home")).Click();
            driver.FindElement(By.XPath("//span[text()='Account Home']"));
            //WebHandlers.Instance.WebElementExists(TenpBookingCancelbtn);
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.Click(TenpBookingCancelbtn);
            TenpBookingCancelbtn.Click();
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(3000);

        }
        public void CancelAll10pDayFromHarrods()
        {
            BrowserDriver.Sleep(5000);
            
            // Get the initial count of cancel button
            IList<IWebElement> cancelButtons = driver.FindElements(By.Id("discount-days-cancel-button"));
            int count = cancelButtons.Count;

            // Iterate through each cancel button and click it
            for (int i = 0; i < count; i++)
            {
                
                cancelButtons = driver.FindElements(By.Id("discount-days-cancel-button"));

                // Click on the first cancel button in the updated list
                cancelButtons[0].Click();

     
                BrowserDriver.Sleep(7000);
            }

        }


    public void ValidateUserTierDetailsOnHarrodsSite(string CurrentTier)
        {
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(FFCustomersCurrentTierDetails(CurrentTier)).Displayed, "Customer tier details is not showing as expected on Harrods.com");
        }

        public void ValidateUserRewardsPointsOnHarrodsSite(string RewardsPoint)
        {
            BrowserDriver.Sleep(3000);
            Assert.AreEqual(RewardsPoint, WebHandlers.Instance.GetAttribute(FFCustomersRewardsPointsDetails, "innerHTML"), "Harrods.com - Customer rewards points is not showing as expected");
        }

        //TC_222A
        public void ValidateUserRewardsPointsOnHarrodsWebSite(string RewardsPoint)
        {
            BrowserDriver.Sleep(3000);
            double RewardsPoints = Convert.ToDouble(RewardsPoint);
            string formattedRewardsPoint = RewardsPoints.ToString("N0");
            Assert.AreEqual(formattedRewardsPoint, WebHandlers.Instance.GetAttribute(FFCustomersRewardsPointsDetails, "innerHTML"), "Harrods.com - Customer rewards points is not showing as expected");
        }

        #endregion
    }
}
