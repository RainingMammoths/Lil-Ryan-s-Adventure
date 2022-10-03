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
        public Dictionary<string, string> Properties { get; set; }
        public string PrototypeID { get; set; }
        public string ID { get; set; }  

    }
}
