using Assets.Scripts;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachine<TObj,TArgs> : MonoBehaviour
{
    public State<TObj, TArgs> state;
    private TObj StateObject { get; set; }
    [SerializeField] private List<State<TObj, TArgs>> states;
    public Dictionary<Type, State<TObj, TArgs>> TypeToState { get; set; }

    public void SetState<TState>() where TState : State<TObj, TArgs>
    {
        state = TypeToState[typeof(TState)];
    }

    public void PerformAction<TAction>(TArgs args) where TAction : StateAction<TObj, TArgs>
    {
        state.PerformAction<TAction>(StateObject, args, this);
    }
    void Start()
    {
        StateObject = GetComponent<TObj>();
        TypeToState = states.ToDictionary(state => state.GetType(), state => state);
    }

    private void FixedUpdate()
    {
        state = state.CheckForTransitions(StateObject);
    }

    void Update()
    {
        
    }
}
