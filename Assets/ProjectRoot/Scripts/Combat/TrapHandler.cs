using UnityEngine;
using System.Collections.Generic;

namespace Combat
{
    public sealed class TrapHandler : MonoBehaviour
    {

        public IReadOnlyCollection<Trap> Traps
        { 
            get => _traps; 
        }


        [SerializeField, Space]
        private List<Trap> _traps = new ();


        private void OnValidate()
        {

            _traps.Clear();


            foreach(Transform child in transform)
            {

                if(child.TryGetComponent(out Trap trap))
                {

                    _traps.Add(trap);
                }
            }
        }
    }
}
