using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAF_GenericUtility.Scripted.dataload;


namespace TAF_GenericUtility.Scripted.DataWrite
{
    public class ExcelDataWrite
    {
        IWorkbook workbook = null;
        ISheet sheet = null;

        /// <summary>
        /// write data to an existing sheet or if sheet not existing create a new one
        /// if no template is provided the first data will be the column header
        /// </summary>
        /// <param name="templateFile">template file if exists otherwise empty</param>
        /// <param name="sheetName">sheetname if exists otherwise new sheet</param>
        /// <param name="outputFile">location of the output file</param>
        /// <param name="templateWithColumnHeader">if the template is provided, column headers already available?</param>
        /// <param name="exceldata">data to be written  <rownumber<list of data>>   </param>
        public void WriteToExcel(string templateFile1, string sheetName, string outputFile, bool templateWithColumnHeader, Dictionary<int, List<string>> exceldata, bool ExistingFile = false)
        {
            int rowIndex;
            try
            {

                if (IsTemplateFileExists(outputFile))
                {
                    ReadWorkbook(outputFile);
                }
                else
                {
                    CreateNewWorkBook();
                }


                //check if sheet exists

                if (IsSheetExists(sheetName))
                {
                    GetSheet(sheetName);
                }
                else
                {
                    CreateSheet(sheetName);
                }

                if (ExistingFile)
                {
                    rowIndex = sheet.PhysicalNumberOfRows;
                }
                else rowIndex = templateWithColumnHeader ? 1 : 0;
                foreach (int item in exceldata.Keys)
                {

                    IRow nRow = null;

                    if (ExistingFile)
                    {
                        nRow = CreateRow(rowIndex);
                    }
                    //else
                    //{
                    //    nRow = GetRow(rowIndex);
                    //}

                    List<string> rowData = new List<string>();
                    rowData = exceldata[item];

                    int cellIndex = 0;
                    foreach (string s in rowData)
                    {

                        if (ExistingFile)
                        {
                            CreateCell(cellIndex, nRow, CellType.String);
                        }

                        SetCellvalue(s, rowIndex, cellIndex);
                        cellIndex++;
                    }

                    rowIndex++;
                }

                using (FileStream stream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
                }
            }
            catch (Exception ex)
            {
                workbook.Close();
            }
        }

        public void WriteToExcel(string outputFile, string sheetName, bool templateWithColumnHeader, Dictionary<int, List<string>> exceldata, bool ExistingFile = false)
        {
            int rowIndex;
            try
            {

                if (IsTemplateFileExists(outputFile))
                {
                    ReadWorkbook(outputFile);
                }
                else
                {
                    CreateNewWorkBook();
                }


                //check if sheet exists
                if (IsSheetExists(sheetName))
                {
                    GetSheet(sheetName);
                }
                else
                {
                    CreateSheet(sheetName);
                }

                rowIndex = sheet.PhysicalNumberOfRows;

                if (rowIndex == 0)
                    rowIndex = templateWithColumnHeader ? 1 : 0;

                foreach (int item in exceldata.Keys)
                {

                    IRow nRow = null;
                    nRow = CreateRow(rowIndex);


                    List<string> rowData = new List<string>();
                    rowData = exceldata[item];

                    int cellIndex = 0;
                    foreach (string s in rowData)
                    {
                        CreateCell(cellIndex, nRow, CellType.String);
                        //if (ExistingFile)
                        //{
                        //    CreateCell(cellIndex, nRow, CellType.String);
                        //}

                        SetCellvalue(s, rowIndex, cellIndex);
                        cellIndex++;
                    }

                    rowIndex++;
                }


                using (FileStream stream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    try
                    {
                        workbook = new XSSFWorkbook(stream);

                       
                    }
                    catch
                    {
                        workbook = null;
                    }
                    workbook.Write(stream);
                }
            }
            catch (Exception ex)
            {
                workbook.Close();
            }
        }
        public void WriteToExcel(string filePath, string sheetName, string columnHeader, string rowValue, string inputValue,int ColumnNo=0)
        {
          
            try
            {
                if (IsTemplateFileExists(filePath))
                {
                    ReadWorkbook(filePath);
                }
                else
                {
                    return;
                }
                
                //check if sheet exists 
                if (IsSheetExists(sheetName))
                {
                    GetSheet(sheetName);
                }
                ExcelDriver excelDriver = new ExcelDriver(workbook, sheet);
                int rowIndex;
                if (rowValue == "")
                    rowIndex = sheet.PhysicalNumberOfRows;
                else rowIndex = excelDriver.getRowNoByColumnData(ColumnNo, rowValue);
                int cellIndex = excelDriver.getColumnHeaderNo(columnHeader);
                IRow Irow = GetRow(rowIndex);
                ICell Icell = GetCell(Irow, cellIndex);
                if (Icell == null)
                    CreateRow(Irow, cellIndex);
                SetCellvalue(inputValue, rowIndex, cellIndex);

                //int attempt = 1;
                //while(attempt <=2)
                //{
                    //try
                    //{
                        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        {
                            workbook.Write(stream);
                        }
                       // break;
                   // }
                    //catch
                    //{
                    //    attempt++;
                    //    workbook.Close();
                    //}
               // }
               
                
            }
            catch (Exception ex)
            {
                workbook.Close();
            }
        }




