using TAF_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sapfewse;
using NUnit.Framework;
using TAF_Scripting.Test.Scripted.PageObjects;
using TAF_Scripting.Test.Scripted.PageObjects.SAP;
using TAF_Scripting.Test.Common;
using System.Threading;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class SAPRepacking
    {
        public static GuiSession _session;
        public static GuiFrameWindow _frameWindow;
        public string RandomHU= null;
        
        public GuiButton WorkstationButton => _frameWindow.FindById<GuiButton>("tbar[1]/btn[6]");              
        public GuiTextField WorkStation => _frameWindow.FindById<GuiTextField>("usr/txtGV_WORKSTATION");
        public GuiTextField SourceHU => _frameWindow.FindById<GuiTextField>("usr/txtGV_SRC_HU");
        public GuiTextField DestinationHU => _frameWindow.FindById<GuiTextField>("usr/txtGV_HU");


        public GuiTextField PackingDialogHU => _frameWindow.FindById<GuiTextField>("usr/txtGV_DEST_HUIDENT");
        public GuiButton F7Confirm => _frameWindow.FindById<GuiButton>("usr/btn%#AUTOTEXT002");


        public GuiButton F6PackWithQty => _frameWindow.FindById<GuiButton>("usr/btnQTY_PACK");

        public GuiTextField Product => _frameWindow.FindById<GuiTextField>("usr/txtGV_MATNR");

        public GuiTextField Quantity => _frameWindow.FindById<GuiTextField>("usr/txtGV_QUANTITY");
        //public GuiButton DeliveryOrderPromptTick => _frameWindow.FindById<GuiButton>("tbar[0]/btn[8]");
        public GuiGridView SourceHUContent => _frameWindow.FindById<GuiGridView>("usr/cntlSOURCE_HU_CONTENT/shellcont/shell");
        public GuiButton TickPackWithQuantity => _frameWindow.FindById<GuiButton>("tbar[0]/btn[48]");

        public GuiButton F8Repack => _frameWindow.FindById<GuiButton>("usr/btnPOST");
        // locators for PRDO
        public GuiTabStrip MainOutboundDeliveryTab => _frameWindow.FindById<GuiTabStrip>("usr/subSUB_COMPLETE_ODP1:/SCWM/SAPLUI_DLV_PRD:3000/tabsTABSTRIP_ODP1");


        public GuiGridView StatusGrid => _frameWindow.FindById<GuiGridView>("usr/subSUB_COMPLETE_ODP1:/SCWM/SAPLUI_DLV_PRD:3000/tabsTABSTRIP_ODP1/tabpOK_ODP1_TAB9/ssubSUB_ODP1_TAB9:/SCWM/SAPLUI_DLV_CORE:3290/ssubSUB_ODP1_9_CONTENT:/SCWM/SAPLUI_DLV_CORE:3291/cntlCONTAINER_ALV_ODP1_9/shellcont/shell");

        public GuiToolbar RefreshGridButton => _frameWindow.FindById<GuiToolbar>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_DLV_PRD:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");

        public GuiButton btnOk => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");
        public GuiTextField txtSerial => _frameWindow.FindById<GuiTextField>("usr/txtGV_SERIAL");
        public GuiButton btnSerialConfirm => _frameWindow.FindById<GuiButton>("usr/btn%#AUTOTEXT002");
        public GuiButton F9PrintButton => _frameWindow.FindById<GuiButton>("usr/btnPRINT");

        public GuiButton OKButton => _frameWindow.FindById<GuiButton>("usr/btnOK");


        public GuiButton getDocDetailsButton => _frameWindow.FindById<GuiButton>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_DLV_PRD:2003/btnCMD_GO");
        public GuiButton OkButtonPackingDialogPopUp => _frameWindow.FindById<GuiButton>("usr/btnOK");

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
        public SAPRepacking(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
          
        }

       


        public string Repack(string HandlingUnitNo,string DestinationHUVal,  bool export = false)
        {

            log.Info("REPACKING STARTED");
            _session.GotoTransaction("/nZ1114");

            if(export)
            {
                if(WorkstationButton!=null)
                        SAPHandlers.Instance.ClickButton(WorkstationButton);
                SAPHandlers.Instance.EnterTextInGuiTextField(WorkStation, "EX01");
            }                
            else
            {
                SAPHandlers.Instance.EnterTextInGuiTextField(WorkStation, "MP04");
            }
            
            SAPHandlers.Instance.SendKeysByWindow(_session, SAPKeys.Enter);
            SAPHandlers.Instance.EnterTextInGuiTextField(SourceHU, HandlingUnitNo);
            int wndCountBeforeClick = _session.Children.Count;
            SAPHandlers.Instance.SendKeysByWindow(_session, SAPKeys.Enter);
            //If its a gift
            int wndCountAfterClick = _session.Children.Count;

            if(wndCountAfterClick> wndCountBeforeClick)
            {
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
                SAPHandlers.Instance.ClickButton(btnOk);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
            }
            
             AddHandlingUnit(DestinationHUVal);

            int rowCount = SAPHandlers.Instance.GridGetRowCount(SourceHUContent);
            while (rowCount > 0)
            {
                wndCountBeforeClick = _session.Children.Count;
                F6PackWithQuantity();
                wndCountAfterClick = _session.Children.Count;

                //Window to enter the serial number
                if (wndCountAfterClick > wndCountBeforeClick)
                {
                    _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
                    string serialNo = RandomSerialNumber();
                    SAPHandlers.Instance.EnterTextInGuiTextField(txtSerial, serialNo);
                    SAPHandlers.Instance.ClickButton(btnSerialConfirm);
                    _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
                }

                rowCount = SAPHandlers.Instance.GridGetRowCount(SourceHUContent);
            }

            if(!export)
            {
                SAPHandlers.Instance.ClickButton(F8Repack);
            }      
                                
            log.Info("REPACKING COMPLETED");
            return RandomHU;
        }

        public string RandomSerialNumber()
        {
            Random r = new Random();
            int genRand = r.Next(10000000, 999999999);
            return genRand.ToString();
        }
        public void AddHandlingUnit(string DestinationHUVal)
        {    
          
            SAPHandlers.Instance.EnterTextInGuiTextField(DestinationHU, DestinationHUVal);
            SAPHandlers.Instance.SendKeysByWindow(_session, SAPKeys.Enter);
            _frameWindow = SAPHandlers.Instance.SetToNextWindow(_frameWindow, _session);

            RandomHU = "25" + DateTime.Now.ToString("ddyyHHmm");// retrieve handling unit with NO

            SAPHandlers.Instance.EnterTextInGuiTextField(PackingDialogHU, RandomHU);
            SAPHandlers.Instance.ClickButton(F7Confirm);

            while (btnOk != null)

            {
                SAPHandlers.Instance.ClickButton(btnOk);
                _frameWindow = SAPHandlers.Instance.SetToPreviousWindow(_frameWindow, _session);
                SAPHandlers.Instance.EnterTextInGuiTextField(DestinationHU, DestinationHUVal);
                SAPHandlers.Instance.SendKeysByWindow(_session, SAPKeys.Enter);
                _frameWindow = SAPHandlers.Instance.SetToNextWindow(_frameWindow, _session);
                RandomHU = "25" + DateTime.Now.ToString("ddyyHHmm");

                SAPHandlers.Instance.EnterTextInGuiTextField(PackingDialogHU, RandomHU);
                SAPHandlers.Instance.ClickButton(F7Confirm);
                
            }

            log.Info($"Random Handling Unit : {RandomHU}");
            _frameWindow = SAPHandlers.Instance.SetToPreviousWindow(_frameWindow, _session);
            
        }

        public void ClickOkPackingDialogPopUp()
        {
            SAPHandlers.Instance.ClickButton(OkButtonPackingDialogPopUp);

        }

        public void F6PackWithQuantity()
        {
            string product = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(SourceHUContent, 0, "Product");
            string quantity = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(SourceHUContent, 0, "Quantity");
            //string productDesc = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(SourceHUContent, 0, "Product Short Description");
            SAPHandlers.Instance.ClickButton(F6PackWithQty);

            _frameWindow = SAPHandlers.Instance.SetToNextWindow(_frameWindow, _session);

            
            SAPHandlers.Instance.EnterTextInGuiTextField(Product, product.Trim());
            SAPHandlers.Instance.EnterTextInGuiTextField(Quantity, quantity);
            SAPHandlers.Instance.SendKeysByWindow(_session, SAPKeys.Enter);

            log.Info($"Product : {product} ,Quantity : {quantity}");
            _frameWindow = SAPHandlers.Instance.SetToPreviousWindow(_frameWindow, _session);

        }
        public void VerifyFFDoc(string DocumentNo, string docValue)
        {
           
                _session.CreateSession();
                Thread.Sleep(5000);
                _session = SAPDriver.Instance.GetSession(1);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

                SAPOutboundDelivery sapOutboundDelivery = new SAPOutboundDelivery(_session, _frameWindow);
                sapOutboundDelivery.getDocumentOrderDetails(DocumentNo); // add function cal for PRDO screen

                string FFDoc_status = "";
                SAPHandlers.Instance.SelectTab(MainOutboundDeliveryTab, "status");
                for (int cnt = 0; cnt <= 10; cnt++)
                {
                    Thread.Sleep(30000);
                    SAPHandlers.Instance.ClickButton(getDocDetailsButton);

                    FFDoc_status = SAPHandlers.Instance.GetGridviewTextByRowColumn(StatusGrid, 18, 2);
                    if (FFDoc_status.Equals(docValue))
                    {
                        log.Info($"FF Document status is {docValue}");
                        break;
                    }

                }
                if (!FFDoc_status.Equals("1"))
                {
                    log.Info($"FF Document status is not {docValue}");
                    Assert.Fail($"FF Document status is not {docValue}");
                }

                string id = _session.Id;
                SAPDriver.Instance.CloseSession(id);
                _session = SAPDriver.Instance.GetSession(0);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
                         
        }

        public void F9Print()
        {
            //if (!export)
            //{
                if (F9PrintButton != null)
                    SAPHandlers.Instance.ClickButton(F9PrintButton);
                else
                {
                    log.Info("F9 Print not accessible");
                    Assert.Fail("F9 Print not accessible");
                }


                if (OKButton == null)
                {
                    log.Info("F9 Print not successful");
                    Assert.Fail("F9 Print not successful");
                }
           // }
                      
        }      
       
    }



}
