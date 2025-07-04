using Combat.Bullets;
using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public sealed class BulletPool : IPool<IBullet>
    {

        public IReadOnlyCollection<IBullet> Bullets
        { 
            get => _bullets; 
        }


        private List<Bullet> _bullets;


        public BulletPool(int capacity)
        {

            _bullets = new List<Bullet>(capacity);
        }


        public void FindBullets(Transform parent)
        {

            _bullets.Clear();


            foreach (Transform child in parent)
            {

                if (child.TryGetComponent(out Bullet bullet))
                {

                    _bullets.Add(bullet);
                }
            }
        }


        public bool TryGetObject(out IBullet bullet)
        {

            bullet = _bullets.Find(IsAvailable);

            return bullet != null;
        }


        private bool IsAvailable(Bullet bullet)
        {

            return !bullet.gameObject.activeInHierarchy;
        }
    }
}