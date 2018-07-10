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

    private Vector3 beaconLocalPos;



    private void Awake()
    {
        if (doesMoveBeacon)
        {
            onReleaseBall = MoveBeaconToBall;
        }
    }

    private void Start()
    {
        currentBallHolder = null;
        holdingBall = false;

        if(doesMoveBeacon)
        {
            beaconLocalPos = beacon.localPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            HoverBall.Instance.HoverToPos = ballHoldPos;
            holdingBall = true;

            if(doesMoveBeacon)
            {
                beacon.parent = goal;
                beacon.localPosition = beaconLocalPos;
            }

            if(currentBallHolder != null && currentBallHolder != this)
            {
                currentBallHolder.OnBallStolen();
            }
            currentBallHolder = this;

            if (onGrabBall != null)
            {
                onGrabBall();
            }
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
        beacon.localPosition = beaconLocalPos;
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

            currentBallHolder = null;

            if (onReleaseBall != null)
            {
                onReleaseBall();
            }
        }
    }

}
