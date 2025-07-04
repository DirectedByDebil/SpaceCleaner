using UnityEngine;

namespace Combat
{

    [CreateAssetMenu(fileName ="Health Stats",
        menuName ="Characters/Stats/Health", order = 1)]
    public sealed class HealthStats : ScriptableObject, IHealthStats
    {

        [field: SerializeField, Range(1, 100)]
        public int MaxHp {  get; private set; }


        [field: SerializeField, Space]
        public bool HasShield {  get; private set; }
    }
}
