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
	public bool isPaused = false;
	bool facingRight = true;
	//Other
	public Transform groundCheck;
	public LayerMask whatIsGround;
	Animator animator;

	// Use this for initialization
	void Start () 
	{
		timeScale = Time.timeScale;
		animator = GetComponent<Animator> ();
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
		animator.SetFloat("Speed", Mathf.Abs(movementSpeed));
		//Checks to see if the player is currently on the ground.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		//Applies the velocity to the player.
		rigidbody2D.velocity = new Vector2 (movementSpeed * maxSpeed, rigidbody2D.velocity.y);
		if (movementSpeed > 0 && !facingRight) 
		{
			Flip ();
		}
		else if (movementSpeed < 0 && facingRight)
		{
			Flip ();
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
