using UnityEngine;
using System.Collections;

public class golfStateScript : MonoBehaviour {

	Camera cam;
	Animator anim; 
	Transform holeCameraPos;
	Transform look1;
	string hole;

	Transform lastCamera;
	GameObject door;
	Transform doorPos;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		string a = "hole1";
		
		AnimatorStateInfo animState = anim.GetCurrentAnimatorStateInfo (0);
		if (animState.IsName ("HoleComplete")) {
			cam.transform.position = Vector3.Lerp (cam.transform.position, holeCameraPos.position, .03f);
			cam.transform.forward = Vector3.Slerp (cam.transform.forward, holeCameraPos.forward, .03f);
			if ( (Vector3.Distance(cam.transform.position,holeCameraPos.position)) < 1) {

				DoorMover ();

			}

		}
	}
	public void buttonPressed() {
		if (Input.anyKey) {
			anim.SetTrigger("ExitState");
		}

	}

	public void Hole1Trigger(string holeName) {
		hole = holeName;
		anim.SetTrigger("HoleComplete");
		lastCamera = cam.transform;
		holeCameraPos = GameObject.Find (holeName + "Event_CameraPos").transform;

		door = GameObject.Find ("Door" + (int.Parse (hole.Substring (hole.Length-1)) + 1));
		doorPos = GameObject.Find ("Door"+(int.Parse (hole.Substring (hole.Length-1))+1)+"_endingLocation").transform;

	}

	public void DoorMover() {
		door.transform.position = Vector3.Lerp (door.transform.position, doorPos.position,.01f);
		if ( (Vector3.Distance(door.transform.position,doorPos.position)) < 30) {
			print ("NEXT");
			if (Input.anyKey) {

				anim.SetTrigger ("ExitState");
			}
			
		}


	}


}
