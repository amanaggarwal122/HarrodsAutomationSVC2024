using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using TAF_Web.Scripted.Web;


namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SMC
{
    class SMCContactsPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        #region  Constructor
        public SMCContactsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        [FindsBy(How = How.Id, Using = "application-MarketingContact-showList-component---worklist--contactToolbarSearchField-I")]
        private IWebElement SMCCustomersSearchEdit;
        // [FindsBy(How = How.XPath, Using = "//a[@class='sapMLnk sapMLnkMaxWidth']")]
        [FindsBy(How = How.XPath, Using = "//div[@class='sapUiVltCell sapuiVltCell']/a[@class='sapMLnk sapMLnkMaxWidth']")]
        private IWebElement SMCNewEmailVerify;
        [FindsBy(How = How.XPath, Using = "//input[@type='search']")]
        private IWebElement SMCInterestCustomerSearch;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Adapt Filters']")]
        private IWebElement SMCInterestAdaptiveFilter;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='OK']")]
        private IWebElement SMCInterestAdaptiveFilterOk;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ContactID-inner')]")]
        private IWebElement SMCInterestContactIdSearch;
        #endregion
        public By SMCInterestFilterCheckbox(string FilterName) { return By.XPath("//bdi[text()='" + FilterName + "']/ancestor::tr//input"); }

        
        public By SMCCustomersGridData(string text) { return By.XPath("(//a[text()='" + text + "'])[1]"); }
        public By SMCCustomersGridEmailData(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }
        public By SMCInterestsConsentStatus(string CdcId, string InterestName)
        {
            return By.XPath("(//span[text()='" + CdcId + "']/ancestor::td/following-sibling::td//span[text()='" + InterestName + "']/ancestor::td/following-sibling::td/span)[1]");
        }
        #region Events
        public void ValidateObsoleteCustomersWereDeletedFromSMC(string FullName, string Email)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(5000);
            Assert.AreEqual(0, driver.FindElements(SMCCustomersGridData(FullName)).Count, "Obsolete customers were not get deleted from SMC");
        }

        public void PerformCustomerSearchOnSMC(string FullName, string Email)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(5000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);
        }

        public void VerifySMCUserpresence(string FullName, string Email)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, FullName + "\n");
            BrowserDriver.Sleep(5000);
            Assert.IsTrue(driver.FindElement(By.XPath("(//h3[normalize-space()=\"We couldn't find any contacts\"])[1]")).Displayed, "The user is still found in SMC");
            BrowserDriver.Sleep(5000);
        }

        public void ValidateSignedUpWithNewEmailWereSavedOnSMC(string FullName, string Email)
        {
            //Editing given customer from SMC

            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);
            Assert.AreEqual(Email.ToLower(), SMCNewEmailVerify.Text, "Email validation failed");
        }
        //public Dictionary<string, Dictionary<string, string>> GetAllLiteCustomersDetails(string fileName, string sheetName)
        //{
        //    Dictionary<string, Dictionary<string, string>> CustomerDetails = new Dictionary<string, Dictionary<string, string>>();
        //    CustomerDetails = DataFilesUtil.GetAllData(fileName, sheetName);

        //    int totalCustomers = CustomerDetails.Count();
        //    var result = CustomerDetails.Where(x => x.Value.Any(y => y.Key == "Email" && y.Value != "")).ToDictionary(x => x.Key, x => x.Value);

        //    return result;
        //}

        public void VerifyGivenUsersWereListingOnSMC(string UserName, string Email)
        {
            string FullName = UserName + " " + UserName + "Lname";
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(5000);
            Assert.IsTrue(driver.FindElement(SMCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())));
            BrowserDriver.Sleep();
            Assert.IsTrue(driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
            BrowserDriver.Sleep();
        }

        public void miniHarrodsRemoveInterestUpdatedInSMC(string FullName, string email, string SMCInterestPage, string CdcId)
        {
            driver.Navigate().GoToUrl(SMCInterestPage);
            WebWaitHelper.Instance.WaitForElementPresence(SMCInterestCustomerSearch);
            WebHandlers.Instance.Click(SMCInterestAdaptiveFilter);
            BrowserDriver.Sleep(2000);
            WebWaitHelper.Instance.WaitForElementPresence(SMCInterestAdaptiveFilterOk);
            Actions FilterAction = new Actions(driver);
            FilterAction.MoveToElement(driver.FindElement(SMCInterestFilterCheckbox("Contact ID"))).Click().Build().Perform();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SMCInterestAdaptiveFilterOk);
            BrowserDriver.Sleep(2000);
            WebWaitHelper.Instance.WaitForElementPresence(SMCInterestContactIdSearch);
            WebHandlers.Instance.EnterText(SMCInterestContactIdSearch, CdcId + "\n");
            BrowserDriver.Sleep(5000);
            //partial interest selection
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "MiniHarrods")).GetAttribute("innerHTML"), "SMC - Mini Harrods interest is  showing as selected ");
        }
        #endregion
    }
}
