using Combat.Bullets;
using Movement;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Core
{
    public sealed class BulletsSystem
    {

        private event Action<float, float> timeChanged;


        private readonly BulletMovement _bulletMovement;

        private readonly BulletVanishing _bulletVanishing;


        public BulletsSystem(MovementStats stats)
        {

            _bulletMovement = new BulletMovement(stats);

            _bulletVanishing = new BulletVanishing();
        }


        #region Set/Unset System

        public void SetSystem(IReadOnlyCollection<IPhysical> bullets)
        {

            _bulletVanishing.SetSystem(bullets);

            _bulletVanishing.Vanished += OnBulletVanished;
        }


        public void UnsetSystem(IEnumerable<IPhysical> bullets)
        {

            _bulletVanishing.UnsetSystem(bullets);

            _bulletVanishing.Vanished -= OnBulletVanished;
        }

        #endregion


        public void OnShootingBullet(IPhysical bullet, Vector3 direction)
        {

            Rigidbody rigidbody = bullet.Rigidbody;

            _bulletMovement.MakeMovement(rigidbody, direction);
            

            VanishingGameObject vanishing = _bulletVanishing.
                StartVanishing(rigidbody.gameObject);

            timeChanged += vanishing.OnTimeChanged;
        }


        public void HandleInput(float bulletLifeTime)
        {

            timeChanged?.Invoke(Time.fixedDeltaTime, bulletLifeTime);
        }


        private void OnBulletVanished(VanishingGameObject bullet)
        {

            timeChanged -= bullet.OnTimeChanged;
        }
    }
}
