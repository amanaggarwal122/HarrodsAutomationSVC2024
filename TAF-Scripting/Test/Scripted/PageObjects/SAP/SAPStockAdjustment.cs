using TAF_SAP;
using sapfewse;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class SAPStockAdjustment
    {
        static GuiFrameWindow _frameWindow;
        static GuiSession _session;

        /*Window Enter Goods Issue*/
        public GuiCTextField MovementType => _frameWindow.FindById<GuiCTextField>("usr/ctxtRM07M-BWARTWA");
        public GuiCTextField Site => _frameWindow.FindById<GuiCTextField>("usr/ctxtRM07M-WERKS");
        public GuiCTextField StorageLoc => _frameWindow.FindById<GuiCTextField>("usr/ctxtRM07M-LGORT");

        public GuiCTextField goodsItem => _frameWindow.FindById<GuiCTextField>("usr/sub:SAPMM07M:0421/ctxtMSEG-MATNR[0,7]");
        public GuiTextField goodsItemQty => _frameWindow.FindById<GuiTextField>("usr/sub:SAPMM07M:0421/txtMSEG-ERFMG[0,26]");
        public GuiButton saveBtn => _frameWindow.FindById<GuiButton>("tbar[0]/btn[11]");
      
        public string movementType;
        public string site;
        public string storageLoc;
      

        public SAPStockAdjustment(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }

        public void StockAdjustment()
        {
            _session.GotoTransaction("/nmb1a");
            SAPHandlers.Instance.EnterTextInGuiCTextField(MovementType, movementType);
            SAPHandlers.Instance.EnterTextInGuiCTextField(Site, site);
            SAPHandlers.Instance.EnterTextInGuiCTextField(StorageLoc, storageLoc);

            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);
        }

        public string EnterGoods(string articleNo, string itemQty)
        {
            string deliveryNo=string.Empty;
            SAPHandlers.Instance.EnterTextInGuiCTextField(goodsItem, articleNo);
            SAPHandlers.Instance.EnterTextInGuiTextField(goodsItemQty, itemQty);
            SAPHandlers.Instance.ClickButton(saveBtn);

            string statusMsg = SAPHandlers.Instance.GetStatusBarMessage(_session, 0);
            // string statusMsg = "Delivery 190436500 created";
            if (statusMsg.Contains("Delivery") && statusMsg.Contains("created"))
            {
                var matches = Regex.Matches(statusMsg, @"\s\d+\s");
                deliveryNo = matches[0].Value.Trim();
            }
            else if (statusMsg.Contains("Document") && statusMsg.Contains("posted"))
            {
                var matches = Regex.Matches(statusMsg, @"\s\d+\s");
                deliveryNo = matches[0].Value.Trim();
            }
            else
            {
               Assert.Fail("Stock adjustment document not created");
            }

            return  deliveryNo;           
        }


    }

}
