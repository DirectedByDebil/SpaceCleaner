using UnityEngine;
using UnityEngine.UIElements;

namespace Views
{
    public class EndLevelView : MonoBehaviour
    {
        public UIDocument uiDocument;

        private Button _restartButton;
        private Button _continueButton;
        private Label _endLevelTitle;

        void OnEnable()
        {
            _restartButton = uiDocument.rootVisualElement.Q<Button>("restartButton");
            _continueButton = uiDocument.rootVisualElement.Q<Button>("continueButton");
            _endLevelTitle = uiDocument.rootVisualElement.Q<Label>("endLevelTitle");

            _restartButton.RegisterCallback<ClickEvent>(OnRestartButtonClicked);
            _continueButton.RegisterCallback<ClickEvent>(OnContinueButtonClicked);
        }

        public void DisplayLevelFailed()
        {
            _continueButton.SetEnabled(false);

            _endLevelTitle.text = "Поражение";
        }

        private void OnContinueButtonClicked(ClickEvent e)
        {
            if(!(_continueButton?.enabledSelf ?? false))
            {
                return;
            }
        }

        private void OnRestartButtonClicked(ClickEvent e)
        {
            if (!(_restartButton?.enabledSelf ?? false))
            {
                return;
            }
        }
    }
}
