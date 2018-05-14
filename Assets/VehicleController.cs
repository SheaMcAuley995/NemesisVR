using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public float acceleration;
    public float turnSpeed;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    private float rotationVelocity;
    private float groundAngelVelocity;

    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        if(Physics.Raycast (transform.position, transform.up * -1, 3f))
        {
            rb.drag = 1;

            Vector3 forwardForce = transform.right * acceleration * Input.GetAxis("Vertical");

            forwardForce = forwardForce * Time.deltaTime * rb.mass;

            rb.AddForce(forwardForce);
        }
        else
        {
            rb.drag = 0;
        }

        Vector3 turnTorque = Vector3.up * turnSpeed * Input.GetAxis("Horizontal");

        turnTorque = turnTorque * Time.deltaTime * rb.mass;
        rb.AddTorque(turnTorque);

        Vector3 newRotation = transform.eulerAngles;
        newRotation.z = Mathf.SmoothDampAngle(newRotation.z, Input.GetAxis("Horizontal") * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        transform.eulerAngles = newRotation;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
