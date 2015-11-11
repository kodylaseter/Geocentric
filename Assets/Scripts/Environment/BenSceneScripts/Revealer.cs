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
			if (Key.name.Equals ("TheEgg")) {
				TextMesh tm = GameObject.Find("NEST_text").GetComponent<TextMesh>();
				tm.color = Color.green;
			} else if (Key.name.Equals ("Rex") && Reveal[0].name.Equals("RevealEggWalk_Return")) {
				GameObject.Find ("questionMark2").GetComponent<Renderer> ().material.color = Color.green;
			} else if (Key.name.Equals ("Rex")) {
				GameObject.Find ("questionMark").GetComponent<Renderer> ().material.color = Color.green;
			}
			foreach (GameObject gameObject in Reveal)
				gameObject.SetActive(true);
		}
		
	}
}
