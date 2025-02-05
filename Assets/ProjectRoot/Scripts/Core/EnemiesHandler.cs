using Characters;
using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public sealed class EnemiesHandler : MonoBehaviour
    {

        public IReadOnlyCollection<IEnemy> AllEnemies
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
    }
}
