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
        private Character _player;

        [SerializeField, Space]
        private bool _isInputRaw;

        private PlayerSystem _playerSystem;
        
        #endregion



        private void Awake()
        {

            _playerSystem = new PlayerSystem(_player);
        }


        private void OnEnable()
        {

            _playerSystem.SetSystem();
        }


        private void OnDisable()
        {

            _playerSystem.UnsetSystem();
        }


        private void FixedUpdate()
        {

            _playerSystem.HandleInput(_isInputRaw);
        }
    }
}
