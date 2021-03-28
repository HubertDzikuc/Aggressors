using System.Collections.Generic;
using Aggressors.Utils;
using System.Linq;
using System;
using UnityEngine;

namespace Aggressors
{
    public class UnitsManager : Singleton<UnitsManager>
    {
        private Dictionary<Type, List<Unit>> units = new Dictionary<Type, List<Unit>>();

        public List<T> GetUnits<T>() where T : Unit
        {
            var unitType = typeof(T);
            if (units.ContainsKey(unitType))
            {
                return units[unitType].Select(x => (T)x).ToList();
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