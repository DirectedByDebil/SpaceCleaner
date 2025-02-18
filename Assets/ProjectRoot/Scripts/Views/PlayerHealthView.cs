using Characters;
using UnityEngine;
using UnityEngine.UIElements;

namespace Combat
{
    public class PlayerHealthView : MonoBehaviour, IHealthView
    {
        public UIDocument uiDocument;

        private Player _player;
        private VisualElement _hpBar;
        private float _hpBarWidthCoef = 0;

        private Label _hpBarNumberLabel;

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


        public void OnShieldEnded()
        {

        }

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
