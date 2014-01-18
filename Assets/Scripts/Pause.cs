using UnityEngine;
using System.Collections;



/// <summary>
/// Author: Joseph Gravelle
/// Project Name: Pause2
/// File Name: Pause
/// Date Created: January 14, 2014
/// Date Modified, January ##, 2014
/// Description: This class controls what happens when an object is picked up by the mouse.
/// </summary>
public class Pause : MonoBehaviour {

	//Variables
	//Booleans
	//Floats

	//Other
	Vector3 boxLoc;

	void Start () 
	{

	}
	
	void Update () 
	{
		boxLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		boxLoc.z = 0;
	}
	void OnMouseDown()
	{
		if (Time.timeScale < 0.01f) 
		{
			transform.position = boxLoc;
		}

	}
}