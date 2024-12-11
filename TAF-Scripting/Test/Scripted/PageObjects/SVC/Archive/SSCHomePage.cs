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
//using System.Text.RegularExpressions;
//using OpenQA.Selenium.Interactions;
//using Keys = OpenQA.Selenium.Keys;


//namespace TAF_Scripting.Test.Scripted.PageObjects.SVC
//{
//    class SSCHomePage
//    {

//        public IWebDriver driver;
//        private Configuration config = null;

//        #region  Constructor
//        public SSCHomePage(IWebDriver driver, Configuration configuration)
//        {
//            this.driver = driver;
//            PageFactory.InitElements(this.driver, this);
//            config = configuration;
//        }

//        #endregion

//        #region Elements
//        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
//        private IWebElement SSCCustomersSearchIcon;

//        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
//        private IWebElement SSCCustomersSearchEdit;

//        [FindsBy(How = How.XPath, Using = "(//input[contains(@id,'-searchField-I')])[2]")]
//        private IWebElement SSCCustomersDetailsSearchEdit;

//        //[FindsBy(How = How.XPath, Using = "(//*[@value='Profile data']//preceding::input[1])[1]")]
//        //private IWebElement SSCProfileDataEditCheckBox;



//        public By SSCCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }

//        [FindsBy(How = How.XPath, Using = "//div[@id='__group0--Grid']//child::span//following-sibling::div//a")]
//        private IWebElement SSCLiteCustomerEmailId;

//        //        [FindsBy(How = How.XPath, Using = "(//*[@value='Profile data']//preceding::input[1])[1]")]
//        [FindsBy(How = How.XPath, Using = "//*[@value='Profile data']//preceding::div[1][contains(@id,'checkbox')]")]
//        private IWebElement SSCProfileDataEditCheckBox;

//        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }

//        private By SSCCustDataIsReconsentGranted(string text)
//        { return By.XPath("//div[@class='sapUiRGLContainerCont']//child::div[21]//child::div//following-sibling::div//child::span[text()='" + text + "']"); }

//        public By UserRewardStatus(string status) { return By.XPath("//span[@title='Rewards Is Active'][text()='" + status + "']"); }
//        public By SSCSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
//        public By SpanSSCText(string text) { return By.XPath("//span[text()='" + text + "']"); }
//        public By TableTdText(string text) { return By.XPath("//td[text()='" + text + "']"); }
//        public By SpanSSCTextFirst(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }

//        [FindsBy(How = How.XPath, Using = "//*[text()='No results found. Search again in all items?']")]
//        private IWebElement UserDataNotFound;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Add']")]
//        private IWebElement SSCAddCustomerDetails;

//        //[FindsBy(How = How.XPath, Using = "//input[contains(@aria-describedby,'dropdownlistbox')][@aria-required='true']")] --> Changed by Ajay 06.02.2023
//        [FindsBy(How = How.XPath, Using = "(//input[contains(@id,'dropdownlistbox')][@aria-required='true'])[1]")]
//        private IWebElement SSCSelectAddressTypeInput;
//        public By SSCListItem(string Item) { return By.XPath("//li[text()='" + Item + "']"); }
//        public By SSCAddAddressFields(string FieldName) { return By.XPath("//bdi[text()='" + FieldName + "']/../following-sibling::div//input[@aria-required='true']"); }
//        public By SSCAddAddressOptFields(string FieldName, int count) { return By.XPath("(//bdi[text()='" + FieldName + "']/../following-sibling::div//input)[" + count + "]"); }

//        [FindsBy(How = How.XPath, Using = "//button[@data-sap-automation-id='button-ListModification-Add']")]
//        private IWebElement SSCNewAddressAddbtn;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
//        private IWebElement SSCEditCustomerSavebtn;
//        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }
//        public By SSCTicketSubtabClose(string text) { return By.XPath("//span[contains(text(),'" + text + "')]/../../../button[2]"); }

//        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
//        private IWebElement SSCDetailsEditIcon;

//        [FindsBy(How = How.XPath, Using = "//input[@checked='checked'][@type='CheckBox']/ancestor::td/..//input[@value='Address']")]
//        private IWebElement SSCCustomerContactAddressDetails;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Phone']/following::input[1][contains(@id,'inputField-inner')]")]
//        private IWebElement SSCPhone;
//        public By SSCCustomerAddressFieldInput(string AddressField) { return By.XPath("//bdi[text()='" + AddressField + "']/..//following::input[1]"); }

//        public By SSCUserFieldData(string FieldLabel) { return By.XPath("//bdi[text()='" + FieldLabel + "']/following::span[1]"); }
//        public By SpanSSCContainsText(string text) { return By.XPath("(//span[contains(text(),'" + text + "')])[1]"); }
//        [FindsBy(How = How.XPath, Using = "//span[text()='My Tickets']")]
//        private IWebElement SSCMyTicketsHeader;

//        [FindsBy(How = How.XPath, Using = "//textarea[@data-role='editor']")]
//        private IWebElement SSCNewTicketDescription;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save and Open']")]
//        private IWebElement SSCNewTicketSaveOpen;
//        [FindsBy(How = How.XPath, Using = "//button[@title='Create']")]
//        private IWebElement SSCTicketCreateBtn;

//        public By SSCNewTicketFields(string FieldLabel) { return By.XPath("(//bdi[text()='" + FieldLabel + "']/following::input)[1]"); }
//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reason']/following::input[1]")]

//        //[FindsBy(How = How.XPath, Using = "//bdi[text()='Status']/following::span[@class='sapUiIcon sapUiIconMirrorInRTL sapUiIconPointer sapMInputBaseIcon'][1]")]
//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Assigned to']//preceding::span[@class='sapUiIcon sapUiIconMirrorInRTL sapUiIconPointer sapMInputBaseIcon'][2]")]
//        private IWebElement SSC_StatusDropdownBtn;

//        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Open']")]
//        private IWebElement SSC_StatusDropdown_TicketOpen;

//        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Solved']")]
//        private IWebElement SSC_StatusDropdown_TicketSolved;

//        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Closed']")]
//        private IWebElement SSC_StatusDropdown_TicketClosed;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Reason']/following::input[1]")]
//        private IWebElement SSC_StatusAdjust_Reason;
//        [FindsBy(How = How.XPath, Using = "//div[text()='Tickets']")]
//        private IWebElement SSCCustomersSubtabTickets;
//        [FindsBy(How = How.XPath, Using = "//iframe[@class='k-content']")]
//        private IWebElement SSCNewTicketEmailFrame;

//        [FindsBy(How = How.XPath, Using = "//body[@class='sapClientMRTEBodyFullHeight']//span")]
//        private IWebElement SSCNewTicketContentBox;
//        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle_')][@role='presentation']")]
//        private IWebElement SSCNewTicketEditIcon;
//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Email']")]
//        private IWebElement SSCNewTicketEmailIcon;
//        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'CreateEmail-ToAddressInput-inner')]")]
//        private IWebElement SSCNewTicketEmailToAddress;
//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Send']")]
//        private IWebElement SSCTicketEmailSend;
//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
//        private IWebElement SSCNewTicketSave;
//        [FindsBy(How = How.XPath, Using = "//iframe[contains(@id,'-iframe')][contains(@src,'calendapp')]")]
//        private IWebElement SSCCalenderFrame;
//        [FindsBy(How = How.XPath, Using = "//div[contains(@aria-label,'Booking 10% day')]")]
//        private IWebElement SSCBookedDiscountDay;
//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Cancel ']")]
//        private IWebElement SSCDiscountDayCancellButton;
//        [FindsBy(How = How.XPath, Using = "//bdi[text()='New']")]
//        private IWebElement SSCCreateNewTicketButton;
//        [FindsBy(How = How.XPath, Using = "//span[text()='Create']//preceding-sibling::span")]
//        private IWebElement SSCCreateNewCustomerButton;
//        [FindsBy(How = How.XPath, Using = "//bdi[text()='First Name']/parent::span/following-sibling::div//input")]
//        private IWebElement SSCCreateNewCustomerFirstname;
//        public By SSCNewCustomerRegisterationFields(string FieldLabel) { return By.XPath("(//bdi[text()='" + FieldLabel + "']/parent::span/following-sibling::div//input"); }


//        public By PointsTEValue(string ColumnName)
//        {
//            if (ColumnName == "Value Changed From")
//                ColumnName = "1";
//            else
//                ColumnName = "2";
//            //return By.XPath("//span[@title='External ID Type']/../../following-sibling::td[" + ColumnName + "]/div/span");
//            return By.XPath("(//*[text()='Status Points'])[1]/following::td[" + ColumnName + "]");
//        }


//        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'--header-arrowScrollRight')]")]
//        private IWebElement SSCCustomerTabScrollRight;

//        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
//        private IWebElement SSCCustomerCDCID;

//        [FindsBy(How = How.XPath, Using = "(//span[contains(@id,'dropdownlistboxa9a498bccf7fdaeaf586528c044f484a')])[1]")]
//        private IWebElement SSCCustomerTierDetails;

