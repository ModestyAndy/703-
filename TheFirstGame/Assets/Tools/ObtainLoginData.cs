//********************************************
// File Name  :         ObtainData.cs
// Author     :         Andy Fang
// Create Time:         10/8/2016 4:22:30 PM 
//********************************************

public class ObtainLoginData
{

    #region Singleton

    public static ObtainLoginData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObtainLoginData ();
            }

            return instance;
        }
    }
    private static ObtainLoginData instance;

    private ObtainLoginData ()
    {
        sDb = ShareDatabase.sDb;
    }

    #endregion

    #region Variable

    public ShareDatabase sDb;

    #endregion


    #region Public Method

    /// <summary>
    /// Add user into "Login" table.
    /// </summary>
    /// <param name="name">User name</param>
    /// <param name="password">User password</param>
    /// <returns></returns>
    public bool AddUser(string name, string password)
    {
        if ((name == null || name == "") || (password == null || password == ""))
        {
            return false;
        }

        if (CheckUserExist(name))
        {
            return false;
        }

        string sql = string.Format("Insert into login (username, password) VALUES ('{0}', '{1}')", name, password);
        return sDb.ExecSql (sql);
    }

    /// <summary>
    /// Check the 
    /// </summary>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool CheckLogin (string name, string password)
    {
        if ((name == null || name == "") || (password == null || password == ""))
        {
            return false;
        }

        string sql = string.Format("Select password FROM Login WHERE username = '{0}'", name);

        object pwdObj = sDb.SelectFieldSql(sql);
        if (pwdObj == null)
        {
            return false;
        }

        string pwd = (string)pwdObj;

        if (pwd == password)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Check if the user is already exist.
    /// </summary>
    /// <param name="name">User name</param>
    /// <returns></returns>
    public bool CheckUserExist(string name)
    {
        if (name == null || name == "")
        {
            return false;
        }

        string sql = string.Format("Select username FROM Login WHERE username = '{0}'", name);

        object userName = sDb.SelectFieldSql(sql);

        if (userName == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Obtain the current player's user id.
    /// </summary>
    /// <param name="name">user name</param>
    /// <returns>user id</returns>
    public int GetUserId(string name)
    {
        string sql = string.Format("SELECT id FROM login WHERE name = '{0}'", name);
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

    #endregion

}