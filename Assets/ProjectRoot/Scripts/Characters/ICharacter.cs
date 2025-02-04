using Movement;
using Combat;
using UnityEngine;

namespace Characters
{
    public interface ICharacter
    {

        public IHealthStats HealthStats { get; }

        public IMovementStats MovementStats { get; }


        public Rigidbody Rigidbody { get; }
    }
}
