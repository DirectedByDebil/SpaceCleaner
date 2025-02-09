using Core;
using Movement;
using UnityEngine;
using System;

namespace Combat.Guns
{
    public sealed class GunModel: IReloadable
    {

        public event Action<IPhysical, Vector3> Shot;

        public event Action<IReloadable, float> Reloading;


        private readonly IGunStats _stats;

        private readonly IPool<IPhysical> _pool;


        private bool _canShoot;


        public GunModel(IGunStats stats, IPool<IPhysical> pool)
        {

            _stats = stats;

            _pool = pool;
        }


        public void Shoot(Vector3 direction)
        {

            if(_canShoot && _pool.TryGetObject(out IPhysical bullet))
            {

                _canShoot = false;


                Reloading?.Invoke(this, _stats.RateOfFire);

                Shot?.Invoke(bullet, direction);
            }
        }


        public void SetReloaded()
        {

            _canShoot = true;
        }
    }
}
