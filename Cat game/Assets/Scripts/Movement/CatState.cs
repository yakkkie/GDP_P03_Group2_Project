using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FiniteStateMachine;

public class CatState : State
{
    public Animator animator;
    public CatFSM fsm;

    #region State Method
    public override void EnterState(Animator animator)
    {
        base.EnterState(animator);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
    #endregion

    public CatState(Animator Animator,CatFSM fsm)
    {
        animator = Animator;
        this.fsm = fsm;
    }
}

public class CatState_IDLE : CatState
{
    protected CatStateName stateName = CatStateName.IDLE;

    #region State Method
    public override void EnterState(Animator animator)
    {
        animator.SetBool("walkBool", false);
        Debug.Log("IDLE_ENTER");

        base.EnterState(animator);
    }

    public override void ExitState()
    {
        Debug.Log("IDLE_EXIT");
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
    #endregion

    public CatState_IDLE(Animator Animator, CatFSM fsm) : base(Animator,fsm)
    {

    }
}

public class CatState_WALK : CatState
{
    protected CatStateName stateName = CatStateName.WALK;
    public NavMeshAgent agent;

    #region State Method
    public override void EnterState(Animator animator)
    {
        animator.SetBool("walkBool", true);
     
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if (agent.velocity.magnitude <= 0)
            fsm.ChangeState(fsm.CatState_IDLE);
            
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public void WalkToDestination(Vector3 destination)
    {

    }

    public CatState_WALK(Animator Animator, CatFSM fsm, NavMeshAgent Agent) : base(Animator, fsm)
    {
        agent = Agent;
    }
    #endregion
}

public class CatState_JUMP : CatState
{
    protected CatStateName stateName = CatStateName.JUMP;

    #region State Method
    public override void EnterState(Animator animator)
    {
        base.EnterState(animator);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
    #endregion

    public CatState_JUMP (Animator Animator, CatFSM fsm) : base(Animator, fsm)
    {

    }
}

public class CatState_EAT : CatState
{
    protected CatStateName stateName = CatStateName.EAT;

    #region State Method
    public override void EnterState(Animator animator)
    {
        base.EnterState(animator);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
    #endregion

    public CatState_EAT(Animator Animator, CatFSM fsm) : base(Animator, fsm)
    {

    }
}

public class CatState_DRINK : CatState
{
    protected CatStateName stateName = CatStateName.DRINK;

    #region State Method
    public override void EnterState(Animator animator)
    {
        base.EnterState(animator);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }
    #endregion

    public CatState_DRINK(Animator Animator, CatFSM fsm) : base(Animator, fsm)
    {

    }
}

public class CatState_DIE : CatState
{
    protected CatStateName name = CatStateName.DIE;
    #region State Method
    public override void EnterState(Animator animator)
    {
        base.EnterState(animator);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    #endregion
    public CatState_DIE(Animator Animator, CatFSM fsm) : base(Animator, fsm)
    {

    }
}


public enum CatStateName //representation of all the cat states
{
    IDLE,
    WALK,
    JUMP,
    EAT,
    DRINK,
    DIE,
}
