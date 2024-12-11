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
    public class SAPProductDetailsPage
    {
        static GuiSession _session;
        string _SAPconnection = string.Empty, FileName = string.Empty;
      
        GuiFrameWindow window = null;
        private SAPHomePage saphomePage = null;
        private SAPProductSearchPage sapProductSearchPage = null;
        private SAPProductDetailsPage sapProductDetailsPage = null;
        private SAPWarehouseMonitorPage sapWarehouseMonitorPage = null;
        public SAPProductDetailsPage(GuiSession session)
        {
            _session = session;
        }

        public GuiTableControl ProductGrid => _session.FindById<GuiTableControl>("wnd[0]/usr/subINCLUDE1XX:SAPMM61R:0750/tblSAPMM61RTC_EZ");
        public GuiButton ProductGridProductDetailsButton => _session.FindById<GuiButton>("wnd[0]/usr/subINCLUDE1XX:SAPMM61R:0750/tblSAPMM61RTC_EZ/btnMDEZ-DETAIL_ICON[0,0]");
        public GuiTextField UnrestrictedStock => _session.FindById<GuiTextField>("wnd[1]/usr/txtMDSTA-LABST");
        public GuiButton ProductStockDetailOkButton => _session.FindById<GuiButton>("wnd[1]/tbar[0]/btn[0]");

        public void ValidateStock(int stockrequired)
        {
            //from grid
            int gridStock = 0;
            //string celltext = ProductGrid.GetCell(0, 9).Text;
            string celltext = SAPHandlers.Instance.GetTableCellValueByRowColumn(ProductGrid, 0, 9);
            celltext = celltext.Replace(",", "");
            gridStock = int.Parse(celltext);

            //from details form
            
            SAPHandlers.Instance.ClickButton(ProductGridProductDetailsButton);

            int detailStock = 0;
            string stockText = SAPHandlers.Instance.GetTextFromGuiTextField(UnrestrictedStock);
            stockText = stockText.Replace(",", "");
            detailStock = int.Parse(stockText);

            SAPHandlers.Instance.ClickButton(ProductStockDetailOkButton);


            if (detailStock < stockrequired)
            {
                Assert.Fail("Exception occured while validation stock in SAP. Error details: Not enough stock available to purchase");
            }

        }

        public void ValidatePageTitle(string title,int window=0)
        {
            string windowTitle = SAPHandlers.Instance.GetWindowTitle(_session, window);
            SAPHandlers.Instance.VerifyTextEquals(windowTitle, title);
        }

        public void ValidateStockInSystem(GuiSession guiSession,string system, string product, string site, int stockrequired)
        {switch (system.ToUpper())
            {
                case "HQ4":
                    {
                        string transaction = "/NMD04";
                                              saphomePage = new SAPHomePage(guiSession);
                        sapProductSearchPage = new SAPProductSearchPage(guiSession);
                        sapProductDetailsPage = new SAPProductDetailsPage(guiSession);

                        saphomePage.ValidatePageTitle("SAP Easy Access  SAP Retail");
                        saphomePage.SelectTransaction(transaction);
                        saphomePage.ValidatePageTitle("Stock/Requirements List: Initial Screen");

                        sapProductSearchPage.SearchArticle(product, site);

                        sapProductDetailsPage.ValidateStock(stockrequired);
                        break;
                    }
                   
                case "EQ1":
                    { 
                    saphomePage = new SAPHomePage(guiSession);
                    sapWarehouseMonitorPage = new SAPWarehouseMonitorPage(guiSession);

                    saphomePage.ValidatePageTitle("SAP Easy Access  -  User Menu");
                    saphomePage.SelectTransactionFromMenu("F00009");
                    saphomePage.ValidatePageTitle("Warehouse Management Monitor ZTVDC - Warehouse Number 0044");
                    sapWarehouseMonitorPage.ExpandStockAndBin("C000000011");
                    sapWarehouseMonitorPage.SelectPhysicalStock("N000000137");

                    sapWarehouseMonitorPage.SelectProduct(product);

                    sapWarehouseMonitorPage.ValidateStock(stockrequired);
                        break;
                    }
                

                default:
                    Assert.Fail("No connection available");
                    break;
            }
            SAPDriver.Instance.CloseConnection();
            SAPDriver.Instance.CloseProcess();

        }
    }
}
