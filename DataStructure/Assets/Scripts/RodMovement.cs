using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class RodMovement : MonoBehaviour
{
    private Vector3 rodPos;
    private Vector3 initialPos;
    public static float speed = 3;
    private bool enableDown = false;
    private bool goUp = false;
    public static bool fishCaught = false;

    // Start is called before the first frame update
    void Start()
    {
        rodPos = transform.position;
        initialPos = transform.position;
            //initialize positions
    }

    // Update is called once per frame
    void Update()
    { 
        transform.rotation = quaternion.identity; //fix rotation
        rodPos.x = -4.7998f; //fix x pos
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            enableDown = true; 
        }

        if (enableDown)
        {
            rodPos.y -= speed * Time.deltaTime; //press ↓ to go down
        }

        if (goUp)
        {
            rodPos.y += 2 * speed * Time.deltaTime; //returning speed
        }

        if (rodPos.y >= initialPos.y) // if returned
        {
            enableDown = false;
            goUp = false;
            fishCaught = false; // reset bools
        }
        
        transform.position = rodPos; // update pos
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        goUp = true; // return

        if (col.gameObject.name.Contains("Fish"))
        {
            fishCaught = true;
            Fish.instance = col.gameObject.GetComponent<Fish>();
                //if collided with fish
        }
    }
}
