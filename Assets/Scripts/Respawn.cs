using UnityEngine;
using System.Collections;

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
