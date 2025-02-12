using Combat;
using Characters;
using System;
using System.Collections.Generic;

namespace Core
{
    public sealed class CombatSystem
    {

        public event Action<ICharacter> OnEnded;


        private Dictionary<ICharacter, Health> _healths;


        public CombatSystem()
        {

            _healths = new Dictionary<ICharacter, Health>();
        }


        #region Add/Remove Character

        public void AddCharacter(ICharacter character)
        {
            
            if(!_healths.ContainsKey(character))
            {

                Health health = new (character);
                

                health.ShieldEnded += OnShieldEnded;

                health.Changed += OnHealthChanged;

                health.Ended += OnHealthEnded;
                

                _healths.Add(character, health);
            }
        }


        public void RemoveCharacter(ICharacter character)
        {

            if(_healths.TryGetValue(character, out Health health))
            {

                health.ShieldEnded -= OnShieldEnded;

                health.Changed -= OnHealthChanged;

                health.Ended -= OnHealthEnded;


                _healths.Remove(character);
            }
        }

        #endregion


        public void OnDamaging(ICharacter character, int damage)
        {
            
            Health health = _healths[character];

            health.TryApplyDamage(damage);
        }


        public void BreakShield(ICharacter character)
        {

            Health health = _healths[character];

            health.BreakShield();
        }


        #region Events Handlers

        private void OnShieldEnded(ICharacter character)
        {

            character.HealthView.OnShieldEnded();
        }


        private void OnHealthChanged(ICharacter character, int hp)
        {

            character.HealthView.OnHealthChanged(hp);
        }


        private void OnHealthEnded(ICharacter character)
        {

            character.HealthView.OnHealthEnded();

            OnEnded?.Invoke(character);
        }
        
        #endregion
    }
}
