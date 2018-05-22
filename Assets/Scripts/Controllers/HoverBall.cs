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

    public float hoverDistance;
    public float hoverStrength;

    public LayerMask groundLayerMask;

    public bool isAttached = false;
    public Transform HoverToPos;
    public float hoverToSpeed;


    public Transform resetPos;

    public delegate void MyHoverBallDelegate();
    public MyHoverBallDelegate myHoverBallDelegate;

    Vector3 _velocity = Vector3.zero;

    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        transform.position = resetPos.position;
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
}
