using Characters;
using Movement;
using Combat;
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
        private EnemiesHandler _enemies;

        private EnemiesSystem _enemiesSystem;


        [SerializeField, Range(0, 1),
            Header("Send player position to enemies interval"), Space]
        private float _checkPositionTime;
        
        #endregion


        private void Awake()
        {

            _playerSystem = new PlayerSystem(_player);

            _enemiesSystem = new EnemiesSystem(
                _enemies.AllEnemies, _enemies.ActiveEnemies);
        }


        private void OnEnable()
        {

            _playerSystem.SetSystem();

            _enemiesSystem.SetSystem();
        }


        private void OnDisable()
        {

            _playerSystem.UnsetSystem();

            _enemiesSystem.UnsetSystem();
        }


        private void FixedUpdate()
        {
            
            _playerSystem.HandleInput(_isInputRaw);

            _enemiesSystem.HandleInput(_player.transform.position,
                _checkPositionTime);
        }
    }
}
