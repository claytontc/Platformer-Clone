using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : MonoBehaviour
{
    //Detect player
    RaycastHit hit;

    //speed
    public float enemySpeed = 5f;

    public int HP = 15;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 8f) && hit.collider.name == "Player")
        {
            if (hit.collider.name == "Player")
            {
                transform.position += Vector3.right * enemySpeed * Time.deltaTime;
            }
        }

        if (Physics.Raycast(transform.position, Vector3.left, out hit, 8f) && hit.collider.name == "Player")
        {
            if (hit.collider.name == "Player")
            {
                transform.position += Vector3.left * enemySpeed * Time.deltaTime;

            }
        }
    }

    //Removes HP
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            HP--;
            Dead();
        }
    }

    //kills enemy
    public void Dead()
    {
        if (HP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
