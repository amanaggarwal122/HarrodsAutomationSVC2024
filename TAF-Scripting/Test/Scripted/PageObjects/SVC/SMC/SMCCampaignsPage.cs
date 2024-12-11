using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using TAF_Web.Scripted.Web;
using System.Collections.ObjectModel;
using System;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SMC
{
    class SMCCampaignsPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SMCCampaignsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        [FindsBy(How = How.XPath, Using = "//button//bdi[text()='Target Group']")]
        private IWebElement SMCTargetGroupMenu;
        [FindsBy(How = How.XPath, Using = "//a[text()='Mini Harrods birthday week adhoc segment ']")]
        private IWebElement SMCMiniHarrodsBdayLink;
        [FindsBy(How = How.XPath, Using = "//div[@class='sapHpaGsegLibGridFormCellContent']/following::a[text()='Mini Harrods birthday week adhoc segment']")]
        private IWebElement SMCMiniHarrodsBdaySegmentLink;
        [FindsBy(How = How.XPath, Using = "(//*[text()='INSERT EMAIL']/following::button[@title='Click to open or close the segment action menu'])[1]")]
        private IWebElement SMCSegmentActionMenu;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapUiMnuItmTxt'][text()='Change Segment']")]
        private IWebElement SMC_SAPMenu_ChangeSegment;
        [FindsBy(How = How.XPath, Using = "//*[text()='Value:']/following::input[1]")]
        private IWebElement SMC_SAPMenu_ChangeSegment_Emailbox;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Harrods: Contact Based Segmentation'])[2]")]
        private IWebElement SMC_SAPMenu_ContactBasedSegmentation;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Campaigns']")]
        private IWebElement SMC_SubMenuCampaigns;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Overview']")]
        private IWebElement SMC_SubMenuOverview;
        [FindsBy(How = How.XPath, Using = "(//div[@class='sapUiTableCellInner']/*[contains(text(),'Mini Harrods birthday week adhoc Camp')])[1]")]
        private IWebElement SMC_AdhocCampaign_TABLELink;
        #endregion

        #region Events
        public void SearchAdhocCampaignandOpenLatestSMC()
        {

            driver.FindElement(By.XPath("//*[contains(text(),'Campaigns (')]")).Click();
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.EnterText(SMCCampaignSearchBox, "Adhoc");
            //Actions a = new Actions(driver);
            //a.MoveToElement(SMCCampaignSearchBox).Click().SendKeys("Adhoc").Click().Build().Perform();
            //SMCCampaignSearchBox.SendKeys("Adhoc");
            driver.FindElement(By.XPath("//bdi[text()='Create']/preceding::input[1]")).SendKeys("Adhoc");
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.Click(SMCSearchButton);
            //clicking the first element in the table grid
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[1]/div[3]/a[1]")));

        }

        public void SelectMiniHarrodsBdayWeekAdhocSMC()
        {
            BrowserDriver.Sleep(3000);
            SMCTargetGroupMenu.Click();
            BrowserDriver.Sleep(3000);
            SMCMiniHarrodsBdayLink.Click();
            BrowserDriver.Sleep(3000);
            SMCMiniHarrodsBdaySegmentLink.Click();
            BrowserDriver.Sleep(3000);
        }

        public void InsertEmailinSegmentAndExecuteSMC(string Email)
        {
            ReadOnlyCollection<string> window_handles = driver.WindowHandles;

            string current_tabwindow = driver.CurrentWindowHandle;
            Console.WriteLine("list of pages ==>" + current_tabwindow);
            foreach (string handle in window_handles)
            {
                if (!handle.Equals(current_tabwindow))

                {
                    driver.SwitchTo().Window(handle);
                }
            }
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SMCSegmentActionMenu);
            BrowserDriver.Sleep(2000);
            //Boolean changesegmentdisplay = SMC_SAPMenu_ChangeSegment.Displayed;
            //if (changesegmentdisplay)
            //{
            WebHandlers.Instance.Click(SMC_SAPMenu_ChangeSegment);
            SMC_SAPMenu_ChangeSegment_Emailbox.Clear();
            BrowserDriver.Sleep(2000);
            SMC_SAPMenu_ChangeSegment_Emailbox.SendKeys(Email);
            //WebHandlers.Instance.EnterText(SMC_SAPMenu_ChangeSegment_Emailbox, Email);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//button[text()='Keep']")));
            ReadOnlyCollection<string> handles = driver.WindowHandles;
            string currenttab = driver.CurrentWindowHandle;
            foreach (string handle in handles)
            {
                if (!handle.Equals(currenttab))
                {
                    driver.SwitchTo().Window(handle);
                }
            }
            BrowserDriver.Sleep(3000);
            // }
        }

        public string CopyandCreateCampaignSMC()
        {
            WebHandlers.Instance.Click(SMC_SAPMenu_ContactBasedSegmentation);
            BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Rebuild']")));
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SMC_SubMenuCampaigns);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SMC_AdhocCampaign_TABLELink);
            BrowserDriver.PageWait();
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Copy']")));
            BrowserDriver.Sleep(6000);
            //string campaign_exist = driver.FindElement(By.XPath("//bdi[text()='Campaign Name']/following::input[1]")).Text;
            //int number = Int32.Parse(campaign_exist) + 1;
            //string campaign_new = "Mini Harrods birthday week adhoc Camp" + number.ToString();
            //WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("//bdi[text()='Campaign Name']/following::input[1]")), campaign_new);

            // Find the input element and retrieve its current value
            string campaign_exist = driver.FindElement(By.XPath("//bdi[text()='Campaign Name']/following::input[1]")).GetAttribute("value");

            // Try to parse the current value to an integer, if it is numeric
            int number;
            if (Int32.TryParse(campaign_exist, out number))
            {
                // Increment the number by 1
                number += 1;
            }
            else
            {
                // Handle the case where the current value is not a number, if necessary
                number = 1; // or any default value
            }

            // Create the new campaign name
            string campaign_new = "Mini Harrods birthday week adhoc Camp " + number.ToString();

            // Enter the new campaign name back into the input field
            driver.FindElement(By.XPath("//bdi[text()='Campaign Name']/following::input[1]")).Clear();  // Clear the field first
            driver.FindElement(By.XPath("//bdi[text()='Campaign Name']/following::input[1]")).SendKeys(campaign_new);


            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Create']")));
            BrowserDriver.Sleep(6000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Done']")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Start']")));
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Yes']")));
            BrowserDriver.Sleep(6000);
            return campaign_new;
        }

        public void ValidatewhetherEMailsdeliveredSMC()
        {
            WebHandlers.Instance.Click(SMC_SubMenuOverview);
            driver.Navigate().Refresh();
            Boolean campaignstatus = driver.FindElement(By.XPath("//span[text()='Finished']")).Displayed;
            if (campaignstatus)
            {
                Boolean email_delivery = driver.FindElement(By.XPath("//*[@stroke='#ffffff']")).Displayed;
                Assert.IsTrue(email_delivery, "Emails are not delivered properly");
            }
            else
            {
                driver.Navigate().Refresh();
                BrowserDriver.PageWait();
                Boolean email_delivery = driver.FindElement(By.XPath("//*[@stroke='#ffffff']")).Displayed;
                Assert.IsTrue(email_delivery, "Emails are not delivered properly");
            }
        }

        #endregion
    }
}
