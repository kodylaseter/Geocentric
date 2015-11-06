using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {

	private Vector3 levelSelectorPoint;
	private Vector3 mainPoint;
	private Transform cam;
	private Transform currentPoint;
	
	void Start () {
		levelSelectorPoint = GameObject.Find("levelSelectPoint").transform.position;
		mainPoint = GameObject.Find("mainPoint").transform.position;
		cam = GameObject.Find("Camera").transform;
		currentPoint.position = mainPoint;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (currentPoint.position == levelSelectorPoint) {
			int x = 1;
		}
		cam.LookAt(currentPoint);
	}
	
	void OnMouseOver() {
		string objName = transform.name;
		TextMesh tm = GetComponent<TextMesh>();
		tm.color = Color.gray;
		if( Input.GetAxisRaw("placeItem") != 0) {
			switch (objName) {
				case "Start_Game_Text": Application.LoadLevel("Kody"); break;
				case "Level_Select_Text": currentPoint.position = levelSelectorPoint; break;
			}
		}
	}
	
	void OnMouseExit() {
		GetComponent<TextMesh>().color = Color.white;
	}
}
