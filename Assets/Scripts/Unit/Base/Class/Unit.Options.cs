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

            public TargetSearchPipeline AddTargeting(ILockTarget targetLock)
            {
                var targetSearchPipeline = new TargetSearchPipeline(targetLock);

                owner.OnUpdate += () => targetSearchPipeline.Handle()?.OnTargeted?.Invoke(owner);

                return targetSearchPipeline;
            }

            public void AddOnTargeted(Action<Unit> onTargeted)
            {
                owner.OnTargeted += onTargeted;
            }
        }
    }
}
