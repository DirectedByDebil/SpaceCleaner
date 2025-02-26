using Characters;
using Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Combat.Views
{
    public class PlayerUI : MonoBehaviour, IPlayerUI
    {
        public UIDocument uiDocument;

        private Player _player;
        private VisualElement _hpBar;
        private float _hpBarWidthCoef = 0;

        private Label _hpBarNumberLabel;

        [SerializeField, Space]
        private GameObject _shield;


        void OnEnable()
        {
            _player = GetComponent<Player>();

            _hpBar = uiDocument.rootVisualElement.Q<VisualElement>("hpBar");
            // Register a callback for the GeometryChangedEvent
            _hpBar.RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);

            _hpBarNumberLabel = uiDocument.rootVisualElement.Q<Label>("hpText");
            _hpBarNumberLabel.text = _player.HealthStats.MaxHp.ToString();
        }


        public void OnHealthChanged(int health)
        {
            _hpBarNumberLabel.text = health.ToString();
            _hpBar.style.width = new StyleLength(health * _hpBarWidthCoef);
        }


        public void OnHealthEnded()
        {
            gameObject.SetActive(false);
        }


        #region Shield Events Handlers

        public void OnShieldEnded()
        {

            SetShield(false);
        }


        public void OnShieldRestored()
        {

            SetShield(true);
        }


        public void OnShieldWorking(float percent)
        {

            GUIOutput.AddOutput("Shield", $"{100 - percent * 100} %");
        }


        private void SetShield(bool isActive)
        {

            if (_shield)
            {

                _shield.SetActive(isActive);
            }
        }

        #endregion
        

        // Callback for the GeometryChangedEvent
        public void OnGeometryChanged(GeometryChangedEvent evt)
        {
            if (_hpBarWidthCoef > 0)
            {
                return;
            }
            // Get the VisualElement that triggered the event
            VisualElement element = evt.target as VisualElement;

            // Get the resolved style of the VisualElement
            _hpBarWidthCoef = element.resolvedStyle.width / _player.HealthStats.MaxHp;
        }
    }
}
