using UnityEngine;

namespace Combat.Guns
{
    public sealed class Gun : MonoBehaviour, IGun
    {

        public IGunStats Stats { get => _stats; }

        public IGunView View { get => _view; }

        public Vector3 MuzzlePosition { get => _muzzle.position; }


        [SerializeField, Space]
        private GunStats _stats;

        [SerializeField, Space]
        private GunView _view;

        [SerializeField, Space]
        private Transform _muzzle;
    }
}
