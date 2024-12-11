using TAF_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sapfewse;
using NUnit.Framework;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPOrderVerificationPage
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;
        public Boolean deliveryStatus=false;

        private SAPDisplaySalesOrder sapDisplaySalesOrder = null;

        public SAPOrderVerificationPage(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;

            sapDisplaySalesOrder = new SAPDisplaySalesOrder(_session, _frameWindow);
        }

        public string getDeliveryNo(string orderNumber)
        {
            openDocumentFlow(orderNumber);
            string deliveryNumber = sapDisplaySalesOrder.fetchDeliveryNumber();
            
            if (string.IsNullOrEmpty(deliveryNumber))
                Assert.Fail("Delivery Number is not valid");
            return deliveryNumber;
        }

        public string GetDocumentFlowDocs(string orderNumber, string documentName, bool failTestCase = true)
        {
            openDocumentFlow(orderNumber);
            string deliveryNumber = sapDisplaySalesOrder.getDocumentNo(documentName, "Doc.no.", failTestCase);
            return deliveryNumber;
        }

        public void openDocumentFlow(string orderNumber)
        {
           
            
            sapDisplaySalesOrder.selectOrder(orderNumber);
            sapDisplaySalesOrder.SwitchWindow(_session, 1);
            sapDisplaySalesOrder.searchOrder();
            sapDisplaySalesOrder.SwitchWindow(_session, 0);
            sapDisplaySalesOrder.ClickOnDocumentFlow();            
            
        }
        
        public string VerifyDocumentFlowDetails(String Document)
        {
            return sapDisplaySalesOrder.VerifyDocumentFlowDetails(Document);
        }


        
        public void DispatchOrder()
        {


        }

        public Boolean VerifyDocumentStatus(string orderNumber,string Document)
        {
            openDocumentFlow(orderNumber);
            string DocumentStatus = sapDisplaySalesOrder.VerifyDocumentFlowDetails(Document);

            if (string.IsNullOrEmpty(DocumentStatus))
                return false;
            else
                return true;
        }
    }
}
