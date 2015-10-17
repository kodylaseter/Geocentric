using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

// Reloads current level when the player tag touches an object

public class Respawn : MonoBehaviour {
	
	public string level;
	
	void OnCollisionEnter (Collision col)
	{	
		//Destroy(col.gameObject);
		if (col.gameObject.tag.Equals ("Player")) {
			Application.LoadLevel(Application.loadedLevel);
		}
		
	}
}
