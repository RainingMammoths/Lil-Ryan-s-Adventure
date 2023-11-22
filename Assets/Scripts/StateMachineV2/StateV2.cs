using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class StateV2<TObj, TArgs> : MonoBehaviour
    {
        public List<TransitionV2<TObj, TArgs>> transitions;
       
       
        void Start()
        {
            
        }

        public StateV2<TObj,TArgs> CheckForTransitions(TObj obj, TArgs args)
        {
            foreach (var transition in transitions)
            {
                if (transition.Condition(obj,args) == true)
                {
                    transition.Action(obj, args);
                    return transition.stateToSwitchTo;
                }
            }
            return this;
        }
    }
}
