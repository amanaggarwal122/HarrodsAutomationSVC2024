using TAF_SAP;
using System;
using sapfewse;
using NUnit.Framework;
using System.Data;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class SAPMonitorScreenProcess
    {
        static GuiFrameWindow _frameWindow;
        static GuiSession _session;

        public GuiGridView gdPhysicalStock => _frameWindow.FindById<GuiGridView>("usr/shell/shellcont[1]/shell/shellcont[0]/shell");
        public GuiGridView OutboundDeliveryOrder => _frameWindow.FindById<GuiGridView>("usr/shell/shellcont[1]/shell/shellcont[0]/shell");
        public GuiGridView WareHouseTaskGrid => _frameWindow.FindById<GuiGridView>("usr/shell/shellcont[1]/shell/shellcont[1]/shell");
        public GuiTextField gridFilterText => _frameWindow.FindById<GuiTextField>("usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN001-LOW");
        public GuiButton gridFilterExec => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");
        public GuiTree WareHouseManagementMonitoLeftMenu => _frameWindow.FindById<GuiTree>("usr/shell/shellcont[0]/shell");

        public GuiCTextField ProductNo => _frameWindow.FindById<GuiCTextField>("usr/ctxtS_MATNR-LOW");
       
        //public GuiTree ResourceMangement => _frameWindow.FindById<GuiTree>("usr/shell/shellcont[0]/shell");
        public GuiGridView MoreMethods => _frameWindow.FindById<GuiGridView>("usr/shell/shellcont[1]/shell/shellcont[0]/shell");
        public GuiTextField Resource1 => _frameWindow.FindById<GuiTextField>("usr/txtS_RSRC-LOW");
        public GuiButton ExecuteButton => _frameWindow.FindById<GuiButton>("tbar[0]/btn[8]");
        public GuiTextField DeliveryOrderPromptOrderSearch => _frameWindow.FindById<GuiTextField>("usr/txtS_DOCNO-LOW");       
        public GuiCTextField QueueNumber => _frameWindow.FindById<GuiCTextField>("usr/sub:SAPLSPO4:0300/ctxtSVALD-VALUE[1,21]");
        public GuiButton ChangeQueueExecuteButton => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");
        public GuiButton DisplayLogsOkButton => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");
        public GuiGridView PhysicalStockGrid => _frameWindow.FindById<GuiGridView>("usr/shell/shellcont[1]/shell/shellcont[0]/shell");
        public GuiGridView gdFilterColumn => _frameWindow.FindById<GuiGridView>("usr/subSUB_DYN0500:SAPLSKBH:0600/cntlCONTAINER1_FILT/shellcont/shell");
        public GuiButton btnDefineValues => _frameWindow.FindById<GuiButton>("usr/subSUB_DYN0500:SAPLSKBH:0600/btn600_BUTTON");
        public GuiCTextField ctxtFilter1 => _frameWindow.FindById<GuiCTextField>("usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN001-LOW");
        public GuiCTextField ctxtFilter2 => _frameWindow.FindById<GuiCTextField>("usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN002-LOW");
        public GuiCTextField ctxtFilter3 => _frameWindow.FindById<GuiCTextField>("usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN004-LOW");
        public GuiCTextField ctxtFilter4 => _frameWindow.FindById<GuiCTextField>("usr/ssub%_SUBSCREEN_FREESEL:SAPLSSEL:1105/ctxt%%DYN005-LOW");

        public GuiButton btnOk => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");

        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SAPMonitorScreenProcess(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;          
        }

        public void onMonitorScreen()
        {
            if (WareHouseManagementMonitoLeftMenu == null)
                _session.GotoTransaction("/N/SCWM/MON");
        }

        public void SwitchWindow(GuiSession guiSession, int windowIndex)
        {
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(guiSession, windowIndex);
        }        

        public void SelectColumnTo_FilterGrid(string ColumnName)
        {

            SAPHandlers.Instance.FilterGridviewColumn(WareHouseTaskGrid, ColumnName);
            //WareHouseTaskGrid.SetCurrentCell(3, "");
            //WareHouseTaskGrid.SelectedRows = "3";

        }

        public void FilterGridWithCondition(string filterValue)
        {
            SAPHandlers.Instance.EnterTextInGuiTextField(gridFilterText, filterValue);
            SAPHandlers.Instance.ClickButton(gridFilterExec);
        }

        public void selectAllRowsInGrid()
        {
            SAPHandlers.Instance.GridSelectAllRows(WareHouseTaskGrid);
        }
        public void ConfirmWTinBgrd()
        {
            log.Info("Confirm WT in Background");
            WareHouseTaskGrid.PressToolbarContextButton("METHODS");
            WareHouseTaskGrid.SelectContextMenuItem("@M00007");

            string Message = SAPHandlers.Instance.GetStatusBarMessage(_session, 0);

            if(!string.IsNullOrEmpty(Message))
                log.Info(Message);

            if (Message.Contains("is inactive and therefore cannot be confirmed"))
                Assert.Fail(Message);
        }

        public void clickDisplaylogsOkButton()
        {
            SAPHandlers.Instance.ClickButton(DisplayLogsOkButton);
        }

        private void ExpandNode_SCWM(string Node ,bool expand = true)
        {
            onMonitorScreen();

            if (expand)
                 SAPHandlers.Instance.ExpandTreeNodeByCode(WareHouseManagementMonitoLeftMenu, Node);
            else
                SAPHandlers.Instance.SelectTreeNodeByCode(WareHouseManagementMonitoLeftMenu, Node);
        }
        
        public void OpenOutboundDeliveryOrder()
        {
            ExpandNode_SCWM("C000000001");
            ExpandNode_SCWM("C000000004");
            SAPHandlers.Instance.ExpandTreeNodeByText(WareHouseManagementMonitoLeftMenu, "Outbound Delivery Order");
        }

        public void OpenResourceMgmt()
        {
            ExpandNode_SCWM("C000000014");
            ExpandNode_SCWM("N000000048",false);          
        }

        public void OpenStock_Bin_PhysicalStock(string articleNo)
        {
            ExpandNode_SCWM("C000000011");
            ExpandNode_SCWM("N000000137", false);

            SwitchWindow(_session, 1);
            SAPHandlers.Instance.EnterTextInGuiCTextField(ProductNo, articleNo);
            SAPHandlers.Instance.ClickButton(ExecuteButton);
            SwitchWindow(_session, 0);
        }

        public void CheckForHUinPhysicalStock(string articleNo , string newHU , string qty)
        {
            OpenStock_Bin_PhysicalStock(articleNo);

            if (PhysicalStockGrid == null)
                Assert.Fail("Physical stock not available");

            FilterTheProduct(newHU ,  qty);
            CheckTheAdjustedStock();

        }

        public void FilterTheProduct(string newHU ,  string qty)
        {

            SAPHandlers.Instance.selectMenuOption(gdPhysicalStock, "&MB_FILTER", "&FILTER");

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            if (gdFilterColumn == null)
            {
                Assert.Fail("Filter option failed");
            }

            gdFilterColumn.SelectedRows = "7";
            gdFilterColumn.DoubleClickCurrentCell();
            gdFilterColumn.SelectedRows = "1";
            gdFilterColumn.DoubleClickCurrentCell();
            gdFilterColumn.SelectedRows = "8";
            gdFilterColumn.DoubleClickCurrentCell();
            //gdFilterColumn.SelectedRows = "10";
            //gdFilterColumn.DoubleClickCurrentCell();

            SAPHandlers.Instance.ClickButton(btnDefineValues);

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 2);
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtFilter1, "WAT01B01");
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtFilter2, newHU);
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtFilter3, qty);
            //SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtAQty, availableQty);
            SAPHandlers.Instance.ClickButton(btnOk);

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
        }

        public void CheckTheAdjustedStock()
        {
            int totalRows = 0;

            totalRows = gdPhysicalStock.RowCount;

            if (totalRows == 0)
            {
                log.Info($"Stock adjustment failed");
                Assert.Fail("Stock adjustment failed");
            }
            else
            {
                log.Info($"Successfully updated the stock");
            }
                
            
        }
        public int GetAvailablePhysicalStock(string articleNo, string storageBinVal, string stockTypeVal, string descVal, string ownerVal)
        {
            int totalRows = 0;
            int totalStock = 0;

            totalRows = PhysicalStockGrid.RowCount;

            for (int rowIndex = 0; rowIndex < totalRows - 1; rowIndex++)
            {
                string storageBin = PhysicalStockGrid.GetCellValue(rowIndex, "LGPLA").Replace(",", "");
                string quantity = PhysicalStockGrid.GetCellValue(rowIndex, "QUAN").Replace(",", "");
                string stockType = PhysicalStockGrid.GetCellValue(rowIndex, "CAT").Replace(",", "");
                string stockDesc = PhysicalStockGrid.GetCellValue(rowIndex, "CAT_TXT").Replace(",", "");
                string owner = PhysicalStockGrid.GetCellValue(rowIndex, "OWNER").Replace(", ", "");

                
                int stock = int.Parse(string.IsNullOrEmpty(quantity) ? "0" : quantity);

                if (stock > 0 && stockType.Equals(stockTypeVal) && owner.Equals(ownerVal) && stockDesc.Equals(descVal))
                {
                    totalStock += stock;
                }
            }


            return totalStock;
        }

       

        public int GetPhysicalStock(string articleNo ,string storageBin,  string stockType , string Desc , string owner)
        {

            
            OpenStock_Bin_PhysicalStock(articleNo);            


            Func<DataRow, bool> predicate = x => x.Field<string>("ST") == stockType && x.Field<string> ("Description of Stock Type") == Desc 
            && x.Field<string>("Owner")== owner && x.Field<string>("Storage Bin") == storageBin;

            DataTable dtAvailableStock = SAPHandlers.Instance.GetFilteredRowsByCellValues(PhysicalStockGrid, predicate);

            int rowCount = dtAvailableStock.Rows.Count;

            return 0;
        }
        public void SetResource(String resourceID)
        {
            SAPHandlers.Instance.EnterTextInGuiTextField(Resource1, resourceID);
            SAPHandlers.Instance.ClickButton(ExecuteButton);
        }

        public void LogOffResource()
        {
            SAPHandlers.Instance.selectMenuOption(MoreMethods, "METHODS", "@MRSRC3");
        }
        public void ChangeQueue()
        {
            SAPHandlers.Instance.selectMenuOption(MoreMethods, "METHODS", "@MRSRC4");
        }
        public void ActionChangeQueue(string resourceID)
        {
            if(resourceID == "CK3001")
            {
                SAPHandlers.Instance.EnterTextInGuiCTextField(QueueNumber, "HD_STD");               
            }
            else
            {
                SAPHandlers.Instance.EnterTextInGuiCTextField(QueueNumber, "OUTBNDGI");               
            }
            SAPHandlers.Instance.ClickButton(ChangeQueueExecuteButton);
        }
        public void SetDeliveryOrder(string DocNo)
        {
            SAPHandlers.Instance.EnterTextInGuiTextField(DeliveryOrderPromptOrderSearch, DocNo);
            SAPHandlers.Instance.ClickButton(ExecuteButton);

        }

        public void ShowWareHouseTaskDetails()
        {
            OutboundDeliveryOrder.PressToolbarContextButton("N000000096");
        }

        public string WTGetSingleData(string columnName)
        {                              
            if (WareHouseTaskGrid == null)
            {
                Assert.Fail("Warehouse Task details not found");
            }
            return SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(WareHouseTaskGrid, 0, columnName);
        }       

        public void ChangeQueue(String resourceID, GuiSession session)
        {
          
            SAPHandlers.Instance.selectMenuOption(MoreMethods, "METHODS", "@MRSRC4");
            _frameWindow = SAPHandlers.Instance.SetToNextWindow(_frameWindow, session);
            SAPHandlers.Instance.EnterTextInGuiCTextField(QueueNumber, "OUTBNDGI");
            SAPHandlers.Instance.ClickButton(ChangeQueueExecuteButton);
            _frameWindow = SAPHandlers.Instance.SetToPreviousWindow(_frameWindow, session);


        }
        public void EnterResouceIDDetails(String resourceID)
        {
            SAPHandlers.Instance.EnterTextInGuiTextField(Resource1, resourceID);
            SAPHandlers.Instance.ClickButton(ExecuteButton);

        }
    }
}
