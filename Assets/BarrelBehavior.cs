using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BarrelBehavior : MonoBehaviour
{
    public CircleCollider2D m_Collider;
    private bool explosion = false;
    private bool explosed = false;
    public string LevelToLoad = "Dead";
    public Animator animator;

    float Wait = 0f;

    private void Start() {
        m_Collider.radius = 0f;
    }

    private void Update() {        
        Wait = Wait - Time.deltaTime;
        Explosion();
    }

    void Explosion(){
        //When anim is finished extend the circle collider
        if(explosion == true && Wait < 0.001f){
            m_Collider.radius = 120f;
            explosed = true;           
        }
    }

    void OnTriggerEnter2D(Collider2D collision){

        // If a bullet hit the Barrel launch the animation
        if (collision.gameObject.tag == "AlliedBullets"){
            Destroy(collision.gameObject);
            animator.SetBool("Explosion", true);
            explosion = true;
            Wait = 0.75f;
        }
        // Delete everything in the circle collider
        if (explosed == true){
            Debug.Log("BOOM");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        // And if it's the player go to the death menu
        if (collision.gameObject.tag == "Player"){
            Destroy(gameObject);
            SceneManager.LoadScene(LevelToLoad);
        }
    }

}   
