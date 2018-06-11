using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour {

    public Transform ballHoldPos;
    TeamManager tm;
    public bool holdingBall { get; private set; }

    public delegate void OnGrabBall();
    public OnGrabBall onGrabBall;
    


    private void Start()
    {
        holdingBall = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            HoverBall.Instance.HoverToPos = ballHoldPos;
            holdingBall = true;
            if(onGrabBall != null)
            {
                onGrabBall();
            }
        }
    }

    public void ShootBall(float force)
    {
        if (holdingBall)
        {
            if (transform.parent != null && transform.parent.tag == "TeamMoon")
            {
                TeamManager.ballStatus = TeamManager.TeamBall.Moon;
            }
            if (transform.parent != null && transform.parent.tag == "TeamSun")
            {
                TeamManager.ballStatus = TeamManager.TeamBall.Sun;
            }

            holdingBall = false;
            HoverBall.Instance.HoverToPos = null;
            HoverBall.Instance.rb.AddForce(HoverBall.Instance.transform.forward * force);

            Debug.Log(TeamManager.ballStatus);
        }
    }

}
