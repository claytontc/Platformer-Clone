using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author:Riley Conlon
 * Date: 11/9/23
 * Function: Gives the bullet Prefab speed and direction
 */

public class Bullet : MonoBehaviour
{
    //Bullet speed
    public float speed = 5f;

    //reference the playercontroller script
    //public GameObject Player;
    public PlayerController playerController;

    //Despawn Timer
    public float despawnTime = 2.5f;

    //facing right
    //public bool isFacingRight;


    // Update is called once per frame
    void Update()
    {
        //if (playerController.isFacingRight == true)
        if(transform.position.z <= -0.1 )
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }       
        //Despawn Bullets
        StartCoroutine(Despawn());
    }


    //Will despawn bullets after a certain time
    public IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        playerController.bulletCount++;
        Destroy(this.gameObject);
        
    }
}
