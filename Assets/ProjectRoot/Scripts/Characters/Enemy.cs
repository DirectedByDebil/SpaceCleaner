using Combat;
using UnityEngine;
using UnityEngine.AI;
using System;

namespace Characters
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class Enemy : Character, IDamager, IEnemy
    {

        public NavMeshAgent NavMeshAgent { get => GetComponent<NavMeshAgent>(); }


        public event Action<GameObject, int> Damaging;


        [SerializeField, Range(1, 100), Space]
        private int _damage;



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
