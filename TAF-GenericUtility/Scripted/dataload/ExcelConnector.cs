﻿using System;

namespace TAF_GenericUtility.Scripted.dataload
{
    public class ExcelConnector
    {
        private String fileName;
        private String sheetName;
        private String[] columnNames;
        private int maxRows = -1;
        private bool hasHeader = true;

        public bool isHasHeader()
        {
            return hasHeader;
        }

        public void setHasHeader(bool hasHeader)
        {
            this.hasHeader = hasHeader;
        }

        public ExcelConnector(String fileName, String sheetName)
        {
            this.fileName = fileName;
            this.sheetName = sheetName;
        }

        /**
         * @return the maxRows
         */
        public int getMaxRows()
        {
            return maxRows;
        }
        public void setMaxRows(int maxRowCount)
        {
            this.maxRows = maxRowCount;
        }

        public void setColumnNames(String[] selectedColumns)
        {
            this.columnNames = selectedColumns;
        }

        public String getFileName()
        {
            return fileName;
        }

        public String getSheetName()
        {
            return sheetName;
        }

        public void setSheetName(String sheetName)
        {
            this.sheetName = sheetName;
        }
    }
}
