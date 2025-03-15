using UnityEngine.UIElements;

namespace Views
{
    public static class UIExtensions
    {

        public static Label GetLabel(this UIDocument document, string name)
        {

            return document.rootVisualElement.Q<Label>(name);
        }
    }
}
