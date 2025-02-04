using Combat;
using UnityEngine;
using System;

namespace Characters
{
    public sealed class Enemy : Character, IDamager
    {

        public event Action<GameObject, int> Damaging;


        [SerializeField, Range(1, 100), Space]
        private int _damage;


        private void OnCollisionEnter2D(Collision2D collision)
        {

            GameObject obj = collision.gameObject;


            if (obj.CompareTag("Player"))
            {

                Damaging?.Invoke(obj, _damage);
            }
        }
    }
}
