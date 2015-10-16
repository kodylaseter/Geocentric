using UnityEngine;
using System.Collections;

public class LavaHit : MonoBehaviour {
	public AudioClip lavadeath;
	AudioSource playerAudio;
	ParticleSystem playerParticles;

	// Use this for initialization
	void Start () {
		playerAudio = GetComponent<AudioSource> ();
		playerParticles = GetComponentInChildren<ParticleSystem> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("Lava")){
			playerAudio.PlayOneShot(lavadeath);
			GetComponent<mainCharacterScript>().Ragdoll();
			playerParticles.Play();

		}
	}
}
