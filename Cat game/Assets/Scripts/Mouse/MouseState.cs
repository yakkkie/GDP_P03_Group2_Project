using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine;

public class MouseState : State
{
    public class MouseState_IDLE : MouseState
    {
        protected MouseStateName stateName = MouseStateName.IDLE;

        #region State Method
        public override void EnterState()
        {
            
            Debug.Log("IDLE_ENTER");

            base.EnterState();
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
    }

    public class MouseState_HOLDITEM : MouseState
    {
        protected MouseStateName stateName = MouseStateName.HOLDITEM;

        #region State Method
        public override void EnterState()
        {

            Debug.Log("HOLDITEM_ENTER");

            base.EnterState();
        }

        public override void ExitState()
        {
            Debug.Log("HOLDITEM_EXIT");
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

    public class MouseState_DROPITEM : MouseState
    {
        protected MouseStateName stateName = MouseStateName.DROPITEM;

        #region State Method
        public override void EnterState()
        {

            Debug.Log("DROPITEM_ENTER");

            base.EnterState();
        }

        public override void ExitState()
        {
            Debug.Log("DROPITEM_EXIT");
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

    public enum MouseStateName //representation of all the mouse states
    {
        IDLE,
        HOLDITEM,
        DROPITEM
    }

}
