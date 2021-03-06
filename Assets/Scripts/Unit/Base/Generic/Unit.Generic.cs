using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aggressors
{
    public abstract partial class Unit<TSelf> : Unit where TSelf : Unit<TSelf>
    {
        private event Action OnUpdate;

        protected abstract void Initialize(InitializeOptions options);
        protected virtual void OnTargeted<T>(T unit) where T : Unit<T>
        { }

        protected override void Initialize()
        {
            Initialize(new InitializeOptions(this));
        }

        protected void Target<T>(T target) where T : Unit<T>
        {
            target.OnTargeted<TSelf>((TSelf)this);
        }

        protected void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}