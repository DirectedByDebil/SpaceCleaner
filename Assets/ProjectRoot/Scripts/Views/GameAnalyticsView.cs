using UnityEngine;
using UnityEngine.UIElements;

namespace Views
{
    public sealed class GameAnalyticsView : MonoBehaviour, IScreen
    {

        [SerializeField] private UIDocument _document;


        private Label _enemyLabel;

        private Label _garbageLabel;



        private void OnEnable()
        {

            _enemyLabel = _document.GetLabel("enemyCounter");

            _garbageLabel = _document.GetLabel("garbageCounter");
        }


        #region On Points Changed

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

        #endregion



        #region Show/Hide

        public void Show()
        {

            _document.Show();
        }


        public void Hide()
        {

            _document.Hide();
        }

        #endregion


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
