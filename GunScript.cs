using UnityEngine;
using System.Collections;

public class GunScript : MonoBehaviour 
{
	public GameObject SoundObject;
	SoundScript soundScript;
	public GameObject Crosshair;
	public GameObject UIHolder;
	CrosshairScript CHScript;
	public bool IsReloading;
	public bool GameStarted;
	public GameObject pf_Bird;
	public GameObject StartScreen;
	public TextMesh InGameRound;
	public int BirdsLeft;
	bool stupid;
	Quaternion target;
	public int Round = 0;
	int shots = 3;

	void Start()
	{
		CHScript = Crosshair.GetComponent<CrosshairScript>();
		soundScript = SoundObject.GetComponent<SoundScript>();
		stupid=true;
	}
	void Update() 
	{
		if(GameStarted==true){
			Time.timeScale = 1.0F;
			UIHolder.SetActive(true);
		}
		else{
			Time.timeScale = 0.0f;
			UIHolder.SetActive(false);
		}
		transform.LookAt(Crosshair.transform.position);
		if(GameStarted==true)
		{
			if(Input.GetMouseButtonDown(0))
			{
				if(GameStarted==true)
				{
					if(IsReloading==false)
					{
						if(stupid==false)
						{
							StartCoroutine(Shot());
						}
					}
				}
				stupid = false;
			}
		}

		if(BirdsLeft<=0)
		{
			NewRound();
		}
	}

	void NewRound()
	{
		Round+=1;
		stupid=true;
		InGameRound.text="Round"+Round;
		PlayerPrefs.SetInt("Player Score", Round);
		BirdsLeft=Round;
		GameStarted=false;
		StartScreen.SetActive(true);
		int i = 0;
		while (i < Round) 
		{
			Instantiate(pf_Bird, new Vector3(Random.Range(-4f,(-4f-(Round/2))), 0.5f, 1.9f),Quaternion.identity);
			i++;
		}
	}

	IEnumerator Shot()
	{
		soundScript.Fire.Play();
		transform.Find("shotty2").GetComponent<Animation>().Play();
		IsReloading=true;
		yield return new WaitForSeconds(0.8f);
		IsReloading=false;
	}
}