using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

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
