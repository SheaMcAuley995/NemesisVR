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

    public static  State_ChaseBall Instance
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

    public override void EnterState(EnemyAI _owner)
    {

        throw new System.NotImplementedException();
    }

    public override void ExitState(EnemyAI _owner)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyAI _owner)
    {
        throw new System.NotImplementedException();
    }
}
