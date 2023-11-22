using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachineV2<TObj,TArgs> : MonoBehaviour
{
    public StateV2<TObj, TArgs> CurrentState;
    private TObj StateObject { get; set; }
    [SerializeField] public TArgs args;
    protected virtual void Start()
    {
        StateObject = GetComponent<TObj>();
    }

    private void FixedUpdate()
    {
        CurrentState = CurrentState.CheckForTransitions(StateObject,args);
    }
}
