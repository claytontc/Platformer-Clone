using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author:Riley Conlon
 * Date: 11/6/23
 * Function: Will code the shooting mechanic
 */

public class Shooting : MonoBehaviour
{
    public bool goingLeft;
    public GameObject projectilePrefab;
    public GameObject Player;

    //Reference an Empty GameObject for bullets to spawn at (end of arm)
    public GameObject spawnPoint;

    //Gives Raycast "hit" 
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast Line from arm
        //illlustrates cooldown length
        //Debug.DrawLine(transform.position, transform.position + Vector3.right * 1.8f, Color.red);

        //Allows for a cooldown between shots
        if (Input.GetKey(KeyCode.Space))
        {
            //Says pressing Spacebar
            Debug.Log("Pressing Spacebar");

            //If a bullet is still within the Raycast range (end variable, currently 2f
            //or 2 units) another bullet cannot be shot.
            if (Physics.Raycast(transform.position, Vector3.right, out hit, 1.8f))
            {
                //Debug.Log("Raycast Active");

                if (hit.collider.name == "Bullet")
                {
                    //Nothing if bullet is in the way
                }

            }
            else
            {
                ///Spacebar will shoot a bullet
                ShootBullet();
            }
        }
    }

    
    /// <summary>
    /// Will spawn a bulletPrefab on whatever object script is attached to
    /// </summary>
    public void ShootBullet()
    {
        //Spawn bullets at spawnPoint at the end of arm
        // made a spawnPoint because it was shooting multiple, so it is in the middle of the raycast
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.transform.position, projectilePrefab.transform.rotation);
        if (projectile.GetComponent<Bullet>())
        {
            projectile.GetComponent<Bullet>().goingLeft = goingLeft;
        }


    }


}
