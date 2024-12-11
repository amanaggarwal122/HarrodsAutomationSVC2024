using sapfewse;
using TAF_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class SAPPickingProcess
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiButton OutboundProcessButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU2");
        public GuiButton PickHUPickingButton => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU3");
        public GuiButton PickByWO => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU3");
        public GuiTextField WareHouseNo => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0238/txt/SCWM/S_RF_SELECTION-WHO");

        public GuiTextField txtMsg1 => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0144/txt/SCWM/S_RF_SCRELM-MSGT1");
        public GuiButton ProgButton => _frameWindow.FindById<GuiButton>("usr/btn/SCWM/S_RF_SCRELM-PB1");

        public GuiLabel lblPickingSummary => _frameWindow.FindById<GuiLabel>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0275/lbl%#AUTOTEXT002");
        //Elements identified for picking process

        ///// <PickingWindow0>
        public GuiLabel lblSbi => _frameWindow.FindById<GuiLabel>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0302/lbl/SCWM/S_RF_ORDIM_CONFIRM-VLPLA");
        public GuiTextField SourceBin => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0302/txt/SCWM/S_RF_ORDIM_CONFIRM-VLPLA");
        public GuiTextField SourceBin_Verify => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0302/txt/SCWM/S_RF_ORDIM_CONFIRM-VLPLA_VERIF");
        public GuiTextField Product => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0302/txt/SCWM/S_RF_ORDIM_CONFIRM-MATNR");
        public GuiTextField Product_Verify => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0302/txt/SCWM/S_RF_ORDIM_CONFIRM-MATID_VERIF");
        public GuiTextField RQty => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0302/txt/SCWM/S_RF_ORDIM_CONFIRM-COMBQTY_CHR");
        public GuiTextField AQty => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0302/txt/SCWM/S_RF_ORDIM_CONFIRM-COMBQTY_VERIF");

        ///// </PickingWindow0>


        ///// <PickingWindow1>

        public GuiLabel lblGoto => _frameWindow.FindById<GuiLabel>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/lbl%#AUTOTEXT002");
        public GuiTextField Sbin => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/txt/SCWM/S_RF_ORDIM_CONFIRM-VLPLA");
        public GuiTextField Sbin_Verify => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/txt/SCWM/S_RF_ORDIM_CONFIRM-VLPLA_VERIF");
        public GuiTextField SourceHU => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/txt/SCWM/S_RF_ORDIM_CONFIRM-VLENR");
        public GuiTextField SourceHU_Verify => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/txt/SCWM/S_RF_ORDIM_CONFIRM-VLENR_VERIF");
        public GuiTextField Article => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/txt/SCWM/S_RF_ORDIM_CONFIRM-MATNR");
        public GuiTextField Article_Verify => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/txt/SCWM/S_RF_ORDIM_CONFIRM-MATID_VERIF");
        public GuiTextField ReqQty => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/txtZSSI_S_RF_PICK_DATA-REQD_QTY");
        public GuiTextField ActualQty => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0274/txt/SCWM/S_RF_ORDIM_CONFIRM-NISTA_VERIF");

        ///// </PickingWindow1>
        public GuiTextField dropOff => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0231/txt/SCWM/S_RF_ORDIM_CONFIRM-NLPLA");
        public GuiTextField dropOff_Verify => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0231/txt/SCWM/S_RF_ORDIM_CONFIRM-NLPLA_VERIF");


        /// <summary>
        /// Unloading
        /// 
        public GuiButton btnLoadUnload => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU3");
        public GuiButton btnInbound => _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU1");

        public GuiButton btnUnloadByLicense=> _frameWindow.FindById<GuiButton>("usr/subX:SAPLZ_SSI_RFUI_DP_CK3:0143/btn/SCWM/S_RF_SCRELM-MENU5");

        public GuiTextField txtLPgrpDelvyNo => _frameWindow.FindById<GuiTextField>("usr/subX:SAPLZSSI_RF_RGR_TMPL:0014/txtZSSI_S_RF_RGR-LPIDENT");
        /// </summary>

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       // private log4net.ILog log; , log4net.ILog logger = null
        public SAPPickingProcess(GuiSession session, GuiFrameWindow frameWindow )
        {
            _frameWindow = frameWindow;
            _session = session;

            //if(logger!=null)
            //    log = logger;
        }

        public void PickTheWO(string WONumber)
        {
            log.Info("PICKING STARTED");

            while (txtMsg1 != null)
            {
                SAPHandlers.Instance.ClickButton(ProgButton);
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            }

            if (OutboundProcessButton != null)
            {
                SAPHandlers.Instance.ClickButton(OutboundProcessButton);
                SAPHandlers.Instance.ClickButton(PickHUPickingButton);
                SAPHandlers.Instance.ClickButton(PickByWO);
                
                if (string.IsNullOrEmpty(WONumber))
                {
                    log.Info("Warehouse number not provided");
                    Assert.Fail("Warehouse number not provided");
                }
                    
                SAPHandlers.Instance.EnterTextInGuiTextField(WareHouseNo, WONumber);
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);

                if(lblPickingSummary!=null)
                    SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            }
          
            while (lblGoto != null || lblSbi != null)
            {
                string SbinValue = string.Empty;
                string SourceHUValue = string.Empty;
                string ArticleValue = string.Empty;
                string ReqQtyValue = string.Empty;

                if (lblGoto != null)
                {
                    SbinValue = SAPHandlers.Instance.GetTextFromGuiTextField(Sbin);                    
                    ArticleValue = SAPHandlers.Instance.GetTextFromGuiTextField(Article);
                    ReqQtyValue = SAPHandlers.Instance.GetTextFromGuiTextField(ReqQty);

                    SAPHandlers.Instance.EnterTextInGuiTextField(Sbin_Verify, SbinValue);

                    if(SourceHU != null)
                    {
                        SourceHUValue = SAPHandlers.Instance.GetTextFromGuiTextField(SourceHU);
                        if(SourceHU_Verify!=null)
                            SAPHandlers.Instance.EnterTextInGuiTextField(SourceHU_Verify, SourceHUValue);
                    }
                    
                    SAPHandlers.Instance.EnterTextInGuiTextField(Article_Verify, ArticleValue);
                    SAPHandlers.Instance.EnterTextInGuiTextField(ActualQty, ReqQtyValue);

                    SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                   
                }
                if (lblSbi != null)
                {
                    SbinValue = SAPHandlers.Instance.GetTextFromGuiTextField(SourceBin);
                    ArticleValue = SAPHandlers.Instance.GetTextFromGuiTextField(Product);
                    ReqQtyValue = SAPHandlers.Instance.GetTextFromGuiTextField(RQty);

                    SAPHandlers.Instance.EnterTextInGuiTextField(SourceBin_Verify, SbinValue);
                    SAPHandlers.Instance.EnterTextInGuiTextField(Product_Verify, ArticleValue);
                    SAPHandlers.Instance.EnterTextInGuiTextField(AQty, ReqQtyValue);

                    SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                    SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                }
            }

            if (dropOff_Verify != null)
            {
                string dropOffValue = SAPHandlers.Instance.GetTextFromGuiTextField(dropOff);
                SAPHandlers.Instance.EnterTextInGuiTextField(dropOff_Verify, dropOffValue);

                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            }

            log.Info("PICKING COMPLETED");
        }

        public void UnloadHU(string grpDelivryNo)
        {
            int attempts = 1;
            while (btnLoadUnload == null && attempts <= 2)
            {
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
                attempts++;
            }
            if (btnLoadUnload != null)
            {
                SAPHandlers.Instance.ClickButton(btnLoadUnload);
                SAPHandlers.Instance.ClickButton(btnInbound);
                SAPHandlers.Instance.ClickButton(btnUnloadByLicense);

                Thread.Sleep(1000);
                SAPHandlers.Instance.EnterTextInGuiTextField(txtLPgrpDelvyNo, grpDelivryNo);
                SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
            }
        }
    }
}
