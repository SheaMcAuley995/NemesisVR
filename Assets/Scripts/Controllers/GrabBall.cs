using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour {

    public Transform ballHoldPos;

    private bool holdingBall = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            HoverBall.Instance.HoverToPos = ballHoldPos;
            holdingBall = true;
        }
    }

    public void ShootBall(float force)
    {
        if(holdingBall)
        {
            holdingBall = false;
            HoverBall.Instance.HoverToPos = null;
            HoverBall.Instance.rb.AddForce(HoverBall.Instance.transform.forward * force);
        }
    }

}