        private void CreateNewWorkBook()
        {
            workbook = new HSSFWorkbook();
        }

        private bool IsSheetExists(string sheetName)
        {
            try
            {
                workbook.GetSheet(sheetName);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void CreateSheet(string sheetName)
        {
            sheet = workbook.CreateSheet(sheetName);
        }

        private void GetSheet(string sheetName)
        {
            sheet = workbook.GetSheet(sheetName);
        }

        private bool IsTemplateFileExists(string templateFile)
        {
            if (string.IsNullOrEmpty(templateFile))
            {
                return false;
            }
            else
            {
                if (File.Exists(templateFile))
                {
                    return true;
                }
                else
                {
                    throw new Exception($"Template {Path.GetFileName(templateFile)} doesn't exists");
                }
            }

        }

        private IRow CreateRow(int rowIndex)
        {
            return sheet.CreateRow(rowIndex);
        }

        private ICell CreateRow(IRow row, int cellIndex)
        {
            return row.CreateCell(cellIndex);
        }

        private IRow GetRow(int rowIndex)
        {
            return sheet.GetRow(rowIndex);
        }

        private ICell GetCell(IRow row, int cellIndex)
        {
            return row.GetCell(cellIndex);
        }

        private string GetCellValue(IRow row, int cellIndex)
        {
            return GetStringValueFromCell(row.Cells[cellIndex]);
        }

        private string GetCellValue(int rowIndex, int cellIndex)
        {
            return GetStringValueFromCell(sheet.GetRow(rowIndex).GetCell(cellIndex));
        }

        private string GetStringValueFromCell(ICell currentCell)
        {
            String cellValue = "";

            if (currentCell.CellType == CellType.Numeric)
            {
                if (DateUtil.IsCellDateFormatted(currentCell))
                {
                    DateTime dt = currentCell.DateCellValue;
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
                cellValue = currentCell.StringCellValue;
            }
            return cellValue;
        }

        private void SetCellvalue(string value, ICell cell)
        {
            cell.SetCellValue(value);
        }

        private ICell CreateCell(int cellindex, IRow row)
        {
            return row.CreateCell(cellindex);
        }

        private ICell CreateCell(int cellindex, IRow row, CellType cellType)
        {
            return row.CreateCell(cellindex, cellType);
        }

        

        private void SetCellvalue(string value, int rowIndex, int cellIndex)
        {
            try
            {
                IRow row=sheet.GetRow(rowIndex);
                this.SetCellvalue(value, sheet.GetRow(rowIndex).GetCell(cellIndex));
            }

            catch (Exception ex)
            { }
        }

        private void ReadWorkbook(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                // Try to read workbook as XLSX:
                try
                {
                    workbook = new XSSFWorkbook(fs);                    
                }
                catch
                {
                    workbook = null;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot read work book {Path.GetFileName(path)}");
            }
        }
    }
}
