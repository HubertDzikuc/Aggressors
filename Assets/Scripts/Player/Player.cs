using Aggressors.Resources;
using Aggressors.Spawn;

namespace Aggressors
{
    public interface IPlayer
    {
        IResources Resources { get; }
    }

    public class Player : IPlayer
    {
        public IResources Resources { get; private set; }
        private readonly IGameManager gameManager;
        private readonly ISpawnManager spawnManager;
        private readonly IInput input;

        public Player(IResources resources, IGameManager gameManager, ISpawnManager spawnManager, IInput input)
        {
            this.input = input;
            this.gameManager = gameManager;
            this.spawnManager = spawnManager;
            this.gameManager.OnUpdate += Update;
            this.Resources = resources;
        }

        private void Update()
        {
            if (input.SpawnUnit())
            {
                spawnManager.SpawnUnit<APC>(Resources);
            }
        }
    }
}