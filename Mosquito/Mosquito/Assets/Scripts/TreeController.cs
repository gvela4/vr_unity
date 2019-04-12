using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    // min and max scale values
    public float minScale = 0.7f;
    public float maxScale = 2.4f;
	// Use this for initialization
	void Start ()
    {
        // set Y position to ground level
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);

        // obtain a random scale
        float scale = Random.Range(minScale, maxScale);

        // change scale or *= scale
        transform.localScale = scale * transform.localScale;

        // random rotation value
        float rotationY = Random.Range(0, 360);

        // rotate about up y axis
        transform.Rotate(0, rotationY, 0, Space.World);

	}
}
