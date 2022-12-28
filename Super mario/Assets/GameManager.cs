using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public static GameManager instance= null;
    public GameObject LvlCmplt;
    public GameObject GameOver;

    
    void Awake(){

        if(instance ==null){
            instance=this;
        }
        else if( instance!=null)
        {
            Destroy(gameObject);   
        }
    }

    public void lvlcmplted(){
        LvlCmplt.SetActive(true);
        SceneManager.LoadScene("Gameplay2");
        // LvlCmplt.SetActive(false);
    }

    public void GameOverr(){
        GameOver.SetActive(true);
        Application.LoadLevel("Gameplay");
    }

    public void gamecompleted(){
        SceneManager.LoadScene("Main Menu");
        // LvlCmplt.SetActive(false);
    }

    
    
}
