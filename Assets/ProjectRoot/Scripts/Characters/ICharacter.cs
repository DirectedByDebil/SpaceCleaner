using Combat;
using Movement;

namespace Characters
{
    public interface ICharacter : IMoveable
    {

        public IHealthStats HealthStats { get; }


        public IHealthView HealthView { get; }
    }
}
