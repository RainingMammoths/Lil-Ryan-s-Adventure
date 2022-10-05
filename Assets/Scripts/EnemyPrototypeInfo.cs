using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyPrototypeInfo
    {
        public Dictionary<string, IComponentPrototypeProperties> Properties { get; set; }
        public GameObject PrototypeObject { get; set; }

        public GameObject Build(Vector3 position, Quaternion rotation)
        {
            GameObject go = GameObject.Instantiate(PrototypeObject, position, rotation);
            foreach (var property in Properties.Values)
            {
                property.ModifyComponent(go);
            }
            return go;
        }
    }
}
