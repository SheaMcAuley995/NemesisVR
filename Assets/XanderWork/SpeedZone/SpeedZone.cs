using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedZone : MonoBehaviour
{

    public float force;

    private List<Rigidbody> bodies = new List<Rigidbody>();



    private void FixedUpdate()
    {
        foreach(Rigidbody b in bodies)
        {
            if(b != null)
            {
                b.AddForce(b.transform.forward * force);
            }
            else
            {
                bodies.Remove(b);
            }
            //float angle = Vector3.Angle(b.velocity.normalized, transform.forward);
            //if(angle < 90)
            //{
            //    b.AddForce(transform.forward * force);
            //}
            //else
            //{
            //    b.AddForce(-transform.forward * force);
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody b = other.GetComponent<Rigidbody>();
        if(b != null)
        {
            //b.drag *= 0.25f;
            bodies.Add(b);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody b = other.GetComponent<Rigidbody>();
        if (b != null)
        {
            //b.drag *= 4.0f;
            bodies.Remove(b);
        }
    }

}
