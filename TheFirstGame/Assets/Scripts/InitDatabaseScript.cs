//********************************************
// File Name  :         InitDatabaseScript.cs
// Author     :         Andy Fang
// Create Time:         9/6/2016 2:52:09 PM
//********************************************
using UnityEngine;

public class InitDatabaseScript : MonoBehaviour
{

    #region Unity Callback Method

    void Start ()
    {
        //PlayerPrefs.DeleteAll ();
        if (!PlayerPrefs.HasKey ("FirstRun"))
        {
            InitDataBaseAction ();
            PlayerPrefs.SetString ("FirstRun", "");
        }
    }

    #endregion


    #region Private Method

    private void InitDataBaseAction ()
    {
        #region Create Tables

        // 1. Login Table
        string sql = string.Format("CREATE TABLE IF NOT EXISTS login(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, username TEXT NOT NULL, password TEXT NOT NULL, online BOOL DEFAULT false)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 2. Player Level Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS player (user_id INTEGER REFERENCES login(id), prefession TEXT NOT NULL, level INTEGER DEFAULT 1, expreience INTEGER DEFAULT 0, hp INTEGER DEFAULT 0, mp INTEGER DEFAULT 0, intelligence INTEGER DEFAULT 0, agility INTEGER DEFAULT 0, resistance INTEGER DEFAULT 0, anger INTEGER DEFAULT 0, strength INTEGER DEFAULT 0, equipment_id_1 INTEGER REFERENCES equipment(id), equipment_id_2 INTEGER REFERENCES equipment(id), equipment_id_3 INTEGER REFERENCES equipment(id),  equipment_id_4 INTEGER REFERENCES equipment(id), equipment_id_5 INTEGER REFERENCES equipment(id), equipment_id_6 INTEGER REFERENCES equipment(id))");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 3. Experience Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS experience(level INTEGER NOT NULL, experience INTEGER NOT NULL)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 4. Profession Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS profession(pro_id INTEGER UNIQUE PRIMARY KEY NOT NULL, pro_name TEXT UNIQUE NOT NULL, skill_id_1 INTEGER REFERENCES skills(skill_id), skill_id_2 INTEGER REFERENCES skills(skill_id), skill_id_3 INTEGER REFERENCES skills(skill_id), skill_id_4 INTEGER REFERENCES skills(skill_id))");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 5. Equipment Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS equipment(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,equip_name TEXT UNIQUE NOT NULL, part INTEGER NOT NULL, hp INTEGER DEFAULT 0, mp INTEGER DEFAULT 0, intelligence INTEGER DEFAULT 0, agility INTEGER DEFAULT 0, resistance INTEGER DEFAULT 0, anger INTEGER DEFAULT 0, strength INTEGER DEFAULT 0, price INTEGER DEFAULT 1)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 6. Skills Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS skills(skill_id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, skill_name TEXT UNIQUE NOT NULL)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 7. Player Skill Status Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS player_skill_status(user_id INTEGERS REFERENCES login(id), skill_id INTEGER REFERENCES skills(id), skill_level INTEGER DEFAULT 0)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 8. Monster Info Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS monster(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, level INTEGER NOT NULL, name TEXT NOT NULL, type INTEGER NOT NULL, hp INTEGER NOT NULL, attack INTEGER NOT NULL, experience INTEGER NOT NULL, skill_id INTEGER REFERENCES skills(skill_id), drop_equip_id_1 INTEGER REFERENCES equipment(id), drop_equip_id_2 INTEGER REFERENCES equipment(id), drop_equip_id_3 INTEGER REFERENCES equipment(id), drop_equip_id_4 INTEGER REFERENCES equipment(id), drop_equip_id_5 INTEGER REFERENCES equipment(id), drop_equip_id_6 INTEGER REFERENCES equipment(id))");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 9. Tasks Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS tasks(id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, task_name TEXT UNIQUE NOT NULL, task_level INTEGER NOT NULL, task_content TEXT NOT NULL, task_experience INTEGER NOT NULL, task_status INTEGER DEFAULT 0)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 10. Bag Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS bag (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, user_id INTEGER REFERENCES login(id), position INTEGER NOT NULL, equip_id INTEGER REFERENCES equipment(id))");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        // 11. NPC Table
        sql = string.Format ("CREATE TABLE IF NOT EXISTS npc (id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, name TEXT NOT NULL");

