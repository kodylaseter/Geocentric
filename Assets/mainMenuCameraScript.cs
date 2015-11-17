using UnityEngine;
using System.Collections;

public class mainMenuCameraScript : MonoBehaviour {

	public Transform destinationTransform;
	private Transform MainMenuCameraPositionTransform;
	private Transform LevelSelectCameraPositionTransform;


	// Use this for initialization
	void Start () {
		MainMenuCameraPositionTransform = GameObject.Find ("MainMenuCameraPosition").transform;
		LevelSelectCameraPositionTransform = GameObject.Find ("LevelSelectCameraPosition").transform;
		destinationTransform = MainMenuCameraPositionTransform;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = Vector3.Slerp (transform.forward, destinationTransform.forward, .1f);
	}

	public void destinationSwitch() {
		if (destinationTransform.Equals (MainMenuCameraPositionTransform)) {
			destinationTransform = LevelSelectCameraPositionTransform;
		} else {
			destinationTransform = MainMenuCameraPositionTransform;
		}
	}
}
