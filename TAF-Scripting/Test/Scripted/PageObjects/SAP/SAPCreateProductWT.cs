using TAF_SAP;
using sapfewse;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPCreateProductWT
    {

        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiCTextField txtProduct => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_ADMA:2001/ctxt/SCWM/S_ASPQ_MAT-MATNR");
        public GuiButton btnExecute => _frameWindow.FindById<GuiButton>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_SEARCH_VALUE:/SCWM/SAPLUI_ADMA:2001/btnCMD_GO");
        public GuiGridView gdProduct => _frameWindow.FindById<GuiGridView>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2211/cntlCONTAINER_ALV_OIP_1/shellcont/shell");
        public GuiGridView gdFilterColumn => _frameWindow.FindById<GuiGridView>("usr/subSUB_DYN0500:SAPLSKBH:0600/cntlCONTAINER1_FILT/shellcont/shell");
        public GuiButton btnDefineValues => _frameWindow.FindById<GuiButton>("usr/subSUB_DYN0500:SAPLSKBH:0600/btn600_BUTTON");

        public GuiCTextField ctxtSHu => _frameWindow.FindById<GuiCTextField>("usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN001-LOW");
        public GuiCTextField ctxtAQty => _frameWindow.FindById<GuiCTextField>("usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN003-LOW");
        public GuiToolbarControl tbFormView => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");

        public GuiCTextField txtWTDocType => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2212/ctxt/SCWM/S_ASP_MAT-PROCTY");

        public GuiButton btnOk => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");
        public GuiGridView gdSaveStatus => _frameWindow.FindById<GuiGridView>("usr/subSUBSCREEN:SAPLSBAL_DISPLAY:0101/cntlSAPLSBAL_DISPLAY_CONTAINER/shellcont/shell");
        public GuiTextField txtAvlQtyAUom => _frameWindow.FindById<GuiTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2212/txt/SCWM/S_ASP_MAT-AVAIL_QUAN_A");
        public GuiTextField txtSrctargetAvlQtyAUom => _frameWindow.FindById<GuiTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2212/txt/SCWM/S_ASP_MAT-VSOLA");
        public GuiCTextField ctxtDestinationStorageBinCode => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2212/ctxt/SCWM/S_ASP_MAT-NLTYP");
        public GuiCTextField ctxtDestinationStorageBinNo => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2212/ctxt/SCWM/S_ASP_MAT-NLBER");
        public GuiCTextField ctxtDestinationStorageBinName => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2212/ctxt/SCWM/S_ASP_MAT-NLPLA");
        public GuiCTextField ctxtDestinationHu => _frameWindow.FindById<GuiCTextField>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/subSUB_OIP_1_DATA:/SCWM/SAPLUI_ADMA:2212/ctxt/SCWM/S_ASP_MAT-NLENR");

        public GuiToolbarControl tbCreate => _frameWindow.FindById<GuiToolbarControl>("usr/subSUB_COMPLETE_OIP:/SCWM/SAPLUI_ADMA:2000/subSUB_OIP_DATA_AREA:/SCWM/SAPLUI_ADMA:2210/cntlCONTAINER_TB_OIP_1/shellcont/shell");
        

        public SAPCreateProductWT(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }

        public void onCreateProductWTScreen()
        {
            if (txtProduct == null)
                _session.GotoTransaction("/N/SCWM/ADPROD");
        }

        public void GetProductDetails(string productID)
        {
            onCreateProductWTScreen();
            SAPHandlers.Instance.EnterTextInGuiCTextField(txtProduct, productID);
            SAPHandlers.Instance.ClickButton(btnExecute);
        }

        public void SelectGRzoneProduct(string storageBin, string availableQty)
        {
            FilterTheProduct(storageBin, availableQty);
            SelectTheAdjustedStock();
        }

        public void FilterTheProduct(string storageBin, string availableQty)
        {

            SAPHandlers.Instance.selectMenuOption(gdProduct, "&MB_FILTER", "&FILTER");

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            if (gdFilterColumn == null)
            {
                Assert.Fail("Filter option failed");
            }
           
            gdFilterColumn.SelectedRows = "10";
            gdFilterColumn.DoubleClickCurrentCell();
            gdFilterColumn.SelectedRows = "12";
            gdFilterColumn.DoubleClickCurrentCell();

            SAPHandlers.Instance.ClickButton(btnDefineValues);

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 2);
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtSHu, storageBin);
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtAQty, availableQty);
            SAPHandlers.Instance.ClickButton(btnOk);

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
        }

        public void SelectTheAdjustedStock()
        {
            int totalRows = 0;
            
            totalRows = gdProduct.RowCount;

            for (int rowIndex = 0; rowIndex < totalRows ; rowIndex++)
            {
                string sourceHU = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gdProduct, rowIndex, "Source HU");

                if (string.IsNullOrEmpty(sourceHU))
                {
                    gdProduct.SelectedRows = rowIndex.ToString();
                    break;
                }
                    
            }   

            
        }

        public void SwitchToFormView()
        {
            SAPHandlers.Instance.ClickToolbar(tbFormView, "OK_OIP_TOGGLE");
        }

        public void SetWTDocType()
        {
            SAPHandlers.Instance.EnterTextInGuiCTextField(txtWTDocType, "3040");
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            SAPHandlers.Instance.ClickButton(btnOk);
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session,0);
        }


        public void SetDestinationHU(string productID , string destinationHU)
        {
            onCreateProductWTScreen();

            string avlQty = SAPHandlers.Instance.GetTextFromGuiTextField(txtAvlQtyAUom);

            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDestinationStorageBinCode, "9010");
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDestinationStorageBinNo, "0001");
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDestinationStorageBinName, "GR-ZONE");

            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDestinationHu, destinationHU);
            SAPHandlers.Instance.EnterTextInGuiTextField(txtSrctargetAvlQtyAUom, avlQty);

            SAPHandlers.Instance.ClickToolbar(tbCreate, "OK_OIP_CREATE_POST_MAT_TO");

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            string wtStatus = gdSaveStatus.GetCellValue(0, "T_MSG").Replace(",", "");
            string woStatus = gdSaveStatus.GetCellValue(1, "T_MSG").Replace(",", "");
            SAPHandlers.Instance.ClickButton(btnOk);
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

            if(!wtStatus.Contains("Warehouse task") && !wtStatus.Contains("was created and confirmed") && !woStatus.Contains("Warehouse order") && !woStatus.Contains("created"))
            {
                Assert.Fail("Failed to create Warehouse task and Warehouse order");
            }
        }
    }

}
