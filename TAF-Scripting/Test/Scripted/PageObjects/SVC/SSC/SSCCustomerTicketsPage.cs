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
    class SSCCustomerTicketsPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SSCCustomerTicketsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'button-content')]/bdi[text()='Actions']")]
        private IWebElement SSCTicketsActions;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Generate Summary']")]
        private IWebElement SSCTicketsActionsGenerateSummary;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Open']")]
        private IWebElement SSC_StatusDropdown_TicketOpen;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'--header-arrowScrollRight')]")]
        private IWebElement SSCCustomerTabScrollRight;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle_')][@role='presentation']")]
        private IWebElement SSCNewTicketEditIcon;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Closed']")]
        private IWebElement SSC_StatusDropdown_TicketClosed;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
        private IWebElement SSCNewTicketSave;
        #endregion
        public By SSCCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }
        public By SSCLinkContains(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }
        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SSCNewTicketFields(string FieldLabel) { return By.XPath("(//bdi[text()='" + FieldLabel + "']/following::input)[1]"); }
        public By SSCBdiGridValue(string Text) { return By.XPath("//bdi[text()='" + Text + "']"); }
        public By SpanSSCText(string text) { return By.XPath("//span[text()='" + text + "']"); }
        public void ValidateGhostAccountInSSC(string FullName, string Email)
        {
            //SearchLiteCustomerOnSSC(FullName, Email);

            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, FullName + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData("- -")).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            driver.FindElement(SSCNewTicketSubTabs("Tickets")).Click();
            BrowserDriver.Sleep(2000);

            //Validate ticket created 
            Assert.IsTrue(driver.FindElement(By.XPath("//a[starts-with(@title,'Online Registration:Conflict')]")).Displayed, " Ticket is not created in Ghost Account");
            driver.FindElement(By.XPath("//a[starts-with(@title,'Online Registration:Conflict')]")).Click();
            BrowserDriver.Sleep(2000);

        }

        public void VerifyTicketSummaryCanBeAccessedByTheCustomer(string Condition)
        {
            //Performing summary export
            WebHandlers.Instance.Click(SSCTicketsActions);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(SSCTicketsActionsGenerateSummary);
            WebWaitHelper.Instance.WaitForElement(driver.FindElement(SSCNewTicketFields("Select Form Template")));
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Select Form Template"), "Harrods_Letter");
            driver.FindElement(SSCNewTicketFields("Select Form Template")).SendKeys("Harrods_Letter");
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Select Signature Type"), "Graphical");
            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Select Signature Type")), "Graphical Signature of Agent");
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Generate")));
            //WebHandlers.Instance.Elementnotpresent(driver.FindElement(SSCBdiGridValue("Generate")));
            BrowserDriver.Sleep(3000);

            //Validating generated pdf
            //driver.FindElement(SSCNewTicketSubTabs("Attachments")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.WebElementExists(driver.FindElement(SSCLinkContains(".pdf")));
            Assert.IsTrue(driver.FindElement(SSCLinkContains(".pdf")).Displayed, "Newly generated summary file is not showing on SSC");
        }

        public void ValidateApproversNamesWereAddedOnSSCTicket()
        {
            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
            BrowserDriver.Sleep(1000);
            driver.FindElement(SSCNewTicketSubTabs("Approval")).Click();
            BrowserDriver.Sleep(2000);
            //Assert.IsTrue(driver.FindElement(TableTdText("1 (1 Approver required, 1 pending) (1)")).Displayed, "Approver details not listing on SSC tickets");
        }

        public void ValidateDiningCompensationTicketGetsClosedWithoutAnyApprovals()
        {
            Assert.IsTrue(driver.FindElement(SpanSSCText("Closed")).Displayed, "SSC Ticket status not changed to closed");
        }

        public void ChangeStatusOfSSCTicket(string Status, bool SaveAction = false)
        {
            //Changing ticket status and target tier details
            BrowserDriver.Sleep(4000);
            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
            BrowserDriver.Sleep(2000);
            try
            {
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), Status);

                //Status selection
                if (Status == "Open")
                {
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketOpen.Click();
                    BrowserDriver.Sleep(1000);
                }
                else if (Status == "Closed")
                {
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketClosed.Click();
                    BrowserDriver.Sleep(1000);
                }
                //Status selection
            }
            catch
            {
                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), Status);
                //Status selection
                if (Status == "Open")
                {
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketOpen.Click();
                    BrowserDriver.Sleep(1000);
                }
                else if (Status == "Closed")
                {
                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
                    //SSC_StatusDropdownBtn.Click();
                    BrowserDriver.Sleep(1000);
                    SSC_StatusDropdown_TicketClosed.Click();
                    BrowserDriver.Sleep(1000);
                }
                //Status selection
            }
            if (Status == "Open")
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
            else if (Status == "Solved")
            {
                driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), Status);
            }

            BrowserDriver.Sleep(2000);
            if (SaveAction)
            {
                WebHandlers.Instance.Click(SSCNewTicketSave);
                //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
                BrowserDriver.Sleep(4000);
            }
        }
    }
}
