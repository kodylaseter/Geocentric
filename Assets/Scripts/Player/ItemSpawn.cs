using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour {

	public GameObject item;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (item, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
	}
}
