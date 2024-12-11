using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;
using Renci.SshNet;
using System.IO;
using TAF_Scripting.Test.Scripted.PageObjects.SVC;
using System.Globalization;
using Keys = OpenQA.Selenium.Keys;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class HomePage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public HomePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
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

        //[FindsBy(How = How.XPath, Using = "//*[@id='tabpanel-login']/form/div[4]/Button[text()='Sign in']")]
        [FindsBy(How = How.XPath, Using = "//*[@id='loginForm-submitButton'][text()='Sign in']")]
        private IWebElement Login1;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='loginForm-submitButton']")]
        private IWebElement Login2;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-alert']")]
        private IWebElement Error;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-alert']/div")]
        private IWebElement ErrorMessage;

        [FindsBy(How = How.XPath, Using = " //button[@id='confirmationModal-confirmButton']")]
        private IWebElement btnSaveChanges;

        public By FFCustomersCurrentTierDetails(string TierValue) { return By.XPath("//p[text()='" + TierValue + "']"); }

        [FindsBy(How = How.XPath, Using = "//span[text()='Points Balance']/following-sibling::span")]
        private IWebElement FFCustomersRewardsPointsDetails;

        [FindsBy(How = How.XPath, Using = "//span[text()='Communication Preferences']")]
        private IWebElement CommunicationPreferences;

        [FindsBy(How = How.XPath, Using = "//h2[text()='Channel']")]
        private IWebElement UserChannelsHeader;

        public By MiniHarrodsField(string miniHarrods) { return By.XPath("//h3[text()='" + miniHarrods + "']"); }
        public By JoinMiniHarrodsLink(string miniHarrods) { return By.XPath("//h3[text()='" + miniHarrods + "']//following-sibling::a"); }
        public By JoinMiniHarrodsSaveChangesButton(string save) { return By.XPath("//button[text()='" + save + "']"); }
        public By FFChannelConsentField(string ChannelName) { return By.XPath("//input[@id='" + ChannelName + "']"); }
        public By FFInterestSelectionButton(string SelectItem) { return By.XPath("//button[text()='" + SelectItem + "']"); }
        public By FFInterestSelectionBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']"); }
        //public By FFInterestCheckBoxBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']//preceding-sibling::div/input"); }
        public By FFInterestCheckBoxBtn(string SelectItem) { return By.XPath("//span[text()='" + SelectItem + "']//preceding-sibling::input"); }
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Mini Harrods Is Enroled']/..//following-sibling::div//span")]
        private IWebElement MiniHarrodsEnrolled;

        [FindsBy(How = How.XPath, Using = "//UL[@data-test='addressBook-list-container']//li[1]//div//p[@data-test='address-addressLine1']")]
        public IWebElement FirstAddressLine1;
        [FindsBy(How = How.XPath, Using = "//UL[@data-test='addressBook-list-container']//li[2]//div//p[@data-test='address-addressLine1']")]
        private IWebElement SecondAddressLine1;
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @data-test='address-setDefault-delivery']")]
        public IWebElement setDeliveryAddress;
        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox' and @data-test='address-setDefault-billing']")]
        public IWebElement setBillingAddress;
        // public By setDeliveryAddress(string Address_Line1) { return By.XPath("//input[@aria-label='Set " + Address_Line1 + " as default delivery address']"); }
        public By DefaultDeliveryAddress(string FirstAddress_Line1) { return By.XPath("//input[@aria-label='" + FirstAddress_Line1 + " is the default delivery address']"); }
        //  public By setBillingAddress(string Address_Line1) { return By.XPath("//input[@aria-label='Set " + Address_Line1 + " as default billing address']"); }
        public By DefaultBillingAddress(string FirstAddress_Line1) { return By.XPath("//input[@aria-label='" + FirstAddress_Line1 + " is the default billing address']"); }
        public By setContactAddress(string ContactAddress) { return By.XPath("//span[text()='" + ContactAddress + "']"); }
        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-confirmation']/div")]
        private IWebElement AddressConfirmation;
        [FindsBy(How = How.XPath, Using = "//button[@data-test='confirmationModal-confirmButton']")]
        private IWebElement SetAsDefaultBtn;

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

        [FindsBy(How = How.XPath, Using = "//a[@title='Customer Merge']")]
        private IWebElement SSCNavCustomerMerge;

        //[FindsBy(How = How.XPath, Using = "//a[@title='Group Accounts']")]
        //[FindsBy(How = How.XPath, Using = "//a[@title='Group Accounts / Companies']")]
        [FindsBy(How = How.XPath, Using = "//a[contains(@title,'Group Accounts')]")]
        private IWebElement SSCNavCustomers_GrpAccount;
        [FindsBy(How = How.XPath, Using = "//a[@title='Purchases']")]
        private IWebElement SSCNavSales_Purchases;

        [FindsBy(How = How.XPath, Using = "//a[@title='Schedule Cards Creation']")]
        private IWebElement SSCNavScheduleCardCreation;

        [FindsBy(How = How.XPath, Using = "//a[@title='Replenishment']")]
        private IWebElement SSCNavReplenishment;

        [FindsBy(How = How.XPath, Using = "//a[@title='Tickets']")]
        private IWebElement SSCNavTickets;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'_36-img')]")]
        private IWebElement SSCCardJobAddButton;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'_42-img')]")]
        private IWebElement SSCCardReplenishAddButton;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Mass Data Run ID']/following::input[1]")]
        private IWebElement SSC_CardMassDataRunTxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Run Description']/following::input[1]")]
        private IWebElement SSCCardRunDescriptionTxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Add Row']")]
        private IWebElement SSCCardAddRowBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Card Source']/following::input[1]")]
        private IWebElement SSC_CardSource;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Migration']")]
        private IWebElement SSC_CardSource_Migration;
        //[FindsBy(How = How.XPath, Using = "//*[text()='Replenishment']/following::input[1]")]
        //private IWebElement SSC_Replenishment;
        //[FindsBy(How = How.XPath, Using = "//*[text()='Mapped Range From']/following::input[1]")]
        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[2]")]
        private IWebElement SSC_Replenishment;
        [FindsBy(How = How.XPath, Using = "//*[text()='Mapped Range From']/following::input[1]")]
        private IWebElement SSC_MappedRangeFrom;
        [FindsBy(How = How.XPath, Using = "//*[text()='Mapped Range To']/following::input[1]")]
        private IWebElement SSC_MappedRangeTo;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'dropdownlistbox')][contains(@id,'-listdefintion')][@class='sapMComboBoxInner sapMInputBaseInner']")]
        private IWebElement SSC_From_Dropdown_Txt;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save & Close']")]
        private IWebElement SSC_SaveClose_Btn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Cancel']")]
        private IWebElement SSC_Cancel_Btn;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;
        [FindsBy(How = How.XPath, Using = "//*[text()='ID']/following::table/tbody/tr/td/div/a")]
        private IWebElement SSCPurchaseOrderID_Grid;
        [FindsBy(How = How.XPath, Using = "//div[text()='Products']")]
        private IWebElement SSCPurchaseOrder_ProductTab;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;
        [FindsBy(How = How.XPath, Using = "//*[text()='Date of Birth']/following::div[1]")]
        private IWebElement SSC_UserBdate;
        [FindsBy(How = How.XPath, Using = "//button[@title='Expand']/span/span")]
        private IWebElement UserDataExpndBtn;
        [FindsBy(How = How.XPath, Using = "//*[@title='Birthday Week From']/following::div/input[1]")]
        private IWebElement SSC_BdayWeekFromDateTxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Confirm Adjustment']")]
        private IWebElement SSC_ConfirmAdjustmentBtn;
        [FindsBy(How = How.XPath, Using = "(//table[2]/tbody[1]/tr[1]/td[5]/div[1]/span[1])[1]")]
        private IWebElement SSC_Description_MarketingCampaign;
        [FindsBy(How = How.XPath, Using = "(//table[2]/tbody[1]/tr[1]/td[7]/div[1]/span[1])[1]")]
        private IWebElement SSC_StartDate_MarketingCampaign;
        [FindsBy(How = How.XPath, Using = "(//table[2]/tbody[1]/tr[1]/td[8]/div[1]/span[1])[1]")]
        private IWebElement SSC_ELS_MarketingCampaign;
        [FindsBy(How = How.XPath, Using = "(//span[contains(@id,'dropdownlistboxa9a498bccf7fdaeaf586528c044f484a')])[1]")]
        private IWebElement SSCCustomerTierDetails;
        [FindsBy(How = How.XPath, Using = "//*[text()='Customer ID']/following::span[1]")]
        private IWebElement SSCCustomer_ID;

        //        [FindsBy(How = How.XPath, Using = "//div[@id='__title0']/span[text()='Group Accounts']")]
        [FindsBy(How = How.XPath, Using = "//div[@id='__title0']/span[text()='Group Accounts / Companies']")]
        private IWebElement SSCGroupAccountHeader;

        public By SSCNavAdminCustomersTree { get => By.XPath("//span[@title='Customers']"); }
        public By SSCNavAdminSalesTree { get => By.XPath("//span[@title='Sales']"); }
        public By SSCNavAdminCardManagementTree { get => By.XPath("//span[@title='Card Management']"); }
        public By SSCNavAdminServiceTree { get => By.XPath("//span[@title='Service']"); }
        public By SSC_Nav_Tickets { get => By.XPath("//a[@title='Tickets']"); }
        public By SSCCustomersGridData(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }
        [FindsBy(How = How.XPath, Using = "//table[2]/tbody[1]/tr[1]/td[3]/div[1]/a[1]")]
        private IWebElement SSCCustomerGridFirstCell;
        //[FindsBy(How = How.XPath, Using = "//table[2]/tbody[1]/tr[1]/td[5]/div[1]/a[1]")] ==> changed by Ajay 02.11.2022
        [FindsBy(How = How.XPath, Using = "//table[2]/tbody[1]/tr[1]/td[5]/div[1]/a[1]")]
        private IWebElement SSCCustomerGridEmailCell;
        [FindsBy(How = How.XPath, Using = "//*[text()='No results found. Search again in all items?']")]
        private IWebElement SSCNoREsultLink;
        public By SSCCustomerBDate(string text) { return By.XPath("//*[text()='" + text + "']"); }
        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }
        public By SSCInputFieldValue(string text) { return By.XPath("//input[@value='" + text + "']"); }
        //GroupAccountCreation
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Name']/following::input)[1]")]
        private IWebElement SSC_GroupAccountName_Txt;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Primary Member']/following::input)[1]")]
        private IWebElement SSC_PrimaryMember_Txt;

        [FindsBy(How = How.XPath, Using = "//tbody/tr/td[3]/div/a")]
        private IWebElement SSCFullnamecellinTable;

        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'-link-listdefintionm_MXxdq8a4M5_GJT7qA0Km_')]")]
        private IWebElement SSCCustomerCardNo;

        [FindsBy(How = How.XPath, Using = "//div[text()='Preferences']")]
        private IWebElement SSCCustomersSubtabPreferences;

        [FindsBy(How = How.XPath, Using = "//div[text()='Overview']")]
        private IWebElement SSCCustomersSubtabOverview;

        [FindsBy(How = How.XPath, Using = "//div[text()='Campaigns']")]
        private IWebElement SSCCustomersSubtabCampaigns;

        [FindsBy(How = How.XPath, Using = "//div[text()='Customer Data']")]
        private IWebElement SSCCustomersSubtabCustomerData;

        [FindsBy(How = How.XPath, Using = "//div[text()='Contact Details']")]
        private IWebElement SSCCustomersSubtabContactDetails;

        [FindsBy(How = How.XPath, Using = "//div[text()='Relationships']")]
        private IWebElement SSCCustomersRelationships;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Attribute']/following::button/span/span//bdi[text()='Add'])[1]")]
        private IWebElement SSC_Pref_Attribute_Btn;

        [FindsBy(How = How.XPath, Using = "//span[text()='Private Shopping']")]
        private IWebElement SSC_DB_PrivShoppingChkBox;
        [FindsBy(How = How.XPath, Using = "//span[text()='Lead Generation']")]
        private IWebElement SSC_DB_LeadGenChkBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='OK']")]
        private IWebElement SSC_DialogBox_OK;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Select']")]
        private IWebElement SSC_DialogBox_Select;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Cancel']")]
        private IWebElement SSC_DialogBox_Cancel;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Private Shopping Digital']/following::input)[1]")]
        private IWebElement SSC_PrivateShopping_ToggleTxt;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Not eligible for Private Shopping']/following::input[1]")]
        private IWebElement SSC_NotEligiblePrivShop_Dropdown;
        [FindsBy(How = How.XPath, Using = "//span[text()='E-Mail']/../../following-sibling::td[1]/div/span")]
        private IWebElement SSCCustomerEmailConsentOptValue;
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]/tr[1]/td[5]/span[1][@title='Delete']")]
        private IWebElement SSC_Attribute_DeleteBtn;
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]/tr[1]/td[1]")]
        private IWebElement SSC_AttributeTable_NoData;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Assigned to']//preceding::span[@class='sapUiIcon sapUiIconMirrorInRTL sapUiIconPointer sapMInputBaseIcon'][2]")]
        private IWebElement SSC_StatusDropdownBtn;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Open']")]
        private IWebElement SSC_StatusDropdown_TicketOpen;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Solved']")]
        private IWebElement SSC_StatusDropdown_TicketSolved;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Closed']")]
        private IWebElement SSC_StatusDropdown_TicketClosed;
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

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Locking object not possible; object locked by SAP_SYSTEM (SAP_SYSTEM)  |  No changes detected, save not executed  ')][@data-help-id='messageBar-headerMessage']")]
        private IWebElement SSC_Lock_BarMessage;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Actions'][contains(@id,'button')]")]
        private IWebElement SSC_Actions_Btn;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Initiate Merge'][contains(@id,'navigationitem')]")]
        private IWebElement SSC_Initiate_Merge_Menu;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Withdraw from Approval']")]
        private IWebElement SSC_Wihdraw_approval_menu;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Email']")]
        private IWebElement SSCNewTicketEmailIcon;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Email']/parent::span")]
        private IWebElement SSCNewTicketEmailSpan;
        public By SSCIsDefaultAddress(string Value) { return By.XPath("//span[contains(text(),'" + Value + "') and @title='isDefault']"); }
        public By SSCIsBillingAddress(string Value) { return By.XPath("//span[contains(text(),'" + Value + "') and @title='isBilling']"); }
        public By SSCIsDeliveryAddress(string Value) { return By.XPath("//span[contains(text(),'" + Value + "') and @title='isDelivery']"); }

        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'--header-arrowScrollRight')]")]
        private IWebElement SSCCustomerTabScrollRight;

        public By SSCChildGenderDropdown(string value)
        {
            return By.XPath("//div[@class='sapMPopoverScroll']/ul/li[text()='" + value + "']");
        }

        [FindsBy(How = How.XPath, Using = "//*[@title='Gender']/following::input[3][@class='sapMInputBaseInner sapMComboBoxInner']")]
        private IWebElement SSCChildGenderdrpdowntxt;

        public By SSCChildRelationship(string value)
        {
            return By.XPath("//ul[@class='sapMComboBoxBaseList sapMComboBoxList sapMSelectList']/li[text()='" + value + "']");
        }

        [FindsBy(How = How.XPath, Using = "//*[@title='Relationship']/following::input[5][@class='sapMInputBaseInner sapMComboBoxInner']")]
        private IWebElement SSCChildRelationshipTxt;

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
        public By SSCCustomerContactAddressCheckbox { get => By.XPath("//input[@type='CheckBox']/ancestor::td/..//span[text()='Address']"); }
        //public By SSCAddressAlignToPhone(string PhoneNumber) { return By.XPath("//a[text()='+44 " + PhoneNumber + "']/ancestor::td/..//span[text()='Address']"); }
        public By SSCAddressAlignToPhone(string PhoneNumber) { return By.XPath("//a[contains(text(),'" + PhoneNumber + "')]/ancestor::td/..//span[text()='Address']"); }
        public By SSCCustomerAddressFieldData(string AddressValue)
        {
            return By.XPath("//span[contains(text(),'" + AddressValue + "')]");
        }
        public By SSCCustomerAddressLinkData(string Value) { return By.XPath("//a[text()='" + Value + "']"); }

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Phone']/following::span)[1]")]
        private IWebElement SSCCustomerPhone_Field1;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Phone']/following::span)[54]")]
        private IWebElement SSCCustomerPhone_Field2;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Phone']/following::div)[258]//div[3]/div[1]/div")]
        private IWebElement SSCCustomerPhone_Field3;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Date of Birth']/following::input[1]")]
        private IWebElement SSC_DOB_Txtbox;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Date of Birth']/following::span[1]")]
        private IWebElement SSC_DOB_Field;

        [FindsBy(How = How.XPath, Using = "//span[text()='Edit']/following::td/..//*[@class='sapMCbBg sapMCbHoverable sapMCbMark']")]
        private IWebElement SSCEditCheckBox;
        //        [FindsBy(How = How.XPath, Using = "(//*[@value='Profile data']//preceding::input[1])[1]")]
        [FindsBy(How = How.XPath, Using = "//*[@value='Profile data']/preceding::div[1]")]
        private IWebElement SSCProfileDataEditCheckBox;

        [FindsBy(How = How.XPath, Using = "//*[text()='Phone']/following::td/..//*[@class='sapMInputBaseInner']")]
        private IWebElement SSCPhonenumberfieldinEditmode;
        public By SSCCustomerPhonenumber(string phonenumber) { return By.XPath("//*[text()='Phone']/following::td/..//*[@class='sapMInputBaseInner'][@value='" + phonenumber + "']"); }

        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;
        [FindsBy(How = How.XPath, Using = "//button[@title='Create']//span[contains(@id,'button')][contains(@id,'-img')]")]
        private IWebElement SSCCreateButton;
        //[FindsBy(How = How.XPath, Using = "//*[@class='sapMComboBoxInner sapMInputBaseInner'][contains(@id,'BOW')]")] -> changed by Ajay 02.11.22
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMInputBaseInner sapMComboBoxInner'][contains(@id,'BOW')]")]
        private IWebElement SSCCustomerType;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Full Account']")]
        private IWebElement SSC_Dropdown_Fullaccount;
        [FindsBy(How = How.XPath, Using = "//*[text()='Last Name']//preceding::input[1]")]
        private IWebElement SSCNew_Firstname;
        [FindsBy(How = How.XPath, Using = "//*[text()='Date of Birth']//preceding::input[1]")]
        private IWebElement SSCNew_Lastname;
        [FindsBy(How = How.XPath, Using = "//*[text()='E-Mail']//following::input[1]")]
        private IWebElement SSCNew_Email;
        [FindsBy(How = How.XPath, Using = "//*[text()='Date of Birth']//following::input[1]")]
        private IWebElement SSCNew_DOB;
        [FindsBy(How = How.XPath, Using = "//*[text()='Phone']//following::input[1]")]
        private IWebElement SSCNew_Phone;
        [FindsBy(How = How.XPath, Using = "//*[text()='Dialing Code']//following::input[1]")]
        private IWebElement SSCDialingCode;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapUiIcon sapUiIconMirrorInRTL sapUiIconPointer sapMInputBaseIcon'][contains(@id,'849')]")]
        private IWebElement SSCDialingCodeArrow;
        //[FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='GB - +44']")]
        [FindsBy(How = How.XPath, Using = "//li[@class='sapMLIB sapMLIB-CTX sapMLIBShowSeparator sapMLIBTypeActive sapMLIBActionable sapMLIBHoverable sapMLIBFocusable sapMSLI sapMComboBoxBaseItem']//..//div[text()='GB - +44']")]
        private IWebElement SSCDialingCode_Dropdown_GB;

        [FindsBy(How = How.XPath, Using = "(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[3]")]
        private IWebElement SSC_TermsandCondns_Toggle;
        [FindsBy(How = How.XPath, Using = "(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[4]")]
        private IWebElement SSC_PrivacyPolicy_Toggle;
        //[FindsBy(How = How.XPath, Using = "//*[text()='Band/Grade']/following::input[1][@class='sapMComboBoxInner sapMInputBaseInner']")]-> changed by Ajay 02.11.22
        [FindsBy(How = How.XPath, Using = "//*[text()='Band/Grade']/following::input[1]")]
        private IWebElement SSC_Qatari_BandGrade_dropdown;
        [FindsBy(How = How.XPath, Using = "//*[text()='Discount Ceiling value']/following::input[1]")]
        private IWebElement SSC_Disc_Ceilvalue;
        [FindsBy(How = How.XPath, Using = "//*[text()='I have made the Customer aware of the T&Cs']/following::span[2]")]
        private IWebElement SSC_Customer_Aware_TC_ToggleBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='I have made the Customer aware of the Privacy Policy']/following::span[2]")]
        private IWebElement SSC_Customer_Aware_PP_ToggleBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Rewards Is Active']/following::span[2]")]
        private IWebElement SSC_RewardsActive_ToggleBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Priviledged Type']//following::input[1]")]
        private IWebElement SSC_Privilegetype_dropdown;
        [FindsBy(How = How.XPath, Using = "//*[text()='Rewards Account']/following::span[2]")]
        private IWebElement SSC_RewardsAccount_ToggleBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Spouse Of']//following::input[1]")]
        private IWebElement SSC_Spouse_SearchBox;
        [FindsBy(How = How.XPath, Using = "//*[text()='Assign New Card']")]
        private IWebElement SSC_ActivateCard_btn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Deactivate Card']")]
        private IWebElement SSC_DeactivateCard_btn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Reason for deactivation']/following::div[contains(@id,'dropdownlistbox')][1]")]
        private IWebElement SSC_Card_deactivate_dropdown;
        //[FindsBy(How = How.XPath, Using = "//ul[@class='sapMComboBoxBaseList sapMComboBoxList sapMSelectList']/li[text()='Stolen'])")]
        [FindsBy(How = How.XPath, Using = "//div[@class='sapMSLITitleOnly'][text()='Stolen']")]
        private IWebElement SSC_Card_deactivate_Stolen;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reason For Status']/following::span[text()='Assigned']")]
        private IWebElement SSC_CardAssigned_Status;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Card ID']/following::a[1]")]
        private IWebElement SSC_Card_Assigned;
        string card_assigned = "";
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Name On Card 1']/following::input[1]")]
        private IWebElement SSC_UserFirstName_Txtbox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Name On Card 1']/following::input[2]")]
        private IWebElement SSC_UserLastName_Txtbox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Send Card to Customer']")]
        private IWebElement SSC_SendCardtocustomer;
        [FindsBy(How = How.XPath, Using = "//*[text()='Request to send card to customer has been sent  |  Your entries have been saved.  ']")]
        private IWebElement SSC_SendNewCardStatusRibbon;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Address Line 1']/following::input[1]")]
        private IWebElement SSC_ContactDetails_AddressLine1;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Address Line 1']/following::input[2]")]
        private IWebElement SSC_ContactDetails_AddressLine2;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Address Line 1']/following::input[3]")]
        private IWebElement SSC_ContactDetails_AddressLine3;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Country/Region']/following::input[1]")]
        private IWebElement SSC_ContactDetails_Country;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='City']/following::input[1]")]
        private IWebElement SSC_ContactDetails_City;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Postal Code']/following::input[1]")]
        private IWebElement SSC_ContactDetails_Postalcode;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Name']/following::input[1]")]
        private IWebElement SSC_CustomerMergerName;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='First Customer']/following::input[1]")]
        private IWebElement SSC_Customer_MergeUserName1;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Second Customer']/following::input[1]")]
        private IWebElement SSC_Customer_MergeUserName2;
        public By TenpTicketAvailDateSSC(string AvailDate) { return By.XPath("//div[@aria-label='" + AvailDate + "']/span"); }
        [FindsBy(How = How.XPath, Using = "//bdi[text()='New  ']")]
        private IWebElement TenpTicketNewSSC;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Cancel ']")]
        private IWebElement TenpTicketCancelSSC;
        [FindsBy(How = How.XPath, Using = "//iframe[contains(@src,'harrodscalendappcalendapp')]")]
        private IWebElement SSCTicketDetailCalendarFrame;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Add']")]
        private IWebElement SSC_Relationship_AddBtn;
        [FindsBy(How = How.XPath, Using = "(//*[text()='Relationship Type']/following::div/input)[1]")]
        private IWebElement SSC_RelationshipType_dropdown;
        [FindsBy(How = How.XPath, Using = "(//*[text()='Relationship Type']/following::div/span)[1]")]
        private IWebElement SSC_RelationshipType_arrow_dropdown;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Has the Primary Member']")]
        private IWebElement SSC_RelationshipType_Primary_Member;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Has Secondary Member']")]
        private IWebElement SSC_RelationshipType_Secondary_Member;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Business Partner']/following::div/input)[1]")]
        private IWebElement SSC_BusinessPartner_Txtbox;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Add'])[1]")]
        private IWebElement SSC_RelationshipPopup_AddBtn;
        public By SSC_Relationship_Member(string member)
        {
            return By.XPath("//*[contains(text(),'" + member + "')]");
        }
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='SSC Account ID']/following::div/span)[1]")]
        private IWebElement SSC_GetTestgroupid;
        //Ticket Creation screen webelements

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Type']/following::input[1]")]
        private IWebElement SSC_TicketType_Txtbox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Source']/following::input[1]")]
        private IWebElement SSC_TicketSource_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Individual Customer']/following::input[1]")]
        private IWebElement SSC_TicketCustomer_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reported By']/following::input[1]")]
        private IWebElement SSC_TicketReportedBy_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Subject']/following::input[1]")]
        private IWebElement SSC_TicketSubject_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Ticket Type Category']/following::input[1]")]
        private IWebElement SSC_TicketTypeCategory_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Contact Category']/following::input[1]")]
        private IWebElement SSC_TicketContactCategory_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Subject Category']/following::input[1]")]
        private IWebElement SSC_TicketSubjectCategory_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Subject Details Category']/following::input[1]")]
        private IWebElement SSC_TicketSubjectDetailsCategory_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Item Category']/following::input[1]")]
        private IWebElement SSC_TicketItemCategory_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Agent']/following::input[1]")]
        private IWebElement SSC_TicketAgent_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Team']/following::input[1]")]
        private IWebElement SSC_TicketTeam_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Business Area']/following::input[1]")]
        private IWebElement SSC_TicketBusinessArea_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Fulfillment point']/following::input[1]")]
        private IWebElement SSC_TicketFulfillmentpt_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Online Division']/following::input[1]")]
        private IWebElement SSC_TicketOnlineDiv_TxtBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Brand']/following::input[1]")]
        private IWebElement SSC_TicketBrand_TxtBox;
        [FindsBy(How = How.XPath, Using = "//iframe[@title='Editable area. Press F10 for toolbar.']")]
        private IWebElement SSC_TicketDescriptionFrame;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save and Open']")]
        private IWebElement SSC_SaveOpen_Btn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Target Tier']/following::input[1]")]
        //[FindsBy(How = How.XPath, Using = "//bdi[text()='Next Tier']/following::input[1]")]
        private IWebElement SSC_Ticket_TargetTierDropdown;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Rewards Points']/following::input[1]")]
        private IWebElement SSC_Ticket_RewardsPoints;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Status Points']/following::input[1]")]
        private IWebElement SSC_Ticket_StatusPoints;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Status Points To Be Adjusted']/following::input[1]")]
        private IWebElement SSC_Ticket_AdjustStatusPoints;
        [FindsBy(How = How.XPath, Using = "//*[text()='Status Points To Be Adjusted']")]
        private IWebElement SSC_StatusPointsLbl;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reason']/following::input[1]")]
        private IWebElement SSC_StatusAdjust_Reason;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Status']/following::div/span)[1]")]
        private IWebElement SSC_Approval_Status;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Summary']/following::input)[1]")]
        private IWebElement SSC_TierChangeSummary;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Status']/following::div/../input)[1]")]
        private IWebElement SSC_Status_Dropdown;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Customer Tier']/following::div)[1]")]
        private IWebElement SSC_CustomerTier_Status;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Subject Details Category']/following::div)[1]")]
        private IWebElement SSC_Customer_SubDetails;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='CDC ID']/following::div/span)[1]")]
        private IWebElement SSC_CdcID;
        public By SpanSSCText(string text) { return By.XPath("//span[contains(text(),'" + text + "')]"); }

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

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='searchUserId']")]
        private IWebElement ACCDCIdSearch;

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='dateFromDate']")]
        private IWebElement ACCHierArchyFromDate;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='dateToDate']")]
        private IWebElement ACCHierArchyToDate;
        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='txtUid']")]
        private IWebElement ACCHierArchy_GrpID;

        [FindsBy(How = How.XPath, Using = "//button[@type='submit'][text()='Search']")]
        private IWebElement ACCustomerSearchBtn;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='User Id']")]
        private IWebElement ACUserSearch;

        [FindsBy(How = How.XPath, Using = "//h4[text()='Current Tier']/../following-sibling::span")]
        private IWebElement ACCustomerCurrentTierData;

        [FindsBy(How = How.XPath, Using = "//h4[text()='Available Points']/../following-sibling::span")]
        private IWebElement ACCustomerRewardsPointsData;

        public By ACCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }

        [FindsBy(How = How.XPath, Using = "//input[@formcontrolname='uid']")]
        private IWebElement ACOrderCDCIdSearch;
        public By ACOrdersGridData(string cdcId) { return By.XPath("//span[text()='" + cdcId + "']"); }
        public By ACOrdersIdGridData(string cdcId) { return By.XPath("(//span[text()='" + cdcId + "']/../../following-sibling::td/a)[1]"); }
        public By ACCustomerEarnedPoints(string cdcId) { return By.XPath("//span[text()='" + cdcId + "']//..//..//following-sibling::td[4]//span"); }


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

        [FindsBy(How = How.XPath, Using = "//span[text()='Campaigns']")]
        private IWebElement SMCNavCampaigns;

        [FindsBy(How = How.Id, Using = "application-MarketingContact-showList-component---worklist--contactToolbarSearchField-I")]
        private IWebElement SMCCustomersSearchEdit;

        [FindsBy(How = How.Id, Using = "(//div[@id='application-Initiative-manageCampaignFlow-component---worklist--searchField-search'])[1]")]
        private IWebElement SMCSearchButton;
        [FindsBy(How = How.Id, Using = "(//input[@id='application-Initiative-manageCampaignFlow-component---worklist--searchField-I'])[1]")]
        private IWebElement SMCCampaignSearchBox;
        //[FindsBy(How = How.Id, Using = "(//bdi[text()='Target Group'])[2]")]
        [FindsBy(How = How.XPath, Using = "//button//bdi[text()='Target Group']")]
        private IWebElement SMCTargetGroupMenu;
        //        [FindsBy(How = How.XPath, Using = "//a[text()='Mini Harrods birthday week adhoc TG ']")] --> changed by ajay 08.02.2023
        [FindsBy(How = How.XPath, Using = "//a[text()='Mini Harrods birthday week adhoc segment ']")]
        private IWebElement SMCMiniHarrodsBdayLink;
        [FindsBy(How = How.XPath, Using = "//div[@class='sapHpaGsegLibGridFormCellContent']/following::a[text()='Mini Harrods birthday week adhoc segment']")]
        private IWebElement SMCMiniHarrodsBdaySegmentLink;
        [FindsBy(How = How.XPath, Using = "(//*[text()='INSERT EMAIL']/following::button[@title='Click to open or close the segment action menu'])[1]")]
        private IWebElement SMCSegmentActionMenu;
        //[FindsBy(How = How.XPath, Using = "(//span[@class='sapUiMenuButtonIco'])[2]")]
        [FindsBy(How = How.XPath, Using = "//*[@class='sapUiMnuItmTxt'][text()='Change Segment']")]
        private IWebElement SMC_SAPMenu_ChangeSegment;
        //[FindsBy(How = How.XPath, Using = "((//label[normalize-space()='Value:'])[1]/following::input)[1]")]
        [FindsBy(How = How.XPath, Using = "//*[text()='Value:']/following::input[1]")]
        private IWebElement SMC_SAPMenu_ChangeSegment_Emailbox;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Harrods: Contact Based Segmentation'])[2]")]
        private IWebElement SMC_SAPMenu_ContactBasedSegmentation;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Campaigns']")]
        private IWebElement SMC_SubMenuCampaigns;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Overview']")]
        private IWebElement SMC_SubMenuOverview;
        [FindsBy(How = How.XPath, Using = "(//div[@class='sapUiTableCellInner']/*[contains(text(),'Mini Harrods birthday week adhoc Camp')])[1]")]
        private IWebElement SMC_AdhocCampaign_TABLELink;
        public By SMCCustomersGridData(string text) { return By.XPath("(//a[text()='" + text + "'])"); }
        public By SMCCustomersGridEmailData(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Personal Data']")]
        private IWebElement SMCCustomersSubtabPersonalData;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Current Tier']/following::div/span)[1]")]
        private IWebElement SMCCustomerTierData;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='IsRewardOptin']/following::span[2]")]
        private IWebElement SMCCustomerRewardOptinStatus;

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

        public By SMCChannelPermissionStatus(string ChannelName) { return By.XPath("(//span[contains(@id,'MarketingPermissionsBlock-Collapsed')][text()='" + ChannelName + "'])[1]/../../following-sibling::td//span[@dir='ltr']"); }
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
        public By SMCInterestFilterCheckbox(string FilterName) { return By.XPath("//bdi[text()='" + FilterName + "']/ancestor::tr//input"); }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'ContactID-inner')]")]
        private IWebElement SMCInterestContactIdSearch;

        private By SMCMiniHarrodsMember(string text)
        { return By.XPath("//bdi[text()='Mini Harrods Member']//parent::span//parent::span//parent::div//following-sibling::div//div//span[text()='" + text + "']"); }
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reward Card No']/following::span[2]")]
        private IWebElement SMC_RewardCardNumber_TextRO;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Mini-Harrods']//parent::span//parent::div//following-sibling::div//span//bdi")]
        private IWebElement SSCMiniHarrodsChildrenCount;

        [FindsBy(How = How.XPath, Using = "//span[@role='img'][@title='Loyalty']/following-sibling::span")]
        private IWebElement SMCInteractionLoyaltyPannelCount;

        #endregion

        List<string> consentselection = new List<string>();
        List<string> interestselection = new List<string>();

        //#region CDC Events
        //public void PerformCDCLogin(string userName, string password)
        //{
        //    WebHandlers.Instance.EnterText(CDCloginEmail, userName, $"Entered {userName} for login email");
        //    WebHandlers.Instance.EnterText(CDCloginPassword, password, $"Entered password for login email");
        //    WebHandlers.Instance.ClickByJsExecutor(CDCloginButton, "Login");
        //    BrowserDriver.Sleep(10000);
        //    if (OTPPrompt.Displayed)
        //        MessageBox.Show("Enter OTP and Navigate to CDC home screen then click OK");
        //}

        //public void NavigateToCDCIdentityAccessProfiles()
        //{
        //    BrowserDriver.Sleep(5000);
        //    Actions action = new Actions(driver);
        //}
        //#endregion


        #region SSC Events
        //public void PerformSSCLogin(string userName, string password)
        //{
        //    WebHandlers.Instance.EnterText(SSCloginEmail, userName, $"Entered {userName} for login email");
        //    WebHandlers.Instance.EnterText(SSCloginPassword, password, $"Entered password for login email");
        //    WebHandlers.Instance.ClickByJsExecutor(SSCloginButton, "Login");
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(10000);
        //}

        //public void NavigateToSSCCustomers()
        //{
        //    BrowserDriver.Sleep(3000);
        //    if (driver.FindElements(SSCNavAdminCustomersTree).Count != 0)
        //    {
        //        driver.FindElement(SSCNavAdminCustomersTree).Click();
        //    }
        //    BrowserDriver.Sleep(3000);
        //    //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
        //    WebHandlers.Instance.Click(SSCNavCustomers);
        //    //try { WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSearchIcon); }
        //    //catch { WebHandlers.Instance.Click(SSCNavCustomers); }
        //    BrowserDriver.Sleep(4000);
        //}

        //public void NavigateToSSCCustomers_GroupAccounts()
        //{
        //    Actions actions = new Actions(driver);
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCNavAdminCustomersTree).Click();
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers_GrpAccount);
        //    actions.MoveToElement(SSCNavCustomers_GrpAccount).Click().Build().Perform();
        //    BrowserDriver.Sleep(2000);
        //    SSCNavCustomers_GrpAccount.Click();
        //    //bool groupaccount = WebHandlers.Instance.IsElementPresent(By.XPath("//div[@id='__title0']/span[text()='Group Accounts']"));
        //    //if (!groupaccount)
        //    //{
        //    //    do
        //    //    {
        //    //        driver.Navigate().Refresh();
        //    //        BrowserDriver.Sleep(3000);
        //    //        driver.FindElement(SSCNavAdminCustomersTree).Click();
        //    //        BrowserDriver.Sleep(2000);
        //    //        //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers_GrpAccount);
        //    //        actions.MoveToElement(SSCNavCustomers_GrpAccount).Click().Build().Perform();
        //    //        BrowserDriver.Sleep(2000);
        //    //    } while (!groupaccount);
        //    //}
        //}

        //public void NavigateToSSCSales_Purchases()
        //{
        //    driver.FindElement(SSCNavAdminSalesTree).Click();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(SSCNavSales_Purchases);
        //    BrowserDriver.Sleep(2000);
        //}

        //public void SSCGroupAccountCreation(string groupaccountname, string primarymember)
        //{
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCGroupAccountHeader);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCTicketCreateBtn);
        //    BrowserDriver.Sleep(5000);

        //    SSC_GroupAccountName_Txt.SendKeys(groupaccountname);
        //    BrowserDriver.Sleep(3000);
        //    SSC_PrimaryMember_Txt.SendKeys(primarymember + Keys.Enter);
        //    //WebHandlers.Instance.EnterText(SSC_PrimaryMember_Txt, primarymember);
        //    BrowserDriver.Sleep(5000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}
        //public void SSCGroupAccountCreation(string groupaccountname)
        //{
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCGroupAccountHeader);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCTicketCreateBtn);
        //    BrowserDriver.Sleep(3000);
        //    //WebHandlers.Instance.EnterText(SSC_GroupAccountName_Txt, groupaccountname);
        //    SSC_GroupAccountName_Txt.SendKeys(groupaccountname);
        //    //WebHandlers.Instance.EnterText(SSC_PrimaryMember_Txt, primarymember);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void NavigateToSSCCardManagement()
        //{
        //    if (driver.FindElements(SSCNavAdminCardManagementTree).Count != 0)
        //    {
        //        //driver.FindElement(SSCNavAdminCardManagementTree).Click();
        //        WebHandlers.Instance.ClickByJsExecutor(SSCNavAdminCardManagementTree);
        //    }
        //    BrowserDriver.Sleep(3000);
        //    //WebHandlers.Instance.ClickByJsExecutor(SSCNavScheduleCardCreation);
        //}

        //public void NavigateToSSCReplenishment()
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.ClickByJsExecutor(SSCNavReplenishment);

        //}
        //public void NavigateToSSC_Service()
        //{
        //    if (driver.FindElements(SSCNavAdminServiceTree).Count != 0)
        //    {
        //        driver.FindElement(SSCNavAdminServiceTree).Click();

        //    }
        //    BrowserDriver.Sleep(2000);
        //}

        //public void SearchCustomerAndNavigatetoRelationshipsTab(string email, string fullname, string phonenumber)
        //{
        //    //Search the customer
        //    SearchCustomerOnSSC(fullname, email);

        //    //Navigate to Relationships tab
        //    WebHandlers.Instance.Click(SSCCustomersRelationships);
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    BrowserDriver.Sleep(2000);
        //}

        //public void SearchforTestGroup(string testgroupname)
        //{
        //    WebHandlers.Instance.Click(SSCCustomersSearchIcon);
        //    SearchGroupOnSSC(testgroupname);
        //}

        //public void AddPrimaryMemberinRelationships(string primarymember)
        //{
        //    WebHandlers.Instance.Click(SSCCustomersRelationships);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSC_Relationship_AddBtn);
        //    BrowserDriver.Sleep(3000);

        //    //WebWaitHelper.Instance.WaitForElementPresence(SSC_RelationshipType_dropdown);
        //    //SSC_RelationshipType_dropdown.Click();
        //    SSC_RelationshipType_arrow_dropdown.Click();
        //    BrowserDriver.Sleep(2000);
        //    SSC_RelationshipType_Primary_Member.Click();
        //    BrowserDriver.Sleep(2000);
        //    //SSC_RelationshipType_dropdown.SendKeys("Has the Primary Member");
        //    //WebHandlers.Instance.EnterText(SSC_RelationshipType_dropdown, "Has the Primary Member");

        //    //WebHandlers.Instance.EnterText(SSC_BusinessPartner_Txtbox, primarymember);
        //    SSC_BusinessPartner_Txtbox.Click();
        //    SSC_BusinessPartner_Txtbox.SendKeys(primarymember);

        //    WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
        //}
        //public void AddSecondaryMemberinRelationships(string secondarymember)
        //{
        //    if (!secondarymember.Equals(""))
        //    {
        //        Actions actions = new Actions(driver);
        //        //driver.Navigate().Refresh();
        //        //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
        //        BrowserDriver.Sleep(3000);
        //        //actions.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.Click(SSC_Relationship_AddBtn);
        //        BrowserDriver.Sleep(2000);
        //        //WebHandlers.Instance.EnterText(SSC_RelationshipType_dropdown, "Has Secondary Member");
        //        //SSC_RelationshipType_dropdown.SendKeys("Has Secondary Member");
        //        SSC_RelationshipType_arrow_dropdown.Click();
        //        BrowserDriver.Sleep(2000);
        //        SSC_RelationshipType_Secondary_Member.Click();
        //        BrowserDriver.Sleep(2000);
        //        //BrowserDriver.Sleep(2000);
        //        //WebHandlers.Instance.EnterText(SSC_BusinessPartner_Txtbox, secondarymember);
        //        //SSC_BusinessPartner_Txtbox.SendKeys(secondarymember);
        //        SSC_BusinessPartner_Txtbox.Click();
        //        SSC_BusinessPartner_Txtbox.Clear();
        //        SSC_BusinessPartner_Txtbox.SendKeys(secondarymember);
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.Click(SSCSaveButton);
        //    }
        //}
        //public void ValidateMemberAddedUnderRelationships(string member)
        //{
        //    BrowserDriver.Sleep(3000);
        //    if (!member.Equals(""))
        //    {
        //        //Boolean member_present = WebHandlers.Instance.IsElementPresent(SSC_Relationship_Member(member));
        //        int ssc_member = driver.FindElements(SSC_Relationship_Member(member)).Count();
        //        Assert.IsTrue(ssc_member > 0, "Member is not displayed as expected");
        //    }
        //}

        //public string GetGroupID()
        //{
        //    string groupid = WebHandlers.Instance.GetTextOfElement(SSC_GetTestgroupid);
        //    return groupid;
        //}
        //public void ValidateErrormessageNonRewardMember()
        //{
        //    BrowserDriver.Sleep(2000);
        //    int invalidmsgcount = driver.FindElements(By.XPath("//span[contains(text(),'not valid')]")).Count;
        //    Assert.IsTrue(invalidmsgcount > 0, "Error Message is not displayed");
        //}

        //public void ValidateErrormessageforExtraMember()
        //{
        //    BrowserDriver.Sleep(2000);
        //    int invalidmsgcount = driver.FindElements(By.XPath("//span[contains(text(),'This Group cannot be assigned more than 5 members')]")).Count;
        //    Assert.IsTrue(invalidmsgcount > 0, "Error Message is not displayed");
        //}

        //public void NavigateToSSC_Service_To_Ticket()
        //{

        //    //driver.FindElement(SSC_Nav_Tickets).Click();
        //    BrowserDriver.Sleep(5000);
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNavTickets);
        //    WebHandlers.Instance.ClickByJsExecutor(SSCNavTickets);
        //    BrowserDriver.Sleep(3000);
        //}

        //public void CreateNewSSCServiceTicket()
        //{
        //    WebHandlers.Instance.Click(SSCTicketCreateBtn);
        //    BrowserDriver.Sleep(3000);
        //}

        //public void CreateEnquiryTicket_SSCService(Dictionary<string, string> CustomerTicketData)
        //{
        //    WebHandlers.Instance.WaitForPageLoad();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
        //    BrowserDriver.Sleep(4000);
        //    //driver.FindElement(SSCNewTicketFields("Type")).Clear();
        //    if (!CustomerTicketData["Type"].Equals("General"))
        //    {
        //        WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), CustomerTicketData["Type"]);
        //    }
        //    BrowserDriver.Sleep(3000);
        //    //driver.FindElement(SSCNewTicketFields("Type")).SendKeys(CustomerTicketData["Type"]);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), CustomerTicketData["Source"]);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), CustomerTicketData["IndividualCustomer"]);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), CustomerTicketData["Subject"]);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), CustomerTicketData["ContactCategory"]);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), CustomerTicketData["SubjectCategory"]);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), CustomerTicketData["SubjectDetailsCategory"]);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Item Category")), CustomerTicketData["ItemCategory"]);
        //    BrowserDriver.Sleep(2000);

        //    driver.FindElement(SSCNewTicketFields("Team")).Clear();
        //    driver.FindElement(SSCNewTicketFields("Team")).SendKeys(CustomerTicketData["Team"]);
        //    BrowserDriver.Sleep(2000);

        //    //Performing ticket Save and close
        //    WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + CustomerTicketData["Subject"]).DoubleClick().Build().Perform();
        //    WebHandlers.Instance.SwithBackFromFrame();
        //    BrowserDriver.Sleep(4000);
        //    //WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
        //    driver.FindElement(SSCNewTicketFields("Brand")).Click();
        //    driver.FindElement(SSCNewTicketFields("Brand")).SendKeys(CustomerTicketData["Brand"]);

        //    BrowserDriver.Sleep(3000);
        //    //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Business Area")), CustomerTicketData["BusinessArea"]);
        //    //WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Business Area")));
        //    driver.FindElement(SSCNewTicketFields("Business Area")).SendKeys(CustomerTicketData["BusinessArea"] + "\n");
        //    BrowserDriver.Sleep(3000);
        //    BrowserDriver.GetDriver().SwitchTo().DefaultContent();
        //    //  WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment point")), CustomerTicketData["FulfillmentPoint"]);
        //    driver.FindElement(SSCNewTicketFields("Fulfillment point")).SendKeys(CustomerTicketData["FulfillmentPoint"]);
        //    BrowserDriver.Sleep(3000);

        //    // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), CustomerTicketData["OnlineDivision"]);
        //    driver.FindElement(SSCNewTicketFields("Online Division")).SendKeys(CustomerTicketData["OnlineDivision"]);
        //    BrowserDriver.Sleep(3000);

        //    //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), CustomerTicketData["Source"]);
        //    driver.FindElement(SSCNewTicketFields("Source")).Clear();
        //    driver.FindElement(SSCNewTicketFields("Source")).SendKeys(CustomerTicketData["Source"]);
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCNewTicketFields("Subject")).SendKeys(CustomerTicketData["Subject"]);
        //    BrowserDriver.Sleep(2000);
        //    SSCNewTicketSaveOpen.Click();
        //    BrowserDriver.Sleep(6000);

        //}

        //public void EditInquiryTicket()
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //}

        //public void ChangeTier(string tier)
        //{
        //    BrowserDriver.Sleep(5000);
        //    //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
        //    SSCNewTicketEditIcon.Click();
        //    BrowserDriver.Sleep(5000);
        //    SSC_TierChangeSummary.SendKeys("Automated Tier Upgrade");
        //    //WebWaitHelper.Instance.WaitForElementPresence(SSC_Ticket_TargetTierDropdown,TimeSpan.FromSeconds(120));
        //    driver.SwitchTo().DefaultContent();
        //    //driver.FindElement(By.XPath("//*[text()='Rewards']")).Click();
        //    WebHandlers.Instance.Click(SSC_Ticket_TargetTierDropdown);
        //    //WebHandlers.Instance.EnterText(SSC_Ticket_TargetTierDropdown, tier);
        //    SSC_Ticket_TargetTierDropdown.SendKeys(tier);
        //    //SSC_Ticket_TargetTierDropdown.SendKeys(Keys.Tab);           

        //}

        //public void ChangeTierfromGreen(string tier)
        //{
        //    Actions actions = new Actions(driver);
        //    driver.Navigate().Refresh();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
        //    //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        //    //wait.Until(ExpectedConditions.ElementToBeClickable(SSCNewTicketEditIcon));
        //    try
        //    {
        //        BrowserDriver.Sleep(3000);
        //        actions.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //        //SSCNewTicketEditIcon.Click();
        //    }
        //    catch (StaleElementReferenceException)
        //    {
        //        // driver.Navigate().Refresh();
        //        BrowserDriver.Sleep(4000);
        //        actions.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //        //SSCNewTicketEditIcon.Click();
        //    }

        //    BrowserDriver.Sleep(3000);
        //    try
        //    {
        //        SSC_Status_Dropdown.Clear();
        //        SSC_Status_Dropdown.SendKeys("Open" + "\n");
        //        BrowserDriver.Sleep(3000);
        //        //driver.FindElement(SSCNewTicketFields("Assigned to")).SendKeys("Anusree Nair");
        //        //BrowserDriver.Sleep(3000);

        //        SSC_TierChangeSummary.SendKeys("Test Summary");
        //        BrowserDriver.Sleep(2000);
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        BrowserDriver.Sleep(2000);
        //        SSCNewTicketEditIcon.Click();
        //        BrowserDriver.Sleep(4000);
        //        SSC_Status_Dropdown.Clear();
        //        SSC_Status_Dropdown.SendKeys("Open" + "\n");
        //        BrowserDriver.Sleep(3000);
        //        //driver.FindElement(SSCNewTicketFields("Assigned to")).SendKeys("Anusree Nair");
        //        //BrowserDriver.Sleep(3000);
        //        SSC_TierChangeSummary.SendKeys("Test Summary");
        //        BrowserDriver.Sleep(2000);
        //    }
        //    SSC_Ticket_TargetTierDropdown.Clear();
        //    BrowserDriver.Sleep(2000);
        //    SSC_Ticket_TargetTierDropdown.SendKeys(tier + "\n");
        //    BrowserDriver.Sleep(2000);
        //    try
        //    {
        //        //actions.MoveToElement(driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']"))).Build().Perform();
        //        driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']")).Click();
        //        BrowserDriver.Sleep(3000);
        //    }
        //    catch (ElementClickInterceptedException)
        //    {
        //        string statuspoints = driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']/following::input[1]")).Text;
        //        BrowserDriver.Sleep(3000);
        //    }
        //    catch (StaleElementReferenceException)
        //    {
        //        string statuspoints = driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']/following::input[1]")).Text;
        //        BrowserDriver.Sleep(3000);
        //    }
        //    //WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(By.XPath("//*[text()='Status Points To Be Adjusted']"))); 

        //    //WebWaitHelper.Instance.WaitForElementPresence(SSC_StatusAdjust_Reason);
        //    //SSC_StatusAdjust_Reason.Clear();
        //    //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing");
        //    //BrowserDriver.Sleep(3000);


        //}

        //public void GestureSelection()
        //{
        //    try
        //    {
        //        WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Single/Multiple")), "Single");
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Dining Experience Vouchers");
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Dining Voucher Value")), "£15 - Hot Beverage & Dessert in Harrods Cafe");
        //        BrowserDriver.Sleep(3000);
        //    }
        //    catch (NoSuchElementException)
        //    {

        //    }

        //    BrowserDriver.Sleep(3000);
        //    Actions ContentAction = new Actions(driver);
        //    //BrowserDriver.Sleep(2000);
        //    //WebWaitHelper.Instance.WaitForElement(SSC_StatusAdjust_Reason);
        //    //SSC_StatusAdjust_Reason.Click();
        //    BrowserDriver.Sleep(2000);
        //    ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("    Loyalty Testing" + "\n").DoubleClick().Build().Perform();

        //    BrowserDriver.Sleep(2000);
        //    SSC_StatusAdjust_Reason.Clear();
        //    SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");

        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void ValidateStatusPointsafterTierChange()
        //{
        //    string RewardsPoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_RewardsPoints);
        //    string StatusPoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_StatusPoints);
        //    string adjustStatuspoints = WebHandlers.Instance.GetTextOfElement(SSC_Ticket_AdjustStatusPoints);

        //    //int rewardpoint = Int16.Parse(RewardsPoints);
        //    //int statuspoints = Int16.Parse(StatusPoints);
        //    //int adjust_statuspoints = Int16.Parse(adjustStatuspoints);

        //    //WebHandlers.Instance.EnterText(SSC_StatusAdjust_Reason, "Loyalty Testing");

        //    BrowserDriver.Sleep(3000);
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().Build().Perform();
        //    ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("    Loyalty Testing" + "\n").DoubleClick().Build().Perform();
        //    //SSC_StatusAdjust_Reason.Click();
        //    BrowserDriver.Sleep(2000);
        //    SSC_StatusAdjust_Reason.Clear();
        //    //            SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
        //    SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing");
        //    BrowserDriver.Sleep(3000);

        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Single/Multiple")), "Single");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Dining Experience Vouchers");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Dining Voucher Value")), "£15 - Hot Beverage & Dessert in Harrods Cafe");
        //    BrowserDriver.Sleep(3000);

        //    WebHandlers.Instance.Click(SSCSaveButton);
        //    BrowserDriver.Sleep(2000);
        //    string approval_status = WebHandlers.Instance.GetTextOfElement(SSC_Approval_Status);
        //    //Assert.IsTrue(adjust_statuspoints == (rewardpoint - statuspoints),"Adjusted Status points is incorrect and doesnt match");
        //    driver.FindElement(SSCNewTicketSubTabs("Approval")).Click();
        //    BrowserDriver.Sleep(2000);
        //    //Assert.IsTrue(approval_status.Equals("In Approval"), "Status is not displayed as --In Approval--");

        //}

        //public void ChangeTicketStatustoOpen()
        //{
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    //driver.Navigate().Refresh();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCDetailsEditIcon);
        //    //WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    SSCDetailsEditIcon.Click();
        //    //ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //    BrowserDriver.Sleep(3000);
        //    try
        //    {
        //        //SSC_Status_Dropdown.Clear();
        //        //SSC_Status_Dropdown.SendKeys("Solved" + "\n");
        //        WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //        //SSC_StatusDropdownBtn.Click();
        //        BrowserDriver.Sleep(1000);
        //        SSC_StatusDropdown_TicketOpen.Click();
        //        BrowserDriver.Sleep(1000);
        //    }
        //    catch (Exception e)
        //    {
        //        BrowserDriver.Sleep(4000);
        //        try
        //        {
        //            ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //        }
        //        catch (Exception f)
        //        {

        //        }
        //        BrowserDriver.Sleep(3000);

        //        try
        //        {
        //            SSC_Actions_Btn.Click();
        //            BrowserDriver.Sleep(2000);
        //            SSC_Wihdraw_approval_menu.Click();
        //            BrowserDriver.Sleep(4000);
        //            //SSC_Status_Dropdown.Clear();
        //            //SSC_Status_Dropdown.SendKeys("Solved" + "\n");
        //            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //            //SSC_StatusDropdownBtn.Click();
        //            BrowserDriver.Sleep(1000);
        //            SSC_StatusDropdown_TicketOpen.Click();
        //            BrowserDriver.Sleep(1000);
        //            //}
        //        }
        //        catch (Exception g)
        //        {
        //            BrowserDriver.Sleep(4000);

        //            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //            //SSC_StatusDropdownBtn.Click();
        //            BrowserDriver.Sleep(1000);
        //            SSC_StatusDropdown_TicketOpen.Click();
        //            BrowserDriver.Sleep(1000);
        //        }
        //    }

        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void ChangeTicketStatustoSolved()
        //{
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    //driver.Navigate().Refresh();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCDetailsEditIcon);
        //    //WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    SSCDetailsEditIcon.Click();
        //    //ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //    BrowserDriver.Sleep(3000);
        //    try
        //    {
        //        //SSC_Status_Dropdown.Clear();
        //        //SSC_Status_Dropdown.SendKeys("Solved" + "\n");
        //        WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //        //SSC_StatusDropdownBtn.Click();
        //        BrowserDriver.Sleep(1000);
        //        SSC_StatusDropdown_TicketSolved.Click();
        //        BrowserDriver.Sleep(1000);
        //    }
        //    catch (Exception e)
        //    {
        //        BrowserDriver.Sleep(4000);
        //        try
        //        {
        //            ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //        }
        //        catch (Exception f)
        //        {

        //        }
        //        BrowserDriver.Sleep(3000);
        //        //  if (SSC_Lock_BarMessage.Displayed || SSC_Status_Dropdown.GetAttribute("readonly").Equals("readonly"))
        //        // {
        //        try
        //        {
        //            SSC_Actions_Btn.Click();
        //            BrowserDriver.Sleep(2000);
        //            SSC_Wihdraw_approval_menu.Click();
        //            BrowserDriver.Sleep(4000);
        //            //SSC_Status_Dropdown.Clear();
        //            //SSC_Status_Dropdown.SendKeys("Solved" + "\n");
        //            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //            //SSC_StatusDropdownBtn.Click();
        //            BrowserDriver.Sleep(1000);
        //            SSC_StatusDropdown_TicketSolved.Click();
        //            BrowserDriver.Sleep(1000);
        //            //}
        //        }
        //        catch (Exception g)
        //        {
        //            BrowserDriver.Sleep(4000);
        //            //SSC_Status_Dropdown.Clear();
        //            //SSC_Status_Dropdown.SendKeys("Solved" + "\n"); 
        //            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //            //SSC_StatusDropdownBtn.Click();
        //            BrowserDriver.Sleep(1000);
        //            SSC_StatusDropdown_TicketSolved.Click();
        //            BrowserDriver.Sleep(1000);
        //        }
        //    }


        //    //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    //string title = (string)js.ExecuteScript("arguments[0].value = 'Solved'", SSC_Status_Dropdown);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}
        //public void ChangeTicketStatustoClosed()
        //{
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(4000);
        //    try
        //    {
        //        ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //        //SSC_Status_Dropdown.Clear();
        //        //SSC_Status_Dropdown.SendKeys("Closed" + "\n");
        //        WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //        //SSC_StatusDropdownBtn.Click();
        //        BrowserDriver.Sleep(1000);
        //        SSC_StatusDropdown_TicketClosed.Click();
        //        BrowserDriver.Sleep(1000);
        //    }
        //    catch (Exception e)
        //    {
        //        try
        //        {
        //            ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //            //SSC_Status_Dropdown.Clear();
        //            //SSC_Status_Dropdown.SendKeys("Closed" + "\n");
        //            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //            //SSC_StatusDropdownBtn.Click();
        //            BrowserDriver.Sleep(1000);
        //            SSC_StatusDropdown_TicketClosed.Click();
        //            BrowserDriver.Sleep(1000);
        //        }
        //        catch (Exception w)
        //        {
        //            BrowserDriver.Sleep(2000);
        //            //ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //            BrowserDriver.Sleep(2000);
        //            //SSC_Status_Dropdown.Clear();
        //            //SSC_Status_Dropdown.SendKeys("Closed" + "\n");
        //            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
        //            //SSC_StatusDropdownBtn.Click();
        //            BrowserDriver.Sleep(1000);
        //            SSC_StatusDropdown_TicketClosed.Click();
        //            BrowserDriver.Sleep(1000);
        //        }
        //    }
        //    //BrowserDriver.Sleep(2000);
        //    //try
        //    //{

        //    //    SSC_Status_Dropdown.Clear();
        //    //    SSC_Status_Dropdown.SendKeys("Closed" + "\n");
        //    //}
        //    //catch (Exception e)
        //    //{
        //    //    BrowserDriver.Sleep(2000);              
        //    //    ContentAction.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
        //    //    BrowserDriver.Sleep(2000);
        //    //    SSC_Status_Dropdown.Clear();
        //    //    SSC_Status_Dropdown.SendKeys("Closed" + "\n");
        //    //}

        //    BrowserDriver.Sleep(4000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void ClickTicketCancelButton()
        //{
        //    try
        //    {
        //        driver.FindElement(By.XPath("//*[text()='Cancel']")).Click();
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //}

        //public string ValidateCustomerTierinTicketScreen(ScenarioContext scenarioContext)
        //{
        //    driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
        //    BrowserDriver.Sleep(4000);
        //    string CustomerTier = WebHandlers.Instance.GetTextOfElement(SSC_Customer_SubDetails);
        //    string Cdcid = WebHandlers.Instance.GetTextOfElement(SSC_CdcID);
        //    //scenarioContext.Add("UserCDCId", SSC_CdcID);

        //    //Assert.IsTrue(CustomerTier.Equals("10% Nominated Day"), "Customer Subject Details is not displayed as 10% Nominated day");
        //    Assert.IsTrue(CustomerTier.Equals("Manual tier upgrade"), "Customer Subject Details is not displayed as Manual tier upgrade");
        //    return Cdcid;
        //}

        //public string ValidateCustomerSubjectDetailsinTicketScreen(ScenarioContext scenarioContext)
        //{

        //    BrowserDriver.Sleep(2000);
        //    string CustomerTier = WebHandlers.Instance.GetTextOfElement(SSC_CustomerTier_Status);
        //    string Cdcid = WebHandlers.Instance.GetTextOfElement(SSC_CdcID);
        //    //scenarioContext.Add("UserCDCId", SSC_CdcID);

        //    Assert.IsTrue(CustomerTier.Equals("Gold"), "Customer Tier is not displayed as Gold");
        //    return Cdcid;
        //}

        //public void CreateNewReplenishmentJob(string CardSource, string Replenishment, string MappedRangeFrom, string MappedRangeTo)
        //{
        //    int already_existcheck = 0;
        //    WebHandlers.Instance.WaitForPageLoad();
        //    if (WebHandlers.Instance.WebElementExists(SSCCardReplenishAddButton))
        //    {
        //        WebHandlers.Instance.Click(SSCCardReplenishAddButton);
        //    }
        //    BrowserDriver.Sleep(4000);            
        //    SSC_CardSource.Click();
        //    //SSC_CardSource.SendKeys(CardSource);
        //    SSC_CardSource_Migration.Click();

        //    //WebHandlers.Instance.EnterText(SSCCardRunDescriptionTxtBox, RunDescription);
        //    BrowserDriver.Sleep(2000);
        //    try
        //    {
        //        already_existcheck = driver.FindElements(By.XPath("//*[contains(text(),'already exists')]")).Count();
        //        if (already_existcheck==0)
        //        {                   
        //            SSC_Replenishment.Click();
        //            SSC_Replenishment.Clear();
        //            SSC_Replenishment.SendKeys(Replenishment);
        //            BrowserDriver.Sleep(2000);
        //            SSC_MappedRangeFrom.Click();
        //            SSC_MappedRangeFrom.SendKeys(MappedRangeFrom);
        //            BrowserDriver.Sleep(2000);
        //            SSC_MappedRangeTo.Click();
        //            SSC_MappedRangeTo.SendKeys(MappedRangeTo);
        //            BrowserDriver.Sleep(2000);
        //            //WebHandlers.Instance.Click(SSCCardAddRowBtn);
        //            BrowserDriver.Sleep(2000);
        //            WebHandlers.Instance.Click(SSC_SaveClose_Btn);
        //        }

        //        else
        //        {
        //            WebHandlers.Instance.Click(SSC_Cancel_Btn);
        //        }

        //    }
        //    catch (Exception e) { }
        //    NavigateToSSCCardManagement();
        //    NavigateToSSCReplenishment();
        //}

        //public void ValidateReplenishmentJob(string CardSource, string Replenishment, string MappedRangeFrom, string MappedRangeTo)
        //{
        //    Boolean Cardsource_disp = driver.FindElement(By.XPath("//*[text()= '" + CardSource + "']")).Displayed;
        //    Boolean Replenishment_disp = driver.FindElement(By.XPath("//*[text()= '" + Replenishment + "']")).Displayed;
        //    Boolean MappedRangeFrom_disp = driver.FindElement(By.XPath("//*[text()= '" + MappedRangeFrom + "']")).Displayed;
        //    Boolean MappedRangeTo_disp = driver.FindElement(By.XPath("//*[text()= '" + MappedRangeTo + "']")).Displayed;

        //    Assert.IsTrue(Cardsource_disp, "The Card Source is not found in Card Replenishment");
        //    Assert.IsTrue(Replenishment_disp, "The Card Source is not found in Card Replenishment");
        //    Assert.IsTrue(MappedRangeFrom_disp, "The Card Source is not found in Card Replenishment");
        //    Assert.IsTrue(MappedRangeTo_disp, "The Card Source is not found in Card Replenishment");

        //}

        //public void NavigateToSSCTickets()
        //{
        //    BrowserDriver.Sleep(3000);
        //    if (driver.FindElements(SSCNavAdminServiceTree).Count != 0)
        //    {
        //        driver.FindElement(SSCNavAdminServiceTree).Click();
        //    }
        //    BrowserDriver.Sleep(5000);
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNavTickets);
        //    WebHandlers.Instance.ClickByJsExecutor(SSCNavTickets);
        //    try { WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader); }
        //    catch { WebHandlers.Instance.Click(SSCNavTickets); }
        //    BrowserDriver.Sleep(5000);
        //}

        //public void NavigateToSSCCustomerMerge()
        //{
        //    BrowserDriver.Sleep(5000);
        //    //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomerMerge);
        //    SSCNavCustomerMerge.Click();
        //    //BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void MergeActiveUsersinSSC(string Mergeusername1, string Mergeusername2)
        //{
        //    BrowserDriver.Sleep(3000);
        //    SSCCreateButton.Click();
        //    DateTime datetime = DateTime.Now;
        //    string mergername = "Test Merge_" + datetime.ToString("dd.MM.yyyy") + "_" + CommonFunctions.GetRandomNumber(2);
        //    BrowserDriver.Sleep(3000);

        //    SSC_CustomerMergerName.SendKeys(mergername);
        //    SSC_Customer_MergeUserName1.SendKeys(Mergeusername1);
        //    SSC_Customer_MergeUserName2.SendKeys(Mergeusername2);
        //    WebHandlers.Instance.Click(SSC_SaveOpen_Btn);
        //}

        //public void ValidateDeemeduserinSSC(string Mergeusername2, string Username2Email)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Mergeusername2 + "\n");
        //    BrowserDriver.Sleep(3000);
        //    int searcherror = driver.FindElements(By.XPath("//*[text()='No results found. Search again in all items?']")).Count();
        //    if (searcherror > 0)
        //    {
        //        driver.FindElement(By.XPath("//*[text()='No results found. Search again in all items?']")).Click();
        //    }

        //    Assert.IsTrue(driver.FindElement(By.XPath("//*[text()='No data'][@class='sapMListTblCell sapMListTblCellNoData']")).Displayed, "The User is still found in Customer Base");

        //}

        //public void EditAttributeofSurvivingCustomer()
        //{
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    ReadOnlyCollection<IWebElement> Surviving_Customer = driver.FindElements(By.XPath("//table[2]/tbody[1]/tr/td[3]/div[1]/div[1]/div[1]/div[1]/div[1]"));
        //    int attribute_count = Surviving_Customer.Count();
        //    for (int i = 0; i < attribute_count; i++)
        //    {
        //        try
        //        {
        //            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//table[2]/tbody[1]/tr/td[3]/div[1]/div[1]/div[1]/div[1]/div[1])[" + i + "]")));
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("Error in element " + Surviving_Customer[i]);
        //        }
        //    }
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void InitateCustomerMerge()
        //{
        //    try
        //    {
        //        WebHandlers.Instance.Click(SSC_Actions_Btn);
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.Click(SSC_Initiate_Merge_Menu);
        //    }
        //    catch
        //    {
        //        WebHandlers.Instance.Click(SSC_Actions_Btn);
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.Click(SSC_Initiate_Merge_Menu);
        //    }

        //}
        //public string[] OptingInEmailConsentOnSSC(string UserName, string Email, string EmailConsent)
        //{
        //    //string FullName = UserName + " " + UserName + "Lname"; bool itemExists = false;
        //    string CdcId = null, CardNumber = null, OptValue = null;
        //    string Gridemailtext = "";
        //    BrowserDriver.Sleep(3000);
        //    try
        //    {

        //        SSCCustomersSearchIcon.Click();
        //        WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //        BrowserDriver.Sleep(3000);


        //        WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
        //        BrowserDriver.PageWait();
        //        BrowserDriver.Sleep(3000);
        //    }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }

        //    //CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='E-Mail']/../../following-sibling::td[4]/div//span[@title='Set to Opt-In']")));
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    WebHandlers.Instance.Click(SSCSaveButton);
        //    //BrowserDriver.Sleep();
        //    //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
        //    //BrowserDriver.PageWait();
        //    //BrowserDriver.Sleep(1000);
        //    return new string[] { CdcId, CardNumber };


        //}

        //public string[] VerifyGivenUserinSSCandExtractCustomerdetails(string UserName, string Email)
        //{
        //    string CdcId = "", CustomerID = "";

        //    //Search Customer
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }

        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    try
        //    {
        //        CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //        WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
        //        BrowserDriver.PageWait();
        //        BrowserDriver.Sleep(3000);

        //        CustomerID = WebHandlers.Instance.GetTextOfElement(SSCCustomer_ID);
        //    }
        //    catch (Exception e)
        //    {
        //        CdcId = "User not found";
        //        CustomerID = "User not found";
        //    }

        //    return new string[] { CdcId, CustomerID };
        //}

        //public string[] VerifyGivenUsersWithCardEmailWereListingOnSSC(string UserName, string Email, string EmailConsent, string JoinRewards)
        //{
        //    //string FullName = UserName + " " + UserName + "Lname"; bool itemExists = false;
        //    string FullName = UserName;
        //    string CdcId = null, CardNumber = null, OptValue = null;
        //    string Gridemailtext = "";
        //    BrowserDriver.Sleep(3000);
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }

        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);

        //    //if (SSCNoREsultLink.Displayed)
        //    //{
        //    //    WebHandlers.Instance.Click(SSCNoREsultLink);
        //    //    Gridemailtext = SSCCustomerGridEmailCell.Text.ToLower();
        //    //    BrowserDriver.Sleep(2000);
        //    //}
        //    //else
        //    //{
        //    Gridemailtext = SSCCustomerGridEmailCell.Text;
        //    //}
        //    string ToLowerEmail = Email.ToLower();
        //    Console.WriteLine(Gridemailtext + "==> Grid Email Text");
        //    Console.WriteLine(ToLowerEmail + "==> Email Text");
        //    Assert.IsTrue(Gridemailtext.Equals(ToLowerEmail), Email + " - Email of the Searched Csutomer is not displayed in Grid");
        //    BrowserDriver.Sleep(1000);
        //    CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

        //    Console.WriteLine(Gridemailtext + "==> Grid Email Text");
        //    WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //    try
        //    {
        //        if (JoinRewards != "NotInterested")
        //        {
        //            CardNumber = WebHandlers.Instance.GetAttribute(SSCCustomerCardNo, "innerHTML");
        //            Assert.IsNotNull(CardNumber, "SSC card number is not showing for the user");
        //        }
        //    }

        //    catch { }

        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(1000);
        //    return new string[] { CdcId, CardNumber };
        //}

        //public string VerifyGivenUsersWereListingOnSSC(string UserName, string Email)
        //{
        //    //string FullName = UserName + " " + UserName + "Lname";
        //    string FullName = UserName;
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(SSCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
        //    Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
        //    BrowserDriver.Sleep(1000);
        //    return WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //}
        //public void SearchCustomerOnSSC(string UserName, string Email)
        //{

        //    BrowserDriver.Sleep(3000);
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);

        //    driver.FindElement(SSCCustomersGridData(UserName)).Click();
        //    //BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void navigatetoCampaignsTabinSSC()
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCCustomersSubtabCampaigns);
        //    BrowserDriver.Sleep(2000);
        //}

        //public void navigatetoPreferencesTabinSSC()
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
        //    BrowserDriver.Sleep(2000);
        //}

        //public void SearchGroupOnSSC(string Testgroupname)
        //{
        //    // string FullName = UserName + " " + UserName + "Lname";

        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Testgroupname + "\n");
        //    BrowserDriver.Sleep(3000);
        //    int searcherror = driver.FindElements(By.XPath("//*[text()='No results found. Search again in all items?']")).Count();
        //    if (searcherror > 0)
        //    {
        //        driver.FindElement(By.XPath("//*[text()='No results found. Search again in all items?']")).Click();
        //    }
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCCustomersGridData(Testgroupname)).Click();
        //    //BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void PurchaseOrderSearch(string PurchaseOrderNo)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, PurchaseOrderNo + "\n");
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(By.XPath("//*[text()='No results found. Search again in all items?']")).Click();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCPurchaseOrderID_Grid);
        //}

        //public void SelectBirthdayPromotioninSSC()
        //{
        //    DateTime BirthDate = Convert.ToDateTime(SSC_UserBdate.Text);
        //    DateTime BdayWeekselec;
        //    if (BirthDate < DateTime.Now)
        //    {
        //        BdayWeekselec = BirthDate.AddYears(1);
        //    }
        //    else
        //    {
        //        BdayWeekselec = BirthDate;
        //    }
        //    BdayWeekselec.AddDays(14);
        //    for (int i = 0; i < 8; i++)
        //    {
        //        BdayWeekselec.AddDays(i);
        //        string day = BdayWeekselec.DayOfWeek.ToString();
        //        if (day.Equals("Monday"))
        //        {
        //            break;
        //        }
        //    }
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SSC_BdayWeekFromDateTxtBox, BdayWeekselec.ToString());
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSC_ConfirmAdjustmentBtn);
        //    BrowserDriver.Sleep(2000);

        //    Assert.IsTrue(driver.FindElements(By.XPath("//span[text()='Birthday week adjustment has been sent to Marketing system  |  Your entries have been saved.  ']")).Count > 0, "Success Message is not displayed as expected");
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void validateMiniHarrodsBdayPromoweekSSC(string username, string email, string campaign_name)
        //{
        //    SearchCustomerOnSSC(username, email);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCCustomersSubtabCampaigns);
        //    string description = SSC_Description_MarketingCampaign.Text;
        //    string startdate = SSC_StartDate_MarketingCampaign.Text;
        //    string els = SSC_ELS_MarketingCampaign.Text;
        //    string current_date = DateTime.Today.ToString("dd.MM.yyyy");
        //    Assert.IsTrue(description.Equals(campaign_name), "The Campaign is not updated in SSC");
        //    Assert.IsTrue(startdate.Equals(current_date), "The Campaign is not updated in SSC");
        //    Assert.IsTrue(description.Equals(campaign_name), "The Campaign is not updated in SSC");
        //}

        //public void ValidateTheErrorMsgBdayWeekinSSC()
        //{
        //    UserDataExpndBtn.Click();
        //    BrowserDriver.Sleep(2000);

        //    //string userbdate = userbday + " 00:05:00 AM";

        //    string[] datelist = SSC_UserBdate.Text.Split('.');

        //    string day = datelist[0].ToString();
        //    string month = datelist[1].ToString();
        //    string year = datelist[2].ToString();

        //    string userbday = month + "/" + day + "/" + year;

        //    DateTime BirthDate = DateTime.ParseExact(userbday, "M/d/yyyy", CultureInfo.InvariantCulture);

        //    DateTime BdayWeekselec;
        //    if (BirthDate < DateTime.Now)
        //    {
        //        BdayWeekselec = BirthDate.AddYears(1);
        //    }
        //    else
        //    {
        //        BdayWeekselec = BirthDate;
        //    }
        //    if (BdayWeekselec.DayOfWeek.ToString().Equals("Monday"))
        //    {
        //        BdayWeekselec.AddDays(16);
        //    }
        //    else { BdayWeekselec.AddDays(14); }
        //    string bdayweeksel = BdayWeekselec.ToString("dd.MM.yyyy");
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    BrowserDriver.Sleep(3000);
        //    //WebHandlers.Instance.EnterText(SSC_BdayWeekFromDateTxtBox, BdayWeekselec.ToString());
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    ContentAction.MoveToElement(SSC_BdayWeekFromDateTxtBox).Click().SendKeys(bdayweeksel).DoubleClick().Build().Perform();
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSC_ConfirmAdjustmentBtn);
        //    BrowserDriver.Sleep(2000);
        //    Assert.IsTrue(driver.FindElements(By.XPath("//span[text()='Only Monday is allowed as the start day of Birthday Week  |  Save failed  ']")).Count > 0, "Error Message is not displayed as expected");

        //}

        //public void ValidatePurchaseValue(string PurchaseValue)
        //{
        //    BrowserDriver.Sleep(4000);
        //    //WebHandlers.Instance.Click(SSCPurchaseOrder_ProductTab);
        //    SSCPurchaseOrder_ProductTab.Click();
        //    BrowserDriver.Sleep(2000);
        //    string saleprice = driver.FindElement(By.XPath("(//span[text()='Sales price']/following::div/div/div/span)[5]")).Text;
        //    Console.WriteLine("displayed sale price" + saleprice);
        //    Console.WriteLine("actual sale price" + PurchaseValue);
        //    Assert.IsTrue(saleprice.Equals(PurchaseValue), "The Purchase value isnt matching. Free Delivery is not applied to order");
        //}

        //public void AddChildrenforUserinSSC_MiniHarrods(string ChildFirstname, string ChildLastName, string ChildDOB, string ChildGender, string Relationship)
        //{
        //    WebHandlers.Instance.Click(SSCCustomersRelationships);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Add Row']")));
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("//bdi[text()='First Name']/following::input[1]")), ChildFirstname);
        //    WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("//bdi[text()='Last Name']/following::input[2]")), ChildLastName);
        //    //WebHandlers.Instance.EnterText(driver.FindElement(SSCChildGenderDropdown(ChildGender)),ChildGender);
        //    SSCChildGenderdrpdowntxt.SendKeys(ChildGender);

        //    WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("//bdi[text()='Birth Date']/following::input[4]")), ChildDOB);
        //    BrowserDriver.Sleep(1000);
        //    //WebHandlers.Instance.EnterText(driver.FindElement(SSCChildRelationship(Relationship)), Relationship);

        //    SSCChildRelationshipTxt.SendKeys(Relationship);
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void RemoveLastChildforUserinSSC_MiniHarrods(string ChildFirstname, string ChildLastName, string ChildDOB, string ChildGender, string Relationship)
        //{
        //    WebHandlers.Instance.Click(SSCCustomersRelationships);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    BrowserDriver.Sleep(3000);
        //    ReadOnlyCollection<IWebElement> delete_links = driver.FindElements(By.XPath("//*[@title='Delete']"));
        //    int count_delete = delete_links.Count;
        //    //clicking the last delete button
        //    WebHandlers.Instance.Click(delete_links[count_delete - 1]);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void SearchQatariCustomerandValidateonSSC(string username, string email, string discountceilvalue, string bandgrade)
        //{
        //    BrowserDriver.Sleep(3000);
        //    SearchCustomerOnSSC(username, email);
        //    BrowserDriver.Sleep(3000);

        //    //moving to customer data tab
        //    WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
        //    BrowserDriver.Sleep(3000);
        //    driver.Navigate().Refresh();
        //    BrowserDriver.Sleep(3000);
        //    driver.Navigate().Refresh();
        //    WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
        //    string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
        //    string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
        //    string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
        //    string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
        //    string isqataristatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Qatari Holdings']/following::div[1]")));
        //    string isemployeestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Employee']/following::div[1]")));



        //    Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
        //    Assert.IsTrue(isregisteredstatus.Equals("Yes"), "The Customer is not registered");
        //    Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
        //    Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");
        //    Assert.IsTrue(isqataristatus.Equals("Yes"), "The Customer is not under qatari holdings");
        //    BrowserDriver.Sleep(3000);
        //    //moving to preferences tab
        //    WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
        //    BrowserDriver.Sleep(3000);
        //    string bandgrade_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Band / Grade (Qatari Holding)']/following::div[1]/label")));
        //    string discountceil_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Discount ceiling (Pound Sterling)']/following::div[1]")));
        //    Assert.IsTrue(bandgrade_displayed.Contains(bandgrade), "The Customer is not having band grade");
        //    Assert.IsTrue(discountceil_displayed.Contains(discountceilvalue), "The discount ceil value is incorrect");
        //}

        //public void SearchAlFaydaCustomerandValidateonSSC(string username, string email, string discountceilvalue, string bandgrade)
        //{
        //    SearchCustomerOnSSC(username, email);
        //    BrowserDriver.Sleep(3000);

        //    //moving to customer data tab
        //    //WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
        //    SSCCustomersSubtabCustomerData.Click();
        //    BrowserDriver.Sleep(3000);
        //    driver.Navigate().Refresh();
        //    BrowserDriver.Sleep(3000);
        //    //driver.Navigate().Refresh();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSubtabCustomerData);
        //    SSCCustomersSubtabCustomerData.Click();
        //    string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
        //    string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
        //    string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
        //    string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
        //    string isalfayadstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Al Fayed Family']/following::div[1]")));
        //    string isemployeestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Employee']/following::div[1]")));

        //    Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
        //    Assert.IsTrue(isregisteredstatus.Equals("Yes"), "The Customer is not registered");
        //    Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
        //    Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");
        //    Assert.IsTrue(isalfayadstatus.Equals("Yes"), "The Customer is not under al fayad family");
        //    BrowserDriver.Sleep(3000);
        //    //moving to preferences tab
        //    WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
        //    BrowserDriver.Sleep(3000);
        //    string bandgrade_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Band / Grade (Al Fayed family)']/following::div[1]/label")));
        //    string discountceil_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Discount ceiling (Pound Sterling)']/following::div[1]")));
        //    Assert.IsTrue(bandgrade_displayed.Contains(bandgrade), "The Customer is not having band grade");
        //    Assert.IsTrue(discountceil_displayed.Contains(discountceilvalue), "The Customer is not under al fayda family");
        //}

        //public void SearchPressPersonandValidateonSSC(string username, string email, string discountceilvalue)
        //{
        //    SearchCustomerOnSSC(username, email);
        //    BrowserDriver.Sleep(3000);

        //    //moving to customer data tab
        //    //WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
        //    SSCCustomersSubtabCustomerData.Click();
        //    BrowserDriver.Sleep(3000);
        //    driver.Navigate().Refresh();
        //    BrowserDriver.Sleep(3000);
        //    //driver.Navigate().Refresh();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSubtabCustomerData);
        //    SSCCustomersSubtabCustomerData.Click();

        //    string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
        //    string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
        //    string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
        //    string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
        //    // string isemployeestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Employee']/following::div[1]")));

        //    Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
        //    Assert.IsTrue(isregisteredstatus.Equals("Yes"), "The Customer is not registered");
        //    Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
        //    Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");

        //    //moving to preferences tab
        //    WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
        //    BrowserDriver.Sleep(3000);
        //    string discountvalue_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Press Discount']/following::div[1]")));
        //    Assert.IsTrue(discountvalue_displayed.Contains("20% Press discount"), "The Customer is not a press person");
        //}

        //public void SearchInteriorDesignPersonandValidateonSSC(string username, string email, string discountceilvalue)
        //{
        //    SearchCustomerOnSSC(username, email);
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabCustomerData.Click();
        //    BrowserDriver.Sleep(3000);
        //    driver.Navigate().Refresh();
        //    BrowserDriver.Sleep(3000);
        //    //driver.Navigate().Refresh();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSubtabCustomerData);
        //    SSCCustomersSubtabCustomerData.Click();

        //    string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
        //    string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
        //    string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
        //    string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
        //    // string isemployeestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Employee']/following::div[1]")));

        //    Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
        //    Assert.IsTrue(isregisteredstatus.Equals("Yes"), "The Customer is not registered");
        //    Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
        //    Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");

        //    //moving to preferences tab
        //    WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
        //    BrowserDriver.Sleep(3000);
        //    string discountvalue_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Interior Designer']/following::div[1]")));
        //    Assert.IsTrue(discountvalue_displayed.Contains("20% Interior Designer discount"), "The Customer is not a Interior Design person");
        //}

        //public void SearchandValidateSpouseofStaffinSSC(string spousename, string username, string email)
        //{
        //    try
        //    {
        //        SearchCustomerOnSSC(username, email);
        //        BrowserDriver.Sleep(3000);

        //        //moving to customer data tab
        //        WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
        //        BrowserDriver.Sleep(3000);
        //        driver.Navigate().Refresh();
        //        BrowserDriver.Sleep(3000);
        //        driver.Navigate().Refresh();
        //        WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
        //        string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
        //        //string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
        //        string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
        //        string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
        //        string isSpouseCivil = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Spouse/Is Civil Partner']/following::div[1]")));



        //        Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
        //        //Assert.IsTrue(isregisteredstatus.Equals("Yes"), "The Customer is not registered");
        //        Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
        //        Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");
        //        Assert.IsTrue(isSpouseCivil.Equals("Yes"), "The Customer is not a spouse of a reward member");
        //        BrowserDriver.Sleep(3000);
        //    }
        //    catch (Exception e)
        //    {
        //        Assert.Fail("The user is not found in SSC");
        //    }

        //}

        //public string VerifyUserPhoneOnSSC(string UserName, string phonenumber, string Email)
        //{
        //    string FullName = UserName + " " + UserName + "Lname";
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(SSCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
        //    BrowserDriver.Sleep(2000);
        //    Assert.IsTrue(driver.FindElement(SSCCustomersGridData("+44 " + phonenumber)).Displayed, phonenumber + " - Expected phone number not showing on the grid");
        //    //Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
        //    BrowserDriver.Sleep(1000);
        //    return WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //}
        //public void NavigatetoContactDetailsinSSC()
        //{
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabContactDetails.Click();
        //    BrowserDriver.Sleep(3000);
        //}

        //public DateTime ResendVerificationemailinSSC()
        //{
        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Resend Verification Email']")));
        //    BrowserDriver.Sleep(3000);
        //    Boolean isEmailSent = WebHandlers.Instance.IsElementPresent(By.XPath("//bdi[text()='Email Sent']"));
        //    DateTime registrationCompltedTime = DateTime.Now;
        //    Assert.IsTrue(isEmailSent, "Verification Email is not sent to the customer");
        //    return registrationCompltedTime;
        //}

        //public void AddnewUserphoneinSSC(string countrycode, string phonenumber, string username, string email)
        //{
        //    string countrycode_no = "";

        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(username)).Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabContactDetails.Click();
        //    BrowserDriver.Sleep(3000);

        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(3000);
        //    //ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//*[text()='Dialing Code']/following::td/..//*[@class='sapMComboBoxInner sapMInputBaseInner']"));
        //    IWebElement dialing_code = driver.FindElement(By.XPath("//*[text()='Dialing Code']/following::input[6]"));
        //    IWebElement dropdwonarrow = driver.FindElement(By.XPath("//*[text()='Dialing Code']/following::span[contains(@id,'dropdownlistbox')][contains(@id,'arrow')][3]"));

        //    BrowserDriver.Sleep(2000);

        //    if (SSCEditCheckBox.Displayed)
        //    {
        //        //SSCEditCheckBox.Click();
        //        SSCProfileDataEditCheckBox.Click();
        //        BrowserDriver.Sleep(2000);
        //        //dialing_code.Click();
        //        //dropdwonarrow.Click();
        //        BrowserDriver.Sleep(2000);
        //        //switch (countrycode)
        //        //{
        //        //    case ("UK"):
        //        //        //links[1].SendKeys("GB +44");    
        //        //        WebHandlers.Instance.ExecuteScript("arguments[0].value = 'GB +44';", dialing_code);
        //        //        //dialing_code.SendKeys("GB +44");
        //        //        break;
        //        //    case ("US"):
        //        //        //links[1].SendKeys("US +1");
        //        //        dialing_code.SendKeys("US +1");
        //        //        break;
        //        //    case ("China"):
        //        //        //links[1].SendKeys("CN +86");
        //        //        dialing_code.SendKeys("CN +86");
        //        //        break;
        //        //    case ("Canada"):
        //        //       // links[1].SendKeys("CA +1");
        //        //        dialing_code.SendKeys("CA +1");
        //        //        break;
        //        //    case ("France"):
        //        //        //links[1].SendKeys("FR +33");
        //        //        dialing_code.SendKeys("FR +33");
        //        //        break;
        //        //}
        //        SSCPhonenumberfieldinEditmode.Clear();
        //        SSCPhonenumberfieldinEditmode.SendKeys(phonenumber);
        //        SSCSaveButton.Click();
        //    }
        //}

        //public void UpdateandValidateUserDOBinSSC(String DOB, string username, string email)
        //{
        //    //Updated DOB
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(username)).Click();
        //    //SSCCustomerGridFirstCell.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.WaitForPageLoad();
        //    WebWaitHelper.Instance.WaitForElement(SSCDetailsEditIcon);
        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(UserDataExpndBtn);
        //    BrowserDriver.Sleep(3000);
        //    SSC_DOB_Txtbox.Clear();
        //    //WebHandlers.Instance.ClearText(SSC_DOB_Txtbox);
        //    //WebHandlers.Instance.EnterText(SSC_DOB_Txtbox, DOB);
        //    SSC_DOB_Txtbox.SendKeys(DOB);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //    BrowserDriver.Sleep(3000);
        //    //ValidateDOB
        //    Assert.IsTrue(SSC_DOB_Field.Text.Equals(DOB), "The DOB is not updated as expected");
        //}

        //public void AddPotentialResellerAttributetoCustomer(string email, string fullname)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(fullname)).Click();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
        //    BrowserDriver.Sleep(3000);
        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSC_Pref_Attribute_Btn);
        //    BrowserDriver.Sleep(3000);
        //    try
        //    {
        //        SSC_DB_LeadGenChkBox.Click();
        //        //WebHandlers.Instance.Click(SSC_DB_PrivShoppingChkBox);
        //        SSC_DialogBox_Select.Click();
        //        //WebHandlers.Instance.Click(SSC_DialogBox_Select);               
        //    }
        //    catch
        //    {
        //        //WebHandlers.Instance.Click(SSC_DialogBox_Cancel);
        //        SSC_DialogBox_Cancel.Click();
        //    }
        //    BrowserDriver.Sleep(4000);
        //    //WebHandlers.Instance.EnterText(SSC_NotEligiblePrivShop_Dropdown, "Potential Reseller / Non-End User");
        //    driver.FindElement(By.XPath("//*[contains(@id,'dataTypeValue3-arrow')]")).Click();
        //    driver.FindElement(By.XPath("//li[contains(@id,'dataTypeValue')][@aria-posinset='3']")).Click();
        //    //WebHandlers.Instance.MultiSelectByText(SSC_NotEligiblePrivShop_Dropdown, "Potential Reseller / Non-End User");
        //    //SSC_NotEligiblePrivShop_Dropdown.SendKeys("Potential Reseller / Non-End User");
        //    //WebHandlers.Instance.ExecuteScript("arguments[0].value='Potential Reseller / Non-End User'", SSC_NotEligiblePrivShop_Dropdown);

        //    //SSC_PrivateShopping_ToggleTxt.SendKeys("No");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //    //string potential_Reseller = WebHandlers.Instance.GetAttribute(SSC_NotEligiblePrivShop_Dropdown, "value");
        //    //string privateShoppingstatus = WebHandlers.Instance.GetAttribute(SSC_PrivateShopping_ToggleTxt,"value");
        //    Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='Potential Reseller / Non-End User']")).Displayed, "The status of potential reseller is not correct");
        //}

        //public void RemovePrivateShoppingAttributetoCustomer(string email, string fullname)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(fullname)).Click();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
        //    BrowserDriver.Sleep(3000);
        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSC_Attribute_DeleteBtn);
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //    string nodata = WebHandlers.Instance.GetTextOfElement(SSC_AttributeTable_NoData);
        //    Assert.IsTrue(nodata.Equals("No data"), "The attribute is not removed");
        //}

        //public void EditUserphoneinSSC(string countrycode, string phonenumber, string username, string email)
        //{
        //    string countrycode_no = "";

        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(username)).Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabContactDetails.Click();
        //    BrowserDriver.Sleep(3000);

        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(3000);
        //    //ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//*[text()='Dialing Code']/following::td/..//*[@class='sapMComboBoxInner sapMInputBaseInner']"));
        //    if (SSCEditCheckBox.Displayed)
        //    {
        //        SSCEditCheckBox.Click();
        //        BrowserDriver.Sleep(2000);
        //        //switch (countrycode)
        //        //{
        //        //    case ("UK"):
        //        //        links[1].SendKeys("GB +44");
        //        //        break;
        //        //    case ("US"):
        //        //        links[1].SendKeys("US +1");
        //        //        break;
        //        //    case ("China"):
        //        //        links[1].SendKeys("CN +86");
        //        //        break;
        //        //    case ("Canada"):
        //        //        links[1].SendKeys("CA +1");
        //        //        break;
        //        //    case ("France"):
        //        //        links[1].SendKeys("FR +33");
        //        //        break;
        //        //}
        //        SSCPhonenumberfieldinEditmode.Clear();
        //        SSCPhonenumberfieldinEditmode.SendKeys(phonenumber);
        //        SSCSaveButton.Click();
        //    }
        //}

        //public void DeleteUserphoneinSSC(string username, string email)
        //{
        //    string countrycode_no = "";

        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(username)).Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabContactDetails.Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(3000);
        //    //ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//*[text()='Dialing Code']/following::td/..//*[@class='sapMComboBoxInner sapMInputBaseInner']"));
        //    if (SSCProfileDataEditCheckBox.Displayed)
        //    {
        //        //SSCEditCheckBox.Click();
        //        SSCProfileDataEditCheckBox.Click();
        //        BrowserDriver.Sleep(2000);
        //        //driver.FindElement(SSCCustomerPhonenumber(phonenumber)).Clear();
        //        SSCPhonenumberfieldinEditmode.Clear();
        //        SSCSaveButton.Click();
        //    }
        //}

        //public void AddUserPersonalDetailsinSSC(string firstname, string lastname, string DOB, string email)
        //{
        //    //string countrycode_no = "";
        //    string username = firstname + " " + lastname;

        //    SSCCreateButton.Click();
        //    SSCCustomerType.SendKeys("Full Account");
        //    SSCNew_Firstname.SendKeys(firstname);
        //    SSCNew_Lastname.SendKeys(lastname);
        //    SSCNew_DOB.SendKeys(DOB);
        //    SSCNew_Email.SendKeys(email);
        //    //SSC_TermsandCondns_Toggle.Click();
        //    // SSC_PrivacyPolicy_Toggle.Click();
        //    SSCSaveButton.Click();

        //}

        //public void CreateQatariStaffDetailsinSSC(string firstname, string lastname, string discountceilvalue, string brandgrade, string dob, string email, string phone)
        //{
        //    //Creating New Staff
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking the rewards account toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking isqatari holding  toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[3]")).Click();
        //    SSC_Qatari_BandGrade_dropdown.SendKeys(brandgrade);
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.EnterText(SSC_Qatari_BandGrade_dropdown, brandgrade);
        //    //WebHandlers.Instance.ClearText(SSC_Disc_Ceilvalue);
        //    //WebHandlers.Instance.EnterText(SSC_Disc_Ceilvalue, discountceilvalue);
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    string title = (string)js.ExecuteScript("arguments[0].value = '';", SSC_Disc_Ceilvalue);


        //    SSC_Disc_Ceilvalue.Clear();
        //    SSC_Disc_Ceilvalue.SendKeys(discountceilvalue);
        //    SSCNew_Firstname.SendKeys(firstname);
        //    SSCNew_Lastname.SendKeys(lastname);
        //    SSCNew_DOB.SendKeys(dob);
        //    SSCNew_Email.SendKeys(email);
        //    SSCNew_Phone.SendKeys(phone);
        //    //SSCDialingCode.Clear();
        //    //SSCDialingCode.SendKeys("GB - +44");
        //    //SSCDialingCode.SendKeys(Keys.Tab);

        //    SSCDialingCode.Click();
        //    BrowserDriver.Sleep(2000);
        //    Actions action = new Actions(driver);
        //    action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
        //    //SSCDialingCodeArrow.Click();
        //    BrowserDriver.Sleep(2000);
        //    //SSCDialingCode_Dropdown_GB.Click();
        //    SSCNew_Phone.Click();
        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void CreateNewStaffinSSC(string FirstName, string LastName, string DOB, string UserEmail)
        //{
        //    Console.WriteLine("*****Staff First name is " + FirstName);
        //    Console.WriteLine("******Staff Last name is " + LastName);
        //    Console.WriteLine("*******Staff DOB is " + DOB);
        //    Console.WriteLine("********Staff Email is " + UserEmail);
        //    //Creating New Staff
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking the rewards account toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
        //    BrowserDriver.Sleep(2000);


        //    SSCNew_Firstname.SendKeys(FirstName);
        //    SSCNew_Lastname.SendKeys(LastName);
        //    SSCNew_DOB.SendKeys(DOB);
        //    SSCNew_Email.SendKeys(UserEmail);
        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();

        //    BrowserDriver.Sleep(3000);
        //}

        //public void CreateNewStaffandValidatePhonenumberinSSC(string FirstName, string LastName, string DOB, string UserEmail,string CountryCode,string Phonenumber)
        //{
        //    Console.WriteLine("*****Staff First name is " + FirstName);
        //    Console.WriteLine("******Staff Last name is " + LastName);
        //    Console.WriteLine("*******Staff DOB is " + DOB);
        //    Console.WriteLine("********Staff Email is " + UserEmail);
        //    //Creating New Staff
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking the rewards account toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
        //    BrowserDriver.Sleep(2000);


        //    SSCNew_Firstname.SendKeys(FirstName);
        //    SSCNew_Lastname.SendKeys(LastName);
        //    SSCNew_DOB.SendKeys(DOB);
        //    SSCNew_Email.SendKeys(UserEmail);
        //    SSCDialingCode.SendKeys(CountryCode);
        //    SSCNew_Phone.SendKeys(Phonenumber);

        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    int error_message1 = driver.FindElements(By.XPath("//*[contains(text(),'Special characters are not allowed in Phone')]")).Count;
        //    int error_message2 = driver.FindElements(By.XPath("//*[contains(text(),'Save failed')]")).Count;
        //    int error_message3 = driver.FindElements(By.XPath("//*[contains(text(),'UK phone number format must start with 7')]")).Count;
        //    int error_message4 = driver.FindElements(By.XPath("//*[contains(text(),'UK phone number cannot below 10 characters')]")).Count;
        //    int error_message5 = driver.FindElements(By.XPath("//*[contains(text(),'phone number cannot below 7 characters')]")).Count;

        //    if (error_message1 > 0)
        //    {
        //        Assert.Pass("Phone number field doesnt accept any other character than numericals");
        //    }
        //    else if(error_message2 > 0)
        //    {
        //        Assert.Pass("Phone number field doesnt accept special characters");
        //    }
        //    else if (error_message3 > 0)
        //    {
        //        Assert.Pass("UK Phone number should start with 7");
        //    }
        //    else if (error_message4 > 0)
        //    {
        //        Assert.Pass("UK Phone number should not be below 10 characters");
        //    }
        //    else if (error_message5 > 0)
        //    {
        //        Assert.Pass("phone number should not be below 10 characters");
        //    }


        //    BrowserDriver.Sleep(3000);
        //}

        //public int CreateFullRewardsCustomerinSSC(string FirstName, string LastName, string DOB, string UserEmail, string userphone)
        //{
        //    //Creating New Staff
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    SSC_RewardsAccount_ToggleBtn.Click();
        //    SSCNew_Firstname.SendKeys(FirstName);
        //    SSCNew_Lastname.SendKeys(LastName);
        //    SSCNew_DOB.SendKeys(DOB);
        //    SSCNew_Email.SendKeys(UserEmail);
        //    SSCNew_Phone.SendKeys(userphone);
        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();
        //    int start_time = DateTime.Now.Millisecond;
        //    int end_time = 0;
        //    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
        //    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@id,'-searchButton-img')]")));

        //    if (SSCCustomersSearchIcon.Displayed)
        //    {
        //        end_time = DateTime.Now.Millisecond;
        //    }

        //    int response_time = end_time - start_time;

        //    return response_time;
        //}

        //public int CreateNonRewardsCustomerinSSC(string FirstName, string LastName, string DOB, string UserEmail, string userphone)
        //{
        //    //Creating New Staff
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    SSCNew_Firstname.SendKeys(FirstName);
        //    SSCNew_Lastname.SendKeys(LastName);
        //    SSCNew_DOB.SendKeys(DOB);
        //    SSCNew_Email.SendKeys(UserEmail);
        //    SSCNew_Phone.SendKeys(userphone);
        //    Console.WriteLine("Entered all the datas");
        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();
        //    int start_time = DateTime.Now.Millisecond;
        //    int end_time = 0;
        //    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
        //    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@id,'-searchButton-img')]")));

        //    if (SSCCustomersSearchIcon.Displayed)
        //    {
        //        end_time = DateTime.Now.Millisecond;
        //    }

        //    int response_time = end_time - start_time;

        //    return response_time;
        //}


        //public int CreateNonRewardsCustomerinSSCForTestdataCreation(string FirstName, string LastName, string DOB, string UserEmail, string userphone)
        //{

        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    BrowserDriver.Sleep(3000);
        //    SSCNew_Firstname.SendKeys(FirstName);
        //    SSCNew_Lastname.SendKeys(LastName);
        //    SSCNew_DOB.SendKeys(DOB);
        //    SSCNew_Email.SendKeys(UserEmail);
        //    //SSCNew_Phone.SendKeys(userphone);
        //    Console.WriteLine("Entered all the datas");
        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCSaveButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCSaveButton.Click();
        //    int start_time = DateTime.Now.Millisecond;
        //    int end_time = 0;
        //    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
        //    var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@id,'-searchButton-img')]")));

        //    if (SSCCustomersSearchIcon.Displayed)
        //    {
        //        end_time = DateTime.Now.Millisecond;
        //    }

        //    int response_time = end_time - start_time;

        //    return response_time;
        //}

        //public void DeActivateandActivateCard(string DeactivateReason)
        //{
        //    Actions ContentAction = new Actions(driver);
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSC_DeactivateCard_btn);
        //    BrowserDriver.Sleep(2000);

        //    ContentAction.MoveToElement(SSC_Card_deactivate_dropdown).Click().SendKeys(DeactivateReason + "\n").DoubleClick().Build().Perform();
        //    //WebWaitHelper.Instance.WaitForElement(SSC_Card_deactivate_dropdown);
        //    //WebHandlers.Instance.EnterText(SSC_Card_deactivate_dropdown, DeactivateReason);
        //    //WebHandlers.Instance.Click(SSC_Card_deactivate_Stolen);
        //    //Click OK button on popup
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='OK']")));
        //    BrowserDriver.Sleep(3000);
        //}

        //public void ChangeNameonCard(string firstname_to_change, string lastname_to_change)
        //{
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.EnterText(SSC_UserFirstName_Txtbox, firstname_to_change);
        //    SSC_UserFirstName_Txtbox.Clear();
        //    SSC_UserFirstName_Txtbox.SendKeys(firstname_to_change);
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.EnterText(SSC_UserLastName_Txtbox, lastname_to_change);
        //    SSC_UserLastName_Txtbox.Clear();
        //    SSC_UserLastName_Txtbox.SendKeys(lastname_to_change);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //    BrowserDriver.Sleep(3000);

        //    //*[text()='Request to send card to customer has been sent  |  Your entries have been saved.  ']
        //}

        //public void ValidateNameonCard(string firstname, string lastname)
        //{
        //    Boolean Firstnamepresent = WebHandlers.Instance.IsElementPresent(By.XPath("//*[text()='" + firstname + "']"));
        //    Boolean Lastnamepresent = WebHandlers.Instance.IsElementPresent(By.XPath("//*[text()='" + lastname + "']"));
        //    Assert.IsTrue(Firstnamepresent, "Firstname is not changed in card");
        //    Assert.IsTrue(Lastnamepresent, "LastName is not changed in card");
        //}

        //public void SendNewCardtoCustomer()
        //{
        //    ReadOnlyCollection<IWebElement> actionlinks = driver.FindElements(By.XPath("//bdi[text()='Actions']"));
        //    WebHandlers.Instance.Click(actionlinks[1]);
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.Click(SSC_SendCardtocustomer);
        //    BrowserDriver.Sleep(1000);
        //    int status_ribbon = driver.FindElements(SpanSSCText("Request to send card to customer has been sent")).Count;
        //    //Boolean NewCardStatus = SSC_SendNewCardStatusRibbon.Displayed;
        //    //Assert.IsTrue(NewCardStatus, "New card is not sent to Customer");
        //    Assert.IsTrue(status_ribbon > 0, "New card is not sent to Customer");
        //}

        //public string ActivateNewCardandValidateinSSC()
        //{
        //    WebHandlers.Instance.Click(SSC_ActivateCard_btn);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //    BrowserDriver.Sleep(3000);
        //    string card_assigned_status = SSC_CardAssigned_Status.Text;
        //    Assert.IsTrue(card_assigned_status.Equals("Assigned"), "New Card is not Assigned");
        //    //storing the card number in class level variable
        //    card_assigned = SSC_Card_Assigned.Text;
        //    return card_assigned;
        //}

        //public void CheckforDuplicateuserandEditinSSC()
        //{
        //    BrowserDriver.Sleep(1000);
        //    Boolean duplicate_check = WebHandlers.Instance.IsElementPresent(By.XPath("//bdi[text()='Duplicate Check Results']"));
        //    if (duplicate_check)
        //    {
        //        //WebHandlers.Instance.Click(driver.FindElement(By.XPath("//table[2]/tbody[1]/tr[1]/td[2]/div[1]/a[1]")));
        //        Assert.Fail("Duplicate user found. Cannot create user");
        //    }

        //}

        //public void CreateAlFayadStaffDetailsinSSC(string firstname, string lastname, string discountceilvalue, string dob, string email, string phone)
        //{
        //    //Creating New Staff
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);

        //    //clicking the rewards account toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking isAlfayadFamily holding  toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[4]")).Click();
        //    //SSC_Qatari_BandGrade_dropdown.SendKeys("Bronze");
        //    SSC_Qatari_BandGrade_dropdown.SendKeys("Orange");

        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.EnterText(SSC_Qatari_BandGrade_dropdown, brandgrade);
        //    //WebHandlers.Instance.ClearText(SSC_Disc_Ceilvalue);
        //    //WebHandlers.Instance.EnterText(SSC_Disc_Ceilvalue, discountceilvalue);
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        //    string title = (string)js.ExecuteScript("arguments[0].value = '';", SSC_Disc_Ceilvalue);

        //    SSC_Disc_Ceilvalue.Clear();
        //    SSC_Disc_Ceilvalue.SendKeys(discountceilvalue);
        //    SSCNew_Firstname.SendKeys(firstname);
        //    SSCNew_Lastname.SendKeys(lastname);
        //    SSCNew_DOB.SendKeys(dob);
        //    SSCNew_Email.SendKeys(email);
        //    SSCNew_Phone.SendKeys(phone);
        //    //SSCDialingCode.Clear();
        //    //SSCDialingCode.SendKeys("GB - +44");
        //    //SSCDialingCode.SendKeys(Keys.Tab);

        //    SSCDialingCode.Click();
        //    BrowserDriver.Sleep(2000);
        //    Actions action = new Actions(driver);
        //    action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
        //    //SSCDialingCodeArrow.Click();
        //    BrowserDriver.Sleep(2000);
        //    //SSCDialingCode_Dropdown_GB.Click();
        //    SSCNew_Phone.Click();
        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void CreatePressPersoninSSC(string firstname, string lastname, string discountceilvalue, string dob, string email, string phone)
        //{
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking the rewards account toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking isPrivileged  toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[5]")).Click();
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.EnterText(SSC_Privilegetype_dropdown,"Press");
        //    SSC_Privilegetype_dropdown.SendKeys("Press");
        //    SSCNew_Firstname.SendKeys(firstname);
        //    SSCNew_Lastname.SendKeys(lastname);
        //    SSCNew_DOB.SendKeys(dob);
        //    SSCNew_Email.SendKeys(email);
        //    SSCNew_Phone.SendKeys(phone);
        //    //SSCDialingCode.Clear();
        //    //SSCDialingCode.SendKeys("GB - +44");
        //    //SSCDialingCode.SendKeys(Keys.Tab);

        //    SSCDialingCode.Click();
        //    BrowserDriver.Sleep(2000);
        //    Actions action = new Actions(driver);
        //    action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
        //    //SSCDialingCodeArrow.Click();
        //    BrowserDriver.Sleep(2000);
        //    //SSCDialingCode_Dropdown_GB.Click();
        //    SSCNew_Phone.Click();

        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();

        //}

        //public void CreateInteriorDesignPersoninSSC(string firstname, string lastname, string discountceilvalue, string dob, string email, string phone)
        //{
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking the rewards account toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking isPrivileged  toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[5]")).Click();
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.EnterText(SSC_Privilegetype_dropdown, "Interior Designer");
        //    SSC_Privilegetype_dropdown.Click();
        //    SSC_Privilegetype_dropdown.SendKeys("Interior Designer");
        //    BrowserDriver.Sleep(2000);
        //    SSCNew_Firstname.SendKeys(firstname);
        //    SSCNew_Lastname.SendKeys(lastname);
        //    SSCNew_DOB.SendKeys(dob);
        //    SSCNew_Email.SendKeys(email);
        //    SSCNew_Phone.SendKeys(phone);
        //    //SSCDialingCode.Clear();
        //    //SSCDialingCode.SendKeys("GB - +44");
        //    //SSCDialingCode.SendKeys(Keys.Tab);

        //    SSCDialingCode.Click();
        //    BrowserDriver.Sleep(2000);
        //    Actions action = new Actions(driver);
        //    action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
        //    //SSCDialingCodeArrow.Click();
        //    BrowserDriver.Sleep(2000);
        //    //SSCDialingCode_Dropdown_GB.Click();
        //    SSCNew_Phone.Click();

        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();
        //}

        //public void AddSpousetoStaffinSSC(string firstname, string lastname, string dob, string email, string spousename, string phone)
        //{
        //    WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
        //    SSCCreateButton.Click();
        //    BrowserDriver.Sleep(3000);
        //    WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
        //    SSCCustomerType.Click();
        //    SSC_Dropdown_Fullaccount.Click();
        //    BrowserDriver.Sleep(2000);
        //    //clicking the rewards account toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click(); BrowserDriver.Sleep(2000);
        //    //clicking is Spouse/Civil Partner  toggle button
        //    driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[2]")).Click();
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.EnterText(SSC_Spouse_SearchBox, spousename);
        //    SSC_Spouse_SearchBox.SendKeys(spousename);
        //    BrowserDriver.Sleep(2000);
        //    SSCNew_Firstname.SendKeys(firstname);
        //    SSCNew_Lastname.SendKeys(lastname);
        //    SSCNew_DOB.SendKeys(dob);
        //    BrowserDriver.Sleep(2000);
        //    SSCNew_Email.SendKeys(email);
        //    BrowserDriver.Sleep(2000);

        //    SSCNew_Phone.SendKeys(phone);
        //    //SSCDialingCode.Clear();
        //    //SSCDialingCode.SendKeys("GB - +44");
        //    //SSCDialingCode.SendKeys(Keys.Tab);

        //    SSCDialingCode.Click();
        //    BrowserDriver.Sleep(2000);
        //    Actions action = new Actions(driver);
        //    action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
        //    //SSCDialingCodeArrow.Click();
        //    BrowserDriver.Sleep(2000);
        //    //SSCDialingCode_Dropdown_GB.Click();
        //    SSCNew_Phone.Click();

        //    SSC_Customer_Aware_TC_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSC_Customer_Aware_PP_ToggleBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    SSCSaveButton.Click();
        //}

        //public void VerifyUserPhoneinSSC(string countrycode, string phonenumber, string username, string Email)
        //{
        //    string countrycode_no = "";
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(username)).Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabContactDetails.Click();
        //    BrowserDriver.Sleep(3000);
        //    switch (countrycode)
        //    {
        //        case ("UK"):
        //            countrycode_no = "+44";
        //            break;
        //        case ("US"):
        //            countrycode_no = "+1";
        //            break;
        //        case ("China"):
        //            countrycode_no = "+86";
        //            break;
        //        case ("Canada"):
        //            countrycode_no = "+1";
        //            break;
        //        case ("France"):
        //            countrycode_no = "+33";
        //            break;
        //    }
        //    Console.WriteLine("user's phone number ==> " + countrycode_no + " " + phonenumber);
        //    int phoneno_count = driver.FindElements(SSCCustomersGridData(phonenumber)).Count;
        //    if (phoneno_count > 0)
        //    {
        //        Console.WriteLine("Phone numbers are seen as expected in " + phoneno_count + " places in the screen");
        //    }
        //    else
        //    {
        //        Assert.Fail("Updated Phone number is not found in the Contact Details screen");
        //        Console.WriteLine("Updated Phone number is not found in the Contact Details screen");
        //    }
        //    BrowserDriver.Sleep(1000);
        //}

        //public void VerifyPhonenumberDeletedSSC(string username, string Email)
        //{
        //    string phonenumber1 = "";
        //    string phonenumber2 = "";
        //    string phonenumber3 = "";
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(username)).Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabContactDetails.Click();
        //    BrowserDriver.Sleep(3000);
        //    try
        //    {
        //        phonenumber1 = SSCCustomerPhone_Field1.Text;
        //        phonenumber2 = SSCCustomerPhone_Field2.Text;
        //        phonenumber3 = SSCCustomerPhone_Field3.Text;
        //    }
        //    catch (Exception e) { }
        //    finally
        //    {
        //        if ((phonenumber1.Equals("") || phonenumber1.Equals("-")) && (phonenumber2.Equals("") || phonenumber2.Equals("-")) && (phonenumber3.Equals("") || phonenumber3.Equals("-")))
        //        {
        //            Console.WriteLine("Phone numbers are successfully deleted");
        //        }
        //        else
        //        {
        //            Assert.Fail("Phone numbers are not deleted in SSC");
        //            // Console.WriteLine("Phone numbers are not deleted in SSC");
        //        }
        //    }
        //}

        //public void VerifyDOBupdatedinSSC(string username, string email, string DOB)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(username)).Click();
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabContactDetails.Click();
        //    BrowserDriver.Sleep(3000);

        //    Assert.IsTrue(driver.FindElement(SSCCustomerBDate(DOB)).Displayed, "Customer Birth Date is not displayed as expected");
        //}

        //public void VerifyOptinConsentandInterestsOnSSC(string UserName, string Email, string consent,string interest)
        //{
        //    string FullName = UserName;
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    if (!consent.Equals(""))
        //    {
        //        Assert.IsTrue(driver.FindElement(SSCCustomersConsent(consent)).Text == "Opt-In", "The Consent " + consent + " is not opted in");
        //    }

        //    if (!interest.Equals(""))
        //    {
        //        Assert.IsTrue(driver.FindElement(SSCCustomersConsent(interest)).Text == "Opt-In", "The Interest " + consent + " is not opted in");
        //    }

        //}

        //public string VerifyConsentandInterestsOnSSC(string UserName, string Email, ScenarioContext scenarioContext)
        //{
        //    string optstatus = "", optstatus1 = "", optstatus2 = "";
        //    List<String> Consentlist = new List<string>(new string[] { "E-Mail", "Telephone", "SMS", "Letter", "Publications" });
        //    List<String> InterestList = new List<string>(new string[] { "Fine Jewellery","Fine Watches","Food Restaurants",
        //        "Harrods Rewards","HBeauty","Home Technology","Kids Toys","Menswear","Mini Harrods","Salon Wellness Services",
        //        "Wine Spirits","Womenswear" });
        //    List<String> optedconsents = new List<string>();
        //    List<String> optedinterests = new List<string>();

        //    string FullName = UserName + " " + UserName + "Lname";
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

        //    scenarioContext.Add("UserCDCId", customer_cdcid);

        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    foreach (String item in Consentlist)
        //    {
        //        if (driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-In")
        //        {

        //            optedconsents.Add(item);
        //        }
        //    }

        //    foreach (String item in InterestList)
        //    {
        //        if (driver.FindElement(SSCCustomersConsent(item)).Text == "Yes")
        //        {

        //            optedinterests.Add(item);
        //        }
        //    }

        //    foreach (string item in optedconsents)
        //    {
        //        if (consentselection.Contains(item))
        //        {
        //            optstatus1 = "";
        //        }
        //    }

        //    foreach (string item in optedinterests)
        //    {
        //        if (interestselection.Contains(item))
        //        {
        //            optstatus2 = "";
        //        }
        //    }
        //    //Edit for Assertion
        //    optstatus = optstatus1 + optstatus2;
        //    return optstatus;
        //}

        //public string VerifyCardEmailConsentDetailsOnSSC(string UserName, string Email, string EmailConsent)
        //{
        //    string FullName = UserName + " " + UserName + "Lname";
        //    string CardNumber = null, OptValue = null;

        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);

        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //    CardNumber = WebHandlers.Instance.GetAttribute(SSCCustomerCardNo, "innerHTML");
        //    Assert.IsNotNull(CardNumber, "SSC card number is not showing for the user");

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);
        //    OptValue = WebHandlers.Instance.GetAttribute(SSCCustomerEmailConsentOptValue, "innerHTML");
        //    if (EmailConsent == "Yes")
        //        Assert.AreEqual("Opt-In", OptValue, "SSC - Email consent value is not showing as expected for the user");
        //    else if (EmailConsent == "No")
        //        Assert.AreEqual("Opt-Out", OptValue, "SSC - Email consent value is not showing as expected for the user");

        //    driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(1000);
        //    return CardNumber;
        //}

        //public void VerifyUsersOrderDetailsWereListingOnSSC(string UserName, string Email, string OrderId)
        //{
        //    string FullName = UserName + " " + UserName + "Lname";
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    SSCCustomersSubtabPurchases.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);
        //    Assert.IsTrue(driver.FindElement(SSCCustomersPurchaseGridData(OrderId)).Displayed, "SSC not listing expected order id for the user");
        //    driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
        //    BrowserDriver.Sleep();
        //}

        //public void CreateTicketForTierUpgrade(string UserName, string Email)
        //{
        //    //Creating manual tier upgrade ticket
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCTicketCreateBtn);
        //    //SSCTicketCreateBtn.Click();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
        //    WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), "General");
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Source"), "Online Fulfillment");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for customer tier upgrade");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Complaint");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "G3-B09");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "G4-BI03");
        //    BrowserDriver.Sleep(2000);

        //    //Performing ticket Save and close
        //    WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    TierUpgrade").DoubleClick().Build().Perform();
        //    WebHandlers.Instance.SwithBackFromFrame();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
        //    BrowserDriver.Sleep(4000);
        //    SSCNewTicketSaveOpen.Click();
        //    BrowserDriver.Sleep(8000);

        //    //Changing ticket status and target tier details
        //    try
        //    {
        //        WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
        //        WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
        //    }
        //    catch
        //    {
        //        WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
        //    }
        //    driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "ManualUpgrade");
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Target Tier"), "Black");
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Loyalty");

        //    //Sending interaction email from ticket
        //    driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
        //    WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
        //    WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
        //    WebHandlers.Instance.Click(SSCTicketEmailSend);
        //    BrowserDriver.Sleep(5000);
        //    WebHandlers.Instance.Click(SSCNewTicketSave);
        //    WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //    BrowserDriver.Sleep(6000);

        //    //Changing ticket status to solved
        //    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
        //    WebHandlers.Instance.Click(SSCNewTicketSave);
        //    WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //    BrowserDriver.Sleep(4000);

        //    if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
        //    {
        //        WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
        //        BrowserDriver.Sleep(1000);
        //        WebHandlers.Instance.Click(SSCNewTicketSave);
        //        WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //        BrowserDriver.Sleep(6000);
        //    }
        //}

        //public void CreateTicketForTierUpgrade(string UserName, string Email, string TargetTier)
        //{
        //    //Creating manual tier upgrade ticket
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCTicketCreateBtn);
        //    //SSCTicketCreateBtn.Click();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
        //    WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
        //    WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for customer tier upgrade");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Complaint");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "G3-B09");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "G4-BI03");
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCNewTicketFields("Team")).Clear();
        //    driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
        //    BrowserDriver.Sleep(2000);

        //    //Performing ticket Save and close
        //    WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    TierUpgrade").DoubleClick().Build().Perform();
        //    WebHandlers.Instance.SwithBackFromFrame();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
        //    BrowserDriver.Sleep(4000);
        //    driver.FindElement(SSCNewTicketFields("Source")).Clear();
        //    WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCNewTicketFields("Subject")).Clear();
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for customer tier upgrade");
        //    SSCNewTicketSaveOpen.Click();
        //    BrowserDriver.Sleep(8000);

        //    //Changing ticket status and target tier details
        //    WebHandlers.Instance.WaitForPageLoad();
        //    //WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
        //    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //    BrowserDriver.Sleep(2000);
        //    try
        //    {
        //        WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open" + "\n");
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
        //        BrowserDriver.Sleep(2000);
        //    }

        //    catch
        //    {
        //        WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open" + "\n");
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
        //        BrowserDriver.Sleep(2000);
        //    }
        //    driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "ManualUpgrade");
        //    WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Target Tier"), TargetTier);


        //    //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Reason"), "Loyalty");
        //    SSC_StatusPointsLbl.Click();
        //    BrowserDriver.Sleep(3000);
        //    SSC_StatusAdjust_Reason.Click();
        //    // ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("    Loyalty Testing" + "\n").DoubleClick().Build().Perform();

        //    BrowserDriver.Sleep(2000);
        //    SSC_StatusAdjust_Reason.Clear();
        //    SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");

        //    BrowserDriver.Sleep(3000);

        //    //Sending interaction email from ticket
        //    driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
        //    WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
        //    WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
        //    WebHandlers.Instance.Click(SSCTicketEmailSend);
        //    BrowserDriver.Sleep(5000);
        //    WebHandlers.Instance.Click(SSCNewTicketSave);
        //    WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //    BrowserDriver.Sleep(6000);

        //    //Changing ticket status to solved
        //    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
        //    try
        //    {
        //        WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
        //    }
        //    catch (Exception g)
        //    {
        //        try
        //        {
        //            SSC_Actions_Btn.Click();
        //            BrowserDriver.Sleep(2000);
        //            SSC_Wihdraw_approval_menu.Click();
        //            BrowserDriver.Sleep(4000);
        //            SSC_Status_Dropdown.Clear();
        //            SSC_Status_Dropdown.SendKeys("Solved" + "\n");
        //            //}
        //        }
        //        catch (Exception e)
        //        {
        //            BrowserDriver.Sleep(4000);
        //            SSC_Status_Dropdown.Clear();
        //            SSC_Status_Dropdown.SendKeys("Solved" + "\n");
        //        }
        //    }
        //    WebHandlers.Instance.Click(SSCNewTicketSave);
        //    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //    BrowserDriver.Sleep(4000);
        //    ChangeTicketStatustoClosed();
        //    //WebHandlers.Instance.Click(SSCNewTicketSave);
        //}

        //public string ValidateUserTierDetailsOnSSC(string Email)
        //{
        //    HomePage homePage = new HomePage(driver);
        //    string CurrTier = ""; int count = 0;

        //    do
        //    {
        //        homePage.NavigateToSSCCustomers();
        //        BrowserDriver.Sleep(15000);
        //        try { SSCCustomersSearchIcon.Click(); }
        //        catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //        BrowserDriver.Sleep();
        //        WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //        BrowserDriver.Sleep(10000);
        //        CurrTier = WebHandlers.Instance.GetAttribute(SSCCustomerTierDetails, "innerHTML");

        //        if (CurrTier == "Black")
        //            break;
        //        count++;
        //    } while (count < 12);

        //    Assert.AreEqual("Black", CurrTier, "SSC - Customer tier details is not showing as expected");
        //    return WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //}

        //public void CreateTicketForPointAddition(string UserName, string Email)
        //{
        //    //Creating manual tier upgrade ticket
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCTicketCreateBtn);
        //    //SSCTicketCreateBtn.Click();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
        //    WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), "General");
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Source"), "Online Fulfillment");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for rewards point addition");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "G3-A08");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "G4-AH01");
        //    BrowserDriver.Sleep(2000);

        //    //Performing ticket Save and close
        //    WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    PointAdd").DoubleClick().Build().Perform();
        //    WebHandlers.Instance.SwithBackFromFrame();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
        //    BrowserDriver.Sleep(4000);
        //    SSCNewTicketSaveOpen.Click();
        //    BrowserDriver.Sleep(6000);

        //    //Changing ticket status and target tier details
        //    try
        //    {
        //        WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
        //        WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
        //    }
        //    catch
        //    {
        //        WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
        //    }
        //    driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "PointsAdd");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Rewards Points To Be Adjusted")), "5000");
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Loyalty");

        //    //Sending interaction email from ticket
        //    driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
        //    WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
        //    WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
        //    WebHandlers.Instance.Click(SSCTicketEmailSend);
        //    BrowserDriver.Sleep(5000);
        //    WebHandlers.Instance.Click(SSCNewTicketSave);
        //    WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //    BrowserDriver.Sleep(6000);

        //    //Changing ticket status to solved
        //    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
        //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
        //    WebHandlers.Instance.Click(SSCNewTicketSave);
        //    WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //    BrowserDriver.Sleep(4000);

        //    if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
        //    {
        //        WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //        BrowserDriver.Sleep(2000);
        //        WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
        //        BrowserDriver.Sleep(1000);
        //        WebHandlers.Instance.Click(SSCNewTicketSave);
        //        WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //        BrowserDriver.Sleep(6000);
        //    }
        //}

        //public string ValidateUserRewardsPointsDetailsOnSSC(string FullName, string Email)
        //{
        //    string CdcId = null; int CurrPoint, count = 0;
        //    SSCHomePage sschomepage = new SSCHomePage(driver, config);

        //    do
        //    {
        //        NavigateToSSCCustomers();
        //        BrowserDriver.Sleep(5000);
        //        CdcId = sschomepage.FetchCDCIdFromSSC(FullName, Email, true);
        //        driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
        //        BrowserDriver.Sleep(10000);
        //        CurrPoint = driver.FindElements(SSCCustomerRewardsPointsValue("5,000")).Count();
        //        driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
        //        BrowserDriver.Sleep(10000);

        //        if (CurrPoint != 0)
        //            break;
        //        count++;


        //    } while (count < 15);

        //    Assert.IsTrue(driver.FindElement(SSCCustomerRewardsPointsValue("5,000")).Displayed, "SSC - Customer rewards point value is not showing as expected");
        //    return CdcId;
        //}

        //public string ValidateUserAddedAddressOnSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    //Navigating to the page and editing given customer
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Performin address validation
        //    driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SSCAddressAlignToPhone(PostalAddress["CellPhone"])).Click();
        //    BrowserDriver.Sleep(2000);
        //    Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on SSC customer address grid");
        //    Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on SSC customer address grid");
        //    Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["AddressLine2"])).Displayed, PostalAddress["AddressLine2"] + " not showing on SSC customer address grid");
        //    // Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["AddressLine3"])).Displayed, PostalAddress["AddressLine3"] + " not showing on SSC customer address grid");
        //    Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on SSC customer address grid");
        //    Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SSC customer address grid");
        //    return CdcId;
        //}
        //public string validateCityPostStateinSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    try
        //    {
        //        SSCCustomersSearchIcon.Click();
        //        if (SSCNoREsultLink.Displayed)
        //        {
        //            SSCNoREsultLink.Click();
        //        }
        //    }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }

        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    //Performin address validation
        //    driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCCustomerContactAddressDetails);
        //    BrowserDriver.Sleep(2000);
        //    Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on SSC customer address grid");
        //    //  Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["State"])).Displayed, PostalAddress["State"] + " not showing on SSC customer address grid");
        //    Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SSC customer address grid");
        //    return CdcId;
        //}
        //public string ValidateUserAddedAddressOnSSCwithDefault(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    //Navigating to the page and editing given customer
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(8000);

        //    //Performin address validation
        //    driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
        //    BrowserDriver.Sleep(3000);
        //    //Takes the number of address links in the table present in Contact details screen 
        //    ReadOnlyCollection<IWebElement> addresslinks = driver.FindElements(By.XPath("//span[text()='Address'][contains(@id,'dropdownlist')][contains(@id,'text-listdefintion')]"));
        //    for (int i = 0; i < addresslinks.Count; i++)
        //    {
        //        addresslinks[i].Click();
        //        //checks whether the post code matches with the value updated in harrods.com
        //        Boolean postcode_status = driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed;
        //        BrowserDriver.Sleep(2000);
        //        ReadOnlyCollection<IWebElement> isDefaultlabels = driver.FindElements(By.XPath("//bdi[text()='IsDefault']"));
        //        if (postcode_status)
        //        {
        //            string defaultcontacttoggle = isDefaultlabels[2].Text;
        //            if (defaultcontacttoggle.Equals("Yes"))
        //            {
        //                //Assert.True(defaultcontacttoggle.Equals("Yes"), "This is not a default address");
        //                break;
        //            }
        //        }
        //    }
        //    return CdcId;
        //}

        //public string ValidateUserAddedBillingAddressOnSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    //Navigating to the page and editing given customer
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    //Performin address validation
        //    driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
        //    BrowserDriver.Sleep(3000);
        //    //Takes the number of address links in the table present in Contact details screen 
        //    ReadOnlyCollection<IWebElement> addresslinks = driver.FindElements(By.XPath("//span[text()='Address'][contains(@id,'dropdownlist')][contains(@id,'text-listdefintion')]"));
        //    for (int i = 0; i < addresslinks.Count; i++)
        //    {
        //        addresslinks[i].Click();
        //        //checks whether the post code matches with the value updated in harrods.com
        //        Boolean postcode_status = driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed;
        //        BrowserDriver.Sleep(2000);
        //        ReadOnlyCollection<IWebElement> isBillinglabels = driver.FindElements(By.XPath("//bdi[text()='IsBilling']"));
        //        if (postcode_status)
        //        {
        //            string billingcontacttoggle = isBillinglabels[2].Text;
        //            if (billingcontacttoggle.Equals("Yes"))
        //            {
        //                //Assert.True(defaultcontacttoggle.Equals("Yes"), "This is not a default address");
        //                break;
        //            }
        //        }
        //        //if (postcode_status)
        //        //{
        //        //    string defaultcontacttoggle = driver.FindElement(By.XPath("//*[@class='sapClientBaseControlsSimpleVLayout sapClientMFormElement sapClientMSwitchElement']//*[text()='IsBilling']/following::div[1]")).Text;
        //        //    Assert.IsTrue(defaultcontacttoggle.Equals("Yes"),"This address is not the Billing address");
        //        //    break;
        //        //}
        //    }
        //    return CdcId;
        //}

        //public void ChangeBillingAddressandSave(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    // BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCCustomersSubtabContactDetails);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //    //ReadOnlyCollection<IWebElement> addresslinks = driver.FindElements(By.XPath("//span[contains(@id,'dropdownlist')][contains(@id,'text-listdefintion')]"));
        //    //ReadOnlyCollection<IWebElement> checkbox_links = driver.FindElements(By.XPath("//span[text()='Edit']/following::td/..//*[@class='sapMCbBg sapMCbHoverable sapMCbMark']"));
        //    ReadOnlyCollection<IWebElement> type = driver.FindElements(By.XPath("//table[2]/tbody/tr/td[3]/div/div/div/input"));
        //    for (int i = 0; i < type.Count; i++)
        //    {
        //        //string type = driver.FindElement(By.XPath("//table[2]/tbody[1]/tr[" + i + "]/td[3]/div[1]")).GetAttribute("value");
        //        if (type[i].GetAttribute("value").Equals("Profile data"))
        //        {
        //            //                    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //            BrowserDriver.Sleep(3000);
        //            //clicking the check box
        //            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//table[2]/tbody[1]/tr[" + i + 1 + "]/td[2]/div[1]/div[1]/div[1]")));
        //            break;
        //        }
        //    }

        //    for (int i = 0; i < type.Count; i++)
        //    {
        //        //string type = driver.FindElement(By.XPath("//table[2]/tbody[1]/tr[" + i + "]/td[3]/div[1]")).GetAttribute("value");
        //        if (type[i].GetAttribute("value").Equals("Address"))
        //        {
        //            //                    WebHandlers.Instance.Click(SSCDetailsEditIcon);
        //            BrowserDriver.Sleep(3000);
        //            //clicking the check box
        //            int posi = i + 1;
        //            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//table[2]/tbody/tr[" + posi.ToString() + "]/td[5]/div/div/div")));
        //            break;
        //        }
        //    }
        //    //for(int i = 1; i <= 5; i++)
        //    //{
        //    //    string checked_status = driver.FindElement(By.XPath("(//*[@value='Address']/following::td[2]/div/div)["+i+"]")).GetAttribute("aria-checked");
        //    //    if (checked_status.Equals("false"))
        //    //    {
        //    //        WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//*[@value='Address']/following::td[2])[" + i + "]")));
        //    //        BrowserDriver.Sleep(1000);
        //    //        WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//*[@value='Address']/following::td[2]/div/div)[" + i + "]")));
        //    //        break;
        //    //    }
        //    //}
        //    //WebHandlers.Instance.EnterText(SSC_ContactDetails_Country, PostalAddress["Country"]);
        //    //WebHandlers.Instance.EnterText(SSC_ContactDetails_AddressLine1, PostalAddress["AddressLine1"]);
        //    //WebHandlers.Instance.EnterText(SSC_ContactDetails_AddressLine2, PostalAddress["AddressLine2"]);
        //    //WebHandlers.Instance.EnterText(SSC_ContactDetails_AddressLine3, PostalAddress["AddressLine3"]);
        //    //WebHandlers.Instance.EnterText(SSC_ContactDetails_City, PostalAddress["City"]);
        //    //WebHandlers.Instance.EnterText(SSC_ContactDetails_Postalcode, PostalAddress["Postcode"]);
        //    //WebHandlers.Instance.Click(SSCSaveButton);

        //}

        //public string ValidateUserAddedDeliveryAddressOnSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    //Navigating to the page and editing given customer
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    //Performin address validation
        //    driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
        //    BrowserDriver.Sleep(3000);
        //    //Takes the number of address links in the table present in Contact details screen 
        //    ReadOnlyCollection<IWebElement> addresslinks = driver.FindElements(By.XPath("//span[text()='Address'][contains(@id,'dropdownlist')][contains(@id,'text-listdefintion')]"));
        //    for (int i = 0; i < addresslinks.Count; i++)
        //    {
        //        addresslinks[i].Click();
        //        //checks whether the post code matches with the value updated in harrods.com
        //        Boolean postcode_status = driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed;
        //        BrowserDriver.Sleep(2000);
        //        if (postcode_status)
        //        {
        //            string defaultcontacttoggle = driver.FindElement(By.XPath("//*[@class='sapClientBaseControlsSimpleVLayout sapClientMFormElement sapClientMSwitchElement']//*[text()='IsDelivery']/following::div[1]")).Text;
        //            Assert.IsTrue(defaultcontacttoggle.Equals("Yes"), "This is not the delivery address");
        //            break;
        //        }
        //    }
        //    return CdcId;
        //}

        //public void ValidateUserAddressGetsDeletedFromSSC(string FullName, string Email)
        //{
        //    //Navigating to the page and editing given customer
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    WebHandlers.Instance.WebElementExists(driver.FindElement(SSCNewTicketSubTabs("Contact Details")));
        //    BrowserDriver.Sleep(5000);

        //    //Validating address gets deleted from the grid
        //    driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsFalse(driver.FindElements(SSCCustomerContactAddress).Count != 0, "Address not get deleted from SSC");
        //}

        //public void ValidateUserAddressGetsSwapedFromSSC(string FullName, string Email)
        //{
        //    //Navigating to the page and editing given customer
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    //Validating address gets deleted from the grid
        //    driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
        //    BrowserDriver.Sleep(3000);
        //    //Console.WriteLine("----Count Of The Address Line in SSC is " + driver.FindElements(SSCCustomerContactAddress).Count);
        //    //Assert.IsTrue(driver.FindElements(SSCCustomerContactAddress).Count == 2, "Multiple address is not added in SSC");
        //    Console.WriteLine("----Count Of The Address Line in SSC is " + driver.FindElements(SSCCustomerContactAddressCheckbox).Count);
        //    Assert.IsTrue(driver.FindElements(SSCCustomerContactAddressCheckbox).Count > 2, "Multiple address is not added in SSC");
        //}

        //public void ValidateChannelOptinAndInterestSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist, List<String> InterestList)
        //{

        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

        //    scenarioContext.Add("UserCDCId", customer_cdcid);

        //    driver.FindElement(SSCCustomersGridData(UserName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);
        //    if (Consentlist.Count > 0)
        //    {
        //        foreach (String item in Consentlist)
        //        {
        //            Assert.IsTrue(driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-In", item + " :IS NOT OPTED");

        //        }
        //    }
        //    if (InterestList.Count > 0)
        //    {
        //        foreach (String item in InterestList)
        //        {
        //            Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "Yes", item + " :IS NOT OPTED");

        //        }
        //    }

        //}
        //public void ValidateInterestUpdatedInSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist, List<String> InterestList, string consentvalue, string InterestValue)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

        //    scenarioContext.Add("UserCDCId", customer_cdcid);

        //    driver.FindElement(SSCCustomersGridData(UserName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    foreach (String item in Consentlist)
        //    {
        //        if (consentvalue == "Opt-in")
        //        {
        //            Assert.IsTrue(driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-In", item + " :IS NOT OPTED");

        //        }
        //        else if (consentvalue == "Opt-Out")
        //            Assert.IsTrue(driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-Out", item + " :IS NOT OPTED");

        //    }

        //    foreach (String item in InterestList)
        //    {
        //        if (InterestValue == "No")
        //        {
        //            Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS  OPTED");
        //        }
        //        else if (InterestValue == "Yes")
        //        {
        //            Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "Yes", item + " :IS  OPTED");
        //        }
        //    }
        //}
        //public void validateMiniHarrodsPresentSSC()
        //{
        //    //bdi[text()='Mini Harrods Is Enroled']/..//following-sibling::div//span
        //    SSCCustomersSubtabCustomerData.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);
        //    Assert.AreEqual("Yes", MiniHarrodsEnrolled.Text, " Mini Harrods is not enrolled ");

        //}


        //public void OptOutConsentsinSSC(string ConsentList, string Email)
        //{
        //    string[] Consent_List = ConsentList.Split(',');
        //    //Customer search
        //    try
        //    {
        //        SSCCustomersSearchIcon.Click();
        //        WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //        BrowserDriver.Sleep(3000);

        //        WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
        //        BrowserDriver.PageWait();
        //        BrowserDriver.Sleep(3000);
        //    }
        //    catch
        //    {
        //        WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon);
        //        WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //        BrowserDriver.Sleep(3000);

        //        WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
        //        BrowserDriver.PageWait();
        //        BrowserDriver.Sleep(3000);
        //    }

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);

        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(4000);
        //    for (int i = 0; i < Consent_List.Length; i++)
        //    {
        //        WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + Consent_List[i] + "']/../../following-sibling::td[4]/div//span[@title='Set to Opt-Out']")));
        //        BrowserDriver.Sleep(2000);
        //    }
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void OptInConsentsinSSC(string ConsentList, string Email)
        //{
        //    string[] Consent_List = ConsentList.Split(',');
        //    //Customer search
        //    try
        //    {
        //        SSCCustomersSearchIcon.Click();
        //        WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //        BrowserDriver.Sleep(3000);

        //        WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
        //        BrowserDriver.PageWait();
        //        BrowserDriver.Sleep(3000);
        //    }
        //    catch
        //    {
        //        WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon);
        //        WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //        BrowserDriver.Sleep(3000);

        //        WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
        //        BrowserDriver.PageWait();
        //        BrowserDriver.Sleep(3000);
        //    }

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);

        //    SSCDetailsEditIcon.Click();
        //    BrowserDriver.Sleep(4000);
        //    for (int i = 0; i < Consent_List.Length; i++)
        //    {
        //        WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + Consent_List[i] + "']/../../following-sibling::td[4]/div//span[@title='Set to Opt-In']")));
        //        BrowserDriver.Sleep(2000);
        //    }
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCSaveButton);
        //}

        //public void RemoveAllInterestsSSC(string Email, string InterestList)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCCustomerGridFirstCell);            

        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    string[] Interest_list = InterestList.Split(',');

        //    foreach (string item in Interest_list)
        //    {
        //        //Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS OPTED");

        //        WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + item + "']/../../following-sibling::td[3]/div//span[@title='Set to Unsubscribed']")));

        //    }
        //}

        //public void AddAllInterestsSSC(string Email, string InterestList)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    string[] Interest_list = InterestList.Split(',');

        //    foreach (string item in Interest_list)
        //    {
        //        //Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS OPTED");

        //        WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + Interest_list + "']/../../following-sibling::td[3]/div//span[@title='Set to Subscribed']")));

        //    }
        //}

        //public void ValidateConsentsOpted(string Consents, bool isopted)
        //{
        //    string[] Consent_List = Consents.Split(',');
        //    if (isopted == true)
        //    {
        //        foreach (var item in Consent_List)
        //        {
        //            Assert.IsTrue(driver.FindElement(FFChannelConsentField(item)).Selected, item + ":IS OPTED");

        //        }
        //    }
        //}



        #endregion

        #region AC Events
        //public void PerformACLogin(string userName, string password)
        //{
        //    WebHandlers.Instance.EnterText(ACloginEmail, userName, $"Entered {userName} for login email");
        //    WebHandlers.Instance.EnterText(ACloginPassword, password, $"Entered password for login email");
        //    WebHandlers.Instance.ClickByJsExecutor(ACloginButton, "Login");
        //    BrowserDriver.Sleep(10000);
        //}

        //public void NavigateToACReportsMemberReports()
        //{
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReportsMember);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);
        //}

        //public void NavigateToACReportsHierarchyManagement()
        //{
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReportsHierarchyManagement);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);
        //}


        //public void SearchforCustomer(string CdcId, string Tier)
        //{

        //    WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
        //    WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
        //    BrowserDriver.Sleep(4000);
        //    WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
        //    BrowserDriver.Sleep(4000);
        //    Assert.AreEqual(Tier, WebHandlers.Instance.GetAttribute(ACCustomerCurrentTierData, "innerHTML"), "AC - Customer tier details is not showing as expected");

        //}

        //public void NavigateToACReportsPointReports()
        //{
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavPointMember);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);
        //}
        //public void NavigateToACAllInteractionReport()
        //{
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReportsAllInteraction);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);

        //}
        //public void NavigateToACReportsPointsReports()
        //{
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReportsPoints);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);
        //}

        //public void NavigateToACReportsOrderReports()
        //{
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReports);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(ACNavReportsOrder);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);
        //}
        //public void VerifyGivenUsersWereListingOnAC(string CdcId)
        //{
        //    WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
        //    BrowserDriver.Sleep(4000);
        //    Assert.IsTrue(driver.FindElement(ACCustomersGridData(CdcId)).Displayed, CdcId + " - Expected user name not showing on the grid");
        //    BrowserDriver.Sleep(1000);
        //}

        //public string VerifyUserOrderDetailsListingOnAC(string CdcId)
        //{
        //    WebHandlers.Instance.EnterText(ACOrderCDCIdSearch, CdcId);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(6000);
        //    Assert.IsTrue(driver.FindElement(ACOrdersGridData(CdcId)).Displayed, CdcId + " - Expected user data showing on the orders grid");
        //    string OrderId = WebHandlers.Instance.GetAttribute(driver.FindElement(ACOrdersIdGridData(CdcId)), "text"); ;
        //    Assert.IsNotNull(OrderId, OrderId + "AC - Order id not generated against user's order");
        //    BrowserDriver.Sleep(1000);
        //    return OrderId;
        //}

        //public void ValidateUserTierDetailsOnAC(string CdcId)
        //{
        //    WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
        //    WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
        //    BrowserDriver.Sleep(4000);
        //    WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
        //    BrowserDriver.Sleep(4000);
        //    Assert.AreEqual("Black", WebHandlers.Instance.GetAttribute(ACCustomerCurrentTierData, "innerHTML"), "AC - Customer tier details is not showing as expected");
        //}

        //public void ValidateUserRewardsPointsDetailsOnAC(string CdcId)
        //{
        //    WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
        //    WebWaitHelper.Instance.WaitForElementPresence(driver.FindElement(ACCustomersGridData(CdcId)));
        //    BrowserDriver.Sleep(4000);
        //    WebHandlers.Instance.ClickByJsExecutor(driver.FindElement(ACCustomersGridData(CdcId)));
        //    BrowserDriver.Sleep(4000);
        //    Assert.AreEqual("5000", WebHandlers.Instance.GetAttribute(ACCustomerRewardsPointsData, "innerHTML"), "AC - Customer rewards points is not showing as expected");
        //}
        //public void ValidateAmexUserRewardsPointsDetailsOnAC(string CdcId)
        //{
        //    WebHandlers.Instance.EnterText(ACUserSearch, CdcId);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);

        //    BrowserDriver.Sleep(4000);


        //    Assert.AreEqual("100", driver.FindElement(By.XPath("(//a[text()='" + CdcId + "']//..//..//following-sibling::td[5])[1]")).Text);
        //    Assert.AreEqual("100", driver.FindElement(By.XPath("(//a[text()='" + CdcId + "']//..//..//following-sibling::td[5])[2]")).Text);

        //}
        //public void ValidateQNBUserRewardsPointsDetailsOnAC(string CdcId)
        //{
        //    WebHandlers.Instance.EnterText(ACUserSearch, CdcId);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);

        //    BrowserDriver.Sleep(4000);


        //    Assert.AreEqual("1000", driver.FindElement(By.XPath("(//a[text()='" + CdcId + "']//..//..//following-sibling::td[5])[1]")).Text);
        //}
        //public void ValidateUserBonusPointsDetailsOnAC(string CdcId)
        //{
        //    WebHandlers.Instance.EnterText(ACCDCIdSearch, CdcId);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);

        //    BrowserDriver.Sleep(4000);
        //    Assert.AreEqual("5000", driver.FindElement(ACCustomerEarnedPoints(CdcId)).Text, "AC - Customer Bonus point is not showing as expected");
        //}

        //public void ValidateAddedMembersHierarchyinAC(string groupid, string fromdate, string todate, String[] member)
        //{
        //    WebHandlers.Instance.EnterText(ACCHierArchyFromDate, fromdate);
        //    WebHandlers.Instance.EnterText(ACCHierArchyToDate, todate);
        //    WebHandlers.Instance.EnterText(ACCHierArchy_GrpID, groupid);
        //    WebHandlers.Instance.ClickByJsExecutor(ACCustomerSearchBtn);
        //    BrowserDriver.Sleep(4000);
        //    for (int i = 0; i < member.Length; i++)
        //    {
        //        Assert.IsTrue(driver.FindElement(ACOrdersGridData(member[i])).Displayed, member[i] + " - Expected user data showing on the orders grid");
        //    }
        //}
        #endregion

        #region SMC Events
        //public void PerformSMCLogin(string userName, string password)
        //{
        //    WebHandlers.Instance.EnterText(SMCloginEmail, userName, $"Entered {userName} for login email");
        //    WebHandlers.Instance.ClickByJsExecutor(SMCContinueButton, "Continue");
        //    BrowserDriver.Sleep(5000);
        //    WebHandlers.Instance.EnterText(SMCloginPassword, password, $"Entered password for login email");
        //    WebHandlers.Instance.ClickByJsExecutor(SMCloginButton, "Login");
        //    BrowserDriver.Sleep(5000);
        //    if (SMCloginButton.Displayed)
        //        WebHandlers.Instance.ClickByJsExecutor(SMCloginButton, "Remember Yes");
        //    BrowserDriver.Sleep(5000);

        //}

        //public void NavigateToSMCContacts()
        //{
        //    WebWaitHelper.Instance.WaitForElementPresence(SMCNavMenuContacts);
        //    WebHandlers.Instance.ClickByJsExecutor(SMCNavMenuContacts);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(SMCNavContacts);
        //    BrowserDriver.Sleep(5000);
        //}
        //public void validateMiniHarrodsPresentSMC()
        //{
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);

        //    Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("Yes")).Displayed);

        //}

        //public void NavigateToSMCCampaigns()
        //{
        //    //WebHandlers.Instance.ClickByJsExecutor(SMCNavCampaigns);
        //    WebHandlers.Instance.Click(SMCNavCampaigns);
        //    BrowserDriver.Sleep(5000);
        //}

        //public void SearchAdhocCampaignandOpenLatestSMC()
        //{

        //    driver.FindElement(By.XPath("//*[contains(text(),'Campaigns (')]")).Click();
        //    BrowserDriver.Sleep(3000);
        //    //WebHandlers.Instance.EnterText(SMCCampaignSearchBox, "Adhoc");
        //    //Actions a = new Actions(driver);
        //    //a.MoveToElement(SMCCampaignSearchBox).Click().SendKeys("Adhoc").Click().Build().Perform();
        //    //SMCCampaignSearchBox.SendKeys("Adhoc");
        //    driver.FindElement(By.XPath("//bdi[text()='Create']/preceding::input[1]")).SendKeys("Adhoc");
        //    BrowserDriver.Sleep(2000);
        //    //WebHandlers.Instance.Click(SMCSearchButton);
        //    //clicking the first element in the table grid
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//table[1]/tbody[1]/tr[1]/td[1]/div[1]/div[1]/div[3]/a[1]")));

        //}

        //public void SelectMiniHarrodsBdayWeekAdhocSMC()
        //{
        //    BrowserDriver.Sleep(3000);
        //    SMCTargetGroupMenu.Click();
        //    BrowserDriver.Sleep(3000);
        //    SMCMiniHarrodsBdayLink.Click();
        //    BrowserDriver.Sleep(3000);
        //    SMCMiniHarrodsBdaySegmentLink.Click();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void InsertEmailinSegmentAndExecuteSMC(string Email)
        //{
        //    ReadOnlyCollection<string> window_handles = driver.WindowHandles;

        //    string current_tabwindow = driver.CurrentWindowHandle;
        //    Console.WriteLine("list of pages ==>" + current_tabwindow);
        //    foreach (string handle in window_handles)
        //    {
        //        if (!handle.Equals(current_tabwindow))
        //        {
        //            driver.SwitchTo().Window(handle);
        //        }
        //    }
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SMCSegmentActionMenu);
        //    BrowserDriver.Sleep(2000);
        //    //Boolean changesegmentdisplay = SMC_SAPMenu_ChangeSegment.Displayed;
        //    //if (changesegmentdisplay)
        //    //{
        //    WebHandlers.Instance.Click(SMC_SAPMenu_ChangeSegment);
        //    SMC_SAPMenu_ChangeSegment_Emailbox.Clear();
        //    BrowserDriver.Sleep(2000);
        //    SMC_SAPMenu_ChangeSegment_Emailbox.SendKeys(Email);
        //    //WebHandlers.Instance.EnterText(SMC_SAPMenu_ChangeSegment_Emailbox, Email);
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//button[text()='Keep']")));
        //    ReadOnlyCollection<string> handles = driver.WindowHandles;
        //    string currenttab = driver.CurrentWindowHandle;
        //    foreach (string handle in handles)
        //    {
        //        if (!handle.Equals(currenttab))
        //        {
        //            driver.SwitchTo().Window(handle);
        //        }
        //    }
        //    BrowserDriver.Sleep(3000);
        //    // }
        //}

        //public string CopyandCreateCampaignSMC()
        //{
        //    WebHandlers.Instance.Click(SMC_SAPMenu_ContactBasedSegmentation);
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Rebuild']")));
        //    BrowserDriver.Sleep(5000);
        //    WebHandlers.Instance.Click(SMC_SubMenuCampaigns);
        //    WebHandlers.Instance.Click(SMC_AdhocCampaign_TABLELink);
        //    BrowserDriver.PageWait();
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Copy']")));
        //    BrowserDriver.Sleep(6000);
        //    string campaign_exist = driver.FindElement(By.XPath("//bdi[text()='Campaign Name']/following::input[1]")).Text;
        //    int number = Int32.Parse(campaign_exist) + 1;
        //    string campaign_new = "Mini Harrods birthday week adhoc Camp" + number.ToString();
        //    WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("//bdi[text()='Campaign Name']/following::input[1]")), campaign_new);
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Create']")));
        //    BrowserDriver.Sleep(6000);
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Done']")));
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Start']")));
        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Yes']")));
        //    BrowserDriver.Sleep(6000);
        //    return campaign_new;
        //}

        //public void ValidatewhetherEMailsdeliveredSMC()
        //{
        //    WebHandlers.Instance.Click(SMC_SubMenuOverview);
        //    driver.Navigate().Refresh();
        //    Boolean campaignstatus = driver.FindElement(By.XPath("//span[text()='Finished']")).Displayed;
        //    if (campaignstatus)
        //    {
        //        Boolean email_delivery = driver.FindElement(By.XPath("//*[@stroke='#ffffff']")).Displayed;
        //        Assert.IsTrue(email_delivery, "Emails are not delivered properly");
        //    }
        //    else
        //    {
        //        driver.Navigate().Refresh();
        //        BrowserDriver.PageWait();
        //        Boolean email_delivery = driver.FindElement(By.XPath("//*[@stroke='#ffffff']")).Displayed;
        //        Assert.IsTrue(email_delivery, "Emails are not delivered properly");
        //    }
        //}

        //public void ValidateCustomerTierinSMC(string Email, string FullName, string Tier)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(5000);
        //    Assert.IsTrue(driver.FindElement(SMCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
        //    WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())));
        //    BrowserDriver.Sleep();
        //    Assert.IsTrue(driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
        //    BrowserDriver.Sleep();

        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);

        //    string Customertier = WebHandlers.Instance.GetTextOfElement(SMCCustomerTierData);
        //    Assert.IsTrue(Customertier.Equals(Tier), "The Customer tier is not changed as expected");
        //}

        //public void VerifyGivenUsersWithCardEmailWereListingOnSMC(string UserName, string Email, string CardNumber, string EmailConsent)
        //{
        //    CardNumber = CardNumber.Trim();
        //    //string FullName = UserName + " " + UserName + "Lname";
        //    string FullName = UserName;
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(5000);
        //    Assert.IsTrue(driver.FindElement(SMCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
        //    WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())));
        //    BrowserDriver.Sleep();
        //    Assert.IsTrue(driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
        //    BrowserDriver.Sleep();

        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    if (CardNumber == "")
        //    {
        //        Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(CardNumber)).Displayed, CardNumber + " - Expected card number not showing on the grid");
        //    }
        //    else { Console.WriteLine("Card number is not available for this customer!"); }

        //    SMCCustomersSubtabPermissionMarketing.Click();
        //    BrowserDriver.Sleep(3000);
        //    SMCPermissionGraphViewBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    if (EmailConsent == "Yes")
        //        Assert.IsTrue(driver.FindElement(SMCCustomersOptInGrid(Email.ToLower())).Displayed, Email + " - Expected email not showing under Opt In");
        //    else if (EmailConsent == "No")
        //        Assert.IsTrue(driver.FindElement(SMCCustomersOptOutGrid(Email.ToLower())).Displayed, Email + " - Expected email not showing under Opt Out");

        //    SMCCustomersSubtabBackBtn.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void VerifyGivenUsersWereListingOnSMC(string UserName, string Email)
        //{
        //    string FullName = UserName + " " + UserName + "Lname";
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(5000);
        //    Assert.IsTrue(driver.FindElement(SMCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
        //    WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())));
        //    BrowserDriver.Sleep();
        //    Assert.IsTrue(driver.FindElement(SMCCustomersGridEmailData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
        //    BrowserDriver.Sleep();
        //}

        //public void VerifyCardEmailConsentDetailsOnSMC(string UserName, string Email, string CardNumber, string EmailConsent)
        //{
        //    string FullName = UserName + " " + UserName + "Lname";
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(CardNumber)).Displayed, CardNumber + " - Expected card number not showing on the grid");

        //    SMCCustomersSubtabPermissionMarketing.Click();
        //    BrowserDriver.Sleep(3000);
        //    if (EmailConsent == "Yes")
        //        Assert.IsTrue(driver.FindElement(SMCCustomersOptInGrid(Email.ToLower())).Displayed, Email + " - Expected email not showing under Opt In");
        //    else if (EmailConsent == "No")
        //        Assert.IsFalse(driver.FindElements(SMCCustomersOptInGrid(Email.ToLower())).Count != 0, Email + " - Expected email not showing under Opt Out");

        //    SMCCustomersSubtabBackBtn.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void VerifyUserOrderDetailsOnSMC(string UserName, string Email, string OrderNumber)
        //{
        //    string FullName = UserName + " " + UserName + "Lname";
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    SMCCustomersSubtabInteractions.Click();
        //    BrowserDriver.Sleep(3000);
        //    //Assert.IsTrue(driver.FindElement(SMCCustomersProductOrderData(OrderNumber)).Displayed, OrderNumber + " - Expected order number not showing on the grid");
        //    Assert.AreEqual("1", WebHandlers.Instance.GetAttribute(SMCInteractionLoyaltyPannelCount, "innerHTML"), "Performed purchase count is not showing as expected");
        //    SMCCustomersSubtabBackBtn.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //}

        //public void ValidateUserTierDetailsOnSMC(string FullName, string Email)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(SMCCustomersCurrentTierDetails("Black")).Displayed, "Customer tier details is not showing as expected on SMC");
        //}

        //public void ValidateUserRewardsPointsOnSMC(string FullName, string Email)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(SMCCustomersRewrdsPointsDetails("5,000.00")).Displayed, "Customer rewards point is not showing as expected on SMC");
        //}

        //public void ValidateUserAddedAddressOnSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    //Editing given customer from SMC
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Validating added address
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on SMC customer personal data grid");
        //    Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["AddressLine2"])).Displayed, PostalAddress["AddressLine2"] + " not showing on SMC customer personal data grid");
        //    //Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["AddressLine3"])).Displayed, PostalAddress["AddressLine3"] + " not showing on SMC customer personal data grid");
        //    // Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on SMC customer personal data grid");
        //    //Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["State"])).Displayed, PostalAddress["State"] + " not showing on SMC customer personal data grid");
        //    //Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on SMC customer personal data grid");
        //    //Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SMC customer personal data grid");
        //    //Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["CellPhone"])).Displayed, PostalAddress["CellPhone"] + " not showing on SMC customer personal data grid");
        //}
        //public void validateCityStatePostcodeInSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Validating added address
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["Country"])).Displayed, PostalAddress["State"] + " not showing on SMC customer personal data grid");
        //    Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on SMC customer personal data grid");
        //    Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SMC customer personal data grid");
        //}

        //public void ValidateUserAddressGetDeletedFromSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    //Editing given customer from SMC
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Validating added address
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);

        //    Assert.IsFalse(driver.FindElements(SMCCustomersPersonalDetails(PostalAddress["AddressLine1"])).Count != 0, PostalAddress["AddressLine1"] + " not get deleted from SMC");
        //    Assert.IsFalse(driver.FindElements(SMCCustomersPersonalDetails(PostalAddress["AddressLine2"])).Count != 0, PostalAddress["AddressLine2"] + " not get deleted from SMC");
        //    Assert.IsFalse(driver.FindElements(SMCCustomersPersonalDetails(PostalAddress["AddressLine3"])).Count != 0, PostalAddress["AddressLine3"] + " not get deleted from SMC");
        //}

        //public void ValidateUserAddedPhonenumberOnSMC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        //{
        //    //Editing given customer from SMC

        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Validating added phone number
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);

        //    Assert.IsTrue(driver.FindElement(SMCCustomersPersonalDetails(PostalAddress["CellPhone"])).Displayed, PostalAddress["CellPhone"] + " not showing on SMC customer personal data grid");
        //}

        //public void ValidatePhonenumberDeletedinSMC(string username, string email, string phonenumber)
        //{
        //    //Boolean mobile_display;
        //    int mobile_display;
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SMCCustomersGridData(username)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(2000);
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    try
        //    {
        //        mobile_display = driver.FindElements(By.XPath("//*[text()='" + phonenumber + "']")).Count;

        //        if (mobile_display == 0)
        //        {
        //            Assert.Pass("Mobile number deleted successfully");
        //        }
        //        else
        //        {
        //            Assert.Fail("Mobile number is not deleted");
        //        }
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        Assert.Pass("Mobile number deleted successfully");
        //    }

        //}

        //public void ValidatewhetherDOBUpdated(string username, string email, string DOB)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SMCCustomersGridData(username)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(By.XPath("//*[text()='" + DOB + "']")).Displayed, "The DOB is not updated");
        //}

        //public void ValidateUserAddedPhonenumberOnSMC(String Email, String Phonenumber)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);            
        //    driver.FindElement(SMCCustomersGridData(user_fullname)).Click();
        //}
        //public void ValidateUserdetailsonSMC(string firstname, string lastname, string dob, string email)
        //{
        //    string username = firstname + " " + lastname;
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    driver.FindElement(SMCCustomersGridData(username)).Click();
        //    BrowserDriver.Sleep(3000);
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);

        //    string displayed_username = driver.FindElement(By.XPath("//*[@id='PersonalDataBlock-Collapsed--contactName-inner']")).Text;
        //    string displayed_dob = driver.FindElement(By.XPath("//*[@id='PersonalDataBlock-Collapsed--DateOfBirth-text']")).Text;

        //    Assert.IsTrue(displayed_username.Equals(username), "Username is not created as expected");
        //    Assert.IsTrue(displayed_dob.Equals(dob), "DOB is not displayed as expected");
        //}
        //public void ValidateUserAddedPhonenumberOnSMC(String countrycode, String phonenumber, String username, String Email)
        //{
        //    string UserPhone = "";
        //    BrowserDriver.Sleep(3000);

        //    switch (countrycode)
        //    {
        //        case ("UK"):
        //            UserPhone = "+44" + phonenumber;
        //            break;
        //        case ("US"):
        //            UserPhone = "+1" + phonenumber;
        //            break;
        //        case ("China"):
        //            UserPhone = "+86" + phonenumber;
        //            break;
        //        case ("Canada"):
        //            UserPhone = "+1" + phonenumber;
        //            break;
        //        case ("France"):
        //            UserPhone = "+33" + phonenumber;
        //            break;
        //    }

        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    Console.WriteLine(username);
        //    driver.FindElement(SMCCustomersGridData(username)).Click();
        //    BrowserDriver.Sleep(3000);
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    Boolean displayed_status = driver.FindElement(SMCPhoneNumber(UserPhone)).Displayed;
        //    if (displayed_status)
        //    {
        //        Console.WriteLine("Phone number is displayed as expected");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Phone number is not displayed as expected");
        //    }
        //}

        //public void ValidateUserRegisteredforRewardsSMC(string username, string email)
        //{
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(SMCCustomersGridData(username)));
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SMCCustomersSubtabPersonalData);
        //    BrowserDriver.Sleep(2000);
        //    string optinstat = SMCCustomerRewardOptinStatus.Text;
        //    Assert.IsTrue(optinstat.Equals("Yes"), "The Rewards option is not opted");

        //}

        //public void ValidateRewardCardforCustomerinSMC(string username, string email, string new_Card)
        //{
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(SMCCustomersGridData(username)));
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SMCCustomersSubtabPersonalData);
        //    BrowserDriver.Sleep(2000);

        //    string rewardcard_SMC = SMC_RewardCardNumber_TextRO.Text;
        //    //Assert.IsTrue(rewardcard_SMC.Equals(card_assigned),"Reward Card "+ card_assigned + " is not updated in SMC. Old card "+ rewardcard_SMC + " is displayed");
        //    Assert.IsTrue(rewardcard_SMC.Equals(new_Card), "Reward Card --> " + new_Card + " is not updated in SMC. Old card --> " + rewardcard_SMC + " is displayed");
        //}

        //public void ValidateChilddetailsOnSMC(string FullName, string Email, Boolean isMember)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Validating added address
        //    SMCCustomersSubtabPersonalData.Click();
        //    BrowserDriver.Sleep(3000);
        //    if (isMember)
        //        Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("Yes")).Displayed);
        //    else
        //    {
        //        Assert.IsTrue(driver.FindElement(SMCMiniHarrodsMember("No")).Displayed);
        //    }

        //}

        //public void ValidateLoyaltyuserSMCChannelPref(string FullName, string Email, string channel,string Status)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Validating SMC customer channels consent
        //    SMCCustomersSubtabPermissionMarketing.Click();
        //    BrowserDriver.Sleep(3000);
        //    SMCPermissionDetailViewBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    if (channel == "email")
        //    {
        //        Assert.AreEqual(Status, driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");

        //    }
        //    if (channel == "postal")
        //    {
        //        //Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
        //        Assert.AreEqual(Status, driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Postal channel consent is not showing under Opt Out");
        //    }
        //}
        //public void ValidateLoyaltyuserSMCCommunicationPreferencesOpting(string FullName, string Email, string channel, string SMCInterestPage, string CdcId)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Validating SMC customer channels consent
        //    SMCCustomersSubtabPermissionMarketing.Click();
        //    BrowserDriver.Sleep(3000);
        //    SMCPermissionDetailViewBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    if (channel == "email")
        //    {
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");

        //    }
        //    if (channel == "postal")
        //    {
        //        //Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");

        //    }
        //    //Validating SMC customer interests consent
        //    driver.Navigate().GoToUrl(SMCInterestPage);
        //    WebWaitHelper.Instance.WaitForElementPresence(SMCInterestCustomerSearch);
        //    WebHandlers.Instance.Click(SMCInterestAdaptiveFilter);
        //    BrowserDriver.Sleep(2000);
        //    WebWaitHelper.Instance.WaitForElementPresence(SMCInterestAdaptiveFilterOk);
        //    Actions FilterAction = new Actions(driver);
        //    FilterAction.MoveToElement(driver.FindElement(SMCInterestFilterCheckbox("Contact ID"))).Click().Build().Perform();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SMCInterestAdaptiveFilterOk);
        //    BrowserDriver.Sleep(2000);
        //    WebWaitHelper.Instance.WaitForElementPresence(SMCInterestContactIdSearch);
        //    WebHandlers.Instance.EnterText(SMCInterestContactIdSearch, CdcId + "\n");
        //    BrowserDriver.Sleep(5000);

        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
        //    Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");



        //}
        //public void ValidateremoveAllInterestSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist, List<String> InterestList)
        //{
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

        //    scenarioContext.Add("UserCDCId", customer_cdcid);

        //    driver.FindElement(SSCCustomersGridData(UserName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    SSCCustomersSubtabPreferences.Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);


        //    foreach (String item in InterestList)
        //    {
        //        Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS OPTED");

        //    }
        //    validateMiniHarrodsPresentSSC();
        //}
        //public void ValidateSMCCommunicationPreferencesOpting(string FullName, string Email, string OptStatus, string SMCInterestPage, string CdcId)
        //{
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.EnterText(SMCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(7000);
        //    driver.FindElement(SMCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(5000);

        //    //Validating SMC customer channels consent
        //    SMCCustomersSubtabPermissionMarketing.Click();
        //    BrowserDriver.Sleep(3000);
        //    SMCPermissionDetailViewBtn.Click();
        //    BrowserDriver.Sleep(1000);
        //    if (OptStatus == "Opt-In All")
        //    {
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt In");
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt In");
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt In");
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt In");
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt In");
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt In");
        //    }

        //    else if (OptStatus == "Opt-Out All")
        //    {
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
        //    }

        //    else if (OptStatus == "Opt-Some")
        //    {
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Experian")).GetAttribute("innerHTML"), "SMC - Experian channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Facebook")).GetAttribute("innerHTML"), "SMC - Facebook channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Google Ads")).GetAttribute("innerHTML"), "SMC - Google Ads channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-In", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
        //    }
        //    else if (OptStatus == "removeAllConsent")
        //    {
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Email")).GetAttribute("innerHTML"), "SMC - Email channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Phone")).GetAttribute("innerHTML"), "SMC - Phone channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("SMS")).GetAttribute("innerHTML"), "SMC - SMS channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Post")).GetAttribute("innerHTML"), "SMC - Post channel consent is not showing under Opt Out");
        //        Assert.AreEqual("Opt-Out", driver.FindElement(SMCChannelPermissionStatus("Publications")).GetAttribute("innerHTML"), "SMC - Publications channel consent is not showing under Opt Out");
        //    }

        //    //Validating SMC customer interests consent
        //    driver.Navigate().GoToUrl(SMCInterestPage);
        //    WebWaitHelper.Instance.WaitForElementPresence(SMCInterestCustomerSearch);
        //    WebHandlers.Instance.Click(SMCInterestAdaptiveFilter);
        //    BrowserDriver.Sleep(2000);
        //    WebWaitHelper.Instance.WaitForElementPresence(SMCInterestAdaptiveFilterOk);
        //    Actions FilterAction = new Actions(driver);
        //    FilterAction.MoveToElement(driver.FindElement(SMCInterestFilterCheckbox("Contact ID"))).Click().Build().Perform();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SMCInterestAdaptiveFilterOk);
        //    BrowserDriver.Sleep(2000);
        //    WebWaitHelper.Instance.WaitForElementPresence(SMCInterestContactIdSearch);
        //    WebHandlers.Instance.EnterText(SMCInterestContactIdSearch, CdcId + "\n");
        //    BrowserDriver.Sleep(5000);
        //    if (OptStatus == "Opt-In All")
        //    {
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");
        //    }

        //    else if (OptStatus == "Opt-Out All")
        //    {
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt Out");
        //    }

        //    else if (OptStatus == "Opt-Some")
        //    {

        //    }
        //    else if (OptStatus == "Opt-mixed")
        //    {
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt Out");
        //        Assert.AreEqual("No", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt Out");

        //    }
        //    else if (OptStatus == "removeAllConsent")
        //    {
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "BeautyGrooming")).GetAttribute("innerHTML"), "SMC - BeautyGrooming interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Menswear")).GetAttribute("innerHTML"), "SMC - Menswear interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineJewellery")).GetAttribute("innerHTML"), "SMC - FineJewellery interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "Womenswear")).GetAttribute("innerHTML"), "SMC - Womenswear interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FineWatches")).GetAttribute("innerHTML"), "SMC - FineWatches interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "SalonWellnessServices")).GetAttribute("innerHTML"), "SMC - SalonWellnessServices interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "FoodRestaurants")).GetAttribute("innerHTML"), "SMC - FoodRestaurants interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "HomeTechnology")).GetAttribute("innerHTML"), "SMC - HomeTechnology interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "WineSpirits")).GetAttribute("innerHTML"), "SMC - WineSpirits interest consent is not showing under Opt In");
        //        Assert.AreEqual("Yes", driver.FindElement(SMCInterestsConsentStatus(CdcId, "KidsToys")).GetAttribute("innerHTML"), "SMC - KidsToys interest consent is not showing under Opt In");
        //    }

        //}

        //public void ValidatechildGetsDeletedFromSSC(string FullName, string Email)
        //{
        //    //Navigating to the page and editing given customer
        //    try { SSCCustomersSearchIcon.Click(); }
        //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
        //    BrowserDriver.Sleep();
        //    WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
        //    BrowserDriver.Sleep(3000);
        //    string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        //    driver.FindElement(SSCCustomersGridData(FullName)).Click();
        //    BrowserDriver.PageWait();
        //    BrowserDriver.Sleep(3000);

        //    //Validating child gets deleted from the grid
        //    WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
        //    BrowserDriver.Sleep(1000);
        //    driver.FindElement(SSCNewTicketSubTabs("Relationships")).Click();
        //    BrowserDriver.Sleep(3000);
        //    string count = SSCMiniHarrodsChildrenCount.Text.Replace("(", string.Empty).Replace(")", string.Empty);
        //    Assert.IsFalse(Int32.Parse(count) != 0, "not get deleted from SMC");

        //}
        #endregion

        #region FF Events  

        //public void ClickOnAcceptAndContinue()
        //{
        //    if (WebHandlers.Instance.WebElementExists(Accept))
        //        WebHandlers.Instance.ClickByJsExecutor(Accept, "Accept");
        //}

        //public void InvokeRegistrationProcess()
        //{
        //    WebHandlers.Instance.ClickByJsExecutor(Register, "Register");
        //}

        //public void InvokeSignInProcessafterRegisteration()
        //{
        //    WebHandlers.Instance.ClickByJsExecutor(SignIn, "Sign In");
        //    BrowserDriver.Sleep(4000);
        //    /*WebHandlers.Instance.EnterText(loginEmail, Email, $"Entered {Email} for login email");
        //    WebHandlers.Instance.EnterText(loginPassword, Password, $"Entered ******** for password");
        //    WebHandlers.Instance.ClickByJsExecutor(Login2, "Login");
        //    BrowserDriver.Sleep(2000);*/
        //}

        //public void SignInAfterConfirmation(string userName, string password)
        //{
        //    log.Info("Sign In after confirmation.");
        //    BrowserDriver.Sleep(10000);
        //    WebHandlers.Instance.EnterText(loginEmail, userName, $"Entered {userName} for login email");
        //    WebHandlers.Instance.EnterText(loginPassword, password, $"Entered ******** for password");
        //    WebHandlers.Instance.ClickByJsExecutor(Login1, "Login");
        //    BrowserDriver.Sleep(10000);

        //}
        //public void InvokeSignInProcess(string userName, string password)
        //{
        //    //BrowserDriver.Sleep(5000);
        //    WebHandlers.Instance.ClickByJsExecutor(SignIn);
        //    BrowserDriver.Sleep(4000);
        //    WebHandlers.Instance.EnterText(loginEmail, userName, $"Entered {userName} for login email");
        //    WebHandlers.Instance.EnterText(loginPassword, password, $"Entered ******** for password");
        //    WebHandlers.Instance.ClickByJsExecutor(Login2, "Login");
        //    BrowserDriver.Sleep(2000);
        //}

        //public void ValidateUserTierDetailsOnHarrodsSite(string CurrentTier)
        //{
        //    BrowserDriver.Sleep(3000);
        //    Assert.IsTrue(driver.FindElement(FFCustomersCurrentTierDetails(CurrentTier)).Displayed, "Customer tier details is not showing as expected on Harrods.com");
        //}

        //public void ValidateUserRewardsPointsOnHarrodsSite(string RewardsPoint)
        //{
        //    BrowserDriver.Sleep(3000);
        //    Assert.AreEqual(RewardsPoint, WebHandlers.Instance.GetAttribute(FFCustomersRewardsPointsDetails, "innerHTML"), "Harrods.com - Customer rewards points is not showing as expected");
        //}

        //public void NavigateToHarrodsCommunicationPreferences()
        //{
        //    BrowserDriver.Sleep(3000);
        //    //WebHandlers.Instance.ClickByJsExecutor(Register, "Register");
        //    WebHandlers.Instance.Click(CommunicationPreferences);
        //    BrowserDriver.Sleep(3000);
        //    //driver.Navigate().Refresh();
        //    WebWaitHelper.Instance.WaitForElementPresence(UserChannelsHeader);
        //}

        //public void PerformHarrodsCommunicationPreferencesOpting(string OptStatus)
        //{
        //    if (OptStatus == "Opt-In All")
        //    {
        //        PerformOptChannel(FFChannelConsentField("email"), true);
        //        PerformOptChannel(FFChannelConsentField("postal"), true);
        //        PerformOptChannel(FFChannelConsentField("sms"), true);
        //        PerformOptChannel(FFChannelConsentField("phone"), true);
        //        PerformOptChannel(FFChannelConsentField("publications"), true);

        //        if (driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled") == "False")
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
        //        WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Select all")));
        //    }
        //    else if (OptStatus == "Opt-Out All")
        //    {
        //        PerformOptChannel(FFChannelConsentField("email"), false);
        //        PerformOptChannel(FFChannelConsentField("postal"), false);
        //        PerformOptChannel(FFChannelConsentField("sms"), false);
        //        PerformOptChannel(FFChannelConsentField("phone"), false);
        //        PerformOptChannel(FFChannelConsentField("publications"), false);
        //        if (driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled") == "False")
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
        //    }
        //    else if (OptStatus == "Opt-Some")
        //    {
        //        PerformOptChannel(FFChannelConsentField("email"), true);
        //        consentselection.Add("email");
        //        PerformOptChannel(FFChannelConsentField("postal"), true);
        //        consentselection.Add("postal");
        //        PerformOptChannel(FFChannelConsentField("sms"), false);
        //        PerformOptChannel(FFChannelConsentField("phone"), false);
        //        PerformOptChannel(FFChannelConsentField("publications"), true);
        //        consentselection.Add("publications");
        //        Boolean selectstatus = driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled") == "True";

        //        if (selectstatus)
        //        {
        //            //WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
        //            //BrowserDriver.Sleep(3000);
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Womenswear")));
        //            interestselection.Add("Womenswear");
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Home & Technology")));
        //            interestselection.Add("Home & Technology");
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Kids & Toys")));
        //            interestselection.Add("Kids & Toys");
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Salon & Wellness Services")));
        //            interestselection.Add("Salon & Wellness Services");
        //        }
        //        else if (!selectstatus)
        //        {
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
        //            BrowserDriver.Sleep(3000);
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Womenswear")));
        //            interestselection.Add("Womenswear");
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Home & Technology")));
        //            interestselection.Add("Home & Technology");
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Kids & Toys")));
        //            interestselection.Add("Kids & Toys");
        //            WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionBtn("Salon & Wellness Services")));
        //            interestselection.Add("Salon & Wellness Services");

        //        }
        //    }

        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
        //}

        //public void ValidateHarrodsCommunicationPreferencesOpting(string OptStatus)
        //{
        //    if (OptStatus == "Opt-In All")
        //    {
        //        ValidateOptChannel(FFChannelConsentField("email"), true);
        //        ValidateOptChannel(FFChannelConsentField("postal"), true);
        //        ValidateOptChannel(FFChannelConsentField("sms"), true);
        //        ValidateOptChannel(FFChannelConsentField("phone"), true);
        //        ValidateOptChannel(FFChannelConsentField("publications"), true);
        //        Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled"), "All interests not showing as opted in");
        //    }
        //    else if (OptStatus == "Opt-Out All")
        //    {
        //        ValidateOptChannel(FFChannelConsentField("email"), false);
        //        ValidateOptChannel(FFChannelConsentField("postal"), false);
        //        ValidateOptChannel(FFChannelConsentField("sms"), false);
        //        ValidateOptChannel(FFChannelConsentField("phone"), false);
        //        ValidateOptChannel(FFChannelConsentField("publications"), false);
        //        Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled"), "All interests not showing as opted out");
        //    }
        //    else if (OptStatus == "Opt-Some")
        //    {
        //        ValidateOptChannel(FFChannelConsentField("email"), true);
        //        ValidateOptChannel(FFChannelConsentField("postal"), true);
        //        ValidateOptChannel(FFChannelConsentField("sms"), false);
        //        ValidateOptChannel(FFChannelConsentField("phone"), false);
        //        ValidateOptChannel(FFChannelConsentField("publications"), true);
        //    }
        //    else if (OptStatus == "Opt-email")
        //    {
        //        PerformOptChannel(FFChannelConsentField("email"), true);
        //    }
        //    else if (OptStatus == "Opt-In-email")
        //    {
        //        ValidateOptChannel(FFChannelConsentField("email"), true);
        //    }

        //}

        //public void PerformOptChannel(By ChannelField, bool OptValue)
        //{
        //    string checkstatus = driver.FindElement(ChannelField).GetAttribute("checked");
        //    Console.WriteLine("check status " + checkstatus);
        //    Console.WriteLine("optvalue " + OptValue);

        //    if (OptValue && string.IsNullOrEmpty(checkstatus))
        //    {
        //        WebHandlers.Instance.Click(driver.FindElement(ChannelField));
        //    }
        //    else if ((OptValue.ToString() == "False") && checkstatus == "true")
        //    //else if (!OptValue && string.IsNullOrEmpty(driver.FindElement(ChannelField).GetAttribute("checked")))
        //    {

        //        WebHandlers.Instance.Click(driver.FindElement(ChannelField));
        //    }
        //    BrowserDriver.Sleep(1000);
        //}
        //public void PerformHarrodsCommunicationPreferencesOptingChannel(string OptStatus, string channel)
        //{
        //    if (OptStatus == "Opt-In")
        //    {
        //        switch (channel)
        //        {
        //            case "email":
        //                PerformOptChannel(FFChannelConsentField("email"), true);
        //                ValidateOptChannel(FFChannelConsentField("email"), true);
        //                //validateAllInterestOpted();

        //                break;
        //            case "sms":
        //                PerformOptChannel(FFChannelConsentField("sms"), true);
        //                ValidateOptChannel(FFChannelConsentField("sms"), true);
        //                //validateAllInterestOpted();
        //                break;
        //            case "postal":
        //                PerformOptChannel(FFChannelConsentField("postal"), true);
        //                ValidateOptChannel(FFChannelConsentField("postal"), true);
        //                //validateAllInterestOpted();
        //                break;
        //            case "phone":
        //                PerformOptChannel(FFChannelConsentField("phone"), true);
        //                ValidateOptChannel(FFChannelConsentField("phone"), true);
        //                //validateAllInterestOpted();
        //                break;
        //            case "publications":
        //                PerformOptChannel(FFChannelConsentField("publications"), true);
        //                ValidateOptChannel(FFChannelConsentField("publications"), true);
        //                break;
        //                //default:
        //                //    // code block
        //                //    break;
        //        }

        //    }


        //    if (OptStatus == "Opt-In-All")
        //    {
        //        PerformOptChannel(FFChannelConsentField("email"), true);
        //        if (!driver.FindElement(FFChannelConsentField("sms")).Selected)
        //            PerformOptChannel(FFChannelConsentField("sms"), true);
        //        PerformOptChannel(FFChannelConsentField("postal"), true);
        //        PerformOptChannel(FFChannelConsentField("phone"), true);
        //        // validateAllInterestOpted();
        //    }
        //    if (OptStatus == "Opt-In-email")
        //    {
        //        PerformOptChannel(FFChannelConsentField("email"), true);

        //    }
        //    if (OptStatus == "Opt-In-sms")
        //    {
        //        PerformOptChannel(FFChannelConsentField("sms"), true);

        //    }
        //    if (OptStatus == "Opt-In-sms")
        //    {
        //        PerformOptChannel(FFChannelConsentField("sms"), true);

        //    }
        //    if (OptStatus == "Opt-In-postal")
        //    {
        //        PerformOptChannel(FFChannelConsentField("postal"), true);
        //        PerformOptChannel(FFChannelConsentField("publications"), true);

        //    }
        //    if (OptStatus == "No consent")
        //    {     //condition for no consent and select all interest
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS NOT OPTED");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is not selected");
        //        Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is not selected");
        //        //Unselecting all 
        //        WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Unselect all")));
        //        WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")));
        //        WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")));
        //        WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Harrods Rewards")));
        //        WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Mini Harrods")));
        //    }
        //    if (OptStatus == "All consent")
        //    {
        //        ValidateOptChannel(FFChannelConsentField("email"), true);
        //        ValidateOptChannel(FFChannelConsentField("sms"), true);
        //        ValidateOptChannel(FFChannelConsentField("postal"), true);
        //        ValidateOptChannel(FFChannelConsentField("phone"), true);
        //        ValidateOptChannel(FFChannelConsentField("publications"), true);
        //        //unselect all consent 
        //        PerformOptChannel(FFChannelConsentField("email"), false);
        //        PerformOptChannel(FFChannelConsentField("sms"), false);
        //        PerformOptChannel(FFChannelConsentField("postal"), false);
        //        PerformOptChannel(FFChannelConsentField("phone"), false);
        //        PerformOptChannel(FFChannelConsentField("publications"), false);
        //        //validate all interest are greyed out
        //        Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled"), "All interests not showing as opted out");
        //        Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Select all")).GetAttribute("disabled"), "All interests not showing as opted out");
        //        Assert.AreEqual("true", driver.FindElement(FFInterestCheckBoxBtn("Harrods Rewards")).GetAttribute("disabled"), "All interests not showing as opted out");
        //        //Assert.AreEqual("true", driver.FindElement(FFInterestCheckBoxBtn("Mini Harrods")).GetAttribute("disabled"), "All interests not showing as opted out");
        //    }
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
        //    BrowserDriver.Sleep(3000);
        //}
        //public void ValidateInterestOpted(List<string> interest, bool isopted)
        //{
        //    if (isopted == true)
        //    {
        //        foreach (var item in interest)
        //        {
        //            Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn(item)).Selected, item + ":IS NOT OPTED");
        //        }

        //    }
        //    else
        //    {
        //        foreach (var item in interest)
        //        {
        //            Assert.IsFalse(driver.FindElement(FFInterestCheckBoxBtn(item)).Selected, item + ":IS OPTED");
        //        }
        //    }

        //}
        //public void performChannelOpting(string channel, bool opted)
        //{
        //    if (opted == true)
        //    {
        //        PerformOptChannel(FFChannelConsentField(channel), true);
        //    }
        //    else
        //    {
        //        PerformOptChannel(FFChannelConsentField(channel), false);
        //    }
        //    if (channel == "All")
        //    {
        //        PerformOptChannel(FFChannelConsentField("email"), true);
        //    }
        //}
        //public void PerformInterestOpting(List<string> interest, bool isopted)
        //{


        //    foreach (var item in interest)
        //    {

        //        try
        //        {
        //            driver.FindElement(FFInterestCheckBoxBtn(item)).Click();
        //        }
        //        catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", driver.FindElement(FFInterestCheckBoxBtn(item))); }

        //        BrowserDriver.Sleep(1000);
        //        log.Info(item + ": is clicked");
        //    }
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
        //    BrowserDriver.Sleep(3000);

        //}
        //public void PerformHarrodsCommunicationPreferencesOptingChannelForRewardsCust(string OptStatus, string channel)
        //{
        //    if (OptStatus == "Opt-In")
        //    {
        //        switch (channel)
        //        {
        //            case "email":
        //                PerformOptChannel(FFChannelConsentField("email"), true);
        //                //validateAllInterestOptedForRewardsCust();
        //                ValidateOptChannel(FFChannelConsentField("email"), true);
        //                //JoinMiniHarrodsViaCommunicationPreference();
        //                break;
        //            case "sms":
        //                PerformOptChannel(FFChannelConsentField("sms"), true);
        //                //validateAllInterestOpted();
        //                ValidateOptChannel(FFChannelConsentField("sms"), true);
        //                break;
        //            case "postal":
        //                PerformOptChannel(FFChannelConsentField("postal"), true);
        //                //validateAllInterestOptedForRewardsCust();
        //                ValidateOptChannel(FFChannelConsentField("postal"), true);
        //                //JoinMiniHarrodsViaCommunicationPreference();
        //                break;
        //            case "phone":
        //                PerformOptChannel(FFChannelConsentField("phone"), true);
        //                ValidateOptChannel(FFChannelConsentField("phone"), true);
        //                //validateAllInterestOpted();
        //                break;
        //            case "publications":
        //                PerformOptChannel(FFChannelConsentField("publications"), true);
        //                ValidateOptChannel(FFChannelConsentField("publications"), true);
        //                //JoinMiniHarrodsViaCommunicationPreference();
        //                break;
        //                //default:
        //                //    // code block
        //                //    break;
        //        }

        //    }

        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
        //    BrowserDriver.Sleep(3000);
        //}
        //public void PerformMixedSelectionOnInterest(string OptStatus)
        //{
        //    PerformOptChannel(FFChannelConsentField("email"), false);
        //    PerformOptChannel(FFChannelConsentField("sms"), false);
        //    PerformOptChannel(FFChannelConsentField("postal"), false);
        //    PerformOptChannel(FFChannelConsentField("phone"), false);
        //    //Assert.AreEqual("true", driver.FindElement(FFInterestSelectionButton("Unselect all")).GetAttribute("disabled"), "All interests not showing as opted out");
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));
        //    BrowserDriver.Sleep(3000);
        //}
        //public void validateAllInterestOpted()
        //{
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is not selected");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is not selected");
        //    bool HarrodsMagazine = WebHandlers.Instance.isElementPresent(FFChannelConsentField("publications"));
        //    bool MiniHarrodspresent = WebHandlers.Instance.isElementPresent(MiniHarrodsField("Mini Harrods"));
        //    Assert.IsFalse(HarrodsMagazine, "Harrods magazines channel should not be displayed ");
        //    Assert.IsFalse(MiniHarrodspresent, "Mini Harrods should not be Displayed for non rewards user");
        //}

        //public void validateAllInterestOptedOut()
        //{
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is selected");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is selected");

        //}

        //public void validateAllInterestOptedForRewardsCust()
        //{
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS NOT OPTED");
        //    Assert.IsFalse(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is selected");
        //    Assert.IsFalse(driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is selected");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Harrods Rewards")).Selected, "Harrods Rewards is not selected");

        //}
        //public void JoinMiniHarrodsViaCommunicationPreference()
        //{
        //    WebHandlers.Instance.Click(driver.FindElement(JoinMiniHarrodsLink("Mini Harrods")));
        //    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!Clicked join mini harrods");
        //    WebHandlers.Instance.Click(btnSaveChanges);
        //    //WebHandlers.Instance.Click(driver.FindElement(JoinMiniHarrodsSaveChangesButton("Yes, Save Changes")));
        //    //Console.WriteLine("!!!!!!!!!!!!!!!!!!!!Clicked save changes");

        //}
        //public void validateCommunicationPrefLoyaltyUserInterestOpted()
        //{
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Womenswear")).Selected, "Womenswear :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Menswear")).Selected, "Menswear :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Beauty & Grooming")).Selected, "Beauty & Grooming :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Salon & Wellness Services")).Selected, "Salon & Wellness Services :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Jewellery")).Selected, "Fine Jewellery :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")).Selected, "Fine Watches :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Home & Technology")).Selected, "Home & Technology :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Food & Restaurants")).Selected, "Food & Restaurants :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Wine & Spirits")).Selected, "Wine & Spirits :IS NOT OPTED");
        //    Assert.IsTrue(driver.FindElement(FFInterestCheckBoxBtn("Kids & Toys")).Selected, "Kids & Toys :IS NOT OPTED");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Father’s Day")).Selected, "Fathers day is selected");
        //    Assert.IsTrue(!driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")).Selected, "Mothers day is selected");
        //    bool MiniHarrodspresent = WebHandlers.Instance.isElementPresent(MiniHarrodsField("Mini Harrods"));
        //    Assert.IsTrue(MiniHarrodspresent, "Mini Harrods should be Displayed for rewards user");

        //}



        //public void ValidateOptChannel(By ChannelField, bool OptValue)
        //{

        //    Console.WriteLine("Opt value --> " + ChannelField.ToString());
        //    if (OptValue)
        //        Assert.AreEqual("true", driver.FindElement(ChannelField).GetAttribute("checked"), "Opt value for channel not showing as expected");
        //    else if (OptValue == false)
        //        Assert.AreEqual(null, driver.FindElement(ChannelField).GetAttribute("checked"), "Opt value for channel not showing as expected");
        //    //Assert.IsEmpty(driver.FindElement(ChannelField).GetAttribute("checked"), "Opt value for channel not showing as expected");
        //}
        //public void PerformPartialInterestSelection()
        //{
        //    WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Fine Watches")));
        //    WebHandlers.Instance.Click(driver.FindElement(FFInterestCheckBoxBtn("Mother’s Day")));
        //    WebHandlers.Instance.Click(driver.FindElement(FFInterestSelectionButton("Save Preferences")));


        //}




        #endregion

        #region Validation     

        //public void ValidateSiginFailure()
        //{
        //    if (WebHandlers.Instance.WebElementExists(Error))
        //    {

        //        List<string> errors = WebHandlers.Instance.GetTextFromMultipleElements(ErrorMessage);

        //        if (errors.Any())
        //        {
        //            string msg = errors.Aggregate((i, j) => i + ";" + j);
        //            Assert.Fail($"Exception occured while login. Error details: " + msg);
        //        }

        //    }
        //}
        //public void ConfirmStatus(string confirmMsg)
        //{
        //    BrowserDriver.Sleep(4000);
        //    WebHandlers.Instance.VerifyText(AddressConfirmation, confirmMsg);
        //}

        //public string ValidateAddressSwapInHarrods(string address_type)
        //{
        //    string AddressLine1Default = null;
        //    if (address_type == "DeliveryAddress")
        //    {
        //        setDeliveryAddress.Click();
        //        SetAsDefaultBtn.Click();
        //        ConfirmStatus("Your default delivery address has been changed.");
        //        AddressLine1Default = driver.FindElement(By.XPath("//input[@type='checkbox' and @data-test='address-setDefault-delivery']//..//..//preceding-sibling::div//p[1]")).Text;
        //        //scenarioContext.Add("AddressLine", AddressLine1Default.Replace(",", ""));
        //    }

        //    if (address_type == "BillingAddress")
        //    {
        //        setBillingAddress.Click();
        //        SetAsDefaultBtn.Click();
        //        ConfirmStatus("Your default billing address has been changed.");
        //        AddressLine1Default = driver.FindElement(By.XPath("//input[@type='checkbox' and @data-test='address-setDefault-billing']//..//..//preceding-sibling::div//p[1]")).Text;
        //        //scenarioContext.Add("AddressLine", AddressLine1Default.Replace(",", ""));
        //    }

        //    if (address_type == "ContactAddress")
        //    {
        //        WebHandlers.Instance.Click(driver.FindElement(setContactAddress("Set as Default Contact Address")));
        //        SetAsDefaultBtn.Click();
        //        ConfirmStatus("Your default contact address has been changed.");
        //        AddressLine1Default = driver.FindElement(By.XPath("//span[text()='Set as Default Contact Address']//..//..//p[@data-test='address-addressLine1']")).Text;
        //        // scenarioContext.Add("AddressLine", AddressLine1Default.Replace(",", ""));

        //    }
        //    return AddressLine1Default;
        //} 



        //public void CreateTenpDayBookingTicket(string UserName, string Email, string FirstName)
        //{
        //    //Creating manual tier upgrade ticket
        //    //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.Click(SSCTicketCreateBtn);
        //    WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
        //    WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
        //    BrowserDriver.Sleep(3000);
        //    WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
        //    WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
        //    BrowserDriver.Sleep(1000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "10% Nominated Day");
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "G3-A08");
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "G4-AH13");
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
        //    BrowserDriver.Sleep(2000);

        //    //Performing ticket Save and close
        //    WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
        //    Actions ContentAction = new Actions(driver);
        //    BrowserDriver.Sleep(2000);
        //    ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    10% Nominated Day").DoubleClick().Build().Perform();
        //    WebHandlers.Instance.SwithBackFromFrame();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
        //    BrowserDriver.Sleep(4000);
        //    SSCNewTicketSaveOpen.Click();
        //    BrowserDriver.Sleep(6000);

        //    //Selecting an available day for 10p
        //    WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
        //    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
        //    BrowserDriver.Sleep(2000);
        //    driver.FindElement(SSCNewTicketSubTabs("Manage 10% Day Booking")).Click();
        //    WebHandlers.Instance.SwitchToFrame(SSCTicketDetailCalendarFrame);
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.WebElementExists(driver.FindElement(SSCInputFieldValue(FirstName)));
        //    BrowserDriver.Sleep(6000);
        //    driver.FindElement(TenpTicketAvailDateSSC(DateTime.Now.ToString("MMMM 30, yyyy"))).Click();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(TenpTicketNewSSC);
        //    WebHandlers.Instance.WebElementExists(TenpTicketCancelSSC);
        //    BrowserDriver.Sleep(5000);
        //    WebHandlers.Instance.Click(TenpTicketCancelSSC);
        //    WebHandlers.Instance.SwithBackFromFrame();
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.Click(SSCNewTicketSave);
        //    WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        //}

        #endregion
    }
}

