using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ComponentPrototypeProperties
{
    public class SizePrototypeProperties : IComponentPrototypeProperties
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; }
        public IComponentPrototypeProperties Clone()
        {
            return new SizePrototypeProperties { MinValue = MinValue, MaxValue = MaxValue };
        }

        public void ModifyComponent(GameObject go)
        {
            float randomFloat = UnityEngine.Random.Range(MinValue, MaxValue);
            go.transform.localScale = new Vector3(randomFloat, 1f, randomFloat);
        }
    }
}
