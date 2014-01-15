using UnityEngine;
using System.Collections;


/// <summary>
/// Author: Joseph Gravelle
/// Project Name: Pause2
/// File Name: PlayerConrtoller.cs
/// Creation Date: January 10, 2014
/// Modification Date: January ##, 2014
/// Description: Handles all player character movement in game.
/// </summary>


public class PlayerController : MonoBehaviour {

	//Variables

	//Floats
	public float maxSpeed;
	public float jumpForce;
	public float groundCheckRadius;
	float movementSpeed;
	float timeScale;
	//Booleans
	bool grounded = true;
	bool isPaused = false;
	//Other
	public Transform groundCheck;
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
		timeScale = Time.timeScale;
	}
	
	// Update is called once per frame
	void Update () {
		//If the player is on the ground and they press the W key, they will jump.
		if (grounded && Input.GetKeyDown (KeyCode.W)) 
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
		//If the player presses the Escape key
		//If the game is not paused, pauses the game
		if (!isPaused && Input.GetKeyDown (KeyCode.Escape)) 
		{
			isPaused = true;
			Time.timeScale = 0.0f;
		}
		//However, if the game is paused, unpause the game.
		else if (isPaused && Input.GetKeyDown  (KeyCode.Escape))
		{
			isPaused = false;
			Time.timeScale = timeScale;
		}


	}

	void FixedUpdate() {
		//Player Movement

		//Controls horizontal movement
		movementSpeed = Input.GetAxis ("Horizontal");
		//Checks to see if the player is currently on the ground.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		//Applies the velocity to the player.
		rigidbody2D.velocity = new Vector2 (movementSpeed * maxSpeed, rigidbody2D.velocity.y);
	}

}
