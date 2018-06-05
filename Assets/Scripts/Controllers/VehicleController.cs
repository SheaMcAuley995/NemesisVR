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

    [Header("Head rotation")]
    public Transform beetleHead;
    public float headPitchMult;
    public float headYawMult;
    public float headRollMult;

    private Vector3 headRotDefault;

    private float rotationVelocity;
    private float groundAngelVelocity;






    private void Start()
    {
        headRotDefault = beetleHead.localEulerAngles;

        if(SceneBridge.Instance.playerTeam == TeamManager.TeamBall.Moon)
        {
            tag = "TeamMoon";
        }
        else
        {
            tag = "TeamSun";
        }
    }

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

        Vector3 turnTorque = Vector3.up * turnSpeed * Time.fixedDeltaTime;
        rb.AddTorque(turnTorque);

        Vector3 localVel = transform.InverseTransformVector(rb.velocity);
        Vector3 localTurn = rb.angularVelocity;
        beetleHead.localEulerAngles = new Vector3(headRotDefault.x + localVel.z * headPitchMult,
                                                  headRotDefault.y + localTurn.y * headYawMult,
                                                  headRotDefault.z + -localTurn.y * headRollMult);

        //Vector3 newRotation = transform.eulerAngles;
        //newRotation.x = Mathf.SmoothDampAngle(newRotation.x, rotationMovement * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        //transform.eulerAngles = newRotation;
    }
    
}
