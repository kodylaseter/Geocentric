﻿using UnityEngine;
using System.Collections;

public class textSlide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position,transform.position + (Vector3.up)*20,.04f);
	}
}
