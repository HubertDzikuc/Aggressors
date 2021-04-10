using Aggressors.GameState;
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
        Option<T> SpawnUnit<T>(IPlayer player) where T : Unit;
    }

    public class SpawnManager : ISpawnManager
    {
        private readonly SpawnManagerConfiguration configuration;
        private readonly IGameStateManager gameStateManager;

        public SpawnManager(SpawnManagerConfiguration configuration, IGameStateManager gameStateManager)
        {
            this.configuration = configuration;
            this.gameStateManager = gameStateManager;
        }

        public Option<T> SpawnUnit<T>(IPlayer player) where T : Unit
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
            if (player.Resources.TryRemove(unitToSpawn.Cost))
            {
                return Option<T>.Some((T)UnityEngine.Object.Instantiate(unitToSpawn, gameStateManager.CurrentSpawnPoint(player.Side), Quaternion.identity));
            }
            else
            {
                return Option<T>.None();
            }
        }
    }
}