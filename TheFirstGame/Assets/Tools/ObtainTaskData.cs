//********************************************
// File Name  :         ObtainTaskData.cs
// Author     :         Andy Fang
// Create Time:         10/9/2016 8:06:36 PM
//********************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObtainTaskData
{
    #region Singleton

    private static ObtainTaskData instance; 

    private ObtainTaskData()
    {
        sDb = ShareDatabase.sDb;
    }

    public static ObtainTaskData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObtainTaskData ();
            }
            return instance;
        }
    }

    #endregion

    #region Variable

    ShareDatabase sDb;

    #endregion

    #region Public Method

    /// <summary>
    /// Get task status.
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    public int GetTaskStatus(int taskId)
    {
        int status = -1;
        string sql = string.Format("SELECT task_status FROM task WHERE id = {0}", taskId);
        object obj = sDb.SelectFieldSql(sql);
        if (obj == null)
        {
            return -1;
        }
        else
        {
            status = (int)obj;
        }

        return status;
    }

    /// <summary>
    /// Update task status.
    /// </summary>
    /// <param name="taskId"></param>
    /// <param name="status"></param>
    public void UpdateTaskStatus(int taskId, int status)
    {
        string sql = string.Format("UPDATE task SET task_status = {0} WHERRE id = {1}", status, taskId);
        sDb.ExecSql (sql);
    }

    /// <summary>
    /// Get task experience.
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    public int GetTaskExperience(int taskId)
    {
        string sql = string.Format("SELECT task_experience FROM task WHERE id = {0}", taskId);
        object obj = sDb.SelectFieldSql (sql);
        if (obj == null)
        {
            return -1;
        }
        else
        {
            return (int)obj; 
        }

    }

    /// <summary>
    /// Get task info.
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    public Task getTask(int taskId)
    {
        string sql = string.Format("SELECT task_name, task_level, task_content, task_status FROM task WHERE id = {0}", taskId);
        List<ArrayList> list = sDb.SelectResultSql(sql);
        if (list == null || list.Count <= 0)
        {
            return null;
        }
        string name = (string)list[0][0];
        int level = (int)list[0][1];
        string content = (string)list[0][2];
        int status = (int)list[0][3];
        Task task = new Task (taskId, name, level, content, status);
        return task;
    }

    #endregion
}