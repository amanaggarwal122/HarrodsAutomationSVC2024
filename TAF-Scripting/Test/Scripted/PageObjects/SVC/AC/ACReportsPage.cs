using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.AC
{
    class ACReportsPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public ACReportsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }
        #endregion
        #region Elements

        [FindsBy(How = How.XPath, Using = "//h4[text()='Current Tier']/../following-sibling::span")]
        private IWebElement ACCustomerCurrentTierData;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='searchUserId']")]
        private IWebElement ACCDCIdSearch;
        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][text()='Search']")]
        private IWebElement ACCustomerSearchBtn;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Available Points']/../following-sibling::span")]
        private IWebElement ACCustomerRewardsPointsData;
        [FindsBy(How = How.Id, Using = "fromdate")]
        private IWebElement ACCustomerSearchFromDate;
        [FindsBy(How = How.Id, Using = "todate")]
        private IWebElement ACCustomerSearchToDate;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='dateFromDate']")]
        private IWebElement ACCHierArchyFromDate;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='dateToDate']")]
        private IWebElement ACCHierArchyToDate;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='txtGroupid']")]
        private IWebElement ACCHierArchy_GrpID;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='uid']")]
        private IWebElement ACOrderReportUserIdSearch;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='order_id']")]
        private IWebElement ACOrderReportOrderIdSearch;
        [FindsBy(How = How.XPath, Using = "//table[@id='kt_table_memberReport']")]
        private IWebElement ACOrderReportsTable;
        [FindsBy(How = How.XPath, Using = "(//th[text()='Purchased Date']/../../parent::table)[1]")]
        private IWebElement ACPurchaseOrderReportsTable;
        [FindsBy(How = How.XPath, Using = "(//table[@aria-describedby='kt_table_addStaff_info'])[1]")]
        private IWebElement ACInteractionReportsTable;
        [FindsBy(How = How.XPath, Using = "//h5[contains(text(),'Activity : ')]//following::table[1]")]
        private IWebElement ACInteractionActivityTable;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='idUser']")]
        private IWebElement ACInteractionReportUserIdSearch;

        [FindsBy(How = How.XPath, Using = "//span[text()='Reports']")]
        private IWebElement ACNavReports;

        [FindsBy(How = How.XPath, Using = "//div[text()='Member']/..//a[text()='GO']")]
        private IWebElement ACNavReportsMember;

        [FindsBy(How = How.XPath, Using = "//div[text()='Hierarchy Management']/..//a[text()='GO']")]
        private IWebElement ACNavReportsHierarchyManagement;

        [FindsBy(How = How.XPath, Using = "//div[text()='All Interaction']/..//a[text()='GO']")]
        private IWebElement ACNavReportsAllInteraction;

        [FindsBy(How = How.XPath, Using = "//div[text()='Points']/..//a[text()='GO']")]
        private IWebElement ACNavPointMember;

        [FindsBy(How = How.XPath, Using = "//div[text()='Points']/..//a[text()='GO']")]
        private IWebElement ACNavReportsPoints;

        [FindsBy(How = How.XPath, Using = "//div[text()='Order']/..//a[text()='GO']")]
        private IWebElement ACNavReportsOrder;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='uid']")]
        private IWebElement ACOrderCDCIdSearch;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='User Id']")]
        private IWebElement ACUserSearch;



        #endregion
        public By ACOrdersIdGridData(string cdcId) { return By.XPath("(//span[text()='" + cdcId + "']/../../following-sibling::td/a)[1]"); }
        public By ACLinkTextUnderSpan(string text) { return By.XPath("//a/span[text()='" + text + "']"); }
        public By ACCustomerActivityLogValue(string ActivityName) { return By.XPath("(//span[text()='"+ActivityName+"']/../following-sibling::td)[1]/span"); }
        public By ACCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }
        public By ACCustomerPointsList(string text) { return By.XPath("//span[text()='" + text + "']/following::i[1]"); }
        public By ACTableDataTd(string text) { return By.XPath("(//td[text()='" + text + "'])[1]"); }
        public By ACTableDatadetails(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }
        public By ACTableDatadetailss(string text) { return By.XPath("(//*[text()='" + text + "'])[1]"); }
        public By ACMemberReportFieldValue(string FieldName) { return By.XPath("//span[text()='" + FieldName + "']/following-sibling::span"); }
        public By ACHeaderFiveData(string text) { return By.XPath("//h5[text()='" + text + "']"); }
        public By ACSpanText(string text) { return By.XPath("//span[text()='" + text + "']"); }
        public By ACOrdersGridData(string cdcId) { return By.XPath("//span[text()='" + cdcId + "']"); }
        public By Total_Members(string text) { return By.XPath("//th[text()='Total Members']//following::td[4]"); }

        public By ACCustomerEarnedPoints(string cdcId) { return By.XPath("//span[text()='" + cdcId + "']//..//..//following-sibling::td[4]//span"); }
        #region Events

        public void NavigateToACReportsMemberReports()
        {
            WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(ACNavReportsMember);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);
        }

        public void NavigateToACReportsHierarchyManagement()
        {
            WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(ACNavReportsHierarchyManagement);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);
        }

        public void NavigateToACReportsPointReports()
        {
            WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(ACNavPointMember);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);
        }
        public void NavigateToACAllInteractionReport()
        {
            WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(ACNavReportsAllInteraction);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);

        }
        public void NavigateToACReportsPointsReports()
        {
            WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(ACNavReportsPoints);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);
        }

        public void NavigateToACReportsOrderReports()
        {
            WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(ACNavReportsOrder);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);
        }

        public string VerifyUserOrderDetailsListingOnAC(string CdcId)
        {
            WebHandlers.Instance.EnterText(ACOrderCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(6000);
            Assert.IsTrue(driver.FindElement(ACOrdersGridData(CdcId)).Displayed, CdcId + " - Expected user data showing on the orders grid");
            string OrderId = WebHandlers.Instance.GetAttribute(driver.FindElement(ACOrdersIdGridData(CdcId)), "text"); ;
            Assert.IsNotNull(OrderId, OrderId + "AC - Order id not generated against user's order");
            BrowserDriver.Sleep(1000);
            return OrderId;
        }

        public void ValidateUserTierDetailsOnAC(string CdcId)
        {
            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            Assert.AreEqual("Black", WebHandlers.Instance.GetAttribute(ACCustomerCurrentTierData, "innerHTML"), "AC - Customer tier details is not showing as expected");
        }

        public void ValidateUserRewardsPointsDetailsOnAC(string CdcId)
        {
            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            Assert.AreEqual("5000", WebHandlers.Instance.GetAttribute(ACCustomerRewardsPointsData, "innerHTML"), "AC - Customer rewards points is not showing as expected");
        }
        public void ValidateAmexUserRewardsPointsDetailsOnAC(string CdcId)
        {
            WebHandlers.Instance.EnterText(ACUserSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);

            BrowserDriver.Sleep(4000);


            Assert.AreEqual("100", driver.FindElement(By.XPath("(//a[text()='" + CdcId + "']//..//..//following-sibling::td[5])[1]")).Text);
            Assert.AreEqual("100", driver.FindElement(By.XPath("(//a[text()='" + CdcId + "']//..//..//following-sibling::td[5])[2]")).Text);

        }
        public void ValidateQNBUserRewardsPointsDetailsOnAC(string CdcId)
        {
            WebHandlers.Instance.EnterText(ACUserSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);

            BrowserDriver.Sleep(4000);


            Assert.AreEqual("1000", driver.FindElement(By.XPath("(//a[text()='" + CdcId + "']//..//..//following-sibling::td[5])[1]")).Text);
        }
        public void ValidateUserBonusPointsDetailsOnAC(string CdcId)
        {
            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);

            BrowserDriver.Sleep(4000);
            Assert.AreEqual("5000", driver.FindElement(ACCustomerEarnedPoints(CdcId)).Text, "AC - Customer Bonus point is not showing as expected");
        }

        public void ValidateAddedMembersHierarchyinAC(string groupid, string fromdate, string todate, String[] member)
        {
            WebHandlers.Instance.EnterText(ACCHierArchyFromDate, fromdate);
            WebHandlers.Instance.EnterText(ACCHierArchyToDate, todate);
            WebHandlers.Instance.EnterText(ACCHierArchy_GrpID, groupid);
            BrowserDriver.Sleep(4000);
            //WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            driver.FindElement(By.XPath("//button[text()='Search']")).Click();
            BrowserDriver.Sleep(4000);
            driver.FindElement(By.XPath("//button[text()='Search']")).Click();
            //Validating the count of members added
            int TotalMembers = 5;
            Assert.IsTrue(driver.FindElement(Total_Members("Total Members")).Displayed, TotalMembers + " - Expected user data not showing on the orders grid");
            //for (int i = 0; i < member.Length; i++)
            //{
            //    Assert.IsTrue(driver.FindElement(ACOrdersGridData(member[i])).Displayed, member[i] + " - Expected user data showing on the orders grid");
            //}
        }

        public void VerifyGivenUsersWereListingOnAC(string CdcId)
        {
            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            BrowserDriver.Sleep(4000);
            Assert.IsTrue(driver.FindElement(ACCustomersGridData(CdcId)).Displayed, CdcId + " - Expected user name not showing on the grid");
            BrowserDriver.Sleep(1000);
        }
        //168
        public void VerifyFullReturnForIsShowingOnAC(string CdcId, string Point)
        {
            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
            Assert.AreEqual(Point, driver.FindElement(ACCustomerActivityLogValue("Return")).Text, "Entry for point deduction against return product is not showing on AC");
            BrowserDriver.Sleep(1000);
        }

        public void ValidateExpectedPointsIsAddedOnAC(string CdcId, string PointCategory, string ExpPoints)
        {
            string CurrPoints = null;
            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-Mar-2021");
            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);

            if (PointCategory == "Miscellaneous" || PointCategory == "Rewards Points" || PointCategory == "Extend Points")
            {
                WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
                BrowserDriver.Sleep(4000);
                WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
                BrowserDriver.Sleep(4000);
                CurrPoints = WebHandlers.Instance.GetAttribute(ACCustomerRewardsPointsData, "innerHTML");
                Assert.AreEqual(ExpPoints, CurrPoints, PointCategory + " Points is not showing as expected on AC");
            }

            else if (PointCategory == "Status Points")
            {
                WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomerPointsList(CdcId)));
                BrowserDriver.Sleep(4000);
                WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomerPointsList(CdcId)));
                BrowserDriver.Sleep(4000);
               Assert.IsTrue(driver.FindElement(ACTableDatadetailss(ExpPoints)).Displayed, PointCategory + " is not showing as expected on AC");
            }
        }

        public void ValidateObsoleteCustomersWereShowingAsInactiveOnAC(string CdcId)
        {
            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            Assert.AreEqual("Inactive", driver.FindElement(ACMemberReportFieldValue("Status:")).GetAttribute("innerText"), "AC - Obsolete customer status is not showing as inactive");
        }

        public void VerifyCurrencyInteractionTypeBonusOnAC(string CdcId, string DateRange)
        {
            String[] DateMonth = DateRange.Split('-');

            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, DateMonth[0]);
            WebHandlers.Instance.EnterText(ACCustomerSearchToDate, DateMonth[1]);
            WebHandlers.Instance.EnterText(ACInteractionReportUserIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            Assert.IsTrue(FetchTableCellDataFromAC(ACInteractionReportsTable, CdcId, "Actions").Contains("FOREX Currency Exchange"), "Annex cloud - action details is not showing expected");
            Assert.AreNotEqual("-", FetchTableCellDataFromAC(ACInteractionReportsTable, CdcId, "Points"), "Annex cloud - points earned is not showing expected");
            BrowserDriver.Sleep(1000);

            WebHandlers.Instance.Click(driver.FindElement(ACCustomersGridData(CdcId)));
            WebWaitHelper.Instance.WaitForPresence(ACHeaderFiveData("Activity : " + CdcId + " "), TimeSpan.FromSeconds(120));
            BrowserDriver.Sleep(5000);
            Assert.AreNotEqual("-", FetchTableCellDataFromAC(ACInteractionActivityTable, "FOREX Currency Exchange", "Points"), "Annex cloud - currency exchange points details is not showing as expected");
        }
        //TC_253
        public void ValidatePurchaseOrderValueinAC(string purchasevalue, string acorderid)
        {
            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, acorderid);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            BrowserDriver.Sleep(8000);
            (driver.FindElement(By.XPath("//th[text()='Order ID']/following::td[3]"))).Click();
            BrowserDriver.Sleep(3000);
            string totalnetprice = driver.FindElement(By.XPath("//th[text()='Unit Price']/following::td[12]")).Text;
            // Convert the string to a decimal or double
            decimal totalnetpriceValue = decimal.Parse(totalnetprice);
            // Format the numeric value with two decimal places
            string totalnetpricewithdecimal = totalnetpriceValue.ToString("F2");
            Assert.IsTrue(totalnetpricewithdecimal.Equals(purchasevalue), "The Purchase amount is not matching with the value displayed in AC");
        }

        public void ValidateACUserTierGetsUpgradedTo(string CdcId, string ExpTier, string ExpPoints)
        {
            string CurrPoints = null;
            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-Mar-2021");
            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            CurrPoints = WebHandlers.Instance.GetAttribute(ACCustomerRewardsPointsData, "innerHTML");
            Assert.AreEqual(ExpTier, WebHandlers.Instance.GetAttribute(ACCustomerCurrentTierData, "innerHTML"), "AC - Customer tier details is not showing as expected");
        }

        public void VerifyGroupAccountDeactivated(string GroupAccount)
        {
            WebHandlers.Instance.EnterText(ACCHierArchyFromDate, DateTime.Now.ToString("MM/dd/yyyy"));
            WebHandlers.Instance.EnterText(ACCHierArchyToDate, DateTime.Now.AddDays(30).ToString("MM/dd/yyyy"));
            WebHandlers.Instance.EnterText(ACCHierArchy_GrpID, GroupAccount);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            BrowserDriver.Sleep(4000);
            Assert.AreEqual(0, driver.FindElements(ACCustomersGridData(GroupAccount)).Count, GroupAccount + " not showing as deactivated on AC");
        }

        public void VerifyNoRewardsPointsAddedForRedeemCashRewards(string CdcId, string OrderId)
        {
            //OrderId = OrderId.Replace('"', ' ').Trim();
            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
            BrowserDriver.Sleep(4000);

            Assert.AreNotEqual("-", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Redeemed"), "Annex cloud - Points redeemed is showing as null");
            Assert.AreEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Earned"), "Annex cloud - Points earned is not showing as 0");
            BrowserDriver.Sleep(1000);
        }

        public string FetchTableCellDataFromAC(IWebElement Table, string RowItem, string ColumnItem)
        {
            int ColumnIndex = 0;
            int RowIndex = 0;
            IList<IWebElement> Rows = Table.FindElements(By.TagName("tr"));
            IList<IWebElement> Columns = Table.FindElements(By.TagName("th"));

            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].GetAttribute("innerHTML") == ColumnItem)
                {
                    ColumnIndex = i + 1;
                    break;
                }
            }

            for (int j = 0; j < Rows.Count; j++)
            {
                if (Rows[j].GetAttribute("innerHTML").Contains(RowItem))
                {
                    RowIndex = j;
                    break;
                }
            }

            string item = Table.FindElement(By.XPath("//following-sibling::tr[" + RowIndex + "]/td[" + ColumnIndex + "]")).GetAttribute("innerHTML");
            return item;
        }

        public void VerifyCancelOrderDataShowingOnACOrderDetails(string CdcId, string OrderId)
        {
            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(driver.FindElement(ACLinkTextUnderSpan(OrderId)));
            WebWaitHelper.Instance.WaitForPresence(ACSpanText(OrderId), TimeSpan.FromSeconds(120));
            BrowserDriver.Sleep(5000);

            Assert.AreEqual("1.00", FetchTableCellDataFromAC(ACPurchaseOrderReportsTable, OrderId, "Cancelled"), "Annex cloud - Cancelled order data is not showing");
            BrowserDriver.Sleep(1000);
        }

        public void VerifyRetrospectiveEntryOnACOrderDetails(string CdcId, string OrderId)
        {
            OrderId = OrderId.Replace('"', ' ').Trim();
            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
            BrowserDriver.Sleep(4000);

            Assert.AreNotEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Earned"), "Annex cloud - Retrospective points earned is not showing expected");
            BrowserDriver.Sleep(1000);
        }

        public void VerifyBaseRewardsPointsEntryOnACOrderDetails(string CdcId, string OrderId)
        {
            OrderId = OrderId.Replace('"', ' ').Trim();
            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, "01-May-2022");
            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
            BrowserDriver.Sleep(4000);
            Assert.AreNotEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Earned"), "Annex cloud - Base rewards points earned is not showing expected");
            Assert.AreEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Redeemed"), "Annex cloud - redeemed points earned is not showing expected");
            BrowserDriver.Sleep(1000);

            WebHandlers.Instance.Click(driver.FindElement(ACLinkTextUnderSpan(OrderId)));
            WebWaitHelper.Instance.WaitForPresence(ACSpanText(OrderId), TimeSpan.FromSeconds(120));
            BrowserDriver.Sleep(5000);
            Assert.AreEqual("1.00", FetchTableCellDataFromAC(ACPurchaseOrderReportsTable, OrderId, "Shipped"), "Annex cloud - Shipped order data is not showing as expected");
            Assert.AreEqual("0.00", FetchTableCellDataFromAC(ACPurchaseOrderReportsTable, OrderId, "Cancelled"), "Annex cloud - Cancelled order data is not showing as expected");
            Assert.AreEqual("0.00", FetchTableCellDataFromAC(ACPurchaseOrderReportsTable, OrderId, "Returned"), "Annex cloud - Returned order data is not showing as expected");
        }

        public void VerifyOnlineRewardsPointsEntryOnACOrderDetails(string CdcId, string OrderId, string DateRange)
        {
            OrderId = OrderId.Replace('"', ' ').Trim();
            String[] DateMonth = DateRange.Split('-');

            WebHandlers.Instance.EnterText(ACCustomerSearchFromDate, DateMonth[0]);
            WebHandlers.Instance.EnterText(ACCustomerSearchToDate, DateMonth[1]);
            WebHandlers.Instance.EnterText(ACOrderReportUserIdSearch, CdcId);
            WebHandlers.Instance.EnterText(ACOrderReportOrderIdSearch, OrderId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebHandlers.Instance.WebElementExists(driver.FindElement(ACLinkTextUnderSpan(CdcId)));
            BrowserDriver.Sleep(4000);
            Assert.AreNotEqual("0", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "Points Earned"), "Annex cloud - Status rewards points earned is not showing expected");
            Assert.AreEqual("Online", FetchTableCellDataFromAC(ACOrderReportsTable, OrderId, "channel"), "Annex cloud - channel details is not showing expected");
        }

        public void SearchforCustomer(string CdcId, string Tier)
        {

            WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
            WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
            WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
            BrowserDriver.Sleep(4000);
            Assert.AreEqual(Tier, WebHandlers.Instance.GetAttribute(ACCustomerCurrentTierData, "innerHTML"), "AC - Customer tier details is not showing as expected");

        }

        #endregion
    }
}
