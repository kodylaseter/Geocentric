﻿using UnityEngine;
using System.Collections;

// Team Gemometry
// Cora Wilson

public class LavaHit : MonoBehaviour {
	public AudioClip lavadeath;
	AudioSource playerAudio;
	ParticleSystem playerParticles;
	Rigidbody playerBody;

	// Use this for initialization
	void Start () {
		playerAudio = GetComponent<AudioSource> ();
		playerParticles = GetComponentInChildren<ParticleSystem> ();
		playerBody = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag.Equals("Lava")){
			playerAudio.PlayOneShot(lavadeath);
			playerBody.AddForce(new Vector3(0,5,0));
			GetComponent<mainCharacterScript>().Ragdoll();
//			playerParticles.Play();
		}
	}
}
