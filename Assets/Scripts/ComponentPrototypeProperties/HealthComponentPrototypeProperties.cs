using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ComponentPrototypeProperties
{
    public class HealthComponentPrototypeProperties : IComponentPrototypeProperties
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public IComponentPrototypeProperties Clone()
        {
            return new HealthComponentPrototypeProperties { MinValue = MinValue, MaxValue = MaxValue };
        }

        public void ModifyComponent(GameObject go)
        {
            var randomInt = UnityEngine.Random.Range(MinValue, MaxValue+1);
            var healthComponent = go.AddComponent<HealthComponent>();
            healthComponent.Health = randomInt;
        }
    }
}
