using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Riley Conlon
 * Date: 11/6/23
 * Function: Allows player to be associated with certain mechanics (Lives, Movement, etc.)
 */

public class PlayerController : MonoBehaviour
{
    //move speed
    public float speed = 15f;

    //jump height/force
    public float jumpForce = 5f;

    //Rayacst variable "hit"
    RaycastHit hit;

    //adds ridigbody variable (as opposed to the class) so theres something we can reference
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        //set reference to the player's attached rigidbody
        rigidbody = GetComponent<Rigidbody>();
        
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


        //Raycast line from Player down
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.5f, Color.red);

        //Handles jumping
        if (Input.GetKey(KeyCode.Space))
        {
            print("Pressing Space");

            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                //My attempt at a jump function. Little janky, not Impulse
                //transform.position += Vector3.up * jumpForce * Time.deltaTime;
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            

        }
    }
}
