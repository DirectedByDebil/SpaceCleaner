namespace Pickables.Bonuses
{
    public interface IBonus : IPickable
    {

        public BonusType BonusType { get; }


        public float Duration { get; }

        public int IncreaseValue { get; }
    }
}