//        //[FindsBy(How = How.XPath, Using = "//div[@id='__title0']/span[text()='Group Accounts']")]
//        [FindsBy(How = How.XPath, Using = "//div[@id='__title0']/span[contains(text(),'Group Accounts')]")]
//        private IWebElement SSCGroupAccountHeader;

//        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-variantManagement-trigger-img')]")]
//        private IWebElement SSCGroupAccountItemViewFilter;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Actions']")]
//        private IWebElement SSCDetailsGridActions;

//        [FindsBy(How = How.XPath, Using = "(//bdi[text()='10% Remaining Days']/following::div/span)[1]")]
//        private IWebElement SSC_TenpercentRemain_Days;

//        public By SSCBdiGridValue(string Text) { return By.XPath("//bdi[text()='" + Text + "']"); }

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Add'][contains(@id,'buttontdiGV')]")]
//        private IWebElement SSCTicketsAttachmentAddBtn;

//        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'button-content')]/bdi[text()='Actions']")]
//        private IWebElement SSCTicketsActions;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Generate Summary']")]
//        private IWebElement SSCTicketsActionsGenerateSummary;

//        [FindsBy(How = How.XPath, Using = "//bdi[text()='Withdraw from Approval']")]
//        private IWebElement SSCTicketsActionsWithdrawApproval;

//        public By SSCLinkContains(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }

//        [FindsBy(How = How.XPath, Using = "//button[@title='Expand']")]
//        private IWebElement SSCCustomerDetailsExpandBtn;

//        [FindsBy(How = How.XPath, Using = "//span[@title='Set As Obsolete'][contains(@id,'checkbox')]")]
//        private IWebElement SSCCustomerObsoleteStatus;

//        public By SSCSetAsOboleteToggleBtn(string text) { return By.XPath("(//bdi[text()='Set As Obsolete']/following::span[text()='" + text + "'])[1]"); }

//        #endregion

//        #region Events


//        #endregion
//        public string SearchLiteCustomerOnSSC(string FullName, string Email)
//        {

//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(3000);
//            try
//            {
//                if (UserDataNotFound.Displayed)
//                {
//                    UserDataNotFound.Click();
//                    BrowserDriver.Sleep(3000);
//                }
//            }
//            catch { }
//            BrowserDriver.Sleep(3000);
//            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
//            driver.FindElement(SSCCustomersGridData(FullName)).Click();
//            BrowserDriver.PageWait();
//            //BrowserDriver.Sleep(3000);
//            return CdcId;
//        }

//        public void ValidateLiteCustomermailid(string FullName, string Email)
//        {
//            BrowserDriver.Sleep(2000);
//            Assert.AreEqual(Email, SSCLiteCustomerEmailId.Text, "Email validation failed in SSC");
//        }

//        public void ValidateLiteCustomerReconsent()
//        {
//            driver.FindElement(SSCNewTicketSubTabs("Customer Data")).Click();
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(SSCCustDataIsReconsentGranted("Yes")).Displayed, "Newsletter validation is failed For reg user in SSC");
//        }

//        public void ValidateUserShowingAsRewardsOnSSC(string FullName, string Email)
//        {
//            SearchLiteCustomerOnSSC(FullName, Email);
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            Assert.IsTrue(driver.FindElement(UserRewardStatus("Yes")).Displayed, "User rewards status is not showing as expected on SSC");

//        }
//        public void ValidateGhostAccountInSSC(string FullName, string Email)
//        {
//            //SearchLiteCustomerOnSSC(FullName, Email);

//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, FullName + "\n");
//            BrowserDriver.Sleep(3000);
//            driver.FindElement(SSCCustomersGridData("- -")).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(3000);

//            driver.FindElement(SSCNewTicketSubTabs("Tickets")).Click();
//            BrowserDriver.Sleep(2000);

//            //Validate ticket created 
//            Assert.IsTrue(driver.FindElement(By.XPath("//a[starts-with(@title,'Online Registration:Conflict')]")).Displayed, " Ticket is not created in Ghost Account");
//            driver.FindElement(By.XPath("//a[starts-with(@title,'Online Registration:Conflict')]")).Click();
//            BrowserDriver.Sleep(2000);

//        }
//        public string AddDefaultUserAddressFromSSC(string Country, string UserName, string Email)
//        {
//            //string FullName = UserName + " " + UserName + "Lname";
//            string FullName = UserName;
//            string City = null, State = null, Postcode = null, Phone = null;

//            if (Country == "UK")
//            {
//                City = "Bristol"; State = "LC - London";
//                Postcode = "EC4Y"; Country = "GB - United Kingdom";
//                Phone = "+44 77" + CommonFunctions.GetRandomNumber(8);
//            }
//            else if (Country == "US")
//            {
//                City = "Brooklyn"; State = "NY - New York";
//                Postcode = "20833"; Country = "US - United States";
//                Phone = "+1 646" + CommonFunctions.GetRandomNumber(7);
//            }
//            else if (Country == "Canada")
//            {
//                City = "Edmonton"; State = "AB - Alberta";
//                Postcode = "K1A 0T6"; Country = "CA - Canada";
//                Phone = "+1 780" + CommonFunctions.GetRandomNumber(7);
//            }

//            //Assigning new address to the user
//            SearchCustomerOnSSC(FullName, Email);
//            WebHandlers.Instance.WaitForPageLoad();
//            BrowserDriver.Sleep(3000);
//            SSCDetailsEditIcon.Click();
//            BrowserDriver.Sleep(3000);
//            //SearchLiteCustomerOnSSC(FullName, Email);
//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Contact Details")));
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(SSCAddCustomerDetails);
//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.Click(SSCSelectAddressTypeInput);
//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.Click(driver.FindElement(SSCListItem("Address")));
//            WebHandlers.Instance.EnterText(SSCSelectAddressTypeInput, "Address");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Recipient Name")), UserName);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Recipient Last Name")), UserName + "Lname");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Address Line 1")), UserName + "Address1");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressOptFields("Address Line 2", 1)), UserName + "Address2");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressOptFields("Address Line 3", 1)), UserName + "Address3");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("City")), City);
//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")));
//            BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")), Country);
//            driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")).SendKeys(Country);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressOptFields("State", 1)), State);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Postal Code")), Postcode);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Country/Region")), Country);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressOptFields("Country/Region", 2)), Country);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCAddAddressFields("Phone")).Clear();
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Phone")), Phone);
//            WebHandlers.Instance.Click(SSCNewAddressAddbtn);
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(SSCEditCustomerSavebtn);
//            BrowserDriver.Sleep(3000);
//            driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
//            BrowserDriver.Sleep(2000);
//            return Phone;
//        }

//        public void EditDefaultUserAddressFromSSC(string Country, string UserName, string Email, string Phonenumber)
//        {
//            //string FullName = UserName + " " + UserName + "Lname";
//            string FullName = UserName;
//            string City = null, State = null, Postcode = null;

//            if (Country == "UK")
//            {
//                City = "Hampstead"; State = "LC - London";
//                Postcode = "NW3"; Country = "GB - United Kingdom";
//            }
//            else if (Country == "US")
//            {
//                City = "Rochester"; State = "NY - New York";
//                Postcode = "14602"; Country = "US - United States";
//            }
//            else if (Country == "Canada")
//            {
//                City = "Lacombe"; State = "AB - Alberta";
//                Postcode = "Y1A 9Z9"; Country = "CA - Canada";
//            }

//            //Editing address of user
//            SearchLiteCustomerOnSSC(FullName, Email);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Contact Details")));
//            BrowserDriver.Sleep(3000);
//            SSCDetailsEditIcon.Click();
//            BrowserDriver.Sleep(3000);
//            //Click Profile Data Edit Checkbox
//            SSCProfileDataEditCheckBox.Click();
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(SSCCustomerContactAddressDetails);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 1")), UserName + "Address1Edit");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 2")), UserName + "Address2Edit");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 3")), UserName + "Address3Edit");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("City")), City);

//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")));
//            BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")), Country);
//            driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")).SendKeys(Country);
//            BrowserDriver.Sleep(2000);

//            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("State")), State);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Postal Code")), Postcode);
//            SSCPhone.Clear();
//            SSCPhone.SendKeys(Phonenumber);
//            //WebHandlers.Instance.EnterText(SSCPhone, Phonenumber);
//            WebHandlers.Instance.Click(SSCEditCustomerSavebtn);
//            BrowserDriver.Sleep(3000);

//            driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
//            BrowserDriver.Sleep(2000);
//        }

//        public void ValidateRemovedChildNotListingOnSSC(Dictionary<string, string> ChildData)
//        {
//            //Selecting user from SSC
//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Relationships")));
//            BrowserDriver.Sleep(4000);
//            Assert.AreEqual(0, driver.FindElements(SpanSSCText(ChildData["ChildFirstName"])).Count, "Child first name not removed from SSC");
//            Assert.AreEqual(0, driver.FindElements(SpanSSCText(ChildData["ChildLastName"])).Count, "Child last name not removed from SSC");
//            Assert.AreEqual(0, driver.FindElements(SpanSSCText(ChildData["DOB"])).Count, "Child date of birth not removed from SSC");
//        }

