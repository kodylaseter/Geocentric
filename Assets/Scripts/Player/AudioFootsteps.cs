using UnityEngine;
using System.Collections;

public class AudioFootsteps : MonoBehaviour {

	AudioSource playerAudio;
	Animator anim;

	string currentGroundTag = "Default";

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		playerAudio = GetComponent<AudioSource> ();
	}

	void PlayFootsteps(){
		//get tag
		RaycastHit hit;
		if (Physics.Raycast (transform.position, Vector3.down, out hit)) {
			currentGroundTag = hit.collider.tag;
		}
//		print (currentGroundTag);
		//requires that a SoundManager singleton exist for every level

		if (currentGroundTag != "Untagged" && currentGroundTag != "Item" ) {
		playerAudio.clip = SoundManager.SM.GetSound (currentGroundTag);
		playerAudio.Play ();
			
		}

	}


}
