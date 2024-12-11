using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TAF_Web.Scripted.Web;
using TAF_Scripting.Test.Common;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.FF
{
    class FFUserMiniHarrodsPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private FFUserCommunicationPreferencesPage FF_Communication_Pref_Page = null;

        #region  Constructor
        public FFUserMiniHarrodsPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
            
        }

        #endregion

        #region Elements

        [FindsBy(How = How.XPath, Using = " //button[@id='submit-button']")]
        private IWebElement btnSubmitChild;
       
        [FindsBy(How = How.XPath, Using = "//button[@id='join-miniHarrods-button']")]
        private IWebElement btnJoinMiniHarrods;

        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
        private IWebElement AddChildFirstNameInput;

        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement AddChildLastNameInput;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.day']")]
        private IWebElement AddChildDOBDaySelect;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.month']")]
        private IWebElement AddChildDOBMonthSelect;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.year']")]
        private IWebElement AddChildDOBYearSelect;
        //Current working xpath for RelationshipSelection
        [FindsBy(How = How.XPath, Using = "//select[@id='newChildForm-relationship']")]
        private IWebElement AddChildRelationshipSelect;
        //Current working xpath for GenderSelection
        [FindsBy(How = How.XPath, Using = "//select[@id='newChildForm-gender']")]
        private IWebElement AddChildGenderSelect;

        [FindsBy(How = How.Id, Using = "leave-miniHarrods-button")]
        private IWebElement LeaveMiniHarrodsSubscriptionbtn;

        [FindsBy(How = How.XPath, Using = " //button[@id='confirmationModal-confirmButton']")]
        private IWebElement btnSaveChanges;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='account-sidebar']//span[text()='Mini Harrods']")]
        private IWebElement lnkMiniHarrods;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.day']")]
        public IWebElement childDate;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.month']")]
        public IWebElement childMonth;

        [FindsBy(How = How.XPath, Using = "//select[@id='dateInput.year']")]
        public IWebElement childYear;

        [FindsBy(How = How.XPath, Using = "  //li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[@class='css-10i47os e1sql9j53']//p[@class='css-nlsg0a e1sql9j54']")]
        private IWebElement chName;

        [FindsBy(How = How.XPath, Using = " //li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[2]//p[1]")]
        private IWebElement chDay;

        [FindsBy(How = How.XPath, Using = " //li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[2]//p[2]")]
        private IWebElement chMonth;

        [FindsBy(How = How.XPath, Using = " //li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[2]//p[3]")]
        private IWebElement chyear;

        [FindsBy(How = How.XPath, Using = "//li[@class='e18t3ils7 css-cl2kl2 e1sql9j50']//dl//dd[3]")]
        private IWebElement chGender;

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox'and @class='css-148cr8f edvavdu0']")]
        public IWebElement checkboxRemoveChild;

        [FindsBy(How = How.XPath, Using = " //button[@id='leave-miniHarrods-button']")]
        private IWebElement btnLeaveMiniHarrods;

        [FindsBy(How = How.XPath, Using = " //div[@data-test='notification-confirmation']")]
        private IWebElement leaveConfirmMessage;

        [FindsBy(How = How.XPath, Using = "//div//input[@id='children[1]Form-firstName' and @type='text']")]
        public IWebElement childFirstName;

        [FindsBy(How = How.XPath, Using = "//div//input[@id='children[1]Form-lastName' and @type='text']")]
        public IWebElement childLastName;

        [FindsBy(How = How.XPath, Using = "//select[@id='children[1]Form-relationship']")]
        public IWebElement childRelationship;

        [FindsBy(How = How.XPath, Using = "//select[@id='children[1]Form-gender']")]
        public IWebElement childGender;

        [FindsBy(How = How.XPath, Using = "//input[@id='miniHarrodsForm-termsAndConditions']")]
        public IWebElement checkBoxtermsAndConditions;

        [FindsBy(How = How.XPath, Using = "//button[@id='join-miniHarrods-button']")]
        public IWebElement btnJoinNow;

        [FindsBy(How = How.Id, Using = "dateInput.day")]
        private IWebElement ddDay;              

        [FindsBy(How = How.Id, Using = "dateInput.month")]
        private IWebElement ddMonth;

        [FindsBy(How = How.Id, Using = "dateInput.year")]
        private IWebElement ddYear;

        [FindsBy(How = How.XPath, Using = "//div//input[@id='newChildForm-firstName' and @type='text']")]
        public IWebElement AnotherchildFirstName;

        [FindsBy(How = How.XPath, Using = "//div//input[@id='newChildForm-lastName' and @type='text']")]
        public IWebElement AnotherchildLastName;

        [FindsBy(How = How.XPath, Using = "//select[@id='newChildForm-relationship']")]
        public IWebElement AnotherchildRelationship;

        [FindsBy(How = How.XPath, Using = "//select[@id='newChildForm-gender']")]
        public IWebElement AnotherchildGender;


        

        #endregion


        public By JoinMiniHarrodsLink(string miniHarrods) { return By.XPath("//h3[text()='" + miniHarrods + "']//following-sibling::a"); }
              

        public By HeaderConfirmMsg(string Message) { return By.XPath("//h2[text()='" + Message + "']"); }

        public By LinkHarrodsText(string Message) { return By.XPath("//a[text()='" + Message + "']"); }

        public By spanHarrodsText(string Message) { return By.XPath("//span[text()='" + Message + "']"); }

        public By CheckboxRemoveChild(string ChildName) { return By.XPath("(//p[text()='" + ChildName + "']/following::input)[1]"); }

        public By ParaUserDetails(string Details) { return By.XPath("//p[text()='" + Details + "']"); }

        public By ChildDobDetails(string Day, string Month, string Year) { return By.XPath("//p[text()='" + Day + "']/following::p[text()='" + Month + "']/following::p[text()='" + Year + "']"); }

        public By DivConfirmMsg(string Message) { return By.XPath("//div[contains(text(),'" + Message + "')]"); }

        public By MainHeaderConfirmMsg(string Message) { return By.XPath("//h1[text()='" + Message + "']"); }

        
        #region Events

        public void InvokeMiniHarrods()
        {
            WebHandlers.Instance.Click(lnkMiniHarrods);
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
        public void ValidateAddedChild(Dictionary<string, string> ChildData)
        {
            BrowserDriver.Sleep(5000);
            Assert.AreEqual(ChildData["Name"], chName.Text);
            //Assert.AreEqual(ChildData["DOB"], chDay.Text + "." + chMonth.Text + "." + chyear.Text);
            BrowserDriver.Sleep(5000);
            Assert.AreEqual(ChildData["DOB"], chDay.Text + "-" + chMonth.Text + "-" + chyear.Text);
            BrowserDriver.Sleep(5000);
            Assert.AreEqual(ChildData["Gender"], chGender.Text);
        }
        public void removeChild()
        {
            checkboxRemoveChild.Click();
            BrowserDriver.Sleep(2000);
            btnSubmitChild.Click();
            BrowserDriver.Sleep(2000);
            btnLeaveMiniHarrods.Click();

        }
        public void validateRemovechildSuccess()
        {
            Assert.AreEqual(leaveConfirmMessage.Text, "Your Mini Harrods membership has now been cancelled.");
        }

        public void ValidateMiniHarrodsBenefitsMembershipCommPreferance()
        {
            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg("Stay in Touch")).Displayed, "Stay in Touch - header not showing on Mini Harrods page");
            Assert.IsTrue(driver.FindElement(LinkHarrodsText("View Communication Preferences ")).Displayed, "View Communication Preferences - link not showing on Mini Harrods page");

            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg("Mini Harrods Benefits")).Displayed, "Mini Harrods Benefits - header not showing on Mini Harrods page");
            Assert.IsTrue(driver.FindElement(spanHarrodsText("The Latest News")).Displayed, "The Latest News - benefits message not showing on Mini Harrods page");
            Assert.IsTrue(driver.FindElement(spanHarrodsText("Birthday 10% Off")).Displayed, "Birthday 10% Off - benefits message not showing on Mini Harrods page");
            Assert.IsTrue(driver.FindElement(spanHarrodsText("The Harrods Academy")).Displayed, "The Harrods Academy - benefits message not showing on Mini Harrods page");
            Assert.IsTrue(driver.FindElement(spanHarrodsText("Special Events")).Displayed, "Special Events - benefits message not showing on Mini Harrods page");

            Assert.IsTrue(driver.FindElement(HeaderConfirmMsg("Mini Harrods Membership")).Displayed, "Mini Harrods Membership - header not showing on Mini Harrods page");
        }

        public void RemoveGivenChildFromMiniHarrods(string ChildFullName)
        {
            BrowserDriver.Sleep(3000);
            driver.FindElement(CheckboxRemoveChild(ChildFullName)).Click();
            btnSubmitChild.Click();
            BrowserDriver.Sleep(5000);
        }

        public void ValidateRemovedChildNotListingOnHarrods(Dictionary<string, string> childData)
        {
            Assert.AreEqual(0, driver.FindElements(ParaUserDetails(childData["Name"])).Count, "Child name is showing under mini harrods even after performing remove child");
            int dobCount = driver.FindElements(ChildDobDetails(childData["DOBDay"], childData["DOBMonth"], childData["DOBYear"])).Count;
            Assert.AreEqual(0, dobCount, "Child date of birth is showing under mini harrods even after performing remove child");
        }

        public void AddAnotherChildfromHarrods(Dictionary<string, string> ChildData)
        {
            string[] child_DOB = ChildData["DOB"].Split('.');
            WebHandlers.Instance.Click(driver.FindElement(spanHarrodsText("Add another child")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.WebElementExists(AddChildFirstNameInput);
            WebHandlers.Instance.EnterText(AddChildFirstNameInput, ChildData["ChildFirstName"]);
            WebHandlers.Instance.EnterText(AddChildLastNameInput, ChildData["ChildLastName"]);

            WebHandlers.Instance.MultiSelectByText(AddChildDOBDaySelect, child_DOB[0]);
            WebHandlers.Instance.MultiSelectByText(AddChildDOBMonthSelect, child_DOB[1]);
            WebHandlers.Instance.MultiSelectByText(AddChildDOBYearSelect, child_DOB[2]);
            BrowserDriver.Sleep(5000);
            //XPath for relationship and gender change
            WebHandlers.Instance.MultiSelectByText(AddChildRelationshipSelect, ChildData["childRelationship"]);
            WebHandlers.Instance.MultiSelectByText(AddChildGenderSelect, ChildData["childGender"]);
            BrowserDriver.Sleep(5000);
            btnSubmitChild.Click();
        }

        public void PerformCancelMiniHarrodsSubscription()
        {
            WebHandlers.Instance.WebElementExists(driver.FindElement(LinkHarrodsText("Leave Mini Harrods")));
            WebHandlers.Instance.Click(driver.FindElement(LinkHarrodsText("Leave Mini Harrods")));
            BrowserDriver.Sleep(3000);
            WebHandlers.Instance.WebElementExists(LeaveMiniHarrodsSubscriptionbtn);
            WebHandlers.Instance.Click(LeaveMiniHarrodsSubscriptionbtn);
            BrowserDriver.Sleep(5000);
        }

        public void ValidateCancelMiniHarrodsSubscriptionStatus()
        {
            string confirmMessage = "Your Mini Harrods membership has now been cancelled.";
            WebHandlers.Instance.WebElementExists(driver.FindElement(DivConfirmMsg(confirmMessage)));
            Assert.IsTrue(driver.FindElement(DivConfirmMsg(confirmMessage)).Displayed, "User is not able to cancel mini harrods subscription");
        }

        public void ValidateUserChildrenDetails(string[] ChildrenData)
        {
            WebHandlers.Instance.WebElementExists(driver.FindElement(MainHeaderConfirmMsg("Mini Harrods")));

            foreach (string child in ChildrenData)
                Assert.IsTrue(driver.FindElement(ParaUserDetails(child)).Displayed, child + " name not listing on online mini harrods page");
        }

        public void JoinMiniHarrodsViaCommunicationPreference()
        {
            WebHandlers.Instance.Click(driver.FindElement(JoinMiniHarrodsLink("Mini Harrods")));
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!Clicked join mini harrods");
            WebHandlers.Instance.Click(btnSaveChanges);
            //WebHandlers.Instance.Click(driver.FindElement(JoinMiniHarrodsSaveChangesButton("Yes, Save Changes")));
            //Console.WriteLine("!!!!!!!!!!!!!!!!!!!!Clicked save changes");

        }

        public Dictionary<string, Dictionary<string, string>> GetAllCustData(string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> CustDetails = new Dictionary<string, Dictionary<string, string>>();
            CustDetails = DataFilesUtil.GetAllData(fileName, sheetName);

            int totalChildren = CustDetails.Count();
            var result = CustDetails.Where(x => x.Value.Any(y => y.Key == "Email" && y.Value != "")).ToDictionary(x => x.Key, x => x.Value);

            return result;
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

            string child_FirstName = "ChildFirst" + CommonFunctions.GenerateRandomUser(5).ToUpper();
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
            FF_Communication_Pref_Page = new FFUserCommunicationPreferencesPage(driver, config);
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
                FF_Communication_Pref_Page.ConfirmStatus("Your changes have been saved.");
                BrowserDriver.Sleep(3000);
            }
        }

        public void AddMultipleChildInMiniHarrods()
        {
            FF_Communication_Pref_Page = new FFUserCommunicationPreferencesPage(driver, config);
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
                FF_Communication_Pref_Page.ConfirmStatus("Your changes have been saved.");
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
        

        #endregion
    }
}
