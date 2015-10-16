using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour{

	public static SoundManager SM;

	public AudioClip[] defaultFootsteps;
	public AudioClip[] obsidianFootsteps;
	public AudioClip[] lavaFootsteps;
<<<<<<< HEAD
	public AudioClip[] collinGrass;
	public AudioClip[] collinStone;
=======
    public AudioClip[] musicBoxChordFootsteps;
>>>>>>> 57b1adebcc4b133fe6960e5c010715d2d3b6d954
	
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
<<<<<<< HEAD
		} else if (string.Compare (tag, "collinStone") == 0) {
			return collinStone [Random.Range (0, collinStone.Length)]; 
		} else if (string.Compare (tag, "collinGrass") == 0) {
			return collinGrass [Random.Range (0, collinGrass.Length)]; 
		}
		else return defaultFootsteps [Random.Range (0, defaultFootsteps.Length)];
=======
		} else if (string.Compare (tag, "musicBox") == 0) {
            return musicBoxChordFootsteps[Random.Range(0, musicBoxChordFootsteps.Length)];
        }
        else return defaultFootsteps [Random.Range (0, defaultFootsteps.Length)];
>>>>>>> 57b1adebcc4b133fe6960e5c010715d2d3b6d954
	}
}
