using Characters;
using Combat;
using Pickables;
using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public sealed class GameProgress
    {

        private readonly Dictionary<GameObject, ICharacter> _characters;

        private readonly Dictionary<GameObject, IPickable> _pickables;


        private readonly CombatSystem _combatSystem;

        private readonly EnemiesSystem _enemiesSystem;


        //Spawn system


        public GameProgress(EnemiesSystem enemiesSystem)
        {

            _characters = new Dictionary<GameObject, ICharacter>();

            _pickables = new Dictionary<GameObject, IPickable>();


            _combatSystem = new CombatSystem();

            _enemiesSystem = enemiesSystem;
        }


        #region Set/Unset Player
        
        public void SetPlayer(Player player)
        {

            _characters.Add(player.gameObject, player);

            _combatSystem.AddCharacter(player);
        }


        public void UnsetPlayer(Player player)
        {

            _combatSystem.RemoveCharacter(player);

            _characters.Remove(player.gameObject);
        }

        #endregion


        #region Set/Unset Traps

        public void SetTraps(IReadOnlyCollection<ITrap> traps)
        {

            foreach (ITrap trap in traps)
            {

                trap.Stepping += OnTrapStepping;
            }   
        }


        public void UnsetTraps(IReadOnlyCollection<ITrap> traps)
        {

            foreach (ITrap trap in traps)
            {

                trap.Stepping -= OnTrapStepping;
            }
        }

        #endregion


        #region Set/Unset Damagers

        public void SetDamagers(IEnumerable<IDamager> damagers)
        {

            foreach (IDamager damager in damagers)
            {

                damager.Damaging += OnDamaging;
            }
        }


        public void UnsetDamagers(IEnumerable<IDamager> damagers)
        {

            foreach (IDamager damager in damagers)
            {

                damager.Damaging -= OnDamaging;
            }
        }

        #endregion


        #region void Set/Unset Enemies

        public void SetEnemies(IReadOnlyCollection<Enemy> enemies)
        {

            foreach(Enemy enemy in enemies)
            {

                enemy.Damaging += OnDamaging;


                _characters.TryAdd(enemy.gameObject, enemy);

                _combatSystem.AddCharacter(enemy);


                //#TODO remove this
                if(enemy.gameObject.activeInHierarchy)
                {

                    _enemiesSystem.AddEnemy(enemy);
                }
            }
        }


        public void UnsetEnemies(IEnumerable<Enemy> enemies)
        {

            foreach (Enemy enemy in enemies)
            {

                enemy.Damaging -= OnDamaging;


                _combatSystem.RemoveCharacter(enemy);

                _characters.Remove(enemy.gameObject);


                _enemiesSystem.RemoveEnemy(enemy);
            }
        }

        #endregion


        #region Set/Unset System

        public void SetSystem()
        {

            _combatSystem.OnEnded += OnEnded;
        }


        public void UnsetSystem()
        {

            _combatSystem.OnEnded -= OnEnded;
        }

        #endregion


        private void OnTrapStepping(GameObject obj)
        {

            if(TryGetCharacter(obj, out ICharacter character))
            {

                _combatSystem.BreakShield(character);
            }
        }


        private void OnDamaging(GameObject obj, int damage)
        {

            if(TryGetCharacter(obj, out ICharacter character))
            {

                _combatSystem.OnDamaging(character, damage);
            }
        }


        private void OnEnded(ICharacter character)
        {

            if(character is IEnemy enemy)
            {

                _enemiesSystem.RemoveEnemy(enemy);

            }
            else if (character is IPlayer player)
            {

                GUIOutput.AddOutput("Game over", "(((((");
            }
        }


        private bool TryGetCharacter(GameObject obj, out ICharacter character)
        {

            return _characters.TryGetValue(obj, out character);
        }
    }
}
