using UnityEngine;
using System.Collections;

public class WolfSight : MonoBehaviour {

	// 能够看到玩家
	public bool playerInSight = false;
	// 机器人视野夹角
	public float fieldOfView = 110f;
	// 机器人视野距离
	private float distanceOfView;
	// 机器人触发器
	private SphereCollider sph;
	// 上一帧的公共警报位置
	private Vector3 previousAlarmPosition;
	// 射线碰撞检测器
	private RaycastHit hit;
	// 导航组件
	private NavMeshAgent nav;
	// 玩家血量脚本
	private SorcererHealth playerHealth;
	// 机器人的视野范围但不是攻击范围
	// private Vector3 personalAlarmPosition;

	void Awake () {
		//获取触发器
		sph = GetComponent<SphereCollider> ();
		nav = GetComponent<NavMeshAgent> ();
		playerHealth = GameObject.FindWithTag (Tags.Player).GetComponent<SorcererHealth> ();
	}

	void Start () {
		//获取视野距离
		distanceOfView = sph.radius;
	}

	void OnTriggerStay (Collider other) {
		//如果是玩家
		if (other.tag == Tags.Player) {
			//重置
			playerInSight = false;
			//玩家与机器人的距离
			float distance = Vector3.Distance (other.transform.position, transform.position);
			//玩家与机器人之间的方向向量
			Vector3 dir = other.transform.position - transform.position;
			//计算机器人自身前方与方向向量之间的夹角
			float angular = Vector3.Angle (dir, transform.forward);
			//满足视野范围内和距离范围内
			if (distance < distanceOfView && angular < fieldOfView / 2) {
				if (Physics.Raycast (transform.position + Vector3.up * 1f,
					    dir, out hit)) {
					if (hit.collider.tag == Tags.Player) {
						//可以看到玩家
						playerInSight = true;
					}
				}
			}
		}
	}
		
}
