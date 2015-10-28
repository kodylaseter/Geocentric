using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.IO;
using System.Linq;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class SoundManager : MonoBehaviour{

	public static SoundManager SM;

	Dictionary<string, List<AudioClip>> footstepTagMap;

	void Start()
	{
		footstepTagMap = CreateFootstepTagMap ("Music/Footsteps");
	}
	
	void Awake()
	{
		if (SM != null) {
			GameObject.Destroy (SM);
		} else {
			SM  = this;
		}

		DontDestroyOnLoad (this);
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

	public AudioClip GetSound(string tag)
	{
		List<AudioClip> clipList = new List<AudioClip>();
		if (footstepTagMap.ContainsKey (tag)) {
			//tag exists in map, use correct list
			clipList = footstepTagMap[tag];
		} else {
			//use default
			clipList = footstepTagMap["Default"];
		}
		//get a random sound from the list
		AudioClip ret = clipList [Random.Range (0, clipList.Count)];
		return ret;
	}
}
