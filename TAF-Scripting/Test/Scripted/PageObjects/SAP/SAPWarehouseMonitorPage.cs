using TAF_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sapfewse;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects
{
    public class SAPWarehouseMonitorPage
    {
        static GuiSession _session;
        public SAPWarehouseMonitorPage(GuiSession session)
        {
            _session = session;
        }
        public GuiTree PhysicalStockMenu => _session.FindById<GuiTree>("wnd[0]/usr/shell/shellcont[0]/shell");
        public GuiTextField PhysicalStockProduct => _session.FindById<GuiTextField>("wnd[1]/usr/ctxtS_MATNR-LOW");
        public GuiButton ExecuteButton => _session.FindById<GuiButton>("wnd[1]/tbar[0]/btn[8]");
        public GuiGridView PhysicalStockGrid => _session.FindById<GuiGridView>("wnd[0]/usr/shell/shellcont[1]/shell/shellcont[0]/shell");

        public void ExpandStockAndBin(string node)
        {
            SAPHandlers.Instance.ExpandTreeNodeByCode(PhysicalStockMenu, node);
        }

        public void SelectPhysicalStock(string node)
        {
            SAPHandlers.Instance.SelectTreeNodeByCode(PhysicalStockMenu, node);
        }

        public void SelectProduct(string value)
        {
            SAPHandlers.Instance.EnterTextInGuiTextField(PhysicalStockProduct, value);
            SAPHandlers.Instance.ClickButton(ExecuteButton);
        }

        public void ValidateStock(int stockrequired)
        {
            int totalRows = 0;
            int totalStock = 0;

            totalRows = PhysicalStockGrid.RowCount;

            for (int rowIndex = 0; rowIndex < totalRows - 1; rowIndex++)
            {
                //string stockCellValue = PhysicalStockGrid.GetCellValue(10, rowIndex).Replace(",", "");
                //string st = PhysicalStockGrid.GetCellValue(12, rowIndex).Replace(",", "");
                //string desc = PhysicalStockGrid.GetCellValue(13, rowIndex).Replace(",", "");
                //string owner = PhysicalStockGrid.GetCellValue(17, rowIndex).Replace(",", "");

                string stockCellValue = SAPHandlers.Instance.GetGridviewTextByRowColumn(PhysicalStockGrid, rowIndex, 10).Replace(",", "");
                string st = SAPHandlers.Instance.GetGridviewTextByRowColumn(PhysicalStockGrid, rowIndex, 12).Replace(",", "");
                string desc = SAPHandlers.Instance.GetGridviewTextByRowColumn(PhysicalStockGrid, rowIndex, 13).Replace(",", "");
                string owner = SAPHandlers.Instance.GetGridviewTextByRowColumn(PhysicalStockGrid, rowIndex, 17).Replace(",", "");


                int stock = int.Parse(string.IsNullOrEmpty(stockCellValue) ? "0" : stockCellValue);

                if (stock > 0 && st.Equals("F2") && owner.Equals("DC44") && desc.Equals("Unrestricted-Use Warehouse"))
                {
                    totalStock += stock;
                }
            }

            if (totalStock < stockrequired)
            {
                Assert.Fail("Exception occured while validation stock in SAP. Error details: Not enough stock available to purchase");
            }
        }

        public void ValidatePageTitle(string title, int window = 0)
        {
            string windowTitle = SAPHandlers.Instance.GetWindowTitle(_session, window);
            SAPHandlers.Instance.VerifyTextEquals(windowTitle, title);
        }
    }
}
