namespace Pickables
{
    public interface IGarbage : IPickable
    {

        public GarbageType GarbageType { get; }
    }
}
