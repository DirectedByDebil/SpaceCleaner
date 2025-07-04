using Characters;
using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public sealed class EnemiesPool : MonoBehaviour, IEnemyPool
    {

        public IReadOnlyCollection<Enemy> AllEnemies
        { 
            get => _allEnemies;
        }

        public IReadOnlyCollection<IEnemy> ActiveEnemies
        {
            get => _activeEnemies;
        }


        [SerializeField, Space]
        private List<Enemy> _allEnemies;

        [SerializeField, Space]
        private List<Enemy> _activeEnemies;


        private EnemyDifficulty _enemyDifficulty;


        private void OnValidate()
        {

            _allEnemies.Clear();

            _activeEnemies.Clear();


            foreach(Transform child in transform)
            {

                if (child.TryGetComponent(out Enemy enemy))
                {

                    AddEnemy(enemy);
                }
            }
        }


        private void AddEnemy(Enemy enemy)
        {
            
            _allEnemies.Add(enemy);


            if(enemy.gameObject.activeInHierarchy)
            {

                _activeEnemies.Add(enemy);
            }
        }


        #region Try Get Enemy

        public bool TryGetObject(out Enemy enemy)
        {

            enemy = _allEnemies.Find(IsAvailable);

            return enemy != null;
        }


        public bool TryGetEnemy(EnemyDifficulty difficulty, out Enemy enemy)
        {

            _enemyDifficulty = difficulty;

            enemy = _allEnemies.Find(IsAvailableDifficulty);

            return enemy != null;
        }

        #endregion


        #region Is Available

        private bool IsAvailable(Enemy enemy)
        {

            return !enemy.gameObject.activeInHierarchy;
        }


        private bool IsAvailableDifficulty(Enemy enemy)
        {

            return enemy.EnemyDifficulty == _enemyDifficulty &&
                !enemy.gameObject.activeInHierarchy;
        }
        
        #endregion
    }
}
