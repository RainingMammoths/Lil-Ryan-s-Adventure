using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionV2<TObj,TArgs> : MonoBehaviour
{
    public abstract bool Condition(TObj obj, TArgs args);
    public abstract void Action(TObj obj, TArgs args);
    public StateV2<TObj,TArgs> stateToSwitchTo;
}
