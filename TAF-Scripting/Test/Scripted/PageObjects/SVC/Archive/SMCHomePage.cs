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
//    class SMCHomePage
//    {

//        public IWebDriver driver;
//        private Configuration config = null;

//        #region  Constructor
//        public SMCHomePage(IWebDriver driver, Configuration configuration)
//        {
//            this.driver = driver;
//            PageFactory.InitElements(this.driver, this);
//            config = configuration;
//        }

//        #endregion

//        #region Elements
//        [FindsBy(How = How.Id, Using = "application-MarketingContact-showList-component---worklist--contactToolbarSearchField-I")]
//        private IWebElement SMCCustomersSearchEdit;

//        public By SMCCustomersGridData(string text) { return By.XPath("(//a[text()='" + text + "'])[1]"); }

//        [FindsBy(How = How.XPath, Using = "//a[@class='sapMLnk sapMLnkMaxWidth']")]
//        private IWebElement SMCNewEmailVerify;

//        [FindsBy(How = How.XPath, Using = "//bdi[@id='PersonalDataBlock-Collapsed--id-1645716314422-1304_Consumer_YY1_ReConsentTimestamp_MPS-element0-label-bdi']//parent::span//parent::span//parent::div//following-sibling::div//div//span")]
//        private IWebElement SMCReconsentTimestamp;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Personal Data']")]
//        private IWebElement SMCCustomersSubtabPersonalData;
//        public By UserRewardStatusSMC(string status) { return By.XPath("//div[contains(@id,'IsRewardOptin')]/span[text()='"+ status + "']"); }
//        public By SubTabs(string tabName) { return By.XPath("//bdi[text()='"+ tabName + "']"); }
//        public By SMCSpanText(string tabName) { return By.XPath("//span[contains(text(),'" + tabName + "')]"); }
//        public By SMCBBInteractionSpanText(string text) { return By.XPath("(//span[text()='"+ text + "'])[1]"); }
//        public By SMCSpanContainsText(string text) { return By.XPath("(//span[contains(text(),'"+ text + "')])[1]"); }
//        [FindsBy(How = How.XPath, Using = "(//span[text()='Sales'])[1]")]
//        private IWebElement SMCInteraction_SalesFilter;

//        [FindsBy(How = How.XPath, Using = "//div[@id='TimeLine-0-shell']//span[@id='__xmlview1--InteractionDetailsButton-img']")]
//        private IWebElement SMCInteractionGridDetails;
//        public By SMCCustomersRewrdsPointsDetails(string PointValue) { return By.XPath("//span[contains(@id,'PointsBalance')][text()='" + PointValue + "']"); }

//        [FindsBy(How = How.XPath, Using = "//span[@role='img'][@title='Third Party Solution']")]
//        private IWebElement SMCInteractionThirdPartyPannel;

//        [FindsBy(How = How.XPath, Using = "//span[@role='img'][@title='Loyalty']")]
//        private IWebElement SMCInteractionLoyaltyPannel;

//        #endregion

//        #region Events
//        public void ValidateSignedUpWithNewEmailWereSavedOnSMC(string FullName, string Email)
//        {
//            //Editing given customer from SMC

//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(7000);
//            driver.FindElement(SMCCustomersGridData(FullName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(5000);
//            Assert.AreEqual(Email.ToLower(), SMCNewEmailVerify.Text, "Email validation failed");
//        }
//        public Dictionary<string, Dictionary<string, string>> GetAllLiteCustomersDetails(string fileName, string sheetName)
//        {
//            Dictionary<string, Dictionary<string, string>> CustomerDetails = new Dictionary<string, Dictionary<string, string>>();
//            CustomerDetails = DataFilesUtil.GetAllData(fileName, sheetName);

//            int totalCustomers = CustomerDetails.Count();
//            var result = CustomerDetails.Where(x => x.Value.Any(y => y.Key == "Email" && y.Value != "")).ToDictionary(x => x.Key, x => x.Value);

//            return result;
//        }
       
//        public void ValidateSignedUpWithRegEmailWereSavedOnSMC(string FullName, string Email, string timestamp)
//        {
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(7000);
//            driver.FindElement(SMCCustomersGridData(FullName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(5000);
//            SMCCustomersSubtabPersonalData.Click();
//            BrowserDriver.Sleep(3000);
//            //validating the reconsent timestamp for reg user
//            var dateTime = SMCReconsentTimestamp.Text;
//            string[] values = dateTime.Split(',');
//            Assert.AreEqual(DateTime.Now.ToString("dd.MM.yyyy"), values[0], "Date validation failed");
//        }

//        public void ValidateUserShowingAsRewardsOnSMC(string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            SMCCustomersSubtabPersonalData.Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(UserRewardStatusSMC("Yes")).Displayed, "User rewards status is not showing as expected on SMC");

//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SMCSpanText("QA_Welcome")).Displayed, "Welcome interaction email not sent from SMC");
//        }

