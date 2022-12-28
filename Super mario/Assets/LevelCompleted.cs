using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleted : MonoBehaviour
{   
    private AudioSource audioManager;

    void Awake(){
        audioManager = GetComponent<AudioSource> ();
    }

    void OnTriggerEnter2D(){
        audioManager.Play();
        GameManager.instance.lvlcmplted();
    }
}
