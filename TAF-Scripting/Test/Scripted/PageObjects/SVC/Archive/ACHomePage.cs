//using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Interactions;
//using SeleniumExtras.PageObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using TAF_Web.Scripted.Web;
//using TAF_GenericUtility.Scripted.Email;
//using HtmlAgilityPack;
//using TAF_Scripting.Test.Common;

//namespace TAF_Scripting.Test.Scripted.PageObjects.SVC
//{
//    class ACHomePage
//    {
//        public IWebDriver driver;
//        private Configuration config = null;

//        #region  Constructor
//        public ACHomePage(IWebDriver driver, Configuration configuration)
//        {
//            this.driver = driver;
//            PageFactory.InitElements(this.driver, this);
//            config = configuration;
//        }

//        #endregion

//        #region Elements
//        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='searchUserId']")]
//        private IWebElement ACCDCIdSearch;

//        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][text()='Search']")]
//        private IWebElement ACCustomerSearchBtn;

//        [FindsBy(How = How.XPath, Using = "//h4[text()='Current Tier']/../following-sibling::span")]
//        private IWebElement ACCustomerCurrentTierData;

//        [FindsBy(How = How.XPath, Using = "//h4[text()='Available Points']/../following-sibling::span")]
//        private IWebElement ACCustomerRewardsPointsData;
//        public By ACHeaderFiveData(string text) { return By.XPath("//h5[text()='" + text + "']"); }
//        public By ACCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }
//        public By ACLinkTextUnderSpan(string text) { return By.XPath("//a/span[text()='"+ text + "']"); }
//        public By ACSpanText(string text) { return By.XPath("//span[text()='"+ text + "']"); }
        
//        [FindsBy(How = How.Id, Using = "fromdate")]
//        private IWebElement ACCustomerSearchFromDate;
//        [FindsBy(How = How.Id, Using = "todate")]
//        private IWebElement ACCustomerSearchToDate;
//        public By ACCustomerActivityLogValue(string ActivityName) { return By.XPath("//span[text()='"+ ActivityName + "']/../following-sibling::td"); }
//        public By ACCustomerPointsList(string text) { return By.XPath("//span[text()='"+ text + "']/following::i[1]"); }
//        public By ACTableDataTd(string text) { return By.XPath("(//td[text()='"+ text + "'])[1]"); }

//        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='dateFromDate']")]
//        private IWebElement ACCHierArchyFromDate;
//        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='dateToDate']")]
//        private IWebElement ACCHierArchyToDate;
//        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='txtUid']")]
//        private IWebElement ACCHierArchy_GrpID;
//        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='uid']")]
//        private IWebElement ACOrderReportUserIdSearch;
//        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='order_id']")]
//        private IWebElement ACOrderReportOrderIdSearch;
//        [FindsBy(How = How.XPath, Using = "//table[@id='kt_table_memberReport']")]
//        private IWebElement ACOrderReportsTable;
//        [FindsBy(How = How.XPath, Using = "(//th[text()='Purchased Date']/../../parent::table)[1]")]
//        private IWebElement ACPurchaseOrderReportsTable;
//        [FindsBy(How = How.XPath, Using = "(//table[@aria-describedby='kt_table_addStaff_info'])[1]")]
//        private IWebElement ACInteractionReportsTable;
//        [FindsBy(How = How.XPath, Using = "//h5[contains(text(),'Activity : ')]//following::table[1]")]
//        private IWebElement ACInteractionActivityTable;
//        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='idUser']")]
//        private IWebElement ACInteractionReportUserIdSearch;
        
//        public By ACMemberReportFieldValue(string FieldName) { return By.XPath("//span[text()='"+ FieldName + "']/following-sibling::span"); }

//        #endregion

//        #region Events
//        public void VerifyFullReturnForIsShowingOnAC(string CdcId, string Point)
//        {
//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
//            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
//            Assert.AreEqual(Point, driver.FindElement(ACCustomerActivityLogValue("Return")).GetAttribute("innerHTML"), "Entry for point deduction against return product is not showing on AC");
//            BrowserDriver.Sleep(1000);
//        }

//        public void ValidateExpectedPointsIsAddedOnAC(string CdcId, string PointCategory, string ExpPoints)
//        {
//            string CurrPoints = null;
//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-Mar-2021");
//            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);

