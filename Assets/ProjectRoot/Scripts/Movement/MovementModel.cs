using UnityEngine;

namespace Movement
{
    public class MovementModel
    {

        private readonly float _speed;

        private readonly Rigidbody _rb;


        public MovementModel(IMovementStats stats, Rigidbody rb)
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
