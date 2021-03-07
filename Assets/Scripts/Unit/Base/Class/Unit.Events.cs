using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aggressors
{
    public partial class Unit
    {
        private event Action OnUpdate;
        private event Action<Unit> OnTargeted;

        protected void Target(Unit target)
        {
            target.OnTargeted?.Invoke(this);
        }

        protected void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
