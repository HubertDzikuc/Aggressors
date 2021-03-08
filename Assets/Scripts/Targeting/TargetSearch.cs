using System.Collections.Generic;

namespace Aggressors.Targeting
{
    public static class TargetSearch
    {
        public delegate T Search<T>(List<T> targets) where T : Unit;
    }
}