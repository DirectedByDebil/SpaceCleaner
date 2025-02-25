using Characters;
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

                    Changed?.Invoke(_character, _hp);
                }
            }
        }

        public bool HasShield { get => _hasShield; }


        public event Action<ICharacter> Ended;

        public event Action<ICharacter, int> Changed;

        public event Action<ICharacter> ShieldEnded;

        public event Action<ICharacter> ShieldRestored;



        private readonly ICharacter _character;

        private readonly int _maxHP;

        private bool _hasShield;

        private int _hp;



        public Health(ICharacter character)
        {

            _character = character;


            IHealthStats stats = _character.HealthStats;

            _maxHP = stats.MaxHp;
            

            SetStats(stats);
        }


        public void SetStats(IHealthStats stats)
        {

            SetShield(stats.HasShield);

            Current = _maxHP;
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


        public void TryApplyDamage(int diff)
        {

            if (_hasShield) return;


            int newHp = _hp - diff;


            if(newHp <= 0)
            {

                newHp = 0;

                Ended?.Invoke(_character);
            }

            Current = newHp;
        }

        #endregion


        #region Add/Break Shield

        public void AddShield()
        {

            SetShield(true);
        }


        public void BreakShield()
        {

            SetShield(false);
        }


        private void SetShield(bool hasShield)
        {

            _hasShield = hasShield;


            if (_hasShield)
            {

                ShieldRestored?.Invoke(_character);
            }
            else
            {

                ShieldEnded?.Invoke(_character);
            }
        }
        
        #endregion
    }
}
