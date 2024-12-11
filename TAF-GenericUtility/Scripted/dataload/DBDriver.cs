﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace TAF_GenericUtility.Scripted.dataload
{
    public class DBDriver
    {

        protected String JDBC_DRIVER = null; // "com.mysql.jdbc.Driver";
        protected String DB_URL = null; // "jdbc:mysql://localhost/EMP";

        protected String USER = null; // "username";
        protected String PASS = null; // "password";
        //SqlConnection conn = null;
        //Statement stmt = null;
        //ResultSet rs = null;
        //ResultSetMetaData rsMetadata = null;
        //long Rows = 0;
        //int Columns = 0;

        /**
         * 
         * @param dbDriver
         * @param dbURL
         * @param user
         * @param pwd
         */

        public DBDriver(String dbDriver, String dbURL, String user, String pwd)
        {
            setDBDriver(dbDriver);
            this.DB_URL = dbURL;
            this.USER = user;
            this.PASS = pwd;
        }

        /**
         * 
         * @param dbDriver
         */
        protected void setDBDriver(String dbDriver)
        {

            switch (dbDriver.ToLower())
            {
                case "mysql":
                    this.JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
                    break;
                case "oracle":
                    this.JDBC_DRIVER = "oracle.jdbc.driver.OracleDriver";
                    break;
                case "sqlserver":
                    this.JDBC_DRIVER = "com.microsoft.sqlserver.jdbc.SQLServerDriver";
                    break;
            }
        }


        //
  
        /// <summary>
        ///  @throws ClassNotFoundException
        ///  @throws SQLException         
        /// </summary>
        public void getConnection()  {
            //try {

            //    Class.forName(JDBC_DRIVER).newInstance();
            //    conn = DriverManager.getConnection(DB_URL, USER, PASS);
            //} catch (Exception e) {
            //    System.out.println(e.getMessage());
            //}

        }

        //	/**
        //	 * 
        //	 * @param sqlStatement
        //	 * @return 
        //	 * @throws SQLException
        //	 */
        //	public ResultSet getResultSet(String sqlStatement) throws SQLException
        //{
        //    stmt=conn.createStatement();
        //    rs = stmt.executeQuery(sqlStatement);
        //		this.rsMetadata = rs.getMetaData();
        //		int i = 0;
        //    rs.first();
        //		while (!rs.isLast()) {

        //        i++;
        //        rs.next();
        //    }

        //    Rows = i;
        //    Columns = rsMetadata.getColumnCount();
        //		return rs;

        //}

        ///**
        // * Get the number of rows in the said db result set
        // * 
        // * @return Return no of rows present in the said db result set
        // * @throws SQLException
        // */
        //public long getNoOfRows()
        //{
        //    return Rows;
        //}

        ///**
        // * Return the number of column in the first row of the DB file
        // * 
        // * @return return the no. of column in the first row of the DB file
        // * @throws SQLException
        // */
        //public int getNoOfColumns() throws SQLException
        //{

        //		return Columns;

        //}

        ///**
        // * 
        // * @param ComlumnName
        // * @return
        // * @throws SQLException
        // */
        //public int getColumnNo(String ComlumnName) throws SQLException
        //{

        //		for (int i = 0; i < getNoOfColumns(); i++) {

        //        if (rsMetadata.getColumnName(i).equalsIgnoreCase(ComlumnName))
        //            return i + 1;
        //    }
        //		return 0;
        //}

        ///**
        // * 
        // * @param ColumnName
        // * @param ColumnVal
        // * @return
        // * @throws SQLException
        // */
        //public int getRowNo(String ColumnName, String ColumnVal)

        //            throws SQLException
        //{
        //		int ColNo = getColumnNo(ColumnName);
        //		long rows = getNoOfRows();

        //		for (int i = 1; i < rows; i++) {

        //        if (rsMetadata.getColumnName(ColNo).equalsIgnoreCase(ColumnVal))
        //        {
        //            return i;
        //        }
        //    }
        //		return -1;
        //}

        ///**
        // * Gets the data from the currently opened sheet based on row and column
        // * number
        // * 
        // * @param row
        // *            Row no. from which the value has to be fetched
        // * @param column
        // *            Respective column no. in the row from which the value has to
        // *            be fetched
        // * @return The data present in the respective row & column. If no value is
        // *         found it returns and empty String.
        // */
        //public String getData(int row, int column)
        //{
        //    String data = "";
        //    try
        //    {

        //        long Nrows = getNoOfRows();
        //        rs.first();
        //        for (int i = 1; i <= Nrows; i++)
        //        {
        //            if (i == row)
        //                break;
        //            rs.next();
        //        }
        //        data = rs.getString(column);
        //        if (data == null)
        //        {
        //            data = "";
        //        }
        //        return data;
        //    }
        //    catch (Exception e)
        //    {
        //        data = "";
        //        return data;
        //    }
        //}
    }

}
