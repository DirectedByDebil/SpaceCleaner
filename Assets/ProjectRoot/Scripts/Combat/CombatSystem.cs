using Characters;
using Pickables.Bonuses;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Combat
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

                health.ShieldRestored += OnShieldRestored;

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

                health.ShieldRestored -= OnShieldRestored;

                health.Changed -= OnHealthChanged;

                health.Ended -= OnHealthEnded;


                _healths.Remove(character);
            }
        }

        #endregion


        public void AddHealth(ICharacter character, int increaseValue)
        {

            _healths[character].Heal(increaseValue);
        }


        public void RestoreCharacter(ICharacter character)
        {

            _healths[character].SetStats(character.HealthStats);
        }


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


        //#TODO replace it to somewhere else
        //#BUG: if shield took twice time counts wrong
        public async void AddShieldAsync(IPlayer player, float duration)
        {

            Health health = _healths[player];

            health.AddShield();


            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {

                if (!health.HasShield) return;


                elapsedTime += Time.deltaTime;

                player.UI.OnShieldWorking(elapsedTime / duration);

                await Task.Yield();
            }


            health.BreakShield();
        }


        #region Events Handlers

        private void OnShieldEnded(ICharacter character)
        {

            character.HealthView.OnShieldEnded();
        }


        private void OnShieldRestored(ICharacter character)
        {

            character.HealthView.OnShieldRestored();
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
