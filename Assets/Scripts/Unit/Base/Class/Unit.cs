using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Aggressors
{
    public abstract partial class Unit : MonoBehaviour
    {
        protected abstract void Initialize();

        protected void Start()
        {
            UnitsManager.Instance.Register(this);
            Initialize();
        }

        protected void OnDestroy()
        {
            UnitsManager.Instance.Deregister(this);
        }
    }
}
