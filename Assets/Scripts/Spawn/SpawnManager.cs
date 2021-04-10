using Aggressors.Resources;
using Aggressors.Utils;
using UnityEngine;

namespace Aggressors.Spawn
{
    [System.Serializable]
    public class SpawnManagerConfiguration // ScriptableObject
    {
        [field: SerializeField]
        public APC Apc { get; private set; } //Change this to be a list and add on validate to make sure all types are implemented 
        public SpawnManagerConfiguration(APC apc)
        {
            this.Apc = apc;
        }
    }

    public interface ISpawnManager
    {
        Option<T> SpawnUnit<T>(IResources resource) where T : Unit;
    }

    public class SpawnManager : ISpawnManager
    {
        private SpawnManagerConfiguration configuration;

        public SpawnManager(SpawnManagerConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Option<T> SpawnUnit<T>(IResources resource) where T : Unit
        {
            Unit unitToSpawn = null;
            if (typeof(T) == typeof(APC))
            {
                unitToSpawn = configuration.Apc;
            }
            else
            {
                unitToSpawn = configuration.Apc;
            }
            if (resource.TryRemove(unitToSpawn.Cost))
            {
                return Option<T>.Some((T)UnityEngine.Object.Instantiate(unitToSpawn));
            }
            else
            {
                return Option<T>.None();
            }
        }
    }
}