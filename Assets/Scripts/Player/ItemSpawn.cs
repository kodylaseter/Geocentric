using UnityEngine;
using System.Collections;

public class ItemSpawn : MonoBehaviour {

	public GameObject item;
	public Transform[] spawnPoints;
	public int maxItems;
	public int spawnedItems;
	private bool m_isAxisInUse = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.R)) {
//			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
//			Instantiate (item, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
//			spawnedItems += 1;
//			print (getSpawnedItems ());
//		}
		if( Input.GetAxisRaw("placeItem") != 0)
		{	
			if(m_isAxisInUse == false)
			{
				// Call your event function here.
				if (spawnedItems < maxItems) {
					int spawnPointIndex = Random.Range (0, spawnPoints.Length);
					Instantiate (item, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
					spawnedItems += 1;
				}

				m_isAxisInUse = true;
			}
		}
		if( Input.GetAxisRaw("placeItem") == 0)
		{
			m_isAxisInUse = false;
		} 
	}

	public int getSpawnedItems() {
		return spawnedItems;
	}
}
