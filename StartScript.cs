using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour 
{
	SoundScript soundScript;
	GunScript gScript;
	public GameObject gObject;
	public TextMesh RoundText;

	// Use this for initialization
	void Start () 
	{
		gScript = gObject.GetComponent<GunScript>();
		soundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
	}

	void Update(){
		RoundText.text="Round "+gScript.Round;
	}

	void OnMouseDown () 
	{
		soundScript.Coin.Play();
		gScript.GameStarted=true;
		gameObject.SetActive(false);
	}
}