//            if (PointCategory == "Miscellaneous" || PointCategory == "Rewards Points" || PointCategory == "Extend Points")
//            {
//                WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
//                BrowserDriver.Sleep(4000);
//                WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
//                BrowserDriver.Sleep(4000);
//                CurrPoints = WebHandlers.Instance.GetAttribute(ACCustomerRewardsPointsData, "innerHTML");
//                Assert.AreEqual(ExpPoints, CurrPoints, PointCategory + " Points is not showing as expected on AC");
//            }

//            else if (PointCategory == "Status Points")
//            {
//                WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomerPointsList(CdcId)));
//                BrowserDriver.Sleep(4000);
//                WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomerPointsList(CdcId)));
//                BrowserDriver.Sleep(4000);
//                Assert.IsTrue(driver.FindElement(ACTableDataTd(ExpPoints)).Displayed, PointCategory + " is not showing as expected on AC");
//            }
//        }

//        public void ValidatePurchaseOrderValueinAC(string purchasevalue, string acorderid)
//        {
//            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, acorderid);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);            
//            BrowserDriver.Sleep(8000);
//            string totalnetprice = driver.FindElement(By.XPath("//th[text()='Total Net Price']/following::td[4]")).Text;
//            Assert.IsTrue(totalnetprice.Equals(purchasevalue), "The Purchase amount is not matching with the value displayed in AC");
//        }

//        public void ValidateACUserTierGetsUpgradedTo(string CdcId, string ExpTier, string ExpPoints)
//        {
//            string CurrPoints = null;
//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-Mar-2021");
//            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
//            BrowserDriver.Sleep(4000);
//            CurrPoints = WebHandlers.Instance.GetAttribute(ACCustomerRewardsPointsData, "innerHTML");
//            Assert.AreEqual(ExpTier, WebHandlers.Instance.GetAttribute(ACCustomerCurrentTierData, "innerHTML"), "AC - Customer tier details is not showing as expected");
//        }

//        public void VerifyGroupAccountDeactivated(string GroupAccount)
//        {
//            WebHandlers.Instance.EnterText(ACCHierArchyFromDate, DateTime.Now.AddDays(-30).ToString("dd-MMM-yyyy"));
//            WebHandlers.Instance.EnterText(ACCHierArchyToDate, DateTime.Now.ToString("dd-MMM-yyyy"));
//            WebHandlers.Instance.EnterText(ACCHierArchy_GrpID, GroupAccount);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            BrowserDriver.Sleep(4000);
//            Assert.AreEqual(0, driver.FindElements(ACCustomersGridData(GroupAccount)).Count, GroupAccount + " not showing as deactivated on AC");
//        }

//        public void VerifyNoRewardsPointsAddedForRedeemCashRewards(string CdcId, string OrderId)
//        {
//            //OrderId = OrderId.Replace('"', ' ').Trim();
//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
//            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
//            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
//            BrowserDriver.Sleep(4000);

//            Assert.AreNotEqual("-", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Redeemed"), "Annex cloud - Points redeemed is showing as null");
//            Assert.AreEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Earned"), "Annex cloud - Points earned is not showing as 0");
//            BrowserDriver.Sleep(1000);
//        }

//        public string FetchTableCellDataFromAC(IWebElement Table, string RowItem, string ColumnItem)
//        {
//            int ColumnIndex = 0;
//            int RowIndex = 0;
//            IList<IWebElement> Rows = Table.FindElements(By.TagName("tr"));
//            IList<IWebElement> Columns = Table.FindElements(By.TagName("th"));

//            for (int i=0; i< Columns.Count; i++)
//            {
//                if(Columns[i].GetAttribute("innerHTML")== ColumnItem)
//                {
//                    ColumnIndex = i+1;
//                    break;
//                }
//            }

//            for (int j = 0; j < Rows.Count; j++)
//            {
//                if (Rows[j].GetAttribute("innerHTML").Contains(RowItem))
//                {
//                    RowIndex = j;
//                    break;
//                }
//            }

//            string item = Table.FindElement(By.XPath("//following-sibling::tr["+RowIndex+ "]/td[" + ColumnIndex + "]")).GetAttribute("innerHTML");
//            return item;
//        }

//        public void VerifyCancelOrderDataShowingOnACOrderDetails(string CdcId, string OrderId)
//        {
//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
//            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
//            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(driver.FindElement(ACLinkTextUnderSpan(OrderId)));
//            WebWaitHelper.Instance.WaitForPresence(ACSpanText(OrderId), TimeSpan.FromSeconds(120));
//            BrowserDriver.Sleep(5000);

//            Assert.AreEqual("1.00", FetchTableCellDataFromAC(ACPurchaseOrderReportsTable, OrderId, "Cancelled"), "Annex cloud - Cancelled order data is not showing");
//            BrowserDriver.Sleep(1000);
//        }

