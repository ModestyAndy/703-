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
    //ע�� 0. δ���ܣ� 1. �ѽ��ܣ� 2. ����ɣ�δ������3. ����ɣ��ѽ�����
    public int Status { get; set; }

    #endregion
}