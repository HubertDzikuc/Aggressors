using UnityEngine;

namespace Aggressors
{
    public enum UnitType
    {
        APC,
        Tank,
    }

    public abstract partial class Unit : MonoBehaviour
    {
        public UnitType Type { get; private set; }
        protected abstract void Initialize(InitializeOptions options);
        protected void Start()
        {
            Type = UnitsManager.Instance.Register(this);
            Initialize(new InitializeOptions(this));
        }

        protected void OnDestroy()
        {
            UnitsManager.Instance.Deregister(this);
        }
    }
}
