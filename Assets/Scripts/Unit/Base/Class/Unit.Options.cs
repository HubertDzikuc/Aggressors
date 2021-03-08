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

            public void AddTargeting<T>(TargetSearch.Search<T> targetSearch, ILockTarget targetLock) where T : Unit
            {
                owner.OnUpdate += () =>
                {
                    if (targetLock.Locked == false)
                    {
                        var units = UnitsManager.Instance.GetUnits<T>();
                        if (units != null)
                        {
                            var target = targetSearch(units);
                            if (target != null)
                            {
                                targetLock.Lock(target);
                                targetLock.Locked = true;
                                target.OnTargeted?.Invoke(owner);
                            }
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
