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
    public float pitchCorrectionForce;
    public float rollCorrectionForce;

    public float dislodgeBallSpeed;

    public LayerMask[] masks;

    public Rigidbody rb;
    public Transform[] thrusters;

    [Header("Head rotation")]
    public Transform beetleHead;
    public float headPitchMult;
    public float headYawMult;
    public float headRollMult;
    public float headPitchMin;
    public float headPitchMax;

    public bool handleHeadRotation = true;

    public Vector3 headRotDefault { get; private set; }

    private float rotationVelocity;
    private float groundAngelVelocity;

    private LayerMask mask;
    private string enemyTag;






    private void Start()
    {
        headRotDefault = beetleHead.localEulerAngles;

        mask = new LayerMask();
        foreach(LayerMask m in masks)
        {
            mask.value = mask.value | m.value;
        }

        if(SceneBridge.Instance.playerTeam == TeamManager.TeamBall.Moon)
        {
            tag = "TeamMoon";
            enemyTag = "TeamSun";
        }
        else
        {
            tag = "TeamSun";
            enemyTag = "TeamMoon";
        }
    }

    private void FixedUpdate()
    {
        vehicleHover();
        vehicleMove();

        //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);
    }

    private void LateUpdate()
    {
        transform.eulerAngles -= Vector3.right * transform.eulerAngles.x;
        transform.eulerAngles -= Vector3.forward * transform.eulerAngles.z;
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

        //RaycastHit hit;
        //
        //foreach (Transform thruster in thrusters)
        //{
        //    Vector3 downwardForce;
        //    float distancePercentage;
        //
        //    if (Physics.Raycast(thruster.position, -Vector3.up, out hit, hoverDistance, mask))
        //    {
        //        Debug.DrawLine(thruster.position, hit.point);
        //        distancePercentage = 1 - (hit.distance / hoverDistance);
        //        downwardForce = (transform.up * hoverStrength * distancePercentage) * Time.deltaTime;
        //        rb.AddForceAtPosition(downwardForce, thruster.position);
        //    }
        //}
    }

    private void vehicleMove()
    {
        Vector3 forwardForce = transform.forward * acceleration * Time.fixedDeltaTime;
        rb.AddForce(forwardForce);

        Vector3 turnTorque = Vector3.up * turnSpeed * Time.fixedDeltaTime;
        rb.AddTorque(turnTorque);

        if(handleHeadRotation)
        {
            Vector3 localVel = transform.InverseTransformVector(rb.velocity);
            Vector3 localTurn = rb.angularVelocity;
            Vector3 newEuler = new Vector3(headRotDefault.x + localVel.z * headPitchMult,
                                           headRotDefault.y + localTurn.y * headYawMult,
                                           headRotDefault.z + -localTurn.y * headRollMult);
            
            newEuler.x = Mathf.Clamp(newEuler.x, headPitchMin, headPitchMax);
            beetleHead.localEulerAngles = newEuler;
        }
        

        //Vector3 newRotation = transform.eulerAngles;
        //newRotation.x = Mathf.SmoothDampAngle(newRotation.x, rotationMovement * -turnRotationAngle, ref rotationVelocity, turnRotationSeekSpeed);
        //transform.eulerAngles = newRotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == enemyTag && collision.relativeVelocity.magnitude >= dislodgeBallSpeed)
        {
            collision.transform.GetComponentInChildren<GrabBall>().ShootBall(1000, Vector3.up);
        }
    }

}
