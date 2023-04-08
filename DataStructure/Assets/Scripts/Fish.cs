using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public static Fish instance;
    private Vector3 fishPos;
    public float speed = 3;
    public float ySpeed;

    // Start is called before the first frame update
    void Start()
    {
        fishPos = transform.position; // initialize
    }

    // Update is called once per frame
    void Update()
    {
        if (!RodMovement.fishCaught)
        {
            speed *= 1; // default situation
        }
        
        else
        {
            instance.speed = 0; // if caught
            instance.fishPos.y += ySpeed * Time.deltaTime; // goes up with the rod
                                                           // but acting very weird 
                                                           // probably b/c of RigidBody2D & multiple instances
                                                           //was working fine when only one fish
        }
        
        fishPos.x -= speed * Time.deltaTime;
        transform.position = fishPos; // update pos
        
        transform.rotation = Quaternion.Euler(0,0,90); // set rotation
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Contains("Airwall"))
        {
            speed *= -1; // bounce back 
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Invoke("AddFish", 0.5f); 
    }

    public void AddFish()
    {
        Destroy(gameObject);
        
        if (gameObject.name.Contains("S")) // add different strings based on different types
        {
            GameManager.instance.AddFishes("Small", 30);
        }
        if (gameObject.name.Contains("M"))
        {
            GameManager.instance.AddFishes("Medium", 50);
        }
        if (gameObject.name.Contains("L"))
        {
            GameManager.instance.AddFishes("Large", 100);
        }
    }
}
