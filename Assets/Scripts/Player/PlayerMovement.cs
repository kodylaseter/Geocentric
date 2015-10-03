 using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;            // The speed that the player will move at.
	public float jumpHeight = 10;
	
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	public bool isFalling;
	bool isWalking;
	bool jump;


	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
	}
	
	
	void FixedUpdate ()
	{
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && !isFalling) 
		{
			if (Input.GetButtonDown ("Jump"))
			{
				jump = true;
				isFalling = true;
				anim.SetTrigger ("Jump");
				anim.SetBool ("IsFalling", true);
			}
			else
			{
				if ((h != 0f || v != 0f) == !isWalking)
				{
					isWalking = !isWalking;
					anim.SetBool ("IsWalking", isWalking);
				}

				if (isWalking) 
				{
					Rotate (h, v);
					anim.SetFloat ("RWBlendSpeed", Mathf.Max(Mathf.Abs(h),Mathf.Abs(v)));
				}
			}
		}

		// Animate the player.
		//Animate (h, v);
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			Vector3 vel = playerRigidbody.velocity;
//			vel.y = jumpHeight;
//			playerRigidbody.velocity = vel;
//			playerRigidbody.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
//			isFalling = true;
//		}
	}
	
	void Rotate (float h, float v)
	{
		// Find the direction the character should be moving.
		Vector3 cameraForward = Camera.main.transform.forward; // Gets the direction the camera is pointing
		cameraForward.y = 0;  // removes the y component
		Vector3 cameraRight = Quaternion.Euler(0, 90, 0) * cameraForward; // gets the "right" component of the vector

		//Quaternion lookDirection = Quaternion.LookRotation (cameraDirection);

		// Move the character
		movement = cameraForward * v + cameraRight * h;
//
//		Quaternion characterDirection = new Quaternion();
//		if (movement.magnitude != 0) {
//			characterDirection = Quaternion.LookRotation (movement);
//		}


		// Change character's rotation based on where he's facing.
			//lookDirection = Quaternion.RotateTowards (transform.rotation,characterDirection,10);
		playerRigidbody.rotation = Quaternion.LookRotation (movement);


//		Quaternion newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 
//		                                          transform.rotation.eulerAngles.y + 200f * Time.deltaTime * h,
//		                                          transform.rotation.eulerAngles.z);
//
//		playerRigidbody.MoveRotation(newRotation);

		// Normalise the movement vector and make it proportional to the speed per second.
		//movement = movement.normalized * speed * Time.deltaTime;

		
		// Move the player to it's current position plus the movement.

		//playerRigidbody.MovePosition (transform.position + movement);




	}
	

	
	void Animate (float h, float v)
	{		
		// Tell the animator whether or not the player is walking.

		anim.SetFloat ("RWBlendSpeed", Mathf.Max(Mathf.Abs(h),Mathf.Abs(v)));
//		if (Input.GetKeyDown("space")) { 
//			anim.SetTrigger ("spin");
//		}
		if (jump)
			anim.SetTrigger ("Jump");
		if (isFalling) {
			anim.SetBool ("IsFalling",true);
		} else {
			anim.SetBool ("IsFalling",false);
			anim.SetBool ("IsWalking", isWalking);
		}
	}

	void OnCollisionEnter ()
	{
		isFalling = false;
	}
}