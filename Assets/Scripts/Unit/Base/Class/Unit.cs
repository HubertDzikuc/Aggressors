using UnityEngine;

namespace Aggressors
{
    public abstract partial class Unit : MonoBehaviour
    {
        protected abstract void Initialize(InitializeOptions options);
        protected void Start()
        {
            UnitsManager.Instance.Register(this);
            Initialize(new InitializeOptions(this));
        }

        protected void OnDestroy()
        {
            UnitsManager.Instance.Deregister(this);
        }
    }
}
