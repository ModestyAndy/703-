using UnityEngine;
using System.Collections;

public class UIMoveScript : MonoBehaviour
{
	public Vector3 homePos;

	void Start ()
	{
		homePos = transform.position;

	}

	public void OnClick (GameObject obj)
	{
		Vector3 ver = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
		Hashtable args = new Hashtable ();
		args.Add ("speed", 500f);
		args.Add ("position", ver); 

		iTween.MoveTo (obj, args); 
	}

	public void OnClickClose (GameObject obj)
	{
		
		Hashtable args = new Hashtable ();
		args.Add ("speed", 500f);
		args.Add ("position", homePos); 

		iTween.MoveTo (obj, args); 
	}

	public void OnClickAppear (GameObject obj)
	{
		obj.SetActive (true);
	}

	public void OnClickDisappear (GameObject obj)
	{
		obj.SetActive (false);
	}
}
