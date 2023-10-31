using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public bool goingLeft;
    public GameObject projectilePrefab;
    public GameObject Player;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            ShootBullet();
            Debug.Log("Pressing Spacebar");
        }
    }

    private void ShootBullet()
    {
        
            GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            if(projectile.GetComponent<Bullet>())
            {
                projectile.GetComponent<Bullet>().goingLeft = goingLeft;
            }
        
    }
}
