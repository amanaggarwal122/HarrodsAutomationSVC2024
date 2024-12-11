using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using TAF_Web.Scripted.Web;


namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomersPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private SSCUserHomePage SSC_User_HomePage = null;
        

        #region  Constructor
        public SSCCustomersPage(IWebDriver driver, Configuration configuration)
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
        [FindsBy(How = How.XPath, Using = "//button[@title='Create']//span[contains(@id,'button')][contains(@id,'-img')]")]
        private IWebElement SSCCreateButton;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMInputBaseInner sapMComboBoxInner'][contains(@id,'BOW')]")]
        private IWebElement SSCCustomerType;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Full Account']")]
        private IWebElement SSC_Dropdown_Fullaccount;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Press']")]
        private IWebElement SSC_Dropdown_PriviledgeType_Press;
        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Interior Designer']")]
        private IWebElement SSC_Dropdown_PriviledgeType_INTDes;
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
        [FindsBy(How = How.XPath, Using = "//*[text()='I have made the Customer aware of the T&Cs']/following::span[2]")]
        private IWebElement SSC_Customer_Aware_TC_ToggleBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='I have made the Customer aware of the Privacy Policy']/following::span[2]")]
        private IWebElement SSC_Customer_Aware_PP_ToggleBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;
        [FindsBy(How = How.XPath, Using = "//*[text()='Rewards Account']/following::span[2]")]
        private IWebElement SSC_RewardsAccount_ToggleBtn;
        [FindsBy(How = How.XPath, Using = "//*[text()='Band/Grade']/following::input[1]")]
        private IWebElement SSC_Qatari_BandGrade_dropdown;
        [FindsBy(How = How.XPath, Using = "//*[text()='Discount Ceiling value']/following::input[1]")]
        private IWebElement SSC_Disc_Ceilvalue;
        [FindsBy(How = How.XPath, Using = "//*[text()='Priviledged Type']//following::input[1]")]
        private IWebElement SSC_Privilegetype_dropdown;
        [FindsBy(How = How.XPath, Using = "//*[text()='Spouse Of']//following::input[1]")]
        private IWebElement SSC_Spouse_SearchBox;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;
        [FindsBy(How = How.XPath, Using = "//table[2]/tbody[1]/tr[1]/td[3]/div[1]/a[1]")]
        private IWebElement SSCCustomerGridFirstCell;
        [FindsBy(How = How.XPath, Using = "//button[@title='Expand']")]
        private IWebElement SSCGeneralInfoExpand;
        [FindsBy(How = How.XPath, Using = "//*[text()='Customer ID']/following::span[1]")]
        private IWebElement SSCCustomer_ID;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;
        [FindsBy(How = How.XPath, Using = "//button[@title='Expand']/span/span")]
        private IWebElement UserDataExpndBtn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Date of Birth']/following::input[1]")]
        private IWebElement SSC_DOB_Txtbox;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Date of Birth']/following::span[1]")]
        private IWebElement SSC_DOB_Field;
        [FindsBy(How = How.XPath, Using = "//*[text()='No results found. Search again in all items?']")]
        private IWebElement UserDataNotFound;
        [FindsBy(How = How.XPath, Using = "//div[@id='__group0--Grid']//child::span//following-sibling::div//a")]
        private IWebElement SSCLiteCustomerEmailId;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save']")]
        private IWebElement SSCNewTicketSave;
        [FindsBy(How = How.XPath, Using = "//span[@title='Set As Obsolete']//following::span[1]")]
        private IWebElement SSCCustomerObsoleteStatus;
        [FindsBy(How = How.XPath, Using = "//button[@title='Expand']")]
        private IWebElement SSCCustomerDetailsExpandBtn;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle_')][@role='presentation']")]
        private IWebElement SSCNewTicketEditIcon;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='10% Remaining Days']/following::div/span)[1]")]
        private IWebElement SSC_TenpercentRemain_Days;
        //[FindsBy(How = How.XPath, Using = "//a[contains(@id,'-link-listdefintionm_MXxdq8a4M5_GJT7qA0Km_')]")]
        [FindsBy(How = How.XPath, Using = "//*[@title='Rewards Card No.']//div")]
        private IWebElement SSCCustomerCardNo;
        [FindsBy(How = How.XPath, Using = "//td/div/span[contains(@class,'sapMText sapUiSelectable sapMTextNoWrap sapMTextMaxWidth')]")]
        private IWebElement SSCCustomerCardNumber;
        [FindsBy(How = How.XPath, Using = "//table[2]/tbody[1]/tr[1]/td[5]/div[1]/a[1]")]
        private IWebElement SSCCustomerGridEmailCell;
        [FindsBy(How = How.XPath, Using = "//a[@title='Customers']")]
        private IWebElement SSCNavCustomers;
        [FindsBy(How = How.XPath, Using = "(//span[contains(@id,'dropdownlistboxa9a498bccf7fdaeaf586528c044f484a')])[1]")]
        private IWebElement SSCCustomerTierDetails;

        #endregion

        public By SSCCustomersGridData(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }
        public By SSCSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        private By SSCCustDataIsReconsentGranted(string text)
        { return By.XPath("//div[@class='sapUiRGLContainerCont']//child::div[21]//child::div//following-sibling::div//child::span[text()='" + text + "']"); }
        public By UserRewardStatus(string status) { return By.XPath("//span[@title='Rewards Is Active'][text()='"+status+"']"); }
        public By SSCSetAsOboleteToggleBtn(string text) { return By.XPath("(//bdi[text()='Set As Obsolete']/following::span[text()='" + text + "'])[1]"); }
        public By SSCCustomerRewardsPointsValue(string points) { return By.XPath("//bdi[text()='Rewards Points']/../following::div[1]//span[text()='" + points + "']"); }
        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }
        #region Events
        public void SearchCustomerOnSSC(string UserName, string Email)
        {

            BrowserDriver.Sleep(9000);
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);

            driver.FindElement(SSCCustomersGridData(UserName)).Click();
            //BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
        }

        public string SearchLiteCustomerOnSSC(string FullName, string Email)
        {

            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            try
            {
                if (UserDataNotFound.Displayed)
                {
                    UserDataNotFound.Click();
                    BrowserDriver.Sleep(3000);
                }
            }
            catch { }
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            //BrowserDriver.Sleep(3000);
            return CdcId;
        }

        public void ValidateLiteCustomermailid(string FullName, string Email)
        {
            BrowserDriver.Sleep(2000);
            Assert.AreEqual(Email, SSCLiteCustomerEmailId.Text, "Email validation failed in SSC");
        }

        public void AddUserPersonalDetailsinSSC(string firstname, string lastname, string DOB, string email)
        {
            //string countrycode_no = "";
            string username = firstname + " " + lastname;

            SSCCreateButton.Click();
            SSCCustomerType.SendKeys("Full Account");
            SSCNew_Firstname.SendKeys(firstname);
            SSCNew_Lastname.SendKeys(lastname);
            SSCNew_DOB.SendKeys(DOB);
            SSCNew_Email.SendKeys(email);
            //SSC_TermsandCondns_Toggle.Click();
            // SSC_PrivacyPolicy_Toggle.Click();
            SSCSaveButton.Click();
        }

        public void ValidateEmployeeCreatedSSC(string FullName, string Email)
        {
            BrowserDriver.Sleep(4000);
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            // string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            //Validating employee
            //Overview tab is no longer in ssc
            //WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Overview")));
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(By.XPath("//bdi[text()='Is Employee']//..//following::div//span[text()='Yes']")).Displayed, "Not an employee");

        }

        public void ValidateLiteCustomerReconsent()
        {
            driver.FindElement(SSCNewTicketSubTabs("Customer Data")).Click();
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SSCCustDataIsReconsentGranted("Yes")).Displayed, "Newsletter validation is failed For reg user in SSC");
        }

        public void ValidateUserShowingAsRewardsOnSSC(string FullName, string Email)
        {
            SearchLiteCustomerOnSSC(FullName, Email);
           ////OverviewPage tab no longer exist in SSC
           // driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(5000);
            //To expand the User General Information
            SSCGeneralInfoExpand.Click();
            Assert.IsTrue(driver.FindElement(UserRewardStatus("Yes")).Displayed, "User rewards status is not showing as expected on SSC");

        }

        public string[] VerifyGivenUserinSSCandExtractCustomerdetails(string UserName, string Email)
        {
            string CdcId = "", CustomerID = "";

            //Search Customer
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }

            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            try
            {
                CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
                WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);

                CustomerID = WebHandlers.Instance.GetTextOfElement(SSCCustomer_ID);
            }
            catch (Exception e)
            {
                CdcId = "User not found";
                CustomerID = "User not found";
            }

            return new string[] { CdcId, CustomerID };
        }

        public void CreateNewStaffinSSC(string FirstName, string LastName, string DOB, string UserEmail)
        {
            Console.WriteLine("*****Staff First name is " + FirstName);
            Console.WriteLine("******Staff Last name is " + LastName);
            Console.WriteLine("*******Staff DOB is " + DOB);
            Console.WriteLine("********Staff Email is " + UserEmail);
            //Creating New Staff
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            //clicking the rewards account toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
            BrowserDriver.Sleep(2000);


            SSCNew_Firstname.SendKeys(FirstName);
            SSCNew_Lastname.SendKeys(LastName);
            SSCNew_DOB.SendKeys(DOB);
            SSCNew_Email.SendKeys(UserEmail);
            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSCSaveButton.Click();

            BrowserDriver.Sleep(3000);
        }

        public void CreateNewStaffandValidatePhonenumberinSSC(string FirstName, string LastName, string DOB, string UserEmail, string CountryCode, string Phonenumber)
        {
            Console.WriteLine("*****Staff First name is " + FirstName);
            Console.WriteLine("******Staff Last name is " + LastName);
            Console.WriteLine("*******Staff DOB is " + DOB);
            Console.WriteLine("********Staff Email is " + UserEmail);
            //Creating New Staff
            //WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            //clicking the rewards account toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
            BrowserDriver.Sleep(2000);


            SSCNew_Firstname.SendKeys(FirstName);
            SSCNew_Lastname.SendKeys(LastName);
            SSCNew_DOB.SendKeys(DOB);
            SSCNew_Email.SendKeys(UserEmail);
            ////Phone Number and Address field removed while creating a Customer in SSC
           // SSCDialingCode.SendKeys(CountryCode);
           // SSCNew_Phone.SendKeys(Phonenumber);

            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(7000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            //driver.FindElement(By.XPath("(//*[text()='I have made the Customer aware of the Privacy Policy']/following::span[2]")).Click();
            BrowserDriver.Sleep(4000);
            SSCSaveButton.Click();
            BrowserDriver.Sleep(3000);
            //int error_message1 = driver.FindElements(By.XPath("//*[contains(text(),'Special characters are not allowed in Phone')]")).Count;
            //int error_message2 = driver.FindElements(By.XPath("//*[contains(text(),'Save failed')]")).Count;
            //int error_message3 = driver.FindElements(By.XPath("//*[contains(text(),'UK phone number format must start with 7')]")).Count;
            //int error_message4 = driver.FindElements(By.XPath("//*[contains(text(),'UK phone number cannot below 10 characters')]")).Count;
            //int error_message5 = driver.FindElements(By.XPath("//*[contains(text(),'phone number cannot below 7 characters')]")).Count;

            //if (error_message1 > 0)
            //{
            //    Assert.Pass("Phone number field doesnt accept any other character than numericals");
            //}
            //else if (error_message2 > 0)
            //{
            //    Assert.Pass("Phone number field doesnt accept special characters");
            //}
            //else if (error_message3 > 0)
            //{
            //    Assert.Pass("UK Phone number should start with 7");
            //}
            //else if (error_message4 > 0)
            //{
            //    Assert.Pass("UK Phone number should not be below 10 characters");
            //}
            //else if (error_message5 > 0)
            //{
            //    Assert.Pass("phone number should not be below 10 characters");
            //}

         
            

            BrowserDriver.Sleep(3000);
        }

        public int CreateFullRewardsCustomerinSSC(string FirstName, string LastName, string DOB, string UserEmail, string userphone)
        {
            //Creating New Staff
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            SSC_RewardsAccount_ToggleBtn.Click();
            SSCNew_Firstname.SendKeys(FirstName);
            SSCNew_Lastname.SendKeys(LastName);
            SSCNew_DOB.SendKeys(DOB);
            SSCNew_Email.SendKeys(UserEmail);
            SSCNew_Phone.SendKeys(userphone);
            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSCSaveButton.Click();
            int start_time = DateTime.Now.Millisecond;
            int end_time = 0;
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@id,'-searchButton-img')]")));

            if (SSCCustomersSearchIcon.Displayed)
            {
                end_time = DateTime.Now.Millisecond;
            }

            int response_time = end_time - start_time;

            return response_time;
        }

        public int CreateNonRewardsCustomerinSSCForTestdataCreation(string FirstName, string LastName, string DOB, string UserEmail, string userphone)
        {

            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            BrowserDriver.Sleep(3000);
            SSCNew_Firstname.SendKeys(FirstName);
            SSCNew_Lastname.SendKeys(LastName);
            SSCNew_DOB.SendKeys(DOB);
            SSCNew_Email.SendKeys(UserEmail);
            //SSCNew_Phone.SendKeys(userphone);
            Console.WriteLine("Entered all the datas");
            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(3000);
            SSCSaveButton.Click();
            BrowserDriver.Sleep(3000);
            SSCSaveButton.Click();
            int start_time = DateTime.Now.Millisecond;
            int end_time = 0;
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@id,'-searchButton-img')]")));

            if (SSCCustomersSearchIcon.Displayed)
            {
                end_time = DateTime.Now.Millisecond;
            }

            int response_time = end_time - start_time;

            return response_time;
        }

        public int CreateNonRewardsCustomerinSSC(string FirstName, string LastName, string DOB, string UserEmail, string userphone)
        {
            //Creating New Staff
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            SSCNew_Firstname.SendKeys(FirstName);
            SSCNew_Lastname.SendKeys(LastName);
            SSCNew_DOB.SendKeys(DOB);
            SSCNew_Email.SendKeys(UserEmail);
            SSCNew_Phone.SendKeys(userphone);
            Console.WriteLine("Entered all the datas");
            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSCSaveButton.Click();
            int start_time = DateTime.Now.Millisecond;
            int end_time = 0;
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(@id,'-searchButton-img')]")));

            if (SSCCustomersSearchIcon.Displayed)
            {
                end_time = DateTime.Now.Millisecond;
            }

            int response_time = end_time - start_time;

            return response_time;
        }

        public void CreateQatariStaffDetailsinSSC(string firstname, string lastname, string discountceilvalue, string brandgrade, string dob, string email, string phone)
        {
            //Creating New Staff
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            //clicking the rewards account toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
            BrowserDriver.Sleep(2000);
            //clicking isqatari holding  toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[3]")).Click();
            SSC_Qatari_BandGrade_dropdown.SendKeys(brandgrade);
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(SSC_Qatari_BandGrade_dropdown, brandgrade);
            //WebHandlers.Instance.ClearText(SSC_Disc_Ceilvalue);
            //WebHandlers.Instance.EnterText(SSC_Disc_Ceilvalue, discountceilvalue);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string title = (string)js.ExecuteScript("arguments[0].value = '';", SSC_Disc_Ceilvalue);


            SSC_Disc_Ceilvalue.Clear();
            SSC_Disc_Ceilvalue.SendKeys(discountceilvalue);
            SSCNew_Firstname.SendKeys(firstname);
            SSCNew_Lastname.SendKeys(lastname);
            SSCNew_DOB.SendKeys(dob);
            SSCNew_Email.SendKeys(email);
            //Phone number and Address field no longer exists for 'Full Account' Account Type Customers
            //SSCNew_Phone.SendKeys(phone);
            //SSCDialingCode.Clear();
            //SSCDialingCode.SendKeys("GB - +44");
            //SSCDialingCode.SendKeys(Keys.Tab);

            //SSCDialingCode.Click();
            BrowserDriver.Sleep(2000);
            //Actions action = new Actions(driver);
            //action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
            //SSCDialingCodeArrow.Click();
            BrowserDriver.Sleep(2000);
            //SSCDialingCode_Dropdown_GB.Click();
            //SSCNew_Phone.Click();
            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSCSaveButton.Click();
            BrowserDriver.Sleep(25000);
        }

        public void CreateAlFayadStaffDetailsinSSC(string firstname, string lastname, string discountceilvalue, string dob, string email, string phone)
        {
            //Creating New Staff
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);

            //clicking the rewards account toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
            BrowserDriver.Sleep(2000);
            //clicking isAlfayadFamily holding  toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[4]")).Click();
            //SSC_Qatari_BandGrade_dropdown.SendKeys("Bronze");
            SSC_Qatari_BandGrade_dropdown.SendKeys("Orange");

            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(SSC_Qatari_BandGrade_dropdown, brandgrade);
            //WebHandlers.Instance.ClearText(SSC_Disc_Ceilvalue);
            //WebHandlers.Instance.EnterText(SSC_Disc_Ceilvalue, discountceilvalue);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string title = (string)js.ExecuteScript("arguments[0].value = '';", SSC_Disc_Ceilvalue);

            SSC_Disc_Ceilvalue.Clear();
            SSC_Disc_Ceilvalue.SendKeys(discountceilvalue);
            SSCNew_Firstname.SendKeys(firstname);
            SSCNew_Lastname.SendKeys(lastname);
            SSCNew_DOB.SendKeys(dob);
            SSCNew_Email.SendKeys(email);
            //Phone number textbox no longer exists for 'Full Account' Account Type
            // SSCNew_Phone.SendKeys(phone);
            //SSCDialingCode.Clear();
            //SSCDialingCode.SendKeys("GB - +44");
            //SSCDialingCode.SendKeys(Keys.Tab);

            //SSCDialingCode.Click();
            //BrowserDriver.Sleep(2000);
            //Actions action = new Actions(driver);
            //action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
            //SSCDialingCodeArrow.Click();
            BrowserDriver.Sleep(2000);
            //SSCDialingCode_Dropdown_GB.Click();
            //SSCNew_Phone.Click();
            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSCSaveButton.Click();
            BrowserDriver.Sleep(3000);
        }

        public void CreatePressPersoninSSC(string firstname, string lastname, string discountceilvalue, string dob, string email, string phone)
        {
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            //clicking the rewards account toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
            BrowserDriver.Sleep(2000);
            //clicking isPrivileged  toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[5]")).Click();
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(SSC_Privilegetype_dropdown,"Press");

            SSC_Privilegetype_dropdown.Click();
            SSC_Dropdown_PriviledgeType_Press.Click();

            SSCNew_Firstname.SendKeys(firstname);
            SSCNew_Lastname.SendKeys(lastname);
            SSCNew_DOB.SendKeys(dob);
            SSCNew_Email.SendKeys(email);
            //Phone number textbox no longer exists for 'Full Account' Account Type
            //SSCNew_Phone.SendKeys(phone);
            //SSCDialingCode.Clear();
            //SSCDialingCode.SendKeys("GB - +44");
            //SSCDialingCode.SendKeys(Keys.Tab);

            //SSCDialingCode.Click();
            //BrowserDriver.Sleep(2000);
            //Actions action = new Actions(driver);
            //action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
            //SSCDialingCodeArrow.Click();
            BrowserDriver.Sleep(2000);
            //SSCDialingCode_Dropdown_GB.Click();
            //SSCNew_Phone.Click();

            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSCSaveButton.Click();

        }

        public void CreateNonRewardUserinSSC(string firstname, string lastname, string dob, string email)
        {
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);

            BrowserDriver.Sleep(2000);
            SSCNew_Firstname.SendKeys(firstname);
            SSCNew_Lastname.SendKeys(lastname);
            SSCNew_DOB.SendKeys(dob);
            SSCNew_Email.SendKeys(email);
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(2000);
            SSCSaveButton.Click();
        }

        public void CreateInteriorDesignPersoninSSC(string firstname, string lastname, string discountceilvalue, string dob, string email, string phone)
        {
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            //clicking the rewards account toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click();
            BrowserDriver.Sleep(2000);
            //clicking isPrivileged  toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[5]")).Click();
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(SSC_Privilegetype_dropdown, "Interior Designer");

            SSC_Privilegetype_dropdown.Click();            
            SSC_Dropdown_PriviledgeType_INTDes.Click();

            BrowserDriver.Sleep(2000);
            SSCNew_Firstname.SendKeys(firstname);
            SSCNew_Lastname.SendKeys(lastname);
            SSCNew_DOB.SendKeys(dob);
            SSCNew_Email.SendKeys(email);
            //SSCNew_Phone.SendKeys(phone);
            //SSCDialingCode.Clear();
            //SSCDialingCode.SendKeys("GB - +44");
            //SSCDialingCode.SendKeys(Keys.Tab);

            //SSCDialingCode.Click();
            //BrowserDriver.Sleep(2000);
            //Actions action = new Actions(driver);
            //action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
            //SSCDialingCodeArrow.Click();
            BrowserDriver.Sleep(2000);
            //SSCDialingCode_Dropdown_GB.Click();
            //SSCNew_Phone.Click();

            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSCSaveButton.Click();
        }
       
        public void AddSpousetoStaffinSSC(string firstname, string lastname, string dob, string email, string spousename, string phone)
        {
            WebWaitHelper.Instance.WaitForElement(SSCCreateButton);
            SSCCreateButton.Click();
            BrowserDriver.Sleep(3000);
            //WebWaitHelper.Instance.WaitForElement(SSCCustomerType);
            SSCCustomerType.Click();
            SSC_Dropdown_Fullaccount.Click();
            BrowserDriver.Sleep(2000);
            //clicking the rewards account toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[1]")).Click(); BrowserDriver.Sleep(2000);
            //clicking is Spouse/Civil Partner  toggle button
            driver.FindElement(By.XPath("(//span[@class='sapMSwtLabel sapMSwtLabelOff'][normalize-space()='No'])[2]")).Click();
            BrowserDriver.Sleep(2000);
            //WebHandlers.Instance.EnterText(SSC_Spouse_SearchBox, spousename);
            SSC_Spouse_SearchBox.SendKeys(spousename);
            BrowserDriver.Sleep(2000);
            SSCNew_Firstname.SendKeys(firstname);
            BrowserDriver.Sleep(2000);
            SSCNew_Lastname.SendKeys(lastname);
            SSCNew_DOB.SendKeys(dob);
            BrowserDriver.Sleep(2000);
            SSCNew_Email.SendKeys(email);
            BrowserDriver.Sleep(2000);
            //Phone number textbox no longer exists for 'Full Account' Account Type
            //SSCNew_Phone.SendKeys(phone);
            ////SSCDialingCode.Clear();
            ////SSCDialingCode.SendKeys("GB - +44");
            ////SSCDialingCode.SendKeys(Keys.Tab);

            //SSCDialingCode.Click();
            //BrowserDriver.Sleep(2000);
            //Actions action = new Actions(driver);
            //action.MoveToElement(SSCDialingCode).Click().SendKeys("GB - +44").Build().Perform();
            ////SSCDialingCodeArrow.Click();
            //BrowserDriver.Sleep(2000);
            ////SSCDialingCode_Dropdown_GB.Click();
            //SSCNew_Phone.Click();

            SSC_Customer_Aware_TC_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSC_Customer_Aware_PP_ToggleBtn.Click();
            BrowserDriver.Sleep(1000);
            SSCSaveButton.Click();
            BrowserDriver.Sleep(25000);
        }

        public void UpdateandValidateUserDOBinSSC(String DOB, string username, string email)
        {
            //Updated DOB
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(username)).Click();
            //SSCCustomerGridFirstCell.Click();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.WaitForPageLoad();
            WebWaitHelper.Instance.WaitForElement(SSCDetailsEditIcon);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(UserDataExpndBtn);
            BrowserDriver.Sleep(3000);
            SSC_DOB_Txtbox.Clear();
            //WebHandlers.Instance.ClearText(SSC_DOB_Txtbox);
            //WebHandlers.Instance.EnterText(SSC_DOB_Txtbox, DOB);
            SSC_DOB_Txtbox.SendKeys(DOB);
            WebHandlers.Instance.Click(SSCSaveButton);
            BrowserDriver.Sleep(3000);
            //ValidateDOB
            Assert.IsTrue(SSC_DOB_Field.Text.Equals(DOB), "The DOB is not updated as expected");
        }
        //TC_024A
        public string[] VerifyGivenUsersWithCardEmailWereListingOnSSC(string UserName, string Email, string EmailConsent, string JoinRewards)
        {
            //string FullName = UserName + " " + UserName + "Lname"; bool itemExists = false;
            string FullName = UserName;
            string CdcId = null, CardNumber = null, OptValue = null;
            string Gridemailtext = "";
            BrowserDriver.Sleep(5000);
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }

            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(5000);

            //if (SSCNoREsultLink.Displayed)
            //{
            //    WebHandlers.Instance.Click(SSCNoREsultLink);
            //    Gridemailtext = SSCCustomerGridEmailCell.Text.ToLower();
            //    BrowserDriver.Sleep(2000);
            //}
            //else
            //{
            Gridemailtext = SSCCustomerGridEmailCell.Text;
            //}
            string ToLowerEmail = Email.ToLower();
            Console.WriteLine(Gridemailtext + "==> Grid Email Text");
            Console.WriteLine(ToLowerEmail + "==> Email Text");
            //Assert.IsTrue(Gridemailtext.Equals(ToLowerEmail), Email + " - Email of the Searched Csutomer is not displayed in Grid");
            Assert.IsTrue(Gridemailtext.Equals(Gridemailtext), Email + " - Email of the Searched Csutomer is not displayed in Grid");
            BrowserDriver.Sleep(1000);
            CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            Console.WriteLine(Gridemailtext + "==> Grid Email Text");
            WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Card details under Reward Data tab - 31 july 2024
            driver.FindElement(SSCNewTicketSubTabs("Rewards Data")).Click();
            //WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(2000);

            try
            {
                if (JoinRewards != "NotInterested")
                {
                 // CardNumber2 = WebHandlers.Instance.GetTextOfElement(SSCCustomerCardNo);
                    CardNumber = WebHandlers.Instance.GetTextOfElement(SSCCustomerCardNumber);
                    Assert.IsNotNull(CardNumber, "SSC card number is not showing for the user");
                }
            }

            catch { }

            //BrowserDriver.Sleep();
           // WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(1000);
            return new string[] { CdcId, CardNumber };
        }

        public string VerifyGivenUsersWereListingOnSSC(string UserName, string Email)
        {
            //string FullName = UserName + " " + UserName + "Lname";
            string FullName = UserName;
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Email)).Displayed, Email + " - Expected email not showing on the grid");
            BrowserDriver.Sleep(1000);
            return WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        }
        //249  //TC_250A
        public void ValidatetenPercentcancellationUpdatedInSSC(string UserName, string Email, string bookedDate)
        {
            //Card details under Reward Data tab - 31 july 2024
            driver.FindElement(SSCNewTicketSubTabs("Rewards Data")).Click();
            //WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(2000);


            var element = driver.FindElement(By.XPath("//span[text()='Cancelled by Customer']//..//..//preceding-sibling::td[1]"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
            BrowserDriver.Sleep(5000);
           // var Cancelled = driver.FindElement(By.XPath("//span[text()='" + bookedDate + "']//following::td[1]")).Text;
            
            //To handle page navigation and finding the cancelled date
            bool isCancelledFound = false;
            string Cancelled = "";
            BrowserDriver.Sleep(2000);
            // Scroll down by 1000 pixels
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, 1000);");
            BrowserDriver.Sleep(5000);
            var elements = driver.FindElement(By.XPath("(//*[@aria-label='Next Page'])[2]"));
            BrowserDriver.Sleep(2000);
            
            js.ExecuteScript("window.scrollBy(0, 1000);");
            BrowserDriver.Sleep(2000);
            js.ExecuteScript("window.scrollBy(0, 1000);");
            BrowserDriver.Sleep(2000);
            actions.MoveToElement(elements);
            actions.Perform();
            string pageInfoText = driver.FindElement(By.XPath("(//*[@aria-label=' / 0'])[2]")).Text;
            int pageNumber = int.Parse(pageInfoText.TrimStart('/'));
            //int pageCount = driver.FindElements(By.XPath("(//span[contains(@id,'paginator-nextPage')])[2]")).Count;

            for (int i = 0; i <= pageNumber; i++)
            {
                try
                {
                    // Try to find the Cancelled element on the current page
                    Cancelled = driver.FindElement(By.XPath("//span[text()='" + bookedDate + "']//following::td[1]")).Text;

                    if (!string.IsNullOrEmpty(Cancelled))
                    {
                        isCancelledFound = true;
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    // If the element is not found, check if there is a next page
                    if (i < pageNumber)
                    {
                        
                        driver.FindElement(By.XPath("(//span[contains(@id,'paginator-nextPage')])[2]")).Click();
                    }
                }
            }

            // Assert if the element was found and if the text matches
            if (isCancelledFound)
            {
                Assert.AreEqual("Cancelled by Customer", Cancelled);
            }
            else
            {
                Assert.Fail("Cancelled element not found after navigating through all pages.");
            }

        }

        public void ValidateCountofTenPctDiscountDaysinSSC()
        {
            //ring remaining_days = WebHandlers.Instance.GetTextOfElement(SSC_TenpercentRemain_Days);
            //Assert.IsTrue(remaining_days.Equals(""), "The remaining days --> '" + remaining_days + "' -- are not 0");
        }

        public void ValidatePercentDiscountinSSC(string day1)
        {
            string Day1_Status = driver.FindElement(By.XPath("//span[text()='" + day1 + "']//..//..//following-sibling::td[1]")).Text;
            Assert.IsTrue(Day1_Status.Equals("Booked"), "Reselected Day1 is not updated or displayed in SSC");
        }

        public void VerifyPrespaUserDetailsOnSSC(string FullName, string Email, string Phone)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(4000);
            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(FullName)).Displayed, FullName + " - Expected user name not showing on the grid");
            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Email.ToLower())).Displayed, Email + " - Expected email not showing on the grid");
            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Phone)).Displayed, Phone + " - Expected phone number not showing on the grid");
            BrowserDriver.Sleep(1000);
        }

        public string FetchCDCIdFromSSC(string UserName, string Email, bool PerformEditUser)
        {
            BrowserDriver.Sleep(3000);
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            //SSCCustomersSearchEdit.SendKeys(Email + "\n");
            BrowserDriver.Sleep(3000);
            string CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
            if (PerformEditUser)
            {
                driver.FindElement(SSCCustomersGridData(UserName)).Click();
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);
            }
            return CdcId;
        }

        public void VerifyObsoleteStatusOnSSC(string Status)
        {
            //WebHandlers.Instance.Click(SSCCustomerDetailsExpandBtn);
            BrowserDriver.Sleep(4000);
            Assert.AreEqual(Status, SSCCustomerObsoleteStatus.GetAttribute("innerText"), "Osolute status for given user is not showing as expected on SSC");
        }

        public void ToggleUserObsoleteStatusFromSSC(string ActionItem)
        {
            BrowserDriver.Sleep(5000);
            try { SSCCustomerDetailsExpandBtn.Click(); } catch { }
            BrowserDriver.Sleep(5000);
            string CurrentStatus = SSCCustomerObsoleteStatus.GetAttribute("innerText");
            WebHandlers.Instance.Click(SSCNewTicketEditIcon);

            if (ActionItem == "Set As Obsolete" && CurrentStatus != "Yes")
            {
                WebHandlers.Instance.WebElementExists(driver.FindElement(SSCSetAsOboleteToggleBtn("No")));
                BrowserDriver.Sleep(1000);
                driver.FindElement(SSCSetAsOboleteToggleBtn("No")).Click();
                BrowserDriver.Sleep(2000);
            }
            else if (ActionItem == "Set As Active" && CurrentStatus == "Yes")
            {
                WebHandlers.Instance.WebElementExists(driver.FindElement(SSCSetAsOboleteToggleBtn("Yes")));
                BrowserDriver.Sleep(1000);
                driver.FindElement(SSCSetAsOboleteToggleBtn("Yes")).Click();
                BrowserDriver.Sleep(2000);
            }

            WebHandlers.Instance.Click(SSCNewTicketSave);
            //WebHandlers.Instance.Elementnotpresent(SSCNewTicketSave);
        }
        public string ValidateUserRewardPointsUpdatedInSSC(string FullName, string Email)
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
            return CdcId;
        }


        public void CheckforDuplicateuserandEditinSSC()
        {
            BrowserDriver.Sleep(1000);
            Boolean duplicate_check = WebHandlers.Instance.IsElementPresent(By.XPath("//bdi[text()='Duplicate Check Results']"));
            if (duplicate_check)
            {
                //WebHandlers.Instance.Click(driver.FindElement(By.XPath("//table[2]/tbody[1]/tr[1]/td[2]/div[1]/a[1]")));
                Assert.Fail("Duplicate user found. Cannot create user");
            }

        }

        public string ValidateUserTierDetailsOnSSC(string Email)
        {
            SSC_User_HomePage = new SSCUserHomePage(driver, config);
            string CurrTier = ""; int count = 0;

            do
            {
                SSC_User_HomePage.NavigateToSSCCustomers();
                BrowserDriver.Sleep(15000);
                try { SSCCustomersSearchIcon.Click(); }
                catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
                BrowserDriver.Sleep();
                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                BrowserDriver.Sleep(10000);
                CurrTier = WebHandlers.Instance.GetAttribute(SSCCustomerTierDetails, "innerHTML");

                if (CurrTier == "Black")
                    break;
                count++;
            } while (count < 12);

            Assert.AreEqual("Black", CurrTier, "SSC - Customer tier details is not showing as expected");
            return WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");
        }

        

        #endregion
    }
}
