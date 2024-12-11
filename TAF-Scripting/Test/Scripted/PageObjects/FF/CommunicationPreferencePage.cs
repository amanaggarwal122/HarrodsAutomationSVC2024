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
using TechTalk.SpecFlow;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class CommunicationPreferencePage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver driver;
        

        #region  Constructor

        public CommunicationPreferencePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        //public HomePage()
        //{

        //}
        #endregion

        #region FF Elements		

        [FindsBy(How = How.XPath, Using = "//a[text()='Register']")]
        private IWebElement Register;

        [FindsBy(How = How.XPath, Using = "//a[text()='Sign in']")]
        private IWebElement SignIn;

        [FindsBy(How = How.XPath, Using = "//Button[text()='Accept & Continue']")]
        private IWebElement Accept;

        [FindsBy(How = How.Id, Using = "loginForm-email")]
        private IWebElement loginEmail;

        [FindsBy(How = How.Id, Using = "loginForm-password")]
        private IWebElement loginPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='tabpanel-login']/form/div[5]/Button[text()='Sign in']")]
        private IWebElement Login1;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='loginForm-submitButton']")]
        private IWebElement Login2;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-alert']")]
        private IWebElement Error;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-alert']/div")]
        private IWebElement ErrorMessage;

        public By FFCustomersCurrentTierDetails(string TierValue) { return By.XPath("//p[text()='" + TierValue + "']"); }

        [FindsBy(How = How.XPath, Using = "//span[text()='Points Balance']/following-sibling::span")]
        private IWebElement FFCustomersRewardsPointsDetails;

        [FindsBy(How = How.XPath, Using = "//span[text()='Communication Preferences']")]
        private IWebElement CommunicationPreferences;

        [FindsBy(How = How.XPath, Using = "//h2[text()='Channel']")]
        private IWebElement UserChannelsHeader;

        public By MiniHarrodsField(string miniHarrods) { return By.XPath("//h3[text()='"+ miniHarrods +"']"); }
        public By FFChannelConsentField(string ChannelName) { return By.XPath("//input[@id='" + ChannelName + "']"); }
        public By FFInterestSelectionButton(string SelectItem) { return By.XPath("//button[text()='" + SelectItem + "']"); }
        public By FFInterestSelectionBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']"); }
        public By FFInterestCheckBoxBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']//preceding-sibling::input"); }
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Mini Harrods Is Enroled']/..//following-sibling::div//span")]
        private IWebElement MiniHarrodsEnrolled;
        
        #endregion

        #region CDC Elements

        [FindsBy(How = How.XPath, Using = "//input[@name='username'][@aria-label='Email']")]
        private IWebElement CDCloginEmail;

        [FindsBy(How = How.XPath, Using = "//input[@name='password'][@placeholder='Password *']")]
        private IWebElement CDCloginPassword;

        [FindsBy(How = How.XPath, Using = "//input[@value='Submit']")]
        private IWebElement CDCloginButton;

        [FindsBy(How = How.XPath, Using = "//input[@type='text'][@class='gig-tfa-code-textbox']")]
        private IWebElement OTPPrompt;

        [FindsBy(How = How.CssSelector, Using = "div > div > ida-user-list-container > div.ida__search-container > ida-search-bar > div > div.search-bar__input > input")]
        private IWebElement CDCUserFind;

        [FindsBy(How = How.CssSelector, Using = "div > div > ida-user-list-container > div.ida__search-container > ida-search-bar > div > div.search-bar__buttons--container > button.fd-button.fd-button--emphasized.search-bar__search-button")]
        private IWebElement CDCUserSearchBtn;

        #endregion

        #region SSC Elements

        [FindsBy(How = How.Id, Using = "USERNAME_FIELD-inner")]
        private IWebElement SSCloginEmail;

        [FindsBy(How = How.Id, Using = "PASSWORD_FIELD-inner")]
        private IWebElement SSCloginPassword;

        [FindsBy(How = How.Id, Using = "LOGIN_LINK_CONTENT")]
        private IWebElement SSCloginButton;

        [FindsBy(How = How.XPath, Using = "//a[@title='Customers']")]
        private IWebElement SSCNavCustomers;

        [FindsBy(How = How.XPath, Using = "//a[@title='Tickets']")]
        private IWebElement SSCNavTickets;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;

        [FindsBy(How = How.XPath, Using = "(//span[contains(@id,'dropdownlistboxa9a498bccf7fdaeaf586528c044f484a')])[1]")]
        private IWebElement SSCCustomerTierDetails;

        public By SSCNavAdminCustomersTree { get => By.XPath("//span[@title='Customers']"); }
        public By SSCCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }
        
        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }

        [FindsBy(How = How.XPath, Using = "//tbody/tr/td[3]/div/a")]
        private IWebElement SSCFullnamecellinTable;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'-link-listdefintionm_MXxdq8a4M5_GJT7qA0Km_')]")]
        private IWebElement SSCCustomerCardNo;

        [FindsBy(How = How.XPath, Using = "//div[text()='Preferences']")]
        private IWebElement SSCCustomersSubtabPreferences;

        [FindsBy(How = How.XPath, Using = "//div[text()='Customer Data']")]
        private IWebElement SSCCustomersSubtabCustomerData;

        [FindsBy(How = How.XPath, Using = "//div[text()='Contact Details']")]
        private IWebElement SSCCustomersSubtabContactDetails;

        [FindsBy(How = How.XPath, Using = "//span[text()='E-Mail']/../../following-sibling::td[1]/div/span")]
        private IWebElement SSCCustomerEmailConsentOptValue;

        public By SSCCustomersConsent(string text)
        {
            return By.XPath("//span[text()='" + text + "']/../../following-sibling::td[1]/div/span");
        }

        public By SSCCustomersInterest(string text)
        {
            return By.XPath("//span[text()='" + text + "']/../../following-sibling::td[1]/div/span");
        }

        [FindsBy(How = How.XPath, Using = "//div[text()='Purchases']")]
        private IWebElement SSCCustomersSubtabPurchases;
        public By SSCCustomersPurchaseGridData(string orderId) { return By.XPath("//span[text()='" + orderId + "']"); }

        [FindsBy(How = How.XPath, Using = "//button[@title='Create']")]
        private IWebElement SSCTicketCreateBtn;

        public By SSCNewTicketFields(string FieldLabel) { return By.XPath("(//bdi[text()='" + FieldLabel + "']/following::input)[1]"); }

        [FindsBy(How = How.XPath, Using = "//div[text()='Purchases']")]
        private IWebElement SSCTicketIndividualCustomerEdit;

        [FindsBy(How = How.XPath, Using = "//span[text()='My Tickets']")]
        private IWebElement SSCMyTicketsHeader;

        [FindsBy(How = How.XPath, Using = "//textarea[@data-role='editor']")]
        private IWebElement SSCNewTicketDescription;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save and Open']")]
        private IWebElement SSCNewTicketSaveOpen;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
        private IWebElement SSCNewTicketSave;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Send']")]
        private IWebElement SSCTicketEmailSend;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle_')][@role='presentation']")]
        private IWebElement SSCNewTicketEditIcon;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Email']")]
        private IWebElement SSCNewTicketEmailIcon;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Email']/parent::span")]
        private IWebElement SSCNewTicketEmailSpan;

        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'CreateEmail-ToAddressInput-inner')]")]
        private IWebElement SSCNewTicketEmailToAddress;

        //[FindsBy(How = How.XPath, Using = "//iframe[@title='Editable area. Press F10 for toolbar.']")]
        [FindsBy(How = How.XPath, Using = "//iframe[@class='k-content']")]
        private IWebElement SSCNewTicketEmailFrame;

        [FindsBy(How = How.XPath, Using = "//body[@class='sapClientMRTEBodyFullHeight']//span")]
        private IWebElement SSCNewTicketContentBox;

        [FindsBy(How = How.XPath, Using = "//body[contains(@class,'sapClientMRTEBodyFullHeight')]//span")]
        private IWebElement SSCNewTicketEmailContentBox;

        public By SSCCustomerRewardsPointsValue(string points) { return By.XPath("//bdi[text()='Rewards Points']/../following::div[1]//span[text()='" + points + "']"); }

        [FindsBy(How = How.XPath, Using = "//input[@checked='checked'][@type='CheckBox']/ancestor::td/..//span[text()='Address']")]
        private IWebElement SSCCustomerContactAddressDetails;
        public By SSCCustomerContactAddress { get => By.XPath("//input[@checked='checked'][@type='CheckBox']/ancestor::td/..//span[text()='Address']"); }
        public By SSCCustomerAddressFieldData(string AddressValue) { return By.XPath("//span[text()='" + AddressValue + "']"); }
        public By SSCCustomerAddressLinkData(string Value) { return By.XPath("//a[text()='" + Value + "']"); }

        #endregion

        #region AC Elements

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Email']")]
        private IWebElement ACloginEmail;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Password']")]
        private IWebElement ACloginPassword;

        [FindsBy(How = How.Id, Using = "kt_login_signin_submit")]
        private IWebElement ACloginButton;

        [FindsBy(How = How.XPath, Using = "//span[text()='Reports']")]
        private IWebElement ACNavReports;

        [FindsBy(How = How.XPath, Using = "//div[text()='Member']/..//a[text()='GO']")]
        private IWebElement ACNavReportsMember;

        [FindsBy(How = How.XPath, Using = "//div[text()='Order']/..//a[text()='GO']")]
        private IWebElement ACNavReportsOrder;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='searchUserId']")]
        private IWebElement ACCDCIdSearch;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][text()='Search']")]
        private IWebElement ACCustomerSearchBtn;

        [FindsBy(How = How.XPath, Using = "//h4[text()='Current Tier']/../following-sibling::span")]
        private IWebElement ACCustomerCurrentTierData;

        [FindsBy(How = How.XPath, Using = "//h4[text()='Available Points']/../following-sibling::span")]
        private IWebElement ACCustomerRewardsPointsData;

        public By ACCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='uid']")]
        private IWebElement ACOrderCDCIdSearch;
        public By ACOrdersGridData(string cdcId) { return By.XPath("//span[text()='" + cdcId + "']"); }
        public By ACOrdersIdGridData(string cdcId) { return By.XPath("(//span[text()='" + cdcId + "']/../../following-sibling::td/a)[1]"); }
        #endregion

        #region SMC Elements
        

        [FindsBy(How = How.XPath, Using = "//input[@id='j_username']")]
        private IWebElement SMCloginEmail;

        [FindsBy(How = How.XPath, Using = "//div[text()='Continue']")]
        private IWebElement SMCContinueButton;

        [FindsBy(How = How.XPath, Using = "//input[@name='passwd']")]
        private IWebElement SMCloginPassword;

        [FindsBy(How = How.XPath, Using = "//input[@id='idSIButton9']")]
        private IWebElement SMCloginButton;

        [FindsBy(How = How.XPath, Using = "//div[text()='Contacts and Profiles']")]
        private IWebElement SMCNavMenuContacts;

        [FindsBy(How = How.XPath, Using = "//span[text()='Con­tacts']")]
        private IWebElement SMCNavContacts;

        [FindsBy(How = How.Id, Using = "application-MarketingContact-showList-component---worklist--contactToolbarSearchField-I")]
        private IWebElement SMCCustomersSearchEdit;

        public By SMCCustomersGridData(string text) { return By.XPath("(//a[text()='" + text + "'])"); }
        public By SMCCustomersGridEmailData(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Personal Data']")]
        private IWebElement SMCCustomersSubtabPersonalData;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Permission Marketing']")]
        private IWebElement SMCCustomersSubtabPermissionMarketing;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Interactions']")]
        private IWebElement SMCCustomersSubtabInteractions;

        public By SMCCustomersPersonalDetails(string text) { return By.XPath("//span[text()='" + text + "']"); }
        public By SMCPhoneNumber(string text) { return By.XPath("//span[@title='" + text + "'][@class='sapMText sapUiSelectable sapMTextNoWrap sapHpaCommunicationGroupDisplayContent sapUiTinyMarginTop']"); }
        public By SMCCustomersCurrentTierDetails(string TierValue) { return By.XPath("//span[contains(@id,'CurrentTier')][text()='" + TierValue + "']"); }
        public By SMCCustomersRewrdsPointsDetails(string PointValue) { return By.XPath("//span[contains(@id,'PointsBalance')][text()='" + PointValue + "']"); }
        public By SMCCustomersOptOutGrid(string email) { return By.XPath("//div[@id='MarketingPermissionsBlock-Collapsed--PermissionsLayoutCardsOptOut']//span[text()='" + email + "']"); }
        public By SMCCustomersOptInGrid(string email) { return By.XPath("//div[@id='MarketingPermissionsBlock-Collapsed--PermissionsLayoutCardsOptIn']//span[text()='" + email + "']"); }
        public By SMCCustomersProductOrderData(string OrderNumber) { return By.XPath("//span[text()='Document ID " + OrderNumber + "']"); }

        [FindsBy(How = How.XPath, Using = "//a[@id='backBtn']")]
        private IWebElement SMCCustomersSubtabBackBtn;
        
        [FindsBy(How = How.XPath, Using = "//span[@id='MarketingPermissionsBlock-Collapsed--permTableToggle-button-img']")]
        private IWebElement SMCPermissionDetailViewBtn;
        
        [FindsBy(How = How.XPath, Using = "//span[@id='MarketingPermissionsBlock-Collapsed--permGraphToggle-button-img']")]
        private IWebElement SMCPermissionGraphViewBtn;

        public By SMCChannelPermissionStatus(string ChannelName) { return By.XPath("(//span[contains(@id,'MarketingPermissionsBlock-Collapsed')][text()='"+ ChannelName + "'])[1]/../../following-sibling::td//span[@dir='ltr']"); }
        public By SMCInterestsConsentStatus(string CdcId, string InterestName)
        {
            return By.XPath("(//span[text()='" + CdcId + "']/ancestor::td/following-sibling::td//span[text()='" + InterestName + "']/ancestor::td/following-sibling::td/span)[1]");
        }

        [FindsBy(How = How.XPath, Using = "//input[@type='search']")]
        private IWebElement SMCInterestCustomerSearch;
        
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Adapt Filters']")]
        private IWebElement SMCInterestAdaptiveFilter;
        
        [FindsBy(How = How.XPath, Using = "//bdi[text()='OK']")]
        private IWebElement SMCInterestAdaptiveFilterOk;
        public By SMCInterestFilterCheckbox(string FilterName) { return By.XPath("//bdi[text()='"+ FilterName + "']/ancestor::tr//input"); }
        
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ContactID-inner')]")]
        private IWebElement SMCInterestContactIdSearch;

        private By SMCMiniHarrodsMember(string text) 
        { return By.XPath("//bdi[text()='Mini Harrods Member']//parent::span//parent::span//parent::div//following-sibling::div//div//span[text()='"+text+"']"); }


        [FindsBy(How = How.XPath, Using = "//bdi[text()='Mini-Harrods']//parent::span//parent::div//following-sibling::div//span//bdi")]
        private IWebElement SSCMiniHarrodsChildrenCount;

        #endregion

        List<string> consentselection = new List<string>();
        List<string> interestselection = new List<string>();

        #region CDC Events

        #endregion


        #region SSC Events
        public void ValidateremoveAllInterestSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist, List<String> InterestList)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            scenarioContext.Add("UserCDCId", customer_cdcid);

            driver.FindElement(SSCCustomersGridData(UserName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);


            foreach (String item in InterestList)
            {
                Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS OPTED");

            }
            
        }
       public void ValidateremoveAllConsentSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist, List<String> InterestList)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            scenarioContext.Add("UserCDCId", customer_cdcid);

            driver.FindElement(SSCCustomersGridData(UserName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);


            foreach (String item in Consentlist)
            {
                Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "Opt-Out", item + " :IS OPTED");

            }
        }
        #endregion

        #region AC Events


        #endregion

        #region SMC Events
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
            Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("Yes")).Displayed,"Not a miniharrods member");

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
           
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
                Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");


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
        #endregion

        #region FF Events  


        #endregion

        #region Validation     
      

        public void ValidateSiginFailure()
            {
                if (WebHandlers.Instance.WebElementExists(Error))
                {

                    List<string> errors = WebHandlers.Instance.GetTextFromMultipleElements(ErrorMessage);

                    if (errors.Any())
                    {
                        string msg = errors.Aggregate((i, j) => i + ";" + j);
                        Assert.Fail($"Exception occured while login. Error details: " + msg);
                    }

                }
            }
      
        public void validateMiniHarrodsPresentSSC()
        {
            //bdi[text()='Mini Harrods Is Enroled']/..//following-sibling::div//span
            SSCCustomersSubtabCustomerData.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);
            Assert.AreEqual("Yes", MiniHarrodsEnrolled.Text, " Mini Harrods is not enrolled ");

        }
        #endregion
    }
    }

