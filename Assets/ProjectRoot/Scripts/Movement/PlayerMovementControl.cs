using UnityEngine;
using System;

namespace Movement
{
    public class PlayerMovementControl
    {

        public event Action<Vector3> Pressed;


        private bool _isRaw;


        public void HandleInput(bool isRaw)
        {

            _isRaw = isRaw;


            Vector3 direction = new ()
            {
                x = GetAxis("Horizontal"),

                z = GetAxis("Vertical")
            };

            Pressed?.Invoke(direction);
        }


        private float GetAxis(string name)
        {

            if(_isRaw)
            {
                return Input.GetAxisRaw(name);
            }

            return Input.GetAxis(name);
        }
    }
}
