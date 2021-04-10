using System;

namespace Aggressors.Utils
{
    public class Option<T> where T : class
    {
        public T Value { get; private set; }
        public bool IsNone { get; private set; }

        private Option(T value)
        {
            this.IsNone = false;
            this.Value = value;
        }

        private Option()
        {
            this.IsNone = true;
            this.Value = null;
        }

        public static Option<T> Some(T value)
        {
            return new Option<T>(value);
        }

        public static Option<T> None()
        {
            return new Option<T>();
        }

        public void Match(Action<T> onSome, Action onNone)
        {
            if (IsNone || Value == null)
            {
                onNone();
            }
            else
            {
                onSome(Value);
            }
        }
    }
}