using System;
using System.IO;
using System.Collections.Generic;


using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace TAF_GenericUtility.Scripted.dataload
{
    public class ExcelDriver
    {
        private ISheet currentSheet = null;
        private IWorkbook currentWorkbook = null;
        private Dictionary<String, int> headerMap = new Dictionary<String, int>();


        /**
         * Constructors based on input parameter type
         * @param filePath - path to the excel file
         */


        public ExcelDriver(IWorkbook Workbook, ISheet Sheet)

        {

            this.currentWorkbook = Workbook;

            this.currentSheet = Sheet;

            setHeaderMap(currentSheet);

        }
        public ExcelDriver(String filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FileInfo excelFile = new FileInfo(filePath);
                if (excelFile.Exists)
                {
                    openSheet(excelFile, 0);
                }
                else
                {
                    Console.WriteLine("File could not be read." + filePath);
                }

            }
            else
            {
                Console.WriteLine("Path is empty.");
            }

            setHeaderMap(currentSheet);
        }

        public ExcelDriver(String filePath,string sheet)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FileInfo excelFile = new FileInfo(filePath);
                if (excelFile.Exists)
                { 
                
                    currentWorkbook = createWorkbook(excelFile);
                    currentSheet = goToSheet(sheet);
                      setHeaderMap(currentSheet);
                }
                else
                {
                    Console.WriteLine("File could not be read." + filePath);
                }

            }
            else
            {
                Console.WriteLine("Path is empty.");
            }

            setHeaderMap(currentSheet);
        }

        /**
	     * Constructors based on input parameter type
	     * @param excelFile - full name of excel file
	     */
        public ExcelDriver(FileInfo excelFile)
        {
            if (null != excelFile && excelFile.Exists)
            {
                excelFile.OpenRead();
            }
            else
            {
                try
                {
                    throw new FileNotFoundException("File Not Found");
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /**
	     * Open a sheet based on excelFile and sheet name
	     * @param excelFile - full name of excel file
	     * @param sheetName - sheet name
	     */
        public void openSheet(FileInfo excelFile, String sheetName)
        {

            currentWorkbook = createWorkbook(excelFile);
            currentSheet = currentWorkbook.GetSheet(sheetName);
            setHeaderMap(currentSheet);
        }

        /**
         * Open a sheet based on excelFile and sheet number
         * @param excelFile - full name of the excel file
         * @param sheetNo - sheet number
         */
        public void openSheet(FileInfo excelFile, int sheetNo)
        {

            currentWorkbook = createWorkbook(excelFile);
            currentSheet = currentWorkbook.GetSheetAt(sheetNo);
            setHeaderMap(currentSheet);
        }

        /**
         *To proceed to a sheet based on sheet number 
         * @param sheetNo - number of the sheet
         */
        public void goToSheet(int sheetNo)
        {

            if ((sheetNo + 1) <= currentWorkbook.NumberOfSheets)
            {
                currentSheet = currentWorkbook.GetSheetAt(sheetNo);
                setHeaderMap(currentSheet);
            }
            else
            {
                Console.WriteLine("Sheet not available");
            }
        }

        /**
         * To proceed to a sheet based on sheet name
         * @param sheetName - name of the sheet
         */
        public ISheet goToSheet(String sheetName)
        {
            try
            {

                currentSheet = currentWorkbook.GetSheet(sheetName);
                setHeaderMap(currentSheet);
            }
            catch (Exception e)
            {

                throw e;
            }

            return currentSheet;
        }

        /**
         * To return the current workbook
         */
        public IWorkbook getCurrentWorkbook()
        {
            return currentWorkbook;
        }

        /**
         * To return the current sheet in the workbook
         */
        public ISheet getCurrentSheet()
        {
            return currentSheet;
        }


        /**
         * To return the current sheet header in a hashmap
         */
        public Dictionary<String, int> getHeaderMap()
        {
            if (headerMap.Count > 0)
            {
                return headerMap;
            }
            else
            {
                Console.WriteLine("No headers in active sheet");
                return headerMap;
            }
        }

        /**
         * To obtain the column header number
         * @param columnName - column name 
         */

        public int getColumnHeaderNo(String columnName)
        {

            int columnNo = -1;

            if (getHeaderMap().Count > 0)
            {

                if (null != getHeaderMap()[columnName].ToString())
                {
                    columnNo = getHeaderMap()[columnName];
                }
            }
            return columnNo;
        }

        /**
         *To obtain a particular cell value based on row and column number 
         * @param row - row number
         * @param column - column number
         */

        public String getCellValueAt(int row, int column)
        {

            IRow currentRow = currentSheet.GetRow(row);
            ICell currentCell = currentRow.GetCell(column);
            String cellValue = "";
            if (currentCell == null)
            {

                cellValue = "";
            }
           else if (currentCell.CellType == CellType.Numeric)
            {

                if (DateUtil.IsCellDateFormatted(currentCell))
                {
                    DateTime dt = currentCell.DateCellValue;
                    //SimpleDateFormat sdf = new SimpleDateFormat("dd MM yyyy HH:mm:ss");
                    //SimpleDateFormat sdf = new SimpleDateFormat("dd-MMM-yyyy");
                    //cellValue = sdf.format(dt);
                    cellValue = dt.ToString("MM/dd/yyyy");
                }
                else
                {
                    cellValue = (Math.Round(currentCell.NumericCellValue).ToString());
                }
            }
            else if (currentCell.CellType == CellType.Blank)
            {
                cellValue = "";
            }
            else if (currentCell.CellType == CellType.Boolean)
            {
                cellValue = (currentCell.BooleanCellValue).ToString();
            }
            else if (currentCell.CellType == CellType.Error)
            {
                cellValue = (currentCell.ErrorCellValue).ToString();
            }
            else if (currentCell.CellType == CellType.String)
            {
                cellValue = currentCell.StringCellValue;
            }
            else
            {
                try { cellValue = currentCell.StringCellValue; }
                catch { cellValue = currentCell.NumericCellValue.ToString(); }

                //DataFormatter formatter = new DataFormatter();
                //String j_username = formatter.FormatCellValue(currentCell);
            }
            return cellValue;
        }

        /**
         *To obtain the values of all columns in a row with header row value(assuming that the first row is header row) based 
         row number as parameter 
         * @param rowNo- row number
         */

        public Dictionary<String, String> getRowMap(int rowNo)
        {
            Dictionary<String, String> rowMap = new Dictionary<String, String>();
            IRow currentRow = currentSheet.GetRow(rowNo);
            for (int i = 0; i < currentRow.PhysicalNumberOfCells; i++)
            {
                String headerKey = getCellValueAt(0, i);
                String value = getCellValueAt(rowNo, i);
                //rowMap.put(headerKey, value);
                rowMap[headerKey] = value;
            }

            return rowMap;
        }

        public Dictionary<String, String> getRowMap(int rowNo, Boolean hasHeader)
        {
            int ColumnCount;
            Dictionary<String, String> rowMap = new Dictionary<String, String>();
            IRow currentRow = currentSheet.GetRow(rowNo);
            Dictionary<int, String> headerdata = new Dictionary<int, String>();
            if (hasHeader == false)
            {
                int headKey = 0;
                for (int i = 0; i < currentRow.PhysicalNumberOfCells; i++)
                {
                    headKey = i;
                    String value = "Column" + i.ToString(); ;
                    headerdata[headKey] = value;
                }

            }
            String headerKey;
            if (headerMap.Count != 0)
                ColumnCount = headerMap.Count;
            else
                ColumnCount = currentRow.PhysicalNumberOfCells;
            for (int i = 0; i < ColumnCount; i++)
            {
                if (hasHeader == true)
                {
                    headerKey = getCellValueAt(0, i);
                }
                else
                {
                    headerKey = headerdata[i];
                }
                String value = getCellValueAt(rowNo, i);
                rowMap[headerKey] = value;
            }

            return rowMap;
        }

        /**
         * To obtain the values of all columns in a row with header row value(assuming that the first row is header row) based on 
         column number and required matching data as parameter
         * @param columnNo - column number
         * @param data - data in the column
         */
        public Dictionary<String, String> getRowMap(int columnNo, String data)
        {
            Dictionary<String, String> rowMap = new Dictionary<String, String>();
            int rowNo = getRowNoByColumnData(columnNo, data);
            IRow currentRow = currentSheet.GetRow(rowNo);
            for (int i = 0; i < currentRow.PhysicalNumberOfCells; i++)
            {
                String headerKey = getCellValueAt(0, i);
                String value = getCellValueAt(rowNo, i);
                rowMap[headerKey] = value;
            }

            return rowMap;
        }

        /**
         *To obtain the values of all columns in a row with header row value(if the first row is header row) based 
         on column name and matching data as parameter 
         * @param columnName - column name
         * @param data - data in the column
         */
        public Dictionary<String, String> getRowMap(String columnName, String data)
        {
            Dictionary<String, String> rowMap = new Dictionary<String, String>();
            int rowNo = getRowNoByColumnName(columnName, data);
            IRow currentRow = currentSheet.GetRow(rowNo);
            for (int i = 0; i < currentRow.PhysicalNumberOfCells; i++)
            {
                String headerKey = getCellValueAt(0, i);
                String value = getCellValueAt(rowNo, i);
                rowMap[headerKey] = value;
            }
            return rowMap;
        }

        /**
         * To obtain row number by column data
         * @param columnNo - column number
         * @param data - data in the column
         */
        public int getRowNoByColumnData(int columnNo, String data)
        {
            int rowNo = -1;
            for (int i = 1; i < currentSheet.PhysicalNumberOfRows; i++)
            {

                String value = getCellValueAt(i, columnNo);
                if (data.ToLower().Equals(value.ToLower()))
                {
                    rowNo = i;
                    return rowNo;
                }
            }
            return rowNo;
        }

        /**
         *To obtain row number by column name 
         * @param columnHeader - column header value
         * @param value - search value
         */
        public int getRowNoByColumnName(String columnHeader, String value)
        {
            int rowNo = -1;
            if (currentSheet.PhysicalNumberOfRows > 1)
            {
                int columnNo = getColumnHeaderNo(columnHeader);

                for (int i = 0; i < currentSheet.PhysicalNumberOfRows; i++)
                {

                    String cv = getCellValueAt(i, columnNo);
                    if (value.Equals(cv))
                    {
                        rowNo = i;
                        return rowNo;
                    }
                }
            }
            return rowNo;
        }

        /**
         *To switch to another excel file 
         * @param filePath -excel file path
         */
        public void switchToFile(String filePath)
        {
            this.currentSheet = null;
            this.currentWorkbook = null;
            this.headerMap.Clear();
            new ExcelDriver(filePath);
        }

        /**
         *To Create a workbook 
         * @param excelFile - excel file name
         */
        private IWorkbook createWorkbook(FileInfo excelFile)
        {

            if (isXlsFileType(excelFile))
            {
                try
                {
                    currentWorkbook = new XSSFWorkbook(excelFile);
                }
                catch (Exception e)
                {
                    // TODO Auto-generated catch block
                    Console.WriteLine(e);
                }
            }
            else
            {
                currentWorkbook = new HSSFWorkbook();
            }

            return currentWorkbook;
        }

        /**
         *Defining workbook 
         * @param excel file path
         */
        private bool isXlsFileType(FileInfo excelFile)
        {

            return (excelFile.Name.EndsWith("xlsx") || excelFile.Name.EndsWith("xlsm") ? true : false);

        }
                
       
        private void setHeaderMap(ISheet currentSheet)

        {

            if (currentSheet.PhysicalNumberOfRows > 0)

            {

                headerMap.Clear();

                IRow headerRow = currentSheet.GetRow(0);

                foreach (ICell rw in headerRow.Cells)

                {

                    headerMap[rw.StringCellValue] = rw.ColumnIndex;

                }



            }

        }


        public int getRowCount()
        {
            return currentSheet.PhysicalNumberOfRows;
        }

        public int GetExcelRowsCount()
        {

            int rowNo =  currentSheet.PhysicalNumberOfRows;
            currentWorkbook.Close();
            return rowNo;
        }

        public void CloseWorkbook()
        {
            currentWorkbook.Close();
        }

    }
}
