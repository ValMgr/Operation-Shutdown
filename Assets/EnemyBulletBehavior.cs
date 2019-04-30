using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBulletBehavior : MonoBehaviour
{
    public float m_speed = 1000f;
    public Rigidbody2D m_rb2D;
    public string LevelToLoad = "Dead";
   

    float m_launchedTime;
    float m_projectilDuration = 1f; // Time before bullet disapear

    private void Start() {
        m_projectilDuration = 1f / Time.timeScale;
    }

    void Awake () {
        m_rb2D = gameObject.GetComponent<Rigidbody2D>();
        m_launchedTime = Time.realtimeSinceStartup;
    }

    public void Launch(Vector2 direction) {
        m_rb2D.AddForce(direction.normalized * m_speed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.realtimeSinceStartup > m_launchedTime + m_projectilDuration){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Ground"){
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player"){
            Destroy(gameObject);
            Destroy(collision.gameObject);
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
