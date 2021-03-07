using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Aggressors
{
    public partial class Unit
    {
        protected class InitializeOptions
        {
            private Unit owner;

            public InitializeOptions(Unit owner)
            {
                this.owner = owner;
            }

            public void AddOnUpdate(Action action)
            {
                owner.OnUpdate += action;
            }

            public void AddTargeting<T>(Action<List<T>> targetingMethod) where T : Unit
            {
                owner.OnUpdate += () => targetingMethod(UnitsManager.Instance.GetUnits<T>());
            }

            public void AddOnTargeted(Action<Unit> onTargeted)
            {
                owner.OnTargeted += onTargeted;
            }
        }
    }
}
