using System;

namespace Aggressors
{
    public partial class Unit
    {
        private event Action OnUpdate;
        private event Action<Unit> OnTargeted;

        protected void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
