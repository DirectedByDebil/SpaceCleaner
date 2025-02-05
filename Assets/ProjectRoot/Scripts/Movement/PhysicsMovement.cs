using UnityEngine;

namespace Movement
{
    public class PhysicsMovement
    {

        private readonly float _speed;

        private readonly Rigidbody _rb;


        public PhysicsMovement(IMovementStats stats, Rigidbody rb)
        {

            _speed = stats.Speed;

            _rb = rb;
        }


        public void MakeMovement(Vector3 direction)
        {

            direction *= _speed * Time.fixedDeltaTime;

            direction += _rb.position;

            _rb.MovePosition(direction);
        }
    }
}
