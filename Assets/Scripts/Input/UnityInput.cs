using UnityEngine;

namespace Aggressors
{
    public interface IInput
    {
        bool SpawnUnit();
        Vector2 MousePosition();
    }

    public class UnityInput : IInput
    {
        public Vector2 MousePosition() => UnityEngine.Input.mousePosition;

        public bool SpawnUnit() => UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.A);
    }
}