using UnityEngine;
using System.Collections;

public class SorcererMovement : MonoBehaviour {
	//转身速度
	public float turnSpeed = 10;
	//操纵键变量
	private float hor, ver;
	//动画组件
	private Animator ani;
	//声音组件
	private AudioSource aud;
	private SorcererHealth playerHealth;

	void Awake () {
		ani = GetComponent<Animator> ();
		aud = GetComponent<AudioSource> ();
		playerHealth = GetComponent<SorcererHealth> ();
	}

	void Update () {
		if (playerHealth.health > 0) {
			//获取用户的按键情况
			hor = Input.GetAxis ("Horizontal");
			ver = Input.GetAxis ("Vertical");
			// transform.position += transform.forward * Time.deltaTime * ver * 3;
		} else {
			hor = 0;
			ver = 0;
		}

		//如果用户按下了方向键
		if (hor != 0 || ver != 0) {
			//动画参数Speed渐变到5.5（奔跑动画）
			ani.SetFloat (HashIDs.Speed, 5.5f, 0.1f, Time.deltaTime);
			//玩家转向
			TurnDir (hor, ver);
		} else {
			//立刻停下来
			ani.SetFloat (HashIDs.Speed, 0);
		}
		//执行脚步声控制
		FootSteps ();
	}

	/// <summary>
	/// 玩家转向
	/// </summary>
	/// <param name="hor">Hor.</param>
	/// <param name="ver">Ver.</param>
	void TurnDir (float hor, float ver) {
		//拿到方向向量
		Vector3 dir = new Vector3 (hor, 0, ver);
		//将方向向量转换成四元数（参考Y轴）
		Quaternion qua = Quaternion.LookRotation (dir);
		//玩家转向到该方向
		transform.rotation = Quaternion.Lerp (transform.rotation,
			qua, Time.deltaTime * turnSpeed);
	}

	void FootSteps () {
		//如果当前玩家正在播放Locomotion正常行走的动画
		if (ani.GetCurrentAnimatorStateInfo (0).shortNameHash
		    == HashIDs.LocomotionState) {
			//如果脚步声没有播放
			if (!aud.isPlaying) {
				//播放
				aud.Play ();
			}
		} else {
			//停止播放脚步声
			aud.Stop ();
		}
	}
}