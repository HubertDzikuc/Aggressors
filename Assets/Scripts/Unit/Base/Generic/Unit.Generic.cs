using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aggressors
{
    public abstract partial class Unit<TSelf> : Unit where TSelf : Unit<TSelf>
    {
        private List<Action> targetingMethods = new List<Action>();

        protected abstract void Register(UnitOptions options);
        protected virtual void OnTargeted<T>(T unit) where T : Unit<T>
        { }

        protected override void Register()
        {
            Register(new UnitOptions(this));
        }

        protected void Target<T>(T target) where T : Unit<T>
        {
            target.OnTargeted<TSelf>((TSelf)this);
        }

        protected void Update()
        {
            RunTargetingMethods();
        }

        private void RunTargetingMethods()
        {
            foreach (var action in targetingMethods)
            {
                action.Invoke();
            }
        }
    }
}