//        public void VerifyPrespaUserDetailsOnSSC(string FullName, string Email, string Phone)
//        {
//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(4000);
//            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
//            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
//            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Phone)).Displayed, Phone + " - Expected phone number not showing on the grid");
//            BrowserDriver.Sleep(1000);
//        }


//        public void VerifyBBUserDetailsAndVerifiedStatusOnSSC(string UserName, string Email, string Phone)
//        {
//            string FullName = UserName + " " + UserName + "Lname";

//            //Validating verified status for the user
//            SearchLiteCustomerOnSSC(FullName, Email);
//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Customer Data")));
//            BrowserDriver.Sleep(3000);
//            Assert.AreEqual("Yes", driver.FindElement(SSCUserFieldData("Is Verified")).GetAttribute("innerText"), "User verified status is not showing as expected");
//            Assert.IsTrue(driver.FindElement(SpanSSCContainsText(Phone)).Displayed, Phone + " - Expected phone number not showing on the grid");
//            Assert.IsTrue(driver.FindElement(SpanSSCContainsText(FullName)).Displayed, FullName + " - Expected user not showing on the grid");
//            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
//        }
//        public void ValidatetenPercentcancellationUpdatedInSSC(string UserName, string Email, string bookedDate)
//        {
//            By element = By.XPath("//span[text()='Cancelled by Customer'][1]");
//            Actions actions = new Actions(driver);
//            actions.MoveToElement(driver.FindElement(element));
//            actions.Perform();
//            BrowserDriver.Sleep(5000);

//            //Assert.AreEqual("Cancelled by Customer", driver.FindElement(By.XPath("//span[text()='" + bookedDate + "']//following::td")).Text);
//            Assert.IsTrue(driver.FindElements(element).Count > 0, "Cancellation record is not seen");

//        }

//        public void ValidateCountofTenPctDiscountDaysinSSC()
//        {
//            string remaining_days = WebHandlers.Instance.GetTextOfElement(SSC_TenpercentRemain_Days);
//            Assert.IsTrue(remaining_days.Equals(""), "The remaining days --> '" + remaining_days + "' -- are not 0");
//        }

//        public void ValidatePercentDiscountinSSC(string day1)
//        {
//            string Day1_Status = driver.FindElement(By.XPath("//span[text()='" + day1 + "']//..//..//following-sibling::td[1]")).Text;
//            Assert.IsTrue(Day1_Status.Equals("Booked"), "Reselected Day1 is not updated or displayed in SSC");
//        }

//        public void SearchCustomerOnSSC(string UserName, string Email)
//        {

//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(3000);


//            driver.FindElement(SSCCustomersGridData(UserName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(3000);
//        }

//        public void createNewTicketfor10PCancellation(string UserName, string Email)
//        {
//            //Creating manual tier upgrade ticket
//            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Tickets")));
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='New']")));
//            BrowserDriver.Sleep(4000);
//            // WebHandlers.Instance.Click(SSCTicketCreateBtn);
//            //SSCTicketCreateBtn.Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
//            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online");


//            driver.FindElement(SSCNewTicketFields("Type")).Clear();
//            driver.FindElement(SSCNewTicketFields("Type")).SendKeys("General");
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), "Online Fulfillment");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), UserName);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for 10p cancellation");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "Rewards");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "10% Nominated Day");
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Team")).Clear();
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
//            BrowserDriver.Sleep(2000);

//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
//            Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    10PCancel").DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(4000);
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(6000);
//            BrowserDriver.PageWait();
//            //Changing ticket status and target tier details
//            //WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);

//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(3000);


//            //try { WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");

//            //}
//            //catch
//            //{
//            //    WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
//            //    WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");                
//            //}
//            try
//            {
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            }
//            catch
//            {
//                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                BrowserDriver.Sleep(2000);
//                //SSC_StatusDropdownBtn.Click();
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            }


//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "10 p cancel");
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Reason"), "Loyalty");
//            //SSC_StatusAdjust_Reason.Click();
//            BrowserDriver.Sleep(2000);
//            //SSC_StatusAdjust_Reason.Clear();
//            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
//            driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Loyalty Testing");

//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
//            WebHandlers.Instance.Click(SSCTicketEmailSend);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Cancel the booked slot 
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketSubTabs("Manage 10% Day Booking")), "Clicked on Manage Booking");
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.SwitchToFrame(SSCCalenderFrame);
//            Actions action = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            action.MoveToElement(SSCBookedDiscountDay).Click().Build().Perform();
//            //Console.WriteLine("Aria label --" + SSCBookedDiscountDay.GetAttribute("aria-label"));
//            //string dmy = convertStringToDate(SSCBookedDiscountDay.GetAttribute("aria-label"));
//            //Console.WriteLine("Discount day --" + dmy);
//            BrowserDriver.Sleep(2000);
//            SSCDiscountDayCancellButton.Click();
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.SwithBackFromFrame();

//            //Changing ticket status to solved
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//            //SSC_StatusDropdownBtn.Click();
//            BrowserDriver.Sleep(1000);
//            SSC_StatusDropdown_TicketSolved.Click();
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(4000);


//        }

//        public string FetchDay2slotdate()
//        {
//            string day2slot = "";
//            return day2slot;
//        }

//        public string convertStringToDate(string discountday)
//        {
//            //dateFormat: June 27, 2022; Booking 10 % day
//            Console.Write("________________" + discountday);
//            string[] DateMonthYear = discountday.Split(';');
//            String[] DateMonth = DateMonthYear[0].Split(',');
//            string year = DateMonth[1].Replace(" ", "");
//            string[] m = DateMonth[0].Split(null);
//            int month = DateTime.ParseExact(m[0], "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
//            string date = m[1];
//            string dmy = date + "." + month.ToString("00") + "." + year;
//            return dmy;
//        }
//        public void ValidateEmployeeCreatedSSC(string FullName, string Email)
//        {
//            BrowserDriver.Sleep(4000);
//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(3000);
//            // string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
//            driver.FindElement(SSCCustomersGridData(FullName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(3000);

//            //Validating employee

//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Overview")));
//            BrowserDriver.Sleep(3000);
//            Assert.IsTrue(driver.FindElement(By.XPath("//bdi[text()='Is Employee']//..//following::div//span[text()='Yes']")).Displayed, "Not an employee");

//        }
//        public string CreateTicketForBonusPointAddition(string UserName, string Email)
//        {
//            WebHandlers.Instance.WaitForPageLoad();
//            BrowserDriver.Sleep(4000);
//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(3000);
//            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

//            driver.FindElement(SSCCustomersGridData(UserName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(3000);
//            //Creating manual tier upgrade ticket
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Tickets")));
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='New']")));
//            BrowserDriver.Sleep(4000);
//            // WebHandlers.Instance.Click(SSCTicketCreateBtn);
//            //SSCTicketCreateBtn.Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
//            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
//            BrowserDriver.Sleep(1000);

//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "Ticket for Add bonus point");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "Rewards");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "Bonus points");
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
//            BrowserDriver.Sleep(2000);

//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
//            Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    BonusPointAdd").DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(4000);
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status and target tier details
//            //WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
//            WebHandlers.Instance.WaitForPageLoad();
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            try
//            {
//                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");
//                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            }
//            catch
//            {
//                WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
//                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");
//                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            }
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "BonusAdd");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Bonus Points To Be Adjusted")), "5000");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Reason"), "Points");
//            BrowserDriver.Sleep(2000);

//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
//            WebHandlers.Instance.Click(SSCTicketEmailSend);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status to solved
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(4000);
//            return CdcId;
//        }
//        public string CreateTicketForPartnerPointAddition(string UserName, string Email)
//        {
//            WebHandlers.Instance.WaitForPageLoad();
//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(3000);
//            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

//            driver.FindElement(SSCCustomersGridData(UserName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(3000);
//            //Creating manual tier upgrade ticket
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Tickets")));
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='New']")));
//            BrowserDriver.Sleep(4000);
//            // WebHandlers.Instance.Click(SSCTicketCreateBtn);
//            //SSCTicketCreateBtn.Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
//            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), "General");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), "Online Fulfillment");
//            BrowserDriver.Sleep(1000);

//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), "City Bank point");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), "Enquiry");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), "Rewards");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), "Citibank Partner Points");
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
//            BrowserDriver.Sleep(2000);

//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
//            Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    Award city bank points").DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(4000);
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status and target tier details
//            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            try { WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open"); }
//            catch
//            {
//                WebHandlers.Instance.Click(SSCNewTicketEditIcon); BrowserDriver.Sleep(2000);
//                WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open");
//            }
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "City banks points add");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Rewards Points To Be Adjusted")), "5000");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Reason"), "CitiBank");
//            BrowserDriver.Sleep(2000);

//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
//            WebHandlers.Instance.Click(SSCTicketEmailSend);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status to solved
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(4000);
//            return CdcId;

