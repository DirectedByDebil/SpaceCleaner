using Combat;
using Movement;

namespace Characters
{
    public interface ICharacter
    {

        public IHealthStats HealthStats { get; }

        public IMovementStats MovementStats { get; }
    }
}
