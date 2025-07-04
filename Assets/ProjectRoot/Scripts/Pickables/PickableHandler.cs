using UnityEngine;
using System.Collections.Generic;

namespace Pickables
{
    //#TODO make base class ObjectHandler
    public sealed class PickableHandler : MonoBehaviour
    {

        public IEnumerable<IPickable> Pickables { get => _pickables; }


        [SerializeField, Space]
        private List<PickableObject> _pickables;


        private void OnValidate()
        {

            _pickables.Clear();


            foreach(Transform child in transform)
            {

                if(child.TryGetComponent(out PickableObject pickable))
                {

                    _pickables.Add(pickable);
                }
            }
        }
    }
}
