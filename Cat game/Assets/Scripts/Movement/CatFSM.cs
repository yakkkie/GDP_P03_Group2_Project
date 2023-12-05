 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FiniteStateMachine;

public class CatFSM : FSM
{
   
    public Dictionary<CatStateName, CatState> StateDict = new Dictionary<CatStateName, CatState>();

    public CatState currentState;

    public CatState_IDLE CatState_IDLE;
    public CatState_WALK CatState_WALK;
    public CatState_JUMP CatState_JUMP;
    public CatState_EAT CatState_EAT;
    public CatState_DRINK catState_Drink;
    public CatState_DIE catState_DIE;

    public Animator animator;

    public void ChangeState(CatState nextState)
    {
        currentState.ExitState();

        currentState = nextState;
        currentState.EnterState(animator);   
    }

    public void Update()
    {
        currentState.UpdateState();
        switch (currentState)
        {
            case CatState_DIE:
                ClearOtherAnimations();
                // Handle other death-related actions
                break;
                // Other cases and state transitions...
        }
    }
    void ClearOtherAnimations()
    {
        // Clear other animations or set parameters to stop ongoing animations
        animator.SetBool("walkBool", false);
        // Clear any other ongoing animations
    }

    public CatFSM(Animator Animator, NavMeshAgent Agent)
    {
        animator = Animator;

        CatState_WALK = new(Animator,this,Agent);
        CatState_IDLE = new(Animator,this);

        currentState = CatState_IDLE;
    }
}
