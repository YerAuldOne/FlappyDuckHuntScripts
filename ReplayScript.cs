using UnityEngine;
using System.Collections;

public class ReplayScript : MonoBehaviour {
	public TextMesh RoundNumber;
	public TextMesh HSNo;
	// Use this for initialization
	void Start () {
		Cursor.visible=true;
		RoundNumber.text=""+PlayerPrefs.GetInt("Player Score");
		if(PlayerPrefs.GetInt("Player Score") > PlayerPrefs.GetInt("High Score")){
		PlayerPrefs.SetInt("High Score",PlayerPrefs.GetInt("Player Score"));
		}
		HSNo.text=""+PlayerPrefs.GetInt("High Score");
		KongregateAPI.SubmitStatistic("High Score", PlayerPrefs.GetInt("High Score"));
		PlayerPrefs.Save();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		PlayerPrefs.DeleteKey("Player Score");
		Application.LoadLevel(0);
	}
}
