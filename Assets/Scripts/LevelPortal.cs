﻿using UnityEngine;
using System.Collections;

public class LevelPortal : MonoBehaviour {

	public string level;

	void OnCollisionEnter (Collision col)
	{
		//Destroy(col.gameObject);
		Application.LoadLevel(level);
	}
}
