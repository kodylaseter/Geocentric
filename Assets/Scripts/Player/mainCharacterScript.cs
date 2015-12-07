
using UnityEngine;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class mainCharacterScript : MonoBehaviour
{
	public float speed = 6f;            // The speed that the player will move at.
	public float jumpHeight = 10;
	

	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
	CapsuleCollider playerCollider;
    GroundTagScript groundedDetector;
    FacePlantDetector faceplantDetector;
	public bool isFalling;
	bool isWalking;
	//bool jump = false;
	public bool twirl;
	public bool ragdoll = false;
    bool isInput = false;

	// RAGDOLL JUNK // 

	public Collider mainCollider;
	public Collider[] bodyParts = new Collider[5];
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();
		playerCollider = GetComponent <CapsuleCollider> ();
        groundedDetector = GetComponentInChildren<GroundTagScript>();
        faceplantDetector = GetComponentInChildren<FacePlantDetector>();
	}
	
	
	void FixedUpdate ()
	{
       // print("Begin FixedUpdate");
		// Store the input axes.
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
        isFalling = !groundedDetector.GetGrounded();

        //print(!isFalling);
//        print("FACEPLANT:" + faceplantDetector.GetFaceplant());

		AnimatorStateInfo animState = anim.GetCurrentAnimatorStateInfo (0); 

#region BLEH
        /* Collider animation for jumping work begins here. */
		if (animState.IsName ("Jump")) {

			float jumpTime = (float) animState.normalizedTime - Mathf.Floor(animState.normalizedTime);
			jumpTime = jumpTime * 2 - 1;
			playerCollider.center.Set(0, Mathf.Lerp(3f, 2.5f, jumpTime), 0);
			playerCollider.height = Mathf.Lerp(4f, 5f, jumpTime);
		}
		/* Collider animation for jumping work ends here. */
		

		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			Ragdoll ();
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			anim.SetTrigger ("Twirl");
			twirl = true;
		} else {
			twirl = false;
        }
#endregion
        if ((h != 0f || v != 0f) == !isInput)
		{
			isInput = !isInput;
        }

        if (isFalling && faceplantDetector.GetFaceplant()) //evil faceplant case
        {
            anim.SetBool("IsWalking", false);
           // print("isFalling and isFaceplant = true");
        } 
        else if (!animState.IsName("Jump")) //no faceplant or no falling, not in jump animation state
		{

            if (Input.GetButtonDown("Jump") && !isFalling) //wants to jump, but is not falling
            {
                //jump = true;
                anim.SetTrigger("Jump"); //JUMP
            }
            else
            {
                anim.SetBool("IsWalking", isInput); //otherwise walk according to input
                //print("input: " + isInput);
            }

		}

        anim.SetFloat("RWBlendSpeed", Mathf.Max(Mathf.Abs(h), Mathf.Abs(v)));
		if (isInput ) Rotate (h, v); //rotate according to input

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
	
	
	void OnCollisionEnter (Collision collision)
	{
		//isFalling = false;
		//commenting this out until we reevaluate jumping
//		foreach (ContactPoint contact in collision.contacts) {
//			if (Vector3.Dot(contact.normal, Vector3.up) > 0)
//			{
//				isFalling = false;
//				break;
//			}
//		}

		//rever player collider from jump
		playerCollider.center.Set (0f, 2.5f, 0f);
		playerCollider.height = 5f;

	}
	public void Ragdoll() 
	{	
//		mainCollider.enabled = !mainCollider.enabled;
//		playerRigidbody.isKinematic = !playerRigidbody.isKinematic;
//		anim.enabled = !anim.enabled;
//		foreach (Collider collider in bodyParts) {
//			collider.enabled = !collider.enabled;
//		}
		ragdoll = true;


//		transform.position += new Vector3 (0, 50, 0);
		playerRigidbody.isKinematic = true;
		playerRigidbody.constraints = RigidbodyConstraints.FreezeAll;
		mainCollider.enabled = false;

		anim.enabled = false;
		foreach (Collider collider in bodyParts) {
			collider.enabled = true;

		}
		playerRigidbody.constraints = RigidbodyConstraints.FreezeRotation;


	}



}