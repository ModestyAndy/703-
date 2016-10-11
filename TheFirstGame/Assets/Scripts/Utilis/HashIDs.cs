using UnityEngine;
using System.Collections;

public class HashIDs : MonoBehaviour {

	public static int Speed;
	public static int Dead;
	public static int LocomotionState;
	public static int Run;
	public static int Attack;

	void Awake () {
		Speed = Animator.StringToHash ("Speed");
		Dead = Animator.StringToHash ("Dead");
		LocomotionState = Animator.StringToHash ("Locomotion");
		Run = Animator.StringToHash ("Run");
		Attack = Animator.StringToHash ("Attack");

	}
}
