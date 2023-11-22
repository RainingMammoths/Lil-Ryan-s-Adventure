using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition<TObj,TArgs> : MonoBehaviour
{
    public abstract bool Condition(TObj obj);
    public State<TObj,TArgs> stateToSwitchTo;
}
