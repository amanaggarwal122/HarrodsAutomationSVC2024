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

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.FF
{
    class FFUserRegistrationPage
    {
        public IWebDriver driver;
        private Configuration config = null;        

        #region  Constructor

        public FFUserRegistrationPage(IWebDriver driver, Configuration configuration)
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
        [FindsBy(How = How.Id, Using = "registerForm-title-select")]
        private IWebElement Title;

        [FindsBy(How = How.Id, Using = "registerForm-firstName")]
        private IWebElement FirstName;

        [FindsBy(How = How.Id, Using = "registerForm-lastName")]
        private IWebElement LastName;

        [FindsBy(How = How.Id, Using = "registerForm-email")]
        private IWebElement Email;

        [FindsBy(How = How.Id, Using = "registerForm-password")]
        private IWebElement Password;

        [FindsBy(How = How.Id, Using = "registerForm-passwordConfirmation")]
        private IWebElement PasswordConfirm;

        [FindsBy(How = How.Id, Using = "rewardsProgramForm-rewardsCardNumber")]
        private IWebElement RewardNumber;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'like to join')]/input")]
        private IWebElement JoinRewards;

        [FindsBy(How = How.XPath, Using = "//input[(@type='radio')]//parent::label[contains(text(),'not interested')]//input")]
        private IWebElement JoinNonRewards;

        [FindsBy(How = How.XPath, Using = "//input[(@type='radio')]//parent::label[contains(text(),'already a Member')]//input")]
        private IWebElement ExistingRewards;

        [FindsBy(How = How.Id, Using = "registerForm-newsletter")]
        private IWebElement chkConsent;

        [FindsBy(How = How.XPath, Using = "//Button[text()='Complete Registration']")]
        private IWebElement CompleteRegistration;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'sent an email with a verification link')]")]
        private IWebElement RegistrationSuccessfullMessage;

        [FindsBy(How = How.XPath, Using = "//UL[@data-test='addressBook-list-container']//li[1]//div//p[@data-test='address-addressLine1']")]
        public IWebElement FirstAddressLine1;
        [FindsBy(How = How.XPath, Using = "//UL[@data-test='addressBook-list-container']//li[2]//div//p[@data-test='address-addressLine1']")]
        public IWebElement SecondAddressLine1;

        #endregion
        #region Events
        public void InvokeRegistrationProcess()
        {
            WebHandlers.Instance.ClickByJsExecutor(Register, "Register");
        }

        public void InvokeSignInProcessafterRegisteration()
        {
            WebHandlers.Instance.ClickByJsExecutor(SignIn, "Sign In");
            BrowserDriver.Sleep(4000);
            /*WebHandlers.Instance.EnterText(loginEmail, Email, $"Entered {Email} for login email");
            WebHandlers.Instance.EnterText(loginPassword, Password, $"Entered ******** for password");
            WebHandlers.Instance.ClickByJsExecutor(Login2, "Login");
            BrowserDriver.Sleep(2000);*/
        }

        public string EnterCustomerDetails(Dictionary<string, string> customerdetails)
        {
            string customerID = customerdetails["CustomerID"];
            string title = customerdetails["Title"];
            string firstName = customerdetails["FirstName"];
            string lastName = customerdetails["LastName"];
            string customerType = customerdetails["CustomerType"];
            string consent = customerdetails["Consent"];
            string email = "Testharrods" +
   (customerType.ToUpper() == "NEWREWARDS" ? "rew" : customerType.ToUpper() == "NONREWARDS" ? "nonrew" : "rewexs") +
   (consent.ToUpper() == "NO" ? "noc" : "con") + customerID.ToString() + "@harrods.com";

            string password = config.FFCustomerPassword;
            string rewardCardNo = customerdetails["RewardCardNo"];

            WebHandlers.Instance.MultiSelectByText(Title, title, "Selected the Title");
            WebHandlers.Instance.EnterText(FirstName, firstName, $"Entered {firstName} for FirstName");
            WebHandlers.Instance.EnterText(LastName, lastName, $"Entered {lastName} for LastName");
            WebHandlers.Instance.EnterText(Email, email, $"Entered {email} for Email");
            WebHandlers.Instance.EnterText(Password, password, $"Entered ******* for Password");
            WebHandlers.Instance.EnterText(PasswordConfirm, password, $"Entered ******* for PasswordConfirm");
            if (customerType.ToUpper().Contains("NONREWARDS"))
            {
                WebHandlers.Instance.Click(JoinNonRewards);
                //log.Info("Registering as NonRewards Customer?");
            }
            else if (customerType.ToUpper().Contains("EXISTINGREWARDS"))
            {
                WebHandlers.Instance.Click(ExistingRewards);
                //log.Info("Registering as  Existing Rewards Customer?");

                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.EnterText(RewardNumber, rewardCardNo, $"Entered {rewardCardNo} for Reward Card Number");

            }
            else
            {
                WebHandlers.Instance.Click(JoinRewards);
               // log.Info("Registering as  Rewards Customer?");
            }

            if (consent.ToUpper().Contains("YES"))
            {
                WebHandlers.Instance.Click(chkConsent);
            }

            return email;
        }
        public void CompleteRegistrationProcess()
        {
            WebHandlers.Instance.ClickByJsExecutor(CompleteRegistration);
           // log.Info("Submit Registration");
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

        public Dictionary<string, Dictionary<string, string>> GetAllCustomerAsPerCategory(string UserCategory, string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> CustomerDetails = new Dictionary<string, Dictionary<string, string>>();
            CustomerDetails = DataFilesUtil.GetAllData(fileName, sheetName);

            int totalCustomers = CustomerDetails.Count();
            var result = CustomerDetails.Where(x => x.Value.Any(y => y.Key == "UserCategory" && y.Value == UserCategory)).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }

        public Dictionary<string, Dictionary<string, string>> GetCustomerDataAsPerRowheader(string ColumnTitle, string Rownum, string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> CustomerDetails = new Dictionary<string, Dictionary<string, string>>();
            CustomerDetails = DataFilesUtil.GetAllData(fileName, sheetName);

            int totalCustomers = CustomerDetails.Count();
            var result = CustomerDetails.Where(x => x.Value.Any(y => y.Key == ColumnTitle && y.Value == Rownum)).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }

        public Dictionary<string, Dictionary<string, string>> GetAllCustomersForReg(string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> CustomerDetails = new Dictionary<string, Dictionary<string, string>>();
            CustomerDetails = DataFilesUtil.GetAllData(fileName, sheetName);

            int totalCustomers = CustomerDetails.Count();
            var result = CustomerDetails.Where(x => x.Value.Any(y => y.Key == "Email" && y.Value != "")).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }
        public Dictionary<string, Dictionary<string, string>> GetAllProductsForOrder(string fileName, string sheetName)
        {
            Dictionary<string, Dictionary<string, string>> ProductDetails = new Dictionary<string, Dictionary<string, string>>();
            ProductDetails = DataFilesUtil.GetAllData(fileName, sheetName);

            int totalCustomers = ProductDetails.Count();
            var result = ProductDetails.Where(x => x.Value.Any(y => y.Key == "ProductId" && y.Value != "")).ToDictionary(x => x.Key, x => x.Value);

            return result;
        }
        #endregion

        #region Validation         

        public void ConfirmRegistrationCompleted(string customerEmail)
        {
            string message = RegistrationSuccessfullMessage.Text;
            if (!WebHandlers.Instance.ContainsText(message, customerEmail))
            {
                Assert.Fail("Registration not successfull");
                return;
            }
            ///*
            //log.Info("Completed Registration");
        }

        public void ConfirmViaEmail(DateTime registrationCompltedTime)
        {

            GoogleApiClient client = new GoogleApiClient(config.EmailRegisteredAppName, config.EmailUserName, config.EmailCredentialFilePath);
            Console.WriteLine("Completed time ==> " + registrationCompltedTime);
            Console.WriteLine("Appname ==> " + config.EmailRegisteredAppName);
            Console.WriteLine("Username ==> " + config.EmailUserName);
            Console.WriteLine("FilePath ==> " + config.EmailCredentialFilePath);
            client.Connect();

            List<MailItem> mailItems = client.GetEmailsFromInBox(false, 2, config.EmailRegistrationFilter);
            string body = string.Empty;
            foreach (MailItem item in mailItems)
            {

                //                DateTime MailDate  = item.MailDate.Value.AddMilliseconds(-item.MailDate.Value.Millisecond);
                DateTime MailDate = item.MailDate.Value.AddSeconds(-item.MailDate.Value.Second);
                Console.WriteLine("Mail Date value --> " + MailDate.ToString());
                //registrationCompltedTime = registrationCompltedTime.AddMilliseconds(-registrationCompltedTime.Millisecond);
                registrationCompltedTime = registrationCompltedTime.AddSeconds(-registrationCompltedTime.Second);
                Console.WriteLine("Registration Date value --> " + registrationCompltedTime.ToString());
                int res = DateTime.Compare(MailDate, registrationCompltedTime);
                //int res = String.Compare(MailDate.ToShortTimeString(), registrationCompltedTime.ToShortTimeString());
                /*<0 − If date1 is earlier than date2
                    0 − If date1 is the same as date2
                    >0 − If date1 is later than date2*/
                Console.WriteLine("Mail Subject --> " + item.Subject);
                Console.WriteLine("Res count --> " + res.ToString());
                if (res == 0 || res < 0)
                {
                    body = mailItems.FirstOrDefault().HTMLBody;
                    if (body.Contains("Confirm Email"))
                    {
                        break;
                    }
                }
                BrowserDriver.Sleep(5000);
            }

            var confirmLink = string.Empty;
            BrowserDriver.Sleep(10000);
            if (body.Contains("Confirm Email"))
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(body);
                confirmLink = doc.DocumentNode.SelectSingleNode("//a[text()='Confirm Email']")
              .Attributes["href"].Value;

                confirmLink = confirmLink.Replace('"', ' ').Trim();
                IList<string> validLink = confirmLink.Split('&');
                IList<string> validToken = validLink[1].Split(';');
                confirmLink = validLink[0] + "=" + validToken[1];
            }
            if (string.IsNullOrEmpty(confirmLink))
            {
                WebHandlers.Instance.ExecuteScript("window.promptResponse=prompt('System could not find confirm email at " + registrationCompltedTime + " Please enter the url manually')");
                //System.Windows.Forms.MessageBox.Show("Please enter the validation email url manually on prompt window then click Ok");
                BrowserDriver.Sleep(15000);
                confirmLink = (String)WebHandlers.Instance.ExecuteScript("return window.promptResponse");
            }

            if (!string.IsNullOrEmpty(confirmLink))
            {
                confirmLink = CommonFunctions.RewriteFarfetchUrl(confirmLink, config);
                WebHandlers.Instance.ExecuteScript("window.open()", null);

                string currentWindowHandle = driver.CurrentWindowHandle;
                List<String> tabs = new List<String>(driver.WindowHandles);
                driver.SwitchTo().Window(tabs[1]);
                BrowserDriver.LaunchWebURL(confirmLink);
                BrowserDriver.Sleep(3000);
                //log.Info("Registration Confirmed via Email");
            }
            else
            {
                Assert.Fail("No registration email found");
            }
        }



        public Tuple<string, DateTime> RegisterCustomer(Dictionary<string, string> customerdata)
        {
            //log.Info("Register Customer");
            WebHandlers.Instance.WaitForPageLoad();
            string customerEmail = EnterCustomerDetails(customerdata);
            string customerID = customerdata["CustomerID"];

            WebHandlers.Instance.WaitForPageLoad();
            CompleteRegistrationProcess();
            DateTime registrationCompltedTime = DateTime.Now;
            DataFilesUtil.SaveDataToExcel("CustomerRegistration", "CustomerPersonalDetails", "Email", customerID, customerEmail);
            DataFilesUtil.SaveDataToExcel("CustomerRegistration", "CustomerPersonalDetails", "CreatedDateTime", customerID, DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            WebHandlers.Instance.WaitForPageLoad();
            ConfirmRegistrationCompleted(customerEmail);

            return new Tuple<string, DateTime>(customerEmail, registrationCompltedTime);
        }

        /// <summary>
        /// Function to register a user form harrods.com
        /// </summary>
        /// <param name="customerdata">User data for registation</param>
        public DateTime RegisterUser(Dictionary<string, string> customerdata)
        {
            string password = config.FFCustomerPassword;

            //Providing user details for registration
            //log.Info("Register Customer");
            //BrowserDriver.Sleep(5000);
            WebHandlers.Instance.WaitForPageLoad();
            //WebHandlers.Instance.MultiSelectByText(Title, customerdata["Title"], "Selected the Title"); //commented until the issue is fixed - 07.08.23
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
                WebHandlers.Instance.EnterText(RewardNumber, customerdata["CardNumber"], $"Entered Reward Card Number");
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
            CompleteRegistrationProcess();
            DateTime registrationCompltedTime = DateTime.Now;

            WebHandlers.Instance.WaitForPageLoad();
            ConfirmRegistrationCompleted(customerdata["Email"]);
            BrowserDriver.Sleep(2000);
            return registrationCompltedTime;
        }

        #endregion
    }
}
