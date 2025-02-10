using UnityEngine;

namespace Movement
{
    public sealed class BulletMovement
    {

        private readonly IMovementStats _stats;


        public BulletMovement(IMovementStats stats)
        {

            _stats = stats;
        }


        public void MakeMovement(Rigidbody rigidbody, Vector3 direction)
        {

            Vector3 to = direction - rigidbody.position;

            to.Normalize();

            //#TODO better add Time.fixedDeltaTime

            rigidbody.AddForce(to * _stats.Acceleration, ForceMode.Impulse);
        }
    }
}
