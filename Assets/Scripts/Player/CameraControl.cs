using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public float turnSpeed = 4.0f;
	public Transform player;
	public float xOffset;
	public float yOffset;
	public float zOffset;
	public float scale;

	private Vector3 offset;
	
	void Start () {
		offset = new Vector3( xOffset,yOffset, zOffset);
		offset = new Vector3( xOffset,yOffset, zOffset);
	}
	
	void LateUpdate() {
		//IJKL
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * (offset);
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, transform.right) * (offset);

		//Right Joystick (tested by Ben in Windows with PS4 controller)
		offset = Quaternion.AngleAxis (Input.GetAxisRaw("Horizontal2") * turnSpeed, Vector3.up) * (offset);
		offset = Quaternion.AngleAxis (Input.GetAxisRaw("Vertical2") * turnSpeed, transform.right) * (offset);
		transform.position = player.position + offset;
		transform.LookAt(player.position);
	}

}