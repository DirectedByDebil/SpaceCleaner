using UnityEngine;
using System;

namespace Combat
{
    public interface IDamager
    {

        public event Action<GameObject, int> Damaging;
    }
}
