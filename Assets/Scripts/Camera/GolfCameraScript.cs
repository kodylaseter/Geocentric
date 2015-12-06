using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class GolfCameraScript : MonoBehaviour {
	
	public float turnSpeed = 4.0f;
	public GameObject player;
	//	public Transform player;
	public Transform ragdoll;
	public float xOffset;
	public float yOffset;
	public float zOffset;
	public float scale;
	Transform playerPosition;
	
	private Vector3 offset;

	Animator stateManager; 
	Transform hole1;
	Transform look1;
	
	void Start () {
		offset = (player.transform.forward * zOffset) + new Vector3 (0, yOffset, 0); ;
		//		offset = new Vector3( xOffset,yOffset, zOffset);
		playerPosition = player.transform;

		stateManager = GameObject.Find ("StateManager").GetComponent<Animator>();
		hole1 = GameObject.Find ("Hole1Event_CameraPos").transform;
	}
	
	void LateUpdate() {
		AnimatorStateInfo animState = stateManager.GetCurrentAnimatorStateInfo (0); 

		if (animState.IsName ("Gameplay")) {
		
			//Mouse
			if (Input.GetMouseButton (0)) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				offset = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * turnSpeed, Vector3.up) * (offset);
				offset = Quaternion.AngleAxis (Input.GetAxis ("Mouse Y") * -1 * turnSpeed, transform.right) * (offset);
			} else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
		
			//Right Joystick (tested by Ben in Windows with PS4 controller)
			offset = Quaternion.AngleAxis (Input.GetAxisRaw ("Horizontal2") * turnSpeed, Vector3.up) * (offset);
			offset = Quaternion.AngleAxis (Input.GetAxisRaw ("Vertical2") * turnSpeed, transform.right) * (offset);
		
			if (player.GetComponent<mainCharacterScript> ().ragdoll) {
				transform.position = ragdoll.position + offset;
				transform.LookAt (ragdoll);
			} else {
				transform.position = playerPosition.position + offset;
				transform.LookAt (playerPosition.position);
			}

		} else {
//			transform.position = Vector3.Lerp (transform.position, hole1.position, .05f);
//			transform.forward = Vector3.Slerp (transform.forward, look1.forward, .05f);
		}
		
	}
	
}