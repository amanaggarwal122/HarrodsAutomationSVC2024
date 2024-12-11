using HtmlAgilityPack;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using TAF_GenericUtility.Scripted.Email;
using TAF_Scripting.Test.Common;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SCAYLE
{
    class ScayleUserRegistrationPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private ScayleUserLoginPage SCAYLE_UserLogin_Page = null; 
        #region  Constructor

        public ScayleUserRegistrationPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }
        #endregion

        #region Elements
        [FindsBy(How = How.XPath, Using = "//a[text()='Register']")]
        private IWebElement Register;
        [FindsBy(How = How.XPath, Using = "//a[text()='Sign in']")]
        private IWebElement SignIn;
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title;

        [FindsBy(How = How.Name, Using = "firstName")]
        private IWebElement FirstName;

        [FindsBy(How = How.Name, Using = "lastName")]
        private IWebElement LastName;

        [FindsBy(How = How.Name, Using = "emailAddress")]
        private IWebElement Email;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password;

        [FindsBy(How = How.Name, Using = "confirmPassword")]
        private IWebElement PasswordConfirm;

        //[FindsBy(How = How.Name, Using = "//input[@name='rewards_cardNumber']")]
        //private IWebElement Rewardcardnumber;
        
        [FindsBy(How = How.Id, Using = "rewardsProgramForm-rewardsCardNumber")]
        private IWebElement RewardNumber;

        [FindsBy(How = How.XPath, Using = "//label/div[contains(text(),'like to join')]")]
        private IWebElement JoinRewards;

        //[FindsBy(How = How.XPath, Using = "//input[(@type='radio')]//parent::label[contains(text(),'not interested')]//input")]
        [FindsBy(How = How.XPath, Using = "//label/div[contains(text(),'not interested')]")]
        private IWebElement JoinNonRewards;


        //[FindsBy(How = How.XPath, Using = "//input[(@type='radio')]//parent::label[contains(text(),'already a Member')]//input")]
        //private IWebElement ExistingRewards;
        [FindsBy(How = How.XPath, Using = "//*[@id='root']/main/div/div[2]/div[2]/div/form/div[7]/div[2]/label/div")]
        private IWebElement ExistingRewards;

        [FindsBy(How = How.XPath, Using = "//input[@name='rewards_cardNumber']")]
        private IWebElement RewardcardNumberEntering;

        [FindsBy(How = How.Name, Using = "allowEmail")]
        private IWebElement chkConsent;

        [FindsBy(How = How.XPath, Using = "//Button[text()='Complete Registration']")]
        private IWebElement CompleteRegistration;

        [FindsBy(How = How.XPath, Using = "//div/p[1][contains(text(),'sent an email with a verification link')]")]
        private IWebElement RegistrationSuccessfullMessage;

        [FindsBy(How = How.XPath, Using = "//UL[@data-test='addressBook-list-container']//li[1]//div//p[@data-test='address-addressLine1']")]
        public IWebElement FirstAddressLine1;
        [FindsBy(How = How.XPath, Using = "//UL[@data-test='addressBook-list-container']//li[2]//div//p[@data-test='address-addressLine1']")]
        public IWebElement SecondAddressLine1;

        #endregion
        #region Events
        public void InvokeRegistrationProcessOnScayle()
        {
            SCAYLE_UserLogin_Page = new ScayleUserLoginPage(driver, config);
            WebHandlers.Instance.ClickByJsExecutor(Register, "Register");
            BrowserDriver.Sleep(3000);
            SCAYLE_UserLogin_Page.ClickOnAcceptAndContinue();
        }

        public void InvokeSignInProcessafterRegisterationOnScayle()
        {
            WebHandlers.Instance.ClickByJsExecutor(SignIn, "Sign In");
            BrowserDriver.Sleep(4000);
            /*WebHandlers.Instance.EnterText(loginEmail, Email, $"Entered {Email} for login email");
            WebHandlers.Instance.EnterText(loginPassword, Password, $"Entered ******** for password");
            WebHandlers.Instance.ClickByJsExecutor(Login2, "Login");
            BrowserDriver.Sleep(2000);*/
        }

        public Dictionary<string, Dictionary<string, string>> GetAllCustomerAsPerCategory(string UserCategory, string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> CustomerDetails = new Dictionary<string, Dictionary<string, string>>();
            CustomerDetails = DataFilesUtil.GetAllData(fileName, sheetName);

            int totalCustomers = CustomerDetails.Count();
            var result = CustomerDetails.Where(x => x.Value.Any(y => y.Key == "UserCategory" && y.Value == UserCategory)).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }

        public void CompleteRegistrationProcessOnScayle()
        {
            WebHandlers.Instance.ClickByJsExecutor(CompleteRegistration);
            // log.Info("Submit Registration");
        }

        public string[] spiltName(string Fullname)
        {
            string[] name = Fullname.Split(' ');

            return name;
        }

        public void ConfirmRegistrationCompletedOnScayle(string customerEmail)
        {
            BrowserDriver.Sleep(7000);
            string message = RegistrationSuccessfullMessage.Text;
            if (!WebHandlers.Instance.ContainsText(message, customerEmail))
            {
                Assert.Fail("Registration not successfull");
                return;
            }
            ///*
            //log.Info("Completed Registration");
        }
        public DateTime RegisterUserOnScayle(Dictionary<string, string> customerdata)
        {
            string password = config.FFCustomerPassword;

            //Providing user details for registration
            //log.Info("Register Customer");
            //BrowserDriver.Sleep(5000);
            WebHandlers.Instance.WaitForPageLoad();
            WebHandlers.Instance.MultiSelectByText(Title, customerdata["Title"], "Selected the Title"); //commented until the issue is fixed - 07.08.23
            WebHandlers.Instance.EnterText(FirstName, customerdata["FirstName"], $"Entered FirstName");
            WebHandlers.Instance.EnterText(LastName, customerdata["LastName"], $"Entered LastName");
            WebHandlers.Instance.EnterText(Email, customerdata["Email"], $"Entered Email");
            WebHandlers.Instance.EnterText(Password, password, $"Entered ******* for Password");
            WebHandlers.Instance.EnterText(PasswordConfirm, password, $"Entered ******* for PasswordConfirm");

            //Providing rewards program as per user status
            if (customerdata["JoinRewards"].ToUpper().Contains("NOTINTERESTED"))
            {
                WebHandlers.Instance.Click(JoinNonRewards);
               // log.Info("Registering as NonRewards Customer?");
            }
            else if (customerdata["JoinRewards"].ToUpper().Contains("EXISTINGREWARDS"))
            {
                WebHandlers.Instance.Click(ExistingRewards);
                // log.Info("Registering as  Existing Rewards Customer?");
                BrowserDriver.Sleep(2000);
                //WebHandlers.Instance.Click(Rewardcardnumber);
                driver.FindElement(By.XPath("//input[@name='rewards_cardNumber']")).Click();
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.EnterText(RewardcardNumberEntering, customerdata["CardNumber"], $"Entered Reward Card Number");
                Console.WriteLine("Reward Number is : " + customerdata["CardNumber"]);

            }
            else
            {
                WebHandlers.Instance.Click(JoinRewards);
                //log.Info("Registering as  Rewards Customer?");
            }

            //Providing email consent as per user interest
            if (customerdata["EmailConsent"].ToUpper().Contains("YES"))
            {
                WebHandlers.Instance.Click(chkConsent);
            }

            //Completing registaration preocedd and verifying confirmation message
            WebHandlers.Instance.WaitForPageLoad();
            CompleteRegistrationProcessOnScayle();
            DateTime registrationCompltedTime = DateTime.Now;

            WebHandlers.Instance.WaitForPageLoad();
            ConfirmRegistrationCompletedOnScayle(customerdata["Email"]);
            BrowserDriver.Sleep(2000);
            return registrationCompltedTime;
        }

        public Dictionary<string, Dictionary<string, string>> GetAllCustomersForReg(string fileName)
        {
            Dictionary<string, Dictionary<string, string>> CustomerDetails = new Dictionary<string, Dictionary<string, string>>();
            CustomerDetails = DataFilesUtil.GetAllData(fileName, "CustomerPersonalDetails");

            int totalCustomers = CustomerDetails.Count();
            var result = CustomerDetails.Where(x => x.Value.Any(y => y.Key == "Email" && y.Value == ""))
             .ToDictionary(x => x.Key, x => x.Value);

            return result;
        }

        #endregion
    }
}
