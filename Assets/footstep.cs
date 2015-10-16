using UnityEngine;
using System.Collections;

public class footstep : MonoBehaviour {

	public AudioSource footsound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerStay   (Collider	other) {
		footsound.Play ();
	}
}
