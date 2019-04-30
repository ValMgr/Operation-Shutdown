using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour {

    public string LevelToLoad;

    private void Update() {
        if(Input.anyKey){
            LoadLevel();
        }
    }

    void LoadLevel(){          
        SceneManager.LoadScene(LevelToLoad);
    }

}