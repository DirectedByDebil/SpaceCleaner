using System;

namespace Combat
{
    public sealed class Health
    {

        public int Current
        {
            get => _hp;

            private set
            {

                if (_hp != value)
                {

                    _hp = value;

                    Changed?.Invoke(_hp);
                }
            }
        }


        public event Action Ended;

        public event Action<int> Changed;

        public event Action ShieldEnded;


        private readonly int _maxHP;

        private bool _hasShield;

        private int _hp;



        public Health(IHealthStats stats)
        {

            _maxHP = stats.MaxHp;
            
            _hasShield = stats.HasShield;


            _hp = _maxHP;
        }


        #region Heal/Apply Damage

        public void Heal(int diff)
        {

            int newHp = _hp + diff;

            if(newHp > _maxHP)
            {
                newHp = _maxHP;
            }


            Current = newHp;
        }


        public void ApplyDamage(int diff)
        {

            if (_hasShield) return;


            int newHp = _hp - diff;

            if(newHp <= 0)
            {
                newHp = 0;

                Ended?.Invoke();
            }

            Current = newHp;
        }
        
        #endregion


        public void BreakShield()
        {

            _hasShield = false;

            ShieldEnded?.Invoke();
        }
    }
}
