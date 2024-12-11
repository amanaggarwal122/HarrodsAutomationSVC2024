using System;
using System.Collections.Generic;
using System.Text;

namespace TAF_GenericUtility.Scripted.dataload
{
    public class TestDataFactory
    {
        ExcelDriver excelDriver;
        ExcelConnector exclConn;

        public TestDataObject GetData(String key, ExcelConnector exclConn, string uniquekey=null)
        {
            this.exclConn = exclConn;
            String fileName = exclConn.getFileName();
         
            TestDataObject excelData = new TestDataObject();
        
            String sheetName = exclConn.getSheetName();
            excelDriver = new ExcelDriver(fileName, sheetName);
            //if (sheetName != null || sheetName != "")
            //{
            //    excelDriver.goToSheet(sheetName);
               
            //}
           int maxRowCount = exclConn.getMaxRows();
            //int maxRowCount = 1;//Ajay modified
            if (uniquekey != null)
                excelData = GetDataWithKey(excelData, excelDriver, maxRowCount, uniquekey);
            else
                excelData = setSheetData(excelData, excelDriver, maxRowCount);
            return excelData;
        }
        private TestDataObject setSheetData(TestDataObject excelData, ExcelDriver excelDriver, int maxRowCount)
        {
            int rowCount;
            bool hasHeader = exclConn.isHasHeader();
            rowCount = excelDriver.getRowCount();
            if ((maxRowCount >= 0) && (maxRowCount < rowCount))
            {
                rowCount = maxRowCount;
                if (hasHeader == true)
                {
                    rowCount++;
                }
            }

            Dictionary<String, Dictionary<String, String>> rowData = new Dictionary<String, Dictionary<String, String>>();
            
            int intitalRowIndex;
            if (hasHeader == true)
            {
                intitalRowIndex = 1;
            }
            else
            {
                intitalRowIndex = 0;
            }
            for (int rowCounter = intitalRowIndex; rowCounter < rowCount; rowCounter++)
            {
                rowData[rowCounter.ToString()] = excelDriver.getRowMap(rowCounter, hasHeader);
               
            }

            excelData.setTableData(rowData);
            excelDriver.CloseWorkbook();
            return excelData;
        }

        private TestDataObject GetDataWithKey(TestDataObject excelData, ExcelDriver excelDriver, int maxRowCount, string key="TC_ID")
        {
            int rowCount;
            bool hasHeader = exclConn.isHasHeader();
            rowCount = excelDriver.getRowCount();
            if ((maxRowCount >= 0) && (maxRowCount < rowCount))
            {
                rowCount = maxRowCount;
                if (hasHeader == true)
                {
                    rowCount++;
                }
            }

            Dictionary<String, Dictionary<String, String>> rowData = new Dictionary<String, Dictionary<String, String>>();

            int intitalRowIndex;
            if (hasHeader == true)
            {
                intitalRowIndex = 1;
            }
            else
            {
                intitalRowIndex = 0;
            }
            for (int rowCounter = intitalRowIndex; rowCounter < rowCount; rowCounter++)
            {
               
                Dictionary<string,string> RowDataForIndex=excelDriver.getRowMap(rowCounter, hasHeader);
                rowData[RowDataForIndex[key]] = RowDataForIndex;
            }

            excelData.setTableData(rowData);
            excelDriver.CloseWorkbook();
            return excelData;
        }
    }
}
