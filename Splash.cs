using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1);
		Application.LoadLevel(1);
	}
}
