using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aggressors.Utils;
using System.Linq;

namespace Aggressors
{
    public class UnitsManager : Singleton<UnitsManager>
    {
        private Dictionary<System.Type, List<Unit>> units = new Dictionary<System.Type, List<Unit>>();

        public List<T> GetUnits<T>() where T : Unit
        {
            var unitType = typeof(T);
            if (units.ContainsKey(unitType))
            {
                return units[unitType].Cast<T>().ToList();
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