//        }
//        public string VerifyFullReturnDetailsShowingOnSSC(string FullName, string Email)
//        {
//            string CdcId = SearchLiteCustomerOnSSC(FullName, Email);
//            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
//            BrowserDriver.Sleep(1000);
//            driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
//            WebHandlers.Instance.WebElementExists(driver.FindElement(PointsTEValue("Value Changed From")));
//            BrowserDriver.Sleep(4000);
//            string prevValue = driver.FindElement(PointsTEValue("Value Changed From")).GetAttribute("innerText");
//            string currValue = driver.FindElement(PointsTEValue("Value Changed To")).GetAttribute("innerText");
//            Assert.Greater(Convert.ToInt64(Math.Floor(Convert.ToDouble(prevValue))), Convert.ToInt64(Math.Floor(Convert.ToDouble(currValue))), "Point reduction against full return not showing on SSC");
//            return CdcId;
//        }

//        public string FetchCDCIdFromSSC(string UserName, string Email, bool PerformEditUser)
//        {
//            BrowserDriver.Sleep(3000);
//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//            //SSCCustomersSearchEdit.SendKeys(Email + "\n");
//            BrowserDriver.Sleep(3000);
//            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
//            if (PerformEditUser)
//            {
//                driver.FindElement(SSCCustomersGridData(UserName)).Click();
//                BrowserDriver.PageWait();
//                BrowserDriver.Sleep(3000);
//            }
//            return CdcId;
//        }

//        public string FetchCurrentPointsFromSSC(string PointCategory, string UserName)
//        {
//            string CurrPoint = null;
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            switch (PointCategory)
//            {
//                case "Rewards Points":
//                    CurrPoint = driver.FindElement(SSCUserFieldData(PointCategory)).GetAttribute("innerText");
//                    break;

//                case "Status Points":
//                    CurrPoint = driver.FindElement(SSCUserFieldData(PointCategory)).GetAttribute("innerText");
//                    break;

//                case "Extend Points":
//                    CurrPoint = driver.FindElement(SSCUserFieldData("Rewards Points")).GetAttribute("innerText");
//                    break;
//            }
//            driver.FindElement(SSCCustomersSubtabClose(UserName)).Click();
//            BrowserDriver.Sleep(3000);
//            if (CurrPoint.Contains(",")) { CurrPoint = CurrPoint.Replace(",", ""); }
//            return CurrPoint;
//        }

//        public void CreateSSCTicketAsPerGivenData_Duplicate(Dictionary<string, string> SSCTicketData)
//        {
//            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Tickets")));
//            WebHandlers.Instance.WebElementExists(SSCCreateNewTicketButton);
//            WebHandlers.Instance.Click(SSCCreateNewTicketButton);
//            WebHandlers.Instance.WebElementExists(SSCNewTicketDescription);
//            BrowserDriver.Sleep(4000);
//            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), SSCTicketData["Type"]);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Source"), SSCTicketData["Source"]);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");

//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
//            Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + SSCTicketData["Subject"]).DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(3000);
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(6000);
//        }
//        public void PerformSSCEditTicket()
//        {
//            BrowserDriver.Sleep(4000);
//            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//        }

//        public void ChangeStatusOfSSCTicket(string Status, bool SaveAction = false)
//        {
//            //Changing ticket status and target tier details
//            BrowserDriver.Sleep(4000);
//            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            try {
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), Status);

//                //Status selection
//                if (Status == "Open")
//                {
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketOpen.Click();
//                    BrowserDriver.Sleep(1000);
//                }
//                else if (Status == "Closed")
//                {
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketClosed.Click();
//                    BrowserDriver.Sleep(1000);
//                }
//                //Status selection
//            }
//            catch
//            {
//                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                BrowserDriver.Sleep(2000);
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), Status);
//                //Status selection
//                if (Status == "Open")
//                {
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketOpen.Click();
//                    BrowserDriver.Sleep(1000);
//                }
//                else if (Status == "Closed")
//                {
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketClosed.Click();
//                    BrowserDriver.Sleep(1000);
//                }
//                //Status selection
//            }
//            if (Status == "Open")
//                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            else if (Status == "Solved")
//            {
//                driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//                BrowserDriver.Sleep(2000);
//                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), Status);
//            }

//            BrowserDriver.Sleep(2000);
//            if (SaveAction)
//            {
//                WebHandlers.Instance.Click(SSCNewTicketSave);
//                //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                BrowserDriver.Sleep(4000);
//            }
//        }

//        public void ProcessSSCTicketAsPerGivenData(string Subject, string PointCategory, string Points)
//        {
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            //BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), Subject);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields(PointCategory)), Points);
//            BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Loyalty");
//            //SSC_StatusAdjust_Reason.Click();
//            BrowserDriver.Sleep(2000);
//            //SSC_StatusAdjust_Reason.Clear();
//            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
//            driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Loyalty Testing");
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);

//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            //WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, Email);
//            WebHandlers.Instance.Click(SSCTicketEmailSend);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);
//        }

//        public void ValidateExpectedPointsAddedOnSSC(string UserName, string Email, string PointCategory, string ExpectedPoints)
//        {
//            string CurrPoint = null; int count = 0;
//            HomePage homePage = new HomePage(driver);
//            if (PointCategory == "Miscellaneous" || PointCategory == "Extend Points")
//                PointCategory = "Rewards Points";
//            do
//            {
//                //homePage.NavigateToSSCCustomers();
//                //BrowserDriver.Sleep(5000);
//                //SSCCustomersSearchEdit.Clear();
//                //WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//                //BrowserDriver.Sleep(3000);
//                //FetchCDCIdFromSSC(UserName, Email, true);
//                //driver.FindElement(SSCCustomersGridData(UserName)).Click();
//                //BrowserDriver.PageWait();

//                try { SSCCustomersSearchIcon.Click(); }
//                catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//                BrowserDriver.Sleep();
//                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//                BrowserDriver.Sleep(3000);
//                string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
//                driver.FindElement(SSCCustomersGridData(UserName)).Click();
//                BrowserDriver.PageWait();
//                BrowserDriver.Sleep(3000);

//                driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//                BrowserDriver.Sleep(2000);
//                CurrPoint = driver.FindElement(SSCUserFieldData(PointCategory)).GetAttribute("innerText");
//                CurrPoint = CurrPoint.Replace(",", "");
//                driver.FindElement(SSCCustomersSubtabClose(UserName)).Click();
//                BrowserDriver.Sleep(3000);

//                if (CurrPoint == ExpectedPoints)
//                    break;
//                count++;
//            } while (count < 5);

//            Assert.AreEqual(ExpectedPoints, CurrPoint, PointCategory + " Points not showing as expected on SSC");
//        }

//        public string ValidateUserRewardPointsUpdatedInSSC(string FullName, string Email)
//        {
//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
//            BrowserDriver.Sleep(3000);
//            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
//            driver.FindElement(SSCCustomersGridData(FullName)).Click();
//            BrowserDriver.PageWait();
//            BrowserDriver.Sleep(3000);
//            return CdcId;
//        }

//        public void CreateSSCTicketAsPerGivenData(Dictionary<string, string> SSCTicketData)
//        {
//            Actions ContentAction = new Actions(driver);
//            //Navigating to Tickets
//            HomePage homePage = new HomePage(driver);
//            homePage.NavigateToSSC_Service();
//            BrowserDriver.Sleep(3000);
//            homePage.NavigateToSSC_Service_To_Ticket();
//            BrowserDriver.Sleep(3000);
//            //Creating manual tier upgrade ticket
//            try { WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader); }
//            catch { homePage.NavigateToSSC_Service_To_Ticket(); }
//            BrowserDriver.Sleep(5000);

//            //SSCTicketCreateBtn.Click();
//            WebHandlers.Instance.Click(SSCTicketCreateBtn);
//            BrowserDriver.Sleep(6000);
//            //Type selected by default in the application
//            //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
//            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(3000);            
//            //driver.FindElement(SSCNewTicketFields("Type")).Clear();
//            //driver.FindElement(SSCNewTicketFields("Type")).SendKeys(SSCTicketData["Type"]);
//            BrowserDriver.Sleep(3000);
                        
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Team")).Clear();
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys(SSCTicketData["Team"]);            
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(4000);
//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);

//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + SSCTicketData["Subject"]).DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
            
//            driver.FindElement(SSCNewTicketFields("Source")).Clear();
//            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Subject")).Clear();
//            driver.FindElement(SSCNewTicketFields("Subject")).SendKeys(SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(10000);

//            //Changing ticket status and target tier details
//            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            try
//            {                
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);                
//            }
//            catch
//            {
//                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                BrowserDriver.Sleep(2000);                
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();                
//                BrowserDriver.Sleep(3000);
//            }
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), SSCTicketData["Subject"]);
//            //driver.FindElement(SSCNewTicketFields("Summary")).SendKeys(SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields(SSCTicketData["FieldName"])), SSCTicketData["Points"]);
//            BrowserDriver.Sleep(2000);

//            BrowserDriver.Sleep(3000);
//            //Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            //ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().Build().Perform();
//            //ContentAction.MoveToElement(SSC_StatusAdjust_Reason).Click().SendKeys("    Loyalty Testing" + "\n").DoubleClick().Build().Perform();
//            //SSC_StatusAdjust_Reason.Click();
//            BrowserDriver.Sleep(2000);
//            //SSC_StatusAdjust_Reason.Clear();
//            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing" + "\n");
//            //SSC_StatusAdjust_Reason.SendKeys("Loyalty Testing");
//            driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Loyalty Testing");
//            BrowserDriver.Sleep(3000);



