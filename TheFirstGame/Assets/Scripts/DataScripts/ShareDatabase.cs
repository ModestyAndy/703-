//********************************************
// File Name  :         ShareDatabase.cs
// Author     :         Andy Fang
// Create Time:         9/6/2016 11:14:06 AM
//********************************************
using Mono.Data.Sqlite;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareDatabase
{
    // Singleton
    public static ShareDatabase sDb = new ShareDatabase(); 
    /// <summary>
    /// The object of Database connecte
    /// </summary>
    SqliteConnection m_con;
    /// <summary>
    /// The object of command execute.
    /// </summary>
    SqliteCommand m_command;
    /// <summary>
    /// The object for receive the return value of select result.
    /// </summary>
    SqliteDataReader m_reader;

    private string databaseName = "/SevenDataBase.sqlite";

    private ShareDatabase()
    {
        //string dataPath = "Data Source =" + Application.streamingAssetsPath + databaseName;

#if UNITY_EDITOR
        string dataPath = "Data Source =" + Application.streamingAssetsPath + databaseName;
#elif UNITY_IPHONE
        string dataPath = "Data Source =" + Application.persistentDataPath + databasseName;
#elif UNITY_ANDROID
        string dataPath = "URI = file:" + Application.persistentDataPath + databasseName;
#endif

        // try connect database.
        try
        {
            if (m_con == null)
            {
                // if exit connect, else create one then connect.
                m_con = new SqliteConnection(dataPath);
            }
        }
        catch (SqliteException ex)
        {
            Debug.Log(ex);
        }
        // try create command
        try
        {
            m_command = m_con.CreateCommand();
        }
        catch (SqliteException ex)
        {
            Debug.Log(ex);
        }
        sDb = this;
    }

    #region Private method
    /// <summary>
    /// Open the connet data base.
    /// </summary>
    private void OpenConnectDatabase()
    {
        try
        {
            m_con.Open();
        }
        catch (SqliteException ex)
        {
            Debug.Log(ex);
        }
    }

    /// <summary>
    /// Close connect data base.
    /// </summary>
    private void CloseConnectDatabase()
    {
        try
        {
            m_con.Close();
        }
        catch (SqliteException ex)
        {
            Debug.Log(ex);
        }
    }

    #endregion

    #region public method

    /// <summary>
    /// Suit for command with no return value.
    /// Such as: Create table, Delete table, Insert data, Delete data, Update data.
    /// </summary>
    /// <param name="query">The execute statement</param>
    public bool ExecSql(string query)
    {
        // Open database.
        OpenConnectDatabase();

        // Execute command
        try
        {
            m_command.CommandText = query;
            m_command.ExecuteNonQuery();
        }
        catch (SqliteException ex)
        {
            Debug.Log(ex);
            return false;
        }

        // Close database
        CloseConnectDatabase();
        return true;
    }

    /// <summary>
    /// Query single field.
    /// Such as: Query attribute, Query count
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public object SelectFieldSql(string query)
    {
        // Open database
        OpenConnectDatabase();

        object obj = new object();
        try
        {
            m_command.CommandText = query;
            obj = m_command.ExecuteScalar();
        }
        catch (SqliteException ex)
        {
            Debug.Log(ex);
        }

        // Close database
        CloseConnectDatabase();

        return obj;
    }

    /// <summary>
    /// Query multi-row and multi-column.
    /// </summary>
    /// <returns></returns>
    public List<ArrayList> SelectResultSql(string query)
    {
        // Open database
        OpenConnectDatabase();

        List<ArrayList> list = new List<ArrayList>();

        try
        {
            m_command.CommandText = query;
            m_reader = m_command.ExecuteReader();
            while (m_reader.Read()) // read a row
            {
                ArrayList alist = new ArrayList();
                for (int i = 0; i < m_reader.FieldCount; i++)
                {
                    alist.Add(m_reader.GetValue(i));
                    list.Add(alist);

                }
            }
            m_reader.Close();
        }
        catch (SqliteException ex)
        {
            Debug.Log(ex);
        }

        // Close database
        CloseConnectDatabase();

        return list;
    }


    #endregion
}