using UnityEngine;
using System.Collections;

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
