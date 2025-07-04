using UnityEngine;

namespace Combat.Guns
{
    public interface IGun
    {

        public IGunStats Stats { get; }

        public IGunView View { get; }


        public Vector3 MuzzlePosition { get; }
    }
}