using UnityEngine.UIElements;

namespace Views
{
    public static class UIExtensions
    {

        #region Get Objects

        public static Label GetLabel(this UIDocument document, string name)
        {

            return document.rootVisualElement.Q<Label>(name);
        }


        public static Button GetButton(this UIDocument document, string name)
        {

            return document.rootVisualElement.Q<Button>(name);
        }

        #endregion


        #region Show/Hide
        
        public static void Show(this UIDocument document)
        {

            document.rootVisualElement.style.display = DisplayStyle.Flex;
        }


        public static void Hide(this UIDocument document)
        {

            document.rootVisualElement.style.display = DisplayStyle.None;
        }

        #endregion
    }
}
