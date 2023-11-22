using Assets.Scripts.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StateMachineV2.StateMachines
{
    public class ActorStateMachine : StateMachineV2<Actor, ActorArgs>
    {
        protected override void Start()
        {
            base.Start();
            args = new ActorArgs();
            args.Target = GameObject.Find("Player");
        }
    }
}
