using UnityEngine;

namespace Aggressors.Targeting
{
    public interface ITarget
    {
        Vector2 Position { get; }
    }

    public class PositionTarget : ITarget
    {
        public Vector2 Position { get; private set; }

        public PositionTarget(Vector2 position)
        {
            this.Position = position;
        }
    }
}