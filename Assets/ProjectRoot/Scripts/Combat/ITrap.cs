using UnityEngine;
using System;

namespace Combat
{
    public interface ITrap
    {

        public event Action<GameObject> Stepping;
    }
}
