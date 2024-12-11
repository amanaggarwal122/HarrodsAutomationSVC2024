using sapfewse;
using NUnit.Framework;
using System.Threading;
using TAF_SAP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_Scripting.Test.Common;

namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    public class RecordQualifiers
    {
        private SAPCARTransTable sapCARTransTable;
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;
         
        Dictionary<string, string> transData = new Dictionary<string, string>();
        Dictionary<string, string> Entireparameterdict = new Dictionary<string, string>();
        private GuiCTextField ctxtHeaderQualifier => _frameWindow.FindById<GuiCTextField>("usr/lbl[74,5]");
        private static GuiCTextField ctxtTranstypecode => _frameWindow.FindById<GuiCTextField>("usr/ctxt/POSDW/TLOGF-TRANSTYPECODE");
       // String Transtypecode = ctxtTranstypecode.Text;
        private static GuiCTextField ctxtBusinessDayDate => _frameWindow.FindById<GuiCTextField>("usr/ctxt/POSDW/TLOGF-BUSINESSDAYDATE");
       // String BDate = ctxtBusinessDayDate.Text;
        private static GuiCTextField ctxtWorkStationId => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-WORKSTATIONID");
       // String WorkId = ctxtWorkStationId.Text;
        private static GuiCTextField ctxtTransNumber => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-TRANSNUMBER");
       // String Transnum = ctxtTransNumber.Text;
        private static GuiCTextField ctxtBeginTimeStamp => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-BEGINTIMESTAMP");
       // String BeginStamp = ctxtBeginTimeStamp.Text;
        private static GuiCTextField ctxtEndTimeStamp => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-ENDTIMESTAMP");
       // String EndStamp = ctxtEndTimeStamp.Text;
        private static GuiCTextField ctxtTurnover => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-TURNOVER");
      //  String Turnover = ctxtTurnover.Text;
        private static GuiCTextField ctxtDiscTypeCode => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-DISCTYPECODE");
       // String DTypeCode = ctxtDiscTypeCode.Text;
        private static GuiCTextField ctxtReductionAmount => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-REDUCTIONAMOUNT");
      //  String ReductionAmount = ctxtReductionAmount.Text;
        private static GuiCTextField ctxtDiscId => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-DISCIDusr/txt/POSDW/TLOGF-DISCID");
       // String DiscId = ctxtDiscId.Text;
        private static GuiCTextField ctxtTenderTypeCode => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-TENDERTYPECODE");
      //  String TTypeCode = ctxtTenderTypeCode.Text;
        private static GuiCTextField ctxtTenderAmount => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-TENDERAMOUNT");
       // String TAmount = ctxtTenderAmount.Text;
        private static GuiCTextField ctxtTenderId => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-TENDERID");
      //  String TId = ctxtTenderId.Text;
        private static GuiCTextField ctxtTenderCurrency => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-TENDERCURRENCY");
     //   String TCurrency = ctxtTenderCurrency.Text;
        private static GuiCTextField ctxtReferenceId => _frameWindow.FindById<GuiCTextField>("usr/txt/POSDW/TLOGF-REFERENCEID");
     //   String RefId = ctxtReferenceId.Text;
        public RecordQualifiers(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }
        
        public void HeaderData(Dictionary<string, string> TCDataDictionary,string recordqualifier, string transtypecode)
        {
            Dictionary<string, string> transDataheader = new Dictionary<string, string>();
            transDataheader.Add("RECORDQUALIFIER", recordqualifier);
            transDataheader.Add("TRANSTYPECODE", transtypecode);

            sapCARTransTable = new SAPCARTransTable(_session, _frameWindow);
             sapCARTransTable.GetTheTransDetails(transDataheader);
            

            sapCARTransTable.ValidateTrancDetails(TCDataDictionary);
        }

        public Dictionary<string, string> FetchData(Dictionary<string, string> EntireList, string recordqualifier, string transtypecode)
        {
            Dictionary<string, string> transDataheader = new Dictionary<string, string>();
            transDataheader.Add("RECORDQUALIFIER", recordqualifier);
            transDataheader.Add("TRANSTYPECODE", transtypecode);

            sapCARTransTable = new SAPCARTransTable(_session, _frameWindow);
            //sapCARTransTable.GetTheTransDetails(transDataheader);
            Entireparameterdict = sapCARTransTable.FetchdatafromTrancTables(EntireList, transDataheader);

            //sapCARTransTable.ValidateTrancDetails(TCDataDictionary);
            return Entireparameterdict;
        }




        public void ConvertStringToInteger(string value)
        {
        string POS_TransNo = "320";
       // string SAP_TransNo = "000000000000000320";
         String Transnum = ctxtTransNumber.Text;

        int POS_TransNum = Convert.ToInt32(POS_TransNo);
        int SAP_TransNum = Convert.ToInt32(Transnum);
            //int SAP_TransNum = Convert.ToInt32(SAP_TransNo);
            //Console.WriteLine(POS_TransNo);
            //Console.WriteLine(SAP_TransNo);
            //Console.WriteLine(POS_TransNum);
            //Console.WriteLine(POS_TransNum);
            if (POS_TransNum == SAP_TransNum)
            {

            }                 
            }
        public void CustomerDetails()
        {
            //Dictionary<string, string> transData = new Dictionary<string, string>();
            transData.Add("RECORDQUALIFIER", "4");  
            transData.Add("TRANSTYPECODE", "1003/1001");

            sapCARTransTable.GetTheTransDetails(transData);

            Dictionary<string, string> transDataCust = new Dictionary<string, string>();
            transDataCust.Add("FEILDGROUP", "0000005003");
            transDataCust.Add("FIELDNAME", "00000000000000000229");
            transDataCust.Add("FEILDVALUE", "25.00");
            sapCARTransTable.ValidateTrancDetails(transDataCust);
        }
        public void ItemDetails()
        {
            //Dictionary<string, string> transData = new Dictionary<string, string>();
            transData.Add("RECORDQUALIFIER", "5");
            transData.Add("TRANSTYPECODE", "1003/1001");

            sapCARTransTable.GetTheTransDetails(transData);

            Dictionary<string, string> transDataItem = new Dictionary<string, string>();
            transDataItem.Add("RETAILTYPECODE", "0000005003");
            transDataItem.Add("ITEMID", "00000000000000000229");
            transDataItem.Add("RETAILQUANTITY", "25.00");
            transDataItem.Add("SALESAMOUNT", "000000000002643178");
            transDataItem.Add("NORMALSALESAMT", "000000000002643178");
            transDataItem.Add("ACTUALUNITPRICE", "000000000002643178");
            transDataItem.Add("ZZWALKEDSITE", "000000000002643178");
            sapCARTransTable.ValidateTrancDetails(transDataItem);
        } 	

        public void TaxDetails()
        {
            //Dictionary<string, string> transData = new Dictionary<string, string>();
            transData.Add("RECORDQUALIFIER", "13");
            //check whether transtypecode is 1003 or 1001
            transData.Add("TRANSTYPECODE", "1003/1001");

            sapCARTransTable.GetTheTransDetails(transData);


            Dictionary<string, string> transDataTax = new Dictionary<string, string>();
            transDataTax.Add("TAXNUMBER", "0000005003");
            transDataTax.Add("TAXTYPECODE", "00000000000000000229");
            transDataTax.Add("TAXAMOUNT", "25.00");
            //transDataTax.Add("TAXINCLUDEDFLAG", "000000000002643178");
            sapCARTransTable.ValidateTrancDetails(transDataTax);
        } 

        public void DiscountDetails()
        {
            //Dictionary<string, string> transData = new Dictionary<string, string>();
            transData.Add("RECORDQUALIFIER", "11");
            //check whether transtypecode is 1003 or 1001
            transData.Add("TRANSTYPECODE", "1003/1001");

            sapCARTransTable.GetTheTransDetails(transData);


            Dictionary<string, string> transDataDisc = new Dictionary<string, string>();
            //transDataDisc.Add("DISCNUMBER", "0000005003");
            transDataDisc.Add("DISCTYPECODE", "00000000000000000229");
            //transDataDisc.Add("DISCREASONCODE", "25.00");
            transDataDisc.Add("REDUCTIONAMOUNT", "000000000002643178");
            //transDataDisc.Add("DISCACCOUNT", "000000000002643178");
            //transDataDisc.Add("DISCIDQUALIFIER", "000000000002643178");
            transDataDisc.Add("DISCID", "000000000002643178");
            sapCARTransTable.ValidateTrancDetails(transDataDisc);
        }


        public void TenderDetails()
        {
            //Dictionary<string, string> transData = new Dictionary<string, string>();
            transData.Add("RECORDQUALIFIER", "11");
            //check whether transtypecode is 1003 or 1001
            transData.Add("TRANSTYPECODE", "1003/1001");

            sapCARTransTable.GetTheTransDetails(transData);


            Dictionary<string, string> transDataTender = new Dictionary<string, string>();
            //transDataTender.Add("TENDERNUMBER", "0000005003");
            transDataTender.Add("TENDERTYPECODE", "00000000000000000229");
            transDataTender.Add("TENDERAMOUNT", "25.00");
            transDataTender.Add("TENDERCURRENCY", "000000000002643178");
            transDataTender.Add("TENDERID", "000000000002643178");
            //transDataTender.Add("ACCOUNTNUMBER", "000000000002643178");
            transDataTender.Add("REFERENCEID", "000000000002643178");
            sapCARTransTable.ValidateTrancDetails(transDataTender);
        }
    }
}

