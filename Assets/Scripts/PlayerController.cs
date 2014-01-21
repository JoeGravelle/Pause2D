using UnityEngine;
using System.Collections;


/// <summary>
/// Author: Joseph Gravelle
/// Project Name: Pause2
/// File Name: PlayerConrtoller.cs
/// Creation Date: January 10, 2014
/// Modification Date: January 20, 2014
/// Description: Handles all player character movement in game, including horizontal movement, jumping, and animations for the player.
/// </summary>


public class PlayerController : MonoBehaviour {

	//Variables

	//Floats
	public float maxSpeed;				//Maximum speed the player can move
	public float jumpForce;				//How high the player can jump
	public float groundCheckRadius;		//How close an object has to be to the player to be considered "ground".
	float movementSpeed;				//How fast the player is currently moving
	float timeScale;					//The current in-game time
	//Booleans
	bool grounded = true;				//If the player is currently on the ground
	public bool isPaused = false;		//If the game is currently paused
	bool facingRight = true;			//Checks which way the player is facing. True for right, False for left
	//Other
	public Transform groundCheck;		//Where the ground should be
	public LayerMask whatIsGround;		//Self explanatory, contains information about what the ground is
	Animator animator;					//The current animator for the player

	//Pre: N/A
	//Post: Fills timeScale and animator
	//Description: Safeguards the current timeScale by storing it in a variable, and initializes the current Animator
	void Start () 
	{
		timeScale = Time.timeScale;
		animator = GetComponent<Animator> ();
	}
	
	//Pre: Game started
	//Post: Checks input, and either adds force to the player, pauses, or unpauses the game.
	//Description: Checks to see what is being inputted into the game. If it's the W key, and the player is on the ground, they will jump. 
	//			   If it's the Escape key, and time is not currently paused, the game will pause. If the game is paused, it will unpause.
	void Update () 
	{
		//If the player is on the ground and they press the W key, they will jump.
		if (grounded && Input.GetKeyDown (KeyCode.W)) 
		{
			animator.SetBool("Grounded", false);
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
	//Pre: Game started
	//Post: Character moves on screen appropriately
	//Description: Checks for horizontal movement, if the player is on ground, and adds appropriate velocity to the player.
	void FixedUpdate() 
	{
		//Player Movement

		//Controls horizontal movement
		movementSpeed = Input.GetAxis ("Horizontal");
		animator.SetFloat("Speed", Mathf.Abs(movementSpeed));

		//Checks to see if the player is currently on the ground.
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
		animator.SetBool ("Grounded", grounded);

		//Applies velocity to the player.
		rigidbody2D.velocity = new Vector2 (movementSpeed * maxSpeed, rigidbody2D.velocity.y);
		animator.SetFloat ("vertSpeed", rigidbody2D.velocity.y);

		//Flips the player sprite's direction
		if (movementSpeed > 0 && !facingRight) 
		{
			Flip ();
		}

		else if (movementSpeed < 0 && facingRight)
		{
			Flip ();
		}
	}
	//Pre: Movement Speed != 0
	//Post: Character sprite flipped
	//Description: Flips the character sprite 180 degrees when the player is facing the opposite direction. 
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
