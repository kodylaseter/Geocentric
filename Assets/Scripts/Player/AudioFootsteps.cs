using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class AudioFootsteps : MonoBehaviour {
	
	AudioSource playerAudio;
	string currentGroundTag = "Default";
	GroundTagScript groundTagger;
	
	// Use this for initialization
	void Start () {
		playerAudio = GetComponent<AudioSource> ();
		groundTagger = GetComponentInChildren<GroundTagScript> ();
	}
	
	void PlayFootsteps(){
		//get tag
		//print (currentGroundTag);
		currentGroundTag = groundTagger.GetGroundTag ();
		if (currentGroundTag != "Item") {
			playerAudio.clip = SoundManager.SM.GetSound (currentGroundTag);
			playerAudio.Play ();
		}
		
	}
	
	
}

