//********************************************
// File Name  :         Bag.cs
// Author     :         Andy Fang
// Create Time:         10/10/2016 1:47:26 PM
//********************************************
using UnityEngine;
using System.Collections;

public class Bag
{
    #region Field

    private const int totalItemCountPerBag = 20;

    #endregion

    #region Property

    public int UserId { get; private set; }
    public BagItem[] items = new BagItem[totalItemCountPerBag];

    #endregion

    public Bag(int userId)
    {
        UserId = userId;
    }
}

public class BagItem
{
    public int Position { get; set; }
    public int EquipId { get; set; }
}