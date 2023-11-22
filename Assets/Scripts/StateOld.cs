using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOld : MonoBehaviour
{
    private StateOld currentState_;
    [SerializeField] private StateOld exitState_;
    private float exitTime;
    private Stack<StateOld> stateStack_;

    private IEnumerator Exit(float time)
    {
        yield return new WaitForSeconds(time);
        currentState_ = exitState_;
    }

    public IEnumerator Transition(StateOld state, Func<Boolean> condition, float time = 0, StateOld exitState = null, Func<Boolean> exitCondition = null)
    {
        if (time > 0) yield return new WaitForSeconds(time);
        if (condition()) // then Transition to given state
        {
            currentState_ = state;
        }
        if (exitState != null) StartCoroutine(Transition(exitState, exitCondition));
    }



}
