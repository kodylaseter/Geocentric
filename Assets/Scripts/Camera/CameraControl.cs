using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class CameraControl : MonoBehaviour {
	
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
	
	void Start () {
		offset = (player.transform.forward * zOffset) + new Vector3 (0, yOffset, 0); ;
//		offset = new Vector3( xOffset,yOffset, zOffset);
		playerPosition = player.transform;
		transform.position = playerPosition.position + offset;
	}
	
	void LateUpdate() {


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
		offset = Quaternion.AngleAxis (Input.GetAxisRaw("Horizontal2") * turnSpeed, Vector3.up) * (offset);
		offset = Quaternion.AngleAxis (Input.GetAxisRaw("Vertical2") * turnSpeed, transform.right) * (offset);

		if (player.GetComponent<mainCharacterScript>().ragdoll) {
			transform.position = ragdoll.position + offset;
			transform.LookAt(ragdoll);
		} else {
			Vector3 newPlayerPos = playerPosition.position + new Vector3(0, 2.5F, 0);
			Vector3 temp = newPlayerPos + offset;
			RaycastHit hit;
			Vector3 direction = newPlayerPos - temp;
			Physics.Raycast(temp, direction, out hit);
			while(hit.collider.tag != "Player") {
				temp = temp + (direction.normalized * 0.1F);
				//temp = temp + (direction.normalized *hit.distance);
				Physics.Raycast(temp, direction, out hit);
			}
//			if (hit.collider.tag != "Player") {
//				temp = temp + (direction * 0.1F);
//			} 
			transform.position = temp;
			//Vector3.Lerp(0
			//transform.position = playerPosition.position + offset;
			transform.LookAt(newPlayerPos);
		}

	}

}