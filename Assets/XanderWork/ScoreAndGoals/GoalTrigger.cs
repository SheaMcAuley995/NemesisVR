using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {

    public delegate void GoalTriggered(Collider other);
    public GoalTriggered goalTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if(goalTriggered != null)
        {
            goalTriggered(other);
        }
    }

}
