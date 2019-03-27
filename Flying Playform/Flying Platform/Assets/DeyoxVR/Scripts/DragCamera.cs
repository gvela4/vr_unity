using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeyoxVR // can be accessed from other classes just by using DeyoxVR namespace
{
    public class DragCamera : MonoBehaviour
    {
    #if UNITY_EDITOR

        // flag to keep track whether we are dragging or not
        bool isDragging = false;

        float startMouseX;
        float startMouseY;

        // camera component
        Camera cam;

        // Use this for initialization
        void Start()
        {
            /// get camera component
            cam = GetComponent<Camera>();
        }

        // Update is called once per frame
        void Update()
        {
            // if we press left button and havent started dragging
            if (Input.GetMouseButtonDown(1) && !isDragging)
            {
                // set flag to true
                isDragging = true;

                // save mouse started position
                startMouseX = Input.mousePosition.x;
                startMouseY = Input.mousePosition.y;
            }
            // if we are not pressing the left butn, we were dragging
            else if (Input.GetMouseButtonUp(1) && isDragging)
            {
                // set flag to false
                isDragging = false;
            }
        }

        void LateUpdate()
        {
            // check if we are dragging
            if (isDragging)
            {
                // calculate current mouse position
                float endMouseX = Input.mousePosition.x;
                float endMouseY = Input.mousePosition.y;

                // difference in screen coordinates
                float diffX = endMouseX - startMouseX;
                float diffY = endMouseY - startMouseY;

                // new center of the screen
                float newCenterX = Screen.width / 2 + diffX;
                float newCenterY = Screen.height / 2 + diffY;

                // get world coordinate, this is where we should be looking at
                // screen to world point
                Vector3 LookHerePoint = cam.ScreenToWorldPoint(new Vector3(newCenterX, newCenterY, cam.nearClipPlane));

                // make camera look at the lookherepoint
                transform.LookAt(LookHerePoint);

                //starting position for next call
                startMouseX = endMouseX;
                startMouseY = endMouseY;
            }
        }
    #endif
    }
}

