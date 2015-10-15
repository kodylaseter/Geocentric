﻿using UnityEngine;
using System.Collections;

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

		offset = new Vector3( xOffset,yOffset, zOffset);
		offset = new Vector3( xOffset,yOffset, zOffset);
		playerPosition = player.transform;
	}
	
	void LateUpdate() {
		//IJKL
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * (offset);
		offset = Quaternion.AngleAxis (Input.GetAxis("Mouse Y") * turnSpeed, transform.right) * (offset);

		//Right Joystick (tested by Ben in Windows with PS4 controller)
		offset = Quaternion.AngleAxis (Input.GetAxisRaw("Horizontal2") * turnSpeed, Vector3.up) * (offset);
		offset = Quaternion.AngleAxis (Input.GetAxisRaw("Vertical2") * turnSpeed, transform.right) * (offset);

		if (player.GetComponent<mainCharacterScript>().ragdoll) {
			transform.position = ragdoll.position + offset;
			transform.LookAt(ragdoll);
		} else {
			transform.position = playerPosition.position + offset;
			transform.LookAt(playerPosition.position);
		}

	}

}