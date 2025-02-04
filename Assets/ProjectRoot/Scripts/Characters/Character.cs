using Combat;
using Movement;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody))]
    public class Character : MonoBehaviour, ICharacter
    {

        public IHealthStats HealthStats { get => _healthStats; }

        public IMovementStats MovementStats { get => _movementStats; }

        public Rigidbody Rigidbody { get => GetComponent<Rigidbody>(); }


        [SerializeField, Space]
        private HealthStats _healthStats;

        [SerializeField, Space]
        private MovementStats _movementStats;
    }
}