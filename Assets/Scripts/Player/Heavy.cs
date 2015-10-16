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
            print("hey");
            rex.GetComponent<Animator>().speed = 0.5f;
        }
        else rex.GetComponent<Animator>().speed = 1f;
    }

}
