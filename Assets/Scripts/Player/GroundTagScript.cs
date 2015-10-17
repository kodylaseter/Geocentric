using UnityEngine;
using System.Collections;

// Team Gemometry
// Cora Wilson

public class GroundTagScript : MonoBehaviour {

	// Use this for initialization
	string currentGroundTag = "Default";

	void OnTriggerEnter(Collider col)
	{
		currentGroundTag = col.gameObject.tag;
//		print ("GroundTagScript" + currentGroundTag);
		//print(currentGroundTag);
	}

	public string GetGroundTag()
	{
		return currentGroundTag;
	}
}
