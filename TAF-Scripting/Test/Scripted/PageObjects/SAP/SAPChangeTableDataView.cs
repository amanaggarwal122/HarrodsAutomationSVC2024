using sapfewse;
using System.Threading;
using TAF_SAP;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPChangeTableDataView
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiMenu mbarUserParams => _frameWindow.FindById<GuiMenu>("mbar/menu[3]/menu[1]");
        public GuiRadioButton rbtnGridDisplay => _frameWindow.FindById<GuiRadioButton>("usr/tabsG_TABSTRIP/tabp0400/ssubTOOLAREA:SAPLWB_CUSTOMIZING:0400/radRSEUMOD-TBALV_GRID");
        public GuiButton btnOk => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");

        public SAPChangeTableDataView(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }

        public void ChangeViewSettings()
        {
            SAPHandlers.Instance.SelectMenuItem(mbarUserParams);
                       
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            rbtnGridDisplay.Select();          
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);

            SAPHandlers.Instance.ClickButton(btnOk);
        }
    }
}
