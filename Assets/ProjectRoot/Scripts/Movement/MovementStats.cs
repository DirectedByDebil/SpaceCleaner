using UnityEngine;

namespace Movement
{

    [CreateAssetMenu(fileName ="Movement Stats",
        menuName ="Characters/Stats/Movement", order = 2)]
    public sealed class MovementStats : ScriptableObject, IMovementStats
    {

        [field: SerializeField, Range(1, 100)]
        public float Speed { get; private set; }
    }
}
