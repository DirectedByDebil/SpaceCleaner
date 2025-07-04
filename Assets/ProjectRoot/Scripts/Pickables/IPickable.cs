using System;

namespace Pickables
{
    public interface IPickable
    {

        public PickableType PickableType { get; }


        public event Action<IPickable> PickingUp;


        public void OnPickedUp();
    }
}