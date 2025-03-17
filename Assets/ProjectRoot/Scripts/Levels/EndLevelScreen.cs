using UnityEngine;
using UnityEngine.UIElements;
using Views;

namespace Levels
{
    public sealed class EndLevelScreen : MonoBehaviour
    {

        [SerializeField, Space]
        private UIDocument _winDocument;


        [SerializeField, Space]
        private UIDocument _loseDocument;


        private Button _winRestart;

        private Button _winContinue;
        
        private Button _loseRestart;


        private void OnEnable()
        {

            _winRestart = _winDocument.GetButton("restartButton");
            
            _winContinue = _winDocument.GetButton("continueButton");
            
            
            _loseRestart = _loseDocument.GetButton("restartButton");


            _winContinue.clicked += OnContinue;

            _winRestart.clicked += OnRestart;

            _loseRestart.clicked += OnRestart;
        }


        private void OnDisable()
        {

            _winContinue.clicked -= OnContinue;

            _winRestart.clicked -= OnRestart;

            _loseRestart.clicked -= OnRestart;
        }


        public void Hide()
        {

            _winDocument.Hide();

            _loseDocument.Hide();
        }


        public void OnLost()
        {

            _loseDocument.Show();
        }


        public void OnWon()
        {

            _winDocument.Show();
        }


        private void OnRestart()
        {

            //#TODO maybe better separate this
            
            GameLevels.RestartCurrentLevel();
        }


        private void OnContinue()
        {

            GameLevels.LoadNextLevel();
        }
    }
}
