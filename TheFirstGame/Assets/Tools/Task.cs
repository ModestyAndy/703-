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

    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Level { get; private set; }
    // NPC
    public string Content { get; private set; }
    public int Experience { get; private set; }
    //ע�� 0. δ���ܣ� 1. �ѽ��ܣ� 2. ����ɣ�δ������3. ����ɣ��ѽ�����
    public int Status { get; private set; }

    #endregion

    public Task(int id, string name, int level, string content, int status)
    {
        ID = id;
        Name = name;
        Level = level;
        Content = content;
        Status = status;
    }
}