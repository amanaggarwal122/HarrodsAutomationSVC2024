using TAF_SAP;
using sapfewse;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class SAPInboundDelivery
    {
        static GuiFrameWindow _frameWindow;
        static GuiSession _session;


        public GuiComboBox OutboundDeliveryType => _frameWindow.FindById<GuiComboBox>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/cmb/SCWM/S_UI_DLV-V_CRITERION");
        public GuiTextField ERPDocNo => _frameWindow.FindById<GuiTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_DLV_PRD:2003/txt/SCWM/S_SP_Q_HEAD-REFDOCNO_ERP_I");
        public GuiButton getDocDetailsButton => _frameWindow.FindById<GuiButton>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_DLV_PRD:2003/btnCMD_GO");
        public GuiMenu packMenu => _frameWindow.FindById<GuiMenu>("mbar/menu[0]/menu[2]/menu[2]");
        public GuiMenu WarehouseTaskMenu => _frameWindow.FindById<GuiMenu>("mbar/menu[0]/menu[2]/menu[0]");
        public GuiTab HUTab => _frameWindow.FindById<GuiTab>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_TODLV:1000/tabsGV_TAB_OIP/tabpOK_TAB_OIP_HU");
        public GuiTabStrip WTTab => _frameWindow.FindById<GuiTabStrip>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_TODLV:1000/tabsGV_TAB_OIP");
        public GuiCTextField Packmaterial => _frameWindow.FindById<GuiCTextField>("usr/subSUB_SCANNER:/SCWM/SAPLUI_PACKING:0200/tabsTS_SCANNER/tabpHU_CREATE/ssubSS_SCANNER:/SCWM/SAPLUI_PACKING:0202/ctxt/SCWM/S_PACK_VIEW_SCANNER-DEST_PMAT_NO");

        public GuiButton PB_Create => _frameWindow.FindById<GuiButton>("usr/subSUB_SCANNER:/SCWM/SAPLUI_PACKING:0200/tabsTS_SCANNER/tabpHU_CREATE/ssubSS_SCANNER:/SCWM/SAPLUI_PACKING:0202/btnPB_CREATE");

        public GuiCTextField productTxt => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_ADMA:2001/ctxt/SCWM/S_ASPQ_MAT-MATNR");
        public GuiButton executeBtn => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");

        public GuiToolbarControl tbGoodsReceipt => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_DLV_PRD:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");

        public GuiGridView DeliveryItemDetails => _frameWindow.FindById<GuiGridView>("usr/subSUB_COMPLETE_ODP1:/SCWM/SAPLUI_DLV_PRD:3000/tabsTABSTRIP_ODP1/tabpOK_ODP1_TAB1/ssubSUB_ODP1_TAB1:/SCWM/SAPLUI_DLV_CORE:3210/ssubSUB_ODP1_1_CONTENT:/SCWM/SAPLUI_DLV_CORE:3211/cntlCONTAINER_ALV_ODP1_1/shellcont/shell");
        public GuiGridView gdDocDetails => _frameWindow.FindById<GuiGridView>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_DLV_PRD:2210/subSUB_OIP_1_CONTENT:/SCWM/SAPLUI_DLV_PRD:2211/cntlCONTAINER_ALV_OIP_1/shellcont/shell");
        public GuiTabStrip InbndTabstrip => _frameWindow.FindById<GuiTabStrip>("usr/subSUB_COMPLETE_ODP1:/SCWM/SAPLUI_DLV_PRD:3000/tabsTABSTRIP_ODP1");

        public GuiGridView gdHUDetails => _frameWindow.FindById<GuiGridView>("usr/subSUB_COMPLETE_ODP1:/SCWM/SAPLUI_DLV_PRD:3000/tabsTABSTRIP_ODP1/tabpOK_ODP1_TAB7/ssubSUB_ODP1_TAB7:/SCWM/SAPLUI_DLV_CORE:3270/ssubSUB_ODP1_7_CONTENT:/SCWM/SAPLUI_DLV_CORE:3271/cntlCONTAINER_ALV_ODP1_7/shellcont/shell");
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SAPInboundDelivery(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }



        public void PackInboundOrderItem(string ERPDocumentNo)
        {

            if (OutboundDeliveryType == null)
                _session.GotoTransaction("/n/scwm/prdi");

            SAPHandlers.Instance.SelectComboboxItemByKey(OutboundDeliveryType, "REFDOCNO_ERP_I");
            SAPHandlers.Instance.EnterTextInGuiTextField(ERPDocNo, ERPDocumentNo);
            SAPHandlers.Instance.ClickButton(getDocDetailsButton);


        }

        public void PackMaterial(string ERPDocumentNo)
        {
            PackInboundOrderItem(ERPDocumentNo);

            SAPHandlers.Instance.SelectMenuItem(packMenu);

            SAPHandlers.Instance.EnterTextInGuiCTextField(Packmaterial, "P004");
            SAPHandlers.Instance.ClickButton(PB_Create);

            //Code missing for moving article to handling unit using drag and drop option in SAP
        }
        public void CheckItemDetailStatus(string ERPDocumentNo, string columnDisplayname)
        {
            string status = string.Empty;
            PackInboundOrderItem(ERPDocumentNo);

            if (DeliveryItemDetails != null)
                status = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(DeliveryItemDetails, 0, columnDisplayname);

            if (string.IsNullOrEmpty(status))
            {
                log.Info($"Value of {columnDisplayname} not retrieved");
                Assert.Fail($"Value of {columnDisplayname} not retrieved");
            }                

            if (status != "Completed")
            {
                log.Info($"Status of {columnDisplayname} not completed");
                Assert.Fail($"Status of {columnDisplayname} not completed");
            }
            else
                log.Info($"Status of {columnDisplayname} completed");


        }

        public void CheckDocDetailStatus(string ERPDocumentNo, string columnDisplayname)
        {
            string status = string.Empty;
            PackInboundOrderItem(ERPDocumentNo);

            if (gdDocDetails != null)
                status = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gdDocDetails, 0, columnDisplayname);

            if (string.IsNullOrEmpty(status))
                Assert.Fail($"{columnDisplayname} not retrieved");

            if (status != "Completed")
                Assert.Fail($"{columnDisplayname} not completed");

        }

        
        public void CreateWarehouseTask()
        {
            SAPHandlers.Instance.SelectMenuItem(WarehouseTaskMenu);
            SAPHandlers.Instance.SelectTab(WTTab, 2);
        }

        public void ClickGoodsReceipt()
        {
            SAPHandlers.Instance.ClickToolbar(tbGoodsReceipt, "OIP_POST_GM");
        }

        public string GetHUFromInbound()
        {
            string HU;

            SAPHandlers.Instance.SelectTab(InbndTabstrip, 9);
            HU = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gdHUDetails, 0, "HU");
            return HU;
        }
    }
}
