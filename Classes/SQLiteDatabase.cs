/*
 * SQL Lite Data Helper Class
 * by Swen Kooij
 * on 10/2/2012 (European Date Notation)
 * Release under the GPL License
 * See http://gpl.org for more information
 * 
 * Mail adresses:
 * ---------------------------------------------------------
 * swenkooij@gmail.com
 * 40004568@st.roca12.nl
 * kirk@hackflag.org
 * tha_kirk@icloud.com
 * swen.kooij@facebook.com
 * swen.kooij@apple.com
 * swen.kooij@youtube.com
 * swen.kooij@google.com
 * ------------------------------------------------------------
*/


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

/// <summary>
/// Vertegenwoordigd een SQL Lite Database
/// </summary>
public class SQLiteDatabase
{
    String dbConnection;

    /// <summary>
    ///     Single Param Constructor for specifying the DB file.
    /// </summary>
    /// <param name="inputFile">The File containing the DB</param>
    public SQLiteDatabase(String inputFile)
    {
        dbConnection = String.Format("Data Source={0}", inputFile);
    }

    /// <summary>
    ///     Single Param Constructor for specifying advanced connection options.
    /// </summary>
    /// <param name="connectionOpts">A dictionary containing all desired options and their values</param>
    public SQLiteDatabase(Dictionary<String, String> connectionOpts)
    {
        String str = "";
        foreach (KeyValuePair<String, String> row in connectionOpts)
        {
            str += String.Format("{0}={1}; ", row.Key, row.Value);
        }
        str = str.Trim().Substring(0, str.Length - 1);
        dbConnection = str;
    }

    /// <summary>
    ///     Allows the programmer to run a query against the Database.
    /// </summary>
    /// <param name="sql">The SQL to run</param>
    /// <returns>A DataTable containing the result set.</returns>
    public DataTable GetDataTable(string sql)
    {
        DataTable dt = new DataTable();
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            SQLiteDataReader reader = mycommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return dt;
    }

    /// <summary>
    /// Allows the programmer to retrieve all contents in a table without a query
    /// </summary>
    /// <param name="tableName">The name of the table</param>
    /// <param name="extraQuery">Add extra shizzle at the end of the SQL query.</param>
    /// <returns>A DataTable containing the result</returns>
    public DataTable GetTable(string tableName, string extraQuery)
    {
        DataTable dt = new DataTable();
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = "SELECT * FROM " + tableName + " " + extraQuery;
            SQLiteDataReader reader = mycommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return dt;
    }

    /// <summary>
    /// Retrieves all rows in a specified table
    /// </summary>
    /// <param name="tableName">The name of the table</param>
    /// <param name="extraQuery">Add extra shizzle at the end of the SQL query.</param>
    /// <returns>A DataRowCollection object</returns>
    public DataRowCollection GetTableRows(string tableName, string extraQuery)
    {
        DataTable dt = new DataTable();
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = "SELECT * FROM " + tableName + " " + extraQuery;
            SQLiteDataReader reader = mycommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        return dt.Rows;
    }

    /// <summary>
    /// Dumps the contents of a table in a string, used for debugging
    /// </summary>
    /// <param name="TableName">The name of the table</param>
    /// <returns>The string</returns>
    public string TableDump(string Query)
    {
        DataTable dt = new DataTable();
        try
        {
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = Query;
            SQLiteDataReader reader = mycommand.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            cnn.Close();
        }
        catch (Exception e)
        {
            string Excp = e.ToString();
            Excp = Excp.Replace("System.Data.SQLite.SQLiteException: ", "");
            Excp = Excp.Split(new[] { "at System.Data.SQLite.SQLite3.Prepare" }, StringSplitOptions.None)[0];
            return Excp;
        }

        string Dump = "Table: " + dt.TableName + Environment.NewLine;
        Dump += "Rows: " + dt.Rows.Count.ToString() + Environment.NewLine + Environment.NewLine;
        DataColumnCollection Columns = dt.Columns;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string Column = Columns[i].ToString() + ": ";
            DataRow Row = dt.Rows[i];
            Dump += "Row " + i.ToString() + Environment.NewLine;
            Dump += "------------------------------------------------------------------" + Environment.NewLine;
            foreach (DataColumn Col in Columns)
            {
                Dump += "-- " + Col.ColumnName + " (" + Col.DataType.ToString().Replace("System.", "") + "): " + Row[Col.ColumnName] + Environment.NewLine;
            }
            Dump += Environment.NewLine;
        }
        return Dump;
    }

    /// <summary>
    ///     Allows the programmer to interact with the database for purposes other than a query.
    /// </summary>
    /// <param name="sql">The SQL to be run.</param>
    /// <returns>An Integer containing the number of rows updated.</returns>
    public string Query(string sql)
    {
        try
        {
            if (sql.StartsWith("SELECT"))
            {
                return TableDump(sql);
            }
            SQLiteConnection cnn = new SQLiteConnection(dbConnection);
            cnn.Open();
            SQLiteCommand mycommand = new SQLiteCommand(cnn);
            mycommand.CommandText = sql;
            int rowsUpdated = mycommand.ExecuteNonQuery();
            cnn.Close();
            return rowsUpdated.ToString();
        }
        catch (Exception E)
        {
            MessageBox.Show(E.ToString() + Environment.NewLine + Environment.NewLine + sql);
        }
        return "";
    }

    /// <summary>
    /// Makes up an insert query
    /// </summary>
    /// <param name="Values">A dictionary of the values to insert</param>
    /// <returns>The query result (Number of rows updated</returns>
    public string Insert(string tableName, Dictionary<string, string> Values)
    {
        string Q = "INSERT INTO " + tableName + " (";
        foreach (string Value in Values.Keys)
        {
            Q += Value + ",";
        }
        Q = Q.TrimEnd(',') + ") VALUES(";
        foreach (string Value in Values.Values)
        {
            Q += "'" + Value + "',";
        }
        Q = Q.TrimEnd(',');
        Q += ");";
        return Query(Q);
    }

    /// <summary>
    /// Retrieves all column names from a specified table.
    /// </summary>
    /// <param name="TableName">The table name.</param>
    /// <returns>An string array of column names</returns>
    public string[] GetColumns(string TableName)
    {
        DataTable Tb = GetTable(TableName, "");
        List<string> Columns = new List<string>();
        foreach (DataColumn Col in Tb.Columns)
        {
            Columns.Add(Col.ColumnName);
        }
        return Columns.ToArray();
    }

    /// <summary>
    /// Retrieves the last added id in a table
    /// </summary>
    /// <param name="tableName">The name of the table you want to retrieve the latest id from</param>
    /// <returns></returns>
    public int RetrieveLastId(string tableName)
    {
        DataRow Row = GetTableRows(tableName, "ORDER BY id DESC LIMIT 0,1")[0];
        return Convert.ToInt32(Row["id"]);
    }
}
