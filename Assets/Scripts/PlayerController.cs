using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	//Variables

	//Floats
	public float maxSpeed;
	public float jumpForce;
	public float groundCheckRadius;
	float movementSpeed;
	//Booleans
	bool grounded = true;
	//Other
	public Transform groundCheck;
	public LayerMask whatIsGround;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//If the player is on the ground and they press the Spacebar, they will jump.
		if (grounded && Input.GetKeyDown (KeyCode.Space)) 
		{
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
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
