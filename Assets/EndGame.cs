using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string LevelToLoad = "End";

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            SceneManager.LoadScene(LevelToLoad);
        }
    }
    
}
