using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteStateMachine
{
    public class FSM
    {
        
    }

    public class State
    {
        public virtual void EnterState()
        {
            Debug.Log("Enter State");
        }

        public virtual void ExitState()
        {
            Debug.Log("Exit State");
        }

        public virtual void UpdateState()
        {
            Debug.Log("Update State");
        }

        public virtual void FixedUpdateState()
        {
            Debug.Log("Fixed Update State");
        }
    }
}
