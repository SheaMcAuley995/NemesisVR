using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestingDot : MonoBehaviour {

    [Header("Dot Product")]
    public Transform cube02;
    public float dotProd;
    public Vector3 cubePos;
    public Vector3 cube02Pos;
    public Vector3 desiredRot;


    [Header("Distance")]
    public float Distance;

    // Update is called once per frame
    void Update () {

        cubePos = gameObject.transform.position;
        cube02Pos = cube02.position;
        desiredRot = (cube02Pos - cubePos).normalized;
        dotProd = Vector3.Dot(cubePos, desiredRot);
        Distance = Vector3.Distance(cubePos, cube02Pos);

	}
}
