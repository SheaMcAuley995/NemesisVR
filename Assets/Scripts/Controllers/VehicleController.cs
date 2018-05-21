using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public float acceleration;
    public float maxSpeed;
    public float minSpeed;
    public float turnSpeed;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    public float hoverDistance;
    public float hoverStrength;

    private float rotationVelocity;
    private float groundAngelVelocity;
    



    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    public void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 dir = (transform.forward - transform.position).normalized;
            //HoverBall.Instance.HoverToPos = null;

            HoverBall.Instance.rb.AddForce(dir);
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
        Vector3 forwardForce = transform.forward * acceleration * Time.deltaTime;
        rb.AddForce(forwardForce);
        
        Vector3 localVel = transform.InverseTransformVector(rb.velocity);
        Debug.Log(localVel);
        localVel.y = 0;
        if(localVel.z > 0 && localVel.magnitude > maxSpeed)
        {
            localVel = transform.TransformVector(localVel.normalized * maxSpeed);
            rb.velocity = new Vector3(localVel.x, rb.velocity.y, localVel.z);
        }
        else if (localVel.z < 0 && localVel.magnitude > minSpeed)
        {
            localVel = transform.TransformVector(localVel.normalized * minSpeed);
            rb.velocity = new Vector3(localVel.x, rb.velocity.y, localVel.z);
        }

        Vector3 turnTorque = Vector3.up * turnSpeed;

        turnTorque = turnTorque * Time.deltaTime * rb.mass;
        rb.AddTorque(turnTorque);

        //Vector3 newRotation = transform.eulerAngles;
        //newRotation.x = Mathf.SmoothDampAngle(newRotation.x, rotationMovement * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        //transform.eulerAngles = newRotation;
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position * -hoverDistance);
    //}
}
