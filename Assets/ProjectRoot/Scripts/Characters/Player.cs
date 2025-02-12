using Combat;
using UnityEngine;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Player : Character, IPlayer
    {

        public Rigidbody Rigidbody { get => GetComponent<Rigidbody>(); }

        public override IHealthView HealthView { get => _healthView; }


        [SerializeField, Space]
        private PlayerHealthView _healthView;
    }
}
