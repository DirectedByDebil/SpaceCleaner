using System;

namespace Pickables.Bonuses
{
    public sealed class BonusSystem
    {

        public event Action<int> PickingHealth;

        public event Action<float> PickingShield;


        public void OnPickingBonus(IBonus bonus)
        {

            switch (bonus.BonusType)
            {

                case BonusType.Heal:

                    PickingHealth?.Invoke(bonus.IncreaseValue);
                    break;
             

                case BonusType.Shield:

                    PickingShield?.Invoke(bonus.Duration);
                    break;
            }


            bonus.OnPickedUp();
        }
    }
}
