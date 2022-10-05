using Assets.Scripts.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [Serializable]
    public class EnemyInfo
    {
        [JsonConverter(typeof(ComponentPrototypePropertiesConverter))]
        public Dictionary<string, IComponentPrototypeProperties> Properties { get; set; }
        public string PrototypeID { get; set; }
        public string ID { get; set; }

        public EnemyInfo Clone()
        {
            return new EnemyInfo
            {
                PrototypeID = PrototypeID,
                ID = ID,
                Properties = Properties.ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value.Clone())
            };
        }
    }
}
