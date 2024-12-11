using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TAF_GenericUtility.Scripted.Security;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SCV
{
    public class CustomerSearchPage
    {
        public IWebDriver driver;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region  Constructor

        public CustomerSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		

       
        [FindsBy(How = How.XPath, Using = "//div[@class='Dropdown-placeholder_-oW5B'][@data-test='tenant-searchType-dropdown']")]
        private IWebElement SiteSearch;


        [FindsBy(How = How.XPath, Using = "//li[@class='Dropdown-option_DbG3W'][@data-test='tenant-searchType-dropdown-52000']")] 
        private IWebElement harrodsSandbox;
        [FindsBy(How = How.XPath, Using = "//*[@id='storm - layout - container']/div[2]/div/div/div/form/div/div[2]/div/div/div[2]/div[2]/div[1]/div/div[1]")]
        private IWebElement CustomerSearch;
        [FindsBy(How = How.Id, Using = "search")]
        private IWebElement SearchFor;
        [FindsBy(How = How.XPath, Using = "//*[@id='storm - layout - container']/div[2]/div/div/div/form/div/div[3]/div/div[1]/button")]
        private IWebElement ClearLink;
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Search')]")]
        private IWebElement SearchButton;
        [FindsBy(How = How.XPath, Using = "//button[@data-test='openProfile']//*[name()='svg']")]
        private IWebElement View;
        [FindsBy(How = How.XPath, Using = "//div[@class='wrapper_290Zj']")]
        private IWebElement div;       
        [FindsBy(How = How.XPath, Using = "(//div[@class='wrapper_290Zj']//input)[2]")]
        private IWebElement ConfirmPassword;
        [FindsBy(How = How.XPath, Using = "//div[@id='ModalWrapper']/footer[1]/div[1]/button[1]")]    
        private IWebElement ConfirmLoginButton;

        [FindsBy(How = How.XPath, Using = "//div[contains(@data-test,'customers-searchType-dropdown')]")]
        private IWebElement SearchDropDown;

        #endregion

        #region Events 

        public void CustomerSearchWithParameter(string CustomerDropdownValue, string SearchValue)
        {
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ScrollWebPageToTop();

            BrowserDriver.Sleep(1000);
            if (!SiteSearch.Text.ToUpper().Equals("HARRODS SANDBOX"))
            {  WebHandlers.Instance.Click(SiteSearch);
            WebHandlers.Instance.Click(harrodsSandbox); }
            BrowserDriver.Sleep(1000);

            switch (CustomerDropdownValue.ToUpper())
            {
                case "EMAIL":
                    {
                        log.Info("Search customer order details with email id");
                        if (!SearchDropDown.Text.ToUpper().Equals("EMAIL"))
                        {
                            IWebElement CustomerDropDownValue = WebHandlers.Instance.GetElement(driver, By.XPath("//li[text()='Email']"));
                            WebHandlers.Instance.Click(SearchDropDown);
                            WebHandlers.Instance.WebElementExists(CustomerDropDownValue);
                            WebHandlers.Instance.Click(CustomerDropDownValue);
                        }
                        WebHandlers.Instance.EnterText(SearchFor, SearchValue, $"Entered {SearchValue} for Customer email id");



                        break;
                    }
                case "PORTAL ORDER NUMBER":
                    {
                        log.Info("Search customer order details with portal order number");
                        if (!SearchDropDown.Text.ToUpper().Equals("PORTAL ORDER NUMBER"))
                        {
                            IWebElement CustomerDropDownValue = WebHandlers.Instance.GetElement(driver, By.XPath("//li[text()='Portal Order Number']"));
                            WebHandlers.Instance.Click(SearchDropDown);
                            WebHandlers.Instance.WebElementExists(CustomerDropDownValue);
                            WebHandlers.Instance.Click(CustomerDropDownValue);
                        }
                        WebHandlers.Instance.EnterText(SearchFor, SearchValue, $"Entered {SearchValue} for Customer portal order number");
                        break;
                    }

            }
         
            WebHandlers.Instance.Click(SearchButton);
            WebHandlers.Instance.ClickByJsExecutor(SearchButton);
        }

                public bool viewOrders()
                {
                     log.Info("View order details");
            BrowserDriver.Sleep(3000);
            if (WebHandlers.Instance.WebElementExists(View))
            {
                WebHandlers.Instance.Click(View);
                return true;
            }
            else
                return false;
                   // WebHandlers.Instance.ClickByJsExecutor(View);
                }
                public void confirmPassword(string password)
                {
                    BrowserDriver.Sleep(3000);
                    log.Info("Confirm Password");
            if (WebHandlers.Instance.WebElementExists(ConfirmPassword))
            {
                WebHandlers.Instance.EnterTextInModalPopup(ConfirmPassword, password, "Entered ****** for password");
                BrowserDriver.Sleep(1000);
                WebHandlers.Instance.Click(ConfirmLoginButton);
            }
                }

       
        #endregion

        #region Validation         
        #endregion
    }

        }
        
