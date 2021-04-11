using System;
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

            public ITargetSearchPipeline AddTargeting(ILockTarget targetLock)
            {
                var targetSearchPipeline = new TargetSearchPipeline(targetLock, ServicesProvider.Get<IUnitsManager>(), owner);

                owner.OnUpdate += () => targetSearchPipeline.Handle()?.OnTargeted?.Invoke(owner);

                return targetSearchPipeline;
            }

            public void AddOnTargeted<T>(Action<T> onTargeted) where T : Unit
            {
                owner.OnTargeted += unit =>
                {
                    if (unit.GetType() == typeof(T))
                    {
                        onTargeted((T)unit);
                    }
                };
            }
        }
    }
}
