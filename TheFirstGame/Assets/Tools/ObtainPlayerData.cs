//********************************************
// File Name  :         ObtainPlayerData.cs
// Author     :         Andy Fang
// Create Time:         10/10/2016 10:35:10 AM
//********************************************
using UnityEngine;
using System.Collections;

public class ObtainPlayerData
{
    #region Singlton

    private static ObtainPlayerData instance;

    private ObtainPlayerData()
    {
        sDb = ShareDatabase.sDb;
    }

    public static ObtainPlayerData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObtainPlayerData ();
            }
            return instance;
        }
    }

    #endregion

    #region Variable

    ShareDatabase sDb;

    #endregion

    #region Public Method 

    public Player GetPlayerInfo(int userId)
    {
        if (tmpPlayer != null && tmpPlayer.UserId == userId)
        {
            return tmpPlayer;
        }
        // Tmp data for test.
        tmpPlayer = new Player();
        tmpPlayer.UserId = userId;
        tmpPlayer.ProfessionId = 1; // Sor
        tmpPlayer.Level = 1;
        tmpPlayer.Experience = 0;
        tmpPlayer.Hp = 100;
        tmpPlayer.Mp = 100;
        tmpPlayer.Intelligence = 50;
        tmpPlayer.agility = 50;
        tmpPlayer.Resistance = 50;
        tmpPlayer.Anger = 0;
        tmpPlayer.Strength = 0;
        Equipment E1 = ObtainEquipmentData.Instance.GetEquipmentInfo(5);
        tmpPlayer.Equip1 = E1;
        tmpPlayer.Equip2 = null;
        tmpPlayer.Equip3 = null;
        tmpPlayer.Equip4 = null;
        tmpPlayer.Equip5 = null;
        tmpPlayer.Equip6 = null;
        return tmpPlayer;
    }

    public void UpdatePlayerInfo(Player player)
    {
        tmpPlayer = player;
    }

    #endregion

    #region Tmp Data 

    Player tmpPlayer;

    #endregion
}