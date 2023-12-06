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
    public CatState_DRINK CatState_DRINK;

    public Animator animator;
    public Cat cat;
    public NavMeshAgent agent;
    public void ChangeState(CatState nextState)
    {
        currentState.ExitState();

        currentState = nextState;
        currentState.EnterState();   
    }

    public void Update()
    {
        currentState.UpdateState();
    }

    public void FixedUpdate()
    {
        currentState.FixedUpdateState();
    }

    public CatFSM(Animator Animator, NavMeshAgent Agent,Cat Cat)
    {
        animator = Animator;
        agent = Agent;
        cat = Cat;
        CatState_WALK = new(this);
        CatState_IDLE = new(this);
        CatState_EAT = new(this);
        CatState_DRINK = new(this);

        currentState = CatState_IDLE;
    }
}
