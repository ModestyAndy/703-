using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingUIScript : MonoBehaviour
{
	public Transform settingEndPos;
	Vector3 startPos;
	bool isOn = true;

	public Button buttonSetOn;
	public Button buttonSetOff;

	void Start ()
	{
		startPos = transform.position;
	}

	public void OnClickOn ()
	{
		
		Vector3 ver = settingEndPos.position;
		Hashtable args = new Hashtable ();
		args.Add ("speed", 500f);
		args.Add ("position", ver); 

		iTween.MoveTo (gameObject, args); 
		buttonSetOn.gameObject.SetActive (!isOn);
		buttonSetOff.gameObject.SetActive (isOn); 
	}

	public void OnClickOff ()
	{
		Hashtable args = new Hashtable ();
		args.Add ("speed", 500f);
		args.Add ("position", startPos);

		iTween.MoveTo (gameObject, args); 
		buttonSetOn.gameObject.SetActive (isOn);
		buttonSetOff.gameObject.SetActive (!isOn); 
	}
	

}
