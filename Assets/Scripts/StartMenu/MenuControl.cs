using UnityEngine;
using System.Collections;

//Team Geocentric
// Kody Lassiter and Collin Caldwell

public class MenuControl : MonoBehaviour {
	
	public bool notLevelSelector; // is this menu object a level select?
	public string level; // what level/menu does this go to?
//	public bool selected;
	
	void OnMouseOver() {
		Selected ();
		GameObject.Find ("Selector").GetComponent<selectionScript> ().updateSelector (gameObject);

	}

	void OnMouseDown() {
		Enter ();
	}

	public void Selected() {
		GetComponent<TextMesh>().color = Color.red;
	}

	public void Enter() {
		if (notLevelSelector) {
			GetComponent<TextMesh>().color = Color.white;
			GameObject.Find ("Camera").GetComponent<mainMenuCameraScript>().destinationSwitch();
			GameObject.Find ("Selector").GetComponent<selectionScript> ().changeArray();
		} else {
			Application.LoadLevel (level);

		}
	}
}
