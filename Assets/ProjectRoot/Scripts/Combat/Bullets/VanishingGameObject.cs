using UnityEngine;
using System;

namespace Combat.Bullets
{
    public sealed class VanishingGameObject
    {

        public event Action<GameObject> Vanishing;
        

        public GameObject GameObject { get; }


        private float _elapsedTime;


        public VanishingGameObject(GameObject obj)
        {

            GameObject = obj;
        }


        public void OnTimeChanged(float deltaTime, float duration)
        {

            _elapsedTime += deltaTime;


            if(_elapsedTime > duration)
            {

                Vanishing?.Invoke(GameObject);
            }
        }


        public void SetReady()
        {

            _elapsedTime = 0f;
        }
    }
}
