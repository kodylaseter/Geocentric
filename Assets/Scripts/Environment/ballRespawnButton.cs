using UnityEngine;
using System.Collections;

public class ballRespawnButton : MonoBehaviour {

	public GameObject ball;
	public GameObject ballSpawn;
	public bool pressed;



	// Use this for initialization
	void Start () {
		pressed = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (pressed == false) {
			ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
			ball.transform.position = ballSpawn.transform.position;
			pressed = true;

		}



	}

	void OnTriggerExit (Collider other) {
		
		pressed = false;
		
		
	}


}
