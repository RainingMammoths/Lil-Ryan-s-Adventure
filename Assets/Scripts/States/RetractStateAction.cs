using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    public class RetractStateAction : StateAction<MapManager, TrapTileArgs>
    {
        public override IEnumerator Perform(MapManager obj, TrapTileArgs args)
        {
            var tileBase = obj.stateToTileData[TrapState.Deployed].tiles.First();

            obj.map.SetTile(args.Position, tileBase);
            yield return new WaitForSeconds(3f);
            tileBase = obj.stateToTileData[TrapState.Triggered].tiles.First();
            obj.map.SetTile(args.Position, tileBase);
            yield return new WaitForSeconds(.5f);
            tileBase = obj.stateToTileData[TrapState.Armed].tiles.First();
            obj.map.SetTile(args.Position, tileBase);
            obj.trapTileStateMachine.SetState<ArmedState>();
        }
    }
}
