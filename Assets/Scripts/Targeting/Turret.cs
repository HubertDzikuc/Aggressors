using UnityEngine;

namespace Aggressors.Targeting
{
    public class Turret : MonoBehaviour, ILockTarget
    {
        public void Lock(Unit target)
        {
            Debug.Log($"{nameof(Turret)} targets: {target}");
        }
    }
}