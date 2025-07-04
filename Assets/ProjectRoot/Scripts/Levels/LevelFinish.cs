using UnityEngine;
using System;

namespace Levels
{
    public sealed class LevelFinish : MonoBehaviour, ILevelFinish
    {

        public event Action Finishing;


        [SerializeField, Space]
        private LevelFinishView _view;


        [SerializeField, Space]
        private bool _isLocked;


        private void OnValidate()
        {

            if(_isLocked)
            {

                _view.OnLocked();
            }
            else
            {

                _view.OnUnlocked();
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            
            if(!_isLocked && other.CompareTag("Player"))
            {

                Finishing?.Invoke();
            }
        }


        public void Lock()
        {

            _isLocked = true;

            _view.OnLocked();
        }


        public void Unlock()
        {

            _isLocked = false;

            _view.OnUnlocked();
        }
    }
}
