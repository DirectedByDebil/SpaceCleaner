using Characters;
using Combat;
using Combat.Guns;
using Effects;
using Levels;
using Movement;
using Pickables;
using Pickables.Bonuses;
using UnityEngine;

namespace Core
{

    public sealed class EntryPoint : MonoBehaviour
    {

        #region Player

        [SerializeField, HideInInspector, Space]
        private Player _player;

        [SerializeField, HideInInspector, Space]
        private bool _isInputRaw;


        private PlayerSystem _playerSystem;

        #endregion


        #region Enemies
        
        private EnemySystem _enemySystem;


        [SerializeField, HideInInspector, Space]
        private EnemiesPool _enemies;


        [SerializeField, HideInInspector, Range(0, 1),
            Header("Send player position to enemies interval"), Space]
        private float _checkPositionTime;


        [SerializeField, HideInInspector, Space]
        private TrapHandler _traps;

        #endregion


        #region Enemies Spawn

        [SerializeField, HideInInspector, Space]
        private SpawnSettings _spawnSettings;


        [SerializeField, HideInInspector, Space]
        private PositionPool _spawnPositionPool;
        #endregion


        #region Shooting System

        private ShootingSystem _shootingSystem;


        [SerializeField, HideInInspector, Space]
        private Gun _gun;

        #endregion


        #region Bullets System

        [SerializeField, HideInInspector, Space]
        private BulletPool _bulletPool;


        [SerializeField, HideInInspector, Space]
        private MovementStats _bulletMovementStats;


        [SerializeField, HideInInspector, Range(1, 3), Space]
        private float _bulletLifeTime;


        private BulletsSystem _bulletsSystem;

        #endregion


        #region Game Logic

        private GameProgress _gameProgress;

        private GameAnalytics _gameAnalytics;


        [SerializeField, HideInInspector, Space]
        private GameAnalyticsCosts _gameAnalyticsCosts;


        private bool _isGameRunning;

        #endregion


        #region Game Levels

        [SerializeField, HideInInspector, Space]
        private LevelFinish _levelFinish;

        #endregion


        #region Pickables

        [SerializeField, HideInInspector, Space]
        private PickableHandler _pickables;

        private BonusSystem _bonusSystem;

        #endregion


        #region Effects

        private CameraEffects _cameraEffects;

        [SerializeField, HideInInspector, Range(0, 1f), Space]
        private float _cameraSmoothTime;

        #endregion



        private void Awake()
        {

            _playerSystem = new PlayerSystem(_player);


            _shootingSystem = new ShootingSystem(_bulletPool);

            _shootingSystem.AddGun(_gun);


            _bulletsSystem = new BulletsSystem(_bulletMovementStats);

            _enemySystem = new EnemySystem(_enemies, _spawnPositionPool);


            _cameraEffects = new CameraEffects(Camera.main);


            _gameProgress = new GameProgress(_enemySystem, _levelFinish);

            _gameAnalytics = new GameAnalytics(_gameAnalyticsCosts);


            _bonusSystem = new BonusSystem();


            _isGameRunning = true;
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

            _gameProgress.SetTraps(_traps.Traps);

            _gameProgress.SetPickables(_pickables.Pickables);

            _gameProgress.SetLevelFinish(_levelFinish);

            _gameProgress.SetSystem();


            _gameProgress.EnemyEnded += _gameAnalytics.OnEnemyEnded;

            _gameProgress.PickingGarbage += _gameAnalytics.OnPickingGarbage;

            _gameProgress.PickingBonus += _bonusSystem.OnPickingBonus;

            _gameProgress.GameOver += OnGameOver;


            _gameAnalytics.GoalAchieved += _gameProgress.OnGoalAchieved;


            _bonusSystem.PickingHealth += _gameProgress.OnPickingHealth;

            _bonusSystem.PickingShield += _gameProgress.OnPickingShield;
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

            _gameProgress.UnsetTraps(_traps.Traps);

            _gameProgress.UnsetPickables(_pickables.Pickables);

            _gameProgress.UnsetLevelFinish(_levelFinish);

            _gameProgress.UnsetSystem();


            _gameProgress.EnemyEnded -= _gameAnalytics.OnEnemyEnded;

            _gameProgress.PickingGarbage -= _gameAnalytics.OnPickingGarbage;

            _gameProgress.PickingBonus -= _bonusSystem.OnPickingBonus;

            _gameProgress.GameOver -= OnGameOver;


            _gameAnalytics.GoalAchieved -= _gameProgress.OnGoalAchieved;


            _bonusSystem.PickingHealth -= _gameProgress.OnPickingHealth;

            _bonusSystem.PickingShield -= _gameProgress.OnPickingShield;
        }


        private void FixedUpdate()
        {

            if (!_isGameRunning) return;

            _playerSystem.HandleInput(_isInputRaw);


            _enemySystem.HandleMovement(_player.transform.position,
                _checkPositionTime);

            _enemySystem.HandleSpawn(_spawnSettings);


            _shootingSystem.HandleInput();


            _bulletsSystem.HandleInput(_bulletLifeTime);


            _cameraEffects.Follow(_player.transform.position,
                _cameraSmoothTime);
        }


        private void OnGameOver()
        {

            _isGameRunning = false;
        }
    }
}
