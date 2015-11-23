using UnityEngine;
using System.Collections;

// Team Geocentric
// Collin Caldwell


public class selectionScript : MonoBehaviour {

	public GameObject[] mainText;
	public GameObject[] levelText;
	private GameObject[] selectedArray;
	public GameObject selected;
	public int selectNum;
	public bool m_isVerticalInUse = false;

	// Use this for initialization
	void Start () {
		selectedArray = mainText;

		selectNum = 0;
		selected = selectedArray [selectNum];
		changeSelector ();
//		print (selected);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			selected.GetComponent<MenuControl> ().Enter ();
//			changeArray();

		} 

		if( Input.GetAxisRaw("Vertical") != 0)
		{	
			if(m_isVerticalInUse == false)
			{
				// Call your event function here.
				if (Input.GetAxisRaw ("Vertical") > 0) 
				{
					selectNum--;
					changeSelector();
				} else if (Input.GetAxisRaw ("Vertical") < 0) {
					selectNum++;
					changeSelector();
				}
				
				m_isVerticalInUse = true;
			}
		}
		if( Input.GetAxisRaw("Vertical") == 0)
		{
			m_isVerticalInUse = false;
		} 
	
	}

	void changeSelector() {
		// Changes color of previous text to white, sets newly selected thing to red, changes Selected to new text
		if (selectNum < 0) {
			selectNum = selectedArray.Length - 1;
		}
//		print (selectNum);
		selected.GetComponent<TextMesh>().color = Color.white;
		selected = selectedArray [(selectNum%selectedArray.Length)];
		selected.GetComponent<TextMesh>().color = Color.red;
	}

	public void updateSelector(GameObject newText) {
		// Gets called from the text itself to tell this script a mouse is pointing at it.
		for (int i = 0; i < selectedArray.Length; i++) {
			if ( newText.Equals (selectedArray[i])) {
				selectNum = i;
				changeSelector ();
			}
		}
	}
	public void changeArray() {
		selected.GetComponent<TextMesh>().color = Color.white;
		if (selected.GetComponent<MenuControl>().notLevelSelector && selectedArray.Equals (mainText)) {
			selectedArray = levelText;
		} else {
			selectedArray = mainText;
		}
		selectNum = 0;
		selected = selectedArray [selectNum];
		changeSelector ();
	}

	public void wipe() {
		if (selectedArray.Equals (levelText)) {
			turnTextWhite(mainText);
		} else {
			turnTextWhite(levelText);
		}
	}

	void turnTextWhite(GameObject[] text) {
		for (int i = 0; i < text.Length; i++) {
			text[i].GetComponent<TextMesh>().color = Color.white;
		}
	}
	
}
