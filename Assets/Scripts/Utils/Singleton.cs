using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aggressors.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T Instance {get ; private set;}

        protected virtual void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            } 
            else
            {
                Instance = (T)this;
            }
        }
    }
}
