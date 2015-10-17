using UnityEngine;
using System.Collections;

// Team Gemometry
// Ben Seco, Collin Caldwell, Cora Wilson, Kody Laseter, Monet Tomioka

// Loads specified level on collision with Player

public class GameOver : MonoBehaviour
{

    public string level;
    Animator anim;
    public float restartDelay = 5f;         // Time to wait before restarting the level
    float restartTimer;                     // Timer to count up to restarting the level
    
    void OnCollisionEnter(Collision col)
    {
        var otherGameObject = GameObject.Find("Canvas");        //Destroy(col.gameObject);
        if (col.gameObject.tag.Equals("Player"))
        {
            Animator anim = otherGameObject.GetComponent<Animator>();
            anim.SetTrigger("GameOver");

            restartTimer = 0;
            
        }

    }

    void OnCollisionStay(Collision col) {
        restartTimer += Time.deltaTime;
        if (restartTimer >= restartDelay)
        {
            Application.LoadLevel(level);
        }
    }

}