//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            BrowserDriver.Sleep(2000);
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            BrowserDriver.Sleep(3000);            
//            WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, SSCTicketData["Email"]);            
//            SSCTicketEmailSend.Click();
//            BrowserDriver.Sleep(3000);            
//            SSCNewTicketSave.Click();            
//            BrowserDriver.Sleep(3000);

//            //Changing ticket status to solved
//            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
                      
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
            

//            //Approval verification and withdrawal == > Below part of code is currently on hold due to admin rights for ssc user
//            WebHandlers.Instance.Click(SSCTicketsActions);
//            BrowserDriver.Sleep(1000);
//            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//            BrowserDriver.Sleep(4000);

//            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
//            {
//                try
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);

//                }
//                catch (Exception e)
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);
//                }

//            }
//        }

//        private string GetNumbers(String InputString)
//        {
//            String Result = "";
//            string Numbers = "0123456789";
//            int i = 0;

//            for (i = 0; i < InputString.Length; i++)
//            {
//                if (Numbers.Contains(InputString.ElementAt(i)))
//                {
//                    Result += InputString.ElementAt(i);
//                }
//            }
//            return Result;
//        }

//        public void ValidateActivityShowingOnSSC(string PointCategory)
//        {
            
//            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
//            BrowserDriver.Sleep(5000);
//            driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
//            BrowserDriver.Sleep(5000);
//            string subjectString = driver.FindElement(By.XPath("//*[contains(@id,'paginator-pageInfo-bdi')]")).Text;
//            string pagination = GetNumbers(subjectString);
//            int p = Int32.Parse(pagination);
//            //driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
//            //WebHandlers.Instance.WebElementExists(driver.FindElement(PointsTEValue("Value Changed From")));
//            for (int i = 0; i < p-1; i++)
//            {
//                try
//                {
//                    IWebElement pointexpiry = driver.FindElement(PointsTEValue("Value Changed From"));
//                    string point = pointexpiry.Text;
//                    if (!point.Equals(null))
//                    {
//                        break;
//                    }

//                }
//                catch { driver.FindElement(By.XPath("//*[@role='button'][contains(@id,'paginator-nextPage')]")).Click(); }
//            }

//            BrowserDriver.Sleep(4000);
//            //Assert.IsTrue(driver.FindElement(SpanSSCTextFirst("Rewards Points")).Displayed, PointCategory + " - activity against user is not showing on SSC");
//            Assert.IsTrue(driver.FindElement(SpanSSCTextFirst("Status Points")).Displayed, PointCategory + " - activity against user is not showing on SSC");

//            if (PointCategory == "RedeemPoints")
//            {
//                string prevValue = driver.FindElement(PointsTEValue("Value Changed From")).GetAttribute("innerText");
//                string currValue = driver.FindElement(PointsTEValue("Value Changed To")).GetAttribute("innerText");
//                Assert.Greater(Convert.ToInt64(Math.Floor(Convert.ToDouble(prevValue))), Convert.ToInt64(Math.Floor(Convert.ToDouble(currValue))), "Redeem points reduction not showing on SSC");

//                driver.FindElement(SSCNewTicketSubTabs("Purchases")).Click();
//                BrowserDriver.Sleep(3000);
//                Assert.IsTrue(driver.FindElement(SpanSSCTextFirst("POS")).Displayed, PointCategory + "POS purchase activity against user is not showing on SSC");
//            }
//        }

//        public string ValidateUserTierGetsUpgradedTo(string UserName, string Email, string ExpectedTier, string ExpectedPoints)
//        {
//            string CurrPoint = null, CurrTier = null; int count = 0;
//            HomePage homePage = new HomePage(driver);

//            do
//            {
//                homePage.NavigateToSSCCustomers();
//                BrowserDriver.Sleep(15000);
//                FetchCDCIdFromSSC(UserName, Email, true);
//                driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//                BrowserDriver.Sleep(10000);
//                CurrPoint = driver.FindElement(SSCUserFieldData("Status Points")).GetAttribute("innerText");
//                driver.FindElement(SSCCustomersSubtabClose(UserName)).Click();
//                BrowserDriver.Sleep(5000);

//                if (CurrPoint == ExpectedPoints)
//                    break;
//                count++;
//            } while (count < 15);

//            Assert.AreEqual(ExpectedPoints, CurrPoint, "Upgraded points not showing as expected on SSC");
//            Assert.AreEqual(ExpectedTier, WebHandlers.Instance.GetAttribute(SSCCustomerTierDetails, "innerHTML"), "SSC - Customer tier details is not showing as expected");
//            return WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
//        }

//        public void CreateGroupAccountFromSSC(string GroupAccount, string PrimaryMember)
//        {
//            //Creating new group account
//            WebWaitHelper.Instance.WaitForElementPresence(SSCGroupAccountHeader);
//            BrowserDriver.Sleep(3000);
//            WebWaitHelper.Instance.WaitForElementPresence(SSCTicketCreateBtn);
//            WebHandlers.Instance.Click(SSCTicketCreateBtn);
//            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Name"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Name")), GroupAccount);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Primary Member")), PrimaryMember);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Name")));
//            WebHandlers.Instance.Click(SSCEditCustomerSavebtn);
//            WebHandlers.Instance.Elementnotpresent(SSCEditCustomerSavebtn);
//            BrowserDriver.Sleep(5000);
//        }

//        public void ActivateOrDeactivateGroupAccount(string Action, string GroupAccount)
//        {
//            //Filtering to All accounts
//            WebHandlers.Instance.Click(SSCGroupAccountItemViewFilter);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCListItem("All")));
//            BrowserDriver.Sleep(6000);

//            //Editing given account
//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, GroupAccount + "\n");
//            BrowserDriver.Sleep(4000);
//            driver.FindElement(SSCCustomersGridData(GroupAccount)).Click();
//            WebHandlers.Instance.WebElementExists(SSCDetailsGridActions);
//            BrowserDriver.Sleep(4000);
//            WebHandlers.Instance.Click(SSCDetailsGridActions);
//            BrowserDriver.Sleep(2000);
//            if (Action == "Activate")
//                WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Set as Active")));
//            else if (Action == "DeActivate")
//                WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Set as Obsolete")));

//            BrowserDriver.Sleep(6000);
//            driver.FindElement(SSCCustomersSubtabClose(GroupAccount)).Click();
//            BrowserDriver.Sleep(5000);
//        }

//        public void VerifyGroupAccountDeactivated(string GroupAccount)
//        {
//            try { SSCCustomersSearchIcon.Click(); }
//            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            BrowserDriver.Sleep();
//            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, GroupAccount + "\n");
//            BrowserDriver.Sleep(4000);
//            Assert.AreEqual(0, driver.FindElements(SSCCustomersGridData(GroupAccount)).Count, GroupAccount + " not showing as deactivated on SSC");
//        }


//        public string CreateSSCTicketForPrimaryToSecondaryTransfer(Dictionary<string, string> SSCTicketData)
//        {
//            //Navigating to Tickets
//            HomePage homePage = new HomePage(driver);
//            BrowserDriver.Sleep(2000);
//            homePage.NavigateToSSC_Service();
//            //homePage.NavigateToSSC_Service_To_Ticket();

//            BrowserDriver.Sleep(2000);
//            //Creating manual tier upgrade ticket
//            WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(SSCTicketCreateBtn);
//            //SSCTicketCreateBtn.Click();
//            //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
//            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(3000);
//            driver.FindElement(SSCNewTicketFields("Type")).Clear();
//            driver.FindElement(SSCNewTicketFields("Type")).SendKeys(SSCTicketData["Type"]);
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Type"), SSCTicketData["Type"]);
//            WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), SSCTicketData["Source"]);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
//            BrowserDriver.Sleep(2000);
//            //driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
//            driver.FindElement(SSCNewTicketFields("Team")).Clear();
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");

//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
//            Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    TransferPoints").DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(4000);
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Source"), SSCTicketData["Source"]);
//            driver.FindElement(SSCNewTicketFields("Source")).Clear();
//            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Subject")).Clear();
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status and target tier details
//            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
//            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            //try { WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Open"); }
//            try
//            {

//                SSCNewTicketEditIcon.Click();
//                BrowserDriver.Sleep(4000);
//                //WebHandlers.Instance.DropDownSetByVal(driver.FindElement(SSCNewTicketFields("Status")), "Open");                
//                //ContentAction.MoveToElement(driver.FindElement(SSCNewTicketFields("Status"))).Click().SendKeys("Open").DoubleClick().Build().Perform();
//                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);

//                //Status selection
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                //Status selection

//            }
//            catch
//            {
//                //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                //SSCNewTicketEditIcon.Click();
//                BrowserDriver.Sleep(2000);
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
//                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Open");

//                //Status selection
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                //Status selection
//            }
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "TransferPoints");
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Transfer Points From")), SSCTicketData["TransferFrom"]);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Transfer Points To")), SSCTicketData["TransferTo"]);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Rewards Points To Be Adjusted")), SSCTicketData["PointsToTransfer"]);
//            WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Points Migration");
//            string RewardsPoints = driver.FindElement(SSCNewTicketFields("Rewards Points")).GetAttribute("value");

