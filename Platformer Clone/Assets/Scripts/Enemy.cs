using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: [Cranford, Clayton]
 * Last Updated: [11/7/2023]
 * [handles the basic enemy that goes from side to side]
 */
public class Enemy : MonoBehaviour
{
    public float speed;
    private Vector3 leftPos;
    private Vector3 rightPos;
    public GameObject leftPoint;
    public GameObject rightPoint;
    public bool goingLeft;
    // Start is called before the first frame update
    void Start()
    {
        leftPos = leftPoint.transform.position;
        rightPos = rightPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// allows the enemy to move from side to side
    /// </summary>
    private void EnemyMove()
    {
        if(goingLeft == true)
        {
            if(transform.position.x <= leftPos.x)
            {
                goingLeft = false;
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else
        {
            if(transform.position.x >= rightPos.x)
            {
                goingLeft = true;
            }
            else
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
}
