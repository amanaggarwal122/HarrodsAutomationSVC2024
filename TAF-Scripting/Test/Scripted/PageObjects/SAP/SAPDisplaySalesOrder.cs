using NUnit.Framework;
using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TAF_SAP;
using TAF_Scripting.Test.Common;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class SAPDisplaySalesOrder
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;
      //  public Boolean deliveryStatus = false;


        public GuiTextField PurchaseOrderNo => _frameWindow.FindById<GuiTextField>("usr/txtRV45S-BSTNK");
        public GuiButton SearchButton => _frameWindow.FindById<GuiButton>("usr/btnBT_SUCH");
        public GuiButton PromptTickButton => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");

        public GuiButton DocumentFlow => _frameWindow.FindById<GuiButton>("tbar[1]/btn[5]");
        public GuiTree DeliveryCreated => _frameWindow.FindById<GuiTree>("usr/shell/shellcont[1]/shell[1]");

        public GuiButton testprevious => _frameWindow.FindById<GuiButton>("tbar[0]/btn[3]");
        public GuiButton testlogoff => _frameWindow.FindById<GuiButton>("tbar[0]/btn[15]");
        public GuiGridView docDetails => _frameWindow.FindById<GuiGridView>("shellcont/shell");


        //For STO

        public GuiMenu stoEditMenu => _frameWindow.FindById<GuiMenu>("mbar/menu[3]/menu[13]/menu[0]/menu[0]");
        public GuiTextField txtDescription => _frameWindow.FindById<GuiTextField>("usr/tblSAPDV70ATC_NAST3/txtDV70A-MSGNA[2,0]");
        public GuiButton procLogBtn => _frameWindow.FindById<GuiButton>("tbar[1]/btn[26]");
        public GuiLabel docNumberlbl => _frameWindow.FindById<GuiLabel>("usr/lbl[6,6]");
        public GuiButton okBtn => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SAPDisplaySalesOrder(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;           
        }

        public void onSalesOrderScreen()
        {
            if (PurchaseOrderNo == null)
                _session.GotoTransaction("/NVA03");
        }

        public void SwitchWindow(GuiSession guiSession, int windowIndex)
        {
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(guiSession, windowIndex);
        }
      
        public void selectOrder(string OrderNumber)
        {
            onSalesOrderScreen();
            SAPHandlers.Instance.EnterTextInGuiTextField(PurchaseOrderNo, OrderNumber);
            SAPHandlers.Instance.ClickButton(SearchButton);

            string Message = SAPHandlers.Instance.GetStatusBarMessage(_session, 0);
            if (Message.Contains("No document selected"))
            {
                Assert.Fail($"Document not created");
            }
        }

        public void searchOrder()
        {
            if(PromptTickButton!=null)
            {
                SAPHandlers.Instance.ClickButton(PromptTickButton);
                SAPHomePage saphomePage = new SAPHomePage(_session);
                saphomePage.ValidatePageTitle("Display Farfetch");
            }
            else
            {
                Assert.Fail($"Document not created");
            }
        }

        public void ClickOnDocumentFlow()
        {
            SAPHandlers.Instance.ClickButton(DocumentFlow);
        }
        public string VerifyDocumentFlowDetails(String Document)
        {

            Document = Document.ToLower();
            dynamic Key = SAPHandlers.Instance.GetTreeNodeText(DeliveryCreated, Document);
            Assert.True(Key.Contains(Document), "" + Document + " is created");
            return Key;
        }

        public string getDocumentNo(string documentName ,string ColumnName, bool failTestCase = true)
        {
            string docNo = string.Empty;
            string key =  SAPHandlers.Instance.SelectTreeNodeByText_ReturnKey(DeliveryCreated, documentName);
            if (key == "" && failTestCase == true)
                Assert.Fail($"{documentName} not created");

            if(docDetails!=null)
            {
                docNo = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(docDetails, 0, ColumnName);
            }
           
            if (docNo == "" && failTestCase == true)
                Assert.Fail($"{documentName} number not found");

            return docNo;
        }

        public void OpenDocumentNo(string documentName, string ColumnName, bool failTestCase = true)
        {
            string docNo = string.Empty;
            string key = SAPHandlers.Instance.SelectTreeNodeByText_ReturnKey(DeliveryCreated, documentName);
            if (key == "" && failTestCase == true)
                Assert.Fail($"{documentName} not created");           
        }

        public string fetchDeliveryNumber()
        {
            dynamic Key = VerifyDocumentFlowDetails("Delivery");
            string DeliveryNumber = Key.Split(new string[] { "delivery " }, StringSplitOptions.None)[1].Split(new string[] { " " }, StringSplitOptions.None)[0];           
            return DeliveryNumber;
        }

        public string  verifySTO(string orderNumber)
        {
            selectOrder(orderNumber);
            SwitchWindow(_session, 1);
            searchOrder();
            SwitchWindow(_session, 0);

            SAPHandlers.Instance.SelectMenuItem(stoEditMenu);
            SAPHomePage saphomePage = new SAPHomePage(_session);
            saphomePage.ValidatePageTitle("Display Farfetch Order");

            if(txtDescription==null)
            {
                log.Info("STO not created");
                Assert.Fail($"STO not created");
            }
               

            string Desc =   SAPHandlers.Instance.GetTextFromGuiTextField(txtDescription);
            if (string.IsNullOrEmpty(Desc))
            {
                log.Info("STO not created");
                Assert.Fail($"STO not created");
            }

            SAPHandlers.Instance.ClickButton(procLogBtn);
            SwitchWindow(_session, 1);
            string STOdocNo = SAPHandlers.Instance.GetLabelText(docNumberlbl);

            log.Info(STOdocNo);
            var matches = Regex.Matches(STOdocNo, @"\s\d+");
            STOdocNo = matches[0].Value.Trim();
            SAPHandlers.Instance.ClickButton(okBtn);
            SwitchWindow(_session, 0);         
            
            return STOdocNo;
        }
    }
}