//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            //WebHandlers.Instance.EnterText(SSCNewTicketEmailToAddress, SSCTicketData["Email"]);
//            WebHandlers.Instance.Click(SSCTicketEmailSend);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status to solved
//            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            //BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            //BrowserDriver.Sleep(2000);
//            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Sub-Reason"), "Other");
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue(SSCNewTicketFields("Status"), "Solved");
//            //BrowserDriver.Sleep(1000);
//            //WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            //BrowserDriver.Sleep(6000);

//            //Approval verification and withdrawal
//            WebHandlers.Instance.Click(SSCTicketsActions);
//            BrowserDriver.Sleep(1000);
//            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//            BrowserDriver.Sleep(4000);

//            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
//            {
//                try
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);

//                }
//                catch (Exception e)
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);
//                }
//            }
//            return RewardsPoints;
//        }

//        public void ValidatePointsGetTransferedFromPrimary(string PrimaryName, string PrimaryEmail, string PreviousPoints)
//        {
//            string CurrPoint = null; int count = 0;
//            HomePage homePage = new HomePage(driver);

//            do
//            {
//                homePage.NavigateToSSCCustomers();
//                BrowserDriver.Sleep(15000);
//                FetchCDCIdFromSSC(PrimaryName, PrimaryEmail, true);
//                driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//                BrowserDriver.Sleep(2000);
//                CurrPoint = driver.FindElement(SSCUserFieldData("Rewards Points")).GetAttribute("innerText");
//                driver.FindElement(SSCCustomersSubtabClose(PrimaryName)).Click();
//                BrowserDriver.Sleep(3000);

//                if (CurrPoint != PreviousPoints)
//                    break;
//                count++;
//            } while (count < 8);

//            Assert.AreNotEqual(PreviousPoints, CurrPoint, "Points not get transfered from SSC");
//        }

//        public void CreateSSCTicketForDiningVoucherCompensation(Dictionary<string, string> SSCTicketData)
//        {
//            ////Navigating to Tickets
//            HomePage homePage = new HomePage(driver);
//            //homePage.NavigateToSSC_Service();
//            //homePage.NavigateToSSC_Service_To_Ticket();

//            //Creating manual tier upgrade ticket
//            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(SSCTicketCreateBtn);
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
//            //WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(5000);
//            // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), SSCTicketData["Type"]);

//            //Type selected by default in the application, not working the below code
//            //WebHandlers.Instance.SSCCustomDropDownSelectValue((SSCNewTicketFields("Type")), SSCTicketData["Type"]);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Type")), SSCTicketData["Type"]);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Item Category")), SSCTicketData["ItemCategory"]);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Team")).Clear();
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");

//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
//            Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    DiningVoucher").DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(2000);
//            //if (driver.FindElement(SSCNewTicketFields("Source")).Text == "")
//            //{
//            //    driver.FindElement(SSCNewTicketFields("Source")).Clear();
//            //    driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
//            //    BrowserDriver.Sleep(2000);
//            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            //}
//            BrowserDriver.Sleep(2000);
//            //try
//            //{
//            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            //    BrowserDriver.Sleep(2000);
//            //}
//            //catch (Exception e)
//            //{
//            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            //    BrowserDriver.Sleep(2000);
//            //}
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status and target tier details
//            //WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            try
//            {
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
//                //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Status")), "Open");

//                //Status selection
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                //Status selection
//            }
//            catch
//            {
//                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                BrowserDriver.Sleep(2000);
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
//                //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Status")), "Open");
//                //Status selection
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                //Status selection
//            }
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), "DiningVoucher");

//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Business Area")), "Online");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Harrods");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), "Mens");
//            BrowserDriver.Sleep(1000);

//            // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Single/Multiple"), "Single");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Single/Multiple")), "Single");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Dining Experience Vouchers");
//            BrowserDriver.Sleep(1000);
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Dining Voucher Value"), "£15-Hot Beverage");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Dining Voucher Value")), "£15 - Hot Beverage & Dessert in Harrods Cafe");

//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.Click(SSCTicketEmailSend);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status to solved
//            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            //BrowserDriver.Sleep(2000);
//            // WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            BrowserDriver.Sleep(2000);
//            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Status")), "Solved");
//            //BrowserDriver.Sleep(1000);
//            //WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Approval verification and withdrawal
//            WebHandlers.Instance.Click(SSCTicketsActions);
//            BrowserDriver.Sleep(1000);
//            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//            BrowserDriver.Sleep(4000);

//            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
//            {
//                try
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);

//                }
//                catch (Exception e)
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);
//                }
//            }
//            Assert.IsTrue(driver.FindElement(SpanSSCText("Solved")).Displayed, "SSC Ticket status not changed to solved");
//        }

//        public void ValidateDiningCompensationTicketGetsClosedWithoutAnyApprovals()
//        {
//            Assert.IsTrue(driver.FindElement(SpanSSCText("Closed")).Displayed, "SSC Ticket status not changed to closed");
//        }

//        public void CreateSSCTicketForFlowerAsCompensation(Dictionary<string, string> SSCTicketData)
//        {
//            //Creating manual tier upgrade ticket
//            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(SSCTicketCreateBtn);
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketDescription);
//            WebWaitHelper.Instance.WaitForVisibleble(SSCNewTicketFields("Type"), TimeSpan.FromSeconds(WebConstants.ELEMENT_TIMEOUT_SECS));
//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Type"), SSCTicketData["Type"]); => changed by ajay 04.11.2022

//            //Type selected by default in the application, not working below code of separate selection
//            //driver.FindElement(SSCNewTicketFields("Type")).Clear();
//            //driver.FindElement(SSCNewTicketFields("Type")).SendKeys(SSCTicketData["Type"]);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Item Category")), SSCTicketData["ItemCategory"]);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Team")).Clear();
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Service");
//            BrowserDriver.Sleep(2000);

//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
//            Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + SSCTicketData["Subject"]).DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(4000);
//            driver.FindElement(SSCNewTicketFields("Source")).Clear();
//            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            //try
//            //{
//            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            //    BrowserDriver.Sleep(2000);
//            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            //    BrowserDriver.Sleep(2000);
//            //}
//            //catch (Exception e)
//            //{
//            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            //    BrowserDriver.Sleep(2000);
//            //    WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            //    BrowserDriver.Sleep(2000);
//            //}
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(10000);

//            //Changing ticket status and target tier details
//            WebWaitHelper.Instance.WaitForElement(SSCNewTicketEditIcon);
//            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            BrowserDriver.Sleep(2000);
//            try
//            {
//                //    WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
//                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(SSCTicketData["Open"]);
//                SSCNewTicketEditIcon.Click();
//                BrowserDriver.Sleep(4000);
//                //WebHandlers.Instance.DropDownSetByVal(driver.FindElement(SSCNewTicketFields("Status")), "Open");                
//                //ContentAction.MoveToElement(driver.FindElement(SSCNewTicketFields("Status"))).Click().SendKeys("Open").DoubleClick().Build().Perform();
//                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);

//                //Status selection
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                //Status selection
//            }
//            catch
//            {
//                WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                BrowserDriver.Sleep(2000);
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
//                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(SSCTicketData["Open"]);
//                BrowserDriver.Sleep(4000);
//                //WebHandlers.Instance.DropDownSetByVal(driver.FindElement(SSCNewTicketFields("Status")), "Open");                
//                //ContentAction.MoveToElement(driver.FindElement(SSCNewTicketFields("Status"))).Click().SendKeys("Open").DoubleClick().Build().Perform();
//                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);

//                //Status selection
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                //Status selection
//            }
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), SSCTicketData["Subject"]);

//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Business Area")), "Online");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Harrods");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), "Mens");
//            BrowserDriver.Sleep(1000);

//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Single/Multiple"), "Single");
//            driver.FindElement(SSCNewTicketFields("Single/Multiple")).Clear();
//            //driver.FindElement(SSCNewTicketFields("Single/Multiple")).SendKeys(SSCTicketData["Single"]);
//            driver.FindElement(SSCNewTicketFields("Single/Multiple")).SendKeys("Single");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Flowers");
//            BrowserDriver.Sleep(1000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("eFlorist Order Value")), "2.50");
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            string title = (string)js.ExecuteScript("arguments[0].value = '';", driver.FindElement(SSCNewTicketFields("eFlorist Order Value")));
//            driver.FindElement(SSCNewTicketFields("eFlorist Order Value")).Clear();
//            BrowserDriver.Sleep(3000);
//            driver.FindElement(SSCNewTicketFields("eFlorist Order Value")).SendKeys("2.50");


//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), config.SSCTicketAssignedTo);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.Click(SSCTicketEmailSend);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Changing ticket status to solved
//            //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//            //BrowserDriver.Sleep(2000);
//            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//            //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//            //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(SSCTicketData["Solved"]);
//            //WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//            //BrowserDriver.Sleep(1000);
//            //SSC_StatusDropdown_TicketSolved.Click();
//            //BrowserDriver.Sleep(1000);
//            //BrowserDriver.Sleep(1000);
//            //WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Approval verification and withdrawal
//            WebHandlers.Instance.Click(SSCTicketsActions);
//            BrowserDriver.Sleep(1000);
//            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//            BrowserDriver.Sleep(4000);

