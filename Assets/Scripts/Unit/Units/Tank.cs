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

        protected override void Register(UnitOptions options)
        {
            options.RegisterTargeting<APC>(TargetingTanks);
        }
    }
}
