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
    public class SAPCreateHUWT
    {

        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        private GuiComboBox cmbDataType => _frameWindow.FindById<GuiComboBox>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/cmb/SCWM/S_UI_ADHOC-V_CRITERION");
        private GuiCTextField ctxtHU => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_ADMA:2005/ctxt/SCWM/S_ASPQ_HU-HUIDENT");
        private GuiButton btnExec => _frameWindow.FindById<GuiButton>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_ADMA:2005/btnCMD_GO");

        public GuiToolbarControl tbFormView => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");
        private GuiCTextField ctxtWhouseProcType => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2213/ctxt/SCWM/S_ASP_HU_AD-PROCTY");
        private GuiButton btnOk=> _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");
        public GuiCTextField ctxtDestinationStorageBinCode => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2213/ctxt/SCWM/S_ASP_HU_AD-NLTYP");
        public GuiCTextField ctxtDestinationStorageBinNo => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2213/ctxt/SCWM/S_ASP_HU_AD-NLBER");
        public GuiCTextField ctxtDestinationStorageBinName => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2213/ctxt/SCWM/S_ASP_HU_AD-NLPLA");

        public GuiToolbarControl tbCreate => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");
        public SAPCreateHUWT(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }

        public void onCreateProductWTScreen()
        {
            if (ctxtHU == null)
                _session.GotoTransaction("/N/SCWM/ADHU");
        }

        public void CreateHUWT(string HU)
        {
            onCreateProductWTScreen();
            SAPHandlers.Instance.SelectComboboxItemByKey(cmbDataType, "HUIDENT");
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtHU, HU);
            SAPHandlers.Instance.ClickButton(btnExec);
        }
        public void SwitchToFormView()
        {
            SAPHandlers.Instance.ClickToolbar(tbFormView, "OK_OIP_TOGGLE");
        }

        public void EnterNewHUDetails()
        {
            SwitchToFormView();
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtWhouseProcType, "9998");
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            SAPHandlers.Instance.ClickButton(btnOk);
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDestinationStorageBinCode, "1040");
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDestinationStorageBinNo, "0001");
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDestinationStorageBinName, "WAT01B01");

            SAPHandlers.Instance.ClickToolbar(tbCreate, "OK_OIP_CREATE_POST_HU_TO");

            Thread.Sleep(3000);
            string statusMsg = SAPHandlers.Instance.GetStatusBarMessage(_session);

            if(!statusMsg.Contains("Warehouse order") && !statusMsg.Contains("created"))
            {
                Assert.Fail("Failed to create Warehous order");
            }

        }


    }
}
