using System;
using Aggressors.Utils;
using UnityEngine;

namespace Aggressors
{
    public interface IGameManager
    {
        event Action OnUpdate;
        void Update();
    }

    public class GameManager : IGameManager
    {
        public event Action OnUpdate;

        public void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}