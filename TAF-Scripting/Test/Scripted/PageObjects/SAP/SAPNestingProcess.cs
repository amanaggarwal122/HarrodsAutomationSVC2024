using NUnit.Framework;
using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAF_SAP;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
   public class SAPNestingProcess
   {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;
        public GuiButton OutBondProcessButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU2");

        public GuiButton ArrowButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-PGDN");

        public GuiTextField ScanHU => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0279/txt/SCWM/S_RF_SELECTION-RFHU");

        public GuiTextField EScanHU => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0237/txt/SCWM/S_RF_SELECTION-RFHU");

        
        public GuiButton HUProcessYesButton => _frameWindow.FindById<GuiButton>("usr/btn/SCWM/S_RF_SCRELM-PB1");
        public GuiTextField HUBinMessage => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0144/txt/SCWM/S_RF_SCRELM-MSGT1");
        public GuiButton MoveHU => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU4");
        public GuiTextField ConfirmQueueMove => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0278/txt/SCWM/S_RF_ORDIM_CONFIRM-NLPLA_O");

        public GuiTextField ConfirmQueueMoveFrom => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0278/txt/SCWM/S_RF_ORDIM_CONFIRM-NLPLA");

        public GuiTextField Destination => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0278/txtZSSI_S_RF_MOVE_HU_DATA-BIN_TEXT");
        public GuiButton HUNestingButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU6");
        public GuiButton HDMarshallingButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU1");
        public GuiTextField WorkCenter => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0241/txt/SCWM/S_RF_PIPO_WORK-WORKSTATION");
        public GuiTextField SourceStorageBin => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0301/txt/SCWM/S_RF_PIPO-VLPLA");
        public GuiTextField HuCount => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0301/txtZSSI_S_RF_MOVE_HU_DATA-ANZLE");
        public GuiButton F3CP => _frameWindow.FindById<GuiButton>("usr/btn/SCWM/S_RF_SCRELM-PB3");
        public GuiButton Enter => _frameWindow.FindById<GuiButton>("usr/btn/SCWM/S_RF_SCRELM-PB1");
        public GuiButton ExecuteOnExpressInfo => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");
        public GuiTextField NoQueueSpecifiedMessage => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0144/txt/SCWM/S_RF_SCRELM-MSGT1");
        public GuiTextField StorageBinNotAssigned => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0144/txt/SCWM/S_RF_SCRELM-MSGT1");
        public GuiButton StorageBinNotAsignedEnter => _frameWindow.FindById<GuiButton>("usr/btn/SCWM/S_RF_SCRELM-PB1");

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SAPNestingProcess(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
           
        }

        public void NestingMoveToHU(String HuNumber)
        {
            clickOnOutbondProcess();
            if (NoQueueSpecifiedMessage != null)
            {
                string ErrorMessage = SAPHandlers.Instance.GetTextFromGuiTextField(NoQueueSpecifiedMessage);

                if(Enter !=null)
                {
                    SAPHandlers.Instance.ClickButton(Enter);
                    SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);
                }

                _session.CreateSession();
                Thread.Sleep(5000);
                _session = SAPDriver.Instance.GetSession(1);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

                SAPMonitorScreenCommon sapMonitorScreenCommon = new SAPMonitorScreenCommon(_session, _frameWindow);
                sapMonitorScreenCommon.ChangeQueue("CK3025");
              

                string id = _session.Id;
                SAPDriver.Instance.CloseSession(id);
                _session = SAPDriver.Instance.GetSession(0);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

                clickOnOutbondProcess();

            }
            Thread.Sleep(1000);
            SAPHandlers.Instance.EnterTextInGuiTextField(ScanHU, HuNumber);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            if (HUBinMessage != null)
            {
                SAPHandlers.Instance.ClickButton(HUProcessYesButton);
            }
        }

        public void MoveToHU(String HuNumber)
        {
            clickOnOutbondProcess();
            if (NoQueueSpecifiedMessage != null)
            {
                string ErrorMessage = SAPHandlers.Instance.GetTextFromGuiTextField(NoQueueSpecifiedMessage);
                //SAPMonitorScreenCommon sapMonitorScreenCommon = new SAPMonitorScreenCommon(_session, _frameWindow);
                //sapMonitorScreenCommon.ChangeQueue("CK3001");
                //SAPDispatchProcess sapDispatchProcess = new SAPDispatchProcess(_session, _frameWindow);
                //sapDispatchProcess.EnterResourceDetails("0044", "CK3001", "CK3");
                //clickOnOutbondProcess();
                if (Enter != null)
                {
                    SAPHandlers.Instance.ClickButton(Enter);
                    SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);
                }

                _session.CreateSession();
                Thread.Sleep(5000);
                _session = SAPDriver.Instance.GetSession(1);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

                SAPMonitorScreenCommon sapMonitorScreenCommon = new SAPMonitorScreenCommon(_session, _frameWindow);
                sapMonitorScreenCommon.ChangeQueue("CK3001");

                string id = _session.Id;
                SAPDriver.Instance.CloseSession(id);
                _session = SAPDriver.Instance.GetSession(0);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

                clickOnOutbondProcess();
            }
            Thread.Sleep(3000);
            SAPHandlers.Instance.EnterTextInGuiTextField(ScanHU, HuNumber);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            if (HUBinMessage != null)
            {
                SAPHandlers.Instance.ClickButton(HUProcessYesButton);
            }


            if(ConfirmQueueMoveFrom!=null)
            {
                string moveTO = SAPHandlers.Instance.GetTextFromGuiTextField(ConfirmQueueMoveFrom);
                SAPHandlers.Instance.EnterTextInGuiTextField(ConfirmQueueMove, moveTO);
            }
           
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
        }
        public void Nesting(String HuNumber)
        {
            log.Info("NESTING STARTED");
        
            NestingMoveToHU(HuNumber);

            Thread.Sleep(3000);
            if(Destination == null)
            {
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                if (HUBinMessage != null)
                {
                    SAPHandlers.Instance.ClickButton(HUProcessYesButton);
                }
            }

            if (Destination == null && OutBondProcessButton != null)
            {
                Assert.Fail("MoveHU not completed");
            }

            string destination = SAPHandlers.Instance.GetTextFromGuiTextField(Destination);
            log.Info($"Destination - {destination}");

            if (destination == "EXPORT")
            {
                SAPHandlers.Instance.EnterTextInGuiTextField(ConfirmQueueMove, "out_exp_stag"); 
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);

                //Creating a  new session to perform repacking for export products
                _session.CreateSession();
                Thread.Sleep(5000);

                _session = SAPDriver.Instance.GetSession(1);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

                SAPRepacking sapRepacking = new SAPRepacking(_session, _frameWindow);
                log.Info("REPACKING STARTED FOR EXPORT ORDER");

                string DestHUVal =  TAFHooks.ApplicationCache.DestinationHUVal;
                sapRepacking.Repack(HuNumber, DestHUVal, true);
                log.Info("REPACKING COMPLETED FOR EXPORT ORDER");

                string id = _session.Id;

                SAPDriver.Instance.CloseSession(id);

                _session = SAPDriver.Instance.GetSession(0);
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
               
            }                
            else
            {
                SAPHandlers.Instance.EnterTextInGuiTextField(ConfirmQueueMove, "OUT-NEST-DOM");
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            }

            //after repacking repeating steps to moveHU
            if (destination == "EXPORT")
            {
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);

                NestingMoveToHU(HuNumber);

                SAPHandlers.Instance.EnterTextInGuiTextField(ConfirmQueueMove, "OUT-NEST-EXP");
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            }

            ////////
           
            if (StorageBinNotAssigned != null)
            {
                SAPHandlers.Instance.ClickButton(StorageBinNotAsignedEnter);
            }

            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);
            if (OutBondProcessButton == null)
            {
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);
            }


            SAPHandlers.Instance.ClickButton(OutBondProcessButton);
            SAPHandlers.Instance.ClickButton(HUNestingButton);
            SAPHandlers.Instance.ClickButton(ArrowButton);
            SAPHandlers.Instance.ClickButton(HDMarshallingButton);
            SAPHandlers.Instance.EnterTextInGuiTextField(WorkCenter, "NEST");
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);

            if(destination== "EXPORT")
                SAPHandlers.Instance.EnterTextInGuiTextField(SourceStorageBin, "OUT-NEST-EXP");
            else
                SAPHandlers.Instance.EnterTextInGuiTextField(SourceStorageBin, "OUT-NEST-DOM");

            String NoOfHus = SAPHandlers.Instance.GetTextFromGuiTextField(HuCount);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            String NoOfHuAfterEnter = SAPHandlers.Instance.GetTextFromGuiTextField(HuCount);
            if (!NoOfHus.Equals(NoOfHuAfterEnter))
                SAPHandlers.Instance.ClickButton(F3CP);
            else
                Assert.Fail("Handling unit not scanned");

            Thread.Sleep(6000);

            int wndCountBeforeClick =  _session.Children.Count;
            SAPHandlers.Instance.ClickButton(Enter);
            int wndCountAfterClick = _session.Children.Count;

            if (destination != "EXPORT" && wndCountAfterClick > wndCountBeforeClick)
            {

                _frameWindow = SAPHandlers.Instance.SetToNextWindow(_frameWindow, _session);
                SAPHandlers.Instance.ClickButton(ExecuteOnExpressInfo);
                _frameWindow = SAPHandlers.Instance.SetToPreviousWindow(_frameWindow, _session);
            }           

            log.Info("NESTING COMPLETED");
        }

        public void clickOnOutbondProcess()
        {
            if (OutBondProcessButton != null)
            {
                SAPHandlers.Instance.ClickButton(OutBondProcessButton);
                SAPHandlers.Instance.ClickButton(MoveHU);
            }

        }
    }
}
