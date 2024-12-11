using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;
using Renci.SshNet;
using System.IO;
using TAF_Scripting.Test.Scripted.PageObjects.SVC;
using System.Globalization;
using Keys = OpenQA.Selenium.Keys;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCGroupAccountsPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region Constructor
        public SSCGroupAccountsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }
        #endregion

        #region Elements 

        [FindsBy(How = How.XPath, Using = "//div[@id='__title0']/span[text()='Group Accounts / Companies']")]
        private IWebElement SSCGroupAccountHeader;

        [FindsBy(How = How.XPath, Using = "//button[@title='Create']")]
        private IWebElement SSCTicketCreateBtn;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Name']/following::input)[1]")]
        private IWebElement SSC_GroupAccountName_Txt;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Primary Member']/following::input)[1]")]
        private IWebElement SSC_PrimaryMember_Txt;

        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;

        [FindsBy(How = How.XPath, Using = "(//*[text()='Save'])")]
        private IWebElement SSCGroupSaveButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='SSC Account ID']/following::div/span)[1]")]
        private IWebElement SSC_GetTestgroupid;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-variantManagement-trigger-img')]")]
        private IWebElement SSCGroupAccountItemViewFilter;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Actions']")]
        private IWebElement SSCDetailsGridActions;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
        private IWebElement SSCEditCustomerSavebtn;

        #endregion
        public By SSCListItem(string Item) { return By.XPath("//li[text()='" + Item + "']"); }
        public By SSCCustomersGridData(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }
        public By SSCBdiGridValue(string Text) { return By.XPath("//bdi[text()='" + Text + "']"); }
        public By SSCNewTicketFields(string FieldLabel) { return By.XPath("(//bdi[text()='" + FieldLabel + "']/following::input)[1]"); }
        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }
        #region Events

        //TC_224
        public string SSCGroupAccountCreation(string groupaccountname, string primarymember)
        {
            BrowserDriver.Sleep(25000);
            WebWaitHelper.Instance.WaitForElementPresence(SSCGroupAccountHeader);
            BrowserDriver.Sleep(9000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            BrowserDriver.Sleep(5000);

            SSC_GroupAccountName_Txt.SendKeys(groupaccountname);
            BrowserDriver.Sleep(3000);
            SSC_PrimaryMember_Txt.SendKeys(primarymember + Keys.Enter);
            //WebHandlers.Instance.EnterText(SSC_PrimaryMember_Txt, primarymember);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCGroupSaveButton);
            BrowserDriver.Sleep(55000);
            //string Groupid = driver.FindElement(By.XPath("//bdi[text()='AC Group ID']//following::span[1]")).Text;
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, groupaccountname + "\n");
            BrowserDriver.Sleep(3000);
            int searcherror = driver.FindElements(By.XPath("//*[text()='No results found. Search again in all items?']")).Count();
            if (searcherror > 0)
            {
                driver.FindElement(By.XPath("//*[text()='No results found. Search again in all items?']")).Click();
            }
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCCustomersGridData(groupaccountname)).Click();
            //BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
            string Groupid = driver.FindElement(By.XPath("//bdi[text()='AC Group ID']//following::span[1]")).Text;
            return Groupid;


            BrowserDriver.Sleep(55000);
            
        }

        public void SSCGroupAccountCreation(string groupaccountname)
        {
            WebWaitHelper.Instance.WaitForElementPresence(SSCGroupAccountHeader);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.EnterText(SSC_GroupAccountName_Txt, groupaccountname);
            SSC_GroupAccountName_Txt.SendKeys(groupaccountname);
            //WebHandlers.Instance.EnterText(SSC_PrimaryMember_Txt, primarymember);
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void SearchGroupOnSSC(string Testgroupname)
        {
            // string FullName = UserName + " " + UserName + "Lname";

            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Testgroupname + "\n");
            BrowserDriver.Sleep(3000);
            int searcherror = driver.FindElements(By.XPath("//*[text()='No results found. Search again in all items?']")).Count();
            if (searcherror > 0)
            {
                driver.FindElement(By.XPath("//*[text()='No results found. Search again in all items?']")).Click();
            }
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCCustomersGridData(Testgroupname)).Click();
            //BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
        }

        public void SearchforTestGroup(string testgroupname)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomersSearchIcon);
            SearchGroupOnSSC(testgroupname);
        }

        public string GetGroupID()
        {
            string groupid = WebHandlers.Instance.GetTextOfElement(SSC_GetTestgroupid);
            return groupid;
        }

        public void VerifyGroupAccountDeactivated(string GroupAccount)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, GroupAccount + "\n");
            BrowserDriver.Sleep(4000);
            Assert.AreEqual(0, driver.FindElements(SSCCustomersGridData(GroupAccount)).Count, GroupAccount + " not showing as deactivated on SSC");
        }

        public void ActivateOrDeactivateGroupAccount(string Action, string GroupAccount)
        {
            //Filtering to All accounts
            WebHandlers.Instance.Click(SSCGroupAccountItemViewFilter);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(driver.FindElement(SSCListItem("All")));
            BrowserDriver.Sleep(6000);

            //Editing given account
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, GroupAccount + "\n");
            BrowserDriver.Sleep(4000);
            driver.FindElement(SSCCustomersGridData(GroupAccount)).Click();
            WebHandlers.Instance.WebElementExists(SSCDetailsGridActions);
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(SSCDetailsGridActions);
            BrowserDriver.Sleep(2000);
            if (Action == "Activate")
                WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Set as Active")));
            
            else if (Action == "DeActivate")
                WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Set as Obsolete")));

            BrowserDriver.Sleep(6000);
            driver.FindElement(SSCCustomersSubtabClose(GroupAccount)).Click();
            BrowserDriver.Sleep(5000);
        }

        public void CreateGroupAccountFromSSC(string GroupAccount, string PrimaryMember)
        {
            //Creating new group account
            WebWaitHelper.Instance.WaitForElementPresence(SSCGroupAccountHeader);
            BrowserDriver.Sleep(3000);
            WebWaitHelper.Instance.WaitForElementPresence(SSCTicketCreateBtn);
            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Name"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Name")), GroupAccount);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Primary Member")), PrimaryMember);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Name")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCEditCustomerSavebtn);
            WebHandlers.Instance.Elementnotpresent(SSCEditCustomerSavebtn);
            BrowserDriver.Sleep(5000);
        }

        #endregion
    }
}
