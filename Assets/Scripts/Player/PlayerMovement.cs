using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	public float jumpSpeed = 1000.0f;



	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	
	void FixedUpdate ()
	{
		// Store the input axes.
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		Move (h, v);

		// Animate the player.
		Animating (h, v);
	}
	
	void Move (float h, float v)
	{
		// Find the direction the character should be moving.
		Vector3 cameraAxis = Camera.main.transform.forward; // Gets the direction the camera is pointing
		Vector3 cameraDirection = new Vector3 (cameraAxis.x, 0, cameraAxis.z);  // removes the y component
		Vector3 cameraRight = Quaternion.Euler(0, 90, 0) * cameraDirection; // gets the "right" component of the vector

		Quaternion lookDirection = Quaternion.LookRotation (cameraDirection);

		// Move the character
		movement = cameraDirection * v;
		movement += cameraRight * h;

		Quaternion characterDirection = new Quaternion();
		if (movement.magnitude != 0) {
			characterDirection = Quaternion.LookRotation (movement);
		}


		// Change character's rotation based on where he's facing.
		bool walking = h != 0f || v != 0f;
		if (walking) {
			lookDirection = Quaternion.RotateTowards (transform.rotation,characterDirection,10);
			playerRigidbody.MoveRotation (lookDirection);
		}

		// Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;

		
		// Move the player to it's current position plus the movement.

		playerRigidbody.MovePosition (transform.position + movement);


	}
	

	
	void Animating (float h, float v)
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = h != 0f || v != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
		anim.SetFloat ("speed", v);
		if (Input.GetKeyDown("space")) { 
			anim.SetTrigger ("spin");
		}
	}
}