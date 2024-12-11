using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerPurchasesPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private CommonFunctions Common_Functions = null;

        #region  Constructor
        public SSCCustomerPurchasesPage(IWebDriver driver, Configuration configuration)
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
        [FindsBy(How = How.XPath, Using = "//*[text()='ID']/following::table/tbody/tr/td/div/a")]
        private IWebElement SSCPurchaseOrderID_Grid;
        [FindsBy(How = How.XPath, Using = "//div[text()='Products']")]
        private IWebElement SSCPurchaseOrder_ProductTab;
        public By SSCCustomersGridData(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }
        #endregion
        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SpanSSCTextFirst(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }
        public By SSCCustomersPurchaseGridData(string orderId) { return By.XPath("//span[text()='" + orderId + "']"); }
        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }
        #region Events
        public void ValidatePurchaseActivityShowingOnSSC(string ActivityType, string SearchItem = null)
        {
            Common_Functions = new CommonFunctions();
            WebHandlers.Instance.WebElementExists(driver.FindElement(SSCNewTicketSubTabs("Purchases")));
            BrowserDriver.Sleep(4000);
            driver.FindElement(SSCNewTicketSubTabs("Purchases")).Click();
            BrowserDriver.Sleep(3000);

            string subjectString = driver.FindElement(By.XPath("//*[contains(@id,'paginator-pageInfo-bdi')]")).Text;
            string pagination = Common_Functions.GetNumbers(subjectString);
            int p = Int32.Parse(pagination);

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    IWebElement pointexpiry = driver.FindElement(SpanSSCTextFirst(ActivityType));
                    string point = pointexpiry.Text;
                    if (point.Equals(ActivityType))
                    {
                        break;
                    }

                }
                catch { driver.FindElement(By.XPath("//*[@role='button'][contains(@id,'paginator-nextPage')]")).Click(); }
            }


            Assert.IsTrue(driver.FindElement(SpanSSCTextFirst(ActivityType)).Displayed, ActivityType + " purchase activity against user is not showing on SSC");
        }

        public void PurchaseOrderSearch(string PurchaseOrderNo)
        {
            BrowserDriver.Sleep(2000);
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, PurchaseOrderNo + "\n");
            BrowserDriver.Sleep(2000);
            driver.FindElement(By.XPath("//*[text()='No results found. Search again in all items?']")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCPurchaseOrderID_Grid);
        }

        public void ValidatePurchaseValue(string PurchaseValue)
        {
            BrowserDriver.Sleep(4000);
            //WebHandlers.Instance.Click(SSCPurchaseOrder_ProductTab);
            BrowserDriver.Sleep(2000);
            SSCPurchaseOrder_ProductTab.Click();
            BrowserDriver.Sleep(2000);
            string saleprice = driver.FindElement(By.XPath("(//bdi[text()='Net Price']/following::span[12])[2]")).Text;
            Console.WriteLine("displayed sale price" + saleprice);
            Console.WriteLine("actual sale price" + PurchaseValue);
            Assert.IsTrue(saleprice.Equals(PurchaseValue), "The Purchase value isnt matching. Free Delivery is not applied to order");
        }

        public void VerifyUsersOrderDetailsWereListingOnSSC(string UserName, string Email, string OrderId)
        {
            string FullName = UserName + " " + UserName + "Lname";
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            driver.FindElement(SSCNewTicketSubTabs("Purchases")).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);
            Assert.IsTrue(driver.FindElement(SSCCustomersPurchaseGridData(OrderId)).Displayed, "SSC not listing expected order id for the user");
            driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
            BrowserDriver.Sleep();
        }

        #endregion
    }

}
