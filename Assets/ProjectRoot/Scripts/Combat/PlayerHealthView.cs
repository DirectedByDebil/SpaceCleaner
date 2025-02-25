using Characters;
using Core;
using UnityEngine;

namespace Combat
{
    public class PlayerHealthView : MonoBehaviour, IPlayerUI
    {

        [SerializeField, Space]
        private GameObject _shield;


        public void OnHealthChanged(int health)
        {

            GUIOutput.AddOutput("HP", health);
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
     

        public void OnShieldWorking(float percent)
        {

            GUIOutput.AddOutput("Shield", $"{100 - percent*100} %");
        }
    }
}
