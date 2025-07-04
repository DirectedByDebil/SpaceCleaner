using System;
using UnityEngine;

namespace Pickables
{
    public abstract class PickableObject : MonoBehaviour, IPickable
    {

        public event Action<IPickable> PickingUp;

        public abstract PickableType PickableType { get; }



        private void OnTriggerEnter(Collider other)
        {
            
            if(other.CompareTag("Player"))
            {

                PickingUp?.Invoke(this);
            }
        }


        public abstract void OnPickedUp();
    }
}
