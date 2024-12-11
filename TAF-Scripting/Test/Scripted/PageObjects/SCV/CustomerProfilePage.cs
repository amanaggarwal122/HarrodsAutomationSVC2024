using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SCV
{
    class CustomerProfilePage
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public IWebDriver driver;
        List<string> FailedOrders = new List<string>();
        public string Error{ get; set; }

        #region  Constructor

        public CustomerProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		

        [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/table[1]/thead[1]/tr[1]/th[2]/div[1]/div[1]/div[1]")]
        private IWebElement div_ddSelectSize;

        [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/button[1]")]
        private IWebElement button_lnkChangeDeliveryAddress;

        [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/button[1]")]
        private IWebElement button_tabOrder;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Create new order')]")]
        private IWebElement button_btnCreateNewOrder;

        [FindsBy(How = How.Id, Using = "name")]
        private IWebElement input_txtSearchItemID;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='search-item-id']")]
        private IWebElement SearchButton;
        
        [FindsBy(How = How.Id, Using = "storm-layout-container")]
        private IWebElement ParentDiv;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='btn-remove']")]
        private IWebElement Remove;

        [FindsBy(How = How.XPath, Using = "//button[text()='Remove item']")]
        private IWebElement RemoveConfirmation;

        [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/button[1]")]
        private IWebElement button_lnkMovetoWishList;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='search-item-id']//*[name()='svg']")]
        private IWebElement button_search_Id;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='select-size-dropdown']")]
        private IWebElement selectsizedropdown;

        [FindsBy(How = How.XPath, Using = "//ul[@data-test='select-size-dropdown-options']")]
        private IWebElement selectsizedropdownoptions;

        
        [FindsBy(How = How.XPath, Using = "//div[@data-test='dropdown-quantity']")]
        private IWebElement Quantitydropdown;

        [FindsBy(How = How.XPath, Using = "//div[@data-test='dropdown-quantity-options']")]
        private IWebElement Quantityoptions;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='proceed-checkout']")]
        private IWebElement button_CheckOut;
        
        [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/button[1]")]
        private IWebElement button_Apply;

        [FindsBy(How = How.XPath, Using = " //button[contains(text(),'Add a new card')]")]
        private IWebElement button_AddNewCard;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Ok')]")]
        private IWebElement button_OkStopRecording;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Place Order')]")]
        private IWebElement button_PlaceOrder;


        //Enter Card Details

        [FindsBy(How = How.Id, Using = "cardHolderName")]
        private IWebElement input_NameOnCard; 

        [FindsBy(How = How.XPath, Using = "//input[@id='cardNumber']")]
        private IWebElement input_EnterCardDetails;

        [FindsBy(How = How.XPath, Using = "//input[@id='cardCvv']")]
        private IWebElement input_CvvDetails;

        [FindsBy(How = How.XPath, Using = " //button[contains(text(),'Submit')]")]
        private IWebElement button_SubmitCardDetails;
       



        [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[5]/span[2]")]
                    private IWebElement span_lblItemID;

                    [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Add to bag')]")]
                    private IWebElement button_btnAddtoBag;




                    [FindsBy(How = How.XPath, Using = "html/body/div[1]/main/article/div/div[2]/div[2]/div/div/div[1]/div/div[1]/div[2]/div/div[2]/div[1]/div[1]/div/button/div/*[name()='svg']")]
                    private IWebElement svg_collapseView;
                    [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[3]/span[2]")]
                    private IWebElement span_lblPrice;
                    [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/button[2]")]
                    private IWebElement button_lnkCancelOrder;
                    [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/span[2]")]
                    private IWebElement span_lblOrderPortalId;
                    [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[4]/div[1]/div[1]/span[2]")]
                    private IWebElement span_lblSize;
                    [FindsBy(How = How.XPath, Using = "//div[@id='storm-layout-container']/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[6]/div[1]/span[1]")]
                    private IWebElement span_btnAvoidReturn;
                    [FindsBy(How = How.XPath, Using = "//button[@data-test='search-item-id']//*[name()='svg']")]
                    private IWebElement svg_btnSearchItem;
        [FindsBy(How = How.XPath, Using = "//*[@id='storm-layout-container']/div[2]/div/div[2]/div/div/div/div/div[2]/div/div/div/div[2]/div[4]/button")]
        private IWebElement checkout;


        [FindsBy(How = How.XPath, Using = "//div[@data-test='cp_orderslist_accordion-header-icon']")]
        private IList<IWebElement> AllOrders;


        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Show more')]")]
        private IWebElement button_ShowMore;
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Cancelled Orders')]")]
        private IWebElement CancelledOrdersTab;
        
        [FindsBy(How = How.XPath, Using = "//button[@data-test='button-save']")]
        private IWebElement button_CancelOrderPromptButton;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='backButton']")]
        private IWebElement backButton;

        [FindsBy(How = How.XPath, Using = "//button[@data-test='button-cancel']")]
        private IWebElement buttoncancel;
     

        [FindsBy(How = How.XPath, Using = "//div[@data-test='cancel_orders_modal_all_checkbox']//label[1]")]
        private IWebElement CancelAllOrderCheckBox;


        [FindsBy(How = How.XPath, Using = "//div[@class='content_3_XMw isOpen_33s2u']")]
        private IWebElement OrderDetails;
        #endregion

        #region Events 

        public void checkOut()
        {

            if (WebHandlers.Instance.WebElementExists(checkout))
                WebHandlers.Instance.ClickByJsExecutor(checkout, "CheckOut");
            else

                Assert.Fail("CheckOut button is not present");
            log.Error("CheckOut button is not present");
        }

        public void ClickCreateOrder()
        {

            if (WebHandlers.Instance.WebElementExists(button_btnCreateNewOrder))
                WebHandlers.Instance.ClickByJsExecutor(button_btnCreateNewOrder, "CreateOrder");
            else
            {
                Assert.Fail("CreateOrder button is not present");
                log.Error("CreateOrder button is not present");
            }
             
        }

        public void ClearBag()
        {
            WebHandlers.Instance.RemoveItemsFromCart(ParentDiv, Remove);
        }

        public void AddProducts(IList<Dictionary<string, string>> HPProduct_Attributes, IList<Dictionary<string, string>> BPProduct_Attributes)
        {
            string productId, productText, size, quantity;
            for (int BPCount = 0; BPCount < BPProduct_Attributes.Count; BPCount++)

            {
                productId = BPProduct_Attributes[BPCount]["Product Id"];
                productText = BPProduct_Attributes[BPCount]["Product Name"];
                size = BPProduct_Attributes[BPCount]["Size"];
                quantity = BPProduct_Attributes[BPCount]["Quantity"];

                SearchAndAddProduct(productId, size, quantity);

            }

            for (int HPCount = 0; HPCount < HPProduct_Attributes.Count; HPCount++)

            {
                productId = HPProduct_Attributes[HPCount]["Product Id"];
                productText = HPProduct_Attributes[HPCount]["Product Name"];
                size = HPProduct_Attributes[HPCount]["Size"];
                quantity = HPProduct_Attributes[HPCount]["Quantity"];


                SearchAndAddProduct(productId, size, quantity);

            }

            //WebHandlers.Instance.ClickByJsExecutor(button_CheckOut, "CheckOut");
            
        }

        public void SearchAndAddProduct(string productid, string size, string quantity)
        {
            WebHandlers.Instance.EnterText(input_txtSearchItemID, productid);
            WebHandlers.Instance.ClickByJsExecutor(SearchButton, "SearchItem");
            WebHandlers.Instance.ElementPresent(button_btnAddtoBag);
            selectsize(size);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(button_btnAddtoBag, "Move");
            selectquantity(productid, quantity);
        }
        public void selectsize(string size)
        {
            
            log.Info("Adding product size");
            WebHandlers.Instance.ClickByJsExecutor(selectsizedropdown, "SizeDropdown");
            BrowserDriver.Sleep(1000);
            size = Regex.Split(size, @"\D+")[0];
            IWebElement selectsizevalue = WebHandlers.Instance.GetElement(driver, By.XPath("//ul[@data-test='select-size-dropdown-options']/li[contains(text(),'" + size + "')]"));

            if (size != null || size != "")
                         WebHandlers.Instance.Click(selectsizevalue, "SizeValue");
          
        }


        public void selectquantity(string productid, string quantity)
        {
            BrowserDriver.Sleep(2000);
            //IWebElement Changequantity = WebHandlers.Instance.GetElement(driver, By.XPath("//button[@data-test='bag-tab']/parent::div//following-sibling::div//span[text()='"+productid+"'][1]/parent::div[1]/preceding-sibling::div//div[@data-test='dropdown-quantity']"));
            IWebElement Changequantity = WebHandlers.Instance.GetElement(driver, By.XPath("//button[@data-test='bag-tab']/parent::div//following-sibling::div//span[text()='"+productid+"'][1]/parent::div/preceding-sibling::div/div[2]//div[@data-test='dropdown-quantity']"));
            WebHandlers.Instance.WaitForPageLoad();
            log.Info("Adding product quantity");
           
            WebHandlers.Instance.Click(Changequantity, "ChangeQuantity");
            BrowserDriver.Sleep(4000);
            //IWebElement Changequantityvalue = WebHandlers.Instance.GetElement(driver, By.XPath("//ul[@data-test='dropdown-quantity-options']/li[contains(text(),'" + quantity + "')]"));
            //button[@data-test='bag-tab']/parent::div//following-sibling::div//span[text()='"+productid+"'][1]/parent::div/preceding-sibling::div/div[2]//ul[@data-test='dropdown-quantity-options
            IWebElement Changequantityvalue = WebHandlers.Instance.GetElement(driver, By.XPath("//button[@data-test='bag-tab']/parent::div//following-sibling::div//span[text()='" + productid + "'][1]/parent::div/preceding-sibling::div/div[2]//li[contains(text(),'" + quantity + "')]"));
            WebHandlers.Instance.ClickByJsExecutor(Changequantityvalue, "ChangeQuantityvalue");
        }


        public void FindOrderAndCancel(string portalordernum)
        {
           
            Error = "";
            try
            {



                while (!WebHandlers.Instance.IsElementPresent(By.XPath("//span[text()='"+ portalordernum.Trim()+"']/ancestor::div/following-sibling::button")))
                {
                    if (WebHandlers.Instance.WebElementExists(button_ShowMore))
                    {
                        WebHandlers.Instance.Click(button_ShowMore);

                    }

                    else
                    {
                        Error = "Portal Order Number not present";
                        Assert.Fail(Error);
                        break;
                        // Assert.Fail("Portal Order Number not present");
                        //write failed status to excel

                    }
                }
                if (Error == "")
                {
                    IList<IWebElement> OrderDetailExpandButtons = WebHandlers.Instance.GetElements(driver, By.XPath("//span[text()='" + portalordernum.Trim() + "']/ancestor::div/following-sibling::button"));
                    CancelOrder(OrderDetailExpandButtons, portalordernum);
                }
            }

            catch (Exception ex)
            {
                if (Error == "")
                    Error = ex.Message;

                FailedOrders.Add(portalordernum);
                
            }
            finally
            {
                if (WebHandlers.Instance.WebElementExists(buttoncancel))
                     WebHandlers.Instance.Click(buttoncancel);
                BrowserDriver.Sleep(2000);
                if (WebHandlers.Instance.WebElementExists(backButton))
                    WebHandlers.Instance.Click(backButton);
               
            }
       
        }

        public void CancelAllOrders()
        {

        }
        
        public void CancelOrder(IList<IWebElement> OrderDetailExpandButtons, string portalordernum)
        {
            foreach (IWebElement OrderDetailExpandButton in OrderDetailExpandButtons)

            {
                
                if (!WebHandlers.Instance.WebElementExists(OrderDetails))
                {
                    WebHandlers.Instance.Click(OrderDetailExpandButton);
                    
                }
                string Partner = OrderDetailExpandButton.FindElement(By.XPath("..//span[@data-test='order_partner']")).Text;
                IWebElement button_CancelOrder = OrderDetailExpandButton.FindElement(By.XPath("../..//following-sibling::div//button[text()='Cancel Order']"));
                //IWebElement button_CancelOrder = WebHandlers.Instance.GetElement(driver, By.XPath("//span[text()='" + portalordernum.Trim() + "']//ancestor::div[@data-test='cp_orderslist_accordion-header-border']//following-sibling::div//button[text()='Cancel Order']"));
                if (button_CancelOrder.Enabled)
                {
                    WebHandlers.Instance.ClickByJsExecutor(button_CancelOrder);
                    WebHandlers.Instance.Click(CancelAllOrderCheckBox);
                    WebHandlers.Instance.Click(button_CancelOrderPromptButton);
                    BrowserDriver.Sleep(4000);

                    button_CancelOrder = WebHandlers.Instance.GetElement(driver, By.XPath("//span[text()='" + portalordernum.Trim() + "']//ancestor::div[@data-test='cp_orderslist_accordion-header-border']//following-sibling::div//button[text()='Cancel Order']"));
                    if (button_CancelOrder.Enabled)
                    {
                        Error = Error + "Cancel NotSuccessful(" + Partner + "); ";
                        log.Error(Error);
                    }
                    else
                        Error = Error + "No Error("+ Partner+"); ";

                    WebHandlers.Instance.Click(OrderDetailExpandButton);

                }
                else
                {
                    WebHandlers.Instance.Click(OrderDetailExpandButton);
                    log.Error("Cancel Order button not enabled("+ Partner +"); ");
                    //Assert.Fail($"Cancel Order is not enabled to click");
                    Error = Error + "Cancel Order button not enabled(" + Partner + "); ";

                    //write fail to excel
                }



            }
           
            //WebHandlers.Instance.Click(CancelledOrdersTab);
            //IWebElement CancelOrder_PortalNumber = WebHandlers.Instance.GetElement(driver, By.XPath("//span[text()='" + portalordernum + "']"));
            //if (WebHandlers.Instance.WebElementExists(CancelOrder_PortalNumber))
            //{ Error = "No Error"; }
            //else
            //    Error = "Cancel unsuccessful";


        }
        #endregion

        #region Validation         
        #endregion
    }

            }

