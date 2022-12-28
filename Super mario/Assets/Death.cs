using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject GameOver;

    void OnTriggerEnter2D(){
        GameManager.instance.GameOverr();
    }
}
