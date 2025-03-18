using Combat.Guns;
using Combat.Bullets;
using UnityEngine;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core
{
    public sealed class ShootingSystem
    {

        public event Action<IBullet, Vector3> ShootingBullet;


        private readonly Dictionary<IGun, GunModel> _guns;


        private readonly GunControl _control;

        private readonly IPool<IBullet> _pool;


        private IGun _currentGun;

        private GunModel _gunModel;

        private IGunView _gunView;



        public ShootingSystem(IPool<IBullet> bulletPool)
        {

            _pool = bulletPool;

            _control = new GunControl();

            _guns = new Dictionary<IGun, GunModel>();
        }


        public void AddGun(IGun gun)
        {

            _currentGun = gun;

            _gunView = _currentGun.View;


            _gunModel = GetGunModel(gun);

            _gunModel.SetReloaded();
        }


        #region Set/Unset System

        public void SetSystem()
        {

            _control.DirectionChanged += _gunView.OnDirectionChanged;
            
            _control.PullingTrigger += _gunModel.Shoot;


            _gunModel.Shooting += OnShooting;

            _gunModel.Reloading += OnReloadingAsync;
        }

        public void UnsetSystem()
        {

            _control.DirectionChanged -= _gunView.OnDirectionChanged;
            
            _control.PullingTrigger -= _gunModel.Shoot;
            

            _gunModel.Shooting -= OnShooting;
            
            _gunModel.Reloading -= OnReloadingAsync;
        }

        #endregion


        public void HandleInput()
        {

            _control.HandleInput();
        }


        private GunModel GetGunModel(IGun gun)
        {

            if (!_guns.TryGetValue(gun, out GunModel model))
            {

                model = new GunModel(gun.Stats);

                _guns.Add(gun, model);
            }

            return model;
        }


        #region Shooting/Reloading Events Handlers

        private void OnShooting(Vector3 direction)
        {

            if(_pool.TryGetObject(out IBullet bullet))
            {

                Rigidbody body = bullet.Rigidbody;

                body.gameObject.SetActive(true);

                body.position = _currentGun.MuzzlePosition;

                body.linearVelocity = Vector3.zero;


                ShootingBullet?.Invoke(bullet, direction);
            }
        }


        private async void OnReloadingAsync(IReloadable reloadable, float rateOfFire)
        {

            int mls = (int)(rateOfFire * 1000);

            //#TODO add cancellation token
            await Task.Delay(mls);

            reloadable.SetReloaded();
        }
        
        #endregion
    }
}
