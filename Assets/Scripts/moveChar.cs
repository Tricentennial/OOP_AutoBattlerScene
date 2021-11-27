using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChar : MonoBehaviour
{

    private float moveTime = 2.0f;
    private float stopTime = 4.0f;
    private float stopWatch = 0.0f;
    public float moveSpeed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //set stopwatch
        stopWatch += Time.deltaTime;

        //move piece forward if timer is less than 2
        if(stopWatch < moveTime)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        //reset stopwatch at 4 seconds
        if (stopWatch > stopTime)
        {
            stopWatch = stopWatch - 4;
        }

    }
}
