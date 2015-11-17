using UnityEngine;
using System.Collections;

public class MenuControl : MonoBehaviour {
	
	public bool notLevelSelector; // is this menu object a level select?
	public string level; // what level/menu does this go to?
	
	void OnMouseOver() {
		TextMesh tm = GetComponent<TextMesh>();
		tm.color = Color.red;
	}

	void OnMouseDown() {
		if (notLevelSelector) {
			GameObject.Find ("Camera").GetComponent<mainMenuCameraScript>().destinationSwitch();
		} else {
			Application.LoadLevel (level);
		}
	}
	
	void OnMouseExit() {
		GetComponent<TextMesh>().color = Color.white;
	}
}
