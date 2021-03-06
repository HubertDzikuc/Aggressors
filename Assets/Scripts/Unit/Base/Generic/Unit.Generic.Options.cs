using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aggressors
{
    public partial class Unit<TSelf>
    {
        protected class InitializeOptions
        {
            private Unit<TSelf> owner;

            public InitializeOptions(Unit<TSelf> owner)
            {
                this.owner = owner;
            }

            public void RegisterAction(Action action)
            {
                owner.OnUpdate += action;
            }

            public void RegisterTargetingAction<T>(Action<List<T>> targetingMethod) where T : Unit
            {
                owner.OnUpdate += () => targetingMethod(UnitsManager.Instance.GetUnits<T>());
            }
        }
    }
}
