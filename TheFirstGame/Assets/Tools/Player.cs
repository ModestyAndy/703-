//********************************************
// File Name  :         Player.cs
// Author     :         Andy Fang
// Create Time:         10/10/2016 10:35:38 AM
//********************************************
using UnityEngine;
using System.Collections;

public class Player
{
    #region Property
    // TODO: ID's set need private;
    public int UserId { get; set; } 
    public int ProfessionId { get; set; }
    public int Level { get; set; }
    public float Experience { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public int Intelligence { get; set; }
    public int agility { get; set; }
    public int Resistance { get; set; }
    public int Anger { get; set; }
    public int Strength { get; set; }
    public Equipment Equip1 { get; set; }
    public Equipment Equip2 { get; set; }
    public Equipment Equip3 { get; set; }
    public Equipment Equip4 { get; set; }
    public Equipment Equip5 { get; set; }
    public Equipment Equip6 { get; set; }

    #endregion



}