using NUnit.Framework;
using sapfewse;
using System.Text.RegularExpressions;
using TAF_SAP;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPCreateShipment
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        private GuiComboBox cmbShipmentType => _frameWindow.FindById<GuiComboBox>("usr/cmbVTTK-SHTYP");
        public GuiButton btnSave => _frameWindow.FindById<GuiButton>("tbar[0]/btn[11]");
        public GuiButton btnOption => _frameWindow.FindById<GuiButton>("usr/btnSPOP-OPTION1");
        public GuiLabel lblKB => _frameWindow.FindById<GuiLabel>("usr/lbl[1,4]");
        public SAPCreateShipment(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;

        }

        public void OnCreateShipmentScreen()
        {
            if (cmbShipmentType == null)
                _session.GotoTransaction("/nVT01n");
        }

        public string CreateShipmentNo()
        {
            OnCreateShipmentScreen();
            string shipmentNo= string.Empty;
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F4);

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            SAPHandlers.Instance.SelectLabel(lblKB);
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.F2);
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);


            SAPHandlers.Instance.SelectComboboxItemByKey(cmbShipmentType, "Z001");
            SAPHandlers.SendKeyToGuiFrameWindow(_frameWindow, SAPKeys.Enter);

            SAPHandlers.Instance.ClickButton(btnSave);

            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            SAPHandlers.Instance.ClickButton(btnOption);
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

            string statusMsg = SAPHandlers.Instance.GetStatusBarMessage(_session, 0);
           
            if (statusMsg.Contains("Shipment") && statusMsg.Contains("has been saved"))
            {
                var matches = Regex.Matches(statusMsg, @"\s\d+\s");
                shipmentNo = matches[0].Value.Trim();
            }
            else
            {
                Assert.Fail("Shipment number has not saved");
            }

            return shipmentNo;
        }
    }
}
