using UnityEngine;
using System.Collections;

public class WolfMoveScript : MonoBehaviour {
	//巡逻点
	public Transform[] wayPoints;
	//追捕速度
	public float chasingSpeed = 6f;
	//巡逻速度
	public float patrallingSpeed = 2.5f;
	//巡视时间
	public float chasingWaitTime = 3f;

	//追捕等待计时器
	private float chasingTimer;
	//巡逻等待计时器
	private float patrallingTimer;
	private WolfSight enemySight;
	private NavMeshAgent nav;
	//巡逻目标索引号
	private int index;
	private SorcererHealth playerHealth;

	void Awake () {
		enemySight = GetComponent<WolfSight> ();
		nav = GetComponent<NavMeshAgent> ();
		playerHealth = GameObject.FindWithTag (Tags.Player).GetComponent<SorcererHealth> ();
		index = 0;
	}

	void Update () {
		if (enemySight.playerInSight && playerHealth.health > 0) {
			//射击
			Shooting ();
//		} else if (enemySight.personalAlarmPosition && playerHealth.health > 0) {
//			//追捕
//			Chasing ();
		} else {
			//巡逻
			Patrolling ();
		}
	}

	/// <summary>
	/// 射击
	/// </summary>
	void Shooting () {
		//导航停止
		nav.Stop ();
	}

	/// <summary>
	/// 追捕
	/// </summary>
	//	void Chasing () {
	//		//恢复导航
	//		nav.Resume ();
	//		//加快速度
	//		nav.speed = chasingSpeed;
	//		//设置导航目标
	//			nav.SetDestination (enemySight.personalAlarmPosition);
	//		//到达了警报位置
	//		if (nav.remainingDistance - nav.stoppingDistance < 0.5f) {
	//			//追捕等待计时器计时
	//			chasingTimer += Time.deltaTime;
	//			//达到等待时间
	//			if (chasingTimer > chasingWaitTime) {
	//				//重置计时器
	//				chasingTimer = 0;
	//			}
	//		} else {
	//			//重置计时器
	//			chasingTimer = 0;
	//		}
	//	}

	/// <summary>
	/// 巡逻
	/// </summary>
	void Patrolling () {
		//巡逻速度
		nav.speed = patrallingSpeed;
		//设置寻路目标
		nav.SetDestination (wayPoints [index].position);
		//到达巡逻点
		if (nav.remainingDistance - nav.stoppingDistance < 0.5f) {
			//计时器计时
			patrallingTimer += Time.deltaTime;
			//计时器完成本次计时
			if (patrallingTimer > chasingWaitTime) {
				//更新下一个巡逻点索引号
				//				index = ++index % wayPoints.Length;
				index++;
				index = index % wayPoints.Length;
				//计时器清零
				patrallingTimer = 0;
			}
		} else {
			//计时器清零
			patrallingTimer = 0;
		}
	}
}
