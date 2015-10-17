using UnityEngine;
using System.Collections;

public class Heavy : MonoBehaviour {
    GameObject rex;

    void Awake() {
        rex = GameObject.Find("Rex");
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag.Equals("Snow")){
            rex.GetComponent<Animator>().speed = 0.5f;
        }
        else rex.GetComponent<Animator>().speed = 1f;
    }

}
