using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class OrderBagPage
    {
        public IWebDriver driver;

        #region  Constructor

        public OrderBagPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		

        //[FindsBy(How = How.XPath, Using = "//a[@data-test='checkout-button']")]--> changed by Ajay 06.02.2023
        [FindsBy(How = How.XPath, Using = "//a[@data-test='summary-go-to-checkout']")]
        private IWebElement SecureCheckout;

        //[FindsBy(How = How.XPath, Using = "//span[text()='Remove']")]

        [FindsBy(How = How.XPath, Using = "//button[@data-test='bag-item-remove-button']")]
        private IWebElement Remove;

        [FindsBy(How = How.XPath, Using = "//button[text()='Remove item']")]
        private IWebElement RemoveConfirmation;

        [FindsBy(How = How.Id, Using = "siteContent")]
        private IWebElement ParentDiv;

        [FindsBy(How = How.XPath, Using = "//h1[@data-test='bag-title']")]
        private IWebElement OrderBagHeader;

        [FindsBy(How = How.XPath, Using = "//h1[@data-test='empty-bag-title']")]
        private IWebElement BagEmptyHeader;


        [FindsBy(How = How.XPath, Using = "//dd[@data-test='summary-charge']")]
        private IWebElement DeliveryCharge;

        [FindsBy(How = How.XPath, Using = "//dd[@data-test='summary-total']")]
        private IWebElement TotalPrice;

        [FindsBy(How = How.XPath, Using = "//dd[@data-test='summary-subtotal']")]
        private IWebElement ProductPrice;


        #endregion

        #region Events  

        public void InvokeCheckoutProcess(ScenarioContext scenarioContext)
        {
            List<string> productPrice = new List<string>();
            productPrice = WebHandlers.Instance.GetTextFromMultipleElements(ProductPrice);

            string delivery = WebHandlers.Instance.GetTextOfElement(DeliveryCharge);
            string totalPrice = WebHandlers.Instance.GetTextOfElement(TotalPrice);
            TAFHooks.ApplicationCache.DeliveryCharge = delivery;
           // scenarioContext["ProductPrice"] = productPrice;
            TAFHooks.ApplicationCache.ItemPrice = productPrice;
            TAFHooks.ApplicationCache.OrderTotal = totalPrice;
            TAFHooks.ApplicationCache.TaxAmount = "";
            // WebHandlers.Instance.WaitForPageLoad();
            WebHandlers.Instance.ClickByJsExecutor(SecureCheckout);
            WebHandlers.Instance.WaitForPageLoad();
        }

        public void ClearBag()
        {
            WebHandlers.Instance.RemoveItemsFromCart(ParentDiv, Remove, RemoveConfirmation);
        }

        #endregion

        #region Validation     

        public void ValidateOrderBagPage()
        {
            string header = "Shopping Bag";
            string empty = "Your Shopping Bag is Empty";

            if (WebHandlers.Instance.WebElementExists(BagEmptyHeader))
                WebHandlers.Instance.VerifyText(BagEmptyHeader, empty);
            else if (WebHandlers.Instance.WebElementExists(OrderBagHeader))
                WebHandlers.Instance.VerifyText(OrderBagHeader, header);
        }
        #endregion
    }
}
