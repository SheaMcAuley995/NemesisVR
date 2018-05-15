using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBall : MonoBehaviour {

    public float hoverDistance;
    public float hoverStrength;


    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
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
}
