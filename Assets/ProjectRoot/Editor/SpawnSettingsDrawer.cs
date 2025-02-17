using UnityEditor;

namespace Core
{
    public sealed class SpawnSettingsDrawer
    {

        private SerializedProperty _spawnSettings;


        public void DrawSpawnSettings(SerializedProperty spawnSettings)
        {

            _spawnSettings = spawnSettings;


            DrawMinMaxSlider();
            

            EditorGUILayout.Space(10);


            DrawSpawnIntervals();
        }


        private void DrawMinMaxSlider()
        {

            SerializedProperty minEnemies = _spawnSettings.FindPropertyRelative("MinEnemies");

            SerializedProperty maxEnemies = _spawnSettings.FindPropertyRelative("MaxEnemies");


            float min = minEnemies.intValue;
            
            float max = maxEnemies.intValue;


            EditorGUILayout.LabelField
                ("Min Enemies: " + min, "Max Enemies: " + max);


            EditorGUILayout.MinMaxSlider(ref min, ref max, 0, 30);


            minEnemies.intValue = (int)min;
            
            maxEnemies.intValue = (int)max;
        }


        private void DrawSpawnIntervals()
        {

            EditorGUILayout.LabelField("Spawn Intervals");

            EditorGUILayout.Space(10);


            EditorGUI.indentLevel++;


            DrawSlider("Standart");
            
            DrawSlider("Heavy");
            
            DrawSlider("Boss");


            EditorGUI.indentLevel--;
        }


        private void DrawSlider(string propertyName)
        {

            SerializedProperty property = _spawnSettings.FindPropertyRelative(propertyName);

            EditorGUILayout.LabelField(propertyName);

            property.floatValue = EditorGUILayout.Slider(property.floatValue, 0f, 60f);
        }
    }
}
