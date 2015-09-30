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
	}
	
	void LateUpdate() {
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * (offset);
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, Vector3.right) * (offset);
		transform.position = player.position + offset; 
		transform.LookAt(player.position);
	}
}