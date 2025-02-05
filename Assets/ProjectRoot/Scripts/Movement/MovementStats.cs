using UnityEngine;

namespace Movement
{

    [CreateAssetMenu(fileName ="Movement Stats",
        menuName ="Characters/Stats/Movement", order = 2)]
    public sealed class MovementStats : ScriptableObject, IMovementStats
    {

        [field: SerializeField, Range(1, 20)]
        public float Speed { get; private set; }


        [field: SerializeField, Range(10, 100)]
        public float Acceleration { get; private set; }
    }
}
