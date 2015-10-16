using UnityEngine;
using System.Collections;

public class applyGravityWithAttack : MonoBehaviour {

	GameObject player;
	Rigidbody attachedRigidBody;
	Collider thisCollider;

	// Use this for initialization
	void Start () {
		attachedRigidBody = gameObject.GetComponent<Rigidbody>();
		thisCollider = gameObject.GetComponent<Collider>();
		player = GameObject.Find ("Rex");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay (Collider other) {
//		print ("WOO");
		if (other == player.GetComponent<SphereCollider>() && player.GetComponent<mainCharacterScript> ().twirl == true) {
			thisCollider.isTrigger = false;
			attachedRigidBody.useGravity = true;
		}



	}
//	void OnTriggerStay (Collider other) {
//		
//		if (other.tag.Equals ("Item") && !other.isTrigger) {
//			Vector3 forceVector = (other.transform.position - gameObject.transform.position).normalized;
//			other.attachedRigidbody.AddForce((Vector3.up+forceVector) * (blastStrength* 1000));
//			other.attachedRigidbody.AddTorque(Vector3.Cross(Vector3.up, forceVector) * (blastStrength* 1000));
//			Destroy (gameObject);
//		} 
//		
//	}
	
}
