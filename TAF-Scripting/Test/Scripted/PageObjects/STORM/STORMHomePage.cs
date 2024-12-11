using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    #region Using
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TAF_Web.Scripted.Web;
    #endregion

    public class STORMHomePage
    {

        public IWebDriver driver;

        #region  Constructor

        public STORMHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Products')]")]
        private IWebElement ProductsMainMenu;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Barcodes')]")]
        private IWebElement BarcodesSubMenu;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Order Processing')]")]
        private IWebElement OrderProcessingMainMenu;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Order Process')]")]
        private IWebElement OrderProcessSubMenu;

  

        #endregion

        #region Events  

        public void SelectOrderProcessing()
        {
            WebHandlers.Instance.Click(OrderProcessingMainMenu);
            WebHandlers.Instance.Click(OrderProcessSubMenu);
        }


        public void OpenProductBarcode()
        {
            WebHandlers.Instance.Click(ProductsMainMenu);
            WebHandlers.Instance.Click(BarcodesSubMenu);
        }


        #endregion

        #region Validation   


        #endregion
    }
}