//        public void VerifyRetrospectiveEntryOnACOrderDetails(string CdcId, string OrderId)
//        {
//            OrderId = OrderId.Replace('"', ' ').Trim();
//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
//            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
//            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
//            BrowserDriver.Sleep(4000);

//            Assert.AreNotEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Earned"), "Annex cloud - Retrospective points earned is not showing expected");
//            BrowserDriver.Sleep(1000);
//        }

//        public void VerifyBaseRewardsPointsEntryOnACOrderDetails(string CdcId, string OrderId)
//        {
//            OrderId = OrderId.Replace('"', ' ').Trim();
//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
//            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
//            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
//            BrowserDriver.Sleep(4000);
//            Assert.AreNotEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Earned"), "Annex cloud - Base rewards points earned is not showing expected");
//            Assert.AreEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Redeemed"), "Annex cloud - redeemed points earned is not showing expected");
//            BrowserDriver.Sleep(1000);

//            WebHandlers.Instance.Click(driver.FindElement(ACLinkTextUnderSpan(OrderId)));
//            WebWaitHelper.Instance.WaitForPresence(ACSpanText(OrderId), TimeSpan.FromSeconds(120));
//            BrowserDriver.Sleep(5000);
//            Assert.AreEqual("1.00", FetchTableCellDataFromAC(ACPurchaseOrderReportsTable, OrderId, "Shipped"), "Annex cloud - Shipped order data is not showing as expected");
//            Assert.AreEqual("0.00", FetchTableCellDataFromAC(ACPurchaseOrderReportsTable, OrderId, "Cancelled"), "Annex cloud - Cancelled order data is not showing as expected");
//            Assert.AreEqual("0.00", FetchTableCellDataFromAC(ACPurchaseOrderReportsTable, OrderId, "Returned"), "Annex cloud - Returned order data is not showing as expected");
//        }

//        public void VerifyOnlineRewardsPointsEntryOnACOrderDetails(string CdcId, string OrderId, string DateRange)
//        {
//            OrderId = OrderId.Replace('"', ' ').Trim();
//            String[] DateMonth = DateRange.Split('-');

//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, DateMonth[0]); 
//            WebHandlers.Instance.EnterText(ACCustomerSearchToDate, DateMonth[1]); 
//            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
//            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
//            BrowserDriver.Sleep(4000);
//            Assert.AreNotEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Earned"), "Annex cloud - Status rewards points earned is not showing expected");
//            Assert.AreEqual("Online", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "channel"), "Annex cloud - channel details is not showing expected");
//        }

//        public void VerifyCurrencyInteractionTypeBonusOnAC(string CdcId, string DateRange)
//        {
//            String[] DateMonth = DateRange.Split('-');

//            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, DateMonth[0]);
//            WebHandlers.Instance.EnterText(ACCustomerSearchToDate, DateMonth[1]);
//            WebHandlers.Instance.EnterText(ACInteractionReportUserIdSearch, CdcId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(ACCustomersGridData(CdcId)));
//            BrowserDriver.Sleep(4000);
//            Assert.IsTrue(FetchTableCellDataFromAC(ACInteractionReportsTable, CdcId, "Actions").Contains("FOREX Currency Exchange"), "Annex cloud - action details is not showing expected");
//            Assert.AreNotEqual("-", FetchTableCellDataFromAC(ACInteractionReportsTable, CdcId, "Points"), "Annex cloud - points earned is not showing expected");
//            BrowserDriver.Sleep(1000);

//            WebHandlers.Instance.Click(driver.FindElement(ACCustomersGridData(CdcId)));
//            WebWaitHelper.Instance.WaitForPresence(ACHeaderFiveData("Activity : "+ CdcId + " "), TimeSpan.FromSeconds(120));
//            BrowserDriver.Sleep(5000);
//            Assert.AreNotEqual("-", FetchTableCellDataFromAC(ACInteractionActivityTable, "FOREX Currency Exchange", "Points"), "Annex cloud - currency exchange points details is not showing as expected");
//        }

//        public void ValidateObsoleteCustomersWereShowingAsInactiveOnAC(string CdcId)
//        {
//            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
//            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
//            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
//            BrowserDriver.Sleep(4000);
//            Assert.AreEqual("Inactive",driver.FindElement(ACMemberReportFieldValue("Status:")).GetAttribute("innerText") , "AC - Obsolete customer status is not showing as inactive");
//        }

//        #endregion

//    }
//}
