using sapfewse;
using TAF_SAP;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPMezzRepacking
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiCTextField QueueNumber => _frameWindow.FindById<GuiCTextField>("usr/sub:SAPLSPO4:0300/ctxtSVALD-VALUE[1,21]");
        public GuiButton ChangeQueueExecuteButton => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");

        public GuiButton OutBondProcessButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU2");

        public GuiButton ArrowButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-PGDN");

        public GuiButton MezzRepackButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU1");

        public GuiTextField Bin => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZRF_REPACKING:0500/txt/SCWM/S_RF_INVENTORY_BIN-LGPLA");

        public GuiTextField HU => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZRF_REPACKING:0500/txt/SCWM/S_HUHDR_INT-HUIDENT");
        public GuiTextField DestHU => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZRF_REPACKING:0504/txt/SCWM/S_RF_INVENTORY_HU-HUIDENT");

        public GuiButton F4Ma => _frameWindow.FindById<GuiButton>("usr/btn/SCWM/S_RF_SCRELM-PB2");
        public GuiTextField DestBin => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZRF_REPACKING:0503/txt/SCWM/S_RF_ORDIM_CONFIRM-NLPLA");
        public GuiTextField InputDestBin => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZRF_REPACKING:0503/txt/SCWM/S_RF_ORDIM_CONFIRM-NLPLA_VERIF");
        public GuiButton MoveHU => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU4");

        public GuiTextField NoQueueSpecifiedMessage => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0144/txt/SCWM/S_RF_SCRELM-MSGT1");

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       // private  log4net.ILog log;,log4net.ILog logger = null
        public SAPMezzRepacking(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;

            //if (logger != null)
            //    log = logger;
        }
        

        public void MezzRepack(String HuNumner)
        {
            Thread.Sleep(4000);

            log.Info("MEZZREPACKING STARTED");

            while (OutBondProcessButton==null)
            {
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F7);
            }
            SAPHandlers.Instance.ClickButton(OutBondProcessButton);
            SAPHandlers.Instance.ClickButton(ArrowButton);
            SAPHandlers.Instance.ClickButton(MezzRepackButton);
            SAPHandlers.Instance.EnterTextInGuiTextField(Bin, "DROP_OFF");
            SAPHandlers.Instance.EnterTextInGuiTextField(HU, HuNumner);

            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            SAPHandlers.Instance.EnterTextInGuiTextField(DestHU, HuNumner);
            SAPHandlers.Instance.ClickButton(F4Ma);
            
            Thread.Sleep(3000);
            if (DestBin != null)
            {
                String txt = SAPHandlers.Instance.GetTextFromGuiTextField(DestBin);
                SAPHandlers.Instance.EnterTextInGuiTextField(InputDestBin, txt);
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            }

            else
            {
                log.Info("Hu is not yet processed");
                Assert.Fail("Hu is not yet processed");
            }

            log.Info("MEZZREPACKING COMPLETED");

        }


    }
}
