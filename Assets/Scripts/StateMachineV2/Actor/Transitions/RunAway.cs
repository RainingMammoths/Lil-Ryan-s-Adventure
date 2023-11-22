using Assets.Scripts.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachineV2.Transitions
{
    public class RunAway : TransitionV2<Actor, ActorArgs>
    {
        public override void Action(Actor obj, ActorArgs args)
        {
            obj.Move(obj.transform.position - args.Target.transform.position, 5f * Time.deltaTime);
        }

        public override bool Condition(Actor obj, ActorArgs args)
        {
            var dist = Vector2.Distance(obj.gameObject.transform.position, args.Target.transform.position);
            return dist < 5f;
        }
    }
}
