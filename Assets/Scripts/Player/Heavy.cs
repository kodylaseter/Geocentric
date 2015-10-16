using UnityEngine;
using System.Collections;

public class Heavy : MonoBehaviour {
    CapsuleCollider playerCollider;
    GameObject rex;

    void Awake() {
        playerCollider = GetComponent<CapsuleCollider>();
        rex = GameObject.Find("Rex");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Snow"))
        {
            //print("hey");
            rex.GetComponent<mainCharacterScript>().speed = 2;
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.tag.Equals("Snow"))
        {
            rex.GetComponent<mainCharacterScript>().speed = 15;
        }
    }
}