//            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
//            {
//                try
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);

//                }
//                catch (Exception e)
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);
//                }
//            }
//            Assert.IsTrue(driver.FindElement(SpanSSCText("Solved")).Displayed, "SSC Ticket status not changed to solved");
//        }

//        public void CreateSSCTicketToResolveComplaintByApology(Dictionary<string, string> SSCTicketData)
//        {
//            string Url = "https://www.google.com/";

//            //Creating manual tier upgrade ticket
//            //WebWaitHelper.Instance.WaitForElementPresence(SSCMyTicketsHeader);
//            BrowserDriver.Sleep(3000);
//            WebHandlers.Instance.Click(SSCTicketCreateBtn);
            
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Individual Customer")), SSCTicketData["UserName"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Contact Category")), SSCTicketData["ContactCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Category")), SSCTicketData["SubCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject Details Category")), SSCTicketData["SubDetailCategory"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Item Category")), SSCTicketData["ItemCategory"]);
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Team")).Clear();
//            driver.FindElement(SSCNewTicketFields("Team")).SendKeys("Harrods - Customer Relations");
//            BrowserDriver.Sleep(2000);


//            //Performing ticket Save and close
//            WebHandlers.Instance.SwitchToFrame(SSCNewTicketEmailFrame);
//            Actions ContentAction = new Actions(driver);
//            BrowserDriver.Sleep(2000);
//            ContentAction.MoveToElement(SSCNewTicketContentBox).Click().SendKeys("    " + SSCTicketData["Subject"]).DoubleClick().Build().Perform();
//            WebHandlers.Instance.SwithBackFromFrame();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Brand")));
//            BrowserDriver.Sleep(4000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Source")), SSCTicketData["Source"]);
//            driver.FindElement(SSCNewTicketFields("Source")).Clear();
//            driver.FindElement(SSCNewTicketFields("Source")).SendKeys(SSCTicketData["Source"]);
//            BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Subject")), SSCTicketData["Subject"]);
//            try
//            {
//                WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Social Channel")), "Facebook");
//            }
//            catch (NoSuchElementException) { }
//            BrowserDriver.Sleep(2000);
//            SSCNewTicketSaveOpen.Click();
//            BrowserDriver.Sleep(10000);

//            //Changing ticket status and target tier details
            
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
//            //try { WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open"); }
//            try
//            {

//                SSCNewTicketEditIcon.Click();
//                BrowserDriver.Sleep(4000);                

//                //Status selection
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                //Status selection

//            }
//            catch
//            {
//                //WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                //SSCNewTicketEditIcon.Click();
//                BrowserDriver.Sleep(2000);
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Open");
//                //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Open");

//                //Status selection
//                WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                //SSC_StatusDropdownBtn.Click();
//                BrowserDriver.Sleep(1000);
//                SSC_StatusDropdown_TicketOpen.Click();
//                BrowserDriver.Sleep(1000);
//                //Status selection
//            }
//            driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Summary")), SSCTicketData["Subject"]);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Mobile")));
//            try
//            {
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Business Area"), "Online");
//                //WebHandlers.Instance.DropDownSetByVal(driver.FindElement(SSCNewTicketFields("Business Area")), "Online");
//                driver.FindElement(SSCNewTicketFields("Business Area")).Clear();
//                driver.FindElement(SSCNewTicketFields("Business Area")).SendKeys("Online");
//            }
//            catch
//            {
//                //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Business Area")), "Online");
//                driver.FindElement(SSCNewTicketFields("Business Area")).Clear();
//                driver.FindElement(SSCNewTicketFields("Business Area")).SendKeys("Online");
//            }
//            BrowserDriver.Sleep(1000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Fulfillment Point")), "Harrods");
//            driver.FindElement(SSCNewTicketFields("Fulfillment Point")).Clear();
//            driver.FindElement(SSCNewTicketFields("Fulfillment Point")).SendKeys("Gucci");
//            BrowserDriver.Sleep(1000);
//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Online Division")), "Mens");
//            driver.FindElement(SSCNewTicketFields("Online Division")).Clear();
//            driver.FindElement(SSCNewTicketFields("Online Division")).SendKeys("Childrenswear");
//            BrowserDriver.Sleep(1000);

//            if (SSCTicketData["Subject"] == "Rewards card")
//                //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Reason"), "Points");
//                //driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Points"); ==> changed by ajay 04.11.2022
//                driver.FindElement(SSCNewTicketFields("Reason")).SendKeys("Points Migration");
//            BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Single/Multiple"), "Single");
//            driver.FindElement(SSCNewTicketFields("Single/Multiple")).SendKeys("Single");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Goodwill Type")), "Gift Cards");
//            BrowserDriver.Sleep(3000);

//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Gift Card Value")), "10.50");
//            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            string title = (string)js.ExecuteScript("arguments[0].value = '';", driver.FindElement(SSCNewTicketFields("Gift Card Value")));
//            driver.FindElement(SSCNewTicketFields("Gift Card Value")).Clear();
//            BrowserDriver.Sleep(3000);
//            driver.FindElement(SSCNewTicketFields("Gift Card Value")).SendKeys("10.50");

//            BrowserDriver.Sleep(3000);
//            //Sending interaction email from ticket
//            driver.FindElement(SSCNewTicketSubTabs("Interactions")).Click();
//            WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCNewTicketFields("Status")));
//            BrowserDriver.Sleep(2000);
//            driver.FindElement(SSCNewTicketFields("Assigned to")).SendKeys(config.SSCTicketAssignedTo);
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(SSCNewTicketEmailIcon);
//            WebHandlers.Instance.Click(SSCTicketEmailSend);
//            BrowserDriver.Sleep(5000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(6000);

//            //Adding Attachment
//            driver.FindElement(SSCNewTicketSubTabs("Attachments")).Click();
//            //WebHandlers.Instance.WebElementExists(driver.FindElement(SSCBdiGridValue("Add")));
//            WebHandlers.Instance.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(SSCBdiGridValue("Status")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Add")));
//            WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Web Link")));
//            WebHandlers.Instance.WebElementExists(driver.FindElement(SSCNewTicketFields("Link")));
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Link")), Url);
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Title")), SSCTicketData["Subject"]);
//            WebHandlers.Instance.Click(SSCTicketsAttachmentAddBtn);
//            BrowserDriver.Sleep(4000);

//            //Changing ticket status to solved

//            //WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Assigned to")), "Ajay Sundar"); //hard coded to ajay id
//            //driver.FindElement(SSCNewTicketFields("Assigned to")).SendKeys("Ajay Sundar");
//            BrowserDriver.Sleep(3000);
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");

//            ///======//// Look at this later 
//            //            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
//            //            string title = (string)js.ExecuteScript("arguments[0].value = 'Solved';", SSCNewTicketFields("Status"));
//            ///======////
//            //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//            BrowserDriver.Sleep(1000);
//            // driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//            //BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//            BrowserDriver.Sleep(9000);

//            //Approval verification and withdrawal == > Below part of code is currently on hold due to admin rights for ssc user
//            WebHandlers.Instance.Click(SSCTicketsActions);
//            BrowserDriver.Sleep(1000);
//            Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//            WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//            BrowserDriver.Sleep(4000);

//            if (driver.FindElements(SpanSSCText("Solved")).Count == 0)
//            {
//                try
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);

//                }
//                catch(Exception e)
//                {
//                    WebHandlers.Instance.Click(SSCNewTicketEditIcon);
//                    BrowserDriver.Sleep(4000);
//                    // WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Status"), "Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).Clear();
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys("Solved");
//                    //driver.FindElement(SSCNewTicketFields("Status")).SendKeys(Keys.Enter);
//                    //if (driver.FindElement(SSCNewTicketFields("Status")).GetAttribute("readonly").Equals("readonly"))
//                    //Status selection
//                    WebHandlers.Instance.Click(SSCTicketsActions);
//                    BrowserDriver.Sleep(1000);
//                    Assert.IsTrue(SSCTicketsActionsWithdrawApproval.Displayed, "Ticket is not blocked for approval");
//                    WebHandlers.Instance.Click(SSCTicketsActionsWithdrawApproval);
//                    BrowserDriver.Sleep(4000);
//                    //Status selection
//                    WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketFields("Status")));
//                    //SSC_StatusDropdownBtn.Click();
//                    BrowserDriver.Sleep(1000);
//                    SSC_StatusDropdown_TicketSolved.Click();
//                    BrowserDriver.Sleep(1000);
//                    //Status selection

//                    BrowserDriver.Sleep(1000);
//                    WebHandlers.Instance.Click(SSCNewTicketSave);
//                    //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//                    BrowserDriver.Sleep(6000);
//                }
                
//            }
//            Assert.IsTrue(driver.FindElement(SpanSSCText("Solved")).Displayed, "SSC Ticket status not changed to solved");
//        }

