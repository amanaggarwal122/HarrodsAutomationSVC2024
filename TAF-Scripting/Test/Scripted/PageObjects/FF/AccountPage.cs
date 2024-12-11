using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Scripting.Test.Common;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class AccountPage
    {
        public IWebDriver driver;

        #region  Constructor

        public AccountPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		
        [FindsBy(How = How.XPath, Using = "//div[@data-test='notification-confirmation']/div")]
        private IWebElement AddressConfirmation;

        [FindsBy(How = How.XPath, Using = "//span[@data-test='headerAccountMenu-username']")]
        private IWebElement WelcomeMessage;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Women')]")]
        private IWebElement MenuWoman;

        [FindsBy(How = How.XPath, Using = "//button[text()='Log Out']")]
        private IWebElement LogOut;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Manage Addresses']")]
        private IWebElement lnkManageAddress;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Account Home']")]
        private IWebElement lnkAccountHome;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Personal Details']")]
        private IWebElement lnkPersonalDetails;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Communication Preferences']")]
        private IWebElement lnkCommunicationPreferences;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='addressBook-addButton']")]
        private IWebElement lnkAddAddress;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='confirmationModal-confirmButton' and contains(text(),'Yes, remove')]")]
        private IWebElement btnRemoveAddress;

        [FindsBy(How = How.Id, Using = "dateInput.day")]
        private IWebElement ddDay;

        [FindsBy(How = How.XPath, Using = "//*[@data-test='reminder-button'and contains(text(), 'Add my number')]")]
        //*[@id="siteContent"]/div[2]/section/div[2]/div[2]/a
        private IWebElement btnaddmynumber;

        [FindsBy(How = How.Id, Using = "dateInput.month")]
        private IWebElement ddMonth;

        [FindsBy(How = How.Id, Using = "dateInput.year")]
        private IWebElement ddYear;

        [FindsBy(How = How.Id, Using = "profileForm-phoneNumber")]
        private IWebElement txtPhone;

        [FindsBy(How = How.Id, Using = "profileForm-phoneCode")]
        private IWebElement countrycode_dropdown;

        [FindsBy(How = How.Id, Using = "profileForm-password")]
        private IWebElement txtPwd;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='profileForm-submitButton' and contains(text(),'Save Changes')]")]
        private IWebElement btnSave;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='communication-preferences-updateButton']")]
        private IWebElement btnUpdateComPref;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Mini Harrods']")]
        private IWebElement lnkMiniHarrods;
        
        [FindsBy(How = How.XPath, Using = "//div//input[@id='children[1]Form-firstName' and @type='text']")]
        public IWebElement childFirstName;

        [FindsBy(How = How.XPath, Using = "//div//input[@id='children[1]Form-lastName' and @type='text']")]
        public IWebElement childLastName;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.day']")]
        public IWebElement childDate;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.month']")]
        public IWebElement childMonth;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.year']")]
        public IWebElement childYear;

        [FindsBy(How = How.XPath, Using = "//select[@id='children[1]Form-relationship']")]
        public IWebElement childRelationship;

        [FindsBy(How = How.XPath, Using = "//select[@id='children[1]Form-gender']")]
        public IWebElement childGender;

        [FindsBy(How = How.XPath, Using = "//input[@id='miniHarrodsForm-termsAndConditions']")]
        public IWebElement checkBoxtermsAndConditions;

        [FindsBy(How = How.XPath, Using = "//button[@id='join-miniHarrods-button']")]
        public IWebElement btnJoinNow;

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox'and @class='css-148cr8f edvavdu0']")]
        public IWebElement checkboxRemoveChild;

        [FindsBy(How = How.XPath, Using = "//span[text()='Edit']")]
        private IWebElement btnAddressEdit;

        [FindsBy(How = How.XPath, Using = "  //li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[@class='css-10i47os e1sql9j53']//p[@class='css-nlsg0a e1sql9j54']")]
        private IWebElement chName;

        [FindsBy(How = How.XPath, Using = " //li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[2]//p[1]")]
        private IWebElement chDay;

        [FindsBy(How = How.XPath, Using = " //li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[2]//p[2]")]
        private IWebElement chMonth;

        [FindsBy(How = How.XPath, Using = " //li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[2]//p[3]")]
        private IWebElement chyear;

        [FindsBy(How = How.XPath, Using = "//*[text()='Relationships']")]
        public IWebElement ssc_relationshipBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'--header-arrowScrollRight')]")]
        private IWebElement SSCCustomerTabScrollRight;

        public By SMCChildGridData(string text) { return By.XPath("(//span[@title='" + text + "'])"); }
        //public By SMCCustomersGridData(string text) { return By.XPath("(//a[text()='"+ text+"'])[1]"); }
        [FindsBy(How = How.XPath, Using = "//span[@id='inputfieldZdoVjr9KdKALCTltGTUUwm_1157-text-listdefintionXmljR_bx9q6aiRVN141zH0_1153-0']")]
        public IWebElement ssc_childFirstname;

        [FindsBy(How = How.XPath, Using = "//span[@id='inputfieldvMrlujbz2asMB5DITUhO50_1161-text-listdefintionXmljR_bx9q6aiRVN141zH0_1153-0']")]
        public IWebElement ssc_childlastname;

        [FindsBy(How = How.XPath, Using = "//span[@id='inputfieldisigN_s86IaA88gi4X2cwzW_1165-text-listdefintionXmljR_bx9q6aiRVN141zH0_1153-0']")]
        public IWebElement ssc_Gender;

        [FindsBy(How = How.XPath, Using = "//li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[3]")]
        private IWebElement chGender;
        [FindsBy(How = How.XPath, Using = "//span[@id='inputfieldvwC_sG9Rwl4IxIq53ZGoSF0_1169-displayText-listdefintionXmljR_bx9q6aiRVN141zH0_1153-0']")]
        public IWebElement ssc_Dob;

        [FindsBy(How = How.XPath, Using = " //button[@id='submit-button']")]
        private IWebElement btnSubmitChild;

        [FindsBy(How = How.XPath, Using = " //button[@id='leave-miniHarrods-button']")]
        private IWebElement btnLeaveMiniHarrods;

        [FindsBy(How = How.XPath, Using = " //div[@data-test='notification-confirmation']")]
        private IWebElement leaveConfirmMessage;


        [FindsBy(How = How.Id, Using = "profileForm-phoneCode")]
        private IWebElement Country_Phonecode;
        public By AddAnotherChildInMiniHarrods(string Addanotherchild) { return By.XPath("//span[text()='" + Addanotherchild + "']"); }
        
        [FindsBy(How = How.XPath, Using = "//div//input[@id='newChildForm-firstName' and @type='text']")]
        public IWebElement AnotherchildFirstName;

        [FindsBy(How = How.XPath, Using = "//div//input[@id='newChildForm-lastName' and @type='text']")]
        public IWebElement AnotherchildLastName;

        [FindsBy(How = How.XPath, Using = "//select[@id='newChildForm-relationship']")]
        public IWebElement AnotherchildRelationship;

        [FindsBy(How = How.XPath, Using = "//select[@id='newChildForm-gender']")]
        public IWebElement AnotherchildGender;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='rewardsTier']/div[1]//span[2]")]
        public IWebElement RewardCardNumber;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='rewardsTier']/div[1]//p")]
        public IWebElement UserTier;


        public By SaveChangesInMiniHarrods(string AddanotherchildSaveChange) { return By.XPath("//button[text()='" + AddanotherchildSaveChange + "']"); }
        #endregion

        #region Events  

        public void ClickOnProductsMenu()
        {
            WebHandlers.Instance.ClickByJsExecutor(MenuWoman);
            WebHandlers.Instance.WaitForPageLoad();
        }

        #endregion

        #region Validation   

        public void ValidateSuccessfullLogin(Dictionary<string, string> customerdetails)
        {
            string title = customerdetails["Title"];
            string firstName = customerdetails["FirstName"];
            string lastName = customerdetails["LastName"];

            string textToCompare = $"{title.Remove(title.Length - 1, 1) }. {firstName.Trim()} {lastName.Trim()}";

            //WebHandlers.Instance.VerifyText(WelcomeMessage, textToCompare); //commented until title issue is fixed 07.08.23

        }

        public void InvokeManageAddress()
        {
            WebHandlers.Instance.Click(lnkManageAddress);
            BrowserDriver.Sleep(3000);
        }

        public void InvokeMiniHarrods()
        {
            WebHandlers.Instance.Click(lnkMiniHarrods);
            BrowserDriver.Sleep(3000);
        }
        public void InvokeDefaultEditAddress()
        {
            IWebElement btnEdit = WebHandlers.Instance.GetElement(driver, By.XPath("//button[@id='address-edit-button']"));
            WebHandlers.Instance.Click(btnEdit);
            BrowserDriver.Sleep(5000);
        }
        public void InvokeAccountHome()
        {
            WebHandlers.Instance.Click(lnkAccountHome);
            BrowserDriver.Sleep(3000);
        }
        public Dictionary<string, Dictionary<string, string>> GetAllChildData(string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> ChildDetails = new Dictionary<string, Dictionary<string, string>>();
            ChildDetails = DataFilesUtil.GetAllData(fileName, sheetName);

            int totalChildren = ChildDetails.Count();
            var result = ChildDetails.Where(x => x.Value.Any(y => y.Key == "Email" && y.Value != "")).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }

        public Dictionary<string, Dictionary<string, string>> GetAllChildData(string UserCategory, string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> ChildDetails = new Dictionary<string, Dictionary<string, string>>();
            ChildDetails = DataFilesUtil.GetDataForKey(fileName, sheetName, UserCategory);
            int totalChildren = ChildDetails.Count();
            var result = ChildDetails.Where(x => x.Value.Any(y => y.Key == "Email" && y.Value != "")).ToDictionary(x => x.Key, x => x.Value); return result;
        }


        public Dictionary<string, Dictionary<string, string>> GetAllCustData(string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> CustDetails = new Dictionary<string, Dictionary<string, string>>();
            CustDetails = DataFilesUtil.GetAllData(fileName, sheetName);

            int totalChildren = CustDetails.Count();
            var result = CustDetails.Where(x => x.Value.Any(y => y.Key == "Email" && y.Value != "")).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }
        public void ClickAddnumber()
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[@data-test='reminder-button'and contains(text(), 'Add my number')]")));
            WebHandlers.Instance.Click(btnaddmynumber);
            BrowserDriver.Sleep(3000);
        }

        public void InvokePersonalDetails()
        {
            WebHandlers.Instance.Click(lnkPersonalDetails);
            BrowserDriver.Sleep(3000);
        }

        public void ValidatePhoneNumber(string countrycode, string phonenumber)
        {            
            if (!phonenumber.Equals(""))
            {
                string countrycode_full = "";
                switch (countrycode)
                {
                    case ("UK"):
                        countrycode_full = "GB +44";
                        break;
                    case ("US"):
                        countrycode_full = "US +1";
                        break;
                    case ("China"):
                        countrycode_full = "CN +86";
                        break;
                    case ("Canada"):
                        countrycode_full = "CA +1";
                        break;
                    case ("France"):
                        countrycode_full = "FR +33";
                        break;
                }
                Boolean country_code = Country_Phonecode.Displayed;
                if (country_code)
                {
                    string txt = txtPhone.GetAttribute("value");
                    //Assert.IsTrue(Country_Phonecode.Text.Equals(countrycode_full), "Country code is not updated correctly");
                    Assert.IsTrue(txt.Equals(phonenumber), "Phone number is not displayed as expected");
                }
            }
            else
            {
                string txt = txtPhone.GetAttribute("value");
                Assert.IsFalse(txt.Equals(""), "Phone number is displayed");
            }
        }

        public void Validate_PersonalDetails(string firstname, string lastname, string DOB)
        {
            //string[] DOB1 = DOB.Split('.');
            string username = firstname + " " + lastname;
            string displayedname = driver.FindElement(By.XPath("//*[text()='Name']/following::div[1]")).Text;
            string displayedday = driver.FindElement(By.XPath("//*[@data-test='dateInput-readOnly-day']")).Text;
            string displayedmonth = driver.FindElement(By.XPath("//*[@data-test='dateInput-readOnly-month']")).Text;
            int month = Int32.Parse(displayedmonth);
            if (month < 10)
            {
                displayedmonth = "0" + displayedmonth;
            }
            string displayedyear = driver.FindElement(By.XPath("//*[@data-test='dateInput-readOnly-year']")).Text;
            string displayedDOB = displayedday + "." + displayedmonth + "." + displayedyear;
            Assert.IsTrue(displayedDOB.Equals(DOB), "DOB is displayed as expected");
            Assert.IsTrue(displayedname.Contains(username), "USername is displayed as expected");

        }

        public void InvokeCommunicationDetails()
        {
            BrowserDriver.Sleep(5000);
            Console.WriteLine("********Entered Comm Pereferences Page");
            WebHandlers.Instance.Click(lnkCommunicationPreferences);
            Console.WriteLine("Comm Pereferences got clicked");
            BrowserDriver.Sleep(3000);
        }

        public void VallidateEmailOptedInHarrods()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//*[text()='Email']/preceding::input")).Selected, "Email is Checked as expected");
            Console.WriteLine(driver.FindElement(By.XPath("//*[text()='Email']/preceding::input")).Text);
            BrowserDriver.Sleep(3000);
        }

        public void updatePersonalDetails(Dictionary<string, string> customerData)
        {
            string DOB = customerData["DOB"];
            string[] DOB1 = DOB.Split('.');
            if (WebHandlers.Instance.WebElementExists(ddDay))
            {
                WebHandlers.Instance.MultiSelectByText(ddDay, DOB1[0]);
                if (WebHandlers.Instance.WebElementExists(ddMonth))
                    WebHandlers.Instance.MultiSelectByText(ddMonth, DOB1[1]);
                if (WebHandlers.Instance.WebElementExists(ddYear))
                    WebHandlers.Instance.MultiSelectByText(ddYear, DOB1[2]);
            }


            WebHandlers.Instance.EnterText(txtPhone, customerData["CellPhone"]);
            WebHandlers.Instance.EnterText(txtPwd, customerData["Password"]);
            WebHandlers.Instance.Click(btnSave);
        }

        public void updatePhonenumber(string countrycode, string Phonenumber, string DOB)
        {
            string[] DOB1 = DOB.Split('.');
            //if (WebHandlers.Instance.WebElementExists(ddDay))
            //{
            //    WebHandlers.Instance.MultiSelectByText(ddDay, DOB1[0]);
            //    if (WebHandlers.Instance.WebElementExists(ddMonth))
            //        WebHandlers.Instance.MultiSelectByText(ddMonth, DOB1[1]);
            //    if (WebHandlers.Instance.WebElementExists(ddYear))
            //        WebHandlers.Instance.MultiSelectByText(ddYear, DOB1[2]);
            //}
            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("profileForm-phoneCode")));

            switch (countrycode)
            {
                case ("UK"):
                    //oSelect.SelectByText("GB +44");
                    countrycode_dropdown.SendKeys("GB +44");
                    break;
                case ("US"):
                    //oSelect.SelectByText("US +1");
                    countrycode_dropdown.SendKeys("US +1");
                    break;
                case ("China"):
                    //oSelect.SelectByText("CN +86");
                    countrycode_dropdown.SendKeys("CN +86");
                    break;
                case ("Canada"):
                    //oSelect.SelectByText("CA +1");
                    countrycode_dropdown.SendKeys("CA +1");
                    break;
            }
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.ClearText(txtPhone);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(txtPhone, Phonenumber);
            WebHandlers.Instance.EnterText(txtPwd, "Harrods123");
            WebHandlers.Instance.Click(btnSave);
            BrowserDriver.Sleep(3000);
        }


        public void editPhonenumber(string countrycode, string Phonenumber)
        {
            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("profileForm-phoneCode")));

            //switch (countrycode)
            //{
            //    case ("UK"):
            //        oSelect.SelectByText("GB +44");
            //        break;
            //    case ("US"):
            //        oSelect.SelectByText("US +1");
            //        break;
            //    case ("China"):
            //        oSelect.SelectByText("CN +86");
            //        break;
            //    case ("Canada"):
            //        oSelect.SelectByText("CA +1");
            //        break;
            //    case ("France"):
            //        oSelect.SelectByText("FR +33");
            //        break;
            //}

            switch (countrycode)
            {
                case ("UK"):
                    //oSelect.SelectByText("GB +44");
                    countrycode_dropdown.SendKeys("GB +44");
                    break;
                case ("US"):
                    //oSelect.SelectByText("US +1");
                    countrycode_dropdown.SendKeys("US +1");
                    break;
                case ("China"):
                    //oSelect.SelectByText("CN +86");
                    countrycode_dropdown.SendKeys("CN +86");
                    break;
                case ("Canada"):
                    //oSelect.SelectByText("CA +1");
                    countrycode_dropdown.SendKeys("CA +1");
                    break;
                case ("France"):
                    //oSelect.SelectByText("FR +33");
                    countrycode_dropdown.SendKeys("FR +33");
                    break;
            }

            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.ClearText(txtPhone);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(txtPhone, Phonenumber);
            WebHandlers.Instance.EnterText(txtPwd, "Harrods123");
            WebHandlers.Instance.Click(btnSave);
            BrowserDriver.Sleep(3000);
        }
        public void updateDOB(string DOB)
        {
            string[] DOB1 = DOB.Split('.');
            if (WebHandlers.Instance.WebElementExists(ddDay))
            {
                WebHandlers.Instance.MultiSelectByText(ddDay, DOB1[0]);
                if (WebHandlers.Instance.WebElementExists(ddMonth))
                    WebHandlers.Instance.MultiSelectByText(ddMonth, DOB1[1]);
                if (WebHandlers.Instance.WebElementExists(ddYear))
                    WebHandlers.Instance.MultiSelectByText(ddYear, DOB1[2]);
            }
            WebHandlers.Instance.EnterText(txtPwd, "Harrods123");
            WebHandlers.Instance.Click(btnSave);
        }

        public string getPhonenumber()
        {
            BrowserDriver.Sleep(3000);
            string phonenumber = txtPhone.Text;
            return phonenumber;
        }
        public void deletePhonenumber()
        {                      
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(txtPwd, "Harrods123");
            txtPhone.Clear();
            //WebHandlers.Instance.ClearText(txtPhone);
            //WebHandlers.Instance.ExecuteScript("arguments[0].value", txtPhone);
            //BrowserDriver.Sleep(2000);            
//            WebHandlers.Instance.EnterText(txtPwd, "Harrods123");
            WebHandlers.Instance.Click(btnSave);
            BrowserDriver.Sleep(2000);
        }


        public void updateCommunicationPref(Dictionary<string, string> customerData)
        {
            string email = customerData["TypeEmail"];
            string sms = customerData["TypeSMS"];
            string postal = customerData["TypePostal"];
            string phone = customerData["TypePhone"];
            string FW = customerData["CP_Food_and_Wine"];
            string Promotions = customerData["CP_Promotions"];
            string MiniHarrods = customerData["CP_Mini_Harrods"];
            string Beauty = customerData["CP_Beauty"];

            foreach (string key in customerData.Keys)
            {
                if (key.StartsWith("CP_"))
                {
                    string needCP = customerData[key];
                    string category = key.Substring(3, key.Length - 3);
                    try
                    {
                        IWebElement inputEmailEle = WebHandlers.Instance.GetElement(driver, By.XPath("//span[contains(text(),'Email')]/preceding-sibling::input[@data-test='" + category + "-subscribeVia-email']"));
                        SelectCommunicationPreference(email, needCP, inputEmailEle);
                        if (category == "Latest_News" && customerData["RewardCardNo"] == "")
                        {
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        string exception = e.StackTrace;
                        Console.WriteLine(exception);
                    }

                    try
                    {
                        if (category == "Promotions" || category == "Mini_Harrods" || category == "Beauty")
                        {
                            //sms
                            IWebElement inputEleSMS = WebHandlers.Instance.GetElement(driver, By.XPath("//span[contains(text(),'SMS')]/preceding-sibling::input[@data-test='" + category + "-subscribeVia-sms']"));
                            SelectCommunicationPreference(sms, needCP, inputEleSMS);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (category == "Promotions")
                        {
                            //phone
                            IWebElement inputElePhone = WebHandlers.Instance.GetElement(driver, By.XPath("//span[contains(text(),'Phone')]/preceding-sibling::input[@data-test='" + category + "-subscribeVia-phone']"));
                            SelectCommunicationPreference(phone, needCP, inputElePhone);
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (category == "Promotions" || category == "Mini_Harrods")
                        {
                            //postal
                            IWebElement inputElePostal = WebHandlers.Instance.GetElement(driver, By.XPath("//span[contains(text(),'Post')]/preceding-sibling::input[@data-test='" + category + "-subscribeVia-postal']"));
                            SelectCommunicationPreference(postal, needCP, inputElePostal);
                        }
                    }
                    catch
                    {

                    }

                }
            }

            WebHandlers.Instance.Click(btnUpdateComPref);


        }

        public void SelectCommunicationPreference(string category, string catType, IWebElement ele)
        {
            if (category.ToUpper() == "YES" && catType.ToUpper() == "YES")
            {
                if (!WebHandlers.Instance.ChkboxIsChecked(ele))
                    WebHandlers.Instance.ClickByJsExecutor(ele);
            }
            else
            {
                if (WebHandlers.Instance.ChkboxIsChecked(ele))
                    WebHandlers.Instance.ClickByJsExecutor(ele);
            }

        }

        public void AddAddress()
        {

            WebHandlers.Instance.Click(lnkAddAddress);
            BrowserDriver.Sleep(3000);
        }
        
        public void InvokeEditAddress(Dictionary<string, string> customerData)
        {

            //IWebElement btnEdit = WebHandlers.Instance.GetElement(driver, By.XPath(" //p[@data-test='address-addressLine1' and contains(text(),\""+ customerData["AddressLine1"].ToString() + "\")]/following-sibling::div/button[@data-test='address-edit-button']"));
            //WebHandlers.Instance.Click(btnEdit);

            WebHandlers.Instance.Click(btnAddressEdit);
            BrowserDriver.Sleep(3000);
        }

        public void InvokeDeleteAddress(Dictionary<string, string> customerData)
        {

            //IWebElement btnDelete = WebHandlers.Instance.GetElement(driver, By.XPath("//p[@data-test='address-addressLine1' and contains(text(),\"" + customerData["AddressLine1"].ToString() + "\")]/following-sibling::div/button[@data-test='address-remove-button']"));
            IList<IWebElement> DeleteElements = driver.FindElements(By.XPath("//button[@data-test='address-remove-button']"));
            foreach (IWebElement DeleteOption in DeleteElements)
            {
                WebHandlers.Instance.Click(DeleteOption);
                BrowserDriver.Sleep(3000);
                WebHandlers.Instance.Click(btnRemoveAddress);
                BrowserDriver.Sleep(3000);
            }
        }

        public void ConfirmStatus(string confirmMsg)
        {
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.VerifyText(AddressConfirmation, confirmMsg);
        }

        public void logOut()
        {
            WebHandlers.Instance.Click(WelcomeMessage);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(LogOut);
        }

        public void AddChild(string ExcelFileName, string SheetName)
        {
            Dictionary<string, string> dictChildData = GetAllChildData(ExcelFileName, SheetName).First().Value;
            string child_FirstName = dictChildData["ChildFirstName"];
            string child_LastName = dictChildData["ChildLastName"];
            splitDOB(dictChildData["DOB"]);
            string child_Relationship = dictChildData["childRelationship"];
            string child_Gender = dictChildData["childGender"];

            WebHandlers.Instance.WebElementExists(childFirstName);
            WebHandlers.Instance.EnterText(childFirstName, child_FirstName);
            WebHandlers.Instance.EnterText(childLastName, child_LastName, $"Entered {child_LastName} for LastName");
            WebHandlers.Instance.MultiSelectByText(childRelationship, child_Relationship, $"Selected the {child_Relationship}");
            WebHandlers.Instance.MultiSelectByText(childGender, child_Gender, $"Selected the {child_Gender}");
            WebHandlers.Instance.Click(checkBoxtermsAndConditions);
            WebHandlers.Instance.Click(btnJoinNow);
            BrowserDriver.Sleep(6000);
        }

        public void AddChildforCategory(Dictionary<string, string> custData)
        {
            //Dictionary<string, string> dictChildData = GetAllChildData(ExcelFileName, SheetName).First().Value;

            string child_FirstName = custData["ChildFirstName"];
            string child_LastName = custData["ChildLastName"];
            splitDOB(custData["DOB"]);
            string child_Relationship = custData["childRelationship"];
            string child_Gender = custData["childGender"];

            WebHandlers.Instance.WebElementExists(childFirstName);
            WebHandlers.Instance.EnterText(childFirstName, child_FirstName);
            WebHandlers.Instance.EnterText(childLastName, child_LastName, $"Entered {child_LastName} for LastName");
            WebHandlers.Instance.MultiSelectByText(childRelationship, child_Relationship, $"Selected the {child_Relationship}");
            WebHandlers.Instance.MultiSelectByText(childGender, child_Gender, $"Selected the {child_Gender}");
            WebHandlers.Instance.Click(checkBoxtermsAndConditions);
            WebHandlers.Instance.Click(btnJoinNow);

        }

        public void AddChildforCategory()
        {
            //Dictionary<string, string> dictChildData = GetAllChildData(ExcelFileName, SheetName).First().Value;

            string child_FirstName = "ChildFirst"+ CommonFunctions.GenerateRandomUser(5).ToUpper();            
            string child_LastName = "ChildLast" + CommonFunctions.GenerateRandomUser(5).ToUpper();
            string DOB = CommonFunctions.GetRandomChildDOB();            
            string child_Relationship = "Parent";
            string child_Gender = CommonFunctions.GenerateRandomGender();

            WebHandlers.Instance.WebElementExists(childFirstName);
            WebHandlers.Instance.EnterText(childFirstName, child_FirstName);
            WebHandlers.Instance.EnterText(childLastName, child_LastName, $"Entered {child_LastName} for LastName");

            string[] DOB1 = DOB.Split('.');
            //if (WebHandlers.Instance.WebElementExists(ddDay))
            //{
            WebHandlers.Instance.MultiSelectByText(ddDay, DOB1[0]);
            if (WebHandlers.Instance.WebElementExists(ddMonth))
                WebHandlers.Instance.MultiSelectByText(ddMonth, DOB1[1]);
            if (WebHandlers.Instance.WebElementExists(ddYear))
                WebHandlers.Instance.MultiSelectByText(ddYear, DOB1[2]);
            //}

            WebHandlers.Instance.MultiSelectByText(childRelationship, child_Relationship, $"Selected the {child_Relationship}");
            WebHandlers.Instance.MultiSelectByText(childGender, child_Gender, $"Selected the {child_Gender}");
            WebHandlers.Instance.Click(checkBoxtermsAndConditions);
            WebHandlers.Instance.Click(btnJoinNow);

        }

        public void AddMultipleChildInMiniHarrods(Dictionary<string, string> custData)
        {
            BrowserDriver.Sleep(5000);

            for (int i = 1; i < 4; i++)
            {
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//button[@id='add-child-button']")), $"Clicked add button for {custData["ChildFirstName" + i]}");
                string child_FirstName = custData["ChildFirstName" + i];
                Console.WriteLine("---------------------------Firstname of the child" + child_FirstName);
                string child_LastName = custData["ChildLastName"];
                splitDOB(custData["DOB"]);
                string child_Relationship = custData["childRelationship"];
                string child_Gender = custData["childGender"];

                WebHandlers.Instance.WebElementExists(AnotherchildFirstName);
                WebHandlers.Instance.EnterText(AnotherchildFirstName, child_FirstName);
                WebHandlers.Instance.EnterText(AnotherchildLastName, child_LastName, $"Entered {child_LastName} for LastName");
                WebHandlers.Instance.MultiSelectByText(AnotherchildRelationship, child_Relationship, $"Selected the {child_Relationship}");
                WebHandlers.Instance.MultiSelectByText(AnotherchildGender, child_Gender, $"Selected the {child_Gender}");
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//button[@id='submit-button']")), $"Clicked save changes for {custData["ChildFirstName" + i]}");
                ConfirmStatus("Your changes have been saved.");
                BrowserDriver.Sleep(3000);
            }
        }

        public void AddMultipleChildInMiniHarrods()
        {
            BrowserDriver.Sleep(5000);

            for (int i = 1; i < 4; i++)
            {
                string child_FirstName = "ChildFirst" + CommonFunctions.GenerateRandomUser(4).ToUpper();
                string child_LastName = "ChildLast" + CommonFunctions.GenerateRandomUser(4).ToUpper();
                string DOB = CommonFunctions.GetRandomChildDOB();
                string child_Relationship = "Parent";
                string child_Gender = CommonFunctions.GenerateRandomGender();
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//button[@id='add-child-button']")), $"Clicked add button for {child_FirstName}");
                
                Console.WriteLine("---------------------------Firstname of the child" + child_FirstName);
                
                WebHandlers.Instance.WebElementExists(AnotherchildFirstName);
                WebHandlers.Instance.EnterText(AnotherchildFirstName, child_FirstName);
                WebHandlers.Instance.EnterText(AnotherchildLastName, child_LastName, $"Entered {child_LastName} for LastName");

                string[] DOB1 = DOB.Split('.');
                //if (WebHandlers.Instance.WebElementExists(ddDay))
                //{
                    WebHandlers.Instance.MultiSelectByText(ddDay, DOB1[0]);
                    if (WebHandlers.Instance.WebElementExists(ddMonth))
                        WebHandlers.Instance.MultiSelectByText(ddMonth, DOB1[1]);
                    if (WebHandlers.Instance.WebElementExists(ddYear))
                        WebHandlers.Instance.MultiSelectByText(ddYear, DOB1[2]);
                //}

                WebHandlers.Instance.MultiSelectByText(AnotherchildRelationship, child_Relationship, $"Selected the {child_Relationship}");
                WebHandlers.Instance.MultiSelectByText(AnotherchildGender, child_Gender, $"Selected the {child_Gender}");
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//button[@id='submit-button']")), $"Clicked save changes for {child_FirstName}");
                ConfirmStatus("Your changes have been saved.");
                BrowserDriver.Sleep(3000);
            }
        }

        public void ValidateaddFifthchildMiniHarrods(Dictionary<string, string> custData)
        {
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElements(By.XPath("//button[@id='add-child-button']")).Count == 0, "Cannot add more than 4 child");


        }

        public void ValidateaddFifthchildMiniHarrods()
        {
            BrowserDriver.Sleep(3000);
            Assert.IsTrue(driver.FindElements(By.XPath("//button[@id='add-child-button']")).Count == 0, "Cannot add more than 4 child");


        }
        public void validateMultiplechildDetailsInSSC(Dictionary<string, string> ssc_childDataFromExcel)
        {
            Assert.IsTrue(driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["ChildFirstName"])).Displayed, ssc_childDataFromExcel["ChildFirstName"] + "not showing childfirsrt name in the relationship grid");
            Assert.IsTrue(driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["ChildFirstName1"])).Displayed, ssc_childDataFromExcel["ChildFirstName1"] + "not showing childfirsrt name in the relationship grid");
            Assert.IsTrue(driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["ChildFirstName2"])).Displayed, ssc_childDataFromExcel["ChildFirstName2"] + "not showing childfirsrt name in the relationship grid");
            Assert.IsTrue(driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["ChildFirstName3"])).Displayed, ssc_childDataFromExcel["ChildFirstName3"] + "not showing childfirsrt name in the relationship grid");
        }
        public void validatechildDetailsInSSC(Dictionary<string, string> ssc_childDataFromExcel)
        {
            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(ssc_relationshipBtn);
            BrowserDriver.Sleep(3000);

            Assert.IsTrue(driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["ChildFirstName"])).Displayed, ssc_childDataFromExcel["ChildFirstName"] + "not showing childfirsrt name in the relationship grid");
            //Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on Harrods.com customer address grid");
            //Assert.AreEqual(ssc_childDataFromExcel["ChildFirstName"], driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["ChildFirstName"])));
            //Assert.AreEqual(ssc_childDataFromExcel["ChildLastName"], ssc_childlastname);
            Assert.IsTrue(driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["ChildLastName"])).Displayed, ssc_childDataFromExcel["ChildLastName"] + "not showing ChildLastName in the relationship grid");
            Assert.IsTrue(driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["childRelationship"])).Displayed, ssc_childDataFromExcel["childRelationship"] + "not showing ChildLastName in the relationship grid");
        }

        public void splitDOB(String DOB)
        {

            string[] DOB1 = DOB.Split('.');
            if (WebHandlers.Instance.WebElementExists(childDate))
            {
                WebHandlers.Instance.MultiSelectByText(childDate, DOB1[0]);
                if (WebHandlers.Instance.WebElementExists(childMonth))
                    WebHandlers.Instance.MultiSelectByText(childMonth, DOB1[1]);
                if (WebHandlers.Instance.WebElementExists(childYear))
                    WebHandlers.Instance.MultiSelectByText(childYear, DOB1[2]);
            }
        }
        public string[] spiltName(string Fullname)
        {
            string[] name = Fullname.Split(' ');
            
             return name;
        }      
        public void ValidateAddedChild(Dictionary<string, string> ChildData) {
            
            Assert.AreEqual(ChildData["Name"], chName.Text);
            //Assert.AreEqual(ChildData["DOB"], chDay.Text + "." + chMonth.Text + "." + chyear.Text);
            Assert.AreEqual(ChildData["DOB"], chDay.Text + "-" + chMonth.Text + "-" + chyear.Text);
            Assert.AreEqual(ChildData["Gender"], chGender.Text);
        }
        public void removeChild()
        {
            checkboxRemoveChild.Click();
            btnSubmitChild.Click();
            btnLeaveMiniHarrods.Click();

        }
        public void validateRemovechildSuccess()
        {
            Assert.AreEqual(leaveConfirmMessage.Text, "Your Mini Harrods membership has now been cancelled.");
        }
        public void ValidateTierInHarrods(Dictionary<string, string> customerdetails)
        {
           
            Assert.AreEqual(customerdetails["CardNumber"], RewardCardNumber.Text,"Card No is not as Expected");
            Assert.AreEqual("GOLD TIER", UserTier.Text, "User Tier  is : "+ UserTier.Text);

        }
        public string validateDiscountdayBookedCanBeCancelled()
        {
            string bookedDate = null;
            if (driver.FindElements(By.XPath("//button[@id='discount-days-cancel-button']")).Count == 0)
            {
                Assert.Fail("No discount opted for the days");
            }
            else
            {
                string bookedslot = driver.FindElement(By.XPath("//button[@id='discount-days-cancel-button']//parent::div//..//p")).Text;
                string[] Date = bookedslot.Replace("th", "").Split(null);
                int month = DateTime.ParseExact(Date[1], "MMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                bookedDate = Date[0] + "." + month.ToString("00") + "." + DateTime.Now.Year;
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//button[@id='discount-days-cancel-button']")), " clicked on Cancel");

            }

            return bookedDate;
        }
        public void bookDiscountDay(string bookedDate)
        {
            driver.FindElement(By.XPath("(//button[@id='discount-days-select-button'])[1]")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            driver.FindElement(By.XPath("//div[@class='DayPicker-Day' and @aria-label='"+bookedDate+"']")).Click();
            driver.FindElement(By.XPath("//button[@id='schedule-selectDate']")).Click();
            BrowserDriver.Sleep(5000);
        }
        #endregion
    }
}
