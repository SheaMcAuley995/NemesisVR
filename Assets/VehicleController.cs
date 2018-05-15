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

    private float rotationVelocity;
    private float groundAngelVelocity;

    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
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
        Vector3 forwardForce = transform.right * acceleration * Input.GetAxis("Vertical");
        forwardForce = forwardForce * Time.deltaTime * rb.mass;
        rb.AddForce(forwardForce);

        Vector3 turnTorque = Vector3.up * turnSpeed * Input.GetAxis("Horizontal");

        turnTorque = turnTorque * Time.deltaTime * rb.mass;
        rb.AddTorque(turnTorque);

      //  Vector3 newRotation = transform.eulerAngles;
      //  newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        //transform.eulerAngles = newRotation;
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, transform.position * -hoverDistance);
    //}
}
