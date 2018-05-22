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


    public float vert;
    public float horz;

    public GameObject ball;
    Rigidbody rb;
    Vector3 delayedBall;


    float desiredAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        desiredAngle = Vector3.Angle(transform.position, ball.transform.position);
        float currentAngle = transform.eulerAngles.y;
        horz = 1 - (desiredAngle / currentAngle);

       //Vector3 targetDir = (ball.transform.position - transform.position);
       //float step = turnSpeed * Time.deltaTime;
       //Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
       //Debug.DrawRay(transform.position, newDir, Color.red);
       //transform.rotation = Quaternion.LookRotation(newDir);
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

        //Vector3 newRotation = transform.eulerAngles;
        //newRotation.z = Mathf.SmoothDampAngle(newRotation.z, horz * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        //transform.eulerAngles = newRotation;
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position * -hoverDistance);
    //}
}



