using UnityEngine;
using System.Collections;



/// <summary>
/// Author: Joseph Gravelle
/// Project Name: Pause2
/// File Name: Pause
/// Date Created: January 14, 2014
/// Date Modified, January 20, 2014
/// Description: This class controls what happens when an object is picked up by the mouse.
/// </summary>
public class Pause : MonoBehaviour 
{
	Vector3 objectLocation;	//Used to determine the new location of the object
	
	//Pre: Mouse has to be on screen
	//Post: Returns the object's location, with Z defaulting to 0.
	//Description: Checks for the mouse's position in world units, instead of screen units.
	void Update () 
	{
		objectLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		objectLocation.z = 0;
	}

	//Pre: Mouse clicked down on object
	//Post: Hides the cursor
	//Description: Hides the cursor when the object is clicked
	void OnMouseDown()
	{
		Screen.showCursor = false;	//Hides the cursor when an object is picked up
	}

	//Pre: timeScale has to equal 0, mouse is dragging the object
	//Post: Moves the object around
	//Description: Only operating when time is frozen, 
	void OnMouseDrag()
	{
		if (Time.timeScale < 0.01f)
		{
			transform.position = objectLocation;	//Objects old position is equal to the new location of the object.
		} 
	}

	//Pre: Mouse not clicked on object
	//Post: Shows the cursor
	//Description: When the mouse is lifted from an object, shows the cursor again.
	void OnMouseUp()
	{
		Screen.showCursor = true;	//Shows the cursor if it's not dragging an object.
	}

}