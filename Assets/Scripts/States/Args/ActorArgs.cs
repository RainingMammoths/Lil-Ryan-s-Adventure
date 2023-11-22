using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.States
{
    [CreateAssetMenu]
    public class ActorArgs : ScriptableObject
    {
        [SerializeField] public GameObject Target;
    }
}

