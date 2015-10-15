﻿using UnityEngine;
using System.Collections;

public class attackForce : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider other) {

		if (other.tag.Equals ("Item") && player.GetComponent<mainCharacterScript>().twirl) {
			Vector3 forceVector = (other.transform.position - player.transform.position).normalized;
			other.attachedRigidbody.AddForce((Vector3.up+forceVector) * 3000);
			other.attachedRigidbody.AddTorque(Vector3.Cross(Vector3.up, forceVector) * 2000);
		}
	}
}
