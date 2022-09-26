using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChatOptionCondition : ScriptableObject
{
    public abstract bool IsConditionMet(GameObject go);
}