using System;
using Aggressors.Utils;

namespace Aggressors
{
    public interface IGameManager
    {
        event Action OnUpdate;
    }

    public class GameManager : Singleton<GameManager>, IGameManager
    {
        public event Action OnUpdate;

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}