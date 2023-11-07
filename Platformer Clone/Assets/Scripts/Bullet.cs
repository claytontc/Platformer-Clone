using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author:Riley Conlon
 * Date: 11/6/23
 * Function: Gives the bullet Prefab speed and direction
 */

public class Bullet : MonoBehaviour
{
    //Bullet speed
    public float speed = 5f;

    //Bullet direction
    public bool goingLeft;

    //Despawn Timer
    public float despawnTime = 2.5f;

    // Update is called once per frame
    void Update()
    {
        //Bullet will go at (speed) in whichever direction (hopefully)
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        if(goingLeft == false)
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }

        //Despawn Bullets
        StartCoroutine(Despawn());
         
    }

    



    //Will despawn bullets after a certain time
    public IEnumerator Despawn()
    {
        yield return new WaitForSeconds(despawnTime);
        Destroy(this.gameObject);
    }
}
