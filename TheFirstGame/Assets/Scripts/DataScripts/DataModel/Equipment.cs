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

    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Part { get; private set; }
    public int Hp { get; private set; }
    public int Mp { get; private set; }
    public int Intelligence { get; private set; }
    public int Agility { get; private set; }
    public int Resistance { get; private set; }
    public int Anger { get; private set; }
    public int Strength { get; private set; }
    public int Price { get; private set; }

    public Equipment (int id, string name, int part, int hp, int mp, int intelligence, int agility, int resistance, int anger, int strength, int price)
    {
        ID = id;
        Name = name;
        Part = part;
        Hp = hp;
        Mp = mp;
        Intelligence = intelligence;
        Agility = agility;
        Resistance = resistance;
        Anger = anger;
        Strength = strength;
        Price = price;
    }

    #endregion
}