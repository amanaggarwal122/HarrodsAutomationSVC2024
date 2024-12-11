using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.FF
{
    class FFHarrodsHomePage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public FFHarrodsHomePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion
        #region Elements
        [FindsBy(How = How.XPath, Using = "//span[@data-test='headerAccountMenu-username']")]
        private IWebElement WelcomeMessage;
        [FindsBy(How = How.XPath, Using = "//button[text()='Log Out']")]
        private IWebElement LogOut;
        [FindsBy(How = How.XPath, Using = "//div[@data-test='rewardsTier']/div[1]//span[2]")]
        public IWebElement RewardCardNumber;
        [FindsBy(How = How.XPath, Using = "//div[@data-test='rewardsTier']/div[1]//p")]
        public IWebElement UserTier;
        #endregion

        #region Events
        //Click On Accept Button and Continue

        public void ValidateSuccessfullLogin(Dictionary<string, string> customerdetails)
        {
            string title = customerdetails["Title"];
            string firstName = customerdetails["FirstName"];
            string lastName = customerdetails["LastName"];

            string textToCompare = $"{title.Remove(title.Length - 1, 1) }. {firstName.Trim()} {lastName.Trim()}";
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.VerifyText(WelcomeMessage, textToCompare); //commented until title issue is fixed 07.08.23

        }

        public void logOut()
        {
            WebHandlers.Instance.Click(WelcomeMessage);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(LogOut);
        }

        public void ValidateTierInHarrods(Dictionary<string, string> customerdetails)
        {

            Assert.AreEqual(customerdetails["CardNumber"], RewardCardNumber.Text, "Card No is not as Expected");
            Assert.AreEqual("GOLD TIER", UserTier.Text, "User Tier  is : " + UserTier.Text);

        }
        public string validateDiscountdayBookedCanBeCancelled()
        {
            string bookedDate = null;
            if (driver.FindElements(By.XPath("//button[@id='discount-days-cancel-button']")).Count == 0)
            {
                Assert.Fail("No discount opted for the days");
            }
            else
            {
                string bookedslot = driver.FindElement(By.XPath("//button[@id='discount-days-cancel-button']//parent::div//..//p")).Text;
                string[] Date = bookedslot.Replace("th", "").Split(null);
                int month = DateTime.ParseExact(Date[1], "MMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                bookedDate = Date[0] + "." + month.ToString("00") + "." + DateTime.Now.Year;
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//button[@id='discount-days-cancel-button']")), " clicked on Cancel");

            }

            return bookedDate;
        }
        public void bookDiscountDay(string bookedDate)
        {
            driver.FindElement(By.XPath("(//button[@id='discount-days-select-button'])[1]")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.FindElement(By.XPath("//div[@class='DayPicker-Day' and @aria-label='" + bookedDate + "']")).Click();
            driver.FindElement(By.XPath("//button[@id='schedule-selectDate']")).Click();
            BrowserDriver.Sleep(5000);
        }

        #endregion

    }
}
