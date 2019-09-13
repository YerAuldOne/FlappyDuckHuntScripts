using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {
	public AudioSource Fire;
	public AudioSource Coin;
	public AudioSource Die;
	public AudioSource Flap;
	AudioSource[] aSources;
	// Use this for initialization
	void Start () {
		aSources = GetComponents<AudioSource>();
		Coin = aSources[0];
		Fire = aSources[1];
		Die = aSources[2];
		Flap = aSources[3];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
