using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;

namespace TAF_Scripting.Test.Scripted.PageObjects.SCV
{
    
   public class SCVLoginPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private CustomerSearchPage CustomerSearchPage = null;
        private CustomerProfilePage CustomerProfilePage = null;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Elements		

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement Username;
        [FindsBy(How = How.XPath, Using = "/html/body/main[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[3]/button[1]/span[1]")]
        private IWebElement span_LoginButton;
        //[FindsBy(How = How.XPath, Using = "/html/body/main[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[3]/button[1]")]
        ///html/body/main/div/div/div[2]/div[1]/form/div[3]/button
        ////html/body/main/div/div/div[2]/div[1]/form/div[3]/button
        [FindsBy(How = How.XPath, Using = "/html/body/main/div/div/div[2]/div[1]/form/div[3]/button")]
        private IWebElement LoginButton;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Password;

        #endregion

        #region  Constructor


        public SCVLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = new Configuration().Init();
        }

        #endregion

        
        #region Events 


        //public void LoginToSCV()
        //{
        //    //BrowserDriver.GetCuPalDriver();
        //    //driver = BrowserDriver.GetDriver();

        //    BrowserDriver.LaunchWebURL(config.SCVUrl);
            
        //    log.Info("SCV login");
        //    Login(config.SCVUserName, config.SCVPassword);

        //    CustomerSearchPage = new CustomerSearchPage(driver);
        //    CustomerSearchPage.CustomerSearchWithEmail("TestAutomation_10142020.082858@harrods.com");
        //    CustomerSearchPage.viewOrders();
        //    CustomerSearchPage.confirmPassword(config.SCVPassword);

        //    CustomerProfilePage = new CustomerProfilePage(driver);
        //    CustomerProfilePage.ClickCreateOrder();
        //    CustomerProfilePage.checkOut();
        //  //  CustomerSearchPage.NewAddress();
        //   // CustomerSearchPage.AddNewAddress();
        //    //BrowserDriver.CloseBrowser();
        //}

        public void Login(string userName, string password)
        {
            WebHandlers.Instance.EnterText(Username, userName, $"Entered {userName} for user name");
            WebHandlers.Instance.EnterText(Password, password, $"Entered ****** for password");
          //  BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(LoginButton, "Login");
        }
        #endregion

        #region Validation         
        #endregion
    }

}

