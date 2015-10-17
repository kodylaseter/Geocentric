using UnityEngine;
using System.Collections;

// Plays game over animation and sound, and reloads level on collision with Player

public class GameOver : MonoBehaviour
{
    public string level;
    public GameObject canvas;
    public float restartDelay = 5f;         // Time to wait before restarting the level
    float restartTimer;                     // Timer to count up to restarting the level
    public AudioClip youdied;
    AudioSource deathflooraudio;

    void Awake(){
        deathflooraudio = GetComponent<AudioSource>();
        restartTimer = 0;
    }

    void Update(){
        if (restartTimer != 0){
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay){
                restartTimer = 0;
                Application.LoadLevel(level);
            }
        }
    }

    void OnCollisionEnter(Collision col){
        if (col.gameObject.tag.Equals("Player") && restartTimer == 0){
            canvas.GetComponent<Animator>().SetTrigger("GameOver");
            deathflooraudio.PlayOneShot(youdied);
            col.gameObject.GetComponent<mainCharacterScript>().Ragdoll();
            restartTimer += Time.deltaTime;
        }
    }

}
