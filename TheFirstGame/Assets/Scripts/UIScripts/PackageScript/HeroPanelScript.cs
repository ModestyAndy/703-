using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroPanelScript : MonoBehaviour
{
	int userId = 0;
	ObtainPlayerData playerData;
	public Image playerImage;
	public Text playerName;
	public Slider hpSlider;
	public Text mpAngerName;

	void Awake ()
	{
		playerData = ObtainPlayerData.Instance;
	}

	void Update ()
	{
		if (playerData.GetPlayerInfo (userId).ProfessionId == 1) {
			playerImage.sprite = Resources.Load<Sprite> ("Master") as Sprite; 
			mpAngerName.text = "蓝量"; 
		} else if (playerData.GetPlayerInfo (userId).ProfessionId == 2) {
			playerImage.sprite = Resources.Load<Sprite> ("swardman") as Sprite; 
			mpAngerName.text = "怒气";
		} else {
			playerImage.sprite = null;
		}

		playerName.text = playerData.GetPlayerInfo (userId).Name.ToString (); 
		hpSlider.value = playerData.GetPlayerInfo (userId).Hp; 
	
	}

}
