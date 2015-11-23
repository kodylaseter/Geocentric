using UnityEngine;
using System.Collections;

public class BackgroundAudio : MonoBehaviour {

    private AudioSource backgroundAudio;
    public string backgroundMusicKey;

	// Use this for initialization
	void Start () {
        backgroundAudio = GetComponent<AudioSource>();
        print(backgroundAudio.name);
        print(SoundManager.SM.PlayBGMusic());
        if(SoundManager.SM.PlayBGMusic())
        {
            AudioClip toPlay = SoundManager.SM.GetBackgroundMusic(backgroundMusicKey);
            backgroundAudio.clip = toPlay;
            backgroundAudio.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
	    //if hit key to mute SE or BG, mute proper thing
	}
}
