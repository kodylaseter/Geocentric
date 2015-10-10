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
	bool ragdoll = false;

	// RAGDOLL JUNK // 

	public Collider[] bodyParts = new Collider[5];
	
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

		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			Ragdoll ();
		}
		
		
		if ((h != 0f || v != 0f) == !isWalking)
		{
			isWalking = !isWalking;
		}
		
		if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && !isFalling) 
		{
			anim.SetBool ("IsWalking", isWalking);
			
			if (Input.GetButtonDown ("Jump"))
			{
				jump = true;
				isFalling = true;
				anim.SetTrigger ("Jump");
				anim.SetBool ("IsFalling", true);
			}
			
			anim.SetFloat ("RWBlendSpeed", Mathf.Max(Mathf.Abs(h),Mathf.Abs(v)));
			
			
		}
		
		if (isWalking) Rotate (h, v);
		
	}
	
	void Rotate (float h, float v)
	{
		// Find the direction the character should be moving.
		Vector3 cameraForward = Camera.main.transform.forward; // Gets the direction the camera is pointing
		cameraForward.y = 0;  // removes the y component
		Vector3 cameraRight = Quaternion.Euler(0, 90, 0) * cameraForward; // gets the "right" component of the vector
		
		movement = cameraForward * v + cameraRight * h;
		
		playerRigidbody.rotation = Quaternion.LookRotation (movement);
	}
	
	
	void OnCollisionEnter ()
	{
		isFalling = false;
	}

	void Ragdoll() 
	{
		playerRigidbody.isKinematic = !playerRigidbody.isKinematic;
		anim.enabled = !anim.enabled;
		foreach (Collider collider in bodyParts) {
			collider.enabled = !collider.enabled;
		}

	}


}