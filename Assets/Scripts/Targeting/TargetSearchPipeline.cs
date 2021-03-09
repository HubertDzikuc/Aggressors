using System.Collections.Generic;
using System;

namespace Aggressors.Targeting
{
    public class TargetSearchPipeline
    {
        private List<Func<Unit>> searches = new List<Func<Unit>>();

        private ILockTarget lockTarget;

        public TargetSearchPipeline(ILockTarget lockTarget)
        {
            this.lockTarget = lockTarget;
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

        public void AddAction<T>(TargetSearch.Search<T> targetSearch) where T : Unit
        {
            searches.Add(() => targetSearch(UnitsManager.Instance.GetUnits<T>()));
        }
    }
}