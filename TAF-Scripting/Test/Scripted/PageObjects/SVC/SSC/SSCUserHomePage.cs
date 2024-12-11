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

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCUserHomePage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SSCUserHomePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements        

        [FindsBy(How = How.XPath, Using = "//a[@title='Customers']")]
        private IWebElement SSCNavCustomers;
        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Group Accounts')]")]
        private IWebElement SSCNavCustomers_GrpAccount;
        [FindsBy(How = How.XPath, Using = "//a[@title='Purchases']")]
        private IWebElement SSCNavSales_Purchases;
        [FindsBy(How = How.XPath, Using = "//div[text()='Purchases']")]
        private IWebElement SSCustomer_Purchases;
        [FindsBy(How = How.XPath, Using = "//a[@title='Replenishment']")]
        private IWebElement SSCNavReplenishment;
        [FindsBy(How = How.XPath, Using = "//a[@title='Tickets']")]
        private IWebElement SSCNavTickets;
        [FindsBy(How = How.XPath, Using = "//span[text()='My Tickets']")]
        private IWebElement SSCMyTicketsHeader;
        [FindsBy(How = How.XPath, Using = "//a[@title='Customer Merge']")]
        private IWebElement SSCNavCustomerMerge;

        #endregion

        public By SSCNavAdminCustomersTree { get => By.XPath("//span[@title='Customers']"); }
        public By SSCNavAdminSalesTree { get => By.XPath("//span[@title='Sales']"); }
        public By SSCNavAdminCardManagementTree { get => By.XPath("//span[@title='Card Management']"); }
        public By SSCNavAdminServiceTree { get => By.XPath("//span[@title='Service']"); }

        #region Events

        public void NavigateToSSCCustomers()
        {
            BrowserDriver.Sleep(3000);
            if (driver.FindElements(SSCNavAdminCustomersTree).Count != 0)
            {
                driver.FindElement(SSCNavAdminCustomersTree).Click();
            }
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
            WebHandlers.Instance.Click(SSCNavCustomers);
            //try { WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSearchIcon); }
            //catch { WebHandlers.Instance.Click(SSCNavCustomers); }
            BrowserDriver.Sleep(4000);
        }

        public void NavigateToSSCCustomers_GroupAccounts()
        {
            Actions actions = new Actions(driver);
            BrowserDriver.Sleep(3000);
            if(SSCNavCustomers_GrpAccount.Displayed)
            {
                actions.MoveToElement(SSCNavCustomers_GrpAccount).Click().Build().Perform();
                BrowserDriver.Sleep(2000);
                SSCNavCustomers_GrpAccount.Click();
            }
            else
            {
                driver.FindElement(SSCNavAdminCustomersTree).Click();
                BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers_GrpAccount);
                actions.MoveToElement(SSCNavCustomers_GrpAccount).Click().Build().Perform();
                BrowserDriver.Sleep(2000);
                SSCNavCustomers_GrpAccount.Click();
            }
            
            
        }

        public void NavigateToSSCSales_Purchases()
        {
            driver.FindElement(SSCNavAdminSalesTree).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(SSCNavSales_Purchases);
            BrowserDriver.Sleep(2000);
        }
        //TC_253
        public void NavigateToSSCCustomerSales_Purchases()
        {
            //BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.Click(SSCustomer_Purchases);
            BrowserDriver.Sleep(2000);
            driver.FindElement(By.XPath("//div[text()='Purchases']")).Click();
            BrowserDriver.Sleep(2000);
            driver.FindElement(By.XPath("//*[@title='ID']//following::a[1]")).Click();
            BrowserDriver.Sleep(2000);
        }

        public void NavigateToSSCCardManagement()
        {
            if (driver.FindElements(SSCNavAdminCardManagementTree).Count != 0)
            {
                //driver.FindElement(SSCNavAdminCardManagementTree).Click();
                WebHandlers.Instance.ClickByJsExecutor(SSCNavAdminCardManagementTree);
            }
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.ClickByJsExecutor(SSCNavScheduleCardCreation);           

        }

        public void NavigateToSSCReplenishment()
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.ClickByJsExecutor(SSCNavReplenishment);

        }

        public void NavigateToSSC_Service()
        {
            if (driver.FindElements(SSCNavAdminServiceTree).Count != 0)
            {
                driver.FindElement(SSCNavAdminServiceTree).Click();

            }
            BrowserDriver.Sleep(2000);
        }

        public void NavigateToSSC_Service_To_Ticket()
        {
            //driver.FindElement(SSC_Nav_Tickets).Click();
            BrowserDriver.Sleep(5000);
            WebWaitHelper.Instance.WaitForElementPresence(SSCNavTickets);
            WebHandlers.Instance.ClickByJsExecutor(SSCNavTickets);
            BrowserDriver.Sleep(3000);
        }

        public void NavigateToSSCTickets()
        {
            BrowserDriver.Sleep(3000);
            if (driver.FindElements(SSCNavAdminServiceTree).Count != 0)
            {
                driver.FindElement(SSCNavAdminServiceTree).Click();
            }
            BrowserDriver.Sleep(5000);
            WebWaitHelper.Instance.WaitForElementPresence(SSCNavTickets);
            WebHandlers.Instance.ClickByJsExecutor(SSCNavTickets);
            try { WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader); }
            catch { WebHandlers.Instance.Click(SSCNavTickets); }
            BrowserDriver.Sleep(5000);
        }

        public void NavigateToSSCCustomerMerge()
        {
            BrowserDriver.Sleep(5000);
            //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomerMerge);
            SSCNavCustomerMerge.Click();
            //BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
        }

        #endregion
    }
}
