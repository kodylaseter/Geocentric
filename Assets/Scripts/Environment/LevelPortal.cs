using UnityEngine;
using System.Collections;

// Loads specified level on collision with Player

public class LevelPortal : MonoBehaviour {

	public string level;

	void OnCollisionEnter (Collision col)
	{	
		//Destroy(col.gameObject);
		if (col.gameObject.tag.Equals ("Player")) {
			Application.LoadLevel(level);
		}

	}
}
