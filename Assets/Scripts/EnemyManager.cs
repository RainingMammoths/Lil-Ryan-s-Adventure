using Assets.Scripts.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] string prototypeJSON_;
        [SerializeField] GameObject prefab;
        private Dictionary<string, EnemyInfo> EnemyInfos { get; set; }
        private Dictionary<string, EnemyPrototypeInfo> EnemyPrototypes { get; set; }

        private void Start()
        {
            var properties = JsonConvert.DeserializeObject<EnemyInfos>(prototypeJSON_);
            EnemyInfos = properties.Prototypes.ToDictionary(prototype => prototype.ID);
            EnemyPrototypes = new Dictionary<string, EnemyPrototypeInfo>();
            foreach(var enemyInfo in EnemyInfos)
            {
                EnemyPrototypes[enemyInfo.Key] = BuildPrototypeInfo(enemyInfo.Value);
            }
        }

        private EnemyPrototypeInfo BuildPrototypeInfo(EnemyInfo info)
        {
            if (string.IsNullOrWhiteSpace(info.PrototypeID))
            {
                return new EnemyPrototypeInfo { PrototypeObject = prefab, Properties = info.Properties.ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value.Clone())};
            }
            else
            {
                var prototypeInfo = BuildPrototypeInfo(EnemyInfos[info.PrototypeID]);
                foreach (var property in info.Properties)
                {
                    prototypeInfo.Properties[property.Key] = property.Value.Clone();
                }
                return prototypeInfo;
            }
        }

        public GameObject BuildEnemy(string ID, Vector3 position, Quaternion rotation)
        {
            return EnemyPrototypes[ID].Build(position, rotation);
        }
    }
}
