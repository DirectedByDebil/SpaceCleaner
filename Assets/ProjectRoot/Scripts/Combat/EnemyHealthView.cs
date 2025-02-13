using Core;
using UnityEngine;

namespace Combat
{
    public sealed class EnemyHealthView : MonoBehaviour, IHealthView
    {

        public void OnHealthChanged(int health)
        {

            GUIOutput.AddOutput(gameObject.name, health);
        }


        public void OnHealthEnded()
        {

            gameObject.SetActive(false);
        }


        public void OnShieldEnded()
        {

        }
    }
}
