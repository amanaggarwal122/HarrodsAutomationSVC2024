using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public static class SAPGotoTransaction
    {

        public static void GotoTransaction(this GuiSession session, string transaction)
        {
            SAPHomePage saphomePage = new SAPHomePage(session);
            transaction = transaction.ToUpper();
            switch (transaction)
            {
                case "/N/SCWM/MON":
                    saphomePage.SelectTransaction("/n/SCWM/MON");
                    saphomePage.ValidatePageTitle("Warehouse Management Monitor");
                    break;
                case "/N/SCWM/RFUI":
                    saphomePage.SelectTransaction("/n/SCWM/RFUI");
                    break;
                case "/N/SCWM/PRDO":
                    saphomePage.SelectTransaction("/n/SCWM/PRDO");
                    saphomePage.ValidatePageTitle("Maintain Outb. Deliv. Order - Warehouse No. 0044 (Time Zone GMTUK)");
                    break;
                case "/NVA03":
                    saphomePage.SelectTransaction("/nVA03");
                    saphomePage.ValidatePageTitle("Display Sales Order");
                    break;
                case "/NZ1114":
                    saphomePage.SelectTransaction("/nZ1114");
                    saphomePage.ValidatePageTitle("SAP");
                    break;
                case "/NRWBE":
                    saphomePage.SelectTransaction("/nRwbe");
                    saphomePage.ValidatePageTitle("Stock Overview");
                    break;
                case "/NMB1A":
                    saphomePage.SelectTransaction("/nmb1a");
                    saphomePage.ValidatePageTitle("Enter Goods Issue: Initial Screen");
                    break;
                case "/N/SCWM/PRDI":
                    saphomePage.SelectTransaction("/n/scwm/prdi");
                    saphomePage.ValidatePageTitle("Maintain Inbound Delivery - Warehouse Number 0044 (Time Zone GMTUK)");
                    break;
                case "/N/SCWM/ADPROD":
                    saphomePage.SelectTransaction("/N/SCWM/ADPROD");
                    saphomePage.ValidatePageTitle("Create Product Warehouse Task in Warehouse Number 0044");
                    break;
                case "/N/SCWM/PACK":
                    saphomePage.SelectTransaction("/N/SCWM/PACK");
                    saphomePage.ValidatePageTitle("Work Center: Packing - General");
                    break;
                case "/N/SCWM/ADHU":
                    saphomePage.SelectTransaction("/N/SCWM/ADHU");
                    saphomePage.ValidatePageTitle("Create HU Warehouse Task in Warehouse Number 0044");
                    break;
                case "/NWF30":
                    saphomePage.SelectTransaction("/nwf30");
                    saphomePage.ValidatePageTitle("Merchandise Distribution");
                    break;
                case "/NZSFALLOC":
                    saphomePage.SelectTransaction("/NZSFALLOC");
                    saphomePage.ValidatePageTitle("Picking Allocation for Shop Floors");
                    break;
                case "/NVT01N":
                    saphomePage.SelectTransaction("/nVT01n");
                    saphomePage.ValidatePageTitle("Create Shipment");
                    break;
                case "/NVL03N":
                    saphomePage.SelectTransaction("/nvl03n");
                    saphomePage.ValidatePageTitle("Display Outbound Delivery");
                    break;
                case "/NZWMALLOC":
                    saphomePage.SelectTransaction("/nZWMALLOC");
                    saphomePage.ValidatePageTitle("Picking Allocation");
                    break;
                case "SE11":
                    saphomePage.SelectTransaction("SE11");
                    saphomePage.ValidatePageTitle("ABAP Dictionary: Initial Screen");
                    break;
                case "/N/POSDW/MON0":
                    saphomePage.SelectTransaction("/n/posdw/mon0");
                    saphomePage.ValidatePageTitle("POS Workbench");
                    break;

            }
        }

    }
}
