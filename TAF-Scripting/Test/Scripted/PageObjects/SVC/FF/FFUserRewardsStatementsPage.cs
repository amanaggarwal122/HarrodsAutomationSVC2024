using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.FF
{
    class FFUserRewardsStatementsPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private FFHarrodsHomePage FF_HarrodsHome_Page = null;

        #region  Constructor
        public FFUserRewardsStatementsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
            
        }

        #endregion
        #region  Element
        public By spanHarrodsText(string Message) { return By.XPath("//span[text()='" + Message + "']"); }
        public By MainHeaderConfirmMsg(string Message) { return By.XPath("//h1[text()='" + Message + "']"); }
        public By BBBookingServiceName(string ServiceName) { return By.XPath("(//span[text()='" + ServiceName + "'])[1]"); }
        #endregion

        #region Events
        public void ValidateRewardsStatementDetailsFromHarrods(string PointsCreditMode, string TxnId)
        {
            FF_HarrodsHome_Page = new FFHarrodsHomePage(driver, config);
            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Rewards Statements")));
            WebHandlers.Instance.WebElementExists(driver.FindElement(MainHeaderConfirmMsg("Rewards Statement")));
            BrowserDriver.Sleep(6000);
            if (PointsCreditMode == "Miscellaneous")
                Assert.IsTrue(driver.FindElement(BBBookingServiceName("Manual Rewards Points Adjustment")).Displayed, "Miscellaneous point statement not showing on harrods rewards");
            else if (PointsCreditMode == "Transfers")
                Assert.IsTrue(driver.FindElement(BBBookingServiceName("Transfer points to group members")).Displayed, "Transfer point statement not showing on harrods rewards");
            else if (PointsCreditMode == "Redeemed")
                Assert.IsTrue(driver.FindElement(BBBookingServiceName("Redemption at POS")).Displayed, "Redeemed point statement not showing on harrods rewards");
            else if (PointsCreditMode == "Retrospective")
                Assert.IsTrue(driver.FindElement(BBBookingServiceName("Purchase")).Displayed, "Retrospective point statement not showing on harrods rewards");
            else if (PointsCreditMode == "Purchase")
                Assert.IsTrue(driver.FindElement(BBBookingServiceName(TxnId)).Displayed, "Purchase point statement not showing on harrods rewards");

            FF_HarrodsHome_Page.logOut();
        }
        #endregion
    }
}
