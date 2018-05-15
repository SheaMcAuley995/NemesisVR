using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{



    private void Start()
    {
        Debug.Log(transform.eulerAngles);
    }

    private void Update()
    {
        //Rotate(10.0f * Time.deltaTime, 10.0f * Time.deltaTime);
        //Rotate(0, 10.0f * Time.deltaTime);
        //Rotate(10.0f * Time.deltaTime, 0);
    }

    public void Rotate(float roll, float pitch)
    {
        transform.eulerAngles += Vector3.forward * roll;
        transform.eulerAngles += Vector3.right * pitch;
    }

}
