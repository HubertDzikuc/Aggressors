using System;
using System.Collections.Generic;
using Aggressors.Targeting;
using UnityEngine;

namespace Aggressors
{
    public class Tank : Unit
    {
        [SerializeField]
        private Turret turret = null;

        private APC TargetingTanks(List<APC> apcs)
        {
            foreach (var apc in apcs)
            {
                return apc;
            }

            return null;
        }

        protected override void Initialize(InitializeOptions options)
        {
            options.AddTargeting(turret)
                .AddAction<APC>(TargetingTanks);
        }
    }
}
