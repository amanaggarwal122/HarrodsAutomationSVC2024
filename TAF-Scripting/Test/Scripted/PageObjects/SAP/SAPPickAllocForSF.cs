using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_SAP;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPPickAllocForSF
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;
       
        public GuiCTextField ctxtDelivery => _frameWindow.FindById<GuiCTextField>("usr/ctxtS_VBELN-LOW");

        public GuiCTextField ctxtDate=> _frameWindow.FindById<GuiCTextField>("usr/ctxtS_BLDAT-LOW");
        public GuiButton execBtn => _frameWindow.FindById<GuiButton>("tbar[1]/btn[8]");
        public GuiCTextField ctxtDeliveryCreationDate => _frameWindow.FindById<GuiCTextField>("usr/ctxtS_BDATU-LOW");
        public GuiCTextField ctxtSourceStorage => _frameWindow.FindById<GuiCTextField>("usr/ctxtS_VLTYP-LOW");
        public GuiCTextField ctxtWarehouseNo => _frameWindow.FindById<GuiCTextField>("usr/ctxtP_LGNUM");

        public GuiGridView gdAllocSF => _frameWindow.FindById<GuiGridView>("usr/cntlGRID1/shellcont/shell");
        public GuiButton saveBtn => _frameWindow.FindById<GuiButton>("tbar[0]/btn[11]");
        public SAPPickAllocForSF(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
           
        }
        public void OnPickForSFScreen()
        {
            if (ctxtDelivery == null)
                _session.GotoTransaction("/NZSFALLOC");
        }

        public void OnPickingAllocScreen()
        {
            if (ctxtDelivery == null)
                _session.GotoTransaction("/NZWMALLOC");
        }

        public void SwitchWindow(GuiSession guiSession, int windowIndex)
        {
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(guiSession, windowIndex);
        }

        public void PickAlloc(string DeliveryNo,string cDate, string supplysite)
        {

            if(supplysite=="SF")
            { 
            OnPickForSFScreen();
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDelivery, DeliveryNo);
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDate, cDate);
            SAPHandlers.Instance.ClickButton(execBtn);
            }
           else if (supplysite == "DCM1")
            {
                OnPickingAllocScreen();
                SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtWarehouseNo, "008");
                SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtSourceStorage, "*");
                SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDeliveryCreationDate, cDate);
                SAPHandlers.Instance.ClickButton(execBtn);
            }
            else
            {
                OnPickingAllocScreen();
                SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtWarehouseNo, "022");
                SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtSourceStorage, "*");
                SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDeliveryCreationDate, cDate);
                SAPHandlers.Instance.ClickButton(execBtn);
            }
        }

       

        public void AllocUser(string userId ,  string supplysite="SF" , string delivery="")
        {
            int rowCount = SAPHandlers.Instance.GridGetRowCount(gdAllocSF);
            if (supplysite == "SF")
            {                
                for (int i = 0; i < rowCount; i++)
                {
                    SAPHandlers.Instance.EnterTextGridField(gdAllocSF, i, "Userid", userId);
                }
                SAPHandlers.Instance.GridSelectAllRows(gdAllocSF);
                SAPHandlers.Instance.ClickButton(saveBtn);
            }
            else
            {
                for (int i = 0; i < rowCount; i++)
                {
                    string deliveryNo = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gdAllocSF, i, "Delivery");
                    if(!string.IsNullOrEmpty(delivery) && !string.IsNullOrEmpty(deliveryNo) && deliveryNo == delivery)
                        SAPHandlers.Instance.EnterTextGridField(gdAllocSF, i, "Userid", userId);
                }
                SAPHandlers.Instance.GridSelectAllRows(gdAllocSF);
                SAPHandlers.Instance.ClickButton(saveBtn);
            }
            
        }
    }
}
