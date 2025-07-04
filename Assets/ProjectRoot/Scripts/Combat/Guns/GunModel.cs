using UnityEngine;
using System;

namespace Combat.Guns
{
    public sealed class GunModel: IReloadable
    {

        public event Action<Vector3> Shooting;

        public event Action<IReloadable, float> Reloading;


        private readonly IGunStats _stats;


        private bool _canShoot;


        public GunModel(IGunStats stats)
        {

            _stats = stats;
        }


        public void Shoot(Vector3 direction)
        {

            if(_canShoot)
            {

                _canShoot = false;


                Reloading?.Invoke(this, _stats.RateOfFire);

                Shooting?.Invoke(direction);
            }
        }


        public void SetReloaded()
        {

            _canShoot = true;
        }
    }
}
