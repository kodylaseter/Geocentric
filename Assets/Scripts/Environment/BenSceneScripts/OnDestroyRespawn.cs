using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

// Reloads current level when the player tag touches an object

public class OnDestroyRespawn : MonoBehaviour {
	
	void OnDestroy ()
	{	
		Application.LoadLevel(Application.loadedLevel);
	}
}
