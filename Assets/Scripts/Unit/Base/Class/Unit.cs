using Aggressors.Targeting;
using UnityEngine;

namespace Aggressors
{

    public abstract partial class Unit : MonoBehaviour
    {
        public bool LeftSide { get; private set; }

        [field: SerializeField]
        public uint Cost { get; private set; } = 50;

        protected ITarget Target { get; private set; }

        public void Setup(ITarget target, bool leftSide)
        {
            Target = target;
            LeftSide = leftSide;
        }

        protected abstract void Initialize(InitializeOptions options);
        protected void Start()
        {
            Configuration.Instance.Provider.Get<IUnitsManager>().Register(this);
            Initialize(new InitializeOptions(this));
        }

        protected void OnDestroy()
        {
            Configuration.Instance.Provider.Get<IUnitsManager>().Deregister(this);
        }
    }
}
