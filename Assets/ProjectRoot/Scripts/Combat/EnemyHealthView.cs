using Core;
using UnityEngine;

namespace Combat
{
    public sealed class EnemyHealthView : MonoBehaviour, IHealthView
    {

        [SerializeField, Space]
        private GameObject _shield;


        public void OnHealthChanged(int health)
        {

            //GUIOutput.AddOutput(gameObject.name, health);
        }


        public void OnHealthEnded()
        {

            gameObject.SetActive(false);
        }


        public void OnShieldEnded()
        {

            SetShield(false);
        }


        public void OnShieldRestored()
        {

            SetShield(true);
        }


        private void SetShield(bool isActive)
        {

            if (_shield)
            {

                _shield.SetActive(isActive);
            }
        }
    }
}
