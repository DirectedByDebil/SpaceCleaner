using Characters;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthUIHandler : MonoBehaviour
{
    Player player;

    VisualElement hpBar;
    float hpBarWidthCoef;

    void OnEnable()
    {
        //Получаем ссылку на компонент UIDocument
        var uiDocument = GetComponent<UIDocument>();
        //Находим кнопку таким запросом, в параметр передаем имя кнопки
        hpBar = uiDocument.rootVisualElement.Q<VisualElement>("hpBar");
        hpBarWidthCoef = hpBar.style.width.value.value / player.HealthStats.MaxHp;

        //Регистрируем событие нажатия кнопки
        okButton.RegisterCallback<ClickEvent>(ClickMessage);
    }

    void OnHpChanged(int newHp)
    {
        hpBar.style.width = new StyleLength(newHp * hpBarWidthCoef); 
    }
}
