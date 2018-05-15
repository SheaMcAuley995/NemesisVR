using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {

    public int scorePerGoal = 1;

    public GoalTrigger sunGoal;
    public GoalTrigger moonGoal;



    private void Awake()
    {
        sunGoal.goalTriggered += SunGoalTrigger;
        moonGoal.goalTriggered += MoonGoalTrigger;
    }

    public void SunGoalTrigger(Collider other)
    {
        if(other.tag == "Ball")
        {
            ScoreManager.Instance.AddScoreSun(scorePerGoal);
        }
    }

    public void MoonGoalTrigger(Collider other)
    {
        if (other.tag == "Ball")
        {
            ScoreManager.Instance.AddScoreMoon(scorePerGoal);
        }
    }

}
