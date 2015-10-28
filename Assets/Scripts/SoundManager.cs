using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class SoundManager : MonoBehaviour{

	public static SoundManager SM;

	Dictionary<string, List<AudioClip>> footstepTagMap;

//	void Start()
//	{
//		footstepTagMap = CreateFootstepTagMap ("Assets/Resources/Music/SoundEffects/Footstep");
//	}
	
	void Awake()
	{
		if (SM != null) {
			GameObject.Destroy (SM);
		} else {
			SM  = this;
		}

		DontDestroyOnLoad (this);
	}

//	Dictionary<string, List<AudioClip>> CreateFootstepTagMap(string resourceDirectory)
//	{
//		//placeholder empty dictionary to fill and return
//		Dictionary<string, List<AudioClip>> returnDict = new Dictionary<string, List<AudioClip>>{};
//
//		DirectoryInfo stepDir = new DirectoryInfo (resourceDirectory);
//		DirectoryInfo[] soundDirs = stepDir.GetDirectories ();
//		foreach (DirectoryInfo tagDir in soundDirs) {
//			//make sure to only get sound files
//			FileInfo[] soundFiles  = tagDir.GetFiles("*.wav");
//			//the tag to use in the project is the same as the directory name
//			string tag = tagDir.Name;
//
//			List<AudioClip> temp = new List<AudioClip>();
//			//for each clip in the folder, load the clip and add it to the list
//			foreach (FileInfo sound in soundFiles)
//			{
//				string soundName = sound.Name;
//				AudioClip audio = UnityEditor.AssetDatabase.LoadAssetAtPath(resourceDirectory+"/"+tag+"/"+soundName, typeof(AudioClip)) as AudioClip;
//				temp.Add(audio);
//			}
//			//add the tag and list entry to the dictionary
//			returnDict.Add(tag, temp);
//		}
//
//		return returnDict;
//	}

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
