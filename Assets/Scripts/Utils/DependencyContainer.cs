using System;
using System.Collections.Generic;

namespace Aggressors.Utils
{
    public class DependencyContainer
    {
        private Dictionary<Type, Func<object>> mappings = new Dictionary<Type, Func<object>>();

        public T Get<T>()
        {
            var type = typeof(T);

            if (mappings.TryGetValue(type, out var generator))
            {
                return (T)generator();
            }
            else
            {
                throw new Exception();
            }
        }

        public DependencyContainer AddScoped<TInterface, TConcrete>(Func<TConcrete> generator) where TConcrete : TInterface
        {
            mappings.Add(typeof(TInterface), () => generator());
            return this;
        }
    }
}