using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine;

public class CatFSM : FSM
{
   
    public Dictionary<CatStateName, CatState> StateDict = new Dictionary<CatStateName, CatState>();

    public CatState currentState;

    public void ChangeState(CatState nextState)
    {
        currentState.ExitState();

        currentState = nextState;
        currentState.EnterState();
    }
}
