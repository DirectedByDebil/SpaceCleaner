using UnityEngine;

namespace Levels
{
    public class LevelFinishView : MonoBehaviour
    {

        [SerializeField, Space]
        private Light _light;


        [SerializeField, Space]
        private Color _lockedColor;

        [SerializeField, Space]
        private Color _unlockedColor;


        public void OnLocked()
        {

            _light.color = _lockedColor;
        }


        public void OnUnlocked()
        {

            _light.color = _unlockedColor;
        }
    }
}
