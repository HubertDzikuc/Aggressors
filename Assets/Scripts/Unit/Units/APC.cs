using UnityEngine;

namespace Aggressors
{
    public class APC : Unit
    {
        private void OnTargeted(Tank enemyTank)
        {
            Debug.Log($"{gameObject.name} Targeted by {enemyTank}");
        }

        protected override void Initialize(InitializeOptions options)
        {
            options.AddOnTargeted<Tank>(OnTargeted);
        }
    }
}
