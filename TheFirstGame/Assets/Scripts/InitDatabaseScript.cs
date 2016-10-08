//********************************************
// File Name  :         InitDatabaseScript.cs
// Author     :         Andy Fang
// Create Time:         9/6/2016 2:52:09 PM
//********************************************
using UnityEngine;

public class InitDatabaseScript : MonoBehaviour
{

    #region Unity Callback Method

    void Start ()
    {
        if (!PlayerPrefs.HasKey ("FirstRun"))
        {
            InitDataBaseAction ();
            PlayerPrefs.SetString ("FirstRun", "");
        }
    }

    #endregion


    #region Private Method

    private void InitDataBaseAction ()
    {
        // Create Tables

        // Login Table
        string sql = string.Format("CREATE TABLE IF NOT EXISTS Login(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, username TEXT NOT NULL, password TEXT NOT NULL, online BOOL DEFAULT false)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);
    }

    #endregion

}