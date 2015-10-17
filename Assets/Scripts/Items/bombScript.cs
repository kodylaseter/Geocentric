using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class bombScript : MonoBehaviour {

	public float fuzeLength;
	float time;
	bool explode = false;
	public SphereCollider blastRadius;
	public int blastStrength;

	// Use this for initialization
	void Start () {
		time = fuzeLength;
	}
	
	// Update is called once per frame
	void Update () {
		if (explode == true) {
			Destroy (gameObject);
		}

		time -= Time.deltaTime;

		if (time < 0) {
			blastRadius.enabled = true;
			explode = true;

		}

	}

//	void explode() {
//		
//	}

	void OnTriggerStay (Collider other) {
		
		if (other.tag.Equals ("Item") && !other.isTrigger) {
			Vector3 forceVector = (other.transform.position - gameObject.transform.position).normalized;
			other.attachedRigidbody.AddForce((Vector3.up+forceVector) * (blastStrength* 1000));
			other.attachedRigidbody.AddTorque(Vector3.Cross(Vector3.up, forceVector) * (blastStrength* 1000));
			Destroy (gameObject);
		} 

	}
}
