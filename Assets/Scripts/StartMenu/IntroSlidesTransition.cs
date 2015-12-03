using UnityEngine;
using System.Collections;

public class IntroSlidesTransition : MonoBehaviour {

	int count;
	// Use this for initialization
	void Start () {
		count = 0;
		//InvokeRepeating("Counter", 0.0, 1.0);
	}

	// Update is called once per frame
	void Update () {
		if(Time.time >= count){
			count += 1;
		}
		if(count ==60)
			Application.LoadLevel("StartMenu");
	}

	void Counter(){
		count += 1;
	}

}
