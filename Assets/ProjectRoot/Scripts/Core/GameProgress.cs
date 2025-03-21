﻿using Characters;
using Combat;
using Pickables;
using Pickables.Bonuses;
using Levels;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Core
{
    public sealed class GameProgress
    {

        public event Action GameWon;

        public event Action GameOver;

        public event Action GameStopping;


        public event Action<IEnemy> EnemyEnded;

        public event Action<IGarbage> PickingGarbage;

        public event Action<IBonus> PickingBonus;


        private readonly Dictionary<GameObject, ICharacter> _characters;


        private readonly CombatSystem _combatSystem;

        private readonly EnemySystem _enemySystem;

        private readonly ILevelFinish _levelFinish;


        private IPlayer _player;


        public GameProgress(EnemySystem enemySystem, ILevelFinish levelFinish)
        {

            _characters = new Dictionary<GameObject, ICharacter>();


            _combatSystem = new CombatSystem();

            _enemySystem = enemySystem;


            _levelFinish = levelFinish;
        }


        #region Set/Unset Player
        
        public void SetPlayer(Player player)
        {

            _player = player;


            _characters.Add(player.gameObject, player);

            _combatSystem.AddCharacter(player);
        }


        public void UnsetPlayer(Player player)
        {

            if(player)
            {

                _combatSystem.RemoveCharacter(player);

                _characters.Remove(player.gameObject);
            }
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


        #region Set/Unset Enemies

        public void SetEnemies(IReadOnlyCollection<Enemy> enemies)
        {

            foreach(Enemy enemy in enemies)
            {

                enemy.Damaging += OnDamaging;


                _characters.TryAdd(enemy.gameObject, enemy);

                _combatSystem.AddCharacter(enemy);


                if(enemy.gameObject.activeInHierarchy)
                {

                    _enemySystem.AddEnemy(enemy);
                }
            }
        }


        public void UnsetEnemies(IEnumerable<Enemy> enemies)
        {

            foreach (Enemy enemy in enemies)
            {

                enemy.Damaging -= OnDamaging;


                _combatSystem.RemoveCharacter(enemy);

                if(enemy)
                {

                    _characters.Remove(enemy.gameObject);
                }

                _enemySystem.RemoveEnemy(enemy);
            }
        }

        #endregion


        #region Set/Unset Pickables
        
        public void SetPickables(IEnumerable<IPickable> pickables)
        {

            foreach(IPickable pickable in pickables)
            {

                pickable.PickingUp += OnPickingUp;
            }
        }


        public void UnsetPickables(IEnumerable<IPickable> pickables)
        {

            foreach (IPickable pickable in pickables)
            {

                pickable.PickingUp -= OnPickingUp;
            }
        }

        #endregion


        #region Set/Unset Level Finish
        
        public void SetLevelFinish(ILevelFinish levelFinish)
        {

            levelFinish.Finishing += OnFinishing;
        }


        public void UnsetLevelFinish(ILevelFinish levelFinish)
        {

            levelFinish.Finishing -= OnFinishing;
        }

        #endregion


        #region Set/Unset System

        public void SetSystem()
        {

            _enemySystem.SetSystem();

            _enemySystem.EnemyAdded += _combatSystem.RestoreCharacter;


            _combatSystem.OnEnded += OnEnded;
        }


        public void UnsetSystem()
        {

            _enemySystem.UnsetSystem();

            _enemySystem.EnemyAdded -= _combatSystem.RestoreCharacter;


            _combatSystem.OnEnded -= OnEnded;
        }

        #endregion


        public void OnGoalAchieved()
        {

            _levelFinish.Unlock();
        }


        #region Bonus Events Handlers

        public void OnPickingHealth(int increaseValue)
        {

            _combatSystem.AddHealth(_player, increaseValue);
        }


        public void OnPickingShield(float duration)
        {

            _combatSystem.AddShieldAsync(_player, duration);
        }

        #endregion


        #region Combat Event Handlers

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

                _enemySystem.RemoveEnemy(enemy);

                EnemyEnded?.Invoke(enemy);

            }
            else if (character is IPlayer player)
            {

                StopGame();
                
                GameOver?.Invoke();
            }
        }
        
        #endregion


        private void OnPickingUp(IPickable pickable)
        {

            switch (pickable.PickableType)
            {

                case PickableType.Garbage:

                    PickingGarbage?.Invoke(pickable as IGarbage);
                    break;
                
                case PickableType.Gun:
                    break;
                
                case PickableType.Bonus:

                    PickingBonus?.Invoke(pickable as IBonus);
                    break;
            }
        }


        private void StopGame()
        {
            //#TODO stop game

            GameStopping?.Invoke();
        }


        private void OnFinishing()
        {

            StopGame();


            GameWon?.Invoke();
        }


        private bool TryGetCharacter(GameObject obj, out ICharacter character)
        {

            return _characters.TryGetValue(obj, out character);
        }
    }
}
