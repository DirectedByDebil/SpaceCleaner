using Movement;
using UnityEngine;
using System;

namespace Combat
{

    [RequireComponent(typeof(Rigidbody))]
    public sealed class Bullet : MonoBehaviour, IDamager, IPhysical
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


        public event Action<GameObject, int> Damaging;


        [SerializeField, Range(1, 20), Space]
        private int _damage;


        private Rigidbody _rigidbody;


        private void OnCollisionEnter(Collision collision)
        {

            Damaging?.Invoke(collision.gameObject, _damage);           
        }
    }
}