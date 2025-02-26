using Core;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Characters
{
    public sealed class EnemySpawnSystem
    {

        public event Action<IEnemy> Added;


        private readonly IEnemyPool _pool;

        private readonly IPool<Vector3> _positionPool;


        private readonly List<EnemyDifficulty> _difficultiesKeys;

        private readonly Dictionary<EnemyDifficulty, float> _elapsedTime;


        private int _spawnedCount;


        public EnemySpawnSystem(IEnemyPool pool, IPool<Vector3> positionPool)
        {

            _pool = pool;

            _positionPool = positionPool;


            _elapsedTime = new Dictionary<EnemyDifficulty, float>()
            {

                {EnemyDifficulty.Standart, 0f },

                {EnemyDifficulty.Heavy, 0f },
                
                {EnemyDifficulty.Boss, 0f },
            };


            _difficultiesKeys = new List<EnemyDifficulty>(_elapsedTime.Keys);
        }


        #region Add/Remove Enemy
        
        public void AddEnemy()
        {

            _spawnedCount++;
        }


        public void RemoveEnemy()
        {

            _spawnedCount--;
        }
        
        #endregion


        public void HandleSpawn(SpawnSettings settings)
        {

            if(_spawnedCount < settings.MinEnemies)
            {

                SpawnImmediately(settings.MinEnemies - _spawnedCount);
            }    


            SpawnInTime(settings);
        }


        private void SpawnImmediately(int count)
        {

            int length = Enum.GetValues(typeof(EnemyDifficulty)).Length;


            for(int i = 0; i < count; i++)
            {

                int index = UnityEngine.Random.Range(0, length);
                
                Spawn((EnemyDifficulty) index);
            }
        }


        #region Spawn In Time

        private void SpawnInTime(SpawnSettings settings)
        {
            
            foreach(EnemyDifficulty difficulty in _difficultiesKeys)
            {

                if (_spawnedCount >= settings.MaxEnemies) return;


                UpdateElapsedTime(difficulty, 
                    settings.GetSpawnInterval(difficulty));
            }
        }


        private void UpdateElapsedTime(EnemyDifficulty difficulty, float spawnTime)
        {

            _elapsedTime[difficulty] += Time.fixedDeltaTime;


            if (_elapsedTime[difficulty] > spawnTime)
            {

                _elapsedTime[difficulty] = 0f;

                Spawn(difficulty);
            }
        }

        #endregion


        private void Spawn(EnemyDifficulty difficulty)
        {

            bool hasObject = _pool.TryGetEnemy(difficulty, out Enemy enemy) ||

                _pool.TryGetObject(out enemy);


            if (hasObject && _positionPool.TryGetObject
                (out Vector3 position))
            {

                _spawnedCount++;


                enemy.gameObject.SetActive(true);

                enemy.transform.position = position;


                Added?.Invoke(enemy);
            }
        }
    }
}
