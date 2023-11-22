using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class ArmedState : State<MapManager,TrapTileArgs>
    {
        public override bool CanPerform<TAction>(MapManager obj, TrapTileArgs args)
        {
            return true;
        }
    }
}
