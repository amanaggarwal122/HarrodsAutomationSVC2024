using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TAF_SAP;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPmerchandiseDistribution
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiCTextField ctxtPurchaseOrderNo => _frameWindow.FindById<GuiCTextField>("usr/ctxtBLNRB-LOW");
        public GuiButton execBtn => _frameWindow.FindById<GuiButton>("tbar[1]/btn[8]");

        public GuiLabel lblPickingDetails => _frameWindow.FindById<GuiLabel>("usr/lbl[13,4]");
        public GuiCTextField ctxtSupplySite => _frameWindow.FindById<GuiCTextField>("usr/subSUB0:SAPLMEGUI:0019/subSUB0:SAPLMEGUI:0030/subSUB1:SAPLMEGUI:1105/ctxtMEPO_TOPLINE-SUPERFIELD");
        public GuiGridView grdRetailInfo => _frameWindow.FindById<GuiGridView>("usr/subSUB0:SAPLMEGUI:0019/subSUB3:SAPLMEVIEWS:1100/subSUB2:SAPLMEVIEWS:1200/subSUB1:SAPLMEGUI:1301/subSUB2:SAPLMEGUI:1303/tabsITEM_DETAIL/tabpTABIDT14/ssubTABSTRIPCONTROL1SUB:SAPLMEGUI:1316/ssubPO_HISTORY:SAPLMMHIPO:0100/cntlMEALV_GRID_CONTROL_MMHIPO/shellcont/shell");

        public GuiTabStrip tbsPick => _frameWindow.FindById<GuiTabStrip>("usr/tabsTAXI_TABSTRIP_OVERVIEW");
        public GuiTextField txtPickedQty => _frameWindow.FindById<GuiTextField>("usr/tabsTAXI_TABSTRIP_OVERVIEW/tabpT\\02/ssubSUBSCREEN_BODY:SAPMV50A:1104/tblSAPMV50ATC_LIPS_PICK/txtLIPSD-PIKMG[6,0]");
        public GuiTextField txtDelvQty => _frameWindow.FindById<GuiTextField>("usr/tabsTAXI_TABSTRIP_OVERVIEW/tabpT\\02/ssubSUBSCREEN_BODY:SAPMV50A:1104/tblSAPMV50ATC_LIPS_PICK/txtLIPSD-G_LFIMG[4,0]");
        public GuiTextField txtHU => _frameWindow.FindById<GuiTextField>("usr/tabsTS_HU_VERP/tabpUE6INH/ssubTAB:SAPLV51G:6040/tblSAPLV51GTC_HU_005/txtHUMV4-IDENT[1,0]");
        public GuiButton btnPack => _frameWindow.FindById<GuiButton>("tbar[1]/btn[18]");
        public GuiButton btnBack => _frameWindow.FindById<GuiButton>("tbar[0]/btn[3]");
        public GuiButton btnDocFlow=> _frameWindow.FindById<GuiButton>("tbar[1]/btn[7]");
        public GuiCTextField ctxtOutboundDelvryNo => _frameWindow.FindById<GuiCTextField>("usr/subSUBSCREEN_HEADER:SAPMV50A:1502/ctxtLIKP-VBELN");
        public SAPmerchandiseDistribution(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;

        }
        public void OnMerchandiseDistbScreen()
        {
            if (ctxtPurchaseOrderNo == null)
                _session.GotoTransaction("/nwf30");
        }

        public void SwitchWindow(GuiSession guiSession, int windowIndex)
        {
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(guiSession, windowIndex);
        }

        public void OpenMerchandiseDistrbnMon(string purchaseNo)
        {
            OnMerchandiseDistbScreen();

            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtPurchaseOrderNo, purchaseNo);
            SAPHandlers.Instance.ClickButton(execBtn);

            SAPHandlers.Instance.SelectLabel(lblPickingDetails);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Ctrl_F11);
            Thread.Sleep(1000);
        }
      
        public Tuple<string, string> MerchandiseDisbDetails(string purchaseNo)
        {

            OpenMerchandiseDistrbnMon(purchaseNo);

            string supplySite= SAPHandlers.Instance.GetTextFromGuiCTextField(ctxtSupplySite);

            string site;
            string[] switchStrings = { "DC22", "DCM1" };
            switch (switchStrings.FirstOrDefault<string>(s => supplySite.ToUpper().Contains(s)))
            {
                case "DC22":
                    site = supplySite;
                    break;
                case "DCM1":
                    site = supplySite;
                    break;
                default:
                    site = "SF";
                    break;
            }

           string articleDoc= string.Empty;
          //=  SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(grdRetailInfo, 0, "Article Document");

            if (grdRetailInfo != null)
            {
                int rowCnt = SAPHandlers.Instance.GridGetRowCount(grdRetailInfo);
                if (rowCnt == 1)
                {
                    // SAPHandlers.Instance.ClickCell(grdRetailInfo, 0, "Article Document");
                    articleDoc = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(grdRetailInfo, 0, "Article Document");
                }
                else
                {
                    for (int i = 0; i < rowCnt; i++)
                    {
                        articleDoc = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(grdRetailInfo, i, "Article Document");
                        if (articleDoc.StartsWith("895"))
                        {
                          //  SAPHandlers.Instance.ClickCell(grdRetailInfo, i, "Article Document");
                            break;
                        }
                    }
                }
            }
            return  new Tuple<string, string>(site, articleDoc);
           
        }

        public void refreshAutomatedSTO(string purchaseNo)
        {
            if(ctxtOutboundDelvryNo!=null)
            {
                SAPHandlers.Instance.ClickButton(btnBack);
            }

            if(ctxtSupplySite!=null)
            {
                SAPHandlers.Instance.GridPressToolBar(grdRetailInfo, "REFRESH");

            }
            else
            {
                OpenMerchandiseDistrbnMon(purchaseNo);
            }

        }
        public int verifyPicking()
        {
            int deliveryQty=0;
            if (grdRetailInfo!=null)
            {
                OpenDMoutDelivery();
                Thread.Sleep(1000);
              
                SAPHandlers.Instance.SelectTab(tbsPick, 2);
                deliveryQty = int.Parse(SAPHandlers.Instance.GetTextFromGuiTextField(txtPickedQty));
               
            }
            return deliveryQty;
        }


        public string verifyHU()
        {
            string createdHU=string.Empty;
            if(btnPack!=null)
            {
                SAPHandlers.Instance.ClickButton(btnPack);
                createdHU = SAPHandlers.Instance.GetTextFromGuiTextField(txtHU);
            }
            SAPHandlers.Instance.ClickButton(btnBack);
            return createdHU;
        }

        public void OpenDocFlow()
        {
            SAPHandlers.Instance.ClickButton(btnDocFlow);
        }

        public void VerifyShipentNo()
        {
          
            OpenDMoutDelivery();
            OpenDocFlow();

            SAPDisplaySalesOrder sapDisplaySalesOrder = new SAPDisplaySalesOrder(_session, _frameWindow);
            sapDisplaySalesOrder.OpenDocumentNo("Shipment", "Doc.no.", true);
        }

        public string  retrieveInboundDelvNo()
        {
            if (grdRetailInfo != null)
            {
                int rowCnt = SAPHandlers.Instance.GridGetRowCount(grdRetailInfo);
                if(rowCnt==1)
                {
                    SAPHandlers.Instance.ClickCell(grdRetailInfo, 0, "Article Document");
                }
                else
                {
                    for (int i = 0; i < rowCnt; i++)
                    {
                      string articleNo =  SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(grdRetailInfo, i, "Article Document");
                    }
                }
               
                Thread.Sleep(1000);

            }
            OpenDocFlow();

            SAPDisplaySalesOrder sapDisplaySalesOrder = new SAPDisplaySalesOrder(_session, _frameWindow);
            string IndeliveryNumber = sapDisplaySalesOrder.getDocumentNo("DM Inb.", "Doc.no.", true);
            return IndeliveryNumber;
        }

        public void OpenDMoutDelivery()
        {
            if (grdRetailInfo != null)
            {
                int rowCnt = SAPHandlers.Instance.GridGetRowCount(grdRetailInfo);
                if (rowCnt == 1)
                {
                    SAPHandlers.Instance.ClickCell(grdRetailInfo, 0, "Article Document");
                }
                else
                {
                    for (int i = 0; i < rowCnt; i++)
                    {
                        string articleNo = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(grdRetailInfo, i, "Article Document");
                        if(articleNo.StartsWith("895"))
                        {
                            SAPHandlers.Instance.ClickCell(grdRetailInfo, i, "Article Document");
                            break;
                        }
                    }
                }
            }           
        }

        public string GetInboundDeliveryNo(string docName)
        {
            
            SAPDisplaySalesOrder sapDisplaySalesOrder = new SAPDisplaySalesOrder(_session, _frameWindow);
            string IndeliveryNumber = sapDisplaySalesOrder.getDocumentNo(docName, "Doc.no.", true);
            return IndeliveryNumber;
        }
    }
}
