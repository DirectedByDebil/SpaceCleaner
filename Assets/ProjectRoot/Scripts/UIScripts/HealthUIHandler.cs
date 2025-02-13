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
        //�������� ������ �� ��������� UIDocument
        var uiDocument = GetComponent<UIDocument>();
        //������� ������ ����� ��������, � �������� �������� ��� ������
        hpBar = uiDocument.rootVisualElement.Q<VisualElement>("hpBar");
        hpBarWidthCoef = hpBar.style.width.value.value / player.HealthStats.MaxHp;

        //������������ ������� ������� ������
        okButton.RegisterCallback<ClickEvent>(ClickMessage);
    }

    void OnHpChanged(int newHp)
    {
        hpBar.style.width = new StyleLength(newHp * hpBarWidthCoef); 
    }
}
