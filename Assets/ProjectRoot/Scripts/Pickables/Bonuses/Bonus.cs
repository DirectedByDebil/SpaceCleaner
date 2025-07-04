using UnityEngine;

namespace Pickables.Bonuses
{
    public sealed class Bonus : PickableObject, IBonus
    {

        public BonusType BonusType { get => _bonusType; }

        public float Duration { get => _duration; }

        public int IncreaseValue { get => _increaseValue; }


        public override PickableType PickableType => PickableType.Bonus;


        [SerializeField, Space]
        private BonusType _bonusType;


        [SerializeField, HideInInspector, Range(1, 20), Space]
        private float _duration;


        [SerializeField, HideInInspector, Range(1, 20), Space]
        private int _increaseValue;


        public override void OnPickedUp()
        {

            gameObject.SetActive(false);
        }
    }
}
