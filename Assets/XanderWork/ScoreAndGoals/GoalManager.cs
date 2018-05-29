﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {

    private static GoalManager instance;
    public static GoalManager Instance
    {
        get
        {
            return instance;
        }
    }

    public int scorePerGoal = 1;

    public GoalTrigger sunGoal;
    public GoalTrigger moonGoal;

    public Transform sunPost;
    public Transform moonPost;
    public Transform sunPostEnd;
    public Transform moonPostEnd;

    public float postMoveSpeed;

    private Vector3 sunPostMoveTo;
    private Vector3 moonPostMoveTo;
    private Vector3 sunPostMoveIncrement;
    private Vector3 moonPostMoveIncrement;



    private void Awake()
    {
        instance = this;

        sunGoal.goalTriggered += SunGoalTrigger;
        moonGoal.goalTriggered += MoonGoalTrigger;
        sunPostMoveTo = sunPost.position;
        moonPostMoveTo = moonPost.position;

        sunPostMoveIncrement = (sunPostEnd.position - sunPost.position).normalized *
                                  (Vector3.Distance(sunPost.position, sunPostEnd.position)
                                   / ScoreManager.Instance.scoreToWin);
        moonPostMoveIncrement = (moonPostEnd.position - moonPost.position).normalized *
                                  (Vector3.Distance(moonPost.position, moonPostEnd.position)
                                   / ScoreManager.Instance.scoreToWin);
    }

    private void Update()
    {
        if(Vector3.Distance(sunPost.position, sunPostMoveTo) > postMoveSpeed)
        {
            sunPost.position += (sunPostMoveTo - sunPost.position).normalized * postMoveSpeed * Time.deltaTime;
        }
        if (Vector3.Distance(moonPost.position, moonPostMoveTo) > postMoveSpeed)
        {
            moonPost.position += (moonPostMoveTo - moonPost.position).normalized * postMoveSpeed * Time.deltaTime;
        }
    }

    public void SunGoalTrigger(Collider other)
    {
        if(other.tag == "Ball")
        {
            HoverBall.Instance.ballReset();
            if(ScoreManager.Instance.ScoreSun < ScoreManager.Instance.scoreToWin)
            {
                sunPostMoveTo += sunPostMoveIncrement;
            }
            ScoreManager.Instance.AddScoreSun(scorePerGoal);
        }
    }

    public void MoonGoalTrigger(Collider other)
    {
        if (other.tag == "Ball")
        {
            HoverBall.Instance.ballReset();
            if (ScoreManager.Instance.ScoreMoon < ScoreManager.Instance.scoreToWin)
            {
                moonPostMoveTo += moonPostMoveIncrement;
            }
            ScoreManager.Instance.AddScoreMoon(scorePerGoal);
        }
    }

}
