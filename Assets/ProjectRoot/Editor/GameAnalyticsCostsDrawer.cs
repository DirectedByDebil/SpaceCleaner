using UnityEditor;

namespace Core
{
    public sealed class GameAnalyticsCostsDrawer
    {

        private SerializedProperty _costs;


        public void DrawCosts(SerializedProperty costs)
        {

            _costs = costs;


            DrawGarbagePoints();

            DrawEnemyPoints();

            DrawPointsToWin();
        }


        private void DrawGarbagePoints()
        {

            EditorGUILayout.Space(10);

            EditorGUILayout.LabelField("Garbage Points");

            EditorGUI.indentLevel++;


            SerializedProperty garbagePoints = _costs.FindPropertyRelative("GarbagePoints");

            int maxValue = 20;


            DrawSlider(garbagePoints, "Small", maxValue);

            DrawSlider(garbagePoints, "Medium", maxValue);
            
            DrawSlider(garbagePoints, "Big", maxValue);


            EditorGUI.indentLevel--;
        }


        private void DrawEnemyPoints()
        {

            EditorGUILayout.Space(10);


            EditorGUILayout.LabelField("Enemy Points");

            EditorGUI.indentLevel++;


            SerializedProperty garbagePoints = _costs.FindPropertyRelative("EnemyPoints");

            int maxValue = 100;


            DrawSlider(garbagePoints, "Standart", maxValue);

            DrawSlider(garbagePoints, "Heavy", maxValue);

            DrawSlider(garbagePoints, "Boss", maxValue);


            EditorGUI.indentLevel--;

        }


        private void DrawPointsToWin()
        {

            EditorGUILayout.Space(20);

            DrawSlider(_costs, "GarbagePointsToWin", 500);
            
            DrawSlider(_costs, "EnemyPointsToWin", 500);
        }


        private void DrawSlider(SerializedProperty parent, string propertyName,
            int maxValue)
        {

            SerializedProperty child = parent.FindPropertyRelative(propertyName);

            EditorGUILayout.IntSlider(child, 0, maxValue, propertyName);
        }
    }
}
