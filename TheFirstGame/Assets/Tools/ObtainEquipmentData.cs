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

        string sql = string.Format("SELECT id, equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price FROM equipment WHERE id = {0}", id);
        List<ArrayList> list = sDb.SelectResultSql (sql);

        if (list == null || list.Count == 0)
        {
            return null;
        }
        // Change info to Equipment instance
        string name = (string)list[0][0];
        int part = (int)list[0][1];
        int hp = (int)list[0][2];
        int mp = (int)list[0][3];
        int intelligence = (int)list[0][4];
        int agility = (int)list[0][4];
        int resistance = (int)list[0][5];
        int anger = (int)list[0][6];
        int strength = (int)list[0][7];
        int price = (int)list[0][8];
        Equipment equip = new Equipment(id, name, part, hp, mp, intelligence, agility, resistance, anger, strength, price);

        return equip;
    }

    #endregion
}