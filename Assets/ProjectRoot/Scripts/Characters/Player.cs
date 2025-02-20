using Combat;
using UnityEngine;
using UnityEngine.AI;

namespace Characters
{
    [RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
    public sealed class Player : Character, IPlayer
    {

        public Rigidbody Rigidbody
        {
            get
            {

                if(_rigidbody == null)
                {

                    _rigidbody = GetComponent<Rigidbody>();
                }

                return _rigidbody;
            }
        }


        public NavMeshAgent NavMeshAgent
        {

            get
            {

                if(_agent == null)
                {

                    _agent = GetComponent<NavMeshAgent>();
                }

                return _agent;
            }
        }


        public override IHealthView HealthView { get => _healthView; }


        [SerializeField, Space]
        private PlayerHealthView _healthView;


        private Rigidbody _rigidbody;

        private NavMeshAgent _agent;
    }
}
