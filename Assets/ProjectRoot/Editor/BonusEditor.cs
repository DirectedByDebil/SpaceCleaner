using UnityEditor;
using UnityEngine;

namespace Pickables.Bonuses
{

    [CustomEditor(typeof(Bonus))]
    public sealed class BonusEditor : Editor
    {

        private SerializedProperty _bonusType;
        
        private SerializedProperty _duration;

        private SerializedProperty _increaseValue;


        public override void OnInspectorGUI ()
        {

            base.OnInspectorGUI();


            EditorGUI.BeginChangeCheck();

            serializedObject.Update();


            DrawInspector();


            if(EditorGUI.EndChangeCheck())
            {

                serializedObject.ApplyModifiedProperties();
            }
        }


        private void OnEnable()
        {

            _bonusType = serializedObject.FindProperty("_bonusType");
            
            _duration = serializedObject.FindProperty("_duration");

            _increaseValue = serializedObject.FindProperty("_increaseValue");   
        }



        private void DrawInspector()
        {

            int index = _bonusType.enumValueFlag;


            DrawSelectedBonus((BonusType)index);
        }


        private void DrawSelectedBonus(BonusType bonusType)
        {

            switch (bonusType)
            {

                case BonusType.Heal:

                    DrawProperties(_increaseValue);
                    break;
            

                case BonusType.Shield:

                    DrawProperties(_duration);
                    break;
            }
        }


        private void DrawProperties(params SerializedProperty[] properties)
        {

            EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));

            foreach (SerializedProperty property in properties)
            {

                EditorGUILayout.PropertyField(property, true);
            }

            EditorGUILayout.EndVertical();
        }
    }
}
