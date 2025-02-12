using UnityEngine;

namespace Combat
{
    public sealed class EnemyHealthView : MonoBehaviour, IHealthView
    {

        public void OnHealthChanged(int health)
        {
            
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
