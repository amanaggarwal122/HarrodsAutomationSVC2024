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

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerRelationshipsPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private SSCCustomersPage SSC_Customers_Page = null;

        #region  Constructor
        public SSCCustomerRelationshipsPage(IWebDriver driver, Configuration configuration)
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

        [FindsBy(How = How.XPath, Using = "//div[text()='Relationships']")]
        private IWebElement SSCCustomersRelationships;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;

        [FindsBy(How = How.XPath, Using = "(//*[text()='Relationship Type']/following::div/span)[1]")]
        private IWebElement SSC_RelationshipType_arrow_dropdown;

        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Has the Primary Member']")]
        private IWebElement SSC_RelationshipType_Primary_Member;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Add']")]
        private IWebElement SSC_Relationship_AddBtn;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Business Partner']/following::div/input)[1]")]
        private IWebElement SSC_BusinessPartner_Txtbox;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Business Partner']/parent::span/following::input)[1]")]
        private IWebElement SSC_BusinessPartner_field;

        [FindsBy(How = How.XPath, Using = "(//bdi[text()='Add'])[1]")]
        private IWebElement SSC_RelationshipPopup_AddBtn;

        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Has Secondary Member']")]
        private IWebElement SSC_RelationshipType_Secondary_Member;

        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;
        [FindsBy(How = How.XPath, Using = "(//*[text()='Save'])")]
        private IWebElement SSCSecoundarySaveButton;

        [FindsBy(How = How.XPath, Using = "//*[@title='Gender']/following::input[3][@class='sapMInputBaseInner sapMComboBoxInner']")]
        private IWebElement SSCChildGenderdrpdowntxt;

        [FindsBy(How = How.XPath, Using = "//*[@title='Relationship']/following::input[5][@class='sapMInputBaseInner sapMComboBoxInner']")]
        private IWebElement SSCChildRelationshipTxt;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'--header-arrowScrollRight')]")]
        private IWebElement SSCCustomerTabScrollRight;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Mini-Harrods']//parent::span//parent::div//following-sibling::div//span//bdi")]
        private IWebElement SSCMiniHarrodsChildrenCount;

        [FindsBy(How = How.XPath, Using = "//*[text()='Relationships']")]
        public IWebElement ssc_relationshipBtn;

        public By SSCChildGridData(string text) { return By.XPath("(//span[@title='" + text + "'])"); }

        #endregion
        public By SSCCustomersGridData(string text) { return By.XPath("//a[contains(text(),'" + text + "')]"); }
        public By SSCSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SpanSSCText(string text) { return By.XPath("//span[text()='" + text + "']"); }
        public By SSC_Relationship_Member(string member)
        {
            return By.XPath("//*[contains(text(),'" + member + "')]");
        }
        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        #region Events
        

        public void SearchCustomerAndNavigatetoRelationshipsTab(string email, string fullname, string phonenumber)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            //Search the customer
            SSC_Customers_Page.SearchCustomerOnSSC(fullname, email);

            //Navigate to Relationships tab
            WebHandlers.Instance.Click(SSCCustomersRelationships);
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(2000);
        }

        public void AddPrimaryMemberinRelationships(string primarymember)
        {
            WebHandlers.Instance.Click(SSCCustomersRelationships);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSC_Relationship_AddBtn);
            BrowserDriver.Sleep(3000);

            //WebWaitHelper.Instance.WaitForElementPresence(SSC_RelationshipType_dropdown);
            //SSC_RelationshipType_dropdown.Click();
            SSC_RelationshipType_arrow_dropdown.Click();
            BrowserDriver.Sleep(2000);
            SSC_RelationshipType_Primary_Member.Click();
            BrowserDriver.Sleep(2000);
            //SSC_RelationshipType_dropdown.SendKeys("Has the Primary Member");
            //WebHandlers.Instance.EnterText(SSC_RelationshipType_dropdown, "Has the Primary Member");

            //WebHandlers.Instance.EnterText(SSC_BusinessPartner_Txtbox, primarymember);
            SSC_BusinessPartner_Txtbox.Click();
            BrowserDriver.Sleep(2000);
            SSC_BusinessPartner_field.SendKeys(primarymember);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
        }
        public void AddSecondaryMemberinRelationships(string secondarymember)
        {
            if (!secondarymember.Equals(""))
            {
                Actions actions = new Actions(driver);
                //driver.Navigate().Refresh();
                //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
                BrowserDriver.Sleep(3000);
                //actions.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                //BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(SSCCustomersRelationships);
                BrowserDriver.Sleep(3000);
                WebHandlers.Instance.Click(SSC_Relationship_AddBtn);
                BrowserDriver.Sleep(3000);

                
                //WebHandlers.Instance.EnterText(SSC_RelationshipType_dropdown, "Has Secondary Member");
                //SSC_RelationshipType_dropdown.SendKeys("Has Secondary Member");
                SSC_RelationshipType_arrow_dropdown.Click();
                BrowserDriver.Sleep(2000);
                SSC_RelationshipType_Secondary_Member.Click();
                BrowserDriver.Sleep(2000);
                //BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.EnterText(SSC_BusinessPartner_Txtbox, secondarymember);
                //SSC_BusinessPartner_Txtbox.SendKeys(secondarymember);
                SSC_BusinessPartner_Txtbox.Click();
                SSC_BusinessPartner_Txtbox.Clear();
                SSC_BusinessPartner_Txtbox.SendKeys(secondarymember);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                BrowserDriver.Sleep(2000);
                if(SSC_RelationshipPopup_AddBtn.Displayed)
                {
                    WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                }
                // WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                BrowserDriver.Sleep(5000);
                WebHandlers.Instance.Click(SSCSecoundarySaveButton);
                BrowserDriver.Sleep(5000);
            }
        }

        public void AddAfterSecondaryMemberinRelationships(string secondarymember)
        {
            if (!secondarymember.Equals(""))
            {
                Actions actions = new Actions(driver);
                //driver.Navigate().Refresh();
                //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
                //  BrowserDriver.Sleep(3000);
                //actions.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                //BrowserDriver.Sleep(2000);
                // WebHandlers.Instance.Click(SSCCustomersRelationships);
                //BrowserDriver.Sleep(3000);
                //WebHandlers.Instance.Click(SSC_Relationship_AddBtn);
                BrowserDriver.Sleep(3000);


                //WebHandlers.Instance.EnterText(SSC_RelationshipType_dropdown, "Has Secondary Member");
                //SSC_RelationshipType_dropdown.SendKeys("Has Secondary Member");
                SSC_RelationshipType_arrow_dropdown.Click();
                BrowserDriver.Sleep(2000);
                SSC_RelationshipType_Secondary_Member.Click();
                BrowserDriver.Sleep(2000);
                //BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.EnterText(SSC_BusinessPartner_Txtbox, secondarymember);
                //SSC_BusinessPartner_Txtbox.SendKeys(secondarymember);
                SSC_BusinessPartner_Txtbox.Click();
                SSC_BusinessPartner_Txtbox.Clear();
                SSC_BusinessPartner_Txtbox.SendKeys(secondarymember);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                BrowserDriver.Sleep(2000);
                if (SSC_RelationshipPopup_AddBtn.Displayed)
                {
                    WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                }
                // WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                BrowserDriver.Sleep(5000);
                WebHandlers.Instance.Click(SSCSecoundarySaveButton);
                BrowserDriver.Sleep(5000);
            }
        }

        public void AddFinalSecondaryMemberinRelationships(string secondarymember)
        {
            if (!secondarymember.Equals(""))
            {
                Actions actions = new Actions(driver);
                //driver.Navigate().Refresh();
                //WebWaitHelper.Instance.WaitForElementPresence(SSCNewTicketEditIcon);
                //  BrowserDriver.Sleep(3000);
                //actions.MoveToElement(SSCNewTicketEditIcon).Click().Build().Perform();
                //BrowserDriver.Sleep(2000);
                // WebHandlers.Instance.Click(SSCCustomersRelationships);
                //BrowserDriver.Sleep(3000);
                //WebHandlers.Instance.Click(SSC_Relationship_AddBtn);
                BrowserDriver.Sleep(3000);


                //WebHandlers.Instance.EnterText(SSC_RelationshipType_dropdown, "Has Secondary Member");
                //SSC_RelationshipType_dropdown.SendKeys("Has Secondary Member");
                SSC_RelationshipType_arrow_dropdown.Click();
                BrowserDriver.Sleep(2000);
                SSC_RelationshipType_Secondary_Member.Click();
                BrowserDriver.Sleep(2000);
                //BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.EnterText(SSC_BusinessPartner_Txtbox, secondarymember);
                //SSC_BusinessPartner_Txtbox.SendKeys(secondarymember);
                SSC_BusinessPartner_Txtbox.Click();
                SSC_BusinessPartner_Txtbox.Clear();
                SSC_BusinessPartner_Txtbox.SendKeys(secondarymember);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                BrowserDriver.Sleep(2000);
                //if (SSC_RelationshipPopup_AddBtn.Displayed)
                //{
                //    WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                //}
                // WebHandlers.Instance.Click(SSC_RelationshipPopup_AddBtn);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(SSCSecoundarySaveButton);
                BrowserDriver.Sleep(5000);
            }
        }


        public void ValidateMemberAddedUnderRelationships(string member)
        {
            BrowserDriver.Sleep(3000);
            if (!member.Equals(""))
            {
                //Boolean member_present = WebHandlers.Instance.IsElementPresent(SSC_Relationship_Member(member));
                int ssc_member = driver.FindElements(SSC_Relationship_Member(member)).Count();
                Assert.IsTrue(ssc_member > 0, "Member is not displayed as expected");
            }
        }

        public void ValidateErrormessageNonRewardMember()
        {
            BrowserDriver.Sleep(2000);
            int invalidmsgcount = driver.FindElements(By.XPath("//span[contains(text(),'not valid')]")).Count;
            Assert.IsTrue(invalidmsgcount > 0, "Error Message is not displayed");
        }

        public void ValidateErrormessageforExtraMember()
        {
            BrowserDriver.Sleep(2000);
            int invalidmsgcount = driver.FindElements(By.XPath("//span[contains(text(),'This Group cannot be assigned more than 5 members')]")).Count;
            Assert.IsTrue(invalidmsgcount > 0, "Error Message is not displayed");
        }

        public void AddChildrenforUserinSSC_MiniHarrods(string ChildFirstname, string ChildLastName, string ChildDOB, string ChildGender, string Relationship)
        {
            
            //Tab Navigation to select 'Relationship' tab
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[@id='viewswitchnavigationGY7DqSLACas5UOimjBjifW_62--header-arrowScrollRight']")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomersRelationships);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//bdi[text()='Add Row']")));
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("//bdi[text()='First Name']/following::input[1]")), ChildFirstname);
            WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("//bdi[text()='Last Name']/following::input[2]")), ChildLastName);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCChildGenderDropdown(ChildGender)),ChildGender);
            SSCChildGenderdrpdowntxt.SendKeys(ChildGender);

            WebHandlers.Instance.EnterText(driver.FindElement(By.XPath("//bdi[text()='Birth Date']/following::input[4]")), ChildDOB);
            BrowserDriver.Sleep(1000);
            //WebHandlers.Instance.EnterText(driver.FindElement(SSCChildRelationship(Relationship)), Relationship);

            SSCChildRelationshipTxt.SendKeys(Relationship);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void RemoveLastChildforUserinSSC_MiniHarrods(string ChildFirstname, string ChildLastName, string ChildDOB, string ChildGender, string Relationship)
        {
            //Tab Navigation to select 'Relationship' tab
            WebHandlers.Instance.Click(driver.FindElement(By.XPath("//span[@id='viewswitchnavigationGY7DqSLACas5UOimjBjifW_62--header-arrowScrollRight']")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCCustomersRelationships);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            BrowserDriver.Sleep(3000);
            ReadOnlyCollection<IWebElement> delete_links = driver.FindElements(By.XPath("//*[@title='Delete']"));
            int count_delete = delete_links.Count;
            //clicking the last delete button
            WebHandlers.Instance.Click(delete_links[count_delete - 1]);
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void ValidateRemovedChildNotListingOnSSC(Dictionary<string, string> ChildData)
        {
            //Selecting user from SSC
            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Relationships")));
            BrowserDriver.Sleep(4000);
            Assert.AreEqual(0, driver.FindElements(SpanSSCText(ChildData["ChildFirstName"])).Count, "Child first name not removed from SSC");
            Assert.AreEqual(0, driver.FindElements(SpanSSCText(ChildData["ChildLastName"])).Count, "Child last name not removed from SSC");
            Assert.AreEqual(0, driver.FindElements(SpanSSCText(ChildData["DOB"])).Count, "Child date of birth not removed from SSC");
        }

        public void ValidatechildGetsDeletedFromSSC(string FullName, string Email)
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

            //Validating child gets deleted from the grid
            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
            BrowserDriver.Sleep(1000);
            driver.FindElement(SSCNewTicketSubTabs("Relationships")).Click();
            BrowserDriver.Sleep(3000);
            string count = SSCMiniHarrodsChildrenCount.Text.Replace("(", string.Empty).Replace(")", string.Empty);
            Assert.IsFalse(Int32.Parse(count) != 0, "not get deleted from SMC");

        }

        public void MultipleChildAddedUpdatedInSSC(string FullName, string Email, ScenarioContext scenarioContext)
        {
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

            driver.FindElement(SSCNewTicketSubTabs("Relationships")).Click();
            BrowserDriver.Sleep(3000);
            string count = SSCMiniHarrodsChildrenCount.Text.Replace("(", string.Empty).Replace(")", string.Empty);
            Assert.IsTrue(count.Equals("4"), "The count Of added To Mini Harrods is " + count);

        }

        public void validateMultiplechildDetailsInSSC(Dictionary<string, string> ssc_childDataFromExcel)
        {
            Assert.IsTrue(driver.FindElement(SSCChildGridData(ssc_childDataFromExcel["ChildFirstName"])).Displayed, ssc_childDataFromExcel["ChildFirstName"] + "not showing childfirsrt name in the relationship grid");
            Assert.IsTrue(driver.FindElement(SSCChildGridData(ssc_childDataFromExcel["ChildFirstName1"])).Displayed, ssc_childDataFromExcel["ChildFirstName1"] + "not showing childfirsrt name in the relationship grid");
            Assert.IsTrue(driver.FindElement(SSCChildGridData(ssc_childDataFromExcel["ChildFirstName2"])).Displayed, ssc_childDataFromExcel["ChildFirstName2"] + "not showing childfirsrt name in the relationship grid");
            Assert.IsTrue(driver.FindElement(SSCChildGridData(ssc_childDataFromExcel["ChildFirstName3"])).Displayed, ssc_childDataFromExcel["ChildFirstName3"] + "not showing childfirsrt name in the relationship grid");
        }
        public void validatechildDetailsInSSC(Dictionary<string, string> ssc_childDataFromExcel)
        {
            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.Click(ssc_relationshipBtn);
            BrowserDriver.Sleep(9000);

           // Assert.IsTrue(driver.FindElement(SSCChildGridData(ssc_childDataFromExcel["ChildFirstName"])).Displayed, ssc_childDataFromExcel["ChildFirstName"] + "not showing childfirsrt name in the relationship grid");
            //Assert.IsTrue(driver.FindElement(FFCustomerAddressGridData(PostalAddress["AddressLine1"])).Displayed, PostalAddress["AddressLine1"] + " not showing on Harrods.com customer address grid");
            //Assert.AreEqual(ssc_childDataFromExcel["ChildFirstName"], driver.FindElement(SMCChildGridData(ssc_childDataFromExcel["ChildFirstName"])));
            //Assert.AreEqual(ssc_childDataFromExcel["ChildLastName"], ssc_childlastname);
            //Assert.IsTrue(driver.FindElement(SSCChildGridData(ssc_childDataFromExcel["ChildLastName"])).Displayed, ssc_childDataFromExcel["ChildLastName"] + "not showing ChildLastName in the relationship grid");
            Assert.IsTrue(driver.FindElement(SSCChildGridData(ssc_childDataFromExcel["childRelationship"])).Displayed, ssc_childDataFromExcel["childRelationship"] + "not showing ChildLastName in the relationship grid");
        }

        #endregion
    }
}
