using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour {

    public static GrabBall currentBallHolder { private set ; get; } 
    
    public Transform ballHoldPos;
    TeamManager tm;
    public bool holdingBall { get; private set; }

    public bool doesMoveBeacon;
    public Transform goal;
    public Transform beacon;

    public delegate void OnGrabBall();
    public OnGrabBall onGrabBall;
    public OnGrabBall onReleaseBall;



    private void Start()
    {
        currentBallHolder = null;
        holdingBall = false;

        if(doesMoveBeacon)
        {
            onReleaseBall += MoveBeaconToBall;
        }
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

            if(doesMoveBeacon)
            {
                beacon.parent = goal;
                beacon.position = goal.position;
            }

            if(currentBallHolder != null && currentBallHolder != this)
            {
                currentBallHolder.OnBallStolen();
            }
            currentBallHolder = this;
        }
    }

    public void OnBallStolen()
    {
        holdingBall = false;
        if (onReleaseBall != null)
        {
            onReleaseBall();
        }
    }

    private void MoveBeaconToBall()
    {
        beacon.parent = HoverBall.Instance.transform;
        beacon.position = HoverBall.Instance.transform.position;
    }

    public void ShootBall(float force)
    {
        ShootBall(force, HoverBall.Instance.transform.forward);
    }

    public void ShootBall(float force, Vector3 dir)
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
            HoverBall.Instance.rb.AddForce(dir * force);

            if (onReleaseBall != null)
            {
                onReleaseBall();
            }

            currentBallHolder = null;
        }
    }

}
