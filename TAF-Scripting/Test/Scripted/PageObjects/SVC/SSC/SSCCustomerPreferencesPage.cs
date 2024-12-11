using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;


namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerPreferencesPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        List<string> consentselection = new List<string>();
        List<string> interestselection = new List<string>();
        private CommonFunctions Common_Functions = null;

        #region  Constructor
        public SSCCustomerPreferencesPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements 
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;
        [FindsBy(How = How.XPath, Using = "//div[text()='Preferences']")]
        private IWebElement SSCCustomersSubtabPreferences;
        [FindsBy(How = How.XPath, Using = "//table[2]/tbody[1]/tr[1]/td[3]/div[1]/a[1]")]
        private IWebElement SSCCustomerGridFirstCell;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;
        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;
        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Attribute']/following::button/span/span//bdi[text()='Add'])[1]")]
        private IWebElement SSC_Pref_Attribute_Btn;       
        [FindsBy(How = How.XPath, Using = "//span[text()='Lead Generation']")]
        private IWebElement SSC_DB_LeadGenChkBox;
        [FindsBy(How = How.XPath, Using = "//span[text()='Classification']")]
        private IWebElement SSC_DB_ClassificatinChkBox;
        [FindsBy(How = How.XPath, Using = "//span[text()='Personal Shopping']")]
        private IWebElement SSC_DB_PSChkBox;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Select']")]
        private IWebElement SSC_DialogBox_Select;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Cancel']")]
        private IWebElement SSC_DialogBox_Cancel;
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]/tr[1]/td[5]/span[1][@title='Delete']")]
        private IWebElement SSC_Attribute_DeleteBtn;
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]/tr[1]/td[1]")]
        private IWebElement SSC_AttributeTable_NoData;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;
        [FindsBy(How = How.XPath, Using = "//a[contains(@id,'-link-listdefintionm_MXxdq8a4M5_GJT7qA0Km_')]")]
        private IWebElement SSCCustomerCardNo;
        [FindsBy(How = How.XPath, Using = "//span[text()='E-Mail']/../../following-sibling::td[1]/div/span")]
        private IWebElement SSCCustomerEmailConsentOptValue;
        [FindsBy(How = How.XPath, Using = "//a[@title='Customers']")]
        private IWebElement SSCNavCustomers;

        [FindsBy(How = How.XPath, Using = "(//bdi[contains(@id,'paginator-pageInfo-bdi')])[2]")]
        private IWebElement SSC_Interests_Pagination;
        #endregion
        public By SSCCustomersGridData(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }
        public By SSCCustomersPurchaseGridData(string orderId) { return By.XPath("//span[text()='" + orderId + "']"); }
        public By SSCCustomersConsent(string text)
        {
            return By.XPath("//span[text()='" + text + "']/../../following-sibling::td[1]/div/span");
        }
        public By SSCCustomersSubtabClose(string text) { return By.XPath("//span[text()='" + text + "']/../../../button[2]"); }
        public By SSCCustomersInterest(string text)
        {
            return By.XPath("//span[text()='" + text + "']/../../following-sibling::td[1]/div/span");
        }
        public By FFChannelConsentField(string ChannelName) { return By.XPath("//input[@id='" + ChannelName + "']"); }
        #region Events
        public void navigatetoPreferencesTabinSSC()
        {
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
            BrowserDriver.Sleep(2000);
        }
        public string[] OptingInEmailConsentOnSSC(string UserName, string Email, string EmailConsent)
        {
            //string FullName = UserName + " " + UserName + "Lname"; bool itemExists = false;
            string CdcId = null, CardNumber = null, OptValue = null;
            string Gridemailtext = "";
            BrowserDriver.Sleep(3000);
            try
            {

                SSCCustomersSearchIcon.Click();
                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                BrowserDriver.Sleep(3000);


                WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);
            }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }

            //CdcId = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='E-Mail']/../../following-sibling::td[4]/div//span[@title='Set to Opt-In']")));
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            WebHandlers.Instance.Click(SSCSaveButton);
            //BrowserDriver.Sleep();
            //WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
            //BrowserDriver.PageWait();
            //BrowserDriver.Sleep(1000);
            return new string[] { CdcId, CardNumber };


        }

        public void ValidateOptChannel(string Channel, bool OptValue)
        {
            
            Console.WriteLine("Opt value --> " + SSCCustomersConsent(Channel).ToString());
            if (OptValue)
                //Assert.AreEqual("true", driver.FindElement(SSCCustomersConsent(Channel)).GetAttribute("checked"), "Opt value for channel not showing as expected");
                Assert.AreEqual("Opt-Out", driver.FindElement(SSCCustomersConsent(Channel)).GetAttribute("title"), "Opt value for channel not showing as expected");
            else if (OptValue == false)
                Assert.AreEqual("Opt-Out", driver.FindElement(SSCCustomersConsent(Channel)).GetAttribute("title"), "Opt value for channel not showing as expected");
            //Assert.IsEmpty(driver.FindElement(ChannelField).GetAttribute("checked"), "Opt value for channel not showing as expected");
        }

        public void AddPotentialResellerAttributetoCustomer(string email, string fullname)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(fullname)).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
            BrowserDriver.Sleep(3000);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSC_Pref_Attribute_Btn);
            BrowserDriver.Sleep(3000);
            try
            {
                BrowserDriver.Sleep(3000);
               // Attribute "Classification" selection
                //SSC_DB_ClassificatinChkBox.Click();
                //WebHandlers.Instance.Click(SSC_DB_PrivShoppingChkBox);               
                
                BrowserDriver.Sleep(8000);
                SSC_DB_LeadGenChkBox.Click();
                BrowserDriver.Sleep(8000);
                //SSC_DB_LeadGenChkBox.Click();
                SSC_DB_PSChkBox.Click();
                SSC_DialogBox_Select.Click();
                BrowserDriver.Sleep(3000);
                //WebHandlers.Instance.Click(SSC_DialogBox_Select);               
            }
            catch
            {
                //WebHandlers.Instance.Click(SSC_DialogBox_Cancel);
                SSC_DialogBox_Cancel.Click();
            }
            BrowserDriver.Sleep(4000);
            //WebHandlers.Instance.EnterText(SSC_NotEligiblePrivShop_Dropdown, "Potential Reseller / Non-End User");
            //Page NAvigation not exist in UI now
            //driver.FindElement(By.XPath("//*[contains(@id,'dataTypeValue3-arrow')]")).Click();
            //driver.FindElement(By.XPath("//li[contains(@id,'dataTypeValue')][@aria-posinset='3']")).Click();
            //WebHandlers.Instance.MultiSelectByText(SSC_NotEligiblePrivShop_Dropdown, "Potential Reseller / Non-End User");
            //SSC_NotEligiblePrivShop_Dropdown.SendKeys("Potential Reseller / Non-End User");
            //WebHandlers.Instance.ExecuteScript("arguments[0].value='Potential Reseller / Non-End User'", SSC_NotEligiblePrivShop_Dropdown);

            //SSC_PrivateShopping_ToggleTxt.SendKeys("No");
            //Lead Generation Attributes- Not eligible for Private Shopping dropdown selection
            //Selection of  'Potential Reseller / Non-End User' from 'Not eligible for Private Shopping' dropdown
            driver.FindElement(By.XPath("//bdi[text()='Not eligible for Private Shopping']//following::td[1]")).Click();
            BrowserDriver.Sleep(2000);
            driver.FindElement(By.XPath("//li[text()='Potential Reseller / Non-End User']")).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCSaveButton);
            //string potential_Reseller = WebHandlers.Instance.GetAttribute(SSC_NotEligiblePrivShop_Dropdown, "value");
            //string privateShoppingstatus = WebHandlers.Instance.GetAttribute(SSC_PrivateShopping_ToggleTxt,"value");
            Assert.IsTrue(driver.FindElement(By.XPath("//span[text()='Potential Reseller / Non-End User']")).Displayed, "The status of potential reseller is not correct");
        }

        public void RemovePrivateShoppingAttributetoCustomer(string email, string fullname)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, email + "\n");
            BrowserDriver.Sleep(3000);
            driver.FindElement(SSCCustomersGridData(fullname)).Click();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
            BrowserDriver.Sleep(3000);
            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(3000);
            // Add new Attribute if Attribute is not there and then trying delete
            WebHandlers.Instance.Click(SSC_Pref_Attribute_Btn);
            BrowserDriver.Sleep(3000);
            try
            {
                BrowserDriver.Sleep(3000);
                //WebHandlers.Instance.WebElementExists(SSC_DB_LeadGenChkBox);
                //SSC_DB_LeadGenChkBox.Click();
                // Attribute "Classification" selection
                SSC_DB_ClassificatinChkBox.Click();
                //Other attributes commented to display "No Data" text
                //BrowserDriver.Sleep(8000);
                //SSC_DB_LeadGenChkBox.Click();
                //SSC_DB_PSChkBox.Click();
                BrowserDriver.Sleep(3000);
                SSC_DialogBox_Select.Click();
                BrowserDriver.Sleep(5000);

            }
            catch
            {
                SSC_DialogBox_Cancel.Click();
            }
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.Click(SSC_Attribute_DeleteBtn);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(SSCSaveButton);
            string nodata = WebHandlers.Instance.GetTextOfElement(SSC_AttributeTable_NoData);
            Assert.IsTrue(nodata.Equals("No data"), "The attribute is not removed");
        }

        public void VerifyOptinConsentandInterestsOnSSC(string UserName, string Email, string consent, string interest)
        {
            string FullName = UserName;
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            if (consent.Equals("Letter"))
            {
                Assert.IsTrue(driver.FindElement(SSCCustomersConsent(consent)).Text == "Opt-In", "The Consent " + consent + " is not opted in");
                
            }
            else if (!consent.Equals(""))
            {
                Assert.IsTrue(driver.FindElement(SSCCustomersConsent(consent)).Text == "Opt-In", "The Consent " + consent + " is not opted in");
            }
           

            if (!interest.Equals(""))
            {
                Assert.IsTrue(driver.FindElement(SSCCustomersConsent(interest)).Text == "Opt-In", "The Interest " + consent + " is not opted in");
            }

        }

        public string VerifyConsentandInterestsOnSSC(string UserName, string Email, ScenarioContext scenarioContext)
        {
            string optstatus = "", optstatus1 = "", optstatus2 = "";
            List<String> Consentlist = new List<string>(new string[] { "E-Mail", "Telephone", "SMS", "Letter", "Publications" });
            List<String> InterestList = new List<string>(new string[] { "Fine Jewellery","Fine Watches","Food Restaurants",
                "Harrods Rewards","HBeauty","Home Technology","Kids Toys","Menswear","Mini Harrods","Salon Wellness Services",
                "Wine Spirits","Womenswear" });
            List<String> optedconsents = new List<string>();
            List<String> optedinterests = new List<string>();

            string FullName = UserName + " " + UserName + "Lname";
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            scenarioContext.Add("UserCDCId", customer_cdcid);

            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            foreach (String item in Consentlist)
            {
                if (driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-In")
                {

                    optedconsents.Add(item);
                }
            }

            foreach (String item in InterestList)
            {
                if (driver.FindElement(SSCCustomersConsent(item)).Text == "Yes")
                {

                    optedinterests.Add(item);
                }
            }

            foreach (string item in optedconsents)
            {
                if (consentselection.Contains(item))
                {
                    optstatus1 = "";
                }
            }

            foreach (string item in optedinterests)
            {
                if (interestselection.Contains(item))
                {
                    optstatus2 = "";
                }
            }
            //Edit for Assertion
            optstatus = optstatus1 + optstatus2;
            return optstatus;
        }

        public string VerifyCardEmailConsentDetailsOnSSC(string UserName, string Email, string EmailConsent)
        {
            string FullName = UserName + " " + UserName + "Lname";
            string CardNumber = null, OptValue = null;

            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);

            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
            CardNumber = WebHandlers.Instance.GetAttribute(SSCCustomerCardNo, "innerHTML");
            Assert.IsNotNull(CardNumber, "SSC card number is not showing for the user");

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);
            OptValue = WebHandlers.Instance.GetAttribute(SSCCustomerEmailConsentOptValue, "innerHTML");
            if (EmailConsent == "Yes")
                Assert.AreEqual("Opt-In", OptValue, "SSC - Email consent value is not showing as expected for the user");
            else if (EmailConsent == "No")
                Assert.AreEqual("Opt-Out", OptValue, "SSC - Email consent value is not showing as expected for the user");

            driver.FindElement(SSCCustomersSubtabClose(FullName)).Click();
            BrowserDriver.Sleep();
            WebHandlers.Instance.ClickByJsExecutor(SSCNavCustomers);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(1000);
            return CardNumber;
        }

        public void ValidateChannelOptinAndInterestSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist, List<String> InterestList)
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
            if (Consentlist.Count > 0)
            {
                foreach (String item in Consentlist)
                {
                    Assert.IsTrue(driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-In", item + " :IS NOT OPTED");

                }
            }
            if (InterestList.Count > 0)
            {
                foreach (String item in InterestList)
                {
                    Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "Yes", item + " :IS NOT OPTED");

                }
            }

        }
        public void ValidateInterestUpdatedInSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist, List<String> InterestList, string consentvalue, string InterestValue)
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
                if (consentvalue == "Opt-in")
                {
                    Assert.IsTrue(driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-In", item + " :IS NOT OPTED");

                }
                else if (consentvalue == "Opt-Out")
                    Assert.IsTrue(driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-Out", item + " :IS NOT OPTED");

            }
            
            foreach (String item in InterestList)
            {
                try
                {
                    if (InterestValue == "No")
                    {
                        Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS  OPTED");
                    }
                    else if (InterestValue == "Yes")
                    {
                        Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "Yes", item + " :IS  Not OPTED");
                    }
                }
                catch (NoSuchElementException)
                {
                    driver.FindElement(By.XPath("(//*[@role='button'][contains(@id,'paginator-nextPage')])[2]")).Click();
                    if (InterestValue == "No")
                    {
                        Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS  OPTED");
                        if(driver.FindElement(SSCCustomersInterest(item)).Text == "No")
                        {
                            break;
                        }
                    }
                    else if (InterestValue == "Yes")
                    {
                        Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "Yes", item + " :IS not OPTED");
                        if (driver.FindElement(SSCCustomersInterest(item)).Text == "Yes")
                        {
                            break;
                        }
                    }
                }
            }
        }

        public void OptOutConsentsinSSC(string ConsentList, string Email)
        {
            string[] Consent_List = ConsentList.Split(',');
            //Customer search
            try
            {
                SSCCustomersSearchIcon.Click();
                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                BrowserDriver.Sleep(3000);

                WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);
            }
            catch
            {
                WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon);
                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                BrowserDriver.Sleep(3000);

                WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);
            }

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);

            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(4000);
            for (int i = 0; i < Consent_List.Length; i++)
            {
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + Consent_List[i] + "']/../../following-sibling::td[4]/div//span[@title='Set to Opt-Out']")));
                BrowserDriver.Sleep(2000);
            }
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void OptInConsentsinSSC(string ConsentList, string Email)
        {
            string[] Consent_List = ConsentList.Split(',');
            //Customer search
            try
            {
                SSCCustomersSearchIcon.Click();
                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                BrowserDriver.Sleep(3000);

                WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);
            }
            catch
            {
                WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon);
                WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
                BrowserDriver.Sleep(3000);

                WebHandlers.Instance.Click(SSCCustomerGridFirstCell);
                BrowserDriver.PageWait();
                BrowserDriver.Sleep(3000);
            }

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(2000);

            SSCDetailsEditIcon.Click();
            BrowserDriver.Sleep(4000);
            for (int i = 0; i < Consent_List.Length; i++)
            {
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + Consent_List[i] + "']/../../following-sibling::td[4]/div//span[@title='Set to Opt-In']")));
                BrowserDriver.Sleep(2000);
            }
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void RemoveAllInterestsSSC(string Email, string InterestList)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomerGridFirstCell);

            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            string[] Interest_list = InterestList.Split(',');
            string[] Interest_list_page1 = Interest_list.Take(9).ToArray(); 
            string[] Interest_list_page2 = Interest_list.Skip(9).ToArray();

            foreach (string item in Interest_list_page1)
            {
                //Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS OPTED");
                //WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[@id='panevariant1FNnz2h45KYAW_aQlhhrGW_624-paginator-nextPage']")));
                BrowserDriver.Sleep(5000);
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + item + "']/../../following-sibling::td[3]/div//span[@title='Set to Unsubscribed']")));

            }
            //Interest tab page Navigation
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[@class='sapUiIcon sapUiIconMirrorInRTL sapUiIconPointer sapClientMnextPageIcon']")));

            foreach (string item in Interest_list_page2)
            {
              //WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[@id='panevariant1FNnz2h45KYAW_aQlhhrGW_624-paginator-nextPage']")));
                BrowserDriver.Sleep(3000);
                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + item + "']/../../following-sibling::td[3]/div//span[@title='Set to Unsubscribed']")));

            }
        }

        public void AddAllInterestsSSC(string Email, string InterestList)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            string[] Interest_list = InterestList.Split(',');

            foreach (string item in Interest_list)
            {
                //Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS OPTED");

                WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[text()='" + Interest_list + "']/../../following-sibling::td[3]/div//span[@title='Set to Subscribed']")));

            }
        }

        public void ValidateConsentsOpted(string Consents, bool isopted)
        {
            string[] Consent_List = Consents.Split(',');
            if (isopted == true)
            {
                foreach (var item in Consent_List)
                {
                    Assert.IsTrue(driver.FindElement(FFChannelConsentField(item)).Selected, item + ":IS OPTED");

                }
            }
        }

        public void ValidateChannelOptinSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist)
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
                Assert.IsTrue(driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-Out", item + " :IS OPTED");
            }

        }

        public void ValidatepartialInterestvalidationSSC(string UserName, string Email, ScenarioContext scenarioContext, List<String> Consentlist, List<String> NoninterestList)
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
            BrowserDriver.Sleep(7000);

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            foreach (String item in Consentlist)
            {
                Assert.IsTrue(driver.FindElement(SSCCustomersConsent(item)).Text == "Opt-In", item + " :IS NOT OPTED");

            }

            foreach (String item in NoninterestList)
            {
                Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "No", item + " :IS OPTED");

            }
            Assert.IsTrue(driver.FindElement(SSCCustomersInterest("Mothers Day")).Text == "Yes", "Mothers day is unsubsribed");

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
                Assert.IsTrue(driver.FindElement(SSCCustomersInterest(item)).Text == "Opt-In", item + " :IS OPTED");

            }
        }
        
        public void miniHarrodsRemoveInterestUpdatedInSSC(string FullName, string Email, ScenarioContext scenarioContext)
        {
            Common_Functions = new CommonFunctions();
            
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Email + "\n");
            BrowserDriver.Sleep(3000);
            string customer_cdcid = WebHandlers.Instance.GetAttribute(SSCCustomerCDCID, "innerHTML");

            scenarioContext.Add("UserCDCId", customer_cdcid);

            driver.FindElement(SSCCustomersGridData(FullName)).Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(3000);

            SSCCustomersSubtabPreferences.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);

            //Extract the pagination details 
            string interests_pagination = SSC_Interests_Pagination.Text;

            string pagination = Common_Functions.GetNumbers(interests_pagination);
            int p = Int32.Parse(pagination);

            for (int i = 0; i < p; i++)
            {
                try
                {
                    string status = driver.FindElement(SSCCustomersInterest("Mini Harrods")).Text;
                    
                    if (status.Equals("No"))
                    {
                        break;
                    }

                }
                catch { }
                //TC_100-Xpath change of Page Navigator
                driver.FindElement(By.XPath("(//*[@aria-label='Next Page'])[2]")).Click(); 
            }

            

            //Assert.IsTrue(driver.FindElement(SSCCustomersInterest("Mini Harrods")).Text == "No", "Mini Harrods :IS OPTED");
        }


        #endregion
    }
}
