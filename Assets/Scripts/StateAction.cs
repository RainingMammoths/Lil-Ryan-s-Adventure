using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class StateAction<TObj,TArgs> : MonoBehaviour
    {
        public abstract IEnumerator Perform(TObj obj, TArgs args);
    }
}
