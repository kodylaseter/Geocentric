using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Team Gemometry
//Cora Wilson

public class SoundManager : MonoBehaviour{

    //protected SoundManager() {}

    public static SoundManager SM = null;

    private bool playSoundEffects;
    private bool playBackgroundMusic;

    private AudioSource bgAudioSource;
    private bool justCreated = true;

	Dictionary<string, List<AudioClip>> footstepTagMap;
    Dictionary<string, AudioClip> backgroundMusicMap;
    Dictionary<string, AudioClip> soundEffectMap;

    AudioClip currentBGMusic;

	void Start()
	{
        playSoundEffects = true;
        playBackgroundMusic = true;

        bgAudioSource = GetComponent<AudioSource>();
        backgroundMusicMap = CreateMusicMap("Music/Background");
        soundEffectMap = CreateMusicMap("Music/SoundEffects");
		footstepTagMap = CreateFootstepTagMap ("Music/Footsteps");

        bgAudioSource.loop = true;

        if(justCreated)
        {
            ChangeBGMusic("GeometryGameBG1");
        }  
	}

    //called once a frame
    //mute sound if needed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            playBackgroundMusic = !playBackgroundMusic;
            if(playBackgroundMusic)
            {
                bgAudioSource.Play();
            }
            else
            {
                bgAudioSource.Stop();
            }
        }
    }
    
	
	void Awake()
	{
		if (SM != null) {
            justCreated = false;
            //idk why it MUST make two and only two but whatever
            //this keeps it running
			//Destroy (SM);
		} else {
			SM  = this;
            DontDestroyOnLoad(this);
		}
	}

    Dictionary<string, AudioClip> CreateMusicMap(string resourceDirectory)
    {
        Dictionary<string, AudioClip> returnDict = new Dictionary<string, AudioClip> { };
        var sounds = Resources.LoadAll(resourceDirectory, typeof(AudioClip)).Cast<AudioClip>();

        foreach(var sound in sounds){
            returnDict.Add(sound.name, sound);
        }

        return returnDict;
    }

	Dictionary<string, List<AudioClip>> CreateFootstepTagMap(string resourceDirectory)
	{
		//placeholder empty dictionary to fill and return
		Dictionary<string, List<AudioClip>> returnDict = new Dictionary<string, List<AudioClip>>{};

		//set the delimeters for the things
		char[] delimiters = {'.'};
		//get all the footstep sounds
		var footsteps = Resources.LoadAll (resourceDirectory, typeof(AudioClip)).Cast<AudioClip>();
		foreach(var step in footsteps){
			//parse the name into parts
			//note: name of a step must be tag.#.wav to be properly recognized as a playable file
			string[] parsedStep = step.name.Split(delimiters);
			string tag = parsedStep[0];

			//if the tag is already logged, add the new step to the step list currently stored
			if(returnDict.ContainsKey(tag))
			{
				returnDict[tag].Add(step);
			} else {
				//else create a new entry in the dictionary and add the step to a new list
				List<AudioClip> newStepList = new List<AudioClip>{step};
				returnDict.Add (tag, newStepList);
			}
		}
		return returnDict;
	}

	public AudioClip GetFootstepSound(string tag)
	{
        List<AudioClip> clipList = new List<AudioClip>();
        if (footstepTagMap.ContainsKey(tag))
        {
            //tag exists in map, use correct list
            clipList = footstepTagMap[tag];
        }
        else
        {
            //use default
            clipList = footstepTagMap["Default"];
        }
        //get a random sound from the list
        AudioClip ret = clipList[Random.Range(0, clipList.Count)];
        return ret;
	}

    public AudioClip GetBackgroundMusic(string key)
    {
        AudioClip ret = null;
        if (backgroundMusicMap.ContainsKey(key))
        {
            ret = backgroundMusicMap[key];
        }
        else
        {
           ret = backgroundMusicMap["GeometryGameBG1"];
        }
        return ret;
    }

    public AudioClip GetSoundEffect(string key)
    {
        AudioClip ret = null;
        if(playSoundEffects && backgroundMusicMap.ContainsKey(key))
        {
            ret = soundEffectMap[key];
        }
        //if return null, no sound effect or SEs turned off
        return ret;
    }
    
    public bool PlayBGMusic()
    {
        return playBackgroundMusic;
    }

    public bool PlaySoundEffects()
    {
        return playSoundEffects;
    }
    
    public void ChangeBGMusic(string level)
    {
        bgAudioSource.Stop();
        bgAudioSource.clip = GetBackgroundMusic(level);
        if(playBackgroundMusic)
        {
            bgAudioSource.Play();
        }
    }
}
