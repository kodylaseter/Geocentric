using UnityEngine;
using System.Collections;

public class killbox : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		print ("yay");
		player.GetComponent<mainCharacterScript>().Ragdoll();
	}
}
