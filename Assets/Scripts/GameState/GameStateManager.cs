using UnityEngine;

namespace Aggressors.GameState
{
    public interface IGameStateManager
    {
        Vector2 CurrentSpawnPoint(bool leftSide);
    }

    public class GameStateManager : IGameStateManager
    {
        public Vector2 CurrentSpawnPoint(bool leftSide)
        {
            if (leftSide)
            {
                return new Vector2(-10, 0);
            }
            else
            {
                return new Vector2(10, 0);
            }
        }
    }
}