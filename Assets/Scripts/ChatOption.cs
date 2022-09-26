using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChatOption : ScriptableObject
{
    public Sprite Avatar;
    public string Speaker;
    public string Message;
    public List<ChatOption> Responses;
    public ChatOptionCondition Condition;
}