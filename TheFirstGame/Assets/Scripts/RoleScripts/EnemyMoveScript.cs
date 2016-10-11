//********************************************
// File Name  :         EnemyMoveScript.cs
// Author     :         Andy Fang
// Create Time:         9/29/2016 7:41:13 PM
//********************************************
using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {
	/// <summary>
	/// 攻击的间隔
	/// </summary>
	private float attack_Timer = 2f;
	private Vector3 burnPos;

	private Vector3 targetPos;

	//private Vector3 findPlayerPos;

	private NavMeshAgent m_nav;

	private float timer;
	private float waitTime = 2f;

	private bool isPlayerIn = false;
	private bool findPlayer = false;
	private float maxPursueDistanse = 15f;
	private Animator ani;
	private GameObject player;


	void Awake () {
		m_nav = GetComponent<NavMeshAgent> ();
		ani = GetComponent<Animator> ();
		burnPos = transform.position;
		targetPos = GenerateTarget (burnPos);
		MoveToTarget (targetPos);
	}

	void Update () {
		if (!findPlayer) {
			MoveToTarget (targetPos);
		}

		if (player != null) {
			PursuePlayer (player.transform.position);
		}

		if (!isPlayerIn && Vector3.Distance (transform.position, burnPos) > maxPursueDistanse) {
			findPlayer = false;
			player = null;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag.Equals ("Player")) {
			if (player != null) {
				return;
			}
			//findPlayerPos = transform.position;
			//isBacking = false;

			player = other.gameObject;
			isPlayerIn = true;
			findPlayer = true;
			PursuePlayer (other.transform.position);
		}
	}

	void OnTriggerExit (Collider other) {
		isPlayerIn = false;
	}

	private Vector3 GenerateTarget (Vector3 partrolCenter) {
		return new Vector3 (partrolCenter.x + Random.Range (-5, 5), partrolCenter.y, partrolCenter.z + Random.Range (-5, 5));

	}

	private void MoveToTarget (Vector3 target) {
		m_nav.SetDestination (targetPos);
		ani.SetBool (HashIDs.Run, true);
		if (Vector3.Distance (transform.position, target) < 0.5f) {
			timer += Time.deltaTime;
			ani.SetBool (HashIDs.Run, false);
			if (timer > waitTime) {
				timer = 0;
				targetPos = GenerateTarget (burnPos);
			}
		}
	}

	private void PursuePlayer (Vector3 player) {
		m_nav.SetDestination (player);
		ani.SetBool (HashIDs.Run, true);
		if (Vector3.Distance (transform.position, player) < 1f) {
			m_nav.Stop ();
			ani.SetBool (HashIDs.Run, false);
			ani.SetTrigger (HashIDs.Attack);
		}
	}
}