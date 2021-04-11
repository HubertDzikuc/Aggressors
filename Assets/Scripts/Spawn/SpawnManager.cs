using System;
using System.Collections.Generic;
using Aggressors.GameState;
using Aggressors.Resources;
using Aggressors.Utils;
using UnityEngine;

namespace Aggressors.Spawn
{
    public interface ISpawnManagerConfiguration
    {
        Option<T> GetUnit<T>() where T : Unit;
    }

    [System.Serializable]
    public class SpawnManagerConfiguration : ISpawnManagerConfiguration
    {
        [SerializeField]
        private List<Unit> units = new List<Unit>();

        private Dictionary<Type, Unit> unitsDictionary = null;

        public Option<T> GetUnit<T>() where T : Unit
        {
            if (unitsDictionary == null)
            {
                SetupUnits();
            }
            if (unitsDictionary.TryGetValue(typeof(T), out var unit))
            {
                return Option<T>.Some((T)unit);
            }
            else
            {
                return Option<T>.None();
            }
        }

        private void SetupUnits()
        {
            unitsDictionary = new Dictionary<Type, Unit>();
            foreach (var unit in units)
            {
                var type = unit.GetType();
                if (!unitsDictionary.ContainsKey(type))
                {
                    unitsDictionary.Add(type, unit);
                }
            }
        }
    }

    public interface ISpawnManager
    {
        Option<T> SpawnUnit<T>(IPlayer player) where T : Unit;
    }

    public class SpawnManager : ISpawnManager
    {
        private readonly ISpawnManagerConfiguration configuration;
        private readonly IGameStateManager gameStateManager;

        public SpawnManager(ISpawnManagerConfiguration configuration, IGameStateManager gameStateManager)
        {
            this.configuration = configuration;
            this.gameStateManager = gameStateManager;
        }

        public Option<T> SpawnUnit<T>(IPlayer player) where T : Unit
        {
            var returnUnit = Option<T>.None();

            configuration.GetUnit<T>().Match(unit =>
            {
                if (player.Resources.TryRemove(unit.Cost))
                {
                    returnUnit = Option<T>.Some((T)UnityEngine.Object.Instantiate(unit, gameStateManager.CurrentSpawnPoint(player.LeftSide), Quaternion.identity));
                }
            });

            return returnUnit;
        }
    }
}