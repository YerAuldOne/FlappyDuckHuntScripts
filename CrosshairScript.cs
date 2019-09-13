using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour {
	Vector3 v;
	float maxX=5.2f;
	float maxY=3.2f;
	float minX=-5.6f;
	float minY=-2f;
	// Use this for initialization
	void Start () 
	{
		Cursor.visible=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		v=new Vector3(Input.mousePosition.x,Input.mousePosition.y,10);
		transform.position=Camera.main.ScreenToWorldPoint(v);

		// If Player's X exceeds minX or maxX..
		if (transform.position.x <= minX || transform.position.x >= maxX)
		{
			// Create values between this range (minX to maxX) and store in xPos
			float xPos = Mathf.Clamp(transform.position.x, minX + 0.1f, maxX);
			
			// Assigns these values to the Transform.position component of the Player
			transform.position = new Vector3(xPos, transform.position.y, 
			                                 transform.position.z); 
		}
		
		// If Player's Y exceeds minY or maxY..
		if (transform.position.y <= minY || transform.position.y >= maxY)
		{
			// Create values between this range (minY to maxY) and store in yPos
			float yPos = Mathf.Clamp(transform.position.y, minY, maxY);
			
			// Assigns these values to the Transform.position component of the Player
			transform.position = new Vector3(transform.position.x, yPos, 
			                                 transform.position.z);
		}
	}
}
