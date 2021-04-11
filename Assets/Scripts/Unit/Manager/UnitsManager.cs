using System.Collections.Generic;
using System.Linq;
using System;

namespace Aggressors
{
    public interface IUnitsManager
    {
        List<T> GetUnits<T>(bool leftSide) where T : Unit;
        void Register(Unit unit);
        void Deregister(Unit unit);
    }

    public class UnitsManager : IUnitsManager
    {
        private Dictionary<Type, List<Unit>> units = new Dictionary<Type, List<Unit>>();

        public List<T> GetUnits<T>(bool leftSide) where T : Unit
        {
            var unitType = typeof(T);
            if (units.ContainsKey(unitType))
            {
                return units[unitType].Where(x => x.LeftSide == leftSide).Select(x => (T)x).ToList();
            }
            else
            {
                return new List<T>();
            }
        }

        public void Register(Unit unit)
        {
            var unitType = unit.GetType();
            if (units.ContainsKey(unitType))
            {
                units[unitType].Add(unit);
            }
            else
            {
                units.Add(unitType, new List<Unit> { unit });
            }
        }

        public void Deregister(Unit unit)
        {
            var unitType = unit.GetType();
            if (units.ContainsKey(unitType))
            {
                units[unitType].Remove(unit);
            }
        }
    }
}