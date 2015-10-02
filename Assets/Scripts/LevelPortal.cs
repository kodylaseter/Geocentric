using UnityEngine;
using System.Collections;

public class LevelPortal : MonoBehaviour {

	public string level;

	void OnCollisionEnter (Collision col)
	{	print (col.gameObject.tag);
		//Destroy(col.gameObject);
		if (col.gameObject.tag.Equals ("Player")) {
			Application.LoadLevel(level);
		}

	}
}
