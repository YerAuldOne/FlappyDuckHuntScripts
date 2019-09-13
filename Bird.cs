using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	GunScript gScript;
	SoundScript soundScript;
	public GameObject gObject;
	public float tapForce;
	private bool isDead;
	float ranSpeed;
	bool IsFlapping;
	int RandomColour;
	Animator anim;

	void Start()
	{
		gScript = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>();
		soundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>();
		anim = gameObject.GetComponent<Animator>();
		InvokeRepeating("Flap", 0.15f, 0.15F);
		ranSpeed=Random.Range(0.002f,0.008f);
		RandomColour = Random.Range(1,5);
		anim.SetInteger("IntChooser",RandomColour);
	}
	void Update () 
	{
		if(transform.position.x>=3.8f){
			Application.LoadLevel(1);
		}
		if(gScript.GameStarted==true){
			Time.timeScale = 1.0F;
			if(isDead==false){
			transform.position+= new Vector3(ranSpeed,0,0);
			}
		}
		else{
			Time.timeScale = 0.0f;
		}
		//Debug.Log(transform.position.y);
		if(transform.position.y<=-0.6f){
			Flap ();
		}

		// Control the rotation of the bird based on its velocity
		transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(0f,0f,0f), Quaternion.Euler(0f,0f,90f), GetComponent<Rigidbody2D>().velocity.y);
		if (GetComponent<Rigidbody2D>().velocity.y < -.05) 
		{
			// Do the same here except only if it is falling
			transform.rotation = Quaternion.RotateTowards(Quaternion.Euler(0f,0f,0f), Quaternion.Euler(0f,0f, -90f), -GetComponent<Rigidbody2D>().velocity.y * 10f);
		}
	}
	
	// Check to see if we hit ANYTHING that's not a trigger
	void OnMouseDown()
	{
		// If we have, call the bird's die method
		if(gScript.IsReloading==false)
		{
			StartCoroutine(Die ());
		}
	}

	// Method that controls the bird's death
	IEnumerator Die()
	{
		// Set a boolean of isDead to true so that we can do some checks later
		isDead = true;
		GetComponent<Collider2D>().enabled=false;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0f, tapForce);
		yield return new WaitForSeconds(0.08f);
		soundScript.Die.Play();
		yield return new WaitForSeconds(1);
		gScript.BirdsLeft--;
		Destroy(gameObject);
	}

	void Flap()
	{
		int x = Random.Range(0,2);
		if(isDead==true){
			return;
		}
		else{
		if(transform.position.y>=1.2f){
			return;
		}
		if( x == 0)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0f, tapForce);
			soundScript.Flap.Play();
		}
		}
	}
}