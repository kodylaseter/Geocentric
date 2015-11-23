using UnityEngine;
using System.Collections;

public class StarSpawn : MonoBehaviour {

	public GameObject player;
	public GameObject star;
	public Camera mainCam;

	public GameObject uhoh;
	public GameObject head;


	private double timer;
	private double spawnTime;
	private bool clicked;


	// Use this for initialization
	void Start () {
		spawnTime = .001;

	}
	
	// Update is called once per frame
	void Update () {
		CreatePrefab();
		player.GetComponent<Rigidbody> ().AddTorque (new Vector3 (0,80, 0));
//		mainCam.transform.position = player.transform.position + (Vector3.up * 20);

		if (Input.anyKeyDown) {
			if (!clicked) {
				breaker();
				clicked = !clicked;
			} else {
				Application.LoadLevel ("StartMenu");
			}

		}
	}
	
	void CreatePrefab()
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
		{

			Instantiate(star, player.transform.position + new Vector3(0,-40,0)+(Random.insideUnitSphere * 20), Quaternion.identity);
			Instantiate(star, player.transform.position + new Vector3(0,-40,40)+(Random.insideUnitSphere * 50), Quaternion.identity);
			timer = spawnTime;
		}
	}

	void breaker() {
		Destroy (head.GetComponent<CharacterJoint> ());

		uhoh.SetActive (true);
	}
}
