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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // StartCoroutine(findBall());
    }

    //IEnumerator findBall()
    //{
    //    while(true)
    //    {
    //        delayedBall = ball.transform.position;
    //        Debug.Log("Update Ball Pos");
    //        yield return new WaitForSeconds(.3f);
    //    }
    //}

    //void AIMove()
    //{
    //    Vector3 dir = transform.position - delayedBall;
    //    Vector3 desiredVel = dir.normalized * 5;
    //    desiredVel.y = 0;
    //    rb.AddForce(rb.velocity - desiredVel);
    //    Vector3 shittyVctor = transform.position + rb.velocity.normalized;
    //    Debug.DrawLine(transform.position, transform.position + (rb.velocity), Color.red);
    //    //shittyVctor = Quaternion.AngleAxis(90, Vector3.up) * shittyVctor;
    //    //transform.LookAt(shittyVctor);
    //}

    private void Update()
    {
        if (ball.transform.position.z < transform.position.z)
        {
            vert = 1;
        }
        else if (ball.transform.position.z > transform.position.z)
        {
            vert = -1;
        }
        else
        {
            vert = 0;
        }

        if (ball.transform.position.x < transform.position.z)
        {
            horz = -1;
        }
        else if (ball.transform.position.x >= transform.position.z)
        {
            horz = 1;
        }
        else
        {
            horz = 0;
        }
    }

    private void FixedUpdate()
    {
        vehicleHover();
       // AIMove();
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



        Vector3 forwardForce = transform.right * acceleration * vert;
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



