using Aggressors.Targeting;
using UnityEngine;

namespace Aggressors
{

    public abstract partial class Unit : MonoBehaviour
    {
        public IPlayer Owner { get; private set; }

        [field: SerializeField]
        public uint Cost { get; private set; } = 50;

        protected ITarget Target { get; private set; }

        public void Setup(ITarget target, IPlayer owner)
        {
            Target = target;
            Owner = owner;
        }

        protected abstract void Initialize(InitializeOptions options);
        protected void Start()
        {
            ServicesProvider.Get<IUnitsManager>().Register(this);
            Initialize(new InitializeOptions(this));
        }

        protected void OnDestroy()
        {
            ServicesProvider.Get<IUnitsManager>().Deregister(this);
        }
    }
}
