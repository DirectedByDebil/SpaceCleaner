using UnityEngine;

namespace Pickables
{
    public sealed class Garbage : PickableObject, IGarbage
    {

        [field: SerializeField, Space]
        public GarbageType GarbageType { get; private set; }


        public override PickableType PickableType => PickableType.Garbage;
        

        public override void OnPickedUp()
        {

            gameObject.SetActive(false);
        }
    }
}
