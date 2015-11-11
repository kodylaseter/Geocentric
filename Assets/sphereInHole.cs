using UnityEngine;
using System.Collections;

// Team Gemometry
// Collin Caldwell

public class sphereInHole : MonoBehaviour {

	public GameObject door;
	public GameObject flag;
	public GameObject flagflag;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		door.transform.position = door.transform.position + transform.up * -12;
		flag.GetComponent<Renderer> ().material.color = Color.green;
		flagflag.GetComponent<Renderer> ().material.color = Color.green;
	}
}
