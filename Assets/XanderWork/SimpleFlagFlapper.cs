using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlagFlapper : MonoBehaviour
{
    
    public float maxRot;
    public float flapSpeed;

    private float rotTo = 0;
    private int rotDir = 1;
    private float distanceRotated = 0;
    private float lastDistFrontCenter = 0;



    private void Start()
    {
        rotTo = transform.eulerAngles.y;
    }

    private void Update()
    {
        if(distanceRotated >= rotTo)
        {
            rotTo = Random.Range(0, maxRot) + distanceRotated - lastDistFrontCenter;
            lastDistFrontCenter = distanceRotated - lastDistFrontCenter;
            distanceRotated = 0;

            if (rotDir == 1)
            {
                rotDir = -1;
            }
            else
            {
                rotDir = 1;
            }
        }
        
        transform.eulerAngles += Vector3.up * flapSpeed * Time.deltaTime * rotDir;
        distanceRotated += flapSpeed * Time.deltaTime;
    }

}
