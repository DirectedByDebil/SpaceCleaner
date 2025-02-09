using UnityEngine;

namespace Combat.Guns
{
    public sealed class Gun : MonoBehaviour
    {

        public IGunStats Stats { get => _stats; }

        public IGunView View { get => _view; }


        [SerializeField, Space]
        private GunStats _stats;

        [SerializeField, Space]
        private GunView _view;
    }
}
