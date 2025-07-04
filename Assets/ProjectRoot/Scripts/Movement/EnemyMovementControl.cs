using UnityEngine;
using System;

namespace Movement
{
    public sealed class EnemyMovementControl
    {

        public event Action<Vector3> Pressed;

        private float _checkInputTime;


        public void HandleInput(Vector3 destination, float checkInputTime)
        {

            _checkInputTime += Time.fixedDeltaTime;


            if(_checkInputTime > checkInputTime)
            {

                _checkInputTime = 0f;
             
                Pressed?.Invoke(destination);
            }
        }
    }
}