//        public void ValidateApproversNamesWereAddedOnSSCTicket()
//        {
//            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
//            BrowserDriver.Sleep(1000);
//            driver.FindElement(SSCNewTicketSubTabs("Approval")).Click();
//            BrowserDriver.Sleep(2000);
//            //Assert.IsTrue(driver.FindElement(TableTdText("1 (1 Approver required, 1 pending) (1)")).Displayed, "Approver details not listing on SSC tickets");
//        }


//        public void ValidatePurchaseActivityShowingOnSSC(string ActivityType, string SearchItem = null)
//        {
//            WebHandlers.Instance.WebElementExists(driver.FindElement(SSCNewTicketSubTabs("Purchases")));
//            BrowserDriver.Sleep(4000);
//            driver.FindElement(SSCNewTicketSubTabs("Purchases")).Click();
//            BrowserDriver.Sleep(3000);

//            string subjectString = driver.FindElement(By.XPath("//*[contains(@id,'paginator-pageInfo-bdi')]")).Text;
//            string pagination = GetNumbers(subjectString);
//            int p = Int32.Parse(pagination);

//            for (int i = 0; i < 10; i++)
//            {
//                try
//                {
//                    IWebElement pointexpiry = driver.FindElement(SpanSSCTextFirst(ActivityType));
//                    string point = pointexpiry.Text;
//                    if (point.Equals(ActivityType))
//                    {
//                        break;
//                    }

//                }
//                catch { driver.FindElement(By.XPath("//*[@role='button'][contains(@id,'paginator-nextPage')]")).Click(); }
//            }


//            //WebHandlers.Instance.WebElementExists(SSCCustomersSearchIcon);
//            //if (!string.IsNullOrEmpty(SearchItem))
//            //{
//            //    try { SSCCustomersSearchIcon.Click(); }
//            //    catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
//            //    BrowserDriver.Sleep();
//            //    WebHandlers.Instance.EnterText(SSCCustomersDetailsSearchEdit, SearchItem + "\n");
//            //    BrowserDriver.Sleep(4000);
//            //    WebHandlers.Instance.WebElementExists(driver.FindElement(SpanSSCText(SearchItem)));
//            //}
//            Assert.IsTrue(driver.FindElement(SpanSSCTextFirst(ActivityType)).Displayed, ActivityType + " purchase activity against user is not showing on SSC");
//        }

//        public void ValidateResolvedAndResolutionDateWereShowingAsPerSLA()
//        {
//            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
//            driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
//            BrowserDriver.Sleep(2000);
//            //Assert.AreNotEqual("", driver.FindElement(SSCUserFieldData("Resolved On")).GetAttribute("innerText"), "Resolved On date inside SSC timeline is not showing as per SLA");
//            //Assert.AreNotEqual("", driver.FindElement(SSCUserFieldData("Resolution Due")).GetAttribute("innerText"), "Resolution Due date inside SSC timeline is not showing as per SLA");
//        }

//        public void VerifyTicketSummaryCanBeAccessedByTheCustomer(string Condition)
//        {
//            //Performing summary export
//            WebHandlers.Instance.Click(SSCTicketsActions);
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.Click(SSCTicketsActionsGenerateSummary);
//            WebWaitHelper.Instance.WaitForElement(driver.FindElement(SSCNewTicketFields("Select Form Template")));
//            BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Select Form Template"), "Harrods_Letter");
//            driver.FindElement(SSCNewTicketFields("Select Form Template")).SendKeys("Harrods_Letter");
//            BrowserDriver.Sleep(2000);
//            //WebHandlers.Instance.SSCCustomDropDownSetByVal(SSCNewTicketFields("Select Signature Type"), "Graphical");
//            WebHandlers.Instance.EnterText(driver.FindElement(SSCNewTicketFields("Select Signature Type")), "Graphical Signature of Agent");
//            BrowserDriver.Sleep(1000);
//            WebHandlers.Instance.Click(driver.FindElement(SSCBdiGridValue("Generate")));
//            //WebHandlers.Instance.Elementnotpresent(driver.FindElement(SSCBdiGridValue("Generate")));
//            BrowserDriver.Sleep(3000);

//            //Validating generated pdf
//            //driver.FindElement(SSCNewTicketSubTabs("Attachments")).Click();
//            BrowserDriver.Sleep(2000);
//            WebHandlers.Instance.WebElementExists(driver.FindElement(SSCLinkContains(".pdf")));
//            Assert.IsTrue(driver.FindElement(SSCLinkContains(".pdf")).Displayed, "Newly generated summary file is not showing on SSC");
//        }

//        public void ToggleUserObsoleteStatusFromSSC(string ActionItem)
//        {
//            try { SSCCustomerDetailsExpandBtn.Click(); } catch { }
//            BrowserDriver.Sleep(1000);
//            string CurrentStatus = SSCCustomerObsoleteStatus.GetAttribute("innerText");
//            WebHandlers.Instance.Click(SSCNewTicketEditIcon);

//            if (ActionItem == "Set As Obsolete" && CurrentStatus != "Yes")
//            {
//                WebHandlers.Instance.WebElementExists(driver.FindElement(SSCSetAsOboleteToggleBtn("No")));
//                BrowserDriver.Sleep(1000);
//                driver.FindElement(SSCSetAsOboleteToggleBtn("No")).Click();
//                BrowserDriver.Sleep(2000);
//            }
//            else if (ActionItem == "Set As Active" && CurrentStatus == "Yes")
//            {
//                WebHandlers.Instance.WebElementExists(driver.FindElement(SSCSetAsOboleteToggleBtn("Yes")));
//                BrowserDriver.Sleep(1000);
//                driver.FindElement(SSCSetAsOboleteToggleBtn("Yes")).Click();
//                BrowserDriver.Sleep(2000);
//            }

//            WebHandlers.Instance.Click(SSCNewTicketSave);
//            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
//        }

//        public void VerifyObsoleteStatusOnSSC(string Status)
//        {
//            //WebHandlers.Instance.Click(SSCCustomerDetailsExpandBtn);
//            BrowserDriver.Sleep(2000);
//            Assert.AreEqual(Status, SSCCustomerObsoleteStatus.GetAttribute("innerText"), "Osolute status for given user is not showing as expected on SSC");
//        }


//        //public void CustomerRegistrationOnSSC(Dictionary<string, string> customerData)
//        //{
//        //    string firstName = customerData["FirstName"];
//        //    string lastName = customerData["LastName"];
//        //    string eMail = customerData["Email"];
//        //    string phoneNumber = customerData["Phone"];
//        //    string dob = customerData["DOB"];

//        //    Console.WriteLine("*********************After Entering the Customer Screen in SSC ");
//        //    Console.WriteLine("First Name of the Customer :" + firstName);
//        //    Console.WriteLine("Last Name of the Customer : " + lastName);
//        //    Console.WriteLine("Email of the Customer : " + eMail);
//        //    Console.WriteLine("Phone Number of the customer : " + phoneNumber);
//        //    Console.WriteLine("Date Of Birth of the Customer : " + dob);

//        //    WebHandlers.Instance.Click(SSCCreateNewCustomerButton);
//        //    Console.WriteLine("***Clicked New Customer Btn");
//        //    BrowserDriver.Sleep(3000);
//        //    //bdi[text()='Account Type']/parent::span/following-sibling::div//input
//        //    IWebElement AccountType = driver.FindElement(By.XPath("//bdi[text()='Account Type']/parent::span/following-sibling::div//input"));
//        //    AccountType.Click();
//        //    BrowserDriver.Sleep(3000);
//        //    AccountType.SendKeys("Full Account");
//        //    //WebHandlers.Instance.EnterText(AccountType, "Full Account");
//        //  // WebHandlers.Instance.MultiSelectByText(driver.FindElement(By.XPath("//div[text()='Full Account']")), "Full Account", "Selected the Title");
//        //    Console.WriteLine("***Full Account Selected");
//        //    //WebHandlers.Instance.Click(driver.FindElement(SSCNewCustomerRegisterationFields("First Name")));
//        //    IWebElement FName = driver.FindElement(By.XPath("//bdi[text()='First Name']/parent::span/following-sibling::div//input"));
//        //    //FName.SendKeys(firstName);
//        //    WebHandlers.Instance.EnterText(FName, customerData["FirstName"], $"Entered FirstName");
//        //    Console.WriteLine("****Entered First Name");
//        //    IWebElement LName = driver.FindElement(By.XPath("//bdi[text()='Last Name']/parent::span/following-sibling::div//input"));
//        //    //LName.SendKeys(lastName);
//        //    WebHandlers.Instance.EnterText(LName, customerData["LastName"], $"Entered LastName");
//        //    Console.WriteLine("****Entered last Name");
//        //    IWebElement Email = driver.FindElement(By.XPath("//bdi[text()='E-Mail']/parent::span/following-sibling::div//input"));
//        //    //Email.SendKeys(eMail);
//        //    WebHandlers.Instance.EnterText(LName, customerData["Email"], $"Entered Email");
//        //    Console.WriteLine("****Entered Email");
//        //    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Save']")));
//        ////    Console.WriteLine("******Clicked Save Btn");


//        //}
//    }
//}
