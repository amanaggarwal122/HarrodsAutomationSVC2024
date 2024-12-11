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
using System.Threading;
using TechTalk.SpecFlow;
using BoDi;
using TAF_Scripting.Test.Common;
using System.Globalization;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class SAPDispatchProcess
    {

        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        private SAPOutboundDelivery sapOutboundDelivery = null;
        private SAPMonitorScreenCommon sapMonScreenCommon = null;
        private SAPOrderVerificationPage saporderpage = null;

        public GuiLabel lblResource => _frameWindow.FindById<GuiLabel>("wnd[0]/usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0074/lbl/SCWM/S_RF_RS_CH-RSRC");
        public GuiTextField WhseNo => _frameWindow.FindById<GuiTextField>("usr/subX:/SCWM/SAPLRSRC_DYNPRO:0001/txt/SCWM/S_RSRC-LGNUM");
        public GuiTextField ResourceRFUI => _frameWindow.FindById<GuiTextField>("usr/subX:/SCWM/SAPLRSRC_DYNPRO:0001/txt/SCWM/S_RSRC-RSRC");
        public GuiTextField DefPresDvc => _frameWindow.FindById<GuiTextField>("usr/subX:/SCWM/SAPLRSRC_DYNPRO:0001/txt/SCWM/S_RSRC-PRDVC");

        public GuiTextField ResourceUnavailableErrorMessage => _frameWindow.FindById<GuiTextField>("usr/txt/SCWM/S_RF_SCRELM-MSGTX");


        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      
        public SAPDispatchProcess(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
          
        }


        public void EnterResourceDetails(String whseNo, String resourceNo, String defPresDvc)
        {
            _session.GotoTransaction("/N/SCWM/RFUI");
            SAPHandlers.Instance.EnterTextInGuiTextField(WhseNo, whseNo);
            SAPHandlers.Instance.EnterTextInGuiTextField(ResourceRFUI, resourceNo);
            SAPHandlers.Instance.EnterTextInGuiTextField(DefPresDvc, defPresDvc);
            SAPHandlers.Instance.SendKeysByWindow(_session, 0, 0);
            if (ResourceUnavailableErrorMessage != null)
            {
                String ResourceID = SAPHandlers.Instance.GetTextFromGuiTextField(ResourceUnavailableErrorMessage);
                if (SAPHandlers.Instance.VerifyTextContains(ResourceID, "E: User") && SAPHandlers.Instance.VerifyTextContains(ResourceID, "is logged on to this re"))
                {
                    SAPMonitorScreenCommon sapMonScreenCommon = new SAPMonitorScreenCommon(_session, _frameWindow);
                    sapMonScreenCommon.ReleaseResource(resourceNo);
                    EnterResourceDetails(whseNo, resourceNo, defPresDvc);
                }
            }


            if(lblResource!=null)
            {
                string val = SAPHandlers.Instance.GetLabelText(lblResource);
                if(val== "Resource")
                {
                    SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                    SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                }
            }
        }

        public void DC44PickingProcess(string WhrsNo)
        {
            EnterResourceDetails("0044", "CK3001", "CK3");

            SAPPickingProcess sapPickingProcess = new SAPPickingProcess(_session, _frameWindow);
            sapPickingProcess.PickTheWO(WhrsNo);

        }

        public void DC44MezzRepacking(string SourceHU)
        {
            EnterResourceDetails("0044", "CK3001", "CK3");
            SAPMezzRepacking sapMezzRepacking = new SAPMezzRepacking(_session, _frameWindow);
            sapMezzRepacking.MezzRepack(SourceHU);
        }


        public void DC44NestingProcess(string HUNumber)
        {
            try
            {
                EnterResourceDetails("0044", "CK3025", "CK3");
                SAPNestingProcess sapNestingProcess = new SAPNestingProcess(_session, _frameWindow);
                sapNestingProcess.Nesting(HUNumber);
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                if(msg== "MoveHU not completed")
                {
                    EnterResourceDetails("0044", "CK3025", "CK3");
                    SAPNestingProcess sapNestingProcess = new SAPNestingProcess(_session, _frameWindow);
                    sapNestingProcess.Nesting(HUNumber);
                }
            }
            
                       
        }

        public void KBMoveHU(string HUNumber)
        {
            EnterResourceDetails("0044", "CK3001", "CK3");
            SAPNestingProcess sapNestingProcess = new SAPNestingProcess(_session, _frameWindow);
            sapNestingProcess.MoveToHU(HUNumber);

        }

        public string RetrieveDocumentNo(string ERPDocNo)
        {
            string DocumentNo = string.Empty;
            sapOutboundDelivery = new SAPOutboundDelivery(_session, _frameWindow);
            if (!String.IsNullOrEmpty(ERPDocNo))
            {
                DocumentNo = sapOutboundDelivery.getDocumentOrderDetails(ERPDocNo);
                log.Info($"Document Number : {DocumentNo}");
            }
            else
            {
                log.Info($"ERP Document Number is invalid");
                Assert.Fail("ERP Document Number is invalid");
            }

            return DocumentNo;
        }

        public void CheckPackingStatus(string ERPDocNo)
        {
            string status=  sapOutboundDelivery.CheckPackingStatus(ERPDocNo);

            if(status!="Completed")
                Assert.Fail("Packing status not completed");
        }
        public string RetrieveWarehoustask(string DocumentNo)
        {
            
            string WarehouseOrderNo = string.Empty;            

            sapMonScreenCommon = new SAPMonitorScreenCommon(_session, _frameWindow);
            if (!String.IsNullOrEmpty(DocumentNo))
            {
                WarehouseOrderNo = sapMonScreenCommon.GetWhseOrdeNumber(DocumentNo);
                log.Info($"Warehouse Order Number : {WarehouseOrderNo}");
            }
            else
            {
                log.Info("Document Number is invalid");
                Assert.Fail("Document Number is invalid");
            }

            // return new Tuple<string, string>(DocumentNo, WarehouseOrderNo);
            return WarehouseOrderNo;
        }

        public string ConfirmWarehouseTask()
        {
            sapOutboundDelivery.ConfirmWTinWO();
            string HU;
            HU  = sapOutboundDelivery.CreateWO();
            log.Info($"Source Handling Unit : {HU}");
            return HU;
        }

        public void CompleteGCOrderPicking()
        {
            sapOutboundDelivery.CompleteGCPicking();
        }

        public string RetrieveHU(string DocumentNo)
        {
          //  Thread.Sleep(3000);
            string SourceHU = string.Empty;
            if (!String.IsNullOrEmpty(DocumentNo))
            {
                SourceHU = sapMonScreenCommon.GetSourceHUNumber(DocumentNo);
                log.Info($"Source Handling Unit : {SourceHU}");
            }

            return SourceHU;
        }
        public void DC44Dipatch(string ERPDocNo, ScenarioContext _scenarioContext, IObjectContainer _objectContainer, FeatureContext _featureContext, string OrderNumber)
        {
            
         

            //string DocumentNo = string.Empty;
            //string WarehouseOrderNo = string.Empty;
            //string SourceHU = string.Empty;
            //string RandomHu = string.Empty;
            string Message = string.Empty;

          
            //sapOutboundDelivery = new SAPOutboundDelivery(_session, _frameWindow);
            //if (!String.IsNullOrEmpty(ERPDocNo))
            //{
            //    DocumentNo = sapOutboundDelivery.getDocumentOrderDetails(ERPDocNo);
            //    log.Info($"Document Number : {DocumentNo}");
            //}
            //else
            //{
            //    log.Info($"ERP Document Number is invalid");
            //    Assert.Fail("ERP Document Number is invalid");
            //}

            //sapMonScreenCommon = new SAPMonitorScreenCommon(_session, _frameWindow);
            //if (!String.IsNullOrEmpty(DocumentNo))
            //{
            //    WarehouseOrderNo = sapMonScreenCommon.GetWhseOrdeNumber(DocumentNo);
            //    log.Info($"Warehouse Order Number : {WarehouseOrderNo}");
            //}
            //else
            //{
            //    log.Info("Document Number is invalid");
            //    Assert.Fail("Document Number is invalid");
            //}


            //if (!String.IsNullOrEmpty(WarehouseOrderNo))
            //{
            //    TAFHooks.ApplicationCache.SAPStatus = "PICKING STARTED";


            //    DC44PickingProcess(WarehouseOrderNo);

            //    TAFHooks.ApplicationCache.SAPStatus = "PICKING COMPLETED";

            //}
            //else
            //    Assert.Fail("Warehouse Number is invalid");

            //if (!String.IsNullOrEmpty(DocumentNo))
            //{
            //    SourceHU = sapMonScreenCommon.GetSourceHUNumber(DocumentNo);
            //    log.Info($"Source Handling Unit : {SourceHU}");
            //}
            //if (!String.IsNullOrEmpty(SourceHU))
            //{
            //    //TAFHooks.ApplicationCache.SAPStatus = "MEZZREPACKING STARTED";


            //    //DC44MezzRepacking(SourceHU);
            //    //TAFHooks.ApplicationCache.SAPStatus = "MEZZREPACKING COMPLETED";

            //    TAFHooks.ApplicationCache.SAPStatus = "REPACKING STARTED";

            //    SAPRepacking sapRepacking = new SAPRepacking(_session, _frameWindow);

            //    RandomHu = sapRepacking.Repack(SourceHU, ERPDocNo);

            //    TAFHooks obj = new TAFHooks(_objectContainer, _scenarioContext, _featureContext);
            //    obj.AttachDesktopScreenshotToReport("F9Print" + OrderNumber);
            //    sapRepacking.ClickOkPackingDialogPopUp();

            //    TAFHooks.ApplicationCache.SAPStatus = "REPACKING COMPLETED";

            //}
            //else
            //    Assert.Fail("SourceHU Number is invalid");

            //if (!String.IsNullOrEmpty(RandomHu))
            //{
            //    TAFHooks.ApplicationCache.SAPStatus = "NESTING STARTED";

            //   // SetNewLog4NetPath(OrderNumber);

            //    DC44NestingProcess(RandomHu);
            //    sapMonScreenCommon = new SAPMonitorScreenCommon(_session, _frameWindow);
            //    sapMonScreenCommon.ConfirmWTinBgrd(DocumentNo);
                
            //    TAFHooks.ApplicationCache.SAPStatus = "NESTING COMPLETED";
               
            //}
            //else
            //    Assert.Fail("Background warehouse task is not confirmed");

            //sapOutboundDelivery = new SAPOutboundDelivery(_session, _frameWindow);
            //Message = sapOutboundDelivery.clickOnGoodsIssue(ERPDocNo);

            //if (Message == "")
            //{
            //    log.Info("Goods issue is failed");
            //    Assert.Fail("Goods issue is failed");
            //}
            //else 
            //    log.Info(Message);

            //if(Message.Contains("HD Customer Delivery") && Message.Contains("changed"))
            //    log.Info("Goods issued");           
               

        }


    }


   
}