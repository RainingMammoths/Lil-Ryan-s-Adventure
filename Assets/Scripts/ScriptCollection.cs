using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCollection
{
    public Dictionary <Type,IClonableMonoBehaviour> Scripts { get; } = new Dictionary<Type,IClonableMonoBehaviour>();

    public ScriptCollection Clone()
    {
        var clone = new ScriptCollection();
        foreach (var script in Scripts)
        {
            clone.Scripts.Add(script.Key,script.Value.Clone());
        }
        return clone;
    }
}
