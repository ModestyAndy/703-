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
        Equipment equip = new Equipment();
        equip.name = (string)list[0][0];
        equip.Part = (int)list[0][1];
        equip.Hp = (int)list[0][2];
        equip.Mp = (int)list[0][3];
        equip.Intelligence = (int)list[0][4];
        equip.agility = (int)list[0][4];
        equip.Resistance = (int)list[0][5];
        equip.Anger = (int)list[0][6];
        equip.Strength = (int)list[0][7];
        equip.Price = (int)list[0][8];

        return equip;
    }

    #endregion
}