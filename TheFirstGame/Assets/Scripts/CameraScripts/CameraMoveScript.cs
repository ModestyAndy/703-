//********************************************
// File Name  :         CameraMoveScript.cs
// Author     :         Andy Fang
// Create Time:         10/11/2016 4:54:53 PM
//********************************************
using UnityEngine;
using System.Collections;

public class CameraMoveScript : MonoBehaviour
{

    public Transform player;

    private float height = 8;
    private float distance = 15;

    Vector3 target;

    void Update()
    {
        target = new Vector3 (player.position.x, player.position.y + height, player.position.z - distance);
        MoveToTarget (target);
    }

    private void MoveToTarget(Vector3 target)
    {
        transform.position = target;
    }
}