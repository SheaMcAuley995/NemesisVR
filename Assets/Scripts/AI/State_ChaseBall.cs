using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManager;

public class State_ChaseBall : State<EnemyAI>
{
#region singleton
    private static State_ChaseBall _instance;

    private void startState()
    {
        if(_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static State_ChaseBall Instance
    {
        get
        {
            if(_instance != null)
            {
                new State_ChaseBall();
            }

            return _instance;
        }
    }
    #endregion


    public Vector3 ballPos;
    private GameObject ball;

    public override void EnterState(EnemyAI _owner)
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public override void ExitState(EnemyAI _owner)
    {
        
    }

    public override void UpdateState(EnemyAI _owner)
    {
        /*  A = Distance between AI and Ball
         *  B = Speed of ball
         *  C = Direction AI needs to go to catch ball
         */ 
         
        
        
    }
}
