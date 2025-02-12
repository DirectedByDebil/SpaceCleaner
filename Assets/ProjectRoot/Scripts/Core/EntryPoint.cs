using Characters;
using Combat.Guns;
using Movement;
using UnityEngine;

namespace Core
{

    public sealed class EntryPoint : MonoBehaviour
    {

        #region Player

        [SerializeField, Space]
        private Player _player;

        [SerializeField, Space]
        private bool _isInputRaw;

        private PlayerSystem _playerSystem;

        #endregion


        #region Enemies

        [SerializeField, Space]
        private EnemiesPool _enemies;

        private EnemiesSystem _enemiesSystem;


        [SerializeField, Range(0, 1),
            Header("Send player position to enemies interval"), Space]
        private float _checkPositionTime;

        #endregion


        #region Shooting System

        private ShootingSystem _shootingSystem;


        [SerializeField, Space]
        private Gun _gun;

        #endregion


        #region Bullets System

        [SerializeField, Space]
        private BulletPool _bulletPool;


        [SerializeField, Space]
        private MovementStats _bulletMovementStats;


        [SerializeField, Range(1, 3), Space]
        private float _bulletLifeTime;


        private BulletsSystem _bulletsSystem;

        #endregion


        #region Game Logic

        private GameProgress _gameProgress;

        #endregion


        private void Awake()
        {

            _playerSystem = new PlayerSystem(_player);


            _shootingSystem = new ShootingSystem(_bulletPool);

            _shootingSystem.AddGun(_gun);


            _bulletsSystem = new BulletsSystem(_bulletMovementStats);

            _enemiesSystem = new EnemiesSystem(_enemies.AllEnemies);


            _gameProgress = new GameProgress(_enemiesSystem);
        }


        private void OnEnable()
        {

            _playerSystem.SetSystem();

            _shootingSystem.SetSystem();


            _shootingSystem.ShootingBullet += _bulletsSystem.OnShootingBullet;


            _bulletsSystem.SetSystem(_bulletPool.Bullets);


            _gameProgress.SetPlayer(_player);

            _gameProgress.SetEnemies(_enemies.AllEnemies);

            _gameProgress.SetDamagers(_bulletPool.Bullets);

            _gameProgress.SetSystem();
        }


        private void OnDisable()
        {

            _playerSystem.UnsetSystem();

            _shootingSystem.UnsetSystem();


            _shootingSystem.ShootingBullet -= _bulletsSystem.OnShootingBullet;


            _bulletsSystem.UnsetSystem(_bulletPool.Bullets);
            

            _gameProgress.UnsetPlayer(_player);

            _gameProgress.UnsetEnemies(_enemies.AllEnemies);

            _gameProgress.UnsetDamagers(_bulletPool.Bullets);

            _gameProgress.UnsetSystem();
        }


        private void FixedUpdate()
        {
            
            _playerSystem.HandleInput(_isInputRaw);

            _enemiesSystem.HandleInput(_player.transform.position,
                _checkPositionTime);


            _shootingSystem.HandleInput();


            _bulletsSystem.HandleInput(_bulletLifeTime);
        }
    }
}
