using UnityEngine;
using System.Collections;

// A script that moves a rigid body vertically when its touched by something.

public class Mover : MonoBehaviour {

	bool timeToMove = false;
	public GameObject destination;
	public GameObject platform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timeToMove) {
			platform.GetComponent<Rigidbody> ().velocity = Vector3.up*50f;
		}
//		platform.GetComponent<Rigidbody> ().AddForce (transform.up*1000);


	
	}
	void OnCollisionEnter (Collision col)
	{	
		//Destroy(col.gameObject);
		if (col.gameObject.tag.Equals ("Player")) {
			timeToMove = true;
		}
		
	}
	void onTriggerEnter(Collider other) {
		timeToMove = true;
	}
}
