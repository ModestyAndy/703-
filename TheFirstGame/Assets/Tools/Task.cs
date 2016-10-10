//********************************************
// File Name  :         Task.cs
// Author     :         Andy Fang
// Create Time:         10/10/2016 11:30:00 AM
//********************************************
using UnityEngine;
using System.Collections;

public class Task
{
    #region Property

    public int ID { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    // NPC
    public string Content { get; set; }
    public float Experience { get; set; }
    //注： 0. 未接受； 1. 已接受； 2. 已完成，未交付；3. 已完成，已交付；
    public int Status { get; set; }

    #endregion
}