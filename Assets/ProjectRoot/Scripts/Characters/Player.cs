using Combat;
using Combat.Views;
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


        public override IHealthView HealthView { get => _playerUI; }

        public IPlayerUI UI { get => _playerUI; }



        [SerializeField, Space]
        private PlayerUI _playerUI;


        private Rigidbody _rigidbody;

        private NavMeshAgent _agent;
    }
}
