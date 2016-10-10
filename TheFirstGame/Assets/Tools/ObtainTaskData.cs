//********************************************
// File Name  :         ObtainTaskData.cs
// Author     :         Andy Fang
// Create Time:         10/9/2016 8:06:36 PM
//********************************************
using UnityEngine;
using System.Collections;

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
    /// Tmp method. (taskId: 1, 2, 3)
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    public int GetTaskStatus(int taskId)
    {
        int status = -1;
        // tmp return test data
        switch (taskId)
        {
            case 1:
                {
                    status = status1;
                    break;
                }
            case 2:
                {
                    status = status2;
                    break;
                }
            case 3:
                {
                    status = status3;
                    break;
                }
        }
        return status;
    }

    public 


    #endregion

    #region Temp method for Test Data

    int status1 = 0;
    int status2 = 0;
    int status3 = 0; 

    /// <summary>
    /// The method only for test, and will deleted finlally.
    /// Set the taskId's status; (taskId: 1, 2, 3)
    /// </summary>
    /// <param name="taskId"></param>
    /// <param name="status"></param>
    public void SetTaskStatus(int taskId, int status)
    {
        switch (taskId)
        {
            case 1:
                {
                    status1 = status;
                    break;
                }
            case 2:
                {
                    status2 = status;
                    break;
                }
            case 3:
                {
                    status3 = status;
                    break;
                }
            default:
                break;
        }
    }

    #endregion
}