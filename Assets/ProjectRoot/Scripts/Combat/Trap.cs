using UnityEngine;
using System;

namespace Combat
{
    public sealed class Trap : MonoBehaviour, ITrap
    {

        public event Action<GameObject> Stepping;


        private void OnTriggerEnter(Collider other)
        {
            
            Stepping?.Invoke(other.gameObject);
        }
    }
}
