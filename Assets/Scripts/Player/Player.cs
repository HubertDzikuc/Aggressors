using Aggressors.Resources;
using Aggressors.Spawn;

namespace Aggressors
{
    public interface IPlayer
    {

    }

    public class Player : IPlayer
    {
        public uint Resources => resources.Amount;
        private IResources resources;

        private readonly IResourcesManager resourcesManager;
        private readonly IGameManager gameManager;
        private readonly ISpawnManager spawnManager;

        public Player(IResourcesManager resourcesManager, IGameManager gameManager, ISpawnManager spawnManager)
        {
            this.resourcesManager = resourcesManager;
            this.gameManager = gameManager;
            this.spawnManager = spawnManager;
            this.gameManager.OnUpdate += Update;
            this.resources = resourcesManager.AddResource();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.A))
            {
                spawnManager.SpawnUnit<APC>();
            }
        }
    }
}