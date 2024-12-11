using NUnit.Framework;
using sapfewse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TAF_SAP;


namespace TAF_Scripting.Test.Scripted.PageObjects.SAP
{
    class SAPCARTransTable
    {
        static GuiSession _session;
        static GuiFrameWindow _frameWindow;

        public GuiRadioButton rbtnDBTable => _frameWindow.FindById<GuiRadioButton>("usr/radRSRD1-TBMA");
        private GuiCTextField ctxtDBTable => _frameWindow.FindById<GuiCTextField>("usr/ctxtRSRD1-TBMA_VAL");
        private GuiButton btnShow => _frameWindow.FindById<GuiButton>("usr/btnPUSHSHOW");
        private GuiButton btnQuery => _frameWindow.FindById<GuiButton>("tbar[1]/btn[46]");
        private int indicator = 0;


        /*Data Browser: Table /POSDW/TLOGF: Selection Screen*/
        private GuiCTextField ctxtBusinessDate => _frameWindow.FindById<GuiCTextField>("usr/ctxtI2-LOW");
        private GuiTextField txtWorkStationID => _frameWindow.FindById<GuiTextField>("usr/txtI7-LOW");
        private GuiTextField txtTransNumber => _frameWindow.FindById<GuiTextField>("usr/txtI8-LOW");
        private GuiButton btnExec => _frameWindow.FindById<GuiButton>("tbar[1]/btn[8]");

        public GuiGridView gvTransactionData => _frameWindow.FindById<GuiGridView>("usr/cntlGRID1/shellcont/shell/shellcont[1]/shell");
        public GuiGridView gvTransactionDetails => _frameWindow.FindById<GuiGridView>("usr/cntlGRID/shellcont/shell");
        private GuiButton btnOk => _frameWindow.FindById<GuiButton>("tbar[0]/btn[0]");

        private List<string> QualifierList = new List<string> { "1", "4", "5", "13", "11", "21" };


        public SAPCARTransTable(GuiSession session, GuiFrameWindow frameWindow)
        {
            _frameWindow = frameWindow;
            _session = session;
        }

        public SAPCARTransTable()
        {

        }

        public void onABAPDictionaryScreen()
        {
            if (rbtnDBTable == null)
                _session.GotoTransaction("SE11");
        }
        public void SelectTransactionTable(string tableName)
        {
            rbtnDBTable.Select();
            SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtDBTable, tableName);
            SAPHandlers.Instance.ClickButton(btnShow);
            Thread.Sleep(1000);
            SAPHandlers.Instance.ClickButton(btnQuery);
        }

        public void QueryTable(Dictionary<string, string> trancData)
        {
            string bdate = null;
            if (!string.IsNullOrEmpty(trancData["BUSINESSDAYDATE"]))
                bdate = GetBusinessDate(trancData["BUSINESSDAYDATE"]);
                SAPHandlers.Instance.EnterTextInGuiCTextField(ctxtBusinessDate, bdate);
            if (!string.IsNullOrEmpty(trancData["WORKSTATIONID"]))
                SAPHandlers.Instance.EnterTextInGuiTextField(txtWorkStationID, trancData["WORKSTATIONID"]);
            if (!string.IsNullOrEmpty(trancData["TRANSNUMBER"]))
                SAPHandlers.Instance.EnterTextInGuiTextField(txtTransNumber, trancData["TRANSNUMBER"]);
            SAPHandlers.Instance.ClickButton(btnExec);
        }

        public bool CheckTheDataviewISINGrid()
        {
            if (gvTransactionData == null)
                return true;
            else
                return false;
        }
        public void GetTheTransDetails(Dictionary<string, string> rowTrancData)
        {
            if (gvTransactionData != null)
            {
                // int rowCnt = SAPHandlers.Instance.GridGetRowCount(gvTransactionData);
                int rowCnt = gvTransactionData.RowCount;
                int columnDataCount = rowTrancData.Count;

                for (int i = 0; i < rowCnt; i++)
                {
                    if (columnDataCount > 0)
                    {
                        int matchedValues = 0;
                        string firstKey = string.Empty;
                        foreach (KeyValuePair<string, string> kv in rowTrancData)
                        {
                            string key = kv.Key;
                            string value = kv.Value;
                            if (string.IsNullOrEmpty(firstKey))
                                firstKey = key;

                            string trancValue = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gvTransactionData, i, key);
                            if (trancValue != value)
                                break;
                            else
                                matchedValues++;
                        }
                        if (matchedValues == columnDataCount)
                        {
                            indicator = 1;
                            // gvTransactionData.SelectedRows = i.ToString();
                            gvTransactionData.SetCurrentCell(i, firstKey);
                            gvTransactionData.DoubleClickCurrentCell();
                            break;
                        }
                    }
                }
            }
        }



        public void ValidateTrancDetails(Dictionary<string, string> rowTrancData)
        {
            if (indicator == 1)
            {
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
                foreach (KeyValuePair<string, string> kv in rowTrancData)
                {
                    string key = kv.Key;
                    string value = kv.Value;
                    // int rowCnt = SAPHandlers.Instance.GridGetRowCount(gvTransactionDetails);
                    int rowCnt = gvTransactionDetails.RowCount;
                    Console.WriteLine("Entered the rowcount");

                    for (int i = 0; i < rowCnt; i++)
                    {
                        string trancFieldName = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gvTransactionDetails, i, "Group description");
                        if (trancFieldName == key)
                        {
                            if (trancFieldName == "TURNOVER")
                            {
                                string turnover = SAPHandlers.Instance.GetGridviewTextByRowColumn(gvTransactionDetails, i, 1);
                                Console.WriteLine(turnover);
                                string finalturnover = RemoveDecimalPoint(turnover);
                                Console.WriteLine("Turnover Value from POS " + value);
                                Console.WriteLine("Turnover Value after removing decimal from SAP " + finalturnover);
                                if (finalturnover != value)
                                {
                                    //Assert.Fail($"The given value of {key} {value} doesnt match with transaction value {finalturnover}");
                                    Console.WriteLine("The given value of " + key + " & " + value + " doesnt match with transaction value " + finalturnover);
                                }
                                else
                                {
                                    Console.WriteLine("Validation id done");
                                    System.Console.WriteLine(key + " --> Key");
                                    System.Console.WriteLine(value + " --> Value");
                                    //Assert.Pass($"The given value of {key} {value} matches with transaction value{trancFieldValue}");
                                    System.Console.WriteLine("The given value of " + key + " & " + value + " matches with transaction value " + finalturnover);
                                    break;
                                }
                            }
                            if (trancFieldName.Equals("TRANSNUMBER") || trancFieldName.Equals("WORKSTATIONID") || trancFieldName.Equals("ITEMID"))
                            {
                                string trancFieldValue_1 = SAPHandlers.Instance.GetGridviewTextByRowColumn(gvTransactionDetails, i, 1);
                                if (trancFieldValue_1 != "")
                                {
                                    int SAP_Value = StringToIntConversion(value);
                                    int POS_Value = StringToIntConversion(trancFieldValue_1);
                                    if (POS_Value != SAP_Value) 

                                    {
                                        Assert.Fail($"The given value of {key} {value} doesnt match with transaction value{SAP_Value}");
                                    }
                                    else
                                    {
                                        System.Console.WriteLine(key + " --> Key");
                                        System.Console.WriteLine(value + " --> Value");
                                        //Assert.Pass($"The given value of {key} {value} matches with transaction value{trancFieldValue}");
                                        System.Console.WriteLine("The given value of " + key + " & " + value + " matches with transaction value " + SAP_Value);
                                        break;
                                    }
                                }
                                else
                                {
                                    System.Console.WriteLine(key + " --> value is empty");
                                }
                            }

                            string trancFieldValue = SAPHandlers.Instance.GetGridviewTextByRowColumn(gvTransactionDetails, i, 1);
                            if (!trancFieldValue.Equals(value))

                            {
                                //Assert.Fail($"The given value of {key} {value} doesnt match with transaction value{trancFieldValue}");
                                System.Console.WriteLine("The given value of " + key + " & " + value + " doesnt match with transaction value" + trancFieldValue);
                            }
                            else
                            {
                                System.Console.WriteLine(key + " --> Key");
                                System.Console.WriteLine(value + " --> Value");
                                //Assert.Pass($"The given value of {key} {value} matches with transaction value{trancFieldValue}");
                                System.Console.WriteLine("The given value of " + key + " & " + value + " matches with transaction value " + trancFieldValue);
                                break;
                            }
                        }
                    }
                }
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
                SAPHandlers.Instance.ClickButton(btnOk);
            }
            else
            {

                System.Console.WriteLine("The Qualifier is not found in the Transactiondetailstable");
            }
        }

        public Dictionary<string, string> FetchdatafromTrancTables(Dictionary<string, string> EntireList, Dictionary<string, string> transDataheader)
        {
            int listcount = EntireList.Count;
            GetTheTransDetails(transDataheader);
            _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 1);
            if (indicator == 1)
            {
                if (gvTransactionDetails != null)
                {
                    for (int i = 0; i < listcount; i++)
                    {
                        string key = EntireList.ElementAt(i).Key;
                        int rowCnt = gvTransactionDetails.RowCount;


                        for (int j = 1; j < rowCnt; j++)
                        {
                            if (key != "TC_ID")
                            {
                                {
                                    string trancFieldName = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gvTransactionDetails, j, "Group description");

                                    if (trancFieldName == key)
                                    {
                                        string trancfieldvalue = SAPHandlers.Instance.GetGridviewTextByRowColumn(gvTransactionDetails, j, 1);
                                        if (trancfieldvalue != "")
                                        {
                                            //if (EntireList.ElementAt(i).Value == null)
                                            //{
                                                EntireList[key] = trancfieldvalue;
                                                //EntireList.Add(key, trancfieldvalue);

                                           // }
                                        }
                                        break;
                                    }
                                }

                            }
                        }
                    }

                }
                _frameWindow = SAPHandlers.Instance.GetWindowByIndex(_session, 0);
                SAPHandlers.Instance.ClickButton(btnOk);
            }
            else
            {
                System.Console.WriteLine("The transaction details table is not present");
            }
            
            return EntireList;
        }


        public Boolean ClickOnRecordQualifier(string recordqualifier)
        {
            Boolean status = false;
            string trancValue = "";
            if (gvTransactionData != null)
            {
                //int rowCnt = SAPHandlers.Instance.GridGetRowCount(gvTransactionData);
                int rowCnt = gvTransactionData.RowCount;
                for (int i = 0; i < rowCnt; i++)
                {
                    trancValue = SAPHandlers.Instance.GetGridviewTextByRowColumnHeader(gvTransactionData, i, "RECORDQUALIFIER");

                    if (trancValue == recordqualifier)
                    {
                        // gvTransactionData.SelectedRows = i.ToString();
                        gvTransactionData.SetCurrentCell(i, "RECORDQUALIFIER");
                        gvTransactionData.DoubleClickCurrentCell();
                        status = true;
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("The Qualifier is not available for this transaction");

                    }
                }
            }
            return status;

        }
        public string RemoveDecimalPoint(string value)
        {
            string[] newvalue = value.Split('.');
            string finalvalue = newvalue[0] + newvalue[1];
            Console.WriteLine(finalvalue);
            return finalvalue;
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
        public int StringToIntConversion(string Commonvalue)
        {
            int finalIntValue = Convert.ToInt32(Commonvalue);
            return finalIntValue;
        }
    }
}

