using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class VirtualImageMoveScript : MonoBehaviour
{
	// 声明一个委托类型
	public delegate void OnCoorChangedDelegate (Vector3 coor);

	public OnCoorChangedDelegate OnPointCoorChanged;

	// 1.小球初始点
	Vector3 startPoint;

	// 2.半径
	float r;

	void Start ()
	{
		startPoint = transform.position;
		r = Screen.width * 0.23f / 2;
	}

	// 拖拽方法
	public void OnPointDragAction (BaseEventData bd)
	{
		// 如果在半径内
		if (Vector3.Distance (Input.mousePosition, startPoint) < r) {
			transform.position = Input.mousePosition;
		} else {
			Vector3 dir = Input.mousePosition - startPoint;
			transform.position = startPoint + dir.normalized * r;
		}
	}

	// 抬起鼠标
	public void OnPointUpAction (BaseEventData bd)
	{
		transform.position = startPoint;
	}

	void Update ()
	{
		Vector3 newDir = (transform.position - startPoint).normalized;
		OnPointCoorChanged (newDir);
	}
}
