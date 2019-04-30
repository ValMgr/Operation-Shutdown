using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    public string m_direction;
    public DialogManager m_dialogDisplayer;


 

    public float speed = 200f;
    public float jumpForce = 30f;
    private bool isJumping = false;

    private float anim_timer = 0f;
    public Animator animator;

    public Rigidbody2D m_rb2D;
    private Rigidbody2D rb;
    public SpriteRenderer m_spriteRenderer;


    public GameObject m_ball;
    private float Firedelay = 0f;

    private void Start() {
        m_direction = "right";
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){


        // Movement to left or right and add gravity
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(move));

        if(Input.GetAxis("Horizontal") < 0f){
            m_direction = "left";
            m_spriteRenderer.flipX = true;

        }

        // Flip the sprite when you switch direction
        if(Input.GetAxis("Horizontal") > 0f){
            m_direction = "right";
            m_spriteRenderer.flipX = false;

        }
       
        Jump();
        Shoot();
  
        // Reset delay between 2shots to 0
        if(Firedelay > 0f){
            Firedelay = Firedelay - Time.deltaTime;
            if(Firedelay < 0f){
                Firedelay = 0f;
            }    
        }

        // Add ShootingAnim... Not working well because we don't have anim for shooting and walking in the same time
        anim_timer = anim_timer - Time.deltaTime;
        if(anim_timer < 0.01f){
            animator.SetBool("Shooting", false);
        }

    }


    void Shoot(){

        if (Input.GetAxis("Fire1") > 0f){

            animator.SetBool("Shooting", true);
            anim_timer = 0.4f;
           

            if(Firedelay == 0f){

                

                
                

                GameObject newBall = Instantiate(m_ball, this.transform.position, Quaternion.identity) as GameObject;
                PlayerBulletBehavior BallBehavior = newBall.GetComponent<PlayerBulletBehavior>();

                // Shoot to left
                if(m_direction == "left"){
                    BallBehavior.Launch(new Vector2(-1f, 0f));
                }
                // Shoot to right
                if(m_direction == "right"){
                    BallBehavior.Launch(new Vector2(1f, 0f));
                }
                
                Firedelay = 0.25f; // delay between 2 shots
            }

        }
    }


    // Jumping
    void Jump(){
        if(Input.GetAxis("Vertical") > 0 && !isJumping){
            isJumping = true;
            rb.AddForce(new Vector2 (rb.velocity.x, jumpForce * 1000f));
        }
    }



 



    // Collider with ground and obstacle
    private void OnCollisionEnter2D(Collision2D other) {
        // Test if player is grounded or not
        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Box")){
            isJumping = false;
            rb.velocity = Vector2.zero;
        }

  
    }




}
