using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour{

	public static SoundManager SM;

	public AudioClip[] defaultFootsteps;
	public AudioClip[] obsidianFootsteps;
	public AudioClip[] lavaFootsteps;
	
	void Awake()
	{
		if (SM != null) {
			GameObject.Destroy (SM);
		} else {
			SM  = this;
		}

		DontDestroyOnLoad (this);
	}

	public AudioClip GetSound(string tag)
	{
		if (string.Compare (tag, "Obsidian") == 0) {
			return obsidianFootsteps [Random.Range (0, obsidianFootsteps.Length)];
		} else if (string.Compare (tag, "Lava") == 0) {
			return lavaFootsteps [Random.Range (0, lavaFootsteps.Length)]; 
		}
		else return defaultFootsteps [Random.Range (0, defaultFootsteps.Length)];
	}
}
