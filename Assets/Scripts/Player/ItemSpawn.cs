using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class ItemSpawn : MonoBehaviour {

	GameObject item;
	public int itemNum = 0;
	public GameObject[] items;
	public Transform spawnPoint;
	public int maxItems = 1000;
	public int spawnedItems;
	private bool m_isAxisInUse = false;
	private bool m_placeAxisInUse = false;
	public Text spawnText;

	// Use this for initialization
	void Start () {
		item = items [itemNum];
	
	}
	
	// Update is called once per frame
	void Update () {

		// Handles placing items
		if( Input.GetAxisRaw("placeItem") != 0)
		{	
			if(m_isAxisInUse == false)
			{
				// Call your event function here.
				if (spawnedItems < maxItems) 
				{
					Instantiate (item, spawnPoint.position, spawnPoint.rotation);
					spawnedItems += 1;
				}
				
				m_isAxisInUse = true;
			}
		}
		if( Input.GetAxisRaw("placeItem") == 0)
		{
			m_isAxisInUse = false;
		} 

		// Handles Changing Items

		if( Input.GetAxisRaw("changeItem") != 0)
		{	
			if(m_placeAxisInUse == false)
			{
				// Call your event function here.
				if (Input.GetAxisRaw ("changeItem") > 0) 
				{
					if (itemNum < items.Length - 1) 
					{
						itemNum += 1;
					} else 
					{
						itemNum = 0;
					}
					item = items [itemNum];
				} else if (Input.GetAxisRaw ("changeItem") < 0) {
					if (itemNum > 0) 
					{
						itemNum -= 1;
					} else 
					{
						itemNum = items.Length - 1;
					}
					print(itemNum);
					item = items[itemNum];
				}
				
				m_placeAxisInUse = true;
			}
		}
		if( Input.GetAxisRaw("changeItem") == 0)
		{
			m_placeAxisInUse = false;
		} 

		// Handles Changing Items
		if (spawnText != null) {
			spawnText.text = "Item to Spawn: " + items [itemNum].name;
		}


	}

	public int getSpawnedItems() {
		return spawnedItems;
	}
}
