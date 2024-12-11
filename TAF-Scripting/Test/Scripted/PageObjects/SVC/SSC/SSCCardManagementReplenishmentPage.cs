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
    class SSCCardManagementReplenishmentPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        public SSCUserHomePage SSCUserHomePage = null;

        #region  Constructor
        public SSCCardManagementReplenishmentPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements 
        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[2]")]
        private IWebElement SSC_Replenishment;

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'_42-img')]")]
        private IWebElement SSCCardReplenishAddButton;

        [FindsBy(How = How.XPath, Using = "//*[text()='Card Source']/following::input[1]")]
        private IWebElement SSC_CardSource;

        [FindsBy(How = How.XPath, Using = "//*[@class='sapMListItems sapMListUl sapMListShowSeparatorsNone sapMListModeSingleSelectMaster']/li/..//div[text()='Migration']")]
        private IWebElement SSC_CardSource_Migration;

        [FindsBy(How = How.XPath, Using = "//*[text()='Mapped Range From']/following::input[1]")]
        private IWebElement SSC_MappedRangeFrom;

        [FindsBy(How = How.XPath, Using = "//*[text()='Mapped Range To']/following::input[1]")]
        private IWebElement SSC_MappedRangeTo;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Save & Close']")]
        private IWebElement SSC_SaveClose_Btn;

        [FindsBy(How = How.XPath, Using = "//bdi[text()='Cancel']")]
        private IWebElement SSC_Cancel_Btn;
        #endregion

        #region Events

        public void CreateNewReplenishmentJob(string CardSource, string Replenishment, string MappedRangeFrom, string MappedRangeTo)
        {
            SSCUserHomePage = new SSCUserHomePage(driver, config);
            int already_existcheck = 0;
            WebHandlers.Instance.WaitForPageLoad();
            if (WebHandlers.Instance.WebElementExists(SSCCardReplenishAddButton))
            {
                WebHandlers.Instance.Click(SSCCardReplenishAddButton);
            }
            BrowserDriver.Sleep(4000);
            SSC_CardSource.Click();
            //SSC_CardSource.SendKeys(CardSource);
            SSC_CardSource_Migration.Click();

            //WebHandlers.Instance.EnterText(SSCCardRunDescriptionTxtBox, RunDescription);
            BrowserDriver.Sleep(2000);
            try
            {
                already_existcheck = driver.FindElements(By.XPath("//*[contains(text(),'already exists')]")).Count();
                if (already_existcheck == 0)
                {
                    SSC_Replenishment.Click();
                    SSC_Replenishment.Clear();
                    SSC_Replenishment.SendKeys(Replenishment);
                    BrowserDriver.Sleep(2000);
                    SSC_MappedRangeFrom.Click();
                    SSC_MappedRangeFrom.SendKeys(MappedRangeFrom);
                    BrowserDriver.Sleep(2000);
                    SSC_MappedRangeTo.Click();
                    SSC_MappedRangeTo.SendKeys(MappedRangeTo);
                    BrowserDriver.Sleep(2000);
                    //WebHandlers.Instance.Click(SSCCardAddRowBtn);
                    BrowserDriver.Sleep(2000);
                    WebHandlers.Instance.Click(SSC_SaveClose_Btn);
                }

                else
                {
                    WebHandlers.Instance.Click(SSC_Cancel_Btn);
                }

            }
            catch (Exception e) { }
            SSCUserHomePage.NavigateToSSCCardManagement();
            SSCUserHomePage.NavigateToSSCReplenishment();
        }

        public void ValidateReplenishmentJob(string CardSource, string Replenishment, string MappedRangeFrom, string MappedRangeTo)
        {
            Boolean Cardsource_disp = driver.FindElement(By.XPath("//*[text()= '" + CardSource + "']")).Displayed;
            int inputValue = int.Parse(Replenishment);
            string ReplenishmentFormatted = string.Format("{0:#,0}", inputValue);// Format the Replenishment number with a comma. Since in UI Replenishment is comma separated

            // Format the MappedRangeFrom number with a comma. Since in UI Replenishment value is comma separated
            long inputValuemapped = long.Parse(MappedRangeFrom);
            string MappedRangeFromFormatted = inputValuemapped.ToString("N0");
            // Format the MappedRangeFrom number with a comma. Since in UI MappedRangeFrom value is comma separated
            long inputValuemappedFrom = long.Parse(MappedRangeFrom);
            string MappedRangeToFormatted = inputValuemappedFrom.ToString("N0");
            // Format the MappedRangeTo number with a comma. Since in UI MappedRangeTo value is comma separated
            Boolean Replenishment_disp = driver.FindElement(By.XPath("//*[text()= '" + ReplenishmentFormatted + "']")).Displayed;
            Boolean MappedRangeFrom_disp = driver.FindElement(By.XPath("//*[text()= '" + MappedRangeFromFormatted + "']")).Displayed;
            Boolean MappedRangeTo_disp = driver.FindElement(By.XPath("//*[text()= '" + MappedRangeToFormatted + "']")).Displayed;

            Assert.IsTrue(Cardsource_disp, "The Card Source is not found in Card Replenishment");
            Assert.IsTrue(Replenishment_disp, "The Card Source is not found in Card Replenishment");
            Assert.IsTrue(MappedRangeFrom_disp, "The Card Source is not found in Card Replenishment");
            Assert.IsTrue(MappedRangeTo_disp, "The Card Source is not found in Card Replenishment");

        }
        #endregion
    }
}