//        public void MarketingInteractionAndEmailOnSMC(string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            WebHandlers.Instance.WebElementExists(SMCInteractionThirdPartyPannel);
//            BrowserDriver.Sleep(10000);
//            WebHandlers.Instance.Click(SMCInteractionThirdPartyPannel);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(SMCBBInteractionSpanText("Premier Spa booked")));
//            BrowserDriver.Sleep(4000);
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Third Party Solution")).Displayed, "Beauty booking details not showing under SMC interaction");
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Premier Spa booked")).Displayed, "Beauty booking details not showing under SMC interaction");
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Shape & Polish Manicure")).Displayed, "Beauty booking service not showing under SMC interaction");
//        }

//        public void VerifyBBUserDetailsInteractionsAndVerifiedStatusOnSMC(string UserName, string Email, string Phone)
//        {
//            string FullName = UserName + " " + UserName + "Lname";
//            PerformCustomerSearchOnSMC(FullName, Email);
//            SMCCustomersSubtabPersonalData.Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SMCSpanContainsText("Verified")).Displayed, "User verified status is not showing as expected on SMC");
//            Assert.IsTrue(driver.FindElement(SMCSpanContainsText(FullName)).Displayed, "User name is not showing as expected on SMC");
//            Assert.IsTrue(driver.FindElement(SMCSpanContainsText(Phone)).Displayed, "User phone number is not showing as expected on SMC");
//            Assert.IsTrue(driver.FindElement(SMCCustomersGridData(Email.ToLower())).Displayed, "User email is not showing as expected on SMC");

//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SMCSpanText("QA_Newsletter_ProductReccs")).Displayed, "Booking interaction not showing on SMC");
//        }
//        public void ValidatetenPercentcancellationUpdatedInSMC(string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            //Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='10p day cancelled']")).Displayed, "Cancelled Interaction is not displayed in SMC");
//            Assert.IsTrue(driver.FindElement(By.XPath("(//span[contains(text(),'10p day cancelled')])[1]")).Displayed, "Cancelled Interaction is not displayed in SMC");

//        }

//        public void ValidateBirthdayMoveinSMC(string Username, string Email)
//        {
//            PerformCustomerSearchOnSMC(Username, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElements(By.XPath("//span[text()='Moved Birthday']")).Count>0, "The Birthday date is not moved in SMC");
//        }

//        public void ValidatePurchaseOrderinSMC(string Username, string Email, string portalorder, string purchasevalue)
//        {
//            PerformCustomerSearchOnSMC(Username, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(SMCInteraction_SalesFilter);
//            BrowserDriver.Sleep(5000);
//            Boolean portalorder_display = driver.FindElement(By.XPath("//span[contains(text(),'" + portalorder + "')]")).Displayed;
//            if (portalorder_display)
//            {
//                driver.FindElement(By.XPath("(//span[contains(text(),'" + portalorder + "')]/following::button)[1]")).Click();
//                BrowserDriver.Sleep(3000);
//                string bill_amount = driver.FindElement(By.XPath("(//bdi[text()='Amount']/following::span)[2]")).Text;
//                Assert.IsTrue(bill_amount.Equals(purchasevalue), "The Purchase value doesnt match with the value in SMC");
//            }
//            else
//            {
//                Assert.Fail("Purchase/Portal Order is not seen in SMC");
//            }
//        }

//        public void ValidateTenPercentDay1UpdatedinSMC(string day1,string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='10p day booked']")).Displayed, "Discount Booked date is not displayed in SMC");
//        }

//        public void ValidateInteractionEmailForSignedUpUser(string FullName, string Email)
//        {
//            driver.FindElement(SubTabs("Interactions")).Click();
//            WebHandlers.Instance.WebElementExists(SMCInteractionGridDetails);
//            WebHandlers.Instance.Click(SMCInteractionGridDetails);
//            BrowserDriver.Sleep(3000);

//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Outbound Email")).Displayed, "Email Interaction is not generated on SMC ");
//            Assert.IsTrue(driver.FindElement(SMCSpanContainsText("Welcome")).Displayed, "Welcome interaction is not generated on SMC ");
//        }

//        public void VerifyMiniHarrodsBirthdayEmailFromSMC(string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("QA_Mini Harrods Happy Birthday")).Displayed, "Mini harrods birthday promotion email not showing under SMC interaction");
//        }

//        public void VerifySelectedTenpDayInteractionEmailFromSMC(string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("QA_10P Confirmation")).Displayed, "10% day promotion email not showing under SMC interaction");
//        }

//        public void VerifySMCUserpresence(string FullName, string Email)
//        {
//            bool user_display = false;
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, FullName + "\n");
//            BrowserDriver.Sleep(5000);
//            //Assert.IsTrue(driver.FindElement(By.XPath("(//h3[normalize-space()=\"We couldn't find any contacts\"])[1]")).Displayed,"The user is still found in SMC");
//            try
//            {
//                user_display = driver.FindElement(SMCCustomersGridData(FullName)).Displayed;
//                Assert.Fail("The user is still found in SMC");
//            }
//            catch (NoSuchElementException)
//            {
//                Console.WriteLine("User is successfully removed in SMC as well");
//            }
            
//            BrowserDriver.Sleep(5000);
//        }

