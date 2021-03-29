using System.Collections.Generic;
using System;

namespace Aggressors.Targeting
{
    public interface ITargetSearchPipeline
    {
        Unit Handle();
        void AddAction<T>(Func<List<T>, T> targetSearch) where T : Unit;
    }

    public class TargetSearchPipeline : ITargetSearchPipeline
    {
        private List<Func<Unit>> searches = new List<Func<Unit>>();

        private readonly ILockTarget lockTarget;
        private readonly IUnitsManager unitsManager;

        public TargetSearchPipeline(ILockTarget lockTarget, IUnitsManager unitsManager)
        {
            this.lockTarget = lockTarget;
            this.unitsManager = unitsManager;
        }

        public Unit Handle()
        {
            for (int i = 0; i < searches.Count; i++)
            {
                var target = searches[i].Invoke();
                if (target != null)
                {
                    this.lockTarget.Lock(target);
                    return target;
                }
            }
            return null;
        }

        public void AddAction<T>(Func<List<T>, T> targetSearch) where T : Unit
        {
            searches.Add(() => targetSearch(unitsManager.GetUnits<T>()));
        }
    }
}