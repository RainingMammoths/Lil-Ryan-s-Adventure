using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class TriggerStateAction : StateAction<MapManager, TrapTileArgs>
    {
        public override IEnumerator Perform(MapManager obj, TrapTileArgs args)
        {
            yield return new WaitForSeconds(.5f);
            obj.trapTileStateMachine.SetState<TriggeredState>();
            obj.trapTileStateMachine.PerformAction<ExpandStateAction>(args);
        }
    }
}
