using Characters;
using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public sealed class EnemiesPool : MonoBehaviour, IPool<IEnemy>
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


        public bool TryGetObject(out IEnemy enemy)
        {

            enemy = _allEnemies.Find(IsAvailable);

            return enemy != null;
        }


        private bool IsAvailable(Enemy enemy)
        {

            return !enemy.gameObject.activeInHierarchy;
        }
    }
}
