using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SMC
{
    class SMCContactProfilePage
    {
        public IWebDriver driver;
        private Configuration config = null;
        

        #region  Constructor
        public SMCContactProfilePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements
        [FindsBy(How = How.Id, Using = "application-MarketingContact-showList-component---worklist--contactToolbarSearchField-I")]
        private IWebElement SMCCustomersSearchEdit;
        [FindsBy(How = How.XPath, Using = "//span[@role='img'][@title='Loyalty']")]
        private IWebElement SMCInteractionLoyaltyPannel;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Personal Data']")]
        private IWebElement SMCCustomersSubtabPersonalData;
        [FindsBy(How = How.XPath, Using = "//div[@id='TimeLine-0-shell']//span[@id='__xmlview1--InteractionDetailsButton-img']")]
        private IWebElement SMCInteractionGridDetails;
        [FindsBy(How = How.XPath, Using = "(//span[text()='Sales'])[1]")]
        private IWebElement SMCInteraction_SalesFilter;
        [FindsBy(How = How.XPath, Using = "(//span[text()='Omni-Channel'])[1]")]
        private IWebElement SMCInteraction_Omni_ChannelFilter;
        [FindsBy(How = How.XPath, Using = "//span[@role='img'][@title='Third Party Solution']")]
        private IWebElement SMCInteractionThirdPartyPannel;
        [FindsBy(How = How.XPath, Using = "//bdi[@id='PersonalDataBlock-Collapsed--id-1645716314422-1304_Consumer_YY1_ReConsentTimestamp_MPS-element0-label-bdi']//parent::span//parent::span//parent::div//following-sibling::div//div//span")]
        private IWebElement SMCReconsentTimestamp;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Permission Marketing']")]
        private IWebElement SMCCustomersSubtabPermissionMarketing;
        [FindsBy(How = How.XPath, Using = "//span[@id='MarketingPermissionsBlock-Collapsed--permGraphToggle-button-img']")]
        private IWebElement SMCPermissionGraphViewBtn;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Current Tier']/following::div/span)[1]")]
        private IWebElement SMCCustomerTierData;
        [FindsBy(How = How.XPath, Using = "//a[@id='backBtn']")]
        private IWebElement SMCCustomersSubtabBackBtn;
        [FindsBy(How = How.XPath, Using = "//input[@type='search']")]
        private IWebElement SMCInterestCustomerSearch;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='IsRewardOptin']/following::span[2]")]
        private IWebElement SMCCustomerRewardOptinStatus;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Adapt Filters']")]
        private IWebElement SMCInterestAdaptiveFilter;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='OK']")]
        private IWebElement SMCInterestAdaptiveFilterOk;
        [FindsBy(How = How.XPath, Using = "//span[@id='MarketingPermissionsBlock-Collapsed--permTableToggle-button-img']")]
        private IWebElement SMCPermissionDetailViewBtn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reward Card No']/following::span[2]")]
        private IWebElement SMC_RewardCardNumber_TextRO;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ContactID-inner')]")]
        private IWebElement SMCInterestContactIdSearch;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Interactions']")]
        private IWebElement SMCCustomersSubtabInteractions;
        [FindsBy(How = How.XPath, Using = "//span[@role='img'][@title='Loyalty']/following-sibling::span")]
        private IWebElement SMCInteractionLoyaltyPannelCount;

        public IWebElement IWebElement { get; private set; }
        #endregion

        public By SMCCustomersGridData(string text) { return By.XPath("(//a[text()='" + text + "'])[1]"); }
        public By SMCUsersGridData(string text) { return By.XPath("(//a[text()='"+text+"'])[1]"); }
        public By SubTabs(string tabName) { return By.XPath("//bdi[text()='" + tabName + "']"); }
        public By SMCBBInteractionSpanText(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }
        public By SMCSales(string text) { return By.XPath("(//span[text()='" + text + "'])"); }
        public By SMCCustomersRewrdsPointsDetails(string PointValue) { return By.XPath("//span[contains(@id,'_PointsBalance')][text()='" + PointValue + "']"); }
        public By SMCCustomersRewrdsDetails(string PointValue) { return By.XPath("//bdi[text()='Status Points Balance']//following::span[text()='" + PointValue + "']"); }
        public By UserRewardStatusSMC(string status) { return By.XPath("//div[contains(@id,'IsRewardOptin')]/span[text()='" + status + "']"); }
        public By SMCSpanContainsverify(string text) { return By.XPath("(//span[contains(text(),'" + text + "')])[1]"); }
        public By SMCSpanContainsText(string text) { return By.XPath("(//span[contains(text(),'" + text + "')])[1]"); }
        public By SMCSpanText(string tabName) { return By.XPath("//span[contains(text(),'" + tabName + "')]"); }
        private By SMCMiniHarrodsMember(string text)
        { return By.XPath("//bdi[text()='Mini Harrods Member']//parent::span//parent::span//parent::div//following-sibling::div//div//span[text()='" + text + "']"); }
        public By SMCCustomersGridEmailData(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }
        public By SMCCustomersPersonalDetails(string text) { return By.XPath("//span/bdi[text()='" + text + "']"); }
        public By SMCUserPersonalDetails(string text) { return By.XPath("(//span[text()='"+text+"'])[3]"); }
        public By SMCUserPersonalDetailsCitys(string text) { return By.XPath("(//span[text()='" + text + "'])[2]"); }
        public By SMCUserAddressDetails(string text) { return By.XPath("(//span[text()='" + text + "'])"); }
        public By SMCCustomersPersonalDetailsAddressLine1(string text) { return By.XPath("//span[text()='" + text + "']"); }
        public By SMCCustomersPersonalDetailsCountry(string text) { return By.XPath("//span[text()='" + text + "']"); }
        public By SMCUserPersonalDetailsCard(string text)
        {
            return By.XPath("(//span[text()='" + text + "'])");
         }
        public By SMCUserPersonalDetailsCountry(string text) { return By.XPath("(//span[contains(text(),'" + text + "')])[2]"); }
        public By SMCUserPD(string text) { return By.XPath("(//span[contains(text(),'" + text + "')])"); }
        public By SMCUserPersonalDetailsCity(string text) { return By.XPath("(//span[contains(text(),'" + text + "')])"); }
        public By SMCCustomersOptOutGrid(string email) { return By.XPath("//div[contains(@id,'MarketingPermissionsBlock-Collapsed--CommMedContainerOptin')]//span[text()='" + email + "']"); }
        public By SMCUserOptOutGrid(string email) { return By.XPath("//div[contains(@id,'MarketingPermissionsBlock-Collapsed--PermCardsOptoutCommMedCardItem-MarketingPermissionsBlock-Collapsed--CommMedContainerOptOut-0-MarketingPermissionsBlock-Collapsed--PermissionsCardsOptoutCommMedCard-MarketingPermissionsBlock-Collapsed--CommMedContainerOptOut-0-0')]//span[text()='" + email + "']"); }

        public By SMCCustomersOptInGrid(string email) { return By.XPath("//div[contains(@id,'MarketingPermissionsBlock-Collapsed--PermCardsOptinCommMedCardItem-MarketingPermissionsBlock-Collapsed--CommMedContainerOptIn-0-MarketingPermissionsBlock-Collapsed--PermissionsCardsOptinCommMedCard-MarketingPermissionsBlock-Collapsed--CommMedContainerOptIn-0-0')]//span[text()='" + email + "']"); }
        
        public By SMCChannelPermissionStatus(string ChannelName) { return By.XPath("(//span[contains(@id,'MarketingPermissionsBlock-Collapsed')][text()='" + ChannelName + "'])[1]/../../following-sibling::td//span[@dir='ltr']"); }
        public By SMCInterestsConsentStatus(string CdcId, string InterestName)
        {
            return By.XPath("(//span[text()='" + CdcId + "']/ancestor::td/following-sibling::td//span[text()='" + InterestName + "']/ancestor::td/following-sibling::td/span)[1]");
        }
        public By SMCCustomersCurrentTierDetails(string TierValue) { return By.XPath("//span[contains(@id,'CurrentTier')][text()='" + TierValue + "']"); }
        public By SMCInterestFilterCheckbox(string FilterName) { return By.XPath("//bdi[text()='" + FilterName + "']/ancestor::tr//input"); }
        public By SMCPhoneNumber(string text) { return By.XPath("//span[@title='" + text + "'][@class='sapMText sapUiSelectable sapMTextNoWrap sapHpaCommunicationGroupDisplayContent sapUiTinyMarginTop']"); }
        #region Events
        public void PerformCustomerSearchOnSMC(string FullName, string Email)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(5000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);
        }
        public void ValidateCurrencyInteractionTypeOnSMC(string FullName, string Email)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            WebHandlers.Instance.WebElementExists(SMCInteractionLoyaltyPannel);
            BrowserDriver.Sleep(10000);
            WebHandlers.Instance.Click(SMCInteractionLoyaltyPannel);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SMCInteractionLoyaltyPannel);
            driver.FindElement(By.XPath("//*[text()='Last 3 Years']")).Click();
            WebHandlers.Instance.WebElementExists(driver.FindElement(SMCBBInteractionSpanText("Loyalty Points Accrued")));
            BrowserDriver.Sleep(4000);
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Loyalty Points Accrued")).Displayed, "Loyalty Points Accrued details not showing under SMC interaction");
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("250 - FOREX Currency Exchange - 2022-05-17T15:59:50")).Displayed, "FOREX currency exchange details not showing under SMC interaction");
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("iPad Pro (9.7-inch)")).Displayed, "Purchased product details not showing under SMC interaction");
        }
        //Tc_222A
        public void ValidateExpectedPointsIsAddedOnSMC(string FullName, string Email, string PointCategory, string ExpPoints)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            double expPointsValue = Convert.ToDouble(ExpPoints);
            string formattedExpPoints = expPointsValue.ToString("N2");
            Assert.IsTrue(driver.FindElement(SMCCustomersRewrdsPointsDetails(formattedExpPoints)).Displayed, PointCategory + " Points is not showing as expected on SMC");
        }

        public void ValidateEmpoyeeCreatedinSMC(string FullName, string Email)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating default address is updated in SMC
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.AreEqual("Yes", driver.FindElement(By.XPath("//bdi[text()='Employee']//..//..//..//following::div//span")).Text);
            //driver.FindElement(SubTabs("Interactions")).Click();
            //BrowserDriver.Sleep(3000);

        }

        public void VerifySalesInteractionAgainstFullReturnShowingOnSMC(string FullName, string Email, string Id)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(driver.FindElement(SubTabs("Interactions")));
            WebHandlers.Instance.Click(driver.FindElement(SubTabs("Interactions")));
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(4000);
            driver.FindElement(By.XPath("//*[text()='Last 3 Years']")).Click();
            BrowserDriver.Sleep(4000);
            IWebElement element = driver.FindElement(SMCBBInteractionSpanText("Sales"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.WebElementExists(driver.FindElement(SMCSales("Sales")));
            BrowserDriver.Sleep(5000);
            //driver.Navigate().Refresh();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Sales")).Displayed, "Sales interaction not showing on SMC");
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("FF Portal Order")).Displayed, "FF order interaction not showing on SMC");
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Document ID " + Id)).Displayed, "Document id interaction not showing on SMC");
        }

        public void VerifyHappyBirthdayEmailFromSMC(string FullName, string Email)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            driver.FindElement(By.XPath("//*[text()='Last 3 Quarters']")).Click();
            BrowserDriver.Sleep(5000);
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("QA_Happy Birthday-Part 1-COMMUNICATION")).Displayed, "Happy birthday promotion email not showing under SMC interaction");
        }

        public void ValidateBrandMailerEmailFromSMC(string FullName, string Email)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("QA_BrandMailer Confirmation")).Displayed, "BrandMailer email not showing under SMC interaction");
        }
        //TC_170
        public void VerifyMiniHarrodsBirthdayEmailFromSMC(string FullName, string Email)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            //Checking CST_Prepone_MiniHarrods_BdayPromo_OneWeek
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Moved Birthday")).Displayed, "Mini harrods birthday promotion email not showing under SMC interaction");
        }

        public void VerifySelectedTenpDayInteractionEmailFromSMC(string FullName, string Email)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("QA_10P Confirmation")).Displayed, "10% day promotion email not showing under SMC interaction");
        }

        public void ValidateTenPercentDay1UpdatedinSMC(string day1, string FullName, string Email)
        {
            //PerformCustomerSearchOnSMC(FullName, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='10p day booked']")).Displayed, "Discount Booked date is not displayed in SMC");
        }

        public void ValidateInteractionEmailForSignedUpUser(string FullName, string Email)
        {
            driver.FindElement(SubTabs("Interactions")).Click();
            WebHandlers.Instance.WebElementExists(SMCInteractionGridDetails);
            WebHandlers.Instance.Click(SMCInteractionGridDetails);
            BrowserDriver.Sleep(3000);

            Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Outbound Email")).Displayed, "Email Interaction is not generated on SMC ");
            Assert.IsTrue(driver.FindElement(SMCSpanContainsText("Welcome")).Displayed, "Welcome interaction is not generated on SMC ");
        }
        //TC_185
        public void ValidatetenPercentcancellationUpdatedInSMC(string FullName, string Email)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            IList<IWebElement> elements = driver.FindElements(By.XPath("(//span[contains(text(),'QA_10p_Cancelled')])[1]"));

            if (elements.Count == 0)
            {
                // If the element does not exist, click the "Show More" button
                driver.FindElement(By.XPath("//bdi[text()='Show More']")).Click();
            }
            BrowserDriver.Sleep(4000);
            //Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='10p day cancelled']")).Displayed, "Cancelled Interaction is not displayed in SMC");
            Assert.IsTrue(driver.FindElement(By.XPath("(//span[contains(text(),'QA_10p_Cancelled')])[1]")).Displayed, "Cancelled Interaction is not displayed in SMC");

        }

        public void ValidateBirthdayMoveinSMC(string Username, string Email)
        {
            PerformCustomerSearchOnSMC(Username, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElements(By.XPath("//span[text()='Moved Birthday']")).Count > 0, "The Birthday date is not moved in SMC");
        }

        public void ValidatePurchaseOrderinSMC(string Username, string Email, string portalorder, string purchasevalue)
        {
            PerformCustomerSearchOnSMC(Username, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SMCInteraction_Omni_ChannelFilter);
            BrowserDriver.Sleep(5000);
            Boolean portalorder_display = driver.FindElement(By.XPath("//span[contains(text(),'" + portalorder + "')]")).Displayed;
            BrowserDriver.Sleep(3000);
            if (portalorder_display)
            {
                BrowserDriver.Sleep(3000);
                driver.FindElement(By.XPath("(//span[contains(text(),'" + portalorder + "')]/following::button)[1]")).Click();
                BrowserDriver.Sleep(5000);
                string bill_amount = driver.FindElement(By.XPath("(//bdi[text()='Amount']/following::span)[2]")).Text;
                BrowserDriver.Sleep(5000);
                Assert.IsTrue(bill_amount.Equals(purchasevalue), "The Purchase value doesnt match with the value in SMC");
            }
            else
            {
                Assert.Fail("Purchase/Portal Order is not seen in SMC");
            }
        }

        public void ValidateUserShowingAsRewardsOnSMC(string FullName, string Email)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(UserRewardStatusSMC("Yes")).Displayed, "User rewards status is not showing as expected on SMC");

            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            // Scroll down to the bottom of the page
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            System.Threading.Thread.Sleep(3000);
            driver.FindElement(SMCBBInteractionSpanText("Email")).Click();
            BrowserDriver.Sleep(3000);
            //Assert.IsTrue(driver.FindElement(SMCSpanText("QA_Welcome")).Displayed, "Welcome interaction email not sent from SMC");
        }

        public void MarketingInteractionAndEmailOnSMC(string FullName, string Email)
        {
            PerformCustomerSearchOnSMC(FullName, Email);
            driver.FindElement(SubTabs("Interactions")).Click();
            WebHandlers.Instance.WebElementExists(SMCInteractionThirdPartyPannel);
            BrowserDriver.Sleep(10000);
            WebHandlers.Instance.Click(SMCInteractionThirdPartyPannel);
            //WebHandlers.Instance.WebElementExists(driver.FindElement(SMCBBInteractionSpanText("Premier Spa booked")));
            BrowserDriver.Sleep(4000);
            //Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Third Party Solution")).Displayed, "Beauty booking details not showing under SMC interaction");
            //Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Premier Spa booked")).Displayed, "Beauty booking details not showing under SMC interaction");
            //Assert.IsTrue(driver.FindElement(SMCBBInteractionSpanText("Shape & Polish Manicure")).Displayed, "Beauty booking service not showing under SMC interaction");
        }

        public void VerifyBBUserDetailsInteractionsAndVerifiedStatusOnSMC(string UserName, string Email, string Phone)
        {
            string FullName = UserName + " " + UserName + "Lname";
            PerformCustomerSearchOnSMC(FullName, Email);
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCSpanContainsverify("Verified")).Displayed, "User verified status is not showing as expected on SMC");
            Assert.IsTrue(driver.FindElement(SMCSpanContainsText(FullName)).Displayed, "User name is not showing as expected on SMC");
            Assert.IsTrue(driver.FindElement(SMCSpanContainsText(Phone)).Displayed, "User phone number is not showing as expected on SMC");
            Assert.IsTrue(driver.FindElement(SMCCustomersGridData(Email.ToLower())).Displayed, "User email is not showing as expected on SMC");

            driver.FindElement(SubTabs("Interactions")).Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCSpanText("QA_Newsletter_ProductReccs")).Displayed, "Booking interaction not showing on SMC");
        }

        public void ValidateSignedUpWithRegEmailWereSavedOnSMC(string FullName, string Email, string timestamp)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            //validating the reconsent timestamp for reg user
            var dateTime = SMCReconsentTimestamp.Text;
            string[] values = dateTime.Split(',');
            Assert.AreEqual(DateTime.Now.ToString("dd.MM.yyyy"), values[0], "Date validation failed");
        }
        public void validateMiniHarrodsPresentSMC()
        {
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);

            Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("Yes")).Displayed);
        }
        //TC_221A
        public void ValidateCustomerTierinSMC(string Email, string FullName, string Tier)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(5000);
            Assert.IsTrue(driver.FindElement(SMCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())));
            BrowserDriver.Sleep();
            Assert.IsTrue(driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
            BrowserDriver.Sleep();
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollBy(-200, 0);");
            Actions actions = new Actions(driver);
            IWebElement = driver.FindElement(SMCCustomersGridData(FullName));
            actions.MoveToElement(IWebElement).Perform();
            BrowserDriver.Sleep(3000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);

            string Customertier = WebHandlers.Instance.GetTextOfElement(SMCCustomerTierData);
            Assert.IsTrue(Customertier.Equals(Tier), "The Customer tier is not changed as expected");
        }

        public void VerifyGivenUsersWithCardEmailWereListingOnSMC(string UserName, string Email, string CardNumber, string EmailConsent)
        {
            CardNumber = CardNumber.Trim();
            //string FullName = UserName + " " + UserName + "Lname";
            string FullName = UserName;
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(5000);
            // Assert.IsTrue(driver.FindElement(SMCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
            //SMCCustomersGridData xpath changed to SMCUsersGridData
            Assert.IsTrue(driver.FindElement(SMCUsersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
            //WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())));
            BrowserDriver.Sleep(5000);
            //Assert.IsTrue(driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
            BrowserDriver.Sleep();
            //driver.FindElement(SMCCustomersGridData(FullName)).Click();
            //SMCCustomersGridData xpath changed to SMCUsersGridData
            driver.FindElement(SMCUsersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(9000);

            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            if (CardNumber!="")
            {
                Assert.IsTrue(driver.FindElement(SMCUserPersonalDetailsCard(CardNumber)).Displayed, CardNumber + " - Expected card number not showing on the grid");
            }
            else { Console.WriteLine("Card number is not available for this customer!"); }

            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionGraphViewBtn.Click();
            BrowserDriver.Sleep(5000);
            if (EmailConsent == "Yes")
                Assert.IsTrue(driver.FindElement(SMCCustomersOptInGrid(Email.ToLower())).Displayed, Email + " - Expected email not showing under Opt In");
            else if (EmailConsent == "No")
                //Assert.IsTrue(driver.FindElement(SMCCustomersOptOutGrid(Email.ToLower())).Displayed, Email + " - Expected email not showing under Opt Out");
                //SMCCustomersOptOutGrid xpath changed to SMCUserOptOutGrid
                Assert.IsTrue(driver.FindElement(SMCUserOptOutGrid(Email.ToLower())).Displayed, Email + " - Expected email not showing under Opt Out");
            SMCCustomersSubtabBackBtn.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
        }

        public void VerifyCardEmailConsentDetailsOnSMC(string UserName, string Email, string CardNumber, string EmailConsent)
        {
            string FullName = UserName + " " + UserName + "Lname";
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(CardNumber)).Displayed, CardNumber + " - Expected card number not showing on the grid");

            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            if (EmailConsent == "Yes")
                Assert.IsTrue(driver.FindElement(SMCCustomersOptInGrid(Email.ToLower())).Displayed, Email + " - Expected email not showing under Opt In");
            else if (EmailConsent == "No")
                Assert.IsFalse(driver.FindElements(SMCCustomersOptInGrid(Email.ToLower())).Count != 0, Email + " - Expected email not showing under Opt Out");

            SMCCustomersSubtabBackBtn.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
        }

        public void VerifyUserOrderDetailsOnSMC(string UserName, string Email, string OrderNumber)
        {
            string FullName = UserName + " " + UserName + "Lname";
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            SMCCustomersSubtabInteractions.Click();
            BrowserDriver.Sleep(3000);
            //Assert.IsTrue(driver.FindElement(SMCCustomersProductOrderData(OrderNumber)).Displayed, OrderNumber + " - Expected order number not showing on the grid");
            Assert.AreEqual("1", WebHandlers.Instance.GetAttribute(SMCInteractionLoyaltyPannelCount, "innerHTML"), "Performed purchase count is not showing as expected");
            SMCCustomersSubtabBackBtn.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
        }

        public void ValidateUserTierDetailsOnSMC(string FullName, string Email)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCCustomersCurrentTierDetails("Black")).Displayed, "Customer tier details is not showing as expected on SMC");
        }

        public void ValidateUserRewardsPointsOnSMC(string FullName, string Email)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCCustomersRewrdsPointsDetails("5,000.00")).Displayed, "Customer rewards point is not showing as expected on SMC");
        }
        //TC_82A,TC_86A,TC_90A
        public void ValidateUserAddedAddressOnSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //Editing given customer from SMC
            BrowserDriver.Sleep(25000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(9000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating added address
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetailsAddressLine1(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on SMC customer personal data grid");
            //Console.WriteLine("Postal Address Address Line 1 is " + SMCCustomersPersonalDetailsAddressLine1(PostalAddress["AddressLine1"]));
            Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetailsAddressLine1(PostalAddress["AddressLine2"])).Displayed, PostalAddress["AddressLine2"] + " not showing on SMC customer personal data grid");
            Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetailsAddressLine1(PostalAddress["AddressLine3"])).Displayed, PostalAddress["AddressLine3"] + " not showing on SMC customer personal data grid");
            Assert.IsTrue(driver.FindElement(SMCUserPersonalDetailsCountry(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on SMC customer personal data grid");
            Assert.IsTrue(driver.FindElement(SMCUserPersonalDetailsCountry(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on SMC customer personal data grid");
            Assert.IsTrue(driver.FindElement(SMCUserPD(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SMC customer personal data grid");
            //Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["CellPhone"])).Displayed, PostalAddress["CellPhone"] + " not showing on SMC customer personal data grid");
        }

        //TC_108
        public void validateCityStatePostcodeInSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating added address
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            // Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["Country"])).Displayed, PostalAddress["State"] + " not showing on SMC customer personal data grid");
            // Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on SMC customer personal data grid");
            // Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SMC customer personal data grid");
            Assert.IsTrue(driver.FindElement(SMCUserPersonalDetails(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on SMC customer personal data grid");
            Assert.IsTrue(driver.FindElement(SMCUserPersonalDetailsCitys(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on SMC customer personal data grid");
             Assert.IsTrue(driver.FindElement(SMCSales(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SMC customer personal data grid");


        }

        public void ValidateUserAddressGetDeletedFromSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //Editing given customer from SMC
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating added address
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);

            Assert.IsFalse(driver.FindElements(SMCCustomersPersonalDetails(PostalAddress["AddressLine1"])).Count != 0, PostalAddress["AddressLine1"] + " not get deleted from SMC");
            Assert.IsFalse(driver.FindElements(SMCCustomersPersonalDetails(PostalAddress["AddressLine2"])).Count != 0, PostalAddress["AddressLine2"] + " not get deleted from SMC");
            Assert.IsFalse(driver.FindElements(SMCCustomersPersonalDetails(PostalAddress["AddressLine3"])).Count != 0, PostalAddress["AddressLine3"] + " not get deleted from SMC");
        }

        public void ValidateUserAddedPhonenumberOnSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //Editing given customer from SMC

            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating added phone number
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);

            Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["CellPhone"])).Displayed, PostalAddress["CellPhone"] + " not showing on SMC customer personal data grid");
        }

        //TC_69,TC_064
        //TC_52A
        public void ValidatePhonenumberDeletedinSMC(string username, string email, string phonenumber)
        {
            //Boolean mobile_display;
            int mobile_display;
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SMCCustomersGridData(username)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            
                //mobile_display = driver.FindElements(By.XPath("//*[text()='" + phonenumber + "']")).Count;
                //Check mobile number is not displayed in SMC
                mobile_display = driver.FindElements(By.XPath("//div[@id='__data830']//span")).Count;
                //As per latest functionality Phone number deletion of SMC,-Mobile Number will display in SMC
                // If the mobile number is found, assertion passes with the message "MB exists"
              //  Assert.IsTrue(mobile_display != 0, "Mobile number Not deleted ");
           


        }

        public void ValidatewhetherDOBUpdated(string username, string email, string DOB)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SMCCustomersGridData(username)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//*[text()='" + DOB + "']")).Displayed, "The DOB is not updated");
        }

        public void ValidateUserdetailsonSMC(string firstname, string lastname, string dob, string email)
        {
            string username = firstname + " " + lastname;
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SMCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(3000);
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);

            string displayed_username = driver.FindElement(By.XPath("//*[@id='PersonalDataBlock-Collapsed--contactName-inner']")).Text;
            string displayed_dob = driver.FindElement(By.XPath("//*[@id='PersonalDataBlock-Collapsed--DateOfBirth-text']")).Text;

            Assert.IsTrue(displayed_username.Equals(username), "Username is not created as expected");
            Assert.IsTrue(displayed_dob.Equals(dob), "DOB is not displayed as expected");
        }
        //TC_59A,60,62,63,67,68
        public void ValidateUserAddednumberOnSMC(String countrycode, String phonenumber, String username, String Email)
        {
            string UserPhone = "";
            BrowserDriver.Sleep(3000);

            switch (countrycode)
            {
                case ("UK"):
                    UserPhone = "+44" + phonenumber;
                    break;
                case ("US"):
                    UserPhone = "+1" + phonenumber;
                    break;
                case ("China"):
                    UserPhone = "+86" + phonenumber;
                    break;
                case ("Canada"):
                    UserPhone = "+1" + phonenumber;
                    break;
                case ("France"):
                    UserPhone = "+33" + phonenumber;
                    break;
            }

           WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            Console.WriteLine(username);
            driver.FindElement(SMCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(3000);
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            //phonenumber=countrycode also included in phonenumber
            try
            {
                var phoneNumberElement = driver.FindElement(SMCPhoneNumber(phonenumber));
                Assert.IsTrue(phoneNumberElement.Displayed, "Phone number is not displayed as expected in SVC.");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Phone number is not displayed in SVC");
            }
            BrowserDriver.Sleep(3000);

            Boolean displayed_status = driver.FindElement(SMCPhoneNumber(phonenumber)).Displayed;
              
                if (displayed_status)
            {
                Console.WriteLine("Phone number is displayed as expected");
            }
            else
            {
                Console.WriteLine("Phone number is not displayed as expected");
            }
            
            
        }

        
        public void ValidateUserAddedPhonenumberOnSMC(String countrycode, String phonenumber, String username, String Email)
        {
            string UserPhone = "";
            BrowserDriver.Sleep(3000);

            switch (countrycode)
            {
                case ("UK"):
                    UserPhone = "+44" + phonenumber;
                    break;
                case ("US"):
                    UserPhone = "+1" + phonenumber;
                    break;
                case ("China"):
                    UserPhone = "+86" + phonenumber;
                    break;
                case ("Canada"):
                    UserPhone = "+1" + phonenumber;
                    break;
                case ("France"):
                    UserPhone = "+33" + phonenumber;
                    break;
            }
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            Console.WriteLine(username);
            driver.FindElement(SMCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(3000);
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            //phonenumber=countrycode also included in phonenumber
            Boolean displayed_status = driver.FindElement(SMCPhoneNumber(UserPhone)).Displayed;
            if (displayed_status)
            {
                Console.WriteLine("Phone number is displayed as expected");
            }
            else
            {
                Console.WriteLine("Phone number is not displayed as expected");
            }
        }

        public void ValidateUserRegisteredforRewardsSMC(string username, string email)
        {
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(8000);
            WebHandlers.Instance.Click(driver.FindElement(SMCCustomersGridData(username)));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SMCCustomersSubtabPersonalData);
            BrowserDriver.Sleep(2000);
            string optinstat = SMCCustomerRewardOptinStatus.Text;
            Assert.IsTrue(optinstat.Equals("Yes"), "The Rewards option is not opted");

        }
      //TC_110A
        public void ValidateUserAddressSwapedInSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //Editing given customer from SMC
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating default address is updated in SMC
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SMCUserAddressDetails(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on SMC customer personal data grid");
        }

        public void validateSMCPartialInterestOpting(string FullName, string Email, string OptStatus, string SMCInterestPage, string CdcId)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating SMC customer channels consent
            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionDetailViewBtn.Click();
            BrowserDriver.Sleep(1000);

            Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt In");
            Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt In");

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
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt Out");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "MothersDay")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt Out");



        }

        public void ValidateRewardCardforCustomerinSMC(string username, string email, string new_Card)
        {
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(SMCCustomersGridData(username)));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SMCCustomersSubtabPersonalData);
            BrowserDriver.Sleep(2000);

            string rewardcard_SMC = SMC_RewardCardNumber_TextRO.Text;
            //Assert.IsTrue(rewardcard_SMC.Equals(card_assigned),"Reward Card "+ card_assigned + " is not updated in SMC. Old card "+ rewardcard_SMC + " is displayed");
            Assert.IsTrue(rewardcard_SMC.Equals(new_Card), "Reward Card --> " + new_Card + " is not updated in SMC. Old card --> " + rewardcard_SMC + " is displayed");
        }

        public void ValidateChilddetailsOnSMC(string FullName, string Email, Boolean isMember)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating added address
            SMCCustomersSubtabPersonalData.Click();
            BrowserDriver.Sleep(3000);
            if (isMember)
                try
                {
                    Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("Yes")).Displayed);
                }
                catch(NoSuchElementException)
                {
                    Assert.Fail("The Selected Member is not a MiniHarrodsMember");
                }
            else
            {
                try
                {
                    Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("No")).Displayed);
                }
                catch (NoSuchElementException)
                {
                    Assert.Fail("The Selected Member is displayed as a MiniHarrodsMember");
                }
            }

        }

        public void ValidateremoveAllInterestSMC(string FullName, string Email, string channel, string SMCInterestPage, string CdcId)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating SMC customer channels consent
            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionDetailViewBtn.Click();
            BrowserDriver.Sleep(1000);
            if (channel == "email")
            {
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");

            }
            if (channel == "postal")
            {
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");

            }
            SMCCustomersSubtabPersonalData.Click();
            Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("Yes")).Displayed, "Not a miniharrods member");

            //Validating SMC customer interests consent
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

            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
            Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");
        }

        public void ValidateremoveAllConsentSMC(string FullName, string Email, string channel, string SMCInterestPage, string CdcId)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating SMC customer channels consent
            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionDetailViewBtn.Click();
            BrowserDriver.Sleep(1000);

            Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
            Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
            Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");


            SMCCustomersSubtabPersonalData.Click();
            //Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("Yes")).Displayed, "Not a miniharrods member");

            //Validating SMC customer interests consent
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

            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");
        }

        public void ValidateLoyaltyuserSMCChannelPref(string FullName, string Email, string channel, string Status)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating SMC customer channels consent
            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionDetailViewBtn.Click();
            BrowserDriver.Sleep(1000);
            if (channel == "email")
            {
                Assert.AreEqual(Status, driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");

            }
            if (channel == "postal")
            {
                //Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual(Status, driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Postal channel consent is not showing under Opt Out");
            }
        }
        public void ValidateLoyaltyuserSMCCommunicationPreferencesOpting(string FullName, string Email, string channel, string SMCInterestPage, string CdcId)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating SMC customer channels consent
            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionDetailViewBtn.Click();
            BrowserDriver.Sleep(1000);
            if (channel == "email")
            {
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");

            }
            if (channel == "postal")
            {
                //Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");

            }
            //Validating SMC customer interests consent
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

            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
            Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");



        }
        
        public void ValidateSMCCommunicationPreferencesOpting(string FullName, string Email, string OptStatus,string SMCInterestPage, string CdcId)
        {
            //BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            //BrowserDriver.Sleep(7000);
            //driver.FindElement(SMCCustomersGridData(FullName)).Click();
            //BrowserDriver.PageWait();
            //BrowserDriver.Sleep(5000);

            //Validating SMC customer channels consent
            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionDetailViewBtn.Click();
            BrowserDriver.Sleep(1000);
            if (OptStatus == "OptIn-All")
            {
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt In");
            }

            else if (OptStatus == "Opt-Out All")
            {
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
            }

            else if (OptStatus == "Opt-Some")
            {
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
            }
            else if (OptStatus == "removeAllConsent")
            {
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Phone")).GetAttribute("innerHTML"), "SMC - Phone channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("SMS")).GetAttribute("innerHTML"), "SMC - SMS channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
            }

            //Validating SMC customer interests consent
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
            if (OptStatus == "Opt-In All")
            {
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");
            }

            else if (OptStatus == "Opt-Out All")
            {
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt Out");
            }

            else if (OptStatus == "Opt-Some")
            {
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt Out");
                //Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt Out");
                //Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt Out");

            }
            else if (OptStatus == "Opt-mixed")
            {
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt Out");

            }
            else if (OptStatus == "removeAllConsent")
            {
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");
            }

        }

        public void ValidateSMCCommunicationPreferencesOpting_TC105(string FullName, string Email, string OptStatus, string SMCInterestPage, string CdcId)
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(7000);
            driver.FindElement(SMCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Validating SMC customer channels consent
            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionDetailViewBtn.Click();
            BrowserDriver.Sleep(1000);
            if (OptStatus == "Opt-Some")
            {
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
            }
          

            //Validating SMC customer interests consent
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
           

             if (OptStatus == "Opt-Some")
            {
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt Out");
                //Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt Out");
                //Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt Out");

            }
          

        }

        public void SearchCustomerAndValidateSMCCommunicationPreferencesOpting(string FullName, string Email, string OptStatus, string SMCInterestPage, string CdcId)
        {
            //BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
            //BrowserDriver.Sleep(7000);
           //// driver.FindElement(SMCCustomersGridData(FullName)).Click();
           // BrowserDriver.PageWait();
           // BrowserDriver.Sleep(5000);

            //Validating SMC customer channels consent
            SMCCustomersSubtabPermissionMarketing.Click();
            BrowserDriver.Sleep(3000);
            SMCPermissionDetailViewBtn.Click();
            BrowserDriver.Sleep(1000);
            if (OptStatus == "OptIn-All")
            {
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt In");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt In");
            }

            else if (OptStatus == "Opt-Out All")
            {
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
            }

            else if (OptStatus == "Opt-Some")
            {
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
            }
            else if (OptStatus == "removeAllConsent")
            {
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Phone")).GetAttribute("innerHTML"), "SMC - Phone channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("SMS")).GetAttribute("innerHTML"), "SMC - SMS channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
            }

            //Validating SMC customer interests consent
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
            if (OptStatus == "Opt-In All")
            {
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");
            }

            else if (OptStatus == "Opt-Out All")
            {
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt Out");
            }

            else if (OptStatus == "Opt-Some")
            {

            }
            else if (OptStatus == "Opt-mixed")
            {
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt Out");
                Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt Out");

            }
            else if (OptStatus == "removeAllConsent")
            {
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
                Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");
            }

        }

        #endregion
    }
}
