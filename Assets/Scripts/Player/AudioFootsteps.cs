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
		if (SoundManager.SM == null)
			return;
		if (currentGroundTag != "Item" && SoundManager.SM.PlaySoundEffects()) {
			if (SoundManager.SM == null) return;
            //if (SoundManager.SM.GetFootstepSound(currentGroundTag) == null) return; //se probably silent; or error
			//playerAudio.clip = SoundManager.SM.GetFootstepSound (currentGroundTag);
			//print (playerAudio.clip.name);
            //playerAudio.volume = 0.5f;
            playerAudio.PlayOneShot(SoundManager.SM.GetFootstepSound(currentGroundTag), 0.5f);
		}
		
	}
	
	
}

