using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaugeBehavior : MonoBehaviour
{
    /*
    private float Jauge = 0f; // Min 0f - Max 5f
    private float timer = 0f;
    private float timer_multiplicator = 0f; // x3 max

    void Start()
    {
        Jauge = 0f;
        timer = 0f;
    }

    void Update()
    {
        // Increase when player jump and shoot
         if(Input.GetAxis("Vertical") > 0 || Input.GetAxis("Fire1") > 0f){
            Jauge = Jauge + 0.45f;
            timer = 0f;
        }

        timer = timer + Time.deltaTime;
        
        // Decrease with time
        if(timer > 2f && Jauge > 0.01f){
            Jauge = Jauge - 4f;
            timer = 0f;
        }
    


        // Make bullettime if it's higher than 150
        // Not balanced for now, just added to test the mechanic
        if(Jauge > 150f){
            Time.timeScale = 0.2f;
        }
        if(Jauge < 65f){
            Time.timeScale = 1f;
        }
        
        Debug.Log(Jauge);
    }*/
}
