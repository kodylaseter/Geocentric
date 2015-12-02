using UnityEngine;
using System.Collections;

public class FacePlantDetector : MonoBehaviour {

	// Use this for initialization
    bool isFaceplant = false;

    void OnTriggerEnter(Collider col)
    {
        isFaceplant = true;
       // print("FACEPLANT:" + isFaceplant);
    }

    void OnTriggerExit(Collider col)
    {
        isFaceplant = false;
       // print("FACEPLANT:" + isFaceplant);
    }

    public bool GetFaceplant()
    {
        return isFaceplant;
    }
}
