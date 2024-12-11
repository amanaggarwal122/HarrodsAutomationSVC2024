using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TAF_Scripting.Test.Common;
using TAF_Web.Scripted.Web;


namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerContactDetailsPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private SSCCustomersPage SSC_Customers_Page = null;

        #region  Constructor
        public SSCCustomerContactDetailsPage(IWebDriver driver, Configuration configuration)
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
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;
        [FindsBy(How = How.XPath, Using = "//*[text()='No results found. Search again in all items?']")]
        private IWebElement SSCNoREsultLink;
        [FindsBy(How = How.XPath, Using = "//input[@checked='checked'][@type='CheckBox']/ancestor::td/..//span[text()='Address']")]
        private IWebElement SSCCustomerContactAddressDetails;
        [FindsBy(How = How.XPath, Using = "//div[text()='Contact Details']")]
        private IWebElement SSCCustomersSubtabContactDetails;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;
        [FindsBy(How = How.XPath, Using = "//span[text()='Edit']/following::td/..//*[@class='sapMCbBg sapMCbHoverable sapMCbMark']")]
        private IWebElement SSCEditCheckBox;
        [FindsBy(How = How.XPath, Using = "//*[@value='Profile data']/preceding::div[1]")]
        private IWebElement SSCProfileDataEditCheckBox;
        [FindsBy(How = How.XPath, Using = "//*[@value='Address']/preceding::div[1]")]
        private IWebElement SSCAddressDataEditCheckBox;
        [FindsBy(How = How.XPath, Using = "//*[@value='Address']/preceding::div[1]")]
        private IWebElement SSCAddressEditCheckBox;
        [FindsBy(How = How.XPath, Using = "//th[@title='Validate Address']/following::span[@title='Remove']")]
        private IWebElement SSCAddressRemove;     
        [FindsBy(How = How.XPath, Using = "//*[text()='Phone']/following::td/..//*[@class='sapMInputBaseInner']")]
        private IWebElement SSCPhonenumberfieldinEditmode;
        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;
        [FindsBy(How = How.XPath, Using = "//button[@data-sap-automation-id='button-ListModification-Add']")]
        private IWebElement SSCNewAddressAddbtn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
        private IWebElement SSCEditCustomerSavebtn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Add']")]
        private IWebElement SSCAddCustomerDetails;
        [FindsBy(How = How.XPath, Using = "(//input[contains(@id,'dropdownlistbox')][@aria-required='true'])[1]")]
        private IWebElement SSCSelectAddressTypeInput;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Phone']/following::input[1][contains(@id,'inputField-inner')]")]
        private IWebElement SSCPhone;
        //[FindsBy(How = How.XPath, Using = "(//bdi[text()='Phone']/following::span)[1]")]
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Phone'])//following::input[@id='linkMivQh0tym4_X5miYlufBEG_1193-inputField-inner']")]
        private IWebElement SSCCustomerPhone_Field1;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Phone']/following::span)[54]")]
        private IWebElement SSCCustomerPhone_Field2;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Phone']/following::div)[258]//div[3]/div[1]/div")]
        private IWebElement SSCCustomerPhone_Field3;


        #endregion
        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }
        public By SSCCustomerAddressFieldData(string AddressValue)
        {
            return By.XPath("//span[contains(text(),'" + AddressValue + "')]");
        }
        public By SSCCustomerContactAddress { get => By.XPath("//input[@checked='checked'][@type='CheckBox']/ancestor::td/..//span[text()='Address']"); }
        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SSCAddressAlignToPhone(string PhoneNumber) { return By.XPath("//a[contains(text(),'" + PhoneNumber + "')]/ancestor::td/..//span[text()='Address']"); }
        public By SSCCustomersGridData(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }
        public By SSCCustomerContactAddressCheckbox { get => By.XPath("//input[@type='CheckBox']/ancestor::td/..//span[text()='Address']"); }
        public By SSCUserContactAddressCheckbox { get => By.XPath("//input[@type='CheckBox']/ancestor::td/.."); }
        public By SSCSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SSCAddAddressFields(string FieldName) { return By.XPath("//bdi[text()='" + FieldName + "']/../following-sibling::div//input[@aria-required='true']"); }
        public By SSCAddAddressOptFields(string FieldName, int count) { return By.XPath("(//bdi[text()='" + FieldName + "']/../following-sibling::div//input)[" + count + "]"); }
        public By SSCCustomerAddressFieldInput(string AddressField) { return By.XPath("//bdi[text()='" + AddressField + "']/..//following::input[1]"); }
        public By SSCCustomerBDate(string text) { return By.XPath("//*[text()='" + text + "']"); }
        public By SSCUserDOB(string text)
        { return By.XPath("//bdi[text()='Date of Birth']//following::div[1]"); }
        public By SSCIsDefaultAddress(string Value) { return By.XPath("//span[contains(text(),'" + Value + "') and @title='isDefault']"); }
        public By SSCIsBillingAddress(string Value) { return By.XPath("//span[contains(text(),'" + Value + "') and @title='isBilling']"); }
        public By SSCIsDeliveryAddress(string Value) { return By.XPath("//span[contains(text(),'" + Value + "') and @title='isDelivery']"); }

        #region Events

        public void NavigatetoContactDetailsinSSC()
        {
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabContactDetails.Click();
            BrowserDriver.Sleep(3000);
        }

        public DateTime ResendVerificationemailinSSC()
        {
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Resend Verification Email']")));
            BrowserDriver.Sleep(3000);
            Boolean isEmailSent = WebHandlers.Instance.IsElementPresent(By.XPath("//bdi[text()='Email Sent']"));
            DateTime registrationCompltedTime = DateTime.Now;
            Assert.IsTrue(isEmailSent, "Verification Email is not sent to the customer");
            return registrationCompltedTime;
        }

        public void AddressDelete()
        {
            //To remove Added Adrress
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//th[@title='Validate Address']/following::span[@title='Remove']")));
            BrowserDriver.Sleep(5000);
            SSCSaveButton.Click();

        }

        public string ValidateUserAddedAddressOnSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //Navigating to the page and editing given customer
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Performin address validation
            driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
            BrowserDriver.Sleep(5000);
            //driver.FindElement(SSCAddressAlignToPhone(PostalAddress["CellPhone"])).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='Address']")));
            BrowserDriver.Sleep(2000);
           //s Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on SSC customer address grid");
            Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on SSC customer address grid");
            Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["AddressLine2"])).Displayed, PostalAddress["AddressLine2"] + " not showing on SSC customer address grid");
            // Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["AddressLine3"])).Displayed, PostalAddress["AddressLine3"] + " not showing on SSC customer address grid");
            Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["City"])).Displayed, PostalAddress["City"] + " not showing on SSC customer address grid");
            Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SSC customer address grid");
            return CdcId;

            
        }
        //To remove Added Adrress
        public void AddressRemovalinSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //To remove Added Adrress
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//th[@title='Validate Address']/following::span[@title='Remove']")));
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//th[@title='Validate Address']/following::span[@title='Remove']")));
            SSCSaveButton.Click();

        }

        public string validateCityPostStateinSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            try
            {
                SSCCustomersSearchIcon.Click();
                if (SSCNoREsultLink.Displayed)
                {
                    SSCNoREsultLink.Click();
                }
            }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }

            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            //Performin address validation
            driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomerContactAddressDetails);
            BrowserDriver.Sleep(2000);
            Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Country"])).Displayed, PostalAddress["Country"] + " not showing on SSC customer address grid");
            //  Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["State"])).Displayed, PostalAddress["State"] + " not showing on SSC customer address grid");
            Assert.IsTrue(driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed, PostalAddress["Postcode"] + " not showing on SSC customer address grid");
            return CdcId;
        }

        public string ValidateUserAddedAddressOnSSCwithDefault(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //Navigating to the page and editing given customer
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(8000);

            //Performin address validation
            driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
            BrowserDriver.Sleep(3000);
            //Takes the number of address links in the table present in Contact details screen 
            ReadOnlyCollection<IWebElement> addresslinks = driver.FindElements(By.XPath("//span[text()='Address'][contains(@id,'dropdownlist')][contains(@id,'text-listdefintion')]"));
            for (int i = 0; i < addresslinks.Count; i++)
            {
                addresslinks[i].Click();
                //checks whether the post code matches with the value updated in harrods.com
                Boolean postcode_status = driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed;
                BrowserDriver.Sleep(2000);
                ReadOnlyCollection<IWebElement> isDefaultlabels = driver.FindElements(By.XPath("//bdi[text()='IsDefault']"));
                if (postcode_status)
                {
                    string defaultcontacttoggle = isDefaultlabels[2].Text;
                    if (defaultcontacttoggle.Equals("Yes"))
                    {
                        //Assert.True(defaultcontacttoggle.Equals("Yes"), "This is not a default address");
                        break;
                    }
                }
            }
            return CdcId;
        }

        public string ValidateUserAddedBillingAddressOnSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //Navigating to the page and editing given customer
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            //Performin address validation
            driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
            BrowserDriver.Sleep(3000);
            //Takes the number of address links in the table present in Contact details screen 
            ReadOnlyCollection<IWebElement> addresslinks = driver.FindElements(By.XPath("//span[text()='Address'][contains(@id,'dropdownlist')][contains(@id,'text-listdefintion')]"));
            for (int i = 0; i < addresslinks.Count; i++)
            {
                addresslinks[i].Click();
                //checks whether the post code matches with the value updated in harrods.com
                Boolean postcode_status = driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed;
                BrowserDriver.Sleep(2000);
                ReadOnlyCollection<IWebElement> isBillinglabels = driver.FindElements(By.XPath("//bdi[text()='IsBilling']"));
                if (postcode_status)
                {
                    string billingcontacttoggle = isBillinglabels[2].Text;
                    if (billingcontacttoggle.Equals("Yes"))
                    {
                        //Assert.True(defaultcontacttoggle.Equals("Yes"), "This is not a default address");
                        break;
                    }
                }
                //if (postcode_status)
                //{
                //    string defaultcontacttoggle = driver.FindElement(By.XPath("//*[@class='sapClientBaseControlsSimpleVLayout sapClientMFormElement sapClientMSwitchElement']//*[text()='IsBilling']/following::div[1]")).Text;
                //    Assert.IsTrue(defaultcontacttoggle.Equals("Yes"),"This address is not the Billing address");
                //    break;
                //}
            }
            return CdcId;
        }

        public void ChangeBillingAddressandSave(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            // BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCCustomersSubtabContactDetails);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            //ReadOnlyCollection<IWebElement> addresslinks = driver.FindElements(By.XPath("//span[contains(@id,'dropdownlist')][contains(@id,'text-listdefintion')]"));
            //ReadOnlyCollection<IWebElement> checkbox_links = driver.FindElements(By.XPath("//span[text()='Edit']/following::td/..//*[@class='sapMCbBg sapMCbHoverable sapMCbMark']"));
            ReadOnlyCollection<IWebElement> type = driver.FindElements(By.XPath("//table[2]/tbody/tr/td[3]/div/div/div/input"));
            for (int i = 0; i < type.Count; i++)
            {
                //string type = driver.FindElement(By.XPath("//table[2]/tbody[1]/tr[" + i + "]/td[3]/div[1]")).GetAttribute("value");
                if (type[i].GetAttribute("value").Equals("Profile data"))
                {
                    //                    WebHandlers.Instance.Click(SSCDetailsEditIcon);
                    BrowserDriver.Sleep(3000);
                    //clicking the check box
                    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//table[2]/tbody[1]/tr[" + i + 1 + "]/td[2]/div[1]/div[1]/div[1]")));
                    break;
                }
            }

            for (int i = 0; i < type.Count; i++)
            {
                //string type = driver.FindElement(By.XPath("//table[2]/tbody[1]/tr[" + i + "]/td[3]/div[1]")).GetAttribute("value");
                if (type[i].GetAttribute("value").Equals("Address"))
                {
                    //                    WebHandlers.Instance.Click(SSCDetailsEditIcon);
                    BrowserDriver.Sleep(3000);
                    //clicking the check box
                    int posi = i + 1;
                    WebHandlers.Instance.Click(driver.FindElement(By.XPath("//table[2]/tbody/tr[" + posi.ToString() + "]/td[5]/div/div/div")));
                    break;
                }
            }
        }

        public string ValidateUserAddedDeliveryAddressOnSSC(string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            //Navigating to the page and editing given customer
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            //Performin address validation
            driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
            BrowserDriver.Sleep(3000);
            //Takes the number of address links in the table present in Contact details screen 
            ReadOnlyCollection<IWebElement> addresslinks = driver.FindElements(By.XPath("//span[text()='Address'][contains(@id,'dropdownlist')][contains(@id,'text-listdefintion')]"));
            for (int i = 0; i < addresslinks.Count; i++)
            {
                addresslinks[i].Click();
                //checks whether the post code matches with the value updated in harrods.com
                Boolean postcode_status = driver.FindElement(SSCCustomerAddressFieldData(PostalAddress["Postcode"])).Displayed;
                BrowserDriver.Sleep(2000);
                if (postcode_status)
                {
                    string defaultcontacttoggle = driver.FindElement(By.XPath("//*[@class='sapClientBaseControlsSimpleVLayout sapClientMFormElement sapClientMSwitchElement']//*[text()='IsDelivery']/following::div[1]")).Text;
                    Assert.IsTrue(defaultcontacttoggle.Equals("Yes"), "This is not the delivery address");
                    break;
                }
            }
            return CdcId;
        }
        //TC_73A
        public void ValidateUserAddressGetsDeletedFromSSC(string FullName, string Email)
        {
            //Navigating to the page and editing given customer
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            WebHandlers.Instance.WebElementExists(driver.FindElement(SSCNewTicketSubTabs("Contact Details")));
            BrowserDriver.Sleep(5000);

            //Validating address gets deleted from the grid
            driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
            BrowserDriver.Sleep(3000);
            BrowserDriver.Sleep(3000);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            Actions actions = new Actions(driver);
            actions.MoveToElement(SSCProfileDataEditCheckBox);
            //actions.SendKeys(OpenQA.Selenium.Keys.PageDown).Build().Perform();
            BrowserDriver.Sleep(3000);
            //Click Address Data Edit Checkbox to Edit the Address 
            SSCProfileDataEditCheckBox.Click();
            BrowserDriver.Sleep(2000);
            actions.MoveToElement(SSCEditCheckBox);
            SSCEditCheckBox.Click();

            BrowserDriver.Sleep(3000);
            Assert.IsFalse(driver.FindElements(SSCCustomerContactAddress).Count != 0, "Address not get deleted from SSC");
        }
        //TC_90
        public void ValidateUserAddressGetsSwapedFromSSC(string UserCategory,string ExcelFileName, string SheetName, string FullName, string Email)
        {
            //Navigating to the page and editing given customer
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            //Validating address gets deleted from the grid
            driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click();
            BrowserDriver.Sleep(3000);
            //Console.WriteLine("----Count Of The Address Line in SSC is " + driver.FindElements(SSCCustomerContactAddress).Count);
            //Assert.IsTrue(driver.FindElements(SSCCustomerContactAddress).Count == 2, "Multiple address is not added in SSC");

            Console.WriteLine("----Count Of The Address Line in SSC is " + driver.FindElements(SSCCustomerContactAddressCheckbox).Count);
            Assert.IsTrue(driver.FindElements(SSCUserContactAddressCheckbox).Count > 2, "Multiple address is not added in SSC");
            //Swap contact address from address 1 to address 2 
            BrowserDriver.Sleep(3000);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            Actions actions = new Actions(driver);
            actions.MoveToElement(SSCProfileDataEditCheckBox);
            //actions.SendKeys(OpenQA.Selenium.Keys.PageDown).Build().Perform();
            BrowserDriver.Sleep(3000);
            //Click Address Data Edit Checkbox to Edit the Address 
            SSCProfileDataEditCheckBox.Click();
            BrowserDriver.Sleep(3000);
            {
                // Define locators for the checkboxes
                string checkbox6XPath = "(//*[@title='isDefault'])[6]";
                string checkbox7XPath = "(//*[@title='isDefault'])[7]";

                // Locate the checkbox elements
                IWebElement checkbox6 = driver.FindElement(By.XPath(checkbox6XPath));
                IWebElement checkbox7 = driver.FindElement(By.XPath(checkbox7XPath));
                Dictionary<string, string> addressToSave = null;
                // Check the status of the first checkbox
                if (!checkbox6.Selected)
                {
                    // If checkbox6 is not selected, click it
                    checkbox6.Click();
                    addressToSave = new Dictionary<string, string>

        {
            { "AddressLine1", "ATFullRewardzwgk Address1" },
            { "AddressLine2", "ATFullRewardzwgk Address2" },
            { "City", "United Kingdom" },
            { "Postcode", "EC4Y" }
        };
                }
                else if (checkbox6.Selected)
                {
                    // If checkbox6 is already selected, click checkbox7
                    checkbox7.Click();
                    addressToSave = new Dictionary<string, string>
        {
            { "AddressLine1", "AT4" },
            { "AddressLine2", "AT5" },
            { "City", "Canada" },
            { "Postcode", "K1A 0T6" }
        };
                }

                // Check if checkbox7 is selected and toggle back to checkbox6
                if (checkbox7.Selected)
                {
                    checkbox6.Click();
                }
                if (addressToSave != null)
                {
                    // Save the selected address to Excel
                    DataFilesUtil.SaveDataToExcel(ExcelFileName, SheetName, "AddressLine", UserCategory, addressToSave["AddressLine1"], 0);
                    DataFilesUtil.SaveDataToExcel(ExcelFileName, SheetName, "AddressLine2", UserCategory, addressToSave["AddressLine2"], 0);
                    DataFilesUtil.SaveDataToExcel(ExcelFileName, SheetName, "City", UserCategory, addressToSave["City"], 0);
                    DataFilesUtil.SaveDataToExcel(ExcelFileName, SheetName, "Postcode", UserCategory, addressToSave["Postcode"], 0);
                }
            }

            Assert.IsTrue(driver.FindElements(SSCUserContactAddressCheckbox).Count > 2, "Multiple address is not added in SSC");
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(SSCEditCustomerSavebtn);
            BrowserDriver.Sleep(3000);
        }

        public string AddDefaultUserAddressFromSSC(string Country, string UserName, string Email)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            //string FullName = UserName + " " + UserName + "Lname";
            string FullName = UserName;
            string City = null, State = null, Postcode = null, Phone = null;

            if (Country == "UK")
            {
                City = "Bristol"; State = "LC - London";
                Postcode = "EC4Y"; Country = "GB - United Kingdom";
                Phone = "+44 77" + CommonFunctions.GetRandomNumber(8);
            }
            else if (Country == "US")
            {
                City = "Brooklyn"; State = "NY - New York";
                Postcode = "20833"; Country = "US - United States";
                Phone = "+1 646" + CommonFunctions.GetRandomNumber(7);
            }
            else if (Country == "Canada")
            {
                City = "Edmonton"; State = "AB - Alberta";
                Postcode = "K1A 0T6"; Country = "CA - Canada";
                Phone = "+1 780" + CommonFunctions.GetRandomNumber(7);
            }

            //Assigning new address to the user
            SSC_Customers_Page.SearchCustomerOnSSC(FullName, Email);
            WebHandlers.Instance.WaitForPageLoad();
            BrowserDriver.Sleep(3000);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            //SearchLiteCustomerOnSSC(FullName, Email);
            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Contact Details")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCAddCustomerDetails);
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.Click(SSCSelectAddressTypeInput);
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.Click(driver.FindElement(SSCListItem("Address")));
            WebHandlers.Instance.EnterText(SSCSelectAddressTypeInput, "Address");
            BrowserDriver.Sleep(1500);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Recipient Name")), UserName);
            BrowserDriver.Sleep(500);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Recipient Last Name")), UserName + "Lname");
            BrowserDriver.Sleep(500);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Address Line 1")), UserName + "Address1");
            BrowserDriver.Sleep(500);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressOptFields("Address Line 2", 1)), UserName + "Address2");
            BrowserDriver.Sleep(500);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressOptFields("Address Line 3", 1)), UserName + "Address3");
            BrowserDriver.Sleep(500);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("City")), City);
            BrowserDriver.Sleep(500);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")));
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")), Country);
            driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")).SendKeys(Country);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressOptFields("State", 1)), State);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Postal Code")), Postcode);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Country/Region")), Country);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressOptFields("Country/Region", 2)), Country);
            BrowserDriver.Sleep(2000);
            driver.FindElement(SSCAddAddressFields("Phone")).Clear();
            WebHandlers.Instance.EnterText(driver.FindElement(SSCAddAddressFields("Phone")), Phone);
            WebHandlers.Instance.Click(SSCNewAddressAddbtn);
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(SSCEditCustomerSavebtn);
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
            BrowserDriver.Sleep(2000);
            return Phone;
        }
        //TC_85
        public void EditDefaultUserAddressFromSSC(string Country, string UserName, string Email, string Phonenumber, string AddressLine1, string AddressLine2, string AddressLine3)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            //string FullName = UserName + " " + UserName + "Lname";
            string FullName = UserName;
            string City = null, State = null, Postcode = null;

            if (Country == "UK")
            //{
            //    City = "Hampstead"; State = "16 - Chaco";
            //    Postcode = "NW3"; Country = "GB - United Kingdom";
            //}
            //Country details
            {
                City = "Bristol"; State = "B5 - Bristol";
                Postcode = "EC4Y"; Country = "GB - United Kingdom";
            }
            else if (Country == "US")
            {
                City = "Rochester"; State = "NY - New York";
                Postcode = "14602"; Country = "US - United States";
            }
            else if (Country == "Canada")
            {
                City = "Lacombe"; State = "AB - Alberta";
                Postcode = "Y1A 9Z9"; Country = "CA - Canada";
            }

            //Editing address of user
            SSC_Customers_Page.SearchLiteCustomerOnSSC(FullName, Email);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Contact Details")));
            BrowserDriver.Sleep(3000);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(5000);
            // Scroll down to the page
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("window.scrollBy(0, 1000);");
            Actions actions = new Actions(driver);
            actions.MoveToElement(SSCProfileDataEditCheckBox).Perform();
            BrowserDriver.Sleep(5000);
            //Click Address Data Edit Checkbox to Edit the Address 
            SSCProfileDataEditCheckBox.Click();
            BrowserDriver.Sleep(2000);
            //SSCEditCheckBox.Click();
            BrowserDriver.Sleep(2000);
            SSCAddressDataEditCheckBox.Click();
            BrowserDriver.Sleep(3000);
            //WebHandlers.Instance.Click(SSCCustomerContactAddressDetails);
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 1")), UserName + "Address1Edit" + CommonFunctions.GenerateRandomUser(4));
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 2")), UserName + "Address2Edit" + CommonFunctions.GenerateRandomUser(4));
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 3")), UserName + "Address3Edit" + CommonFunctions.GenerateRandomUser(4));
            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 1")), AddressLine1);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 2")), AddressLine2);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Address Line 3")), AddressLine3);




            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("City")), City);

            WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")));
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")), Country);
            driver.FindElement(By.XPath("(//bdi[text()='Country/Region']/../following-sibling::div//input)[1]")).SendKeys(Country);
            BrowserDriver.Sleep(2000);

            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("State")), State);
            WebHandlers.Instance.EnterText(driver.FindElement(SSCCustomerAddressFieldInput("Postal Code")), Postcode);
            BrowserDriver.Sleep(2000);
            SSCPhone.Clear();
            SSCPhone.SendKeys(Phonenumber);
            //WebHandlers.Instance.EnterText(SSCPhone, Phonenumber);
            WebHandlers.Instance.Click(SSCEditCustomerSavebtn);
            BrowserDriver.Sleep(3000);

            driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
            BrowserDriver.Sleep(2000);
        }

        public void AddnewUserphoneinSSC(string countrycode, string phonenumber, string username, string email)
        {
            string countrycode_no = "";

            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabContactDetails.Click();
            BrowserDriver.Sleep(3000);

            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            //ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//*[text()='Dialing Code']/following::td/..//*[@class='sapMComboBoxInner sapMInputBaseInner']"));
            IWebElement dialing_code = driver.FindElement(By.XPath("//*[text()='Dialing Code']/following::input[6]"));
            BrowserDriver.Sleep(3000);
            IWebElement dropdwonarrow = driver.FindElement(By.XPath("//*[text()='Dialing Code']/following::span[contains(@id,'dropdownlistbox')][contains(@id,'arrow')][3]"));

            BrowserDriver.Sleep(2000);

            if (SSCEditCheckBox.Displayed)
            {
                //SSCEditCheckBox.Click();
                SSCProfileDataEditCheckBox.Click();
                BrowserDriver.Sleep(2000);
                //dialing_code.Click();
                //dropdwonarrow.Click();
                BrowserDriver.Sleep(2000);
                //switch (countrycode)
                //{
                //    case ("UK"):
                //        //links[1].SendKeys("GB +44");    
                //        WebHandlers.Instance.ExecuteScript("arguments[0].value = 'GB +44';", dialing_code);
                //        //dialing_code.SendKeys("GB +44");
                //        break;
                //    case ("US"):
                //        //links[1].SendKeys("US +1");
                //        dialing_code.SendKeys("US +1");
                //        break;
                //    case ("China"):
                //        //links[1].SendKeys("CN +86");
                //        dialing_code.SendKeys("CN +86");
                //        break;
                //    case ("Canada"):
                //       // links[1].SendKeys("CA +1");
                //        dialing_code.SendKeys("CA +1");
                //        break;
                //    case ("France"):
                //        //links[1].SendKeys("FR +33");
                //        dialing_code.SendKeys("FR +33");
                //        break;
                //}
                SSCPhonenumberfieldinEditmode.Clear();
                SSCPhonenumberfieldinEditmode.SendKeys(phonenumber);
                SSCSaveButton.Click();

                BrowserDriver.Sleep(3000);
                //IWebElement element = driver.FindElement(By.XPath("//*[text()='Your entries have been saved.']"));
                //Assert.IsTrue(element.Displayed, "Phone Number has not updated on SSC");
                //BrowserDriver.Sleep(3000);

            }
        }
        //TC_59,TC_62
        public void EditUserphoneinSSC(string countrycode, string phonenumber, string username, string email)
        {
            string countrycode_no = "";

            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(5000);
            SSCCustomersSubtabContactDetails.Click();
            BrowserDriver.Sleep(3000);

            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            //ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//*[text()='Dialing Code']/following::td/..//*[@class='sapMComboBoxInner sapMInputBaseInner']"));
            if (SSCEditCheckBox.Displayed)
            {
                //SSCEditCheckBox.Click();
                // Page Scroll down 
                Actions actions = new Actions(driver);
               // actions.SendKeys(OpenQA.Selenium.Keys.PageDown).Build().Perform();
                BrowserDriver.Sleep(3000);
               actions.MoveToElement(SSCProfileDataEditCheckBox);
                BrowserDriver.Sleep(5000);

                //actions.SendKeys(OpenQA.Selenium.Keys.PageUp).Build().Perform();
                actions.MoveToElement(SSCProfileDataEditCheckBox);
                //To Edit Phone Number
                SSCProfileDataEditCheckBox.Click();
                BrowserDriver.Sleep(4000);
                //switch (countrycode)
                //{
                //    case ("UK"):
                //        links[1].SendKeys("GB +44");
                //        break;
                //    case ("US"):
                //        links[1].SendKeys("US +1");
                //        break;
                //    case ("China"):
                //        links[1].SendKeys("CN +86");
                //        break;
                //    case ("Canada"):
                //        links[1].SendKeys("CA +1");
                //        break;
                //    case ("France"):
                //        links[1].SendKeys("FR +33");
                //        break;
                //}
                SSCPhonenumberfieldinEditmode.Clear();
                SSCPhonenumberfieldinEditmode.SendKeys(phonenumber);
                SSCSaveButton.Click();
                BrowserDriver.Sleep(3000);
                //IWebElement element = driver.FindElement(By.XPath("(//span[text()='Your entries have been saved.  '])[2]"));

                //// Assert that the element is displayed
                //Assert.IsTrue(element.Displayed, "Phone Number has not updated on SSC");

            }
        }

        public void DeleteUserphoneinSSC(string username, string email)
        {
            string countrycode_no = "";

            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabContactDetails.Click();
            BrowserDriver.Sleep(3000);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            //ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//*[text()='Dialing Code']/following::td/..//*[@class='sapMComboBoxInner sapMInputBaseInner']"));
            if (SSCProfileDataEditCheckBox.Displayed)
            {
                //SSCEditCheckBox.Click();
                SSCProfileDataEditCheckBox.Click();
                BrowserDriver.Sleep(2000);
                //driver.FindElement(SSCCustomerPhonenumber(phonenumber)).Clear();
                SSCPhonenumberfieldinEditmode.Clear();
                SSCSaveButton.Click();
            }
        }

        public void VerifyUserPhoneinSSC(string countrycode, string phonenumber, string username, string Email)
        {
            string countrycode_no = "";
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabContactDetails.Click();
            BrowserDriver.Sleep(3000);
            switch (countrycode)
            {
                case ("UK"):
                    countrycode_no = "+44";
                    break;
                case ("US"):
                    countrycode_no = "+1";
                    break;
                case ("China"):
                    countrycode_no = "+86";
                    break;
                case ("Canada"):
                    countrycode_no = "+1";
                    break;
                case ("France"):
                    countrycode_no = "+33";
                    break;
            }
            Console.WriteLine("user's phone number ==> " + countrycode_no + " " + phonenumber);
            int phoneno_count = driver.FindElements(SSCCustomersGridData(phonenumber)).Count;
            if (phoneno_count > 0)
            {
                Console.WriteLine("Phone numbers are seen as expected in " + phoneno_count + " places in the screen");
            }
            else
            {
                Assert.Fail("Updated Phone number is not found in the Contact Details screen");
                Console.WriteLine("Updated Phone number is not found in the Contact Details screen");
            }
            BrowserDriver.Sleep(1000);
        }

        public void VerifyPhonenumberDeletedSSC(string username, string Email)
        {
            string phonenumber1 = "";
            string phonenumber2 = "";
            string phonenumber3 = "";
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabContactDetails.Click();
            BrowserDriver.Sleep(3000);
            try
            {
                phonenumber1 = SSCCustomerPhone_Field1.Text;
                phonenumber2 = SSCCustomerPhone_Field2.Text;
                phonenumber3 = SSCCustomerPhone_Field3.Text;
            }
            catch (Exception e) { }
            finally
            {
                if ((phonenumber1.Equals("") || phonenumber1.Equals("-")) && (phonenumber2.Equals("") || phonenumber2.Equals("-")) && (phonenumber3.Equals("") || phonenumber3.Equals("-")))
                {
                    Console.WriteLine("Phone numbers are successfully deleted");
                }
                else
                {
                    Assert.Fail("Phone numbers are not deleted in SSC");
                    // Console.WriteLine("Phone numbers are not deleted in SSC");
                }
            }
        }

        public string VerifyUserPhoneOnSSC(string UserName, string phonenumber, string Email)
        {
            string FullName = UserName + " " + UserName + "Lname";
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
            BrowserDriver.Sleep(2000);
            Assert.IsTrue(driver.FindElement(SSCCustomersGridData("+44 " + phonenumber)).Displayed, phonenumber + " - Expected phone number not showing on the grid");
            //Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
            BrowserDriver.Sleep(1000);
            return WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        }

        public void VerifyDOBupdatedinSSC(string username, string email, string DOB)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(username)).Click();
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabContactDetails.Click();
            BrowserDriver.Sleep(3000);

            //Assert.IsTrue(driver.FindElement(SSCCustomerBDate(DOB)).Displayed, "Customer Birth Date is not displayed as expected");
            Assert.IsTrue(driver.FindElement(SSCUserDOB(DOB)).Displayed, "Customer Birth Date is not displayed as expected");
            
        }

        public void ValidateUserAddressCanBeDeletedFromSSC(string FullName, string Email)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            //Validating address gets deleted

            WebHandlers.Instance.Click(driver.FindElement(SSCNewTicketSubTabs("Contact Details")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomerContactAddressDetails);
            BrowserDriver.Sleep(2000);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(2000);
            //ReadOnlyCollection<IWebElement> rowDeleteButtons = driver.FindElements(By.XPath("//span[text()='Address']//following::td[7]/descendant::span[@title='Remove']"));
            if (SSCEditCheckBox.Displayed)
            {
                SSCEditCheckBox.Click();
                BrowserDriver.Sleep(2000);

                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//input[@checked='checked'][@type='CheckBox']/ancestor::td/..//span[@title='Remove']")), "Clicked on Delete button");
                BrowserDriver.Sleep(3000);
                WebHandlers.Instance.Click(SSCSaveButton, "Clicked On Save after Delete");
                BrowserDriver.Sleep(4000);
                Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='Your entries have been saved.  'and @data-sap-automation-id='messageBar-headerMessage']")).Displayed, "Save message is not displayed");
                Assert.IsTrue(driver.FindElements(SSCCustomerContactAddress).Count == 0, "Address not get deleted from SSC");

            }
        }

        public void ValidateUserAddressGetsSwapedInSSC(string addressType, string FullName, string Email, Dictionary<string, string> PostalAddress)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            //Validating address gets swaped
            try { driver.FindElement(SSCNewTicketSubTabs("Contact Details")).Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", driver.FindElement(SSCNewTicketSubTabs("Contact Details"))); }

            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomerContactAddressDetails);
            BrowserDriver.Sleep(2000);
            if (addressType == "BillingAddress")
            {
                Assert.IsTrue(driver.FindElement(SSCIsBillingAddress("Yes")).Displayed, " Address is not set as Default in SSC");

            }
            else if (addressType == "DefaultContactAddress")
            {
                Assert.IsTrue(driver.FindElement(SSCIsDefaultAddress("Yes")).Displayed, " Address is not set as Default in SSC");
            }
            //Is delivery checking  not in Website FF 
            //else
            //{
            //    Assert.IsTrue(driver.FindElement(SSCIsDeliveryAddress("Yes")).Displayed, " Address is not set as Default in SSC");
            //}



        }

        #endregion
    }
}
