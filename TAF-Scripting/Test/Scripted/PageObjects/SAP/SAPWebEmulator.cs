using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Scripting.Test.Common;
using TAF_Web.Scripted.Web;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPWebEmulator
    {
        public IWebDriver driver;
        private Configuration config = null;

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [FindsBy(How = How.XPath, Using = "//*[@id='sap-user']")]
        private IWebElement Username;

        [FindsBy(How = How.XPath, Using = "//*[@id='sap-password']")]
        private IWebElement Password;

        [FindsBy(How = How.XPath, Using = "//input[@value='Logon'][@type='button']")]
        private IWebElement Logon;

        [FindsBy(How = How.XPath, Using = "//*[@id='sapSL_DEFAULT_BUTTON']")]
        private IWebElement continueBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'To Confirmation')]")]
        private IWebElement ToConfirmation;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Pick from Shop Floor')]")]
        private IWebElement PickFromSF;
        

        [FindsBy(How = How.Id, Using = "WD5B")]
        private IWebElement btnPickAlloc;

        //[FindsBy(How = How.XPath, Using = "//td[@id='WD45']//div[1]]")]
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'lsButton lsTbarBtnStd')]")]
        private IWebElement AllocatedPicking;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'has no shop floor picks')]")]
        private IWebElement Information;
        
        [FindsBy(How = How.Id, Using = "//span[contains(text(), 'no picks')]")]
        private IWebElement InformationMsg;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Pick Confirmed')]")]
        private IWebElement PickConfirm;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'lsControl--explicitwidth lsButton')]")]
        private IWebElement ConfirmChecked;

        

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Tracking')]")]
        private IWebElement Tracking;
        
        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Group Delivery')]")]
        private IWebElement GroupDeliv;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='WD55']")]
        private IWebElement ScanGI;

        [FindsBy(How = How.XPath, Using = "//*[@id='WD76']")]
        private IWebElement Location;

        [FindsBy(How = How.XPath, Using = "//span[@id='WD76-r']//div[1]")]
        private IWebElement LocationPopup;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'KCC B0 OUT')]")]
        private IWebElement LocationValue;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='URLSPW-0']")]
        private IWebElement iframeLocationValue;

        [FindsBy(How = How.XPath, Using = "//*[@id='WD7E']")]
        private IWebElement Register;

        [FindsBy(How = How.XPath, Using = "//*[@id='WD86']")]
        private IWebElement Shipment;

        [FindsBy(How = How.XPath, Using = "//*[@id='WD8E']")]
        private IWebElement Scan;
       
        [FindsBy(How = How.XPath, Using = "//td[@id='WD9D']//div[1]")]
        private IWebElement DoneBtn;
        
        [FindsBy(How = How.XPath, Using = "//span[@id='WDBA']//a[1]")]
        private IWebElement lblStatus;

        [FindsBy(How = How.XPath, Using = "//*[@id='WD9A']")]
        private IWebElement GroupBtn;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='WD9C']")]
        private IWebElement ListHUBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='WDA5']")]
        private IWebElement GroupPrinter;

        [FindsBy(How = How.XPath, Using = "//*[@id='WD75']")]
        private IWebElement ScanHU;

        [FindsBy(How = How.XPath, Using = "(//div[@ti='0'])[3]")]
        private IWebElement ExitWithPFSF;

        [FindsBy(How = How.XPath, Using = "//div[@title='Cancel ']")]
        private IWebElement ExitMenu;

        [FindsBy(How = How.XPath, Using = "//td[@colspan='4']//div[1]")]
        private IWebElement BackFromGD;

        //  [FindsBy(How = How.XPath, Using = "//*[@id='WDBC']")]
        [FindsBy(How = How.XPath, Using = "(//span[@class='lsTextView--root lsControl--valign']//span)[2]")]
        private IWebElement GropuCreatedNo;

        // [FindsBy(How = How.XPath, Using = "//span[@id='WD77-r']//span[1]")]
        // [FindsBy(How = How.Id, Using = "WD82")]
        // [FindsBy(How = How.Id, Using = "WD85")]      
        [FindsBy(How = How.CssSelector, Using = "div#WD7F>div>table>tbody>tr>td:nth-of-type(2)>span>span")]
        private IWebElement lblDelvNo;

        //[FindsBy(How = How.XPath, Using = "//*[@id='WDC1']")]
        //[FindsBy(How = How.XPath, Using = "//*[@id='WDD6']")]  
        // [FindsBy(How = How.XPath, Using = "//*[@id='WDD2']")]
        [FindsBy(How = How.XPath, Using = "//input[@ct='CBS']")]
        private IWebElement PrinterName;
       

        //[FindsBy(How = How.XPath, Using = "//*[@id='WDCB']")]
        // [FindsBy(How = How.XPath, Using = "//span[@id='WDCB-r']//span[1]")]
        // [FindsBy(How = How.Id, Using = "WDE0")]
        [FindsBy(How = How.Id, Using = "WDDC")]
        private IWebElement ArticleNoModal;

        //[FindsBy(How = How.XPath, Using = "//*[@id='WD012D']")]
        //[FindsBy(How = How.XPath, Using = "//*[@id='WD0144']")]
        // [FindsBy(How = How.XPath, Using = "//*[@id='WDE5']")]
        [FindsBy(How = How.XPath, Using = "(//span[contains(@class,'urEdf2Whl lsField')]//input)[2]")]        
        private IWebElement ArticleNumber;
       


        // [FindsBy(How = How.Id, Using = "WDFE")]
        [FindsBy(How = How.Id, Using = "WDFA")]
        private IWebElement QtyRqd;

        [FindsBy(How = How.XPath, Using = "(//input[contains(@class,'lsField__input urEdf2TxtEnbl')])[3]")]
        private IWebElement QtyPicked;

        //WD0100
        //[FindsBy(How = How.XPath, Using = "//*[@id='WD0115']")]
        //[FindsBy(How = How.XPath, Using = "//*[@id='WD0111']")]
        [FindsBy(How = How.XPath, Using = "(//input[@ct='CBS'])[2]")]
        private IWebElement HandlingUnit;

        

        //[FindsBy(How = How.XPath, Using = "//input[contains(@class,'lsField__input urEdf2TxtEnbl')]")]
        //[FindsBy(How = How.XPath, Using = "//*[@id='WD72']")]
        [FindsBy(How = How.Id, Using = "WD72")]
        private IWebElement lblPickingDelvNo;

        [FindsBy(How = How.Id, Using = "WDC2")]
        private IWebElement txtDisAllocate;

        [FindsBy(How = How.Id, Using = "WDCA")]
        private IWebElement txtAllocate;

        [FindsBy(How = How.Id, Using = "WDD8")]
        private IWebElement txtDisArticleNO;

        [FindsBy(How = How.Id, Using = "WDDF")]
        private IWebElement txtNewArticleNO;

        [FindsBy(How = How.Id, Using = "WDE9")]
        private IWebElement txtAvailQty;

        [FindsBy(How = How.Id, Using = "WDEF")]
        private IWebElement txtQty;

        [FindsBy(How = How.XPath, Using = "//input[@id='WD0103']")]
        private IWebElement txtPickHU;

        [FindsBy(How = How.Id, Using = "WD0145")]
        private IWebElement txtCloseHU;

        [FindsBy(How = How.Id, Using = "WD014C")]
        private IWebElement txtPrinter;

        [FindsBy(How = How.Id, Using = "WD0156")]
        private IWebElement btnCloseHU;

        [FindsBy(How = How.Id, Using = "WD0170")]
        private IWebElement lblConfirmMsg;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'lsControl--explicitwidth lsButton')]")]
        private IWebElement btnConfirmPick;

        // [FindsBy(How = How.XPath, Using = "//div[@id='WD011E']")]
        // [FindsBy(How = How.XPath, Using = "//div[@id='WD0133']")]          
        [FindsBy(How = How.XPath, Using = "//*[@id='WD012F']")]
        private IWebElement btnNext;

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'lsControl--explicitwidth lsButton')])[2]")]
        private IWebElement btnPickingNext;

        [FindsBy(How = How.XPath, Using = "//*[@id='WD86']")]
        private IWebElement btnDivPickingNext;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'lsButton lsTbarBtnStd')]")]
        private IWebElement btnSelectOrder;

        [FindsBy(How = How.XPath, Using = "//div[@id='WD011C']")]
        private IWebElement btnLast;

        [FindsBy(How = How.XPath, Using = "//td[@id='WD3B']//div[1]")]
        private IWebElement btnLogout;

        public SAPWebEmulator(IWebDriver driver, Configuration configuration)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            config = configuration;
        }

        public void LogintoWebEmulator()
        {
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(Username, config.AllocUser, $"Entered {config.AllocUser} for username");
            WebHandlers.Instance.EnterText(Password, config.AllocUserPassword, $"Entered ******** for password");
            WebHandlers.Instance.ClickByJsExecutor(Logon, "Login");
           

            if (WebHandlers.Instance.WebElementExists(continueBtn))
            {
                BrowserDriver.Sleep(2000);
                WebHandlers.Instance.ClickByJsExecutor(continueBtn, "Continue if already login");
            }  
        }

        public void ConfirmToPicking()
        {
            BrowserDriver.Sleep(2000);
            if (WebHandlers.Instance.WebElementExists(ToConfirmation))
            {
                WebHandlers.Instance.ClickByJsExecutor(ToConfirmation, "Confirm Picking");
            }
            else
            {
                Assert.Fail("Confirming option not visible");
            }
        }

        public void PickFromSite(string site)
        {
            BrowserDriver.Sleep(2000);

            if(site =="SF")
            {
                if (WebHandlers.Instance.WebElementExists(PickFromSF))
                {
                    WebHandlers.Instance.ClickByJsExecutor(PickFromSF, "Picking from shop Floor");
                }
                else
                {
                    Assert.Fail("Picking option not visible");
                }

                if (WebHandlers.Instance.WebElementExists(Information))
                {
                   // WebHandlers.Instance.ClickByJsExecutor(Information, "User has no shop floor picks");
                    Assert.Fail("User has no shop floor picks");
                }

                if(WebHandlers.Instance.WebElementExists(btnPickAlloc))
                {
                    WebHandlers.Instance.ClickByJsExecutor(btnPickAlloc, "Pick by allocation");
                }
            }
            else
            {
                if (WebHandlers.Instance.WebElementExists(AllocatedPicking))
                {
                    WebHandlers.Instance.ClickByJsExecutor(AllocatedPicking, "Allocate Picking");
                }
                else
                {
                    Assert.Fail("Picking allocation option not visible");
                }

                if (WebHandlers.Instance.WebElementExists(InformationMsg))
                {
                   // WebHandlers.Instance.ClickByJsExecutor(InformationMsg, "User has no picks");
                    Assert.Fail("User has no shop floor picks");
                }
            }
            
        }

        public string CompletePickingRequest(string DeliveryNo, string supplySite)
        {
            string HU;
            if (supplySite == "SF")
            {
                HU = SF_PickingConfirmation(DeliveryNo);
            }
            else
            {
                HU = PickingConfirmation(DeliveryNo);
            }

            return HU;
        }

        public string PickingConfirmation(string DeliveryNo)
        {
            string HU = string.Empty;
            string delNo;
            string firstOrder = string.Empty;

            delNo = WebHandlers.Instance.GetTextOfElement(lblPickingDelvNo);

            int orderCount = 0;
            while (DeliveryNo != delNo)
            {
                if (orderCount == 0)
                    firstOrder = delNo;

                if (firstOrder == delNo && orderCount != 0)
                    break; 

                if (WebHandlers.Instance.WebElementExists(btnPickingNext))
                {
                     WebHandlers.Instance.ClickByJsExecutor(btnPickingNext, "Next");
                }
                BrowserDriver.Sleep(1000);
                delNo = WebHandlers.Instance.GetTextOfElement(lblPickingDelvNo);

                orderCount++;
            }

            if (DeliveryNo != delNo)
                Assert.Fail("Assigned order not found for picking ");

            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.ClickByJsExecutor(btnSelectOrder, "Select order"); 

            string alloc = WebHandlers.Instance.GetTextOfElement(txtDisAllocate);
            WebHandlers.Instance.EnterText(txtAllocate, alloc, $"Entered {alloc} as SRC");

            string articleNo = WebHandlers.Instance.GetTextOfElement(txtDisArticleNO);

            string newArticleNo = articleNo.Substring(articleNo.Length - 10);
            newArticleNo = string.Concat("0000", newArticleNo, "0000000");
            WebHandlers.Instance.EnterText(txtNewArticleNO, newArticleNo, $"Entered {newArticleNo} as Article Number");

            string qty = WebHandlers.Instance.GetTextOfElement(txtAvailQty);
            WebHandlers.Instance.EnterText(txtQty ,qty, $"Entered {qty} as Qunatity");

            HU = GethandlingUnitFromExcel();
            WebHandlers.Instance.EnterText(txtPickHU, HU, $"Entered {HU} as Handling Unit");

            if (WebHandlers.Instance.WebElementExists(btnConfirmPick))
            {
                WebHandlers.Instance.Click(btnConfirmPick, "Confirm");
                BrowserDriver.Sleep(1500);
            }

            DataFilesUtil.SaveDataToExcel("HU_Shipment", "HU", "IsUsed", HU, "Yes");

            WebHandlers.Instance.EnterText(txtCloseHU, HU, $"Entered {HU} as Handling Unit");
            WebHandlers.Instance.EnterText(txtPrinter, "TZ28", $"Entered  TZ28 as printer");
            WebHandlers.Instance.Click(btnCloseHU, "Close HU");

            //string msg = WebHandlers.Instance.GetTextOfElement(lblConfirmMsg);

            //if(msg.Contains("is not on delivery"))
            //{
            //    Assert.Fail(msg);
            //}
            return HU;
        }

        public string SF_PickingConfirmation(string DeliveryNo)
        {
            string HU;
            string delNo;
            string firstOrder = string.Empty;

            delNo = WebHandlers.Instance.GetTextOfElement(lblDelvNo);

            int orderCount = 0;
            while (DeliveryNo != delNo)
            {
                if (orderCount == 0)
                    firstOrder = delNo;

                if (firstOrder == delNo && orderCount != 0)
                    break;

                if (WebHandlers.Instance.WebElementExists(btnNext))
                {
                      WebHandlers.Instance.ClickByJsExecutor(btnNext, "Next");
                }

                BrowserDriver.Sleep(1000);
                delNo = WebHandlers.Instance.GetTextOfElement(lblDelvNo);

                orderCount++;
            }

            if (DeliveryNo != delNo)
                Assert.Fail("Assigned order not found for picking ");
            
            BrowserDriver.Sleep(1000);
            WebHandlers.Instance.EnterText(PrinterName, "TZ28" + Keys.Enter, $"Entered tz28 as printer");

            BrowserDriver.Sleep(1500);
            var articleNoModal= WebHandlers.Instance.GetTextOfElement(ArticleNoModal);
            string newArticleNo = articleNoModal.Substring(articleNoModal.Length - 10);
            newArticleNo = string.Concat("0000", newArticleNo, "0000000");

            double qtyRqd =Convert.ToDouble( WebHandlers.Instance.GetTextOfElement(QtyRqd));
            double qtyPikd = Convert.ToDouble(WebHandlers.Instance.GetTextOfElement(QtyPicked));
            while (qtyPikd  < qtyRqd)
            {
                WebHandlers.Instance.EnterText(ArticleNumber, newArticleNo + Keys.Enter, $"Entered {newArticleNo} as Article Number");
                qtyPikd++;
            }
            HU = GethandlingUnitFromExcel();
            string HU1 = HU;
            WebHandlers.Instance.EnterText(HandlingUnit, HU1 + Keys.Enter, $"Entered {HU} as Handling Unit");



            BrowserDriver.Sleep(1500);
            if (WebHandlers.Instance.WebElementExists(PickConfirm))
            {
                log.Info("Pick confirmed");
            }
            else
            {
                if (WebHandlers.Instance.WebElementExists(ConfirmChecked))
                {
                    WebHandlers.Instance.ClickByJsExecutor(ConfirmChecked, "Confirm");
                    BrowserDriver.Sleep(1500);
                    if (WebHandlers.Instance.WebElementExists(PickConfirm))
                    {
                        log.Info("Pick confirmed");
                    }
                }
            }


            DataFilesUtil.SaveDataToExcel("HU_Shipment", "HU", "IsUsed", HU, "Yes");

            if (WebHandlers.Instance.WebElementExists(ExitWithPFSF))
            {
                WebHandlers.Instance.ClickByJsExecutor(ExitWithPFSF, "Exit from  PFSF confirmation");
            }
            BrowserDriver.Sleep(1000);
            if (WebHandlers.Instance.WebElementExists(ExitMenu))
            {
                WebHandlers.Instance.ClickByJsExecutor(ExitMenu, "Exit");
            }

            BrowserDriver.Sleep(1000);
            if (WebHandlers.Instance.WebElementExists(btnLogout))
            {
                WebHandlers.Instance.ClickByJsExecutor(btnLogout, "Logout");
            }
            return HU;
        }

        public string CreateGroupDelivery(string GroupNumber)
        {
            if (WebHandlers.Instance.WebElementExists(Tracking))
            {
                WebHandlers.Instance.ClickByJsExecutor(Tracking, "Tracking");
            }
            else
            {
                Assert.Fail("Tracking option not visible");
            }

            if (WebHandlers.Instance.WebElementExists(GroupDeliv))
            {
                WebHandlers.Instance.ClickByJsExecutor(GroupDeliv, "Group Delivery");
            }
            else
            {
                Assert.Fail("Group Delivery option not visible");
            }
            BrowserDriver.Sleep(1000);
           // WebWaitHelper.Instance.WaitForElementPresence(ScanHU);
            WebHandlers.Instance.EnterText(ScanHU, GroupNumber + Keys.Enter, $"Entered {GroupNumber} as Scan Handling Unit");

            //WebWaitHelper.Instance.WaitForElementPresence(GroupBtn);
            BrowserDriver.Sleep(1000);
            if (WebHandlers.Instance.WebElementExists(GroupBtn))
            {
                WebHandlers.Instance.ClickByJsExecutor(GroupBtn, "Group");
            }
            else
            {
                Assert.Fail("Group option not visible");
            }
            BrowserDriver.Sleep(1500);
            
            WebHandlers.Instance.EnterText(GroupPrinter, "TZ28" + Keys.Enter, $"Entered TZ28 as printer");
            // WebHandlers.Instance.ClickByJsExecutor(ListHUBtn, "List HU");
            BrowserDriver.Sleep(1000);
           // WebWaitHelper.Instance.WaitForElementPresence(GropuCreatedNo);
            string grpCreatedNo = WebHandlers.Instance.GetTextOfElement(GropuCreatedNo);

            BrowserDriver.Sleep(1000);
            if (WebHandlers.Instance.WebElementExists(BackFromGD))
            {
                WebHandlers.Instance.ClickByJsExecutor(BackFromGD, "Back");
            }

            BrowserDriver.Sleep(1000);
            if (WebHandlers.Instance.WebElementExists(ExitMenu))
            {
                WebHandlers.Instance.ClickByJsExecutor(ExitMenu, "Exit");
            }

            BrowserDriver.Sleep(1000);
            if (WebHandlers.Instance.WebElementExists(btnLogout))
            {
                WebHandlers.Instance.ClickByJsExecutor(btnLogout, "Logout");
            }
            return grpCreatedNo;
        }


        public void ScanGIShipment(string ShipmentNo , string GroupNo)
        {
            if (WebHandlers.Instance.WebElementExists(Tracking))
            {
                WebHandlers.Instance.ClickByJsExecutor(Tracking, "Tracking");
            }
            else
            {
                Assert.Fail("Tracking option not visible");
            }

            BrowserDriver.Sleep(1200);
            if (WebHandlers.Instance.WebElementExists(ScanGI))
            {
                WebHandlers.Instance.ClickByJsExecutor(ScanGI, "Scan GI Shipment");
            }
            else
            {
                Assert.Fail("Scan GI Shipment option not visible");
            }

            BrowserDriver.Sleep(1500);

            WebHandlers.Instance.EnterText(Location, "B0O - KCC B0 OUT", $"Entered 'B0O - KCC B0 OUT' as Location");

           
            WebHandlers.Instance.EnterText(Register, "YXZ", $"Entered 'YXZ' as Registration");
            WebHandlers.Instance.EnterText(Shipment, ShipmentNo, $"Entered {ShipmentNo} as Shipment");
            BrowserDriver.Sleep(1500);
            WebHandlers.Instance.EnterText(Scan, GroupNo, $"Entered {GroupNo} as Scan");
            BrowserDriver.Sleep(4000);
          
            WebHandlers.Instance.Click(DoneBtn, "Done");

            BrowserDriver.Sleep(1500);
            if (WebHandlers.Instance.WebElementExists(lblStatus))
            {
                string status = WebHandlers.Instance.GetTextOfElement(lblStatus);
                if (status.Contains("Wrong barcode scanned"))
                    Assert.Fail("Wrong barcode scanned. Enter 10 to 20 digits.");
            }
        }
        public string GethandlingUnitFromExcel()
        {
            string HU = string.Empty;
            string isUsed;
            Dictionary<string, Dictionary<string, string>> HandlingUnits = new Dictionary<string, Dictionary<string, string>>();
            HandlingUnits = DataFilesUtil.GetAllData("HU_Shipment", "HU");

            for (int row = 1; row <= HandlingUnits.Count; row++)
            {
                Dictionary<string, string> valuesset = HandlingUnits[row.ToString()];
                HU = valuesset["HandlingUnit"];
                isUsed = valuesset["IsUsed"];

                if(string.IsNullOrEmpty(isUsed))
                {
                    break;
                }
            }
            if(string.IsNullOrEmpty(HU))
            {
                Assert.Fail("Handling Unit not available");
            }
            return HU;
        }
    }
}
