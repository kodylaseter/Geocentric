using UnityEngine;
using System.Collections;

// Team Geocentric
// Collin Caldwell

public class mainMenuCameraScript : MonoBehaviour {

	public Transform destinationTransform;
	private Transform MainMenuCameraPositionTransform;
	private Transform LevelSelectCameraPositionTransform;
	public bool done = true; // says if the camera is done moving.


	// Use this for initialization
	void Start () {
		MainMenuCameraPositionTransform = GameObject.Find ("MainMenuCameraPosition").transform;
		LevelSelectCameraPositionTransform = GameObject.Find ("LevelSelectCameraPosition").transform;
		destinationTransform = MainMenuCameraPositionTransform;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = Vector3.Slerp (transform.forward, destinationTransform.forward, .1f);
		if (done == false) {
			if (transform.forward == destinationTransform.forward) {
				GameObject.Find("Selector").GetComponent<selectionScript>().wipe ();
				done = true;
			}
		}
	}

	public void destinationSwitch() {
		if (destinationTransform.Equals (MainMenuCameraPositionTransform)) {
			destinationTransform = LevelSelectCameraPositionTransform;
		} else {
			destinationTransform = MainMenuCameraPositionTransform;
		}
		done = false;
	}
}
