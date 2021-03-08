namespace Aggressors.Targeting
{
    public interface ILockTarget
    {
        bool Locked { get; set; }
        void Lock(Unit target);
    }
}