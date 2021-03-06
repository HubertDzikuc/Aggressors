using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aggressors
{
    public class Tank : Unit<Tank>
    {
        private void TargetingTanks(List<APC> apcs)
        {
            foreach (var apc in apcs)
            {
                Target(apc);
            }
        }

        protected override void Initialize(InitializeOptions options)
        {
            options.RegisterTargetingAction<APC>(TargetingTanks);
        }
    }
}
