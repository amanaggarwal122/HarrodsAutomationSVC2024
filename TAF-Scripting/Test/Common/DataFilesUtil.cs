using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility;
using TAF_GenericUtility.Scripted.dataload;
using TAF_GenericUtility.Scripted.DataWrite;
using TAF_GenericUtility.Scripted.Generic;

namespace TAF_Scripting.Test.Common
{
   public class DataFilesUtil
    {
        public static Dictionary<String, Dictionary<String, String>> GetAllData(string excelFileName, string sheetName)
        { 
            string dataFileName = GetExcelLocation(excelFileName);

            ExcelConnector con = new ExcelConnector(dataFileName, sheetName);
            TestDataFactory test = new TestDataFactory();
            TestDataObject obj = test.GetData(string.Empty, con);


            return obj.getTableData();
        }

       
        public static Dictionary<String, Dictionary<String, String>> GetDataForKey(string excelFileName, string sheetName, string uniquekey)
        {
            string dataFileName = GetExcelLocation(excelFileName);

            ExcelConnector con = new ExcelConnector(dataFileName, sheetName);
            TestDataFactory test = new TestDataFactory();
            TestDataObject obj = test.GetData(string.Empty, con, uniquekey);



            //var tablevalues = tabledata.SelectMany(x => x.Value); ;

            return obj.getTableData();
        }
        public static void  SaveDataToExcel(string excelFileName, string sheetName, string columnHeader, string rowValue, string inputValue,int ColumnNo=0)
        {
            ExcelDataWrite objExcelDataWrite = new ExcelDataWrite();
            string dataFileName = GetExcelLocation(excelFileName);
            objExcelDataWrite.WriteToExcel(dataFileName,  sheetName,  columnHeader,  rowValue,  inputValue, ColumnNo);

        }

        public static void SaveMultipleDataToExcel(string excelFileName, string sheetName,  bool templateWithColumnHeader, Dictionary<int, List<string>> exceldata, bool ExistingFile = false)
        {
            ExcelDataWrite objExcelDataWrite = new ExcelDataWrite();
            string dataFileName = GetExcelLocation(excelFileName);
            objExcelDataWrite.WriteToExcel(dataFileName, sheetName, dataFileName, templateWithColumnHeader, exceldata, ExistingFile);
           // (string templateFile, string sheetName, string outputFile, bool templateWithColumnHeader, Dictionary<int, List<string>> exceldata, bool ExistingFile = false)
        }


        public static Dictionary<String, Dictionary<String, String>> GetAllData(string excelFileName, string sheetName, string key)
        {
            string dataFileName = GetExcelLocation(excelFileName);

            ExcelConnector con = new ExcelConnector(dataFileName, sheetName);
            TestDataFactory test = new TestDataFactory();
            TestDataObject obj = test.GetData(key, con);
            return obj.getTableData();
        }

        public static Dictionary<String, String> GetDataRow(string ExcelFileName, string sheetName, string uniquekey="",int row = 1)
        {
            //if (key != null)
            //if (key != null)
            //{
            //   
            ////}
            //Dictionary<string, string> values = { "TC_ID", key };
            //Dictionary<string, string> values = GetAllData(ExcelFileName, sheetName).Values.ToDictionary(t => t.ToString(), t => t);

            //string fileName = GetConfigLocation(ExcelFileName);
            //string excel = ConfigDriver.GetPropertyValue(ExcelFileName, "excelName");
            
            //var myKey = tabledata.FirstOrDefault(x => x.Value == "one").Key;
       
            return GetAllData(ExcelFileName, sheetName)[row.ToString()];
            
        }

        public static Dictionary<String, String> GetDataRowWithUniqueKey(string ExcelFileName, string sheetName, string uniquekey = "", string uniquevalue="",int row = 1)
        {
            Dictionary<String, string> tabledata= new Dictionary<string, string>();

            if (uniquekey != null)
                 tabledata = GetDataForKey(ExcelFileName, sheetName, uniquekey)[uniquevalue];

            return tabledata;
        }
        public static Dictionary<String, String> GetCellValue(string ExcelFileName, string sheetName, string key, int row = 1)
        {
            //string fileName = GetConfigLocation(configFileName);
            //string excel = ConfigDriver.GetPropertyValue(ExcelFileName, "excelName");
            return GetAllData(ExcelFileName, sheetName, key)[row.ToString()];
        }

        public static string GetExcelLocation(string excelFileName)
        {
            if (string.IsNullOrEmpty(excelFileName))
            {
                throw new Exception("No data file specified");
            }

            return PathUtil.Combine(PathUtil.BasePath(), $"Resources/DataFiles/{excelFileName}.xlsx");
        }
        
       
    }
}
