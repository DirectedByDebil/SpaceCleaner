using Core;
using Movement;
using UnityEngine;
using System;

namespace Characters
{
    public sealed class EnemySystem
    {

        public event Action<IEnemy> EnemyAdded;


        private readonly EnemyMovementSystem _enemyMovement;

        private readonly EnemySpawnSystem _enemySpawn;


        public EnemySystem(IEnemyPool enemyPool, IPool<Vector3> positionPool)
        {

            _enemyMovement = new EnemyMovementSystem(enemyPool.AllEnemies);

            _enemySpawn = new EnemySpawnSystem(enemyPool, positionPool);
        }


        #region Add/Remove Enemy

        public void AddEnemy(IEnemy enemy)
        {

            _enemyMovement.AddEnemy(enemy);

            _enemySpawn.AddEnemy();
        }


        public void RemoveEnemy(IEnemy enemy)
        {


            _enemyMovement.RemoveEnemy(enemy);

            _enemySpawn.RemoveEnemy();
        }

        #endregion


        #region Set/Unset System

        public void SetSystem()
        {

            _enemySpawn.Added += OnEnemySpawned;
        }


        public void UnsetSystem()
        {

            _enemySpawn.Added -= OnEnemySpawned;
        }

        #endregion


        public void HandleMovement(Vector3 destination, float time)
        {

            _enemyMovement.HandleInput(destination, time);
        }


        public void HandleSpawn(SpawnSettings settings)
        {

            _enemySpawn.HandleSpawn(settings);
        }


        private void OnEnemySpawned(IEnemy enemy)
        {

            _enemyMovement.AddEnemy(enemy);

            EnemyAdded?.Invoke(enemy);
        }
    }
}
