using UnityEngine;
using System.Collections;

// Team Gemometry
// Cora Wilson

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
			//print (playerAudio.clip.name);
			playerAudio.Play ();
		}
		
	}
	
	
}

