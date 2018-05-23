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

    public float shootForce;

    public GameObject target;
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
        desiredDir = (target.transform.position - transform.position).normalized;
        desiredAngle = Vector3.Dot(transform.right, desiredDir);

        if(desiredAngle > 0.01f)
        {
            horz = 1 ;
        }
        else if (desiredAngle < -0.01f)
        {
            horz = -1;
        }
        else
        {
            horz = 0;
        }
        if(Vector3.Distance(transform.position, target.transform.position) > 50)
        {
            horz += 1 - (Vector3.Distance(transform.position, target.transform.position) / 100);
        }
        else if(Vector3.Distance(transform.position,target.transform.position) < 10)
        {
            horz += 1 - (Vector3.Distance(transform.position, target.transform.position) / 100);
        }


        vert = 1 - (Vector3.Distance(transform.position, target.transform.position)/100);

        if (Vector3.Angle(transform.position,target.transform.position) < 10f)
        {
            vert += 1;
        }
        if (Vector3.Distance(transform.position, target.transform.position ) > 95)
        {
            vert = 0.8f;
        }


        if(!grabBall.holdingBall)
        {
            target = GameObject.FindGameObjectWithTag("Ball");
        }
        else if (grabBall.holdingBall)
        {
            target = GameObject.FindGameObjectWithTag("Goal");
            if(Vector3.Distance(transform.position,target.transform.position) < 20)
            {
                grabBall.ShootBall(shootForce);
            }
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



