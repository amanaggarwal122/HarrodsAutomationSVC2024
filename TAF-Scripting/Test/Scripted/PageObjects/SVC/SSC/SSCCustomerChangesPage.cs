using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SVC.SSC
{
    class SSCCustomerChangesPage
    {
        public IWebDriver driver;
        private Configuration config = null;
        private SSCCustomersPage SSC_Customer_Page = null;
        private CommonFunctions Common_Functions = null;

        #region  Constructor
        public SSCCustomerChangesPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
            
        }
        
        #endregion

        #region Elements
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'--header-arrowScrollRight')]")]
        private IWebElement SSCCustomerTabScrollRight;
        [FindsBy(How = How.XPath, Using = "//div[text()='Changes']")]
        private IWebElement SSCNewTicketSubTabChange;
        [FindsBy(How = How.XPath, Using = "( //span[@class='sapUiIcon sapUiIconMirrorInRTL sapMITBArrowScroll sapMITBArrowScrollRightTextOnly sapMITHVerticallyCenteredArrow sapMITBArrowScrollRightInLine'])[1]")]
        private IWebElement SSCNewTicketSubTabNavigator;
        

        #endregion
        //TC_235
        public By SSCNewTicketSubTabs(string tabName) { return By.XPath("//div[text()='" + tabName + "']"); }
        
        public By PointsTEValue(string ColumnName)
        {
            if (ColumnName == "Value Changed From")
                ColumnName = "1";
            else
                ColumnName = "2";
            //return By.XPath("//span[@title='External ID Type']/../../following-sibling::td[" + ColumnName + "]/div/span");
            //return By.XPath("(//*[text()='Status Points'])[1]/following::td[" + ColumnName + "]");
            //TC_235 "Status Points" xpath changed to "Status points"
            return By.XPath("(//*[text()='Status points'])[1]/following::td[" + ColumnName + "]");
        }
        public By SpanSSCTextFirst(string text) { return By.XPath("(//span[text()='" + text + "'])[1]"); }
        
        #region Events        
        //TC_187
        public string VerifyFullReturnDetailsShowingOnSSC(string FullName, string Email)
        {
            SSC_Customer_Page = new SSCCustomersPage(driver, config);
            string CdcId = SSC_Customer_Page.SearchLiteCustomerOnSSC(FullName, Email);
            BrowserDriver.Sleep(5000);
            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
            BrowserDriver.Sleep(5000);
            driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
            // method  to handle page navigation and filtering the attribute
            BrowserDriver.Sleep(5000);
            string subjectString = driver.FindElement(By.XPath("//*[contains(@id,'paginator-pageInfo-bdi')]")).Text;
            string result = subjectString.Replace("/", "");
            //string pagination = Common_Functions.GetNumbers(result);
            
            int p = Int32.Parse(result);
            //driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
            //WebHandlers.Instance.WebElementExists(driver.FindElement(PointsTEValue("Value Changed From")));
            for (int i = 0; i < p - 1; i++)
            {
                try
                {
                    IWebElement pointexpiry = driver.FindElement(PointsTEValue("Value Changed From"));
                    string point = pointexpiry.Text;
                    if (!point.Equals(null))
                    {
                        break;
                    }

                }
                catch { driver.FindElement(By.XPath("//*[@role='button'][contains(@id,'paginator-nextPage')]")).Click(); }
            }

            BrowserDriver.Sleep(4000);

            // Locate the filter element
            IWebElement filterElement = driver.FindElement(By.XPath("//th[@title='Attribute']"));

            Actions actions = new Actions(driver);

            // Click on the filter element and search for "Status Points" Attribute
            actions.Click(filterElement)
                   .SendKeys("Status Points")
                   .SendKeys(Keys.Enter)
                   .Build()
                   .Perform();
            BrowserDriver.Sleep(4000);
            Assert.IsTrue(driver.FindElement(SpanSSCTextFirst("Status points")).Displayed, "Status points" + " - activity against user is not showing on SSC");
            BrowserDriver.Sleep(4000);
            string prevValue = driver.FindElement(By.XPath("(//*[text()='Status points'])[1]/following::td[37]")).GetAttribute("innerText");
            string currValue = driver.FindElement(By.XPath("(//*[text()='Status points'])[1]/following::td[38]")).GetAttribute("innerText");
            //Assert.Greater(Convert.ToInt64(Math.Floor(Convert.ToDouble(prevValue))), Convert.ToInt64(Math.Floor(Convert.ToDouble(currValue))), "Redeem points reduction not showing on SSC");

            //WebHandlers.Instance.WebElementExists(driver.FindElement(PointsTEValue("Value Changed From")));
            BrowserDriver.Sleep(4000);
            //string prevValue = driver.FindElement(PointsTEValue("Value Changed From")).GetAttribute("innerText");
            //string currValue = driver.FindElement(PointsTEValue("Value Changed To")).GetAttribute("innerText");
            //Assert.Greater(Convert.ToInt64(Math.Floor(Convert.ToDouble(prevValue))), Convert.ToInt64(Math.Floor(Convert.ToDouble(currValue))), "Point reduction against full return not showing on SSC");
            return CdcId;
        }

        public void ValidateActivityShowingOnSSC(string PointCategory)
        {
            Common_Functions = new CommonFunctions();
            WebHandlers.Instance.Click(SSCCustomerTabScrollRight);
            BrowserDriver.Sleep(5000);
            driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
            BrowserDriver.Sleep(5000);
            string subjectString = driver.FindElement(By.XPath("//*[contains(@id,'paginator-pageInfo-bdi')]")).Text;
            string pagination = Common_Functions.GetNumbers(subjectString);
            int p = Int32.Parse(pagination);
            //driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
            //WebHandlers.Instance.WebElementExists(driver.FindElement(PointsTEValue("Value Changed From")));
            for (int i = 0; i < p - 1; i++)
            {
                try
                {
                    IWebElement pointexpiry = driver.FindElement(PointsTEValue("Value Changed From"));
                    string point = pointexpiry.Text;
                    if (!point.Equals(null))
                    {
                        break;
                    }

                }
                catch { driver.FindElement(By.XPath("//*[@role='button'][contains(@id,'paginator-nextPage')]")).Click(); }
            }

            BrowserDriver.Sleep(4000);
            //Assert.IsTrue(driver.FindElement(SpanSSCTextFirst("Rewards Points")).Displayed, PointCategory + " - activity against user is not showing on SSC");
            if (PointCategory != "RedeemPoints")
            {
                Assert.IsTrue(driver.FindElement(SpanSSCTextFirst("Status points")).Displayed, PointCategory + " - activity against user is not showing on SSC");
            }
            if (PointCategory == "RedeemPoints")
            {
                BrowserDriver.Sleep(3000);
                
                // Locate the filter element
                IWebElement filterElement = driver.FindElement(By.XPath("//th[@title='Attribute']"));

               Actions actions = new Actions(driver);

                // Click on the filter element and search for "Status Points" Attribute
                actions.Click(filterElement)
                       .SendKeys("Status Points")
                       .SendKeys(Keys.Enter)
                       .Build()
                       .Perform();
                BrowserDriver.Sleep(4000);
                Assert.IsTrue(driver.FindElement(SpanSSCTextFirst("Status points")).Displayed, PointCategory + " - activity against user is not showing on SSC");
                string prevValue = driver.FindElement(PointsTEValue("Value Changed From")).GetAttribute("innerText");
                string currValue = driver.FindElement(PointsTEValue("Value Changed To")).GetAttribute("innerText");
                Assert.Greater(Convert.ToInt64(Math.Floor(Convert.ToDouble(prevValue))), Convert.ToInt64(Math.Floor(Convert.ToDouble(currValue))), "Redeem points reduction not showing on SSC");

                driver.FindElement(SSCNewTicketSubTabs("Purchases")).Click();
                BrowserDriver.Sleep(3000);
                Assert.IsTrue(driver.FindElement(SpanSSCTextFirst("POS")).Displayed, PointCategory + "POS purchase activity against user is not showing on SSC");
            }
        }

        public void ValidateResolvedAndResolutionDateWereShowingAsPerSLA()
        {
            //SubtabNavigator click
            SSCNewTicketSubTabNavigator.Click();
            //driver.FindElement(SSCNewTicketSubTabs("Overview")).Click();
            BrowserDriver.Sleep(3000);
            //driver.FindElement(SSCNewTicketSubTabs("Changes")).Click();
            //'Changes'button xpath
            SSCNewTicketSubTabChange.Click();
            BrowserDriver.Sleep(2000);
            //Assert.AreNotEqual("", driver.FindElement(SSCUserFieldData("Resolved On")).GetAttribute("innerText"), "Resolved On date inside SSC timeline is not showing as per SLA");
            //Assert.AreNotEqual("", driver.FindElement(SSCUserFieldData("Resolution Due")).GetAttribute("innerText"), "Resolution Due date inside SSC timeline is not showing as per SLA");
        }
        #endregion
    }
}
