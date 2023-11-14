using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Riley Conlon
 * Date: 11/13/23
 * Function: Allows player to be associated with certain mechanics (Lives, Movement, etc.)
 */

public class PlayerController : MonoBehaviour
{
    //move speed
    public float playerSpeed = 15f;

    //jump height/force
    public float jumpForce = 5f;

    //Rayacst variable "hit"
    RaycastHit hit;

    //adds ridigbody variable (as opposed to the class) so theres something we can reference
    private Rigidbody rigidbody;

    //T/F values to which direction the Player is facing
    public bool isFacingRight = true;

    //Amount of damage Player can take before death
    public float hitPoints = 99;

    //Time player will blink after taking damage
    public float blinkTime = .3f;

    //reference shootingArm for blink coroutine
    public Shooting shootingArm;

    //indicates if the player is flashing
    public bool isBlinking = false;


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
            if (isFacingRight == true)
            {
                Flip();
            }
            print("Pressing Key A");
            transform.position += Vector3.left * playerSpeed * Time.deltaTime;
            //transform.position += transform.forward * Time.deltaTime * speed;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (isFacingRight== false)
            {
                Flip();
            }
            print("Pressing Key D");
            transform.position += Vector3.right * playerSpeed * Time.deltaTime;
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


    //Allows things to be triggered, (takes damage, increase health, pickup items)
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            if (isBlinking == false)
            {
                hitPoints = hitPoints - 15;
                StartCoroutine(Blink());
            }
        }
    }

    //Will make the Player blink when damaged
    public IEnumerator Blink()
    {
        isBlinking = true;
        for (int index = 0; index < 17; index++)
        {
            if(index % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
                shootingArm.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
                shootingArm.GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(blinkTime);
            
        }
        GetComponent<MeshRenderer>().enabled = true;
        shootingArm.GetComponent<MeshRenderer>().enabled = true;
        isBlinking = false;
    }


    //Rotate Player and invert bool
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180.0f, 0);
    }
}
