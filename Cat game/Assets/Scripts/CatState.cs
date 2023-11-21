using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine;

public class CatState : State
{
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
}

public class CatState_IDLE : CatState
{
    protected CatStateName stateName = CatStateName.IDLE;

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
}

public class CatState_WALK : CatState
{
    protected CatStateName stateName = CatStateName.WALK;

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
}

public class CatState_EAT : CatState
{
    protected CatStateName stateName = CatStateName.EAT;

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
}

public class CatState_DRINK : CatState
{
    protected CatStateName stateName = CatStateName.DRINK;

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
}

public enum CatStateName //representation of all the cat states
{
    IDLE,
    WALK,
    JUMP,
    EAT,
    DRINK,
}