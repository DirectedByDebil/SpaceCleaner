using Combat;
using Movement;
using UnityEngine;

namespace Characters
{

    public class Character : MonoBehaviour, ICharacter
    {

        public IHealthStats HealthStats { get => _healthStats; }

        public IMovementStats MovementStats { get => _movementStats; }


        [SerializeField, Space]
        private HealthStats _healthStats;

        [SerializeField, Space]
        private MovementStats _movementStats;
    }
}