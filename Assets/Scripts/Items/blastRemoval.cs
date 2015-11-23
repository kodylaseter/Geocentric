using UnityEngine;
using System.Collections;

// Team Gemometry
// Collin Caldwell

public class blastRemoval : MonoBehaviour {
	public int frames;

	// Use this for initialization
	void Start () {

		              
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = transform.localScale * 2;
		if (frames < 0) {
			Destroy (gameObject);
		}
		frames --;

	}
}
