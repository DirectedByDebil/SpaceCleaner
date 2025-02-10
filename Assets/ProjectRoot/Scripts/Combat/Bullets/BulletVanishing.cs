using Movement;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace Combat.Bullets
{

    public sealed class BulletVanishing
    {

        public event Action<VanishingGameObject> Vanished;


        private Dictionary<GameObject, VanishingGameObject> _bullets;


        #region Set/Unset System

        public void SetSystem(IReadOnlyCollection<IPhysical> bullets)
        {

            _bullets = new Dictionary<GameObject, VanishingGameObject>(bullets.Count);

            
            foreach (IPhysical bullet in bullets)
            {

                GameObject obj = bullet.Rigidbody.gameObject;


                VanishingGameObject vanishing = new(obj);

                vanishing.Vanishing += OnVanishing;


                _bullets.Add(obj, vanishing);
            }
        }


        public void UnsetSystem(IEnumerable<IPhysical> bullets)
        {

            foreach (IPhysical bullet in bullets)
            {

                VanishingGameObject body = _bullets[bullet.Rigidbody.gameObject];

                body.Vanishing -= OnVanishing;
            }
        }

        #endregion


        public VanishingGameObject StartVanishing(GameObject obj)
        {

            VanishingGameObject vanishing = _bullets[obj];

            vanishing.SetReady();

            return vanishing;
        }


        private void OnVanishing(GameObject obj)
        {

            VanishingGameObject body = _bullets[obj];

            obj.SetActive(false);


            Vanished?.Invoke(body);
        }
    }
}
