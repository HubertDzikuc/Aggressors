using UnityEngine;

namespace Aggressors.Spawn
{
    [System.Serializable]
    public class SpawnManagerConfiguration // ScriptableObject
    {
        [field: SerializeField]
        public APC Apc { get; private set; }
        public SpawnManagerConfiguration(APC apc)
        {
            this.Apc = apc;
        }
    }

    public interface ISpawnManager
    {
        Unit SpawnUnit<T>() where T : Unit;
    }

    public class SpawnManager : ISpawnManager
    {
        private SpawnManagerConfiguration configuration;

        public SpawnManager(SpawnManagerConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Unit SpawnUnit<T>() where T : Unit
        {
            if (typeof(T) == typeof(APC))
            {
                return UnityEngine.Object.Instantiate(configuration.Apc);
            }
            else
            {
                return UnityEngine.Object.Instantiate(configuration.Apc);
            }
        }
    }
}