using NUnit.Framework;
using sapfewse;
using System.Collections.Generic;
using TAF_SAP;
using System;
using System.Threading;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPPOSWorkbench
    {
        //public const string
        //transSuccess = "@5B\\QAll Tasks Processed Successfully@",
        //transFail = "@5C\\QTasks with Errors Exist@";
                
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;
        
        public GuiTabStrip tbPOSTransc => _frameWindow.FindById<GuiTabStrip>("usr/tabsTABSTRIP_WB_TAB2");
        public GuiCTextField ctxtDate => _frameWindow.FindById<GuiCTextField>("usr/tabsTABSTRIP_WB_TAB2/tabpUCOMM21/ssub%_SUBSCREEN_WB_TAB2:/POSDW/SAPLMONITOR_SEL:0301/ctxtSO_DATE-LOW");
        public GuiTextField txtWorkStation => _frameWindow.FindById<GuiTextField>("usr/tabsTABSTRIP_WB_TAB2/tabpUCOMM22/ssub%_SUBSCREEN_WB_TAB2:/POSDW/SAPLMONITOR_SEL:0302/txtSO_WID-LOW");
        public GuiTextField txtTrancNumber => _frameWindow.FindById<GuiTextField>("usr/tabsTABSTRIP_WB_TAB2/tabpUCOMM22/ssub%_SUBSCREEN_WB_TAB2:/POSDW/SAPLMONITOR_SEL:0302/txtSO_TRNR-LOW");
        private GuiButton btnExec => _frameWindow.FindById<GuiButton>("tbar[1]/btn[8]");
        private GuiGridView gvOverview => _frameWindow.FindById<GuiGridView>("usr/cntlMAIN_CONTAINER/shellcont/shell/shellcont[1]/shell/shellcont[2]/shell");
        public GuiGridView gvTransactionData => _frameWindow.FindById<GuiGridView>("usr/cntlGRID1/shellcont/shell/shellcont[1]/shell");
        private GuiGridView statusview => _frameWindow.FindById<GuiGridView>("usr/cntlMAIN_CONTAINER/shellcont/shell/shellcont[1]/shell/shellcont[2]/shell");
        //usr/cntlMAIN_CONTAINER/shellcont/shell/shellcont[1]/shell/shellcont[2]/shell
        public SAPPOSWorkbench(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }

        public void onPOSWBScreen()
        {
            if (tbPOSTransc == null)
                _session.GotoTransaction("/n/posdw/mon0");
        }

        public String GetBusinessDate(string value)
        {
            String businessDate = value.Remove(10);
            String year = businessDate.Substring(0, 4);
            String month = businessDate.Substring(5, 2);
            String day = businessDate.Substring(8, 2);
            businessDate = day + "." + month + "." + year;
            return businessDate;
        }

        public void ShowTransactionDetails(Dictionary<string, string> trancData)
        {
            onPOSWBScreen();
            
            string bdate = GetBusinessDate(trancData["BUSINESSDAYDATE"]);
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDate, bdate);
            SAPHandlers.Instance.SelectTab(tbPOSTransc, 2);
            SAPHandlers.Instance.EnterTextInGuiTextField(txtWorkStation, trancData["WORKSTATIONID"]);
            SAPHandlers.Instance.EnterTextInGuiTextField(txtTrancNumber, trancData["TRANSNUMBER"]);
            SAPHandlers.Instance.ClickButton(btnExec);
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
           
            //int status = SAPHandlers.Instance.GridGetRowCount(statusview);
            int status = statusview.RowCount;
            String trancValue = null;
            SAPHandlers.Instance.ClickGridField(statusview, 0, "Status");
            
                trancValue = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(statusview, 0, "Status");
                System.Console.WriteLine(trancValue);
            if(trancValue.Contains("Tasks Processed Successfully"))
            {
                System.Console.WriteLine("Test passed");
            }
            else
            {
                System.Console.WriteLine("Test Failed");
            }
                //if (trancValue != null)
                //{
                //    statusview.SetCurrentCell(0, "Transaction Status");
                //    statusview.DoubleClickCurrentCell();
                //}
                //else
                //{
                //    System.Console.WriteLine("The table valule is empty");
                //}

            
            
            //System.Console.WriteLine(trancValue);

        }

        
    }
}
