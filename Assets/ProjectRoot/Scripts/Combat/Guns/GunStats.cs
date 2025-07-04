using UnityEngine;

namespace Combat.Guns
{

    [CreateAssetMenu(fileName = "Gun Stats",
    menuName = "Gun Stats", order = 3)]

    public sealed class GunStats : ScriptableObject, IGunStats
    {

        [field: SerializeField, Range(0, 1.5f), Space]
        public float RateOfFire { get; private set; }
    }
}
