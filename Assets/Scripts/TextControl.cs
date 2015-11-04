using UnityEngine;
using System.Collections;

public class TextControl : MonoBehaviour {

	// Use this for initialization

	void Start () {
		//tm = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver() {
		TextMesh tm = GetComponent<TextMesh>();
		tm.color = Color.gray;
		if( Input.GetAxisRaw("placeItem") != 0) {
			switch (tm.text) {
				case "Start Game": Application.LoadLevel("Kody"); break;
			}
		}
	}

	void OnMouseExit() {
		GetComponent<TextMesh>().color = Color.white;
	}
}
