using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class SAPMonitorScreenCommon
    {
        static GuiFrameWindow _frameWindow;
        static GuiSession _session;

        private SAPMonitorScreenProcess monScreen = null;
        public SAPMonitorScreenCommon(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;

            monScreen = new SAPMonitorScreenProcess(_session, _frameWindow);
        }

        public void OnMonitorScreen_ShowWareHouseDetails(string DocNo)
        {
            monScreen.onMonitorScreen();
            monScreen.OpenOutboundDeliveryOrder();
            monScreen.SwitchWindow(_session, 1);
            monScreen.SetDeliveryOrder(DocNo);
            monScreen.SwitchWindow(_session, 0);
            monScreen.ShowWareHouseTaskDetails();
        }

       
        public string GetSourceHUNumber(string DocNo)
        {                      
            OnMonitorScreen_ShowWareHouseDetails(DocNo);
            string SourceHU = monScreen.WTGetSingleData("Source HU");
            return SourceHU;
        }

        public string GetWhseOrdeNumber(string DocNo)
        {
            OnMonitorScreen_ShowWareHouseDetails(DocNo);
            string WhseOrdeNumber = monScreen.WTGetSingleData("Whse Order");
            return WhseOrdeNumber;
        }

        public void ConfirmWTinBgrd(string DocNo)
        {
            OnMonitorScreen_ShowWareHouseDetails(DocNo);
            monScreen.SelectColumnTo_FilterGrid("Type");
            monScreen.SwitchWindow(_session, 1);
            monScreen.FilterGridWithCondition("9070");
            monScreen.SwitchWindow(_session, 0);
            monScreen.selectAllRowsInGrid();
            monScreen.ConfirmWTinBgrd();
            monScreen.SwitchWindow(_session, 1);
            monScreen.clickDisplaylogsOkButton();
            monScreen.SwitchWindow(_session, 0);

        }

        public void ReleaseResource(String resourceID)
        {
            SearchResource(resourceID);
            monScreen.LogOffResource();
        }

        public void SearchResource(String resourceID)
        {
            _session.GotoTransaction("/N/SCWM/MON");

            monScreen.OpenResourceMgmt();
            monScreen.SwitchWindow(_session, 1);
            monScreen.SetResource(resourceID);
            monScreen.SwitchWindow(_session, 0);

        }

        public void ChangeQueue(String resourceID)
        {
            SearchResource(resourceID);
            monScreen.ChangeQueue();
            monScreen.SwitchWindow(_session, 1);
            monScreen.ActionChangeQueue(resourceID);
            monScreen.SwitchWindow(_session, 0); 
        }

       
    }
}
