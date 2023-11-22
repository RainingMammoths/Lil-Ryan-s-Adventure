using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class State<TObj, TArgs> : MonoBehaviour
    {

        public List<Transition<TObj, TArgs>> transitions;
        [SerializeField] private List<StateAction<TObj,TArgs>> stateActions;
        public Dictionary<Type, StateAction<TObj,TArgs>> StateActions { get; set; }
        void Start()
        {
            StateActions = stateActions.ToDictionary(action => action.GetType(), action => action);
        }

        public void PerformAction<TAction>(TObj obj, TArgs args, StateMachine<TObj,TArgs> stateMachine) where TAction : StateAction<TObj, TArgs>
        {
            if (!StateActions.ContainsKey(typeof(TAction))) return; // if registered
            var action = StateActions[typeof(TAction)]; 
            if (!CanPerform<TAction>(obj,args)) return; // if performable
            StartCoroutine(action.Perform(obj,args));
        }

        /*public State<TObj, TArgs> Transition(Func<GameObject, bool> condition, State<TObj, TArgs> stateToSwitchTo)
        {
            return condition(gameObject) != true ? currentState : stateToSwitchTo;
        }*/

        public State<TObj,TArgs> CheckForTransitions(TObj obj)
        {
            foreach (var transition in transitions) // How do I loop these?
            {
                if (transition.Condition(obj) == true)
                    return transition.stateToSwitchTo;
            }
            return this;
        }

        public abstract bool CanPerform<TAction>(TObj obj,TArgs args) where TAction : StateAction<TObj, TArgs>;
    }
}
