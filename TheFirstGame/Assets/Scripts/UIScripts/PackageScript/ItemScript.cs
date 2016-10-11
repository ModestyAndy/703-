using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
{

	// item放在了那个Cell中.(原来的父物体)
	Transform originalParent;

	// 拖拽时, Item的父物体.
	public Transform dragParent;

	public void OnBeginDrag (PointerEventData eventdata)
	{
		// 记录原来的父亲是谁
		originalParent = transform.parent;
		// 修改自己的父亲为dragParent
		transform.SetParent (dragParent);
		// 关掉自身的射线检测
		GetComponent<Image> ().raycastTarget = false;
	}

	public void OnDrag (PointerEventData eventdata)
	{
		transform.position = Input.mousePosition;
	}

	GameObject pointEnterObject;

	public void OnEndDrag (PointerEventData eventdata)
	{
		GetComponent<Image> ().raycastTarget = true;
		pointEnterObject = eventdata.pointerEnter;
		if (pointEnterObject == null) {
			transform.SetParent (originalParent);
			transform.localPosition = Vector3.zero;
		} else if (pointEnterObject.tag == "Cell") {
			transform.SetParent (pointEnterObject.transform);
			transform.localPosition = Vector3.zero;
		} else if (pointEnterObject.tag == "Item") {
			transform.SetParent (pointEnterObject.transform.parent);
			pointEnterObject.transform.SetParent (originalParent);
			transform.localPosition = Vector3.zero;
			pointEnterObject.transform.localPosition = Vector3.zero;
		} else {
			transform.SetParent (originalParent);
			transform.localPosition = Vector3.zero;
		}
	}
}
