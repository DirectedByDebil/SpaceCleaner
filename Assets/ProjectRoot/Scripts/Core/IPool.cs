namespace Core
{
    public interface IPool<T>
    {

        public bool TryGetObject(out T obj);
    }
}
