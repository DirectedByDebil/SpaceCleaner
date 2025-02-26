using UnityEngine;
using UnityEngine.UIElements;

namespace Combat
{
    public class EndLevelView : MonoBehaviour
    {
        public UIDocument uiDocument;

        private VisualElement _topBar;
        private VisualElement _endLevelScreen;
        private Button _restartButton;
        private Button _continueButton;
        private Label _endLevelTitle;

        void OnEnable()
        {
            _topBar = uiDocument.rootVisualElement.Q<VisualElement>("topBar");
            _endLevelScreen = uiDocument.rootVisualElement.Q<VisualElement>("endLevelScreen");
            _restartButton = uiDocument.rootVisualElement.Q<Button>("restartButton");
            _continueButton = uiDocument.rootVisualElement.Q<Button>("continueButton");
            _endLevelTitle = uiDocument.rootVisualElement.Q<Label>("endLevelTitle");

            _restartButton.RegisterCallback<ClickEvent>(OnRestartButtonClicked);
            _continueButton.RegisterCallback<ClickEvent>(OnContinueButtonClicked);
        }

        public void DisplayLevelFailed()
        {
            DisplayEndLevel();

            _continueButton.SetEnabled(false);

            _endLevelTitle.text = "Поражение";
        }

        public void DisplayLevelCompleted()
        {
            DisplayEndLevel();
        }

        private void DisplayEndLevel()
        {
            _topBar.style.visibility = Visibility.Hidden;
            _endLevelScreen.style.visibility = Visibility.Visible;
        }

        private void OnContinueButtonClicked(ClickEvent e)
        {
            if(!_continueButton.enabledSelf)
            {
                return;
            }
        }

        private void OnRestartButtonClicked(ClickEvent e)
        {
            if (!_restartButton.enabledSelf)
            {
                return;
            }
        }
    }
}
