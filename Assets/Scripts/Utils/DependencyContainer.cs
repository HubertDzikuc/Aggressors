using System;
using System.Collections.Generic;

namespace Aggressors.Utils
{
    public interface IServicesProvider
    {
        T Get<T>();
    }

    public interface IServicesConfiguration
    {
        IServicesConfiguration AddScoped<TInterface, TConcrete>() where TConcrete : TInterface, new();
        IServicesConfiguration AddScoped<TInterface, TConcrete>(Func<TConcrete> generator) where TConcrete : TInterface;
        IServicesConfiguration AddSingleton<TInterface, TConcrete>() where TConcrete : TInterface, new();
        IServicesConfiguration AddSingleton<TInterface, TConcrete>(Func<TConcrete> generator) where TConcrete : TInterface;
    }

    public class DependencyContainer : IServicesProvider, IServicesConfiguration
    {
        private interface IMapping
        {
            object Get();
        }

        private class ScopedMapping : IMapping
        {
            private Func<object> generator;
            public ScopedMapping(Func<object> generator)
            {
                this.generator = generator;
            }

            public object Get()
            {
                return generator();
            }
        }

        private class SingletonMapping : IMapping
        {
            private Func<object> generator;
            private object cache = null;
            public SingletonMapping(Func<object> generator)
            {
                this.generator = generator;
            }

            public object Get()
            {
                if (cache == null)
                {
                    cache = generator();
                }
                return cache;
            }
        }

        private Dictionary<Type, IMapping> mappings = new Dictionary<Type, IMapping>();
        public T Get<T>()
        {
            var type = typeof(T);

            if (mappings.TryGetValue(type, out var mapping))
            {
                return (T)mapping.Get();
            }
            else
            {
                throw new Exception();
            }
        }

        public IServicesConfiguration AddScoped<TInterface, TConcrete>() where TConcrete : TInterface, new()
        {
            mappings.Add(typeof(TInterface), new ScopedMapping(() => new TConcrete()));
            return this;
        }

        public IServicesConfiguration AddScoped<TInterface, TConcrete>(Func<TConcrete> generator) where TConcrete : TInterface
        {
            mappings.Add(typeof(TInterface), new ScopedMapping(() => generator()));
            return this;
        }

        public IServicesConfiguration AddSingleton<TInterface, TConcrete>() where TConcrete : TInterface, new()
        {
            mappings.Add(typeof(TInterface), new SingletonMapping(() => new TConcrete()));
            return this;
        }

        public IServicesConfiguration AddSingleton<TInterface, TConcrete>(Func<TConcrete> generator) where TConcrete : TInterface
        {
            mappings.Add(typeof(TInterface), new SingletonMapping(() => generator()));
            return this;
        }
    }
}