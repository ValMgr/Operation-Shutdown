using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public int EnemyType = 0; // 0 = Standart behavior (Moving randomly right and left) - 1 = Static - 2 = static but looking to right and left

    public Rigidbody2D rb2d;
    public SpriteRenderer m_spriteRenderer;

    public float speed = 200f;
    public string m_direction = "right";


    
    public GameObject Target;
    public GameObject m_ball;
    private float Firedelay = 0f;
    float distance = 0f;

    private float StartingPosX;
    private Vector3 StartingPos;
    private float distance_from_origin = 0f;
    private Rigidbody2D rb;
    float Moovetimer = 0.7f;

    private int ActualStep = 0;

    void Start() {
        StartingPosX = transform.position.x;
        StartingPos = new Vector3(StartingPosX, transform.position.y, transform.position.z);
        rb = GetComponent<Rigidbody2D>();


        
    }

    // Update is called once per frame
    void Update()
    {

        // Reset delay between 2shots to 0
        if(Firedelay > 0f){
            Firedelay = Firedelay - Time.deltaTime;
            if(Firedelay < 0f){
                Firedelay = 0f;
            }    
        }

        
        
        distance = Vector3.Distance(transform.position, Target.transform.position);
        //Debug.Log(Target.transform.position.x);
        
        
        distance_from_origin = Vector3.Distance(transform.position, StartingPos);
        
        if(EnemyType == 0){
            if(distance_from_origin < 500f){

                
                Moovetimer = Moovetimer - Time.deltaTime;
                

                if(Moovetimer < 0f){

                    int random = Random.Range(0, 12);
                    

                    //if random = 1, 2, 3
                    if(ActualStep > 0 && ActualStep < 4){
                        m_direction = "right";
                        rb.velocity = new Vector2(speed, rb.velocity.y);
                    }
                    //if random = 4, 5, 6
                    if(ActualStep > 3 && ActualStep < 7){
                        m_direction = "left";
                        rb.velocity = new Vector2(- speed, rb.velocity.y);
                    }
                    //if random = 7, 8, 9, 10 and more
                    // Nothing because he's not mooving
                
                    if(IsBetween(ActualStep, 0, 3) && IsBetween(random, 0, 3)){
                        Moovetimer = 0.1f;
                    }
                    if(IsBetween(ActualStep, 4, 6) && IsBetween(random, 4, 6)){
                        Moovetimer = 0.1f;
                    }
                    if(IsBetween(ActualStep, 7, 12) && IsBetween(random, 7, 12)){
                        Moovetimer = 0.7f;
                    }

                      ActualStep = random;  

                }
            }
        }


        // Switching direction to look the player when he is too close
        //  /!\ Not definitif /!\
        if(distance < 800f && m_direction == "right"){
            if(Target.transform.position.x < transform.position.x){
                m_direction = "left";
                
            }
        }
        if(distance < 800f && m_direction == "left"){
            if(Target.transform.position.x > transform.position.x){
                m_direction = "right";
            }
        }



        SpriteDirection();
        Shoot();
    }

    // Method to check if a number is inside an interval or not
    static bool IsBetween(int Nbr, int start, int end){
        return Comparer.Default.Compare(Nbr, start) >= 0 && Comparer.Default.Compare(Nbr, end) <= 0;
    }


    // Just flip the sprite in the good direction lmao
    private void SpriteDirection(){
        if(m_direction == "right"){
            m_spriteRenderer.flipX = false;
        }
        if(m_direction == "left"){
            m_spriteRenderer.flipX = true;
        }
    }

    private void Shoot(){

        if(Firedelay == 0f && distance < 800f){
               
                GameObject newBall = Instantiate(m_ball, this.transform.position, Quaternion.identity) as GameObject;
                EnemyBulletBehavior BallBehavior = newBall.GetComponent<EnemyBulletBehavior>();

                if(Target.transform.position.x > 0){
                    BallBehavior.Launch(new Vector2(- Target.transform.position.x, Target.transform.position.y));
                }
                else{
                    BallBehavior.Launch(new Vector2(Target.transform.position.x, Target.transform.position.y));
                }
                Firedelay = 0.8f; // delay between 2 shots
            }

    }



}
