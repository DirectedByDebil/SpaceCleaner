using Combat.Bullets;
using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public sealed class BulletPool : MonoBehaviour, IPool<IBullet>
    {

        public IReadOnlyCollection<IBullet> Bullets
        { 
            get => _bullets; 
        }


        [SerializeField]
        private List<Bullet> _bullets;


        private void OnValidate()
        {

            _bullets.Clear();


            foreach(Transform child in transform)
            {

                if(child.TryGetComponent(out Bullet bullet))
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