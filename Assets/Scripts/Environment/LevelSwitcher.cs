﻿using UnityEngine;
using System.Collections;

// Team Gemometry
// Collin Caldwell

// Press 1 - 5 to switch between levels

public  class LevelSwitcher : MonoBehaviour {

	public string one;
	public string two;
	public string three;
	public string four;
	public string five;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
		//Application.LoadLevel (one);

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
            SoundManager.SM.ChangeBGMusic("GeometryGameBG1");
			Application.LoadLevel ("StartMenu");
		}
//		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
//			Application.LoadLevel (two);
//		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
//			Application.LoadLevel (three);
//		}  else if (Input.GetKeyDown ()) {
//
//		}
	}

	bool Exists (string test) {
		return false;
	}
}
