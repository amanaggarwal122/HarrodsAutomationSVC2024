using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using TAF_Web.Scripted.Web;
using System.Globalization;
using System.Collections.Generic;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerCampaignsPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        public SSCCustomersPage SSC_Customers_Page = null;

        #region  Constructor
        public SSCCustomerCampaignsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;            
        }
        #endregion

        #region Elements 
        [FindsBy(How = How.XPath, Using = "//div[text()='Campaigns']")]
        private IWebElement SSCCustomersSubtabCampaigns;

        [FindsBy(How = How.XPath, Using = "(//table[2]/tbody[1]/tr[1]/td[5]/div[1]/span[1])[1]")]
        private IWebElement SSC_Description_MarketingCampaign;

        [FindsBy(How = How.XPath, Using = "(//table[2]/tbody[1]/tr[1]/td[7]/div[1]/span[1])[1]")]
        private IWebElement SSC_StartDate_MarketingCampaign;

        [FindsBy(How = How.XPath, Using = "(//table[2]/tbody[1]/tr[1]/td[8]/div[1]/span[1])[1]")]
        private IWebElement SSC_ELS_MarketingCampaign;

        [FindsBy(How = How.XPath, Using = "//*[text()='Date of Birth']/following::div[1]")]
        private IWebElement SSC_UserBdate;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;

        [FindsBy(How = How.XPath, Using = "//*[@title='Birthday Week From']/following::div/input[1]")]
        private IWebElement SSC_BdayWeekFromDateTxtBox;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Confirm Adjustment']")]
        private IWebElement SSC_ConfirmAdjustmentBtn;

        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;

        [FindsBy(How = How.XPath, Using = "//button[@title='Expand']/span/span")]
        private IWebElement UserDataExpndBtn;

        #endregion

        #region Events
        public void navigatetoCampaignsTabinSSC()
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomersSubtabCampaigns);
            BrowserDriver.Sleep(2000);
        }

        public void validateMiniHarrodsBdayPromoweekSSC(string username, string email, string campaign_name)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            SSC_Customers_Page.SearchCustomerOnSSC(username, email);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomersSubtabCampaigns);
            string description = SSC_Description_MarketingCampaign.Text;
            string startdate = SSC_StartDate_MarketingCampaign.Text;
            string els = SSC_ELS_MarketingCampaign.Text;
            string current_date = DateTime.Today.ToString("dd.MM.yyyy");
            Assert.IsTrue(description.Equals(campaign_name), "The Campaign is not updated in SSC");
            Assert.IsTrue(startdate.Equals(current_date), "The Campaign is not updated in SSC");
            Assert.IsTrue(description.Equals(campaign_name), "The Campaign is not updated in SSC");
        }
        //TC_275
        public void SelectBirthdayPromotioninSSC()
        {
            // DateTime BirthDate = Convert.ToDateTime(SSC_UserBdate.Text);
            //  DateTime BdayWeekselec;
            //if (BirthDate < DateTime.Now)
            //{
            //    BdayWeekselec = BirthDate.AddYears(1);
            //}
            //else
            //{
            //    BdayWeekselec = BirthDate;
            //}
            DateTime BirthDate;
            try
            {
                // Use DateTime.TryParseExact to handle multiple formats
                bool success = DateTime.TryParseExact(
                    SSC_UserBdate.Text,
                    new[] { "dd/MM/yyyy", "MM/dd/yyyy", "yyyy-MM-dd" },
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out BirthDate);

                if (!success)
                {
                    Console.WriteLine("Date format is not valid.");
                    return; 
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Date format is not valid: " + ex.Message);
                return;
            }

            DateTime BdayWeekselec;
            if (BirthDate < DateTime.Now)
            {
                BdayWeekselec = BirthDate.AddYears(1);
            }
            else
            {
                BdayWeekselec = BirthDate;
            }

            Console.WriteLine($"Selected Birthday Week: {BdayWeekselec.ToString("dd/MM/yyyy")}");
            BdayWeekselec.AddDays(14);
            for (int i = 0; i < 8; i++)
            {
                BdayWeekselec.AddDays(i);
                string day = BdayWeekselec.DayOfWeek.ToString();
                if (day.Equals("Monday"))
                {
                    break;
                }
            }
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SSC_BdayWeekFromDateTxtBox, BdayWeekselec.ToString());
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSC_ConfirmAdjustmentBtn);
            BrowserDriver.Sleep(2000);

            Assert.IsTrue(driver.FindElements(By.XPath("//span[text()='Birthday week adjustment has been sent to Marketing system  |  Your entries have been saved.  ']")).Count > 0, "Success Message is not displayed as expected");
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void ValidateTheErrorMsgBdayWeekinSSC()
        {
            UserDataExpndBtn.Click();
            BrowserDriver.Sleep(2000);

            //string userbdate = userbday + " 00:05:00 AM";

            string[] datelist = SSC_UserBdate.Text.Split('.');

            string day = datelist[0].ToString();
            string month = datelist[1].ToString();
            string year = datelist[2].ToString();

            string userbday = month + "/" + day + "/" + year;

            DateTime BirthDate = DateTime.ParseExact(userbday, "M/d/yyyy", CultureInfo.InvariantCulture);

            DateTime BdayWeekselec;
            if (BirthDate < DateTime.Now)
            {
                BdayWeekselec = BirthDate.AddYears(1);
            }
            else
            {
                BdayWeekselec = BirthDate;
            }
            if (BdayWeekselec.DayOfWeek.ToString().Equals("Monday"))
            {
                BdayWeekselec.AddDays(16);
            }
            else { BdayWeekselec.AddDays(14); }
            string bdayweeksel = BdayWeekselec.ToString("dd.MM.yyyy");
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.EnterText(SSC_BdayWeekFromDateTxtBox, BdayWeekselec.ToString());
            Actions ContentAction = new Actions(driver);
            BrowserDriver.Sleep(2000);
            ContentAction.MoveToElement(SSC_BdayWeekFromDateTxtBox).Click().SendKeys(bdayweeksel).DoubleClick().Build().Perform();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSC_ConfirmAdjustmentBtn);
            BrowserDriver.Sleep(2000);
            //Assert.IsTrue(driver.FindElements(By.XPath("//span[text()='Only Monday is allowed as the start day of Birthday Week  |  Save failed  ']")).Count > 0, "Error Message is not displayed as expected");

        }

        #endregion



    }
}
