//********************************************
// File Name  :         Equipment.cs
// Author     :         Andy Fang
// Create Time:         10/9/2016 7:38:17 PM
//********************************************

/// <summary>
/// The data model of equipments.
/// </summary>
public class Equipment
{
    #region Propertity

    public int ID { get; set; }
    public string name { get; set; }
    public int Part { get; set; }
    public int Hp { get; set; }
    public int Mp { get; set; }
    public int Intelligence { get; set; }
    public int agility { get; set; }
    public int Resistance { get; set; }
    public int Anger { get; set; }
    public int Strength { get; set; }
    public int Price { get; set; }

    #endregion
}