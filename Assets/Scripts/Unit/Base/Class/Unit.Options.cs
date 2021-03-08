using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Aggressors.Targeting;

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

            public void AddTargeting<T>(Func<List<T>, T> targetingMethod, ITargeting targeting) where T : Unit
            {
                owner.OnUpdate += () =>
                {
                    var units = UnitsManager.Instance.GetUnits<T>();
                    if (units != null)
                    {
                        var target = targetingMethod(units);
                        if (target != null)
                        {
                            targeting.Target(target);
                            target.OnTargeted?.Invoke(owner);
                        }
                    }
                };

            }

            public void AddOnTargeted(Action<Unit> onTargeted)
            {
                owner.OnTargeted += onTargeted;
            }
        }
    }
}
