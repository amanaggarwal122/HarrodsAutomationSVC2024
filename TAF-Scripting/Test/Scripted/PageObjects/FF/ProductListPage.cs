using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class ProductListPage
    {
        public IWebDriver driver;
        private Configuration config = null;

        #region  Constructor

        public ProductListPage(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        #endregion

        #region Elements		

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'sort by')]")]
        private IWebElement SortBy;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Price ( Low to High )')]")]
        private IWebElement SortByPrice;

        #endregion

        #region Events  

        public void SortByLowestPrice()
        {
            WebHandlers.Instance.ClickByJsExecutor(SortBy);
            WebHandlers.Instance.ClickByJsExecutor(SortByPrice);
            BrowserDriver.Sleep(4000);
            WebHandlers.Instance.WaitForPageLoad();
        }

        public void SelectProduct(string productText,string productId)
        {
            if(productText.Contains(" "))
            {
                productText = productText.Replace(" ", "-").ToLower();
            }

            if(string.IsNullOrEmpty(productText))
            {
                productText = "falabella-tote";
            }
               
            string Url= config.FFProductUrl.Replace("{productText}", productText).Replace("{productId}", productId);
            
            BrowserDriver.LaunchWebURL(Url);
            WebHandlers.Instance.WaitForPageLoad();
           // BrowserDriver.Sleep(3000);
        }
        #endregion

        #region Validation     
        #endregion
    }
}
