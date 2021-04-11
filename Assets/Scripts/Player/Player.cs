using Aggressors.GameState;
using Aggressors.Resources;
using Aggressors.Spawn;
using Aggressors.Targeting;

namespace Aggressors
{
    public interface IPlayer
    {
        bool LeftSide { get; set; }
        IResources Resources { get; }
    }

    public class Player : IPlayer
    {
        public bool LeftSide { get; set; }
        public IResources Resources { get; }
        private readonly IGameManager gameManager;
        private readonly IGameStateManager gameStateManager;
        private readonly ISpawnManager spawnManager;
        private readonly IInput input;

        public Player(IResources resources, IGameManager gameManager, ISpawnManager spawnManager, IInput input, IGameStateManager gameStateManager)
        {
            this.input = input;
            this.gameManager = gameManager;
            this.spawnManager = spawnManager;
            this.gameManager.OnUpdate += Update;
            this.Resources = resources;
            this.gameStateManager = gameStateManager;
        }

        private void Update()
        {
            if (input.SpawnUnit())
            {
                spawnManager.SpawnUnit<APC>(this).Match(x =>
                {
                    x.transform.position = gameStateManager.CurrentSpawnPoint(LeftSide);
                    x.Setup(new PositionTarget(input.MousePosition()), this);
                });
            }
        }
    }
}