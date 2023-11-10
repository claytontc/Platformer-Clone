using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author:Riley Conlon
 * Date: 11/9/23
 * Function: Will code the shooting mechanic
 */

public class Shooting : MonoBehaviour
{

    //Referencing important game objects
    public GameObject projectilePrefab;
    public GameObject Player;
    public GameObject spawnPoint;

    //Gives Raycast "hit" 
    RaycastHit hit;


    // Update is called once per frame
    void Update()
    {
        // Raycast Line from arm
        // illlustrates cooldown length
        // Debug.DrawLine(transform.position, transform.position + Vector3.right * 1.8f, Color.red);

        //Allows for a cooldown between shots
        if (Input.GetKey(KeyCode.Return))
        {
            //Says pressing Enter
            Debug.Log("Pressing Enter");

            //If a bullet is still within the Raycast range (end variable)
            //another bullet cannot be shot.
            if (Physics.Raycast(transform.position, Vector3.right, out hit, 8f))
            {
                Debug.Log("Raycast Active");

                if (hit.collider.name == "Bullet")
                {
                    //Nothing if bullet is in the way
                }
            }
            else
            {
                ///Enter will shoot a bullet
                ShootBullet();
            }        
        }        
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            ShootBullet();
        }
    }


    /// <summary>
    /// Will spawn a bulletPrefab 
    /// </summary>
    public void ShootBullet()
    {
        //Spawn bullets at spawnPoint at the end of arm
        // made a spawnPoint because it was shooting multiple, so it is in the middle of the raycast
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.transform.position,
        projectilePrefab.transform.rotation);
    }


}