        #endregion

        #region Insert Data

        #region Insert skills Table

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "变羊");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "暴风雪");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "寒冰箭");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "寒冰炸弹");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "冲锋");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "雷霆一击");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "霸刃");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "旋风斩");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "火球术");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO skills (skill_name) VALUES ('{0}')", "铁拳");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Insert Profression Table

        sql = string.Format ("INSERT INTO profession (pro_id, pro_name, skill_id_1, skill_id_2, skill_id_3, skill_id_4) VALUES (1, '{0}', 1, 2, 3, 4)", "法师");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO profession (pro_id, pro_name, skill_id_1, skill_id_2, skill_id_3, skill_id_4) VALUES (2, '{0}', 5,6,7,8)", "战士");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Insert Experience Table

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (1, 100)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (2, 200)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (3, 300)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (4, 400)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (5, 500)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (6, 600)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (7, 700)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (8, 800)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO experience (level, experience) VALUES (9, 900)");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Insert Equipment Table 
        // PART ： 0. 不可装备物品；1. 头部；2. 胸部；3. 腿部；4. 鞋；5. 左手；6. 右手；

        #region Insert Goods

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 0, 0, 0, 0, 0, 0, 0, 0, 1)", "金币");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 0, 50, 0, 0, 0, 0, 0, 0, 20)", "生命药水");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 0, 0, 50, 0, 0, 0, 0, 0, 20)", "法力药水");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 0, 0, 0, 0, 0, 0, 50, 0, 20)", "怒气药水");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Sor Head equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 10, 10, 20, 10, 10, 0, 0, 30)", "法师兜帽");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 20, 20, 30, 20, 20, 0, 0, 40)", "法魂兜帽");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 30, 30, 40, 30, 30, 0, 0, 50)", "夜空兜帽");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 40, 40, 50, 40, 40, 0, 0, 60)", "神圣头巾");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 50, 50, 60, 50, 60, 0, 0, 70)", "神圣王冠");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Sor Chest Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 20, 20, 30, 20, 20, 0, 0, 40)", "法师外衣");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 30, 30, 40, 30, 30, 0, 0, 50)", "法魂外衣");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 40, 40, 50, 40, 40, 0, 0, 60)", "夜空外套");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 50, 50, 60, 50, 50, 0, 0, 70)", "神圣布甲");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 60, 60, 70, 60, 70, 0, 0, 80)", "神圣法衣");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Sor Leg Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 15, 15, 25, 15, 15, 0, 0, 40)", "法师护腿");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 25, 25, 35, 25, 25, 0, 0, 50)", "法魂护腿");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 30, 30, 40, 30, 30, 0, 0, 60)", "夜空长裤");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 40, 40, 50, 40, 40, 0, 0, 70)", "神圣护腿");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 50, 50, 60, 50, 60, 0, 0, 80)", "神圣长裤");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Sor Shoe Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 10, 10, 20, 10, 10, 0, 0, 30)", "法师布鞋");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 20, 20, 30, 20, 20, 0, 0, 40)", "法魂软鞋");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 30, 30, 40, 30, 30, 0, 0, 50)", "夜空战靴");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 40, 40, 50, 40, 40, 0, 0, 60)", "神圣软鞋");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 50, 50, 60, 50, 60, 0, 0, 70)", "神圣战鞋");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Sor Weapon Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 10, 30, 30, 0, 0, 0, 0, 100)", "长杆法杖");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 20, 40, 40, 0, 0, 0, 0, 200)", "学徒法杖");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 30, 50, 50, 0, 0, 0, 0, 300)", "元素法杖");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 40, 60, 60, 0, 0, 0, 0, 400)", "法师之杖");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 50, 70, 70, 0, 0, 0, 0, 500)", "神圣之杖");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Warrior Head Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 10, 0, 0, 10, 20, 10, 20, 30)", "铬铁头盔");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 20, 0, 0, 20, 30, 20, 30, 40)", "钢质头盔");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 30, 0, 0, 30, 40, 30, 40, 50)", "秘银战盔");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 40, 0, 0, 40, 50, 40, 50, 60)", "神圣面甲");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 1, 50, 0, 0, 50, 60, 50, 60, 70)", "神圣战盔");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Warrior Chest Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 20, 0, 0, 20, 30, 20, 30, 40)", "铬铁胸甲");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 30, 0, 0, 30, 40, 30, 40, 50)", "钢质胸甲");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 40, 0, 0, 40, 50, 40, 50, 60)", "秘银胸铠");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 50, 0, 0, 50, 60, 50, 60, 70)", "神圣胸甲");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 2, 60, 0, 0, 60, 70, 60, 70, 80)", "神圣胸铠");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Warrior Leg Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 15, 0, 0, 15, 25, 15, 25, 40)", "铬铁腿甲");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 25, 0, 0, 25, 35, 25, 35, 50)", "钢质腿甲");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 35, 0, 0, 35, 45, 35, 45, 60)", "秘银腿铠");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 45, 0, 0, 45, 55, 45, 55, 70)", "神圣腿甲");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 3, 55, 0, 0, 55, 65, 55, 65, 80)", "神圣腿铠");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Warrior Shoe Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 10, 0, 0, 10, 20, 10, 20, 30)", "铬铁长靴");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 20, 0, 0, 20, 30, 20, 30, 40)", "钢质长靴");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 30, 0, 0, 30, 40, 30, 40, 50)", "秘银战靴");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 40, 0, 0, 40, 50, 40, 50, 60)", "神圣长靴");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 4, 50, 0, 0, 50, 60, 50, 60, 70)", "神圣战靴");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Warrior Weapon Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 10, 0, 0, 0, 0, 30, 30, 80)", "单手剑");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 10, 0, 0, 0, 0, 40, 40, 160)", "北地短剑");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 10, 0, 0, 0, 0, 50, 50, 240)", "长剑");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 10, 0, 0, 0, 0, 60, 60, 320)", "血刃");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 5, 10, 0, 0, 0, 0, 70, 70, 400)", "断魂");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Warrior Shield Equipment

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 6, 20, 0, 0, 0, 20, 30, 30, 80)", "木质大盾");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 6, 30, 0, 0, 0, 30, 40, 40, 160)", "精兵盾牌");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 6, 40, 0, 0, 0, 40, 50, 50, 240)", "塔盾");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 6, 50, 0, 0, 0, 50, 60, 60, 320)", "纹章盾");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO equipment (equip_name, part, hp, mp, intelligence, agility, resistance, anger, strength, price) VALUES ('{0}', 6, 60, 0, 0, 0, 60, 70, 70, 400)", "神圣之盾");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #endregion

        #region Insert Monster Table
        // TODO: 只添加了两条数据，等怪物模型确定了再添加其它的
        // 注： 怪物类型 1. 近战； 2. 远程攻击；
        sql = string.Format ("INSERT INTO monster (level, name, type, hp, attack, experience, skill_id, drop_equip_id_1, drop_equip_id_2,drop_equip_id_3,drop_equip_id_4,drop_equip_id_5, drop_equip_id_6) VALUES (1, '{0}', 1, 50, 5, 10, 10, 1, 2, 3, 4, 5, 30)", "恶狼");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO monster (level, name, type, hp, attack, experience, skill_id, drop_equip_id_1, drop_equip_id_2,drop_equip_id_3,drop_equip_id_4,drop_equip_id_5, drop_equip_id_6) VALUES (2, '{0}', 1, 75, 7, 15, 10, 1, 2, 3, 4, 20, 45)", "大恶狼");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Insert Tasks Table

        sql = string.Format ("INSERT INTO tasks (task_name, task_level, task_content, task_experience) VALUES ('{0}', 1, '{1}', 20)", "找到村长", "找到村长，并了解当前村庄情况。");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        sql = string.Format ("INSERT INTO tasks (task_name, task_level, task_content, task_experience) VALUES ('{0}', 1, '{1}', 30)", "解决狼群麻烦", "帮助村民杀死10只恶狼。");
        ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #region Insert npc Table

        //sql = string.Format ("INSERT INTO npc SET (name) VALUES ('{0}'", "村长");
        //ObtainLoginData.Instance.sDb.ExecSql (sql);

        #endregion

        #endregion

    }

    #endregion

}