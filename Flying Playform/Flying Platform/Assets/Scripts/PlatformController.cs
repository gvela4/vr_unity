using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // movement target
    public Transform target;

    // speed
    public float speed = 1f;

    // flag that sets whether we are moving or not
    bool isMoving = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        // handle input
        HandleInput();

        // move our platform
        HandleMovement();
    }

    // take care of movement
    void HandleMovement()
    {
        if (isMoving)
        {
            // calculate teh distance from targetr
            float distance = Vector3.Distance(transform.position, target.position);
            // have we arrived?
            if (distance > 0)
            {
                // calcualte how much we need to move(step) d = v * t
                float step = speed * Time.deltaTime;
                // move by that step
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }
    }

    void HandleInput()
    {
        // check for fire1 axis
        if (Input.GetButtonDown("Fire1"))
        {
            // negate is moving
            isMoving = true;
        }
    }
}
