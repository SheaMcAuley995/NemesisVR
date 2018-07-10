using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBall : MonoBehaviour {

#region singleton

    private static HoverBall instance;
    public static HoverBall Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }


    #endregion

    public static bool isEquipped;
    
    public float hoverDistance;
    public float hoverStrength;

    public LayerMask groundLayerMask;

    public bool isAttached = false;
    public Transform HoverToPos;
    public float hoverToSpeed;


    public Transform resetPos;
    public float spawnRadiusMin;
    public float spawnRadiusMax;

    public delegate void MyHoverBallDelegate();
    public MyHoverBallDelegate myHoverBallDelegate;

    Vector3 _velocity = Vector3.zero;

    public float passiveMoveForce;

    public Rigidbody rb;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballReset();
    }

    void Update () {
        if (HoverToPos != null)
        {
            hoverTo(HoverToPos.transform);
        }
        else
        {
            ballHover();
        }
        if(transform.position.y < -18)
        {
            transform.position = resetPos.position;
        }
    }

    private void FixedUpdate()
    {
        Vector3 dir = transform.forward;
        dir.y = 0;
        dir.Normalize();
        rb.AddForce(dir * passiveMoveForce);
    }

    void ballHover()
    {
        RaycastHit hit;

        Vector3 downwardForce;
        float distancePercentage;

        if (Physics.Raycast(transform.position, -transform.up, out hit, hoverDistance, groundLayerMask))
        {
            distancePercentage = 1 - (hit.distance / hoverDistance);
            downwardForce = (transform.up * hoverStrength * distancePercentage) * Time.deltaTime;
            rb.AddForce(downwardForce);
        }
    }

    public void ballReset()
    {
        Vector2 circle = Random.insideUnitCircle.normalized * Random.Range(spawnRadiusMin, spawnRadiusMax);
        Vector3 spawnOffset = new Vector3(circle.x, 0, circle.y);
        transform.position = resetPos.position + spawnOffset;
        rb.velocity = Vector3.zero;
    }
    public void hoverTo(Transform hoverToPos)
    {
        transform.position = HoverToPos.position;
        transform.rotation = HoverToPos.rotation;

        /*I might need these
            
        //Vector3.Lerp(transform.position, HoverToPos.transform.position, 1f);
           
        //(transform.position, HoverToPos.transform.position, ref _velocity, hoverToSpeed * Time.deltaTime);
           
         * */
    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.Rotate(Vector3.up * 180);
    }
}
