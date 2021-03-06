using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aggressors
{
    public partial class Unit<TSelf>
    {
        public class UnitOptions
        {
            private Unit<TSelf> owner;

            public UnitOptions(Unit<TSelf> owner)
            {
                this.owner = owner;
            }

            public void RegisterTargeting<T>(Action<List<T>> targetingMethod) where T : Unit
            {
                owner.targetingMethods.Add(() => targetingMethod(UnitsManager.Instance.GetUnits<T>()));
            }
        }
    }
}
