using System.Collections.Generic;
using System;

namespace Aggressors.Targeting
{
    public interface ITargetSearchPipeline
    {
        Unit Handle();
        void Friendlies<T>(Func<List<T>, T> targetSearch) where T : Unit;
        void Enemies<T>(Func<List<T>, T> targetSearch) where T : Unit;
    }

    public class TargetSearchPipeline : ITargetSearchPipeline
    {
        private List<Func<Unit>> searches = new List<Func<Unit>>();

        private readonly ILockTarget lockTarget;
        private readonly IUnitsManager unitsManager;
        private readonly Unit owner;

        public TargetSearchPipeline(ILockTarget lockTarget, IUnitsManager unitsManager, Unit owner)
        {
            this.lockTarget = lockTarget;
            this.unitsManager = unitsManager;
            this.owner = owner;
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

        public void Friendlies<T>(Func<List<T>, T> targetSearch) where T : Unit
        {
            searches.Add(() => targetSearch(unitsManager.GetUnits<T>(owner.LeftSide)));
        }

        public void Enemies<T>(Func<List<T>, T> targetSearch) where T : Unit
        {
            searches.Add(() => targetSearch(unitsManager.GetUnits<T>(!owner.LeftSide)));
        }
    }
}