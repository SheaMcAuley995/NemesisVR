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

    //private void Awake()
    //{
    //    instance = this;
    //}

#endregion

    public float hoverDistance;
    public float hoverStrength;

    public LayerMask groundLayerMask;

    public Transform resetPos;

    public delegate void MyHoverBallDelegate();
    public MyHoverBallDelegate myHoverBallDelegate;


    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
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
}
