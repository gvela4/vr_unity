using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class MosquitoController : MonoBehaviour
{
    // moving speed
    public float speed = 0.5f;

    // minimum distance from us
    public float minDistance = 0.55f;

    // vr interactive item
    VRInteractiveItem vrIntItem;

    // rigibody
    Rigidbody rb;

    // flag to keep track whether the mosquito is moving
    bool isMoving = true;

    // target 
    Vector3 target;

	// Use this for initialization
	void Awake ()
    {
        // grab vr interactive component
        vrIntItem = GetComponent<VRInteractiveItem>();

        // grab rigibody component
        rb = GetComponent<Rigidbody>();

        // set target
        target = Camera.main.transform.position;

        // make mosquito look at us
        transform.LookAt(target);
	}

    // when our game object is enabled
    void OnEnable()
    {
        vrIntItem.OnClick += HandleClick;
    }

    // when the game object is disabled 
    void OnDisable()
    {
        vrIntItem.OnClick -= HandleClick;
    }

    // this is called when the mosquito is clicked on
    void HandleClick()
    {
        // check if it's moving
        if (rb.isKinematic)
        {
            // rotate transform
            transform.Rotate(new Vector3(0, 0, 180));

            // disable kinematic property
            rb.isKinematic = false;

            // set flag to false
            isMoving = false;
        }
    }



    // Update is called once per frame
    void Update ()
    {
        // check that we are moving
        if (isMoving)
        {
            // calculate distance from target
            float distance = Vector3.Distance(transform.position, target);

            // check min distance
            if (distance <= minDistance)
            {
                // we stop
                isMoving = false;
            }
            else
            {
                // calcualte movement step v = d/t
                float movementStep = speed * Time.deltaTime;

                // move on that step
                transform.position = Vector3.MoveTowards(transform.position, target, movementStep);
            }
        }
	}
}
