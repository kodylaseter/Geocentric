using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	private Vector3 levelSelectorPoint;
	private Vector3 mainPoint;
	
	private Transform cam;
	private Transform currentPoint;
	private Transform mainPosition;
	private Transform levelSelect;
	
	void Start () {
		levelSelectorPoint = GameObject.Find("levelSelectPoint").transform.position;
		levelSelect = GameObject.Find ("LevelPosition").transform;
		mainPosition = GameObject.Find ("mainPoint").transform;
		mainPoint = GameObject.Find("mainPoint").transform.position;

		cam = GameObject.Find("Camera").transform;
//		currentPoint.position = mainPoint;
	}
	
	// Update is called once per frame
	void LateUpdate () {
//		if (currentPoint.position == levelSelectorPoint) {
//			int x = 1;
//		}
		cam.LookAt(currentPoint);
	}
	
	void OnMouseOver() {
		string objName = transform.name;
		TextMesh tm = GetComponent<TextMesh>();
		tm.color = Color.red;
		if( Input.GetAxisRaw("placeItem") != 0) {
			switch (objName) {
				case "Start_Game_Text": Application.LoadLevel("Kody"); break;
				case "Level_Select_Text": currentPoint.position = levelSelectorPoint; break;
			}
		}
	}

	void OnMouseDown() {
		if (gameObject.name == "Start_Game_Text") {
			Application.LoadLevel ("s000 - Walk Forward Alpha");
		} else if (gameObject.name == "Level_Select_Text") {
			CameraMove (levelSelect);
		} else if (gameObject.name == "Back_Select") {
			CameraMove (mainPosition);
		} else if (gameObject.name == "Ben_Selector") {
			Application.LoadLevel ("Ben");
		} else if (gameObject.name == "Monet_Selector") {
			Application.LoadLevel ("Monet");
		} else if (gameObject.name == "Collin_Selector") {
			Application.LoadLevel ("bombGolf");
		} else if (gameObject.name == "Kody_Selector") {
			Application.LoadLevel ("Kody");
		}

	}
	
	void OnMouseExit() {
		GetComponent<TextMesh>().color = Color.white;
	}

	void CameraMove(Transform look) {
//		print (levelSelect.position);
		cam.transform.LookAt (look);
//		rotationX = Vector3.Lerp(cam.transform.localEulerAngles, transform.eulerAngles, 1.0f * Time.deltaTime).x;
	}
}
