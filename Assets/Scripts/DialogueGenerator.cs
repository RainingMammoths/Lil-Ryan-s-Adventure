using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGenerator : Observer
{
    public override void OnNotify<TSubject>(TSubject subject, EVENT subjectEvent)
    {
        if (subject is InputHandle inputHandle)
        {
            switch ((EVENT)subjectEvent)
            {
                case EVENT.INTERACT:
                    {
                        Debug.Log("Subject interacted with something.");
                        break;
                    }
            }
        }
    }
}