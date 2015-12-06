using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

// Reloads current level when the player tag touches an object

public class BensRespawn : MonoBehaviour {
	
	public string level;
	public GameObject[] DestroyReveal;
	
	void OnCollisionEnter (Collision col)
	{	
		//Destroy(col.gameObject);
		if (col.gameObject.tag.Equals ("Player") || col.gameObject.tag.Equals("BadEgg") ) {
			Application.LoadLevel (Application.loadedLevel);
		}
		else if (col.gameObject.tag.Equals ("GoodEgg"))
		{
			foreach (GameObject gameObject in DestroyReveal)
				gameObject.SetActive(true);
			Destroy(col.gameObject);
		}
		else Destroy(col.gameObject);
		
	}
}
