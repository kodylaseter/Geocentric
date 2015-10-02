using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour {

	public ItemSpawn itemSpawn; 
	public GameObject guiText;
	Text text;
	
	// Use this for initialization
	void Start () {
		text = guiText.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		int itemsSpawned = itemSpawn.getSpawnedItems ();

		if (text) {
			text.text = "Cubes Spawned: " + itemsSpawned;
		}
	}
}