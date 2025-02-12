using UnityEngine;
using System;

namespace Pickables
{
    public interface IPickable
    {

        public event Action<GameObject, PickableType> PickingUp;
    }
}
