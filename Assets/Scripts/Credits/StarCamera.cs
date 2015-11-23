using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

public class StarCamera : MonoBehaviour {
	
	public float turnSpeed = 4.0f;
	public GameObject player;
	//	public Transform player;
	public float xOffset;
	public float yOffset;
	public float zOffset;
	public float scale;
	Transform playerPosition;
	
	private Vector3 offset;
	
	void Start () {
		offset = (player.transform.forward * zOffset) + new Vector3 (0, yOffset,0 ); ;
		//		offset = new Vector3( xOffset,yOffset, zOffset);
		playerPosition = player.transform;
	}
	
	void LateUpdate() {



			transform.position = Vector3.Lerp (transform.position,playerPosition.position + offset,.9f);
			transform.LookAt(playerPosition.position);
		
	}
	
}