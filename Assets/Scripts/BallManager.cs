using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject ball;
    public Transform[] spawnPoints;


    void Start ()
    {
    }


    void Update ()
    {

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		if (Input.GetKeyDown(KeyCode.R)){
			Instantiate (ball, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}

    }
}