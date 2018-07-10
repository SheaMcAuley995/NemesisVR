using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXRotation : MonoBehaviour {

    public float rotationSpeed = 3.0f;

    [Range(-125, 125)]
    public float rotateX;
    [Range(-125, 125)]
    public float rotateY;
    [Range(-125, 125)]
    public float rotateZ;

    void Update()
    {
        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime, Space.World);
    }

}