using System.Collections.Generic;
using Aggressors.Resources;
using Aggressors.Spawn;
using Aggressors.Utils;

namespace Aggressors
{
    public class PlayersManager : Singleton<PlayersManager>
    {
        private List<Player> players = new List<Player>();

        private void Start()
        {
            var container = new DependencyContainer();

            container.AddScoped<IResourcesManager, ResourcesManager>(() => ResourcesManager.Instance);
            container.AddScoped<IGameManager, GameManager>(() => GameManager.Instance);
            container.AddScoped<ISpawnManager, SpawnManager>(() => SpawnManager.Instance);

            players.Add(new Player(container.Get<IResourcesManager>(), container.Get<IGameManager>(), container.Get<ISpawnManager>()));
        }
    }
}