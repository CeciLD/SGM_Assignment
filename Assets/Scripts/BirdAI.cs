using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAI : MonoBehaviour {

    public float amplitude = 0.1f;
    public float frequency = 1f;
    private bool goesRight;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        //posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posOffset = transform.position;
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
        if (transform.position.x <= -50)
        {
            goesRight = true;
            //transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 8);
        }
        if(transform.position.x >= 50)
        {
            goesRight = false;
        }

        if (goesRight)
        {
            transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * 8);
        }
        if (!goesRight)
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 8);
        }
    }
}
