using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{

    public float acceleration;
    public float turnSpeed;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    public float hoverDistance;
    public float hoverStrength;

    private float rotationVelocity;
    private float groundAngelVelocity;


    private float vert;
    private float horz;

    public GameObject ball;
    Vector3 desiredDir;
    Rigidbody rb;
    Vector3 delayedBall;
    public GrabBall grabBall;

    float desiredAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        desiredDir = (ball.transform.position - transform.position).normalized;
        desiredAngle = Vector3.Dot(transform.right, desiredDir);

        if(desiredAngle > 0.01f)
        {
            horz = 1;
        }
        else if (desiredAngle < -0.01f)
        {
            horz = -1;
        }
        else
        {
            horz = 0;
        }

        if (desiredDir.z <= 0.9f || desiredDir.z >= -0.9f)
        {
            vert = 1;
        }
        else if (desiredDir.z > 0.9f)
        {
            vert = 0 - desiredAngle;
        }
        else if (desiredDir.z < -0.9f)
        {
            vert = 0 + desiredAngle;
        }
        else
        {
            vert = 0;
        }


    }

    private void FixedUpdate()
    {
        vehicleHover();
        vehicleMove();
    }


    private void vehicleHover()
    {
        RaycastHit hit;

        Vector3 downwardForce;
        float distancePercentage;

        if (Physics.Raycast(transform.position, -transform.up, out hit, hoverDistance))
        {
            distancePercentage = 1 - (hit.distance / hoverDistance);
            downwardForce = (transform.up * hoverStrength * distancePercentage) * Time.deltaTime;
            rb.AddForce(downwardForce);
        }
    }

    private void vehicleMove()
    {
   //     float distancePercentage = 1 - ((Vector3.Distance(transform.position, ball.transform.position) ))



        Vector3 forwardForce = transform.forward * acceleration * vert;
        forwardForce = forwardForce * Time.deltaTime * rb.mass;
        rb.AddForce(forwardForce);

        Vector3 turnTorque = Vector3.up * turnSpeed * horz;

        turnTorque = turnTorque * Time.deltaTime * rb.mass;
        rb.AddTorque(turnTorque);

        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, horz * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position * -hoverDistance);
    //}
}



