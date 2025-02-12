using Combat;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace Characters
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class Enemy : Character, IEnemy
    {

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


        public event Action<GameObject, int> Damaging;



        [SerializeField, Range(1, 100), Space]
        private int _damage;


        [SerializeField, Space]
        private EnemyHealthView _healthView;


        private NavMeshAgent _agent;


        private void OnCollisionEnter(Collision collision)
        {
            
            GameObject obj = collision.gameObject;


            if (obj.CompareTag("Player"))
            {

                Damaging?.Invoke(obj, _damage);
            }
        }
    }
}
