using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestingDot : MonoBehaviour {

    
    public Transform Target;

    [Header("Vectors")]
    public Vector3 VehiclePosition;
    public Vector3 TargetPosition;
    public Vector3 desiredRot;

    [Header("Angles")]
    public float AngleBetweenObjects;

    [Header("Dot Product")]
    public float dotProd;

    [Header("Distance")]
    public float Distance;

    [Header("Inverse Transform")]
    public Vector3 InverseTransform;
    public float newSteer;
    public float newFwd;

    // Update is called once per frame
    void Update () {

        InverseTransform = transform.InverseTransformPoint(TargetPosition);
        newSteer = InverseTransform.x / InverseTransform.magnitude;
        newFwd = InverseTransform.z / InverseTransform.magnitude;
        VehiclePosition = gameObject.transform.position;
        TargetPosition = Target.position;
        desiredRot = (TargetPosition - VehiclePosition).normalized;
        dotProd = Vector3.Dot(transform.right, desiredRot);
        Distance = Vector3.Distance(VehiclePosition, TargetPosition);
        AngleBetweenObjects = Vector3.Angle(transform.forward, (TargetPosition - transform.position).normalized);

        Debug.DrawLine(transform.position, Target.transform.position);
        Debug.DrawRay(transform.position, transform.forward * 6,Color.red);
        Debug.DrawRay(transform.position, transform.forward * -6, Color.blue);
    }
}
