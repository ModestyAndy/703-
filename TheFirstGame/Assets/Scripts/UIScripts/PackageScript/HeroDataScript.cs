using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Net.Mail;

public class HeroDataScript : MonoBehaviour
{
	int userId = 0;
	ObtainPlayerData playerData;
	Text levelText;
	GameObject[] objs;
	public Text hp;
	public Text mp;
	public Text intelligence;
	public Text agility;
	public Text resistance;
	public Text anger;
	public Text strength;
	public Text playerName;
	public Text coinText;
	public Image playerImage;

	void Awake ()
	{
		playerData = ObtainPlayerData.Instance;
	}

	void Start ()
	{
		objs = GameObject.FindGameObjectsWithTag ("level"); 

	}

	public void OnClick ()
	{
		foreach (GameObject item in objs) {
			item.transform.GetComponent<Text> ().text = playerData.GetPlayerInfo (userId).Level.ToString ();
		}
		hp.text = playerData.GetPlayerInfo (userId).Hp.ToString ();
		intelligence.text = playerData.GetPlayerInfo (userId).Intelligence.ToString ();
		agility.text = playerData.GetPlayerInfo (userId).agility.ToString ();  
		resistance.text = playerData.GetPlayerInfo (userId).Resistance.ToString ();
		anger.text = playerData.GetPlayerInfo (userId).Anger.ToString ();
		strength.text = playerData.GetPlayerInfo (userId).Strength.ToString ();  
		coinText.text = playerData.GetPlayerInfo (userId).Coin.ToString ();
		playerName.text = playerData.GetPlayerInfo (userId).Name.ToString (); 

		if (playerData.GetPlayerInfo (userId).ProfessionId == 1) {
			playerImage.sprite = Resources.Load<Sprite> ("Master") as Sprite; 
		} else if (playerData.GetPlayerInfo (userId).ProfessionId == 2) {
			playerImage.sprite = Resources.Load<Sprite> ("swardman") as Sprite; 
		} else {
			playerImage.sprite = null;
		}
	}

}
