using UnityEngine;

namespace Aggressors.Targeting
{
    public class Turret : MonoBehaviour, ILockTarget
    {
        public bool Locked { get; set; }

        public void Lock(Unit target)
        {
            throw new System.NotImplementedException();
        }
    }
}