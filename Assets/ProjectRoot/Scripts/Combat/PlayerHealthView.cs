using Core;
using UnityEngine;

namespace Combat
{
    public class PlayerHealthView : MonoBehaviour, IHealthView
    {

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

        }


        public void OnShieldRestored()
        {

        }
    }
}
