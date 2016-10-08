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
        //PlayerPrefs.DeleteAll ();
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
        #region Create Tables

        // 1. Login Table
        string sql = string.Format("CREATE TABLE IF NOT EXISTS login(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, username TEXT NOT NULL, password TEXT NOT NULL, online BOOL DEFAULT false)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 2. Player Level Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS player (user_id INTEGER REFERENCES login(id), prefession TEXT NOT NULL, level INTEGER DEFAULT 1, expreience INTEGER DEFAULT 0, hp INTEGER DEFAULT 0, mp INTEGER DEFAULT 0, intelligence INTEGER DEFAULT 0, agility INTEGER DEFAULT 0, resistance INTEGER DEFAULT 0, anger INTEGER DEFAULT 0, strength INTEGER DEFAULT 0, equipment_id_1 INTEGER REFERENCES equipment(id), equipment_id_2 INTEGER REFERENCES equipment(id), equipment_id_3 INTEGER REFERENCES equipment(id),  equipment_id_4 INTEGER REFERENCES equipment(id), equipment_id_5 INTEGER REFERENCES equipment(id), equipment_id_6 INTEGER REFERENCES equipment(id))");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 3. Experience Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS experience(level INTEGER NOT NULL, experience INTEGER NOT NULL)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 4. Profession Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS profession(pro_id INTEGER UNIQUE PRIMARY KEY NOT NULL, pro_name TEXT UNIQUE NOT NULL, skill_id_1 INTEGER REFERENCES skills(skill_id), skill_id_2 INTEGER REFERENCES skills(skill_id), skill_id_3 INTEGER REFERENCES skills(skill_id), skill_id_4 INTEGER REFERENCES skills(skill_id))");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 5. Equipment Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS equipment(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,equip_name TEXT UNIQUE NOT NULL, position INTEGER NOT NULL, hp INTEGER DEFAULT 0, mp INTEGER DEFAULT 0, intelligence INTEGER DEFAULT 0, agility INTEGER DEFAULT 0, resistance INTEGER DEFAULT 0, anger INTEGER DEFAULT 0, strength INTEGER DEFAULT 0)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 6. Skills Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS skills(skill_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, skill_name TEXT UNIQUE NOT NULL)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 7. Player Skill Status Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS player_skill_status(user_id INTEGERS REFERENCES login(id), skill_id INTEGER REFERENCES skills(id), skill_level INTEGER DEFAULT 0)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 8. Monster Info Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS monster(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, level INTEGER NOT NULL, name TEXT NOT NULL, type INTEGER NOT NULL, skill_id INTEGER REFERENCES skills(id), drop_equip_id_1 INTEGER REFERENCES equipment(id), drop_equip_id_2 INTEGER REFERENCES equipment(id), drop_equip_id_3 INTEGER REFERENCES equipment(id), drop_equip_id_4 INTEGER REFERENCES equipment(id))");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 9. Tasks Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS tasks(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, task_name TEXT UNIQUE NOT NULL, task_level INTEGER NOT NULL, task_content TEXT NOT NULL, task_experience INTEGER NOT NULL)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion


        #region Insert data

        // 1. Insert skills table
        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "变羊");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // TODO: 
        #endregion

    }

    #endregion

}