

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    using NUnit.Framework;
    #region Using
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using TAF_Web.Scripted.Web;
    #endregion

    public class STORMProductPage
    {

        public IWebDriver driver;
        string Rowindex, Columnindex;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region  Constructor

        public STORMProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search item ID / SKU']")]
        private IWebElement ProcutIDText;


        [FindsBy(How = How.XPath, Using = "//button[@data-test='page-search-button']")]
        private IWebElement SearchButton;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='filter-partners']")]
        private IWebElement PartnerDropDown;

        [FindsBy(How = How.XPath, Using = "//ul//li[contains(.,'HARRODS SANDBOX')]")]
        private IWebElement HarrodsSandBoxItem;

        //[FindsBy(How = How.XPath, Using = "//ul//li[contains(.,'HARRODS GIFT CARDS')]")]
        //private IWebElement HarrodsGiftCardItem;

        [FindsBy(How = How.XPath, Using = "//ul//li[contains(.,'HARRODS SANDBOX GIFT CARDS')]")]
        private IWebElement HarrodsGiftCardItem;

        //select item


        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'14580288')]")]
        private IWebElement TableProductButton;

        [FindsBy(How = How.XPath, Using = "//table[@data-test='list-table']")]
        private IWebElement TableProductList;


        
        //[FindsBy(How = How.XPath, Using = "//div[contains(@class,'InventoryTable-body')]/div[Rowindex]/div/div[Columnindex]")]
        //private IWebElement StockValue;

        //[FindsBy(How = How.XPath, Using = Rowindex)]
        //private IWebElement StockValue;

        // check stock


        [FindsBy(How = How.XPath, Using = "//button[@data-test='tab_inventory']")]
        private IWebElement TabInventory;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='dropdown-merchants']")]
        private IWebElement DivMerchants;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='dropdown-tenants']")]
        private IWebElement DivTenants;

        [FindsBy(How = How.XPath, Using = "//ul//li[contains(text(),'Harrods Sandbox')]")]
        private IWebElement HarrodsTenantItem;


        [FindsBy(How = How.XPath, Using = "//div[@data-test='inventory-table']/div[contains(@class,'fixedColumn') and not(contains(@class,'totalColumn'))]/div")]
        private IWebElement LeftHeaderColumn;


        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'row') and @data-test='header']/div")]
        private IWebElement DataHeaderRow;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'row') and contains(@data-test,'row')]/div")]
        private IWebElement DataCell;


        [FindsBy(How = How.XPath, Using = "//button[@data-test='pic-close']")]
        private IWebElement CloseStockPrompt;
        #endregion

        #region Events  
        public void SearchProduct(string productId)
        {

            WebHandlers.Instance.EnterText(ProcutIDText, productId);
            WebHandlers.Instance.Click(SearchButton);
        }

        public void SelectPartner(string Node)
        {
            IWebElement DropDownItem=null;
            
            BrowserDriver.Sleep(2000);
            switch (Node.ToUpper())
            {
               
                case "GC":
                    if (!PartnerDropDown.Text.Contains("HARRODS SANDBOX GIFT CARDS"))
                    {
                        DropDownItem = WebHandlers.Instance.GetElement(driver, By.XPath("//ul//li[contains(.,'HARRODS SANDBOX GIFT CARDS')]"));
                        WebHandlers.Instance.Click(PartnerDropDown);
                        WebHandlers.Instance.Click(DropDownItem);
                    }
                    break;
                case "BBY":
                    if (!PartnerDropDown.Text.Contains("BURBERRY SANDBOX UK WH"))
                    {
                        DropDownItem = WebHandlers.Instance.GetElement(driver, By.XPath("//ul//li[contains(.,'BURBERRY SANDBOX UK WH')]"));
                        WebHandlers.Instance.Click(PartnerDropDown);
                        WebHandlers.Instance.Click(DropDownItem);
                    }
                    break;

                default:
                    if (!PartnerDropDown.Text.Equals("HARRODS SANDBOX"))
                    {
                        DropDownItem = WebHandlers.Instance.GetElement(driver, By.XPath("//ul//li[contains(.,'HARRODS SANDBOX')]"));
                        WebHandlers.Instance.Click(PartnerDropDown);
                        WebHandlers.Instance.Click(DropDownItem);
                    }
                    break;
            }



        }

        public void SelectProduct(string productId)
        {
            if (WebHandlers.Instance.WebElementExists(TableProductList))
            {
                WebHandlers.Instance.TblCelButtonClick(TableProductList, productId);
            }
            else
            {
                Assert.Fail($" Search for product - {productId}");
            }
        }

        public void SelectSite()
        {
            WebHandlers.Instance.Click(DivTenants);
            BrowserDriver.Sleep();
            WebHandlers.Instance.ClickByJsExecutor(HarrodsTenantItem);
        }

        public void SelectInventory()
        {
            WebHandlers.Instance.Click(TabInventory);
            WebHandlers.Instance.ClickByJsExecutor(TabInventory);
        }

        #endregion

        #region Validation   

        public  void ValidateStock(int requiredQuantity, string size, string Node)
        {
            int columnIndex;
            log.Info("Validating stock in storm");
            string partner=FetchPartner(Node);
            int rowIndex = WebHandlers.Instance.GetIndexUsingText(LeftHeaderColumn, partner);
            if(Regex.Split(size, @"\D+").Length !=0)
             columnIndex = WebHandlers.Instance.GetIndexUsingText(DataHeaderRow, Regex.Split(size, @"\D+")[0]);
            else
              columnIndex = WebHandlers.Instance.GetIndexUsingText(DataHeaderRow, size);
            IWebElement StockValue = WebHandlers.Instance.GetElement(driver,By.XPath("//div[contains(@class,'InventoryTable-body')]/div[" + (rowIndex+1).ToString() + "]/div/div[" + (columnIndex+1).ToString() + "]"));
            
            string stock = StockValue.Text;
            //WebHandlers.Instance.GetTextUsingIndex(DataCell, (columnIndex +1) * rowIndex);

            if (int.Parse(stock) < requiredQuantity)
            {
                log.Info("Not enough stock available to purchase");
                Assert.Fail("Exception occured while validation stock in Storm. Error details: Not enough stock available to purchase");
            }
            else
                log.Info("Enough stock to purchase");
            WebHandlers.Instance.ClickByJsExecutor(CloseStockPrompt);
            
        }

        public int AvailableStock(string size, string Node)
        {
            int columnIndex;
            log.Info("Validating stock in storm");
            string partner = FetchPartner(Node);
            int rowIndex = WebHandlers.Instance.GetIndexUsingText(LeftHeaderColumn, partner);
            if (Regex.Split(size, @"\D+").Length != 0)
                columnIndex = WebHandlers.Instance.GetIndexUsingText(DataHeaderRow, Regex.Split(size, @"\D+")[0]);
            else
                columnIndex = WebHandlers.Instance.GetIndexUsingText(DataHeaderRow, size);
            IWebElement StockValue = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@class,'InventoryTable-body')]/div[" + (rowIndex + 1).ToString() + "]/div/div[" + (columnIndex + 1).ToString() + "]"));

            string stock = StockValue.Text;
           
            WebHandlers.Instance.ClickByJsExecutor(CloseStockPrompt);

            return int.Parse(stock);
        }

        #endregion

        #region FetchPartner
        

        public string FetchPartner(string location)
        {
            string partner = "";
            switch (location.ToUpper().Trim())
            {
                case "DC44":
                    partner = "HARRODS SANDBOX WAREHOUSE";
                    break;
                case "GC":
                    partner = "HARRODS SANDBOX GIFT CARDS";
                    break;
                case "DCX1":
                    partner = "HARRODS SANDBOX HAMPERS";
                    break;
                case "BBY":
                    partner = "BURBERRY SANDBOX UK WH";
                    break;
                default:
                    partner = "HARRODS SANDBOX STORE";
                    break;


            }
            return partner;
        }

        #endregion

    }
}
