using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class SoundManager : MonoBehaviour{

	public static SoundManager SM;

	public AudioClip[] defaultFootsteps;
	public AudioClip[] obsidianFootsteps;
	public AudioClip[] lavaFootsteps;
	public AudioClip[] collinGrass;
	public AudioClip[] collinStone;
    public AudioClip[] musicBoxChordFootsteps;
	public AudioClip[] crackedEarthfootsteps;
	
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
		} else if (string.Compare (tag, "collinStone") == 0) {
			return collinStone [Random.Range (0, collinStone.Length)]; 
		} else if (string.Compare (tag, "collinGrass") == 0) {
			return collinGrass [Random.Range (0, collinGrass.Length)]; 
		} else if (string.Compare (tag, "musicBox") == 0) {
			return musicBoxChordFootsteps [Random.Range (0, musicBoxChordFootsteps.Length)];
		} else if (string.Compare (tag, "CrackedFloor") == 0) {
			return crackedEarthfootsteps [Random.Range (0, crackedEarthfootsteps.Length)];

		}
        else return defaultFootsteps [Random.Range (0, defaultFootsteps.Length)];
	}
}
