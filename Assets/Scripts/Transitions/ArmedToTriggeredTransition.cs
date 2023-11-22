using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedToTriggeredTransition : Transition<MapManager,Object>
{
    // Start is called before the first frame update
    public override bool Condition(MapManager obj)
    {
        return true;
    }
}
