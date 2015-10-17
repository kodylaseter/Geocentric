using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class AudioFootsteps : MonoBehaviour {

	AudioSource playerAudio;
	string currentGroundTag = "Default";

	// Use this for initialization
	void Start () {
		playerAudio = GetComponent<AudioSource> ();
	}

	void PlayFootsteps(){
		//get tag
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
			currentGroundTag = hit.collider.tag;
//			print (hit.collider.gameObject.name);
		}
		//print (currentGroundTag);

		if (currentGroundTag != "Item") {
			playerAudio.clip = SoundManager.SM.GetSound (currentGroundTag);
			playerAudio.Play ();
		}

	}


}
