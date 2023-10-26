using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Riley Conlon
 * Date: 10//23
 * Function:
 */

public class PlayerController : MonoBehaviour
{
    //move speed
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //Allows the Player to move left and right
        if (Input.GetKey(KeyCode.A))
        {
            print("Pressing Key A");
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            print("Pressing Key D");
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
