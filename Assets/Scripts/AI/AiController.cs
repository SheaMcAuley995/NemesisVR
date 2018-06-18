using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{


    public Transform[] thrusters;

    public TeamManager.TeamBall myTeam;
//    List

    public float acceleration;
    public float turnSpeed;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;

    public float hoverDistance;
    public float hoverStrength;

    private float rotationVelocity;
  //  private float groundAngelVelocity;

    public float maxSteerAngle = 40f;

    public Vector3 InverseTransform;
    public float newSteer;
    public float newFwd;

    public float vert;
    public float horz;

    public float shootForce;

    public GameObject target;
    Vector3 desiredDir;
    Rigidbody rb; 
    public GrabBall grabBall;
    public GameObject myGoal;
    float desiredAngle;
    float currentDistance;

    public LayerMask obstacle;

    public Transform beetleHead;

    public float sensorLength = 10f;
    public Vector3 frontSensorpos = new Vector3(0,0.2f,0);
    public float FrontsideSensorPos = 0.2f;
    public float frontSensorAngle = 30;

    private float normDrag;
    public float ballDrag;

    void Start()
    {
        
        target = HoverBall.Instance.gameObject;
        rb = GetComponent<Rigidbody>();
        normDrag = rb.drag;
        grabBall.onReleaseBall += OnBallRelease;
    }

    public void OnBallRelease()
    {
        target = HoverBall.Instance.gameObject;
    }

    private void Update()
    {

        if (!GrabBall.currentBallHolder == this.grabBall)
        {
            target = HoverBall.Instance.gameObject;
            rb.drag = normDrag; 
        }
        if (GrabBall.currentBallHolder == this.grabBall)
        {
            rb.drag = ballDrag;
            target = myGoal;
            if(Vector3.Distance(transform.position,target.transform.position) < 80)
            {
                if(desiredAngle <= 0.001f && desiredAngle >= -0.001f)
                {
                    if(Vector3.Angle(transform.forward, (target.transform.position - transform.position).normalized) < 12)
                    {
                        int randnum = Random.Range(0, 50);
                        if (randnum == 8)
                        {
                            
                            grabBall.ShootBall(shootForce);
                        }
                    }
                    
                }

            }
            if (Vector3.Distance(transform.position, target.transform.position) < 10)
            {
                grabBall.ShootBall(shootForce);
            }
        }
        if (Vector3.Angle(transform.forward, (target.transform.position - transform.position).normalized) < 20)
        {
            beetleHead.LookAt(target.transform.position);
        }




    }

    private void FixedUpdate()
    {
        vehicleSteer();
        vehicleHover();
        vehicleSensor();

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

    }


    private void vehicleHover()
    {
        RaycastHit hit;

        foreach(Transform thruster in thrusters)
        {
            Vector3 downwardForce;
            float distancePercentage;

            if (Physics.Raycast(thruster.position, -Vector3.up, out hit, hoverDistance))
            {
                Debug.DrawLine(thruster.position, hit.point);
                rb.drag = normDrag;
                distancePercentage = 1 - (hit.distance / hoverDistance);
                downwardForce = (transform.up * hoverStrength * distancePercentage) * Time.deltaTime;
                rb.AddForceAtPosition(downwardForce, thruster.position);
            }
            //else
            //{
            //    downwardForce = (-transform.up * hoverStrength)/2 * Time.deltaTime;
            //    rb.AddForce(downwardForce);
            //}
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

    private void vehicleSteer()
    {
        InverseTransform = transform.InverseTransformPoint(target.transform.position);
        newSteer = InverseTransform.x / InverseTransform.magnitude + 0.02f;
        newFwd = InverseTransform.z / InverseTransform.magnitude;
        horz = newSteer;
        if(newSteer > 0)
        {
            vert = newFwd - newSteer;
        }
        if(newSteer < 0)
        {
            vert = newFwd + newSteer;
        }
        if (Vector3.Distance(transform.position, target.transform.position) < 70 && Vector3.Distance(transform.position, target.transform.position) > 10)
        {
           horz *= 0 + Vector3.Distance(transform.position, target.transform.position)/10;
        }
        else if(Vector3.Distance(transform.position, target.transform.position) < 10)
        {
            horz *= 5;
        }
    }

    private void vehicleSensor()
    {
        RaycastHit hit;
        Vector3 sensorStartingpos = transform.position + frontSensorpos;
        sensorStartingpos += transform.forward * frontSensorpos.z;
        sensorStartingpos += transform.up * frontSensorpos.y;
        float avoidMultiplier = 0;
        bool isAvoiding = false;
        //front center
        if (avoidMultiplier == 0)
        {
            if (Physics.Raycast(sensorStartingpos, transform.forward, out hit, sensorLength + 3, obstacle))
            {
                if (!hit.collider.CompareTag("Ground"))
                {
                    Debug.DrawLine(sensorStartingpos, hit.point);
                    isAvoiding = true;
                    if(hit.normal.x < 0)
                    {
                        Debug.Log((Vector3.Distance(transform.position, hit.point) / sensorLength));
                        vert += 1 - (Vector3.Distance(transform.position, hit.point)/sensorLength);
                        //vert += -2f;
                        avoidMultiplier += 1;
                    }
                    else
                    {
                        Debug.Log((Vector3.Distance(transform.position, hit.point) / sensorLength));
                        vert += 1 - (Vector3.Distance(transform.position, hit.point) / sensorLength);
                        avoidMultiplier += -1;
                    }
                  
                    //if(Vector3.Distance(transform.position,))
                }
                Debug.DrawLine(sensorStartingpos, hit.point);
            }
        }


        //front right
        sensorStartingpos += transform.right * FrontsideSensorPos;
        if (Physics.Raycast(sensorStartingpos, transform.forward, out hit, sensorLength, obstacle))
        {
            if (!hit.collider.CompareTag("Ground"))
            {
                
                isAvoiding = true;
                avoidMultiplier -= 2f;
            }
            Debug.DrawLine(sensorStartingpos, hit.point);
        }


        //front right angle
        if (Physics.Raycast(sensorStartingpos, Quaternion.AngleAxis(30, transform.up) * transform.forward, out hit, sensorLength, obstacle))
        {
            if (!hit.collider.CompareTag("Ground"))
            {
                Debug.DrawLine(sensorStartingpos, hit.point);
                isAvoiding = true;
                avoidMultiplier -= 1.5f;
            }
            Debug.DrawLine(sensorStartingpos, hit.point);
        }

        if (Physics.Raycast(sensorStartingpos, Quaternion.AngleAxis(45, transform.up) * transform.forward, out hit, sensorLength, obstacle))
        {
            vert += 1f;
            Debug.DrawLine(sensorStartingpos, hit.point);
        }

        //front left
        sensorStartingpos -= transform.right * FrontsideSensorPos * 2;
        if (Physics.Raycast(sensorStartingpos, transform.forward, out hit, sensorLength, obstacle))
        {
            if (!hit.collider.CompareTag("Ground"))
            {
                Debug.DrawLine(sensorStartingpos, hit.point);
                isAvoiding = true;
                avoidMultiplier += 2f;
            }
            Debug.DrawLine(sensorStartingpos, hit.point);
        }


        //front left angle
        if (Physics.Raycast(sensorStartingpos, Quaternion.AngleAxis(-30, transform.up) * transform.forward, out hit, sensorLength, obstacle))
        {
            if (!hit.collider.CompareTag("Ground"))
            {
                Debug.DrawLine(sensorStartingpos, hit.point);
                isAvoiding = true;
                avoidMultiplier += 1.5f;
            }
            Debug.DrawLine(sensorStartingpos, hit.point);
        }

        if (Physics.Raycast(sensorStartingpos, Quaternion.AngleAxis(-45, transform.up) * transform.forward, out hit, sensorLength, obstacle))
        {
            vert = 1f;
            Debug.DrawLine(sensorStartingpos, hit.point);
        }
            if (isAvoiding)
        {
            horz += avoidMultiplier;
            //vert += avoidMultiplier;
        }
        
            vehicleMove();
    }
}

//desiredDir = (target.transform.position - transform.position).normalized;
//desiredAngle = Vector3.Dot(transform.right, desiredDir);
//currentDistance = Vector3.Distance(transform.position, target.transform.position);
//
//if (desiredAngle > 0.01f)
//{
//    horz = 1 ;
//}
//else if (desiredAngle < -0.01f)
//{
//    horz = -1;
//}
//else
//{
//    horz = 0;
//}
//if(currentDistance > 50)
//{
//    horz += 1 - (currentDistance / 100);
//}
//else if(Vector3.Distance(transform.position,target.transform.position) < 10)
//{
//    horz += 1 - (currentDistance / 100);
//}
//
//
//vert = 1 - (currentDistance/100);
//
//if (Vector3.Angle(transform.position,target.transform.position) < 10f)
//{
//    vert += 1;
//}
//if (currentDistance > 60)
//{
//    vert = 0.9f;
//}
//
//if (!grabBall.holdingBall && currentDistance < 20)
//{
//    if(desiredAngle > 0.03f || desiredAngle < 0.03f)
//    {
//        vert = 0.1f;
//    }
//    
//}
//
//
//
//if (!grabBall.holdingBall)
//{
//    target = GameObject.FindGameObjectWithTag("Ball");
//}
//else if (grabBall.holdingBall)
//{
//    target = GameObject.FindGameObjectWithTag("Goal");
//    if(Vector3.Distance(transform.position,target.transform.position) < 80)
//    {
//        if(desiredAngle <= 0.001f && desiredAngle >= -0.001f)
//        {
//            grabBall.ShootBall(shootForce);
//        }
//    }
//}
//