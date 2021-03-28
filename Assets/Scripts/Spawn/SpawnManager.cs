using Aggressors.Utils;
using UnityEngine;

namespace Aggressors.Spawn
{
    public interface ISpawnManager
    {
        Unit SpawnUnit<T>() where T : Unit;
    }

    public class SpawnManager : Singleton<SpawnManager>, ISpawnManager
    {
        [SerializeField]
        private APC apc = null;

        public Unit SpawnUnit<T>() where T : Unit
        {
            if (typeof(T) == typeof(APC))
            {
                return Instantiate(apc);
            }
            else
            {
                return Instantiate(apc);
            }
        }
    }
}