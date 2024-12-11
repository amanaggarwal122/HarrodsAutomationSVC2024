using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using TAF_Web.Scripted.Web;


namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerMergePage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor
        public SSCCustomerMergePage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements 
        [FindsBy(How = How.XPath, Using = "//button[@title='Create']//span[contains(@id,'button')][contains(@id,'-img')]")]
        private IWebElement SSCCreateButton;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Name']/following::input[1]")]
        private IWebElement SSC_CustomerMergerName;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='First Customer']/following::input[1]")]
        private IWebElement SSC_Customer_MergeUserName1;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Second Customer']/following::input[1]")]
        private IWebElement SSC_Customer_MergeUserName2;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save and Open']")]
        private IWebElement SSC_SaveOpen_Btn;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'-searchButton-img')]")]
        private IWebElement SSCCustomersSearchIcon;
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'-searchField-I')]")]
        private IWebElement SSCCustomersSearchEdit;
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'buttonbuttonCLIENT_GENERATED_ThingAction_DisplayEditToggle')][contains(@id,'img')]")]
        private IWebElement SSCDetailsEditIcon;
        [FindsBy(How = How.XPath, Using = "//*[text()='Save']")]
        private IWebElement SSCSaveButton;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Actions'][contains(@id,'button')]")]
        private IWebElement SSC_Actions_Btn;
        [FindsBy(How = How.XPath, Using = "//bdi[text()='Initiate Merge'][contains(@id,'navigationitem')]")]
        private IWebElement SSC_Initiate_Merge_Menu;
        #endregion

        #region Events
        public void MergeActiveUsersinSSC(string Mergeusername1, string Mergeusername2)
        {
            BrowserDriver.Sleep(3000);
            SSCCreateButton.Click();
            DateTime datetime = DateTime.Now;
            string mergername = "Test Merge_" + datetime.ToString("dd.MM.yyyy") + "_" + CommonFunctions.GetRandomNumber(2);
            BrowserDriver.Sleep(3000);

            SSC_CustomerMergerName.SendKeys(mergername);
            SSC_Customer_MergeUserName1.SendKeys(Mergeusername1);
            SSC_Customer_MergeUserName2.SendKeys(Mergeusername2);
            WebHandlers.Instance.Click(SSC_SaveOpen_Btn);
        }

        public void ValidateDeemeduserinSSC(string Mergeusername2, string Username2Email)
        {
            try { SSCCustomersSearchIcon.Click(); }
            catch { WebHandlers.Instance.ExecuteScript("arguments[0].click();", SSCCustomersSearchIcon); }
            BrowserDriver.Sleep();
            WebHandlers.Instance.EnterText(SSCCustomersSearchEdit, Mergeusername2 + "\n");
            BrowserDriver.Sleep(3000);
            int searcherror = driver.FindElements(By.XPath("//*[text()='No results found. Search again in all items?']")).Count();
            if (searcherror > 0)
            {
                driver.FindElement(By.XPath("//*[text()='No results found. Search again in all items?']")).Click();
            }

            Assert.IsTrue(driver.FindElement(By.XPath("//*[text()='No data'][@class='sapMListTblCell sapMListTblCellNoData']")).Displayed, "The User is still found in Customer Base");

        }

        public void EditAttributeofSurvivingCustomer()
        {
            WebHandlers.Instance.Click(SSCDetailsEditIcon);
            ReadOnlyCollection<IWebElement> Surviving_Customer = driver.FindElements(By.XPath("//table[2]/tbody[1]/tr/td[3]/div[1]/div[1]/div[1]/div[1]/div[1]"));
            int attribute_count = Surviving_Customer.Count();
            for (int i = 0; i < attribute_count; i++)
            {
                try
                {
                    WebHandlers.Instance.Click(driver.FindElement(By.XPath("(//table[2]/tbody[1]/tr/td[3]/div[1]/div[1]/div[1]/div[1]/div[1])[" + i + "]")));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in element " + Surviving_Customer[i]);
                }
            }
            WebHandlers.Instance.Click(SSCSaveButton);
        }

        public void InitateCustomerMerge()
        {
            try
            {
                WebHandlers.Instance.Click(SSC_Actions_Btn);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(SSC_Initiate_Merge_Menu);
            }
            catch
            {
                WebHandlers.Instance.Click(SSC_Actions_Btn);
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.Click(SSC_Initiate_Merge_Menu);
            }

        }
        #endregion
    }
}
