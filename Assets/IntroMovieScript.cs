using UnityEngine;
using System.Collections;

public class IntroMovieScript : MonoBehaviour {

	int scene = 1;
	float alphaLevel;
	Animator stateManager; 
	GameObject cam;
	bool loaded;

	// Use this for initialization
	void Start () {
		cam = GameObject.Find ("Main Camera");
		stateManager = GameObject.Find ("StateManager").GetComponent<Animator>();
//		scene = 1;
		loaded = false;
		SceneLoader ();




	}
	
	// Update is called once per frame
	void Update () {
//		print (scene);
		AnimatorStateInfo animState = stateManager.GetCurrentAnimatorStateInfo (0); 
		
		if (animState.IsName ("FadeIn")) {
			GameObject.Find ("Fader").GetComponent<CanvasGroup> ().alpha -= .05f;

		} else if (animState.IsName ("FadeOut")) {
			GameObject.Find ("Fader").GetComponent<CanvasGroup> ().alpha += .05f;
			if (GameObject.Find ("Fader").GetComponent<CanvasGroup> ().alpha > .99&& !loaded) {
				SceneLoader ();
			}
		} else {
			if (Input.anyKeyDown) {

				scene +=1;
				stateManager.SetTrigger ("Fade");
				loaded = false;
			}
		}

	
	}

	public void SceneLoader() {
		if (scene == 5) {
			Application.LoadLevel ("StartMenu");
		}
		print ("Loading " + scene);
		GameObject.Find ("Scene" + (scene - 1)).transform.position -= Vector3.up * 100;
		GameObject.Find ("Scene" + scene).transform.position += Vector3.up * 100;
		GameObject.Find ("Text" + (scene)).GetComponent<CanvasGroup>().alpha = 1;
		GameObject.Find ("Text" + (scene - 1)).GetComponent<CanvasGroup>().alpha = 0;
		Transform newCamera = GameObject.Find ("Camera" + scene).transform;
		cam.transform.forward = newCamera.forward;
		cam.transform.position = newCamera.position;
		loaded = true;


	}
}
