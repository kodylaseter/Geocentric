using UnityEngine;

public class PlayerMovement_old : MonoBehaviour
{
	public float speed = 6f;            // The speed that the player will move at.
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	public float jumpHeight = 10;
	bool isFalling;
	Vector3 airVelocity = new Vector3 (0,0,0);
	Vector3 zero = new Vector3();



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

		if (isFalling) {
			movement = newDirection (h, v).normalized * speed * Time.deltaTime;
			inAir(movement);
		} else {
			airVelocity = new Vector3 (0,0,0);
			Move (h, v);
		}


		// Animate the player.
		Animating (h, v);
		if (Input.GetKeyDown (KeyCode.Space) && !isFalling) {
			Vector3 vel = playerRigidbody.velocity;
			vel.y = jumpHeight;
			playerRigidbody.velocity = vel;
			playerRigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
			isFalling = true;
			// Find the direction the character should be moving.
			Vector3 cameraAxis = Camera.main.transform.forward; // Gets the direction the camera is pointing
			Vector3 cameraDirection = new Vector3 (cameraAxis.x, 0, cameraAxis.z);  // removes the y component
			Vector3 cameraRight = Quaternion.Euler(0, 90, 0) * cameraDirection; // gets the "right" component of the vector
			
//			Quaternion lookDirection = Quaternion.LookRotation (cameraDirection);
			
			// Move the character
			airVelocity = cameraDirection * v;
			airVelocity += cameraRight * h;
			airVelocity = airVelocity.normalized * speed * Time.deltaTime;
		}
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
		movement = newDirection (h, v);

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

		anim.SetFloat ("speed", v);
//		if (Input.GetKeyDown("space")) { 
//			anim.SetTrigger ("spin");
//		}
		if (isFalling) {
			anim.SetBool ("isFalling",true);
		} else {
			anim.SetBool ("isFalling",false);
			anim.SetBool ("IsWalking", walking);
		}
	}

	void inAir (Vector3 movement) {

		if (!airVelocity.Equals(zero) && Vector3.Dot (airVelocity, movement) > 0) {
			Vector3 rightMovement = Quaternion.Euler(0, 90, 0) * movement;
			airVelocity = airVelocity + (Vector3.Dot (movement,rightMovement)*rightMovement)*.03f;
			airVelocity = airVelocity + movement*.01f;
		} else {
			airVelocity = airVelocity + movement*.03f;
		}


//		airVelocity = Vector3.Lerp (airVelocity, movement, 100);
//		if (h != 0 && v != 0) {
//			airVelocity = Vector3.RotateTowards (airVelocity, movement, 0.05f, 0.05f);
//			Quaternion lookDirection = Quaternion.LookRotation (airVelocity);
//			lookDirection = Quaternion.RotateTowards (transform.rotation,movement,10);
//			playerRigidbody.MoveRotation (lookDirection);
//		}
//		if (v < 0) {

//		}
		Vector3 cameraAxis = Camera.main.transform.forward; // Gets the direction the camera is pointing
		Vector3 cameraDirection = new Vector3 (cameraAxis.x, 0, cameraAxis.z);
		Quaternion lookDirection = Quaternion.LookRotation (cameraDirection);
		Quaternion characterDirection = new Quaternion();
		if (movement.magnitude != 0) {
			characterDirection = Quaternion.LookRotation (movement);
		}
		lookDirection = Quaternion.RotateTowards (transform.rotation,characterDirection,5);
		playerRigidbody.MoveRotation (lookDirection);
		playerRigidbody.MovePosition (transform.position + (airVelocity));
	}

	Vector3 newDirection (float h, float v) {
		// Find the direction the character should be moving.
		Vector3 cameraAxis = Camera.main.transform.forward; // Gets the direction the camera is pointing
		Vector3 cameraDirection = new Vector3 (cameraAxis.x, 0, cameraAxis.z);  // removes the y component
		Vector3 cameraRight = Quaternion.Euler(0, 90, 0) * cameraDirection; // gets the "right" component of the vector
		
		
		// Move the character
		movement = cameraDirection * v;
		movement += cameraRight * h;
		return movement;
	}
	void OnCollisionStay ()
	{	
		if (playerRigidbody.velocity.y <= 2) {
			isFalling = false;
			movement = new Vector3();
		}

	}
}