using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManager;


public class EnemyAI : MonoBehaviour
{
    public StateMachine<EnemyAI> stateMachine { get; set; }

    public void Start()
    {
        stateMachine = new StateMachine<EnemyAI>(this);
        stateMachine.ChangeState(State_ChaseBall.Instance);
    }

    private void Update()
    {

        stateMachine.Update();
    }
}
