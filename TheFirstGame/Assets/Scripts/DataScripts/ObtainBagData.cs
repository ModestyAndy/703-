//********************************************
// File Name  :         ObtainBagData.cs
// Author     :         Andy Fang
// Create Time:         10/10/2016 1:43:56 PM
//********************************************
using System.Collections;
using System.Collections.Generic;

public class ObtainBagData
{
    #region Singleton

    private static ObtainBagData instance;

    private ObtainBagData()
    {
        sDb = ShareDatabase.sDb;
    }

    public static ObtainBagData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObtainBagData ();
            }
            return instance;
        }
    }

    #endregion

    #region Variable

    ShareDatabase sDb;

    #endregion

    #region Public Method

    public void AddEquipment(int userId, int equipId)
    {
        // TODO: 
        //string sql = string.Format("INSERT INTO bag set ")
    }

    public Bag GetBag(int userId)
    {
        Bag bag = new Bag(userId);

        string sql = string.Format("SELECT position, equip_id FROM bag WHERE user_id = {0}", userId);
        List<ArrayList> list = sDb.SelectResultSql (sql);

        BagItem item = new BagItem();

        for (int i = 0; i < list.Count; i++)
        {
            int position = int.Parse(list[i][0].ToString());
            int equipId = int.Parse(list[i][1].ToString());
            item.Position = position;
            item.EquipId = equipId;
            bag.items[position] = item;
        }

        return bag;
    }

    public void MoveEquipment(BagItem from, BagItem to)
    {
        // update position
        string sql = string.Format("UPDATE bag set position = {0} WHERE position = {1}", to.Position , from.Position);
        sDb.ExecSql (sql);
    }

    public void SwitchEquipments (BagItem item1, BagItem item2)
    {
        //update position
        string sql = string.Format("UPDATE bag set position = {0} WHERE position = {1}", item2.Position, item1.Position);
        sDb.ExecSql (sql);
        sql = string.Format ("UPDATE bag set position = {0} WHERE equip_id = {1}", item1.Position, item1.EquipId);
        sDb.ExecSql (sql);
    }



    #endregion
    
}