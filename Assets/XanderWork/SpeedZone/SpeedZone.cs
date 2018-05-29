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
            b.AddForce(transform.forward * force);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody b = other.GetComponent<Rigidbody>();
        if(b != null)
        {
            bodies.Add(b);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody b = other.GetComponent<Rigidbody>();
        if (b != null)
        {
            bodies.Remove(b);
        }
    }

}
