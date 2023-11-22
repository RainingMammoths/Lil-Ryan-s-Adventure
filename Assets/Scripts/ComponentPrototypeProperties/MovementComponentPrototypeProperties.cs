using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ComponentPrototypeProperties
{
    public class MovementComponentPrototypeProperties : IComponentPrototypeProperties
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
        public IComponentPrototypeProperties Clone()
        {
            return new MovementComponentPrototypeProperties { MinValue = MinValue, MaxValue = MaxValue };
        }

        public void ModifyComponent(GameObject go)
        {
            float randomFloat = UnityEngine.Random.Range(MinValue, MaxValue);
            var movementComponent = go.AddComponent<MovementComponent>();
            movementComponent.Speed = randomFloat;
        }
    }
}
