using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Riley Conlon
 * Date: 11/9/23
 * Function:Allow camera to stay where it is instead of 
 * rotating with the player
 */

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        //transform.position of camera - transform position of the target
        offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //as target moves camera will follow
        transform.position = target.transform.position + offset;
    }
}
