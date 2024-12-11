using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TAF_GenericUtility.Scripted.dataload
{
    public class TestDataObject
    {

        private Dictionary<String, Dictionary<String, String>> tableData;
        private Dictionary<String, String> mapData;
        private DataTable datatable;
        private Boolean hasMapData = false;
        private Boolean hasTableData = false;

        public Dictionary<String, String> getMapData()
        {
            return mapData;
        }

        public void setMapData(Dictionary<String, String> mapData)
        {
            this.mapData = mapData;
            hasMapData = true;
        }

        public Dictionary<String, Dictionary<String, String>> getTableData()
        {
            return tableData;
        }


        
        public void setTableData(Dictionary<String, Dictionary<String, String>> tableData)
        {
            this.tableData = tableData;
            hasTableData = true;
        }

        public Boolean getHasMapData()
        {
            return hasMapData;
        }

        public Boolean getHasTableData()
        {
            return hasTableData;
        }
    }
}
