using UnityEngine;
using System.Collections;

// Team Gemometry
// Cora Wilson

public class GroundTagScript : MonoBehaviour {

	// Use this for initialization
	string currentGroundTag = "Default";
    bool isGrounded = true;

	void OnTriggerEnter(Collider col)
	{
		currentGroundTag = col.gameObject.tag;
//		print ("GroundTagScript" + currentGroundTag);
		//print(currentGroundTag);
        isGrounded = true;
        //print(isGrounded);
	}

    void OnTriggerExit(Collider col)
    {
        isGrounded = false;
        //print(isGrounded);
    }

	public string GetGroundTag()
	{
		return currentGroundTag;
	}

    public bool GetGrounded()
    {
        return isGrounded;
    }
}
