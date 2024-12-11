using NUnit.Framework;
using sapfewse;
using System.Threading;
using TAF_SAP;


namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPTrunckingODC
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiMenu changeMenu => _frameWindow.FindById<GuiMenu>("mbar/menu[0]/menu[1]");
        public GuiButton btnPlan => _frameWindow.FindById<GuiButton>("usr/tabsHEADER_TABSTRIP2/tabpTABS_OV_DE/ssubG_HEADER_SUBSCREEN2:SAPMV56A:1025/btn*RV56A-ICON_STDIS");
        public GuiButton btnLoadStart => _frameWindow.FindById<GuiButton>("usr/tabsHEADER_TABSTRIP2/tabpTABS_OV_DE/ssubG_HEADER_SUBSCREEN2:SAPMV56A:1025/btn*RV56A-ICON_STLBG");
        public GuiButton btnLoadEnd => _frameWindow.FindById<GuiButton>("usr/tabsHEADER_TABSTRIP2/tabpTABS_OV_DE/ssubG_HEADER_SUBSCREEN2:SAPMV56A:1025/btn*RV56A-ICON_STLAD");
        public GuiButton btnShipmentStart => _frameWindow.FindById<GuiButton>("usr/tabsHEADER_TABSTRIP2/tabpTABS_OV_DE/ssubG_HEADER_SUBSCREEN2:SAPMV56A:1025/btn*RV56A-ICON_STTBG");
        public GuiButton btnSave => _frameWindow.FindById<GuiButton>("tbar[0]/btn[11]");
        public SAPTrunckingODC(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;

        }

        public void ChangeShipment()
        {
            Thread.Sleep(5000);
            SAPHandlers.Instance.SelectMenuItem(changeMenu);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);

            SAPHandlers.Instance.ClickButton(btnPlan);
            Thread.Sleep(3000);
            SAPHandlers.Instance.ClickButton(btnLoadStart);
            Thread.Sleep(3000);
            SAPHandlers.Instance.ClickButton(btnLoadEnd);
            Thread.Sleep(3000);
            SAPHandlers.Instance.ClickButton(btnShipmentStart);
            Thread.Sleep(3000);
            SAPHandlers.Instance.ClickButton(btnSave);

            Thread.Sleep(3000);
            string statusMsg = SAPHandlers.Instance.GetStatusBarMessage(_session);

            if (!statusMsg.Contains("Shipment") && !statusMsg.Contains("has been saved"))
            {
                Assert.Fail("Shipment start failed");
            }
        }
    }
}
