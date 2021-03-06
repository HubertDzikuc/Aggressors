using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aggressors
{
    public class APC : Unit<APC>
    {
        protected override void OnTargeted<T>(T enemy)
        {
            Debug.Log($"{gameObject.name} Targeted by {enemy}");
        }

        protected override void Register(UnitOptions options)
        {

        }
    }
}
