using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine;

public class CatFSM : FSM
{
   
    public Dictionary<CatStateName, CatState> StateDict = new Dictionary<CatStateName, CatState>();

    public CatState currentState = new CatState_IDLE();

    CatState_IDLE CatState_IDLE = new CatState_IDLE();
    public CatState_WALK CatState_WALK = new CatState_WALK();
    CatState_JUMP CatState_JUMP = new CatState_JUMP();
    CatState_EAT CatState_EAT = new CatState_EAT();
    CatState_DRINK catState_Drink = new CatState_DRINK();

    public Animator animator ;

    public void ChangeState(CatState nextState)
    {
        currentState.ExitState();

        currentState = nextState;
        currentState.EnterState(animator);

        
    }

    
}
