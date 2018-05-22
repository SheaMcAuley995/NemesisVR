using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public float acceleration;
    public float turnSpeed;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    public float hoverDistance;
    public float hoverStrength;

    public Rigidbody rb;

    private float rotationVelocity;
    private float groundAngelVelocity;
    


    

    public void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 dir = (transform.forward - transform.position).normalized;

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
                downwardForce = (transform.up * hoverStrength * distancePercentage) * Time.fixedDeltaTime;
                rb.AddForce(downwardForce);
            }
    }

    private void vehicleMove()
    {
        Vector3 forwardForce = transform.forward * acceleration * Time.fixedDeltaTime;
        rb.AddForce(forwardForce);

        Vector3 turnTorque = Vector3.up * turnSpeed;

        turnTorque = turnTorque * Time.deltaTime * rb.mass;
        rb.AddTorque(turnTorque);

        //Vector3 newRotation = transform.eulerAngles;
        //newRotation.x = Mathf.SmoothDampAngle(newRotation.x, rotationMovement * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        //transform.eulerAngles = newRotation;
    }
    
}
