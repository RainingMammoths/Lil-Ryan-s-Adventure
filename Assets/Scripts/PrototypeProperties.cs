using Assets.Scripts.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class PrototypeProperties
    {
        [JsonConverter(typeof(ComponentPrototypePropertiesConverter))]
        public Dictionary<string, IComponentPrototypeProperties> Properties { get; set; } = new Dictionary<string, IComponentPrototypeProperties>();
    }
}
