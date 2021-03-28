namespace Aggressors.Resources
{
    public interface IResources
    {
        uint Amount { get; }
        bool TryRemove(uint amount);
    }

    public class Resources : IResources
    {
        public uint Amount { get; private set; }

        public void Add(uint amount)
        {
            Amount += amount;
        }

        public bool TryRemove(uint amount)
        {
            if (amount <= Amount)
            {
                Amount -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}