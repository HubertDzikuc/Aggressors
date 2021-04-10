using System;
using Aggressors.Resources;
using Aggressors.Spawn;
using Aggressors.Targeting;
using Aggressors.Utils;
using UnityEngine;

namespace Aggressors
{
    public class Configuration : Singleton<Configuration>
    {
        public IServicesProvider Provider { get; private set; }

        [SerializeField]
        private SpawnManagerConfiguration spawnManagerConfiguration = null;

        private void Configure(IServicesConfiguration services)
        {
            services.AddSingleton<IResourcesManager, ResourcesManager>();
            services.AddSingleton<IGameManager, GameManager>();
            services.AddSingleton<ISpawnManager, SpawnManager>(() => new SpawnManager(spawnManagerConfiguration));
            services.AddSingleton<IPlayersManager, PlayersManager>();
            services.AddSingleton<IUnitsManager, UnitsManager>();
            services.AddSingleton<IInput, UnityInput>();

            services.AddScoped<IPlayer, Player>(() =>
                new Player(
                    Provider.Get<IResourcesManager>().AddResource(),
                    Provider.Get<IGameManager>(),
                    Provider.Get<ISpawnManager>(),
                    Provider.Get<IInput>()));
        }

        protected override void Awake()
        {
            base.Awake();

            var containter = new DependencyContainer();
            Provider = containter;
            Configure(containter);

            Provider.Get<IPlayersManager>().Start();
        }

        private void Update()
        {
            Provider.Get<IGameManager>().Update();
        }
    }
}