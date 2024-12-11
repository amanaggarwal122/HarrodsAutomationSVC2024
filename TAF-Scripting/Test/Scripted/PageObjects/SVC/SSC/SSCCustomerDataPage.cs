using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerDataPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        public SSCCustomersPage SSC_Customers_Page = null;

        #region  Constructor
        public SSCCustomerDataPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
            
        }

        #endregion

        #region Elements 
        [FindsBy(How = How.XPath, Using = "//div[text()='Customer Data']")]
        private IWebElement SSCCustomersSubtabCustomerData;
        [FindsBy(How = How.XPath, Using = "//div[text()='Preferences']")]
        private IWebElement SSCCustomersSubtabPreferences;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Mini Harrods Is Enroled']/..//following-sibling::div//span")]
        private IWebElement MiniHarrodsEnrolled;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'inputfield3fa290bb8e1a22fe0d86afd4640e1bc8')]")]
        private IWebElement SSCCustomerCDCID;

        #endregion
        public By SSCSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        public By SSCUserFieldData(string FieldLabel) { return By.XPath("//bdi[text()='" + FieldLabel + "']/following::span[1]"); }
        public By SpanSSCContainsText(string text) { return By.XPath("(//span[contains(text(),'" + text + "')])[1]"); }
        public By SSCCustomersGridData(string text) { return By.XPath("//a[text()='" + text + "']"); }
        public By SSCCustomersInterest(string text)
        {
            return By.XPath("//span[text()='" + text + "']/../../following-sibling::td[1]/div/span");
        }
        #region Events
        public void SearchQatariCustomerandValidateonSSC(string username, string email, string discountceilvalue, string bandgrade)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            BrowserDriver.Sleep(25000);
            SSC_Customers_Page.SearchCustomerOnSSC(username, email);
            BrowserDriver.Sleep(3000);

            //moving to customer data tab
            WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
            BrowserDriver.Sleep(3000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(110000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(110000);
            driver.Navigate().Refresh();
            WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
            BrowserDriver.Sleep(3000);
            string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
            string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
            string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
            string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
            string isqataristatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Qatari Holdings']/following::div[1]")));
            //string isemployeestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Employee']/following::div[1]")));



            Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
            //As per defect BUG 128432  "Is Registered" flag is only for Employees for all other customers it will be displaying as No
            Assert.IsTrue(isregisteredstatus.Equals("No"), "The Customer is not registered");
            Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
            Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");
            Assert.IsTrue(isqataristatus.Equals("Yes"), "The Customer is not under qatari holdings");
            BrowserDriver.Sleep(3000);
            //moving to preferences tab
            WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
            BrowserDriver.Sleep(3000);
            string bandgrade_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Band / Grade (Qatari Holding)']/following::div[1]/label")));
            string discountceil_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Discount ceiling (Pound Sterling)']/following::div[1]")));
            Assert.IsTrue(bandgrade_displayed.Contains(bandgrade), "The Customer is not having band grade");
            Assert.IsTrue(discountceil_displayed.Contains(discountceilvalue), "The discount ceil value is incorrect");
        }

        public void SearchAlFaydaCustomerandValidateonSSC(string username, string email, string discountceilvalue, string bandgrade)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            SSC_Customers_Page.SearchCustomerOnSSC(username, email);
            BrowserDriver.Sleep(25000);

            //moving to customer data tab
            //WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
            SSCCustomersSubtabCustomerData.Click();
            BrowserDriver.Sleep(110000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(10000);
            driver.Navigate().Refresh();
            WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSubtabCustomerData);
            BrowserDriver.Sleep(60000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(3000);
            SSCCustomersSubtabCustomerData.Click();
            BrowserDriver.Sleep(3000);
            string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
            string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
            string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
            string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
            string isalfayadstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Al Fayed Family']/following::div[1]")));
            //string isemployeestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Employee']/following::div[1]")));

            Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
            //As per defect BUG 128432  "Is Registered" flag is only for Employees for all other customers it will be displaying as No
            Assert.IsTrue(isregisteredstatus.Equals("No"), "The Customer is not registered");
            Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
            //Assert.IsTrue(isDiscountstatus.Equals("No"), "The Customer does not have discount");
            Assert.IsTrue(isalfayadstatus.Equals("Yes"), "The Customer is not under al fayad family");
            BrowserDriver.Sleep(3000);
            //moving to preferences tab
            WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
            BrowserDriver.Sleep(3000);
            string bandgrade_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Band / Grade (Al Fayed family)']/following::div[1]/label")));
            //string discountceil_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Discount ceiling (Pound Sterling)']/following::div[1]")));
            Assert.IsTrue(bandgrade_displayed.Contains(bandgrade), "The Customer is not having band grade");
            //Assert.IsTrue(discountceil_displayed.Contains(discountceilvalue), "The Customer is not under al fayda family");


        }

        public void SearchPressPersonandValidateonSSC(string username, string email, string discountceilvalue)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            SSC_Customers_Page.SearchCustomerOnSSC(username, email);
            BrowserDriver.Sleep(25000);

            //moving to customer data tab
            //WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
            SSCCustomersSubtabCustomerData.Click();
            BrowserDriver.Sleep(75000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(10000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(3000);
            WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSubtabCustomerData);
            SSCCustomersSubtabCustomerData.Click();
            BrowserDriver.Sleep(3000);
            string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
            string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
            string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
            string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
            // string isemployeestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Employee']/following::div[1]")));

            Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
            //As per defect BUG 128432  "Is Registered" flag is only for Employees for all other customers it will be displaying as No
            Assert.IsTrue(isregisteredstatus.Equals("No"), "The Customer is not registered");
            Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
            Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");

            //moving to preferences tab
            WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
            BrowserDriver.Sleep(3000);
            string discountvalue_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Press Discount']/following::div[1]")));
            Assert.IsTrue(discountvalue_displayed.Contains("20% Press discount"), "The Customer is not a press person");
        }
        //TC_94
        public void SearchInteriorDesignPersonandValidateonSSC(string username, string email, string discountceilvalue)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            SSC_Customers_Page.SearchCustomerOnSSC(username, email);
            BrowserDriver.Sleep(55000);
            SSCCustomersSubtabCustomerData.Click();
            BrowserDriver.Sleep(75000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(50000);
            driver.Navigate().Refresh();
            BrowserDriver.Sleep(3000);
            WebWaitHelper.Instance.WaitForElementPresence(SSCCustomersSubtabCustomerData);
            SSCCustomersSubtabCustomerData.Click();
            BrowserDriver.Sleep(3000);
            string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
            string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
            string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
            string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
            // string isemployeestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Employee']/following::div[1]")));

            Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
            //As per defect BUG 128432  "Is Registered" flag is only for Employees for all other customers it will be displaying as No
            Assert.IsTrue(isregisteredstatus.Equals("No"), "The Customer is not registered");
            Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
            Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");

            //moving to preferences tab
            WebHandlers.Instance.Click(SSCCustomersSubtabPreferences);
            BrowserDriver.Sleep(3000);
            string discountvalue_displayed = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Interior Designer']/following::div[1]")));
            Assert.IsTrue(discountvalue_displayed.Contains("20% Interior Designer discount"), "The Customer is not a Interior Design person");
        }

        //TC_95
        public void SearchandValidateSpouseofStaffinSSC(string spousename, string username, string email)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            try
            {
                SSC_Customers_Page.SearchCustomerOnSSC(username, email);
                BrowserDriver.Sleep(45000);

                //moving to customer data tab
                WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
                BrowserDriver.Sleep(3000);
                driver.Navigate().Refresh();
                BrowserDriver.Sleep(25000);
                driver.Navigate().Refresh();
                WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
                BrowserDriver.Sleep(25000);
                driver.Navigate().Refresh();
                WebHandlers.Instance.Click(SSCCustomersSubtabCustomerData);
                BrowserDriver.Sleep(3000);
                string isactivestatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='IsActive']/following::div[1]")));
                //string isregisteredstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Registered']/following::div[1]")));
                string isverifiedstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Verified']/following::div[1]")));
                string isDiscountstatus = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Discount Eligible']/following::div[1]")));
                string isSpouseCivil = WebHandlers.Instance.GetTextOfElement(driver.FindElement(By.XPath("//*[text()='Is Spouse/Is Civil Partner']/following::div[1]")));



                Assert.IsTrue(isactivestatus.Equals("Yes"), "The Customer is not active");
                //Assert.IsTrue(isregisteredstatus.Equals("Yes"), "The Customer is not registered");
                Assert.IsTrue(isverifiedstatus.Equals("Yes"), "The Customer is not verified");
                Assert.IsTrue(isDiscountstatus.Equals("Yes"), "The Customer does not have discount");
                Assert.IsTrue(isSpouseCivil.Equals("Yes"), "The Customer is not a spouse of a reward member");
                BrowserDriver.Sleep(3000);
            }
            catch (Exception e)
            {
                Assert.Fail("The user is not found in SSC");
            }

        }

        public void VerifyBBUserDetailsAndVerifiedStatusOnSSC(string UserName, string Email, string Phone)
        {
            SSC_Customers_Page = new SSCCustomersPage(driver, config);
            string FullName = UserName + " " + UserName + "Lname";

            //Validating verified status for the user
            SSC_Customers_Page.SearchLiteCustomerOnSSC(FullName, Email);
            BrowserDriver.Sleep(9000);
            WebHandlers.Instance.Click(driver.FindElement(SSCSubTabs("Customer Data")));
            BrowserDriver.Sleep(9000);
            Assert.AreEqual("Yes", driver.FindElement(SSCUserFieldData("Is Verified")).GetAttribute("innerText"), "User verified status is not showing as expected");
            Assert.IsTrue(driver.FindElement(SpanSSCContainsText(Phone)).Displayed, Phone + " - Expected phone number not showing on the grid");
            Assert.IsTrue(driver.FindElement(SpanSSCContainsText(FullName)).Displayed, FullName + " - Expected user not showing on the grid");
            Assert.IsTrue(driver.FindElement(SSCCustomersGridData(Email)).Displayed, Email + " - Expected email not showing on the grid");
        }

        public void validateMiniHarrodsPresentSSC()
        {
            //bdi[text()='Mini Harrods Is Enroled']/..//following-sibling::div//span
            SSCCustomersSubtabCustomerData.Click();
            BrowserDriver.PageWait();
            BrowserDriver.Sleep(5000);
           // Assert.AreEqual("Yes", MiniHarrodsEnrolled.Text, " Mini Harrods is not enrolled ");

        }
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
            validateMiniHarrodsPresentSSC();
        }

        #endregion
    }
}
