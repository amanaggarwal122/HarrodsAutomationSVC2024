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
using SeleniumExtras.WaitHelpers;
using TAF_Scripting.Test.Scripted.StepDefinitions;
using TAF_Web.Scripted.Web.BrowserOptions;
using Keys = System.Windows.Forms.Keys;
using OpenQA.Selenium.Support.UI;
//using Examine.Lucene.Search;
using ISearchContext = OpenQA.Selenium.ISearchContext;
using OpenQA.Selenium.Remote;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class CDCUserHomePage
    {
        public IWebDriver driver;
        private Configuration config = null;

        

        #region  Constructor
        public CDCUserHomePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }


        //Page_Objects

        // ShadowDOm Helper Page
        private ShadowDomHelper Shadow_Dom_Helper = null;

        // Create a WebDriverWait instance
        private WebDriverWait wait = null;

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
        [FindsBy(How = How.XPath, Using = "//span[contains(text() , 'Identity Access')]")]
        private IWebElement CDCTry;
        [FindsBy(How = How.XPath, Using = "//app-root/fd-busy-indicator/div/side-nav/div/fd-side-nav/nav/div[1]/ul/li[2]/div/a/span/span")]
        private IWebElement CDCTry2;

        #endregion

        public By SSCNavAdminCustomersTree { get => By.XPath("//span[@title='Customers']"); }
        public By SSCNavAdminSalesTree { get => By.XPath("//span[@title='Sales']"); }
        public By SSCNavAdminCardManagementTree { get => By.XPath("//span[@title='Card Management']"); }
        public By SSCNavAdminServiceTree { get => By.XPath("//span[@title='Service']"); }

        public By ShadowHost1 { get => By.TagName("main-app"); }
        public By ShadowHost2 { get => By.CssSelector("app-root > fd-busy-indicator > div > div > single-app-page > identity-access-app"); }
        public By ShadowHost3 { get => By.CssSelector("ida-user-profile-container > ida-card:nth-child(3) > fd-layout-panel > fd-layout-panel-body > div:nth-child(2) > ul:nth-child(1) > li.card__control.filled-first-column-item.addresses > ida-card-control-host > ida-complex-data-card-control > div > gigya-casting-editor"); }

        public By EmailSearchResult { get => By.CssSelector("div > div > ida-user-list-container > div.ida__user-list-container > ida-user-list > fd-busy-indicator > table > tbody > tr > td.table-cell--name.fd-table__cell > div > a.fd-link > span");}


        #region Events

        public void NavigateToCDCShadowCustomers()
        {

            // CSS Selector HELP
            //1 : CSS: input[name='username']
            //2 : CSS:input[name='login'][type='submit']
            //3 : Next Sibling CSS: #username + input
            //4 : A link with an “id” that starts with the text “id_prefix_” -- > CSS: a[id^='id_prefix_']


            //Object of Selenium Extras

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            //Object of Shadow DOM Helper Class created to call the method
            Shadow_Dom_Helper = new ShadowDomHelper(driver, config);

            BrowserDriver.Sleep(3000);
            var js = (IJavaScriptExecutor)driver;


            //To locate Shadow DOM 1 : 
            var RemoteDriverHost1 = Shadow_Dom_Helper.GetShadowElementForFirstDOM(driver,ShadowHost1);

            //Performing action in DOM1
            var ProfileMenu = RemoteDriverHost1.FindElement(By.CssSelector("nav > div.fd-side-nav__main-navigation > ul > li:nth-child(2) > ul > li:nth-child(1) > a > span"));
            ProfileMenu.Click();


            //Locating DOM 2 ( which is nested DOM) therefore driver will be changed to last DOM remote driver
            var RemoteDriverHost2 = Shadow_Dom_Helper.GetShadowElementForNestedDOM(RemoteDriverHost1, ShadowHost2);

            //Performing action in DOM2
            var EmailSearchBox = RemoteDriverHost2.FindElement(By.CssSelector("ida-user-list-container > div.ida__search-container > ida-search-bar > div > div.search-bar__input > input"));
            EmailSearchBox.SendKeys("auto_scayle_tc_45_user@yopmail.com");
            BrowserDriver.Sleep(500);
            RemoteDriverHost2.FindElement(By.CssSelector("ida-user-list-container > div.ida__search-container > ida-search-bar > div > div.search-bar__buttons--container > button.fd-button.fd-button--emphasized.search-bar__search-button.is-cozy")).Click();
            BrowserDriver.Sleep(2000);

          //  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(EmailSearchResult));
            

            RemoteDriverHost2.FindElement(By.CssSelector("div > div > ida-user-list-container > div.ida__user-list-container > ida-user-list > fd-busy-indicator > table > tbody > tr > td.table-cell--name.fd-table__cell > div > a.fd-link > span")).Click();

            //Locating DOM 3 ( which is nested DOM2) therefore driver will be changed to last DOM remote driver
            var RemoteDriverHost3 = Shadow_Dom_Helper.GetShadowElementForNestedDOM(RemoteDriverHost2, ShadowHost3);

            //Performing action in DOM3
            var AddressExpand = RemoteDriverHost3.FindElement(By.CssSelector("div > div.gigya-editor__main > gigya-casting-editor-row:nth-child(1) > div > div.gigya-editor__cell.gigya-editor__cell--icons > button"));
            WebHandlers.Instance.ClickByJsExecutor(AddressExpand);


           }


       


       

        public void NavigateToSSCCustomers_GroupAccounts()
        {
            Actions actions = new Actions(driver);
            BrowserDriver.Sleep(3000);
            if (SSCNavCustomers_GrpAccount.Displayed)
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
