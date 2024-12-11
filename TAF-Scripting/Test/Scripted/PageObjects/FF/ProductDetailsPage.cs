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
    public class ProductDetailsPage
    {
        public IWebDriver driver;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //private static ProductDetailsPage instance;
        #region  Constructor

        public ProductDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
        //public ProductDetailsPage()
        //{
          
        //}

        #endregion

        #region Elements		

        [FindsBy(How = How.Id, Using = "quantity")]
        private IWebElement Quantity;

        [FindsBy(How = How.Id, Using = "size")]
        private IWebElement Size;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Add to bag')]")]
        private IWebElement AddToBag;


        [FindsBy(How = How.XPath, Using = "//a[@data-test='bagLink']")]
        private IWebElement Bag;

        [FindsBy(How = How.XPath, Using = "//a[@data-test='bagLink-loading']")]
        private IWebElement BagLink;
        //  

        #endregion

        #region Events  

        //public static ProductDetailsPage GetRegisterObj()
        //{

        //    if (instance == null)
        //    {
        //        instance = new ProductDetailsPage();
        //    }
        //    return instance;

        //}

        public void AddProductToBag()
        {
            log.Info("Add product to bag");
            WebHandlers.Instance.ClickByJsExecutor(AddToBag);
            WebHandlers.Instance.WaitForPageLoad();
        }

        public void AddQuantity(string quantity)
        {
            log.Info("Adding product qunatity");
            WebHandlers.Instance.MultiSelectByText(Quantity, quantity);
        }

        public void SelectSize(string size)
        {
            log.Info("Adding product size");
            int attempt = 1;
            while (!WebHandlers.Instance.WebElementExists(Size) && attempt <= 3)
            {
                BrowserDriver.Sleep(1200);
                attempt++;
            }

            if (size != null || size != "")
                WebHandlers.Instance.MultiSelectByText(Size, size);
        }

        public void GoToBag()
        {
            

            if (WebHandlers.Instance.WebElementExists(Bag))
            {
                WebHandlers.Instance.ClickByJsExecutor(Bag);
            }
            else
            {
                WebHandlers.Instance.ClickByJsExecutor(BagLink);
            }
             WebHandlers.Instance.WaitForPageLoad();
        }

       
        #endregion

        #region Validation     
        #endregion
    }
}
