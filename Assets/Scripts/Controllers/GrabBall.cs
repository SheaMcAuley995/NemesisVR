using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBall : MonoBehaviour {

    public static GrabBall currentBallHolder { private set ; get; } 
    
    public Transform ballHoldPos;
    TeamManager tm;
    public bool holdingBall { get; private set; }

    public delegate void OnGrabBall();
    public OnGrabBall onGrabBall;
    public OnGrabBall onReleaseBall;
    


    private void Start()
    {
        currentBallHolder = null;
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

            if(currentBallHolder != null)
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

            if(onReleaseBall != null)
            {
                onReleaseBall();
            }

            currentBallHolder = null;

            Debug.Log(TeamManager.ballStatus);
        }
    }

}
