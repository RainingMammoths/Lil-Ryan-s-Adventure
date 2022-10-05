using Assets.Scripts.ComponentPrototypeProperties;
using Assets.Scripts.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class ComponentPrototypePropertiesConverter : JsonConverter<Dictionary<string, IComponentPrototypeProperties>>
    {
        public override Dictionary<string, IComponentPrototypeProperties> ReadJson(JsonReader reader, Type objectType, Dictionary<string, IComponentPrototypeProperties> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = new Dictionary<string, IComponentPrototypeProperties>();
            while (reader.TokenType != JsonToken.EndObject)
            {
                if (reader.TokenType == JsonToken.PropertyName)
                {
                    var componentName = (string)reader.Value;
                    reader.Read();
                    switch (componentName)
                    {
                        case "Health":
                            var health = serializer.Deserialize<HealthComponentPrototypeProperties>(reader);
                            result[componentName] = health;
                            break;
                        case "Speed":
                            var speed = serializer.Deserialize<MovementComponentPrototypeProperties>(reader);
                            result[componentName] = speed;
                            break;
                    }
                }
                reader.Read();
            }
            return result;
        }

        public override void WriteJson(JsonWriter writer, Dictionary<string, IComponentPrototypeProperties> value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