//        public void PerformCustomerSearchOnSMC(string FullName, string Email)
//        {
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(5000);
//            driver.FindElement(SMCCustomersGridData(FullName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(5000);
//        }

//        public void ValidateBrandMailerEmailFromSMC(string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("QA_BrandMailer Confirmation")).Displayed, "BrandMailer email not showing under SMC interaction");
//        }

//        public void VerifyHappyBirthdayEmailFromSMC(string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            driver.FindElement(By.XPath("//*[text()='Last 3 Quarters']")).Click();
//            BrowserDriver.Sleep(5000);
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("QA_Happy Birthday-Part 1-COMMUNICATION")).Displayed, "Happy birthday promotion email not showing under SMC interaction");
//        }

//        public void VerifySalesInteractionAgainstFullReturnShowingOnSMC(string FullName, string Email, string Id)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            BrowserDriver.Sleep(3000);
//            //WebWaitHelper.Instance.WaitForElement(driver.FindElement(SubTabs("Interactions")));
//            WebHandlers.Instance.Click(driver.FindElement(SubTabs("Interactions")));
//            driver.FindElement(SubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(3000);
//            driver.FindElement(By.XPath("//*[text()='Last 3 Years']")).Click();
//            WebHandlers.Instance.WebElementExists(driver.FindElement(SMCBBInteractionSpanText("Sales")));
//            BrowserDriver.Sleep(3000);
//            //driver.Navigate().Refresh();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Sales")).Displayed, "Sales interaction not showing on SMC");
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("FF Portal Order")).Displayed, "FF order interaction not showing on SMC");
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Document ID "+ Id)).Displayed, "Document id interaction not showing on SMC");
//        }

//        public void ValidateEmpoyeeCreatedinSMC(string FullName,string Email)
//        {
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(7000);
//            driver.FindElement(SMCCustomersGridData(FullName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(5000);

//            //Validating default address is updated in SMC
//            SMCCustomersSubtabPersonalData.Click();
//            BrowserDriver.Sleep(3000);
//            Assert.AreEqual("Yes", driver.FindElement(By.XPath("//bdi[text()='Employee']//..//..//..//following::div//span")).Text);
//            //driver.FindElement(SubTabs("Interactions")).Click();
//            //BrowserDriver.Sleep(3000);

//        }
//        #endregion
//        public void NavigateToSMCcontentStudio()
//        {
//            WebHandlers.Instance.Click(driver.FindElement(SMCSpanContainsText("Content Studio")));
//            BrowserDriver.Sleep(3000);
//        }
//        public void SearchandInsertImageToSMCcontentStudio()
//        {
//            //click on template available
//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//div[@class='sapCntPgPreviewLoader'])[1]")));
//            BrowserDriver.Sleep(7000);
//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//div[@id='application-CampaignMessage-manage-component---object--DesignView--ContentPage-0-2']")));
//            BrowserDriver.Sleep(7000);
//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//i[@class='mce-ico mce-i-image']")));
//            BrowserDriver.Sleep(7000);
//            //click on insert button
//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[@aria-label='Show Value Help']")));
//            BrowserDriver.Sleep(7000);

//            //Note: image uploading need to be implemented // Images not available in Canto

//        }

//        public void ValidateExpectedPointsIsAddedOnSMC(string FullName, string Email, string PointCategory, string ExpPoints)
//        {
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(7000);
//            driver.FindElement(SMCCustomersGridData(FullName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(5000);

//            SMCCustomersSubtabPersonalData.Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SMCCustomersRewrdsPointsDetails(ExpPoints+".00")).Displayed, PointCategory+" Points is not showing as expected on SMC");
//        }

//        public void ValidateCurrencyInteractionTypeOnSMC(string FullName, string Email)
//        {
//            PerformCustomerSearchOnSMC(FullName, Email);
//            driver.FindElement(SubTabs("Interactions")).Click();
//            WebHandlers.Instance.WebElementExists(SMCInteractionLoyaltyPannel);
//            BrowserDriver.Sleep(10000);
//            WebHandlers.Instance.Click(SMCInteractionLoyaltyPannel);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(SMCInteractionLoyaltyPannel);
//            driver.FindElement(By.XPath("//*[text()='Last 3 Years']")).Click();
//            WebHandlers.Instance.WebElementExists(driver.FindElement(SMCBBInteractionSpanText("Loyalty Points Accrued")));
//            BrowserDriver.Sleep(4000);
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Loyalty Points Accrued")).Displayed, "Loyalty Points Accrued details not showing under SMC interaction");
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("250 - FOREX Currency Exchange - 2022-05-17T15:59:50")).Displayed, "FOREX currency exchange details not showing under SMC interaction");
//            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("iPad Pro (9.7-inch)")).Displayed, "Purchased product details not showing under SMC interaction");
//        }

//        public void ValidateObsoleteCustomersWereDeletedFromSMC(string FullName, string Email)
//        {
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(5000);
//            Assert.AreEqual(0, driver.FindElements(SMCCustomersGridData(FullName)).Count, "Obsolete customers were not get deleted from SMC");
//        }

//    }
//}
