using TAF_SAP;
using sapfewse;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public  class SAPOutboundDelivery
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiComboBox OutboundDeliveryType => _frameWindow.FindById<GuiComboBox>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/cmb/SCWM/S_UI_DLV-V_CRITERION");               
        public GuiTextField ERPDocNo => _frameWindow.FindById<GuiTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_DLV_PRD:2003/txt/SCWM/S_SP_Q_HEAD-REFDOCNO_ERP_I");
        public GuiButton getDocDetailsButton => _frameWindow.FindById<GuiButton>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_DLV_PRD:2003/btnCMD_GO");
        public GuiGridView docDetailsGrid => _frameWindow.FindById<GuiGridView>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_DLV_PRD:2210/subSUB_OIP_1_CONTENT:/SCWM/SAPLUI_DLV_PRD:2211/cntlCONTAINER_ALV_OIP_1/shellcont/shell");

        public GuiToolbarControl createBtn => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_DLV_PRD:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");

        public GuiToolbarControl GoodsIssueButon => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_DLV_PRD:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");

        public GuiCTextField ctxtOutboundDelvy => _frameWindow.FindById<GuiCTextField>("usr/ctxtLIKP-VBELN");

        public GuiToolbarControl DisplayAdditionalBtn => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_DLV_PRD:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_DLV_PRD:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");
        public GuiGridView gvWarehouseOrderMain => _frameWindow.FindById<GuiGridView>("usr/subSUB_OIP:/SCWM/SAPLUI_TO_DISP:0120/subSUB_SEARCH_RESULT:/SCWM/SAPLUI_TO_DISP:0130/cntlCC_OIP/shellcont/shell");
        public GuiToolbarControl WarehouseOrderBtn => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_OIP:/SCWM/SAPLUI_TO_DISP:0120/cntlCC_OIP_TB/shellcont/shell");

        public GuiTab tabPickHU => _frameWindow.FindById<GuiTab>("usr/subSUB_ODP_1:/SCWM/SAPLUI_TO_CONF:0150/tabsTS_ODP1/tabpOK_ODP1_TAB3");
        public GuiToolbarControl tbCreate => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_ODP_1:/SCWM/SAPLUI_TO_CONF:0150/tabsTS_ODP1/tabpOK_ODP1_TAB3/ssubSUB_ODP1_3_TAB:/SCWM/SAPLUI_TO_CONF:0210/cntlCC_ODP1_TB_PHU/shellcont/shell");

        public GuiGridView gvWarehouseOrderDetails => _frameWindow.FindById<GuiGridView>("usr/subSUB_ODP_1:/SCWM/SAPLUI_TO_CONF:0150/tabsTS_ODP1/tabpOK_ODP1_TAB3/ssubSUB_ODP1_3_TAB:/SCWM/SAPLUI_TO_CONF:0210/subSUB_ODP1_3_CONT:/SCWM/SAPLUI_TO_CONF:0200/cntlCC_ODP1_PHU/shellcont/shell");
        public GuiGridView gvProductWT => _frameWindow.FindById<GuiGridView>("usr/subSUB_ODP_1:/SCWM/SAPLUI_TO_CONF:0150/tabsTS_ODP1/tabpOK_ODP1_TAB1/ssubSUB_ODP1_1_TAB:/SCWM/SAPLUI_TO_CONF:0155/ssubSUB_ODP1_1_CONT:/SCWM/SAPLUI_TO_CONF:0160/cntlCC_ODP1_MAT/shellcont/shell");

        public GuiTab tbProductWT => _frameWindow.FindById<GuiTab>("usr/subSUB_ODP_1:/SCWM/SAPLUI_TO_CONF:0150/tabsTS_ODP1/tabpOK_ODP1_TAB1");
        public GuiToolbarControl tbInProductWT => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_ODP_1:/SCWM/SAPLUI_TO_CONF:0150/tabsTS_ODP1/tabpOK_ODP1_TAB1/ssubSUB_ODP1_1_TAB:/SCWM/SAPLUI_TO_CONF:0155/cntlCC_ODP1_TB_MAT/shellcont/shell");
        public GuiToolbarControl tbInMain => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_OIP:/SCWM/SAPLUI_TO_CONF:0120/cntlCC_OIP_TB/shellcont/shell");
        public GuiCTextField ctxtDesBin => _frameWindow.FindById<GuiCTextField>("usr/subSUB_ODP_1:/SCWM/SAPLUI_TO_CONF:0150/tabsTS_ODP1/tabpOK_ODP1_TAB1/ssubSUB_ODP1_1_TAB:/SCWM/SAPLUI_TO_CONF:0155/ssubSUB_ODP1_1_CONT:/SCWM/SAPLUI_TO_CONF:0165/ctxt/SCWM/S_ASP_MAT_TO-NLPLA");

        public SAPOutboundDelivery(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;

          //  onOutboundDelivery();
        }

        public void onOutboundDelivery()
        {
            if (OutboundDeliveryType == null)
                _session.GotoTransaction("/N/SCWM/PRDO");
        }
        public string getDocumentOrderDetails(string ERPDocumentNo)
        {
            onOutboundDelivery();
            SAPHandlers.Instance.SelectComboboxItemByKey(OutboundDeliveryType, "REFDOCNO_ERP_I");
            SAPHandlers.Instance.EnterTextInGuiTextField(ERPDocNo, ERPDocumentNo);
            SAPHandlers.Instance.ClickButton(getDocDetailsButton);
            
            string DocNumber = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(docDetailsGrid, 0, "Document");
            if (string.IsNullOrEmpty(DocNumber))
                Assert.Fail("Document Number not retrieved");

            SAPHandlers.Instance.GridSelectAllRows(docDetailsGrid);
            return DocNumber;
        }

        public string CheckPackingStatus(string ERPDocumentNo)
        {
            onOutboundDelivery();
            SAPHandlers.Instance.SelectComboboxItemByKey(OutboundDeliveryType, "REFDOCNO_ERP_I");
            SAPHandlers.Instance.EnterTextInGuiTextField(ERPDocNo, ERPDocumentNo);
            SAPHandlers.Instance.ClickButton(getDocDetailsButton);

            string status = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(docDetailsGrid, 0, "Packing Status");
            return status;
        }

        public void ConfirmWTinWO()
        {
            SAPHandlers.Instance.ClickToolbarMenu(DisplayAdditionalBtn, "OIP_DETAIL_TO");
        }
        public string CreateWO()
        {
            SAPHandlers.Instance.GridSelectAllRows(gvWarehouseOrderMain);
            SAPHandlers.Instance.ClickToolbarMenu(WarehouseOrderBtn, "OIP_CALL_TO_CONF");
            SAPHandlers.Instance.SelectTabItem(tabPickHU);
            SAPHandlers.Instance.ClickToolbar(tbCreate, "ODP1_INSERT");
            SAPHandlers.Instance.EnterTextGridField(gvWarehouseOrderDetails, 0, "Storage Bin", "DROP_OFF");
            SAPHandlers.Instance.EnterTextGridField(gvWarehouseOrderDetails, 0, "Packaging Material", "P026");
            
           // SAPHandlers.Instance.ClickToolbar(tbCreate, "ODP1_CREATE_HU");
            string HU = string.Empty;
            int attempt=1;
            //HU = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gvWarehouseOrderDetails, 0, "Handling Unit");

            while(HU==string.Empty && attempt<=2)
            {
                SAPHandlers.Instance.GridSelectAllRows(gvWarehouseOrderDetails);
                SAPHandlers.Instance.ClickToolbar(tbCreate, "ODP1_CREATE_HU");
                HU = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gvWarehouseOrderDetails, 0, "Handling Unit");
                attempt++;
            }

            if(HU == string.Empty)
            {
                Assert.Fail("Warehouse order not created");
            }
           
            return HU;
        }

        public void CompleteGCPicking()
        {
            SAPHandlers.Instance.SelectTabItem(tbProductWT);
            SAPHandlers.Instance.GridSelectAllRows(gvProductWT);
            SAPHandlers.Instance.ClickToolbar(tbInProductWT, "OK_ODP1_TOGGLE");
            SAPHandlers.Instance.ClickToolbar(tbInProductWT, "ODP1_CONF_FGR");
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDesBin, "DROP_OFF");
            SAPHandlers.Instance.ClickToolbar(tbInMain, "OIP_CONF_SAVE");
            
        }

        public void refreshGrid()
        {            
            SAPHandlers.Instance.ClickToolbar(createBtn, "OIP_CREATE");
        }
        public string clickOnGoodsIssue(string ERPDocumentNo)
        {
            onOutboundDelivery();
            SAPHandlers.Instance.SelectComboboxItemByKey(OutboundDeliveryType, "REFDOCNO_ERP_I");
            SAPHandlers.Instance.EnterTextInGuiTextField(ERPDocNo, ERPDocumentNo);
            SAPHandlers.Instance.ClickButton(getDocDetailsButton);
            string Message = "";
            SAPHandlers.Instance.ClickToolbar(GoodsIssueButon, "OIP_POST_GM");

            //Need to handle the popup
            Message=SAPHandlers.Instance.GetStatusBarMessage(_session, 0);
            return Message;

        }


        public void OpenDMOutboundDelivery(string delvryNo)
        {
            if (ctxtOutboundDelvy == null)
                _session.GotoTransaction("/nvl03n");

            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtOutboundDelvy, delvryNo);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);

        }
    }
}
