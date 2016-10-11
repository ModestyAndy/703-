//********************************************
// File Name  :         ObtainEquipmentData.cs
// Author     :         Andy Fang
// Create Time:         10/9/2016 7:21:38 PM
//********************************************
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObtainEquipmentData
{
    #region Singlton 

    private static ObtainEquipmentData instance;

    private ObtainEquipmentData()
    {
        sDb = ShareDatabase.sDb;
    }

    public static ObtainEquipmentData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObtainEquipmentData ();
            }
            return instance;
        }
    }

    #endregion

    #region Variable

    private ShareDatabase sDb;
    private object equ;

    #endregion

    #region Public Method

    /// <summary>
    /// Get the equipment info.
    /// </summary>
    /// <param name="id">The equipment id.</param>
    /// <returns>The equipment instance</returns>
    public Equipment GetEquipmentInfo(int id)
    {
        if (id <= 0)
        {
            return null; 
        }

        string sql = string.Format("SELECT equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price FROM equipment WHERE id = {0}", id);
        List<ArrayList> list = sDb.SelectResultSql (sql);

        if (list == null || list.Count == 0)
        {
            return null;
        }
        // Change info to Equipment instance
        string name = (string)list[0][0];
        int part = int.Parse(list[0][1].ToString());
        int hp = int.Parse(list[0][2].ToString());
        int mp = int.Parse(list[0][3].ToString());
        int intelligence = int.Parse(list[0][4].ToString());
        int agility = int.Parse(list[0][5].ToString());
        int resistance = int.Parse(list[0][6].ToString());
        int anger = int.Parse(list[0][7].ToString());
        int strength = int.Parse(list[0][8].ToString());
        int price = int.Parse(list[0][9].ToString());
        Equipment equip = new Equipment(id, name, part, hp, mp, intelligence, agility, resistance, anger, strength, price);

        return equip;
    }

    #endregion
}