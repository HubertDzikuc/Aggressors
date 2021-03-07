using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aggressors
{
    public class APC : Unit
    {
        private void OnTargeted(Unit enemy)
        {
            //Debug.Log($"{gameObject.name} Targeted by {enemy}");
        }

        protected override void Initialize(InitializeOptions options)
        {
            options.AddOnTargeted(OnTargeted);
        }
    }
}
