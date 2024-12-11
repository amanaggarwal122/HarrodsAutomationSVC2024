using TAF_SAP;
using sapfewse;
using NUnit.Framework;
using System.Threading;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPWorkCenterPacking
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiCTextField txtWTNo => _frameWindow.FindById<GuiCTextField>("usr/ctxtPA_LGNUM");
        public GuiCTextField txtWorkCenter => _frameWindow.FindById<GuiCTextField>("usr/ctxtPA_WRKST");
        public GuiCTextField txtStorageBin => _frameWindow.FindById<GuiCTextField>("usr/ctxtSOLGPLA-LOW");
        public GuiCTextField txtHU => _frameWindow.FindById<GuiCTextField>("usr/ctxtSOHUID-LOW");

        public GuiCTextField txtpackMaterial => _frameWindow.FindById<GuiCTextField>("usr/subSUB_SCANNER:/SCWM/SAPLUI_PACKING:0200/tabsTS_SCANNER/tabpHU_CREATE/ssubSS_SCANNER:/SCWM/SAPLUI_PACKING:0202/ctxt/SCWM/S_PACK_VIEW_SCANNER-DEST_PMAT_NO");
        public GuiTextField txtHUStorageBin => _frameWindow.FindById<GuiTextField>("usr/subSUB_SCANNER:/SCWM/SAPLUI_PACKING:0200/tabsTS_SCANNER/tabpHU_CREATE/ssubSS_SCANNER:/SCWM/SAPLUI_PACKING:0202/txt/SCWM/S_PACK_VIEW_SCANNER-DEST_ID");

        public GuiTextField txtNoOfHu => _frameWindow.FindById<GuiTextField>("usr/subSUB_SCANNER:/SCWM/SAPLUI_PACKING:0200/tabsTS_SCANNER/tabpHU_CREATE/ssubSS_SCANNER:/SCWM/SAPLUI_PACKING:0202/txt/SCWM/S_PACK_VIEW_SCANNER-NUMBER_HUS");
        public GuiButton btnExecute => _frameWindow.FindById<GuiButton>("tbar[1]/btn[8]");
        public GuiButton btnCreate => _frameWindow.FindById<GuiButton>("usr/subSUB_SCANNER:/SCWM/SAPLUI_PACKING:0200/tabsTS_SCANNER/tabpHU_CREATE/ssubSS_SCANNER:/SCWM/SAPLUI_PACKING:0202/btnPB_CREATE");
        public GuiButton btnSave => _frameWindow.FindById<GuiButton>("tbar[0]/btn[11]");
        public GuiTree treeHandlingUnit => _frameWindow.FindById<GuiTree>("shellcont/shell/shellcont[1]/shell[1]");
        public GuiTab tbHUDetails2 => _frameWindow.FindById<GuiTab>("usr/subSUB_HUDETAIL:/SCWM/SAPLUI_PACKING:0300/tabsTS_HU/tabpHUDETAIL2");
        public GuiTextField txtDetails2_HU => _frameWindow.FindById<GuiTextField>("usr/subSUB_HUDETAIL:/SCWM/SAPLUI_PACKING:0300/tabsTS_HU/tabpHUDETAIL2/ssubSUB_DETAIL:/SCWM/SAPLUI_PACKING:0335/txt/SCWM/S_PACK_VIEW_HUHDR-HUIDENT");
        public SAPWorkCenterPacking(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }

        public void onWorkCenterPackingScreen()
        {
            if (txtWTNo == null)
                _session.GotoTransaction("/N/SCWM/PACK");
        }

        public void SetWorkCenter()
        {
            onWorkCenterPackingScreen();
            SAPHandlers.Instance.EnterTextInGuiCTextField(txtWTNo, "0044");
            SAPHandlers.Instance.EnterTextInGuiCTextField(txtWorkCenter, "STAG");
            SAPHandlers.Instance.EnterTextInGuiCTextField(txtStorageBin, "GR-ZONE");
            SAPHandlers.Instance.EnterTextInGuiCTextField(txtHU, "sda");
            SAPHandlers.Instance.ClickButton(btnExecute);
        }

        public void CreateHU()
        {
            SAPHandlers.Instance.EnterTextInGuiCTextField(txtpackMaterial, "P026");
            SAPHandlers.Instance.EnterTextInGuiTextField(txtHUStorageBin, "GR-ZONE ");
            SAPHandlers.Instance.EnterTextInGuiTextField(txtNoOfHu, "1");
            SAPHandlers.Instance.ClickButton(btnCreate);

            Thread.Sleep(4000);
            SAPHandlers.Instance.ClickButton(btnSave);
        }

        public string  verifyHU()
        {
            SAPHandlers.Instance.ExpandTreeNodeByCode(treeHandlingUnit, "          1");
            SAPHandlers.Instance.ExpandTreeNodeByCode(treeHandlingUnit, "          2");
            SAPHandlers.Instance.SelectTreeNodeByCode(treeHandlingUnit, "          3");
            Thread.Sleep(7000);
            SAPHandlers.Instance.SelectTabItem(tbHUDetails2);

            string details2HU = SAPHandlers.Instance.GetTextFromGuiTextField(txtDetails2_HU);

            return details2HU;
        }
    }
}
