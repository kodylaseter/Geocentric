using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	private Vector3 levelSelectorPoint;
	private Vector3 mainPoint;
	public bool notLevelSelector; // is this menu object a level select?
	public string level; // what level/menu does this go to?
	
	private Transform cam;
	private Transform currentPoint;
	private Transform mainPosition;
//	private Transform levelSelect;

	private Transform MainMenuCameraPositionTransform;
	private Transform LevelSelectCameraPositionTransform;
	private Transform destinationTransform;

	void Awake() {
//		MainMenuCameraPositionTransform = GameObject.Find ("MainMenuCameraPosition").transform;
//		LevelSelectCameraPositionTransform = GameObject.Find ("LevelSelectCameraPosition").transform;
//		destinationTransform = MainMenuCameraPositionTransform;
		
	}
	
	void Start () {
//		Debug.Log("Start called.");
//		levelSelect = GameObject.Find ("LevelPosition").transform;
//		mainPosition = GameObject.Find ("mainPoint").transform;
//		mainPoint = GameObject.Find("mainPoint").transform.position;

//		print (LevelSelectCameraPositionTransform.forward);

//		cam = GameObject.Find("Camera").transform;
//		currentPoint.position = mainPoint;
	}

	void Update() {
//		print (cam.forward);
//		print (destinationTransform.forward);
//		cam.forward = Vector3.Slerp (cam.forward, destinationTransform.forward, .1f);
	}
	
	// Update is called once per frame
	void LateUpdate () {
//		if (currentPoint.position == levelSelectorPoint) {
//			int x = 1;
//		}
//		cam.LookAt(currentPoint);
//
//		print (cam.forward);
//		cam.forward = Vector3.Slerp (cam.forward, destinationTransform.forward, .5f);
	}
	
	void OnMouseOver() {
		string objName = transform.name;
		TextMesh tm = GetComponent<TextMesh>();
		tm.color = Color.red;
//		if( Input.GetAxisRaw("placeItem") != 0) {
//			switch (objName) {
//				case "Start_Game_Text": Application.LoadLevel("Kody"); break;
//				case "Level_Select_Text": currentPoint.position = levelSelectorPoint; break;
//			}
//		}
	}

	void OnMouseDown() {
		if (notLevelSelector) {
			GameObject.Find ("Camera").GetComponent<mainMenuCameraScript>().destinationSwitch();
		} else {
			Application.LoadLevel (level);
		}

//		if (gameObject.name == "Start_Game_Text") {
//			Application.LoadLevel ("s000 - Walk Forward Alpha");
//		} else if (gameObject.name == "Level_Select_Text") {
//			destinationTransform = LevelSelectCameraPositionTransform;
//		} else if (gameObject.name == "Back_Select") {
//			destinationTransform = MainMenuCameraPositionTransform;
//		} else if (gameObject.name == "Ben_Selector") {
//			Application.LoadLevel ("Ben");
//		} else if (gameObject.name == "Monet_Selector") {
//			Application.LoadLevel ("Monet");
//		} else if (gameObject.name == "Collin_Selector") {
//			Application.LoadLevel ("bombGolf");
//		} else if (gameObject.name == "Kody_Selector") {
//			Application.LoadLevel ("Kody");
//		} else if (gameObject.name == "Credits") {
//			Application.LoadLevel ("starfield");
//		}

	}
	
	void OnMouseExit() {
		GetComponent<TextMesh>().color = Color.white;
	}

	void CameraMove(Transform look) {
//		print (levelSelect.position);

		cam.transform.LookAt (look);
//		rotationX = Vector3.Lerp(cam.transform.localEulerAngles, transform.eulerAngles, 1.0f * Time.deltaTime).x;
	}
//	void Selected() {
//
//	}
}
