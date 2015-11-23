using UnityEngine;
using System.Collections;

public class starScript : MonoBehaviour {
	public float despawnTime;
	public int moveSpeed;

	private double timer;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		transform.position += transform.position + (Vector3.up * moveSpeed);
		despawnTime -= Time.deltaTime;
		if (despawnTime <= 0)
		{
			
			Destroy (gameObject);
		}
	}
}
