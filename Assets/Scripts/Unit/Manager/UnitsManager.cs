using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aggressors.Utils;
using System.Linq;

namespace Aggressors
{
    public class UnitsManager : Singleton<UnitsManager>
    {
        public static Dictionary<System.Type, UnitType> TypesMapper = new Dictionary<System.Type, UnitType>()
        {
            { typeof(APC), UnitType.APC},
            { typeof(Tank), UnitType.Tank}
        };

        private Dictionary<UnitType, List<Unit>> units = new Dictionary<UnitType, List<Unit>>();

        public List<T> GetUnits<T>() where T : Unit
        {
            var unitType = TypesMapper[typeof(T)];
            if (units.ContainsKey(unitType))
            {
                return units[unitType].Select(x => (T)x).ToList();
            }
            else
            {
                return null;
            }
        }

        public UnitType Register(Unit unit)
        {
            var unitType = TypesMapper[unit.GetType()];
            if (units.ContainsKey(unitType))
            {
                units[unitType].Add(unit);
            }
            else
            {
                units.Add(unitType, new List<Unit> { unit });
            }
            return unitType;
        }

        public void Deregister(Unit unit)
        {
            var unitType = TypesMapper[unit.GetType()];
            if (units.ContainsKey(unitType))
            {
                units[unitType].Remove(unit);
            }
        }
    }
}