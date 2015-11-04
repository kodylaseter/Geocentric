using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class ItemSpawnCycle : MonoBehaviour {

	GameObject item;
	public int itemNum = 0;
	public GameObject[] items;
	public Transform spawnPoint;
	public int maxItems = 1000; //this + spanwedItems as base for energy system
	public int spawnedItems; 
	private bool m_isAxisInUse = false; 
	private bool m_placeAxisInUse = false;

	public Text spawnText;
	public Image prevSpawnItem;
	public Image currentSpawnItem;
	public Image nextSpawnItem;

	//set these up in start
	private int nextItemNum;
	private int prevItemNum;
	private Sprite[] itemIcons;

	//get small image of thing
	//if end of list, grab pic from beginning
	//if start of list, get pic from end
	//holy shit a doubly-linked, cyclic linked list would be PERF

	// Use this for initialization
	void Start () {
		item = items [itemNum];
		itemIcons = CreateIconArray ("Icons");
		//load up a map of item things
		//for item in items, get appropriate picture, add to array
		//have some "default" star for unaccounted for spawns
		//then at each update, display proper rotation
	
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
					//print(itemNum);
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
		UpdateItemNums ();
		print ("PREV" + prevItemNum);
		print ("CURRENT" + itemNum);
		print ("NEXT" + nextItemNum);

		prevSpawnItem.sprite = itemIcons [prevItemNum];
		currentSpawnItem.sprite = itemIcons [itemNum];
		nextSpawnItem.sprite = itemIcons [nextItemNum];
		spawnText.text = "Item to Spawn: " + items [itemNum].name;



	}

	public int getSpawnedItems() {
		return spawnedItems;
	}

	private void UpdateItemNums()
	{
		prevItemNum = itemNum - 1;

		//if the previous item number hits negatives, make it circle to the last
		if(prevItemNum < 0){
			prevItemNum = items.Length - 1;
		}

		nextItemNum = itemNum + 1;
		if (nextItemNum >= items.Length) {
			nextItemNum = 0; //reset to beginning
		}
	}

	private Sprite[] CreateIconArray(string iconDirectory)
	{
		Sprite[] retArray = new Sprite[items.Length];
		int counter = 0;
		foreach (GameObject item in items) {
			Sprite temp = Resources.Load(iconDirectory + "/" + item.name, typeof(Sprite)) as Sprite;
			//SHOULD load only the needed item icons
			retArray[counter] = temp;
			print(iconDirectory+"/"+item.name);
			print (temp.name);
			counter++;
		}
		print (retArray.Length);
		return retArray;
	}
}
