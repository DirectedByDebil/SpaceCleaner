using UnityEngine;
using UnityEngine.UIElements;

namespace Views
{
    public sealed class GameAnalyticsView : MonoBehaviour
    {

        [SerializeField] private UIDocument _document;


        private Label _enemyLabel;

        private Label _garbageLabel;



        private void OnEnable()
        {

            _enemyLabel = _document.GetLabel("enemyCounter");

            _garbageLabel = _document.GetLabel("garbageCounter");
        }



        public void OnEnemyPointsChanged(int points, int goal)
        {

            UpdateText(_enemyLabel, points, goal);


            CheckWin(_enemyLabel, points >= goal);
        }



        public void OnGarbagePointsChanged(int points, int goal)
        {

            UpdateText(_garbageLabel, points, goal);


            CheckWin(_garbageLabel, points >= goal);
        }


        private void UpdateText(Label label, int points , int goal)
        {

            label.text = points + "/" + goal;
        }


        private void CheckWin(Label label, bool isWin)
        {

            if (isWin)
            {

                label.style.color = Color.green;
            }
        }

    }
}
