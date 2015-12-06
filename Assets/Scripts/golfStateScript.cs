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
	Transform levelCompleteCamera;

	GameObject Rex;
	GameObject goldenThing;	

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		anim = GetComponent <Animator> ();
		levelCompleteCamera = GameObject.Find ("LevelCompleteCamera").transform;
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

		if (animState.IsName ("LevelComplete")) {

			cam.transform.position = Vector3.Lerp (cam.transform.position, levelCompleteCamera.position, .03f);
			cam.transform.forward = Vector3.Slerp (cam.transform.forward, levelCompleteCamera.forward, .03f);
			cam.transform.position = Vector3.Lerp (cam.transform.position, levelCompleteCamera.position, .03f);
			goldenThing.transform.position = Vector3.Lerp (goldenThing.transform.position, Rex.transform.position+(Vector3.up*6),.03f);
		}

		if (animState.IsName ("SwitchLevel")) {
			GameObject.Find ("LevelCompleteText").GetComponent<CanvasGroup> ().alpha += .05f;
			if (Input.anyKey) {
				
				Application.LoadLevel(GameObject.Find ("Portal").GetComponent<LevelPortal>().level);
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

	public void LevelComplete() {
		anim.SetTrigger("LevelComplete");
		Rex = GameObject.Find ("Rex");
		GameObject.Find ("Rex").GetComponent<Animator> ().SetTrigger ("LevelComplete");
		GameObject.Find ("Rex").GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeAll;
		GameObject.Find ("Portal").GetComponent<Collider> ().enabled = false;
		goldenThing = GameObject.Find ("Golden Square");

	}


}
