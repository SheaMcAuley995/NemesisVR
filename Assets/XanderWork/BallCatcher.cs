using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCatcher : MonoBehaviour {

    public float resetHeight;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.transform.position += Vector3.up * resetHeight;
        }
    }

}
