using FiniteStateMachine;
using UnityEngine;

public class CatState : State
{
    public Animator animator;
    public CatFSM fsm;
    public Cat cat;

    #region State Method
    public override void EnterState()
    {
        base.EnterState();
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

    public CatState(CatFSM fsm)
    {
        animator = fsm.animator;
        cat = fsm.cat;
        this.fsm = fsm;
    }
}

public class CatState_IDLE : CatState
{
    protected CatStateName stateName = CatStateName.IDLE;

    #region State Method
    public override void EnterState()
    {
        animator.SetBool("walkBool", false);

        base.EnterState();
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

    public CatState_IDLE(CatFSM fsm) : base(fsm)
    {

    }
}

public class CatState_WALK : CatState
{
    protected CatStateName stateName = CatStateName.WALK;

    #region State Method
    public override void EnterState()
    {
        animator.SetBool("walkBool", true);

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if (fsm.agent.velocity.magnitude <= 0)
            fsm.ChangeState(fsm.CatState_IDLE);

    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
    }

    public void WalkToDestination(Vector3 destination)
    {

    }

    public CatState_WALK(CatFSM fsm) : base(fsm)
    {

    }
    #endregion
}

public class CatState_JUMP : CatState
{
    protected CatStateName stateName = CatStateName.JUMP;

    #region State Method
    public override void EnterState()
    {
        base.EnterState();
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

    public CatState_JUMP(CatFSM fsm) : base(fsm)
    {

    }
}

public class CatState_EAT : CatState
{
    protected CatStateName stateName = CatStateName.EAT;
    bool isEating;
    float timer = 0;

    #region State Method
    public override void EnterState()
    {
        isEating = true;
        Debug.Log("EATING");
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if (timer > 0.2)
        {
            cat.currentHunger = Mathf.Clamp(cat.currentHunger += 15, 0, cat.MaxHunger);

            timer = 0;
        }

        if (cat.currentHunger / cat.MaxHunger > 1)
        {
            isEating = false;
        }

        if (!isEating)
            fsm.ChangeState(fsm.CatState_IDLE);

        base.UpdateState();
    }

    public override void FixedUpdateState()
    {


        timer += Time.fixedDeltaTime;
        base.FixedUpdateState();
    }
    #endregion

    public CatState_EAT(CatFSM fsm) : base(fsm)
    {

    }
}

public class CatState_DRINK : CatState
{
    protected CatStateName stateName = CatStateName.DRINK;
    bool isDrinking = false;
    float timer = 0;

    #region State Method
    public override void EnterState()
    {
        isDrinking = true;
        Debug.Log("DRINKING");
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        if (timer > 0.2)
        {

            cat.currentThirst = Mathf.Clamp(cat.currentThirst += 15, 0, cat.MaxThirst);
            timer = 0;
        }

        if (cat.currentThirst / cat.MaxThirst > 1)
        {
            isDrinking = false;
        }

        if (!isDrinking)
            fsm.ChangeState(fsm.CatState_IDLE);

        base.UpdateState();
    }

    public override void FixedUpdateState()
    {
        timer += Time.fixedDeltaTime;
        base.FixedUpdateState();
    }
    #endregion

    public CatState_DRINK(CatFSM fsm) : base(fsm)
    {

    }
}

public class CatState_DIE : CatState
{
    protected CatStateName name = CatStateName.DIE;
    #region State Method
    public override void EnterState()
    {
        base.EnterState();
        animator.SetBool("walkBool", false);

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    #endregion
    public CatState_DIE(CatFSM fsm) : base(fsm)
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
