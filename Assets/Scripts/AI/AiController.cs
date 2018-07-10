using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[SelectionBase]
public class AiController : MonoBehaviour
{
    private NavMeshPath path;
    //Stack<Transform> navPoints;

    public Transform[] thrusters;
    public float hoverDistance;
    public float hoverStrength;

    public TeamManager.TeamBall myTeam;
//    List

    public float acceleration;
    public float turnSpeed;

    public float turnRotationAngle;
    public float turnRotationSeekSpeed;



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

    private bool obsticleDetected = false;


    void Start()
    {
        path = new NavMeshPath();
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
        
        if (!GrabBall.currentBallHolder == this.grabBall && !obsticleDetected)
        {
            
            target = HoverBall.Instance.gameObject;
            rb.drag = normDrag; 
        }
        if (GrabBall.currentBallHolder == this.grabBall && !obsticleDetected)
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

        NavMeshHit navMeshHitA;
        NavMeshHit navMeshHitB;
        NavMesh.SamplePosition(transform.position, out navMeshHitA, float.PositiveInfinity, NavMesh.AllAreas);
        NavMesh.SamplePosition(target.transform.position, out navMeshHitB, float.PositiveInfinity, NavMesh.AllAreas);
        bool result = NavMesh.CalculatePath(navMeshHitA.position, navMeshHitB.position, NavMesh.AllAreas, path);

        //Debug.Assert(result, "pls");
        for (int i = 0; i < path.corners.Length -1; i++)
        {
            Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
        }

    }

    private void FixedUpdate()
    {
        vehicleSteer();
        vehicleHover();
        vehicleSensor();

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0f);

    }


    public void vehicleHover()
    {
        RaycastHit hit;

        foreach (Transform thruster in thrusters)
        {
            Vector3 downwardForce;
            float distancePercentage;

            if (Physics.Raycast(thruster.position, -Vector3.up, out hit, hoverDistance))
            {
                Debug.DrawLine(thruster.position, hit.point);
                distancePercentage = 1 - (hit.distance / hoverDistance);
                downwardForce = (transform.up * hoverStrength * distancePercentage) * Time.deltaTime;
                rb.AddForceAtPosition(downwardForce, thruster.position);
            }
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

        if (path.corners.Length > 0)
        {
            Vector3 dumb = path.corners[1];
            Vector3 assistInverse = transform.InverseTransformPoint(dumb);
            float assistFwd = assistInverse.z / assistInverse.magnitude + 0.02f;
            float assistSteer = assistInverse.x / assistInverse.magnitude;

            // newFwd /= 2;
            // newSteer /= 2;
            newFwd = assistFwd;
            newSteer = assistSteer;
        }

        horz = newSteer;
        if (newSteer > 0)
        {
            vert = newFwd - newSteer;
        }
        if (newSteer < 0)
        {
            vert = newFwd + newSteer;
        }
        if (Vector3.Distance(transform.position, target.transform.position) < 70 && Vector3.Distance(transform.position, target.transform.position) > 10)
        {
            horz *= 0 + Vector3.Distance(transform.position, target.transform.position) / 10;
        }
        else if (Vector3.Distance(transform.position, target.transform.position) < 10)
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
        //back center
        if (avoidMultiplier == 0)
        {
            if (Physics.Raycast(sensorStartingpos, -transform.forward, out hit, sensorLength, obstacle))
            {
                if (!hit.collider.CompareTag("Ground"))
                {
                    Debug.DrawLine(sensorStartingpos, hit.point);
                    isAvoiding = true;

                       // Debug.Log(1 - (Vector3.Distance(transform.position, hit.point) / sensorLength));
                        //vert += (Vector3.Distance(transform.position, hit.point) / sensorLength);
                        vert *= -1;
                        avoidMultiplier += 1;
                }
                Debug.DrawLine(sensorStartingpos, hit.point,Color.yellow);
            }
        }
        //front center
        if (avoidMultiplier == 0)
        {
            if (Physics.Raycast(sensorStartingpos, transform.forward, out hit, sensorLength, obstacle))
            {
                if (!hit.collider.CompareTag("Ground"))
                {
                    Debug.DrawLine(sensorStartingpos, hit.point);
                    isAvoiding = true;

                       // Debug.Log(1 - (Vector3.Distance(transform.position, hit.point) / sensorLength));
                        vert -= 1 - (Vector3.Distance(transform.position, hit.point)/sensorLength);
                        avoidMultiplier += 1;
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

        //if (Physics.Raycast(sensorStartingpos, Quaternion.AngleAxis(45, transform.up) * transform.forward, out hit, sensorLength-1, obstacle))
        //{
            //avoidMultiplier = Mathf.Lerp(avoidMultiplier, 1, 0.1f * Time.deltaTime);
            //vert += Vector3.Distance(transform.position,hit.point) / 3;
            //horz -= horz;
            //Debug.DrawLine(sensorStartingpos, hit.point, Color.green);
        //}

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

        //if (Physics.Raycast(sensorStartingpos, Quaternion.AngleAxis(-45, transform.up) * transform.forward, out hit, sensorLength-1, obstacle))
        //{
        //    avoidMultiplier = Mathf.Lerp(avoidMultiplier, 1, 0.1f * Time.deltaTime);
        //    vert += Vector3.Distance(transform.position, hit.point) / 3;
        //    horz -= horz;
        //    Debug.DrawLine(sensorStartingpos, hit.point,Color.green);
        //}
        if (isAvoiding)
        {
            horz += avoidMultiplier;
            //vert += avoidMultiplier;
        }
        
        if(isAvoiding)
        {
            obsticleDetected = true;
        }
        else
        {
            obsticleDetected = false;
        }
            vehicleMove();



        if (horz > 1)
        {
            horz = 1;
        }

        if (vert > 1)
        {
            vert = 1;
        }

        if (horz < -1)
        {
            horz = -1;
        }
        if(vert < -1)
        {
            vert = -1;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) { return; }
        Gizmos.color = Color.red;

       // Debug.Log("NODES" + path.corners.Length);
        foreach (var node in path.corners)
        {
            Gizmos.DrawSphere(node, 1);
        }
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