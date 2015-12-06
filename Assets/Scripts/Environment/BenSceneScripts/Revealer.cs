using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

// Reloads current level when the player tag touches an object

public class Revealer : MonoBehaviour {

	public GameObject Key;
	public GameObject[] Reveal;
	
	void OnCollisionEnter (Collision col)
	{	
		//Destroy(col.gameObject);
		if (col.gameObject == Key) {
			foreach (GameObject gameObject in Reveal)
				gameObject.SetActive(true);
		}
		
	}
}
