using UnityEngine;
using System.Collections;

// Warps GameObject player from their current position to the location of the GameObject this script is attached to.

public class CharacterMover : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T)) {
			player.transform.position = transform.position;
			player.transform.forward = new Vector3(0,0,-1);
		}
	}
}
