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
using TAF_GenericUtility.Scripted.Email;
using HtmlAgilityPack;
using TAF_Scripting.Test.Common;
using TAF_Scripting.Test.Scripted.StepDefinitions;
using TAF_Web.Scripted.Web.BrowserOptions;
using Keys = System.Windows.Forms.Keys;
using OpenQA.Selenium.Support.UI;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.IDS
{
    class IDSHomePage
    {

        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public IDSHomePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements

        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement IDSLoginEmail;

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement IDSLoginPassword;

        [FindsBy(How = How.XPath, Using = "//input[@type='submit']")]
        private IWebElement IDSSignInbtn;

        [FindsBy(How = How.Id, Using = "RewardsCard")]
        private IWebElement IDSCustomerRewardsCard;

        [FindsBy(How = How.XPath, Using = "//span[text()='Search']")]
        private IWebElement IDSCustomerRewardsCardSearch;

        [FindsBy(How = How.Id, Using = "Project_Client_Name")]
        private IWebElement IDSProjectClientName;

        [FindsBy(How = How.Id, Using = "Project_Client_RewardsCard")]
        private IWebElement IDSProjectClientRewardsCard;

        [FindsBy(How = How.Id, Using = "Project_Client_SapCustomerId")]
        private IWebElement IDSProjectClientSapCustomerId;

        [FindsBy(How = How.Id, Using = "Project_Client_Telephone")]
        private IWebElement IDSProjectClientTelephone;

        [FindsBy(How = How.XPath, Using = "(//span[text()='Cancel'])[2]")]
        private IWebElement IDSProjectCancel;

        #endregion  

        public By LinkHarrodsText(string Message) { return By.XPath("//a[text()='" + Message + "']"); }

        #region Events

        public void IDSLoginPageGetsDisplayed()
        {
            WebHandlers.Instance.WebElementExists(IDSLoginPassword);
            Assert.IsTrue(IDSLoginPassword.Displayed, "IDS login page not showing");
            Assert.IsTrue(IDSLoginEmail.Displayed, "IDS login username not showing");
        }

        public void LoginToIDSApplication(string UserName, string Password)
        {
            WebHandlers.Instance.EnterText(IDSLoginEmail, UserName);
            IDSLoginPassword.SendKeys(Password);
            WebHandlers.Instance.Click(IDSSignInbtn);
            WebHandlers.Instance.WebElementExists(driver.FindElement(LinkHarrodsText("Home")));
            BrowserDriver.Sleep(3000);
        }

        public void NavigateToIDSCreateNewProject()
        {
            WebHandlers.Instance.Click(driver.FindElement(LinkHarrodsText("Create New Project")));
            WebHandlers.Instance.WebElementExists(IDSCustomerRewardsCard);
            BrowserDriver.Sleep(3000);
        }

        public void PerformCustomerSearchOnIDS(string RewardsCardNumber)
        {
            WebHandlers.Instance.EnterText(IDSCustomerRewardsCard, RewardsCardNumber);
            WebHandlers.Instance.Click(IDSCustomerRewardsCardSearch);
            WebHandlers.Instance.WebElementExists(IDSProjectClientName);
            BrowserDriver.Sleep(3000);
        }

        public void ValidateIDSPopulatedWithUserDetails(string SapId, string UserName, string RewardCard, string Phone)
        {
            Assert.AreEqual(SapId, IDSProjectClientSapCustomerId.GetAttribute("value"), "User SAP id is not showing as expected on IDS");
            Assert.AreEqual(UserName, IDSProjectClientName.GetAttribute("value"), "User name is not showing as expected on IDS");
            Assert.AreEqual(RewardCard, IDSProjectClientRewardsCard.GetAttribute("value"), "User card number is not showing as expected on IDS");
            Assert.AreEqual(Phone, IDSProjectClientTelephone.GetAttribute("value"), "User phone number is not showing as expected on IDS");
            WebHandlers.Instance.Click(IDSProjectCancel);
            BrowserDriver.Sleep(2000);
        }

        #endregion
    }
}
