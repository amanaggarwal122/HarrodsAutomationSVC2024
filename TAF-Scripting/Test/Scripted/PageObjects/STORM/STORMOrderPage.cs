using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility;
using TAF_GenericUtility.Scripted.DataWrite;
using TAF_Scripting.Test.Scripted.StepDefinitions;
using TAF_Web.Scripted.Web;
using TechTalk.SpecFlow;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class STORMOrderPage
    {
        public IWebDriver driver;
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region  Constructor

        public STORMOrderPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        #endregion

        #region Elements		
        [FindsBy(How = How.ClassName, Using = "FF-orderDetail-gift-order-message")]
        private IWebElement GiftMsg;

        [FindsBy(How = How.XPath, Using = "//dd[contains(@data-tstid,'Label_Item_NDD')]")]
        private IWebElement lblNDD;

        [FindsBy(How = How.XPath, Using = "//div[@data-id='JS-FF-ordersearchfieldfilter']")]
        private IWebElement OrderSearchType;

        [FindsBy(How = How.XPath, Using = "//ul[@class='FF-dropdown-items-container']//li[text()='Portal Order Number']")]
        private IWebElement SearchTypePortalOrderNumber;


        [FindsBy(How = How.XPath, Using = "//ul[@class='FF-dropdown-items-container']//li[text()='Order Code']")]
        private IWebElement SearchTypeOrderCode;

        [FindsBy(How = How.XPath, Using = "//input[@id='SearchCriteria']")]
        private IWebElement SearchCriteria;


        [FindsBy(How = How.XPath, Using = "//div[@id='searchBtn']")]
        private IWebElement SearchButton;


        [FindsBy(How = How.XPath, Using = "//span[text()='No items to display']")]
        private IWebElement NoOrderFound;

        [FindsBy(How = How.XPath, Using = "//div[contains(@data-tstid,'Order_Code')]/span")]
        private IWebElement StormOrder;


        [FindsBy(How = How.XPath, Using = "//dd[contains(@data-tstid,'Label_Item_Merchant_Barcode')]")]
        private IWebElement OrderSKU;

        [FindsBy(How = How.XPath, Using = "//div[@class='progress-bar']")]
        private IWebElement ProgressBar;

        [FindsBy(How = How.XPath, Using = "//span[contains(@data-tstid,'Label_Item_Price')]")]
        private IWebElement Price;

        [FindsBy(How = How.XPath, Using = "//div[@class='baseline FF-order-steps-expandAll FF-order-steps-expandAll-glyph icon-plus']")]
        private IWebElement ExpandAll;


        [FindsBy(How = How.XPath, Using = "//span[@class=' glyphs icon-Tick']")]
        private IList<IWebElement> tickicons;


        [FindsBy(How = How.XPath, Using = "//button[contains(@data-tstid,'Submit_Save_Stock')]")]
        private IList<IWebElement> SaveStockButtons;

        [FindsBy(How = How.ClassName, Using = "JS-FF-dropdown FF-custom-dropdown hide processed")]
        private IWebElement BoxDropDown;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-tstid,'Submit_Create_Box')]")]
        private IList<IWebElement> CreateBoxes;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-tstid,'Submit_Step')]")]
        private IList<IWebElement> SaveBoxButtons;

        [FindsBy(How = How.XPath, Using = "//button[contains(@data-tstid,'Submit_Step')]/span[@class='FF-button-icon FF-button-icon FF-button-icon FF-button-icon FF-loading FF-button-loader']")]
        private IWebElement SaveButtonLoader;

        [FindsBy(How = How.Id, Using = "FF_refresh_orders")]
        private IWebElement RefreshButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='baseline FF-order-steps-expandAll FF-order-steps-expandAll-glyph icon-minus']")]
        private IWebElement CollapseAll;

       
        [FindsBy(How = How.Id, Using = "step1-submit-checkStock")]
        private IWebElement SubmitCheckStock;

        [FindsBy(How = How.XPath, Using = "//div[starts-with(@id, 'stockOk_')]")]
        private IWebElement StockOk;

        [FindsBy(How = How.XPath, Using = "//div[starts-with(@id, 'divOrderProgressBar_')]")]
        private IWebElement OrderPanel;

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class,'FF-button FF-button_width')])[2]")]
        private IWebElement submitBox;
        

        [FindsBy(How = How.XPath, Using = "//div[starts-with(@data-tstid, ' ComboBox_Boxes_')]")]
        private IWebElement SelectBoxes;

        [FindsBy(How = How.XPath, Using = "//div[starts-with(@id, 'divOrderProgressBar_')]/following-sibling::div[contains(@class, 'icon-plus')]")]
        private IWebElement ExpandPanel;

        #endregion

        #region Events  
        public void ValidateGiftMessage(string message)
        {
            string msg= string.Empty;
            if (WebHandlers.Instance.WebElementExists(GiftMsg))
            {
                 msg = WebHandlers.Instance.GetTextOfElement(GiftMsg);
            }
            else
            {
                Assert.Fail("Gift meassage not reflected in storm application");
            }

            if(msg!= message)
            {
                Assert.Fail("Gift meassage not matching");
            }

        }

        public void ValidateNDD(string ndd)
        {
            string stormNDD = string.Empty;
            if (WebHandlers.Instance.WebElementExists(lblNDD))
            {
                stormNDD = WebHandlers.Instance.GetTextOfElement(lblNDD);
            }
            else
            {
                Assert.Fail("Nominated Delivery Date not reflected in storm application");
            }

             ndd = Convert.ToDateTime(ndd).ToString("d MMM yyyy");

            if (stormNDD != ndd)
            {
                Assert.Fail("Nominated Delivery Date not matching");
            }
        }
        public void SearchOrderNumber(string portalOrderNumber, string searchcriteria="PORTALORDERNUMBER")
        {
            BrowserDriver.Sleep(10000);
            WebHandlers.Instance.ScrollWebPageToTop();

            WebHandlers.Instance.Click(OrderSearchType);
            WebHandlers.Instance.ScrollWebPageToTop();
            BrowserDriver.Sleep(2000);
            switch(searchcriteria.ToUpper().Trim())
            {

                case "PORTALORDERNUMBER":
                    WebHandlers.Instance.Click(SearchTypePortalOrderNumber);
                    break;
                case "ORDERCODE":
                    WebHandlers.Instance.Click(SearchTypeOrderCode);
                    break;
                default:
                    WebHandlers.Instance.Click(SearchTypePortalOrderNumber);
                    break;
            }
           
            WebHandlers.Instance.ScrollWebPageToTop();
            WebHandlers.Instance.EnterText(SearchCriteria, portalOrderNumber);
            WebHandlers.Instance.ScrollWebPageToTop();
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SearchButton);
            WebHandlers.Instance.ClickByJsExecutor(SearchButton);

            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.ClickByJsExecutor(ExpandAll);
        }

        public void CompleteCheckStock()
        {
            WebHandlers.Instance.Click(StockOk);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(SubmitCheckStock);
        }

        public void SelectBox()
        {
            
            if (WebHandlers.Instance.WebElementExists(ExpandPanel))
            {
                WebHandlers.Instance.Click(OrderPanel);
                BrowserDriver.Sleep(2000);
            }
            
            WebHandlers.Instance.Click(SelectBoxes);
            IWebElement SelectBox = WebHandlers.Instance.GetElement(driver, By.XPath("//ul[@class='FF-dropdown-items-container']//li[text()='" + "External - Extralarge" +"']"));
            WebHandlers.Instance.Click(SelectBox);
            BrowserDriver.Sleep(2000);
            WebHandlers.Instance.Click(submitBox);
        }

        public void SearchOrderNumber2attempt()
        {
            WebHandlers.Instance.Click(SearchButton);
            WebHandlers.Instance.ClickByJsExecutor(SearchButton);
        }

        //public List<string> RetriveOrderDetails(string portalOrderNumber, IList<string> sku, ScenarioContext scenarioContext)
        //{

        //    //if (WebHandlers.Instance.ElementPresent(NoOrderFound))
        //    //{
        //    //    Assert.Fail($"No order found for portal order {portalOrderNumber}");
        //    //}

        //    RetryOrderSearch(portalOrderNumber);
           
        //    List<string> texts = WebHandlers.Instance.GetTextFromMultipleElements(StormOrder);
        //    List<string> orderNumbers = new List<string>();
        //    for (int indx = 0; indx < texts.Count; indx++)
        //    {
        //        orderNumbers.Add(texts[indx] + texts[indx + 1]);
        //        indx = indx + 1;
        //    }


        //    List<string> skus = WebHandlers.Instance.GetTextFromMultipleElements(OrderSKU);

        //    foreach (string skuid in sku)
        //    {
        //        if (!skus.Any(p => p.Equals(skuid)))
        //        {
        //            Assert.Fail($"No order found for SKU {sku}");
        //        }

        //    }
            

        //    List<string> price = WebHandlers.Instance.GetTextFromMultipleElements(Price);
        //    string deliveryCharge = "0";
        //    try
        //    {
        //        deliveryCharge = scenarioContext["DeliveryCharge"] as string;
        //        //List<string> price = scenarioContext["ProductPrice"] as List<string>;
        //    }
        //    catch (Exception ex) { }

        //    List<string> status = GetOrderStatus();

        //    // write to excel

        //    string input = $"{ConfigDriver.getDirPath()}\\Resources\\SkriptmateArtefacts\\Test Order Tracker.xlsx";
        //    string output = $"{ConfigDriver.getDirPath()}\\ScriptmateReport\\STORM\\Test Order Tracker{DateTime.Now.ToString("ddMMyyyy_hhmmss")}.xlsx";
        //    string sheetname = "Order List";
        //    ExcelDataWrite excelwrite = new ExcelDataWrite();
        //    Dictionary<int, List<string>> data = new Dictionary<int, List<string>>();

        //    for (int indx = 0; indx < orderNumbers.Count; indx++)
        //    {
        //        List<string> row = new List<string>();

        //        row.Add((indx + 1).ToString());
        //        row.Add(DateTime.Now.ToString("dd/MM/yyyy"));
        //        row.Add(portalOrderNumber);
        //        row.Add(orderNumbers[indx]);
        //        row.Add(price[indx]);
        //        row.Add(deliveryCharge);
        //        row.Add(status[indx]);

        //        data.Add(indx + 1, row);
        //    }

        //    excelwrite.WriteToExcel(input, sheetname, output, true, data);
        //    return orderNumbers;
        //}

        public List<string> RetriveOrderDetails(string portalOrderNumber, IList<string> sku , ApplicationCache cache)
        {
            RetryOrderSearch(portalOrderNumber);

            List<string> texts = WebHandlers.Instance.GetTextFromMultipleElements(StormOrder);
            List<string> orderNumbers = new List<string>();
            for (int indx = 0; indx < texts.Count; indx++)
            {
                orderNumbers.Add(texts[indx] + texts[indx + 1]);
                indx = indx + 1;
            }
            TAFHooks.ApplicationCache.StormOrderCodes = orderNumbers;
            //cache.StormOrderCodes = orderNumbers;
            //cache.PortalOrderNumber = portalOrderNumber;
            //List<string> skus = WebHandlers.Instance.GetTextFromMultipleElements(OrderSKU);
            

            //List<string> price = WebHandlers.Instance.GetTextFromMultipleElements(Price);
           // string deliveryCharge = "0";
            //try
            //{
            //    deliveryCharge = cache.DeliveryCharge;
                
            //}
            //catch (Exception ex) { }

            List<string> status = GetOrderStatus();
           // cache.Orderstatus = status;
           TAFHooks.ApplicationCache.Orderstatus = status;
            //foreach (string skuid in sku)
            //{
            //    if (!skus.Any(p => p.Equals(skuid)))
            //    {
            //        Assert.Fail($"No order found for SKU {sku}");
            //    }

            //}
            // write to excel

            //string input = $"{ConfigDriver.getDirPath()}\\Resources\\SkriptmateArtefacts\\Test Order Tracker.xlsx";
            //string output = $"{ConfigDriver.getDirPath()}\\ScriptmateReport\\STORM\\Test Order Tracker{DateTime.Now.ToString("ddMMyyyy_hhmmss")}.xlsx";
            //string sheetname = "Order List";
            //ExcelDataWrite excelwrite = new ExcelDataWrite();
            //Dictionary<int, List<string>> data = new Dictionary<int, List<string>>();

            //for (int indx = 0; indx < orderNumbers.Count; indx++)
            //{
            //    List<string> row = new List<string>();

            //    row.Add((indx + 1).ToString());
            //    row.Add(DateTime.Now.ToString("dd/MM/yyyy"));
            //    row.Add(portalOrderNumber);
            //    row.Add(orderNumbers[indx]);
            //    row.Add(price[indx]);
            //    row.Add(deliveryCharge);
            //    row.Add(status[indx]);

            //    data.Add(indx + 1, row);
            //}

            //TAFHooks.ApplicationCache.ExcelPath = output;

            //excelwrite.WriteToExcel(input, sheetname, output, true, data);
            return orderNumbers;
        }


        public void DispatchOrder(ApplicationCache cache)
        {
          


            ExpandAllOrders();
            PerformPacking(cache.StormOrderCodes);
            RefreshAndVerifyStatus(cache.StormOrderCodes, "PACKAGING");
            SelectBox(cache.StormOrderCodes);
            RefreshAndVerifyStatus(cache.StormOrderCodes, "PRINT");
            //List<string> statuses = GetOrderStatus();


            //    while(!statuses.Any(p => p.ToUpper().Equals("PACKAGING")))

            //    {
            //        BrowserDriver.Sleep(2000);
            //        RetryOrderSearch(cache.PortalOrderNumber);
            //     statusretry++;

            //    if (statusretry > 5)
            //    {
            //        Assert.Fail("status is not updated to PACKAGING even after 10 seconds");
            //        break;
            //    }
            //    }
            //statusretry = 0;






        }

        public void PerformPacking(IList<string> stormordercodes)
        {
            string partnercode = "";
            foreach (string stormordercode in stormordercodes)
            {
                if (!stormordercode.Contains("HS"))
                {
                    switch (stormordercode.Substring(0, 3))
                    {
                        case "BSW":
                            partnercode = "BSW";

                            break;

                        case "HSW":
                            partnercode = "HSW";


                            break;

                        case "HSS":
                            partnercode = "HSS";

                            break;
                    }



                    IList<IWebElement> tickicons = WebHandlers.Instance.GetElements(driver, By.XPath(" //div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='"+ partnercode+"']/../../..//span[@class=' glyphs icon-Tick']"));
                    IWebElement SaveButton = WebHandlers.Instance.GetElement(driver, By.XPath(" //div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='"+ partnercode+"']/../../..//button[contains(@data-tstid,'Submit_Save_Stock')]"));
                    foreach (IWebElement tickicon in tickicons)
                        WebHandlers.Instance.ClickByJsExecutor(tickicon, "tickicon");
                    BrowserDriver.Sleep(2000);
                    //foreach (IWebElement SaveButton in SaveStockButtons)
                    WebHandlers.Instance.ClickByJsExecutor(SaveButton, "SaveButton");
                 
                    BrowserDriver.Sleep(4000);
                    //if (!WebHandlers.Instance.Elementnotpresent(SaveButton, "SaveBox"))
                    //    Assert.Fail("Box not saved successfully");
                }
            }
        }

        public void RefreshAndVerifyStatus(IList<string> stormordercodes, string status,int MaxCount=10)

        {
            int statusretry = 0; string orderstatus="";

            foreach (string stormordercode in stormordercodes)

            {
                 statusretry = 0;

                if (!stormordercode.Contains("HS"))
                {
                    orderstatus= GetOrderStatusOfSpecificOrder(stormordercode);
                    while (!orderstatus.ToUpper().Equals(status))
                    {
                       
                        if (statusretry > MaxCount)
                        {
                            Assert.Fail("status is not updated to" + status + " even after 20 seconds");
                            break;
                        }

                        BrowserDriver.Sleep(2000);
                        WebHandlers.Instance.ClickByJsExecutor(RefreshButton);
                        orderstatus = GetOrderStatusOfSpecificOrder(stormordercode);
                        statusretry++;
                    }

                }
            }

            log.Info("Status updated to" + status + " successfully");
        }

        //do

        //{
        //    BrowserDriver.Sleep(2000);
        //    WebHandlers.Instance.ClickByJsExecutor(RefreshButton);
        //    statuses = GetOrderStatus();
        //    statusretry++;

        //    if (statusretry > MaxCount)
        //    {
        //        Assert.Fail("status is not updated to" + status + " even after 20 seconds");
        //        break;
        //    }
        //} while (statuses.Any(p => !p.ToUpper().Equals(status)));



        public void ExpandAllOrders()
        {
            if (WebHandlers.Instance.WebElementExists(ExpandAll))
                WebHandlers.Instance.ClickByJsExecutor(ExpandAll, "ExpandAll");
            else
            {
                WebHandlers.Instance.ClickByJsExecutor(CollapseAll, "CollapseAll");
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.ClickByJsExecutor(ExpandAll, "ExpandAll");
                BrowserDriver.Sleep(2000);
            }

        }
        public void  SelectBox(IList<string> stormordercodes)
        { string DropDownValue="",   partnercode="";
            IWebElement BoxDropDownExpand=null, BoxDropDownValue=null, OrderItemsList=null, MoveToBox=null, CreateBox=null, SaveBox=null;
            foreach (string stormordercode in stormordercodes)
            {
                if (!stormordercode.Contains("HS"))
                {
                    switch (stormordercode.Substring(0, 3))
                    {
                        case "BSW":
                            partnercode = "BSW";
                            DropDownValue = "Burberry MB1";
                            break;

                        case "HSW":
                            partnercode = "HSW";

                            DropDownValue = "Automated packing carton - Large (52x35x13.1)";
                            break;

                        case "HSS":
                            partnercode = "HSS";
                            DropDownValue = "Automated packing carton - Large (52x35x13.1)";
                            break;
                    }
                    ExpandAllOrders();
                    BoxDropDownExpand = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//div[@class='FF-dropdown']"));
                    BoxDropDownValue = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//div[@class='FF-dropdown']//li[text()='" + DropDownValue + "']"));

                    if (WebHandlers.Instance.IsElementPresent(By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//span[@class='glyphs icon-arrow_right JS-FF-packaging-trigger-right FF-packaging-trigger-right']")))
                    {
                        OrderItemsList = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//ul[@id='listItems']/li"));
                        MoveToBox = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//span[@class='glyphs icon-arrow_right JS-FF-packaging-trigger-right FF-packaging-trigger-right']"));

                        while (WebHandlers.Instance.IsElementPresent(By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//ul[@id='listItems']/li")))
                        {
                            WebHandlers.Instance.Click(MoveToBox, "MoveToBox");
                            BrowserDriver.Sleep(500);

                        }

                        BrowserDriver.Sleep(3000);
                        WebHandlers.Instance.Click(BoxDropDownExpand, "BoxDropDownExpand");

                        BrowserDriver.Sleep(2000);

                        WebHandlers.Instance.ClickByJsExecutor(BoxDropDownValue, "BoxDropDownvalue");
                    }

                    else
                    {
                       IWebElement BoxDropDownExp = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//div[@class='FF-dropdown']/div"));
                        BrowserDriver.Sleep(3000);
                       
                        WebHandlers.Instance.Click(BoxDropDownExp, "BoxDropDownExpand");
                        WebHandlers.Instance.Click(BoxDropDownExp, "BoxDropDownExpand");
                        BrowserDriver.Sleep(2000);
                        WebHandlers.Instance.ClickByJsExecutor(BoxDropDownValue, "BoxDropDownvalue");
                        //IWebElement BoxDropDownSingleQuantity = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//div[@class='FF-dropdown custom-select']//select"));
                        //WebHandlers.Instance.DropDownSetByVal(BoxDropDownValue, DropDownValue, "BoxDropDown");
                    }
                    
                    if (WebHandlers.Instance.IsElementPresent(By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//button[contains(@data-tstid,'Submit_Create_Box')]")))
                    { 
                        CreateBox = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//button[contains(@data-tstid,'Submit_Create_Box')]"));
                        WebHandlers.Instance.Click(CreateBox, "CreateBox");
                    }
                  
                        SaveBox = WebHandlers.Instance.GetElement(driver, By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='" + partnercode + "']/../../..//button[contains(@data-tstid,'Submit_Step')]"));

                    
                    BrowserDriver.Sleep(2000);
                    WebHandlers.Instance.Click(SaveBox, "SaveBox");

                    BrowserDriver.Sleep(4000);
                    if (!WebHandlers.Instance.Elementnotpresent(SaveBox, "SaveBox"))
                        Assert.Fail("Box not saved successfully");

                    ExpandAllOrders();
                }

                //foreach (IWebElement CreateBox in CreateBoxes)
                //{
                //    WebHandlers.Instance.Click(CreateBox, "CreateBox");
                //    BrowserDriver.Sleep(2000);
                //    WebHandlers.Instance.Click(SaveBoxButtons[CreateBoxes.IndexOf(CreateBox)]);
                //    BrowserDriver.Sleep(4000);
                //    if (!WebHandlers.Instance.Elementnotpresent(SaveBoxButtons[CreateBoxes.IndexOf(CreateBox)], "SaveBox"))
                //        Assert.Fail("Box not saved successfully");
                //    //ExpandAllOrders();
                //}


                BrowserDriver.Sleep(2000);
              

            }         
           
        }


        #endregion

        #region Validation   

        private void RetryOrderSearch(string portalOrderNumber, int maxRetries = 10, int delayInMilliSeconds = 30000)
        {
            bool isFound = false;
            var attempts = 0;

            while (!isFound)
            {
                if (WebHandlers.Instance.ElementPresent(NoOrderFound))
                {
                    if (attempts == maxRetries)
                        break;

                    Task.Delay(delayInMilliSeconds).Wait();
                    SearchOrderNumber(portalOrderNumber);
                    isFound = false;
                    attempts++;
                }
                else
                {
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                if (WebHandlers.Instance.ElementPresent(NoOrderFound))
                {
                    Assert.Fail($"No order found for portal order {portalOrderNumber}");
                }
            }
        }

        #endregion

        #region
        private List<string> GetOrderStatus()
        {
            List<string> status = new List<string>();

            List<string> attributes = WebHandlers.Instance.GetAttributeValueFromMultipleElements(ProgressBar, "style");

            foreach (string s in attributes)
            {
                int width = Convert.ToInt32(s.Split(new string[] { "width: " }, StringSplitOptions.None)[1].Replace("%;", ""));

                if (width > 15 && width <= 20)
                {
                    status.Add("CHECK STOCK");
                }
                else if (width > 21 && width <= 40)
                {
                    status.Add("PAYMENT");
                }
                else if (width > 40 && width <= 60)
                {
                    status.Add("PACKAGING");
                }
                else if (width > 60 && width <= 80)
                {
                    status.Add("AWB");
                }
                else if (width > 80 && width <= 100)
                {
                    status.Add("PRINT");
                }
            }

            return status;
        }

        public string GetOrderStatusOfSpecificOrder(string stormordercode)
        {
            IWebElement ProgressBar = WebHandlers.Instance.GetElement(driver,By.XPath("//div[contains(@data-tstid,'Div_Order_Line')]/div/div/span[text()='"+ stormordercode.Substring(0,3)+"']/parent::div/following-sibling::div//div[@class='progress-bar']"));

            string attribute=WebHandlers.Instance.GetAttribute(ProgressBar, "style");

            string status="";

            int width = Convert.ToInt32(attribute.Split(new string[] { "width: " }, StringSplitOptions.None)[1].Replace("%;", ""));

            if (width > 15 && width <= 20)
            {
                status="CHECK STOCK";
            }
            else if (width > 21 && width <= 40)
            {
                status = "PAYMENT";
            }
            else if (width > 40 && width <= 60)
            {
                status = "PACKAGING";
            }
            else if (width > 60 && width <= 80)
            {
                status = "AWB";
            }
            else if (width > 80 && width <= 100)
            {
                status="PRINT";
            }
            return status;
        }
        #endregion
    }
}
