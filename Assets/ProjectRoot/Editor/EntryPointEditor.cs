using UnityEngine;
using UnityEditor;

namespace Core
{

    [CustomEditor(typeof(EntryPoint))]
    public sealed class EntryPointEditor : Editor
    {

        private DisplayCategory _selectedCategory;


        #region Player

        private SerializedProperty _player;

        private SerializedProperty _isInputRaw;
        
        private SerializedProperty _gun;

        #endregion


        #region Bullets

        private SerializedProperty _bulletPool;

        private SerializedProperty _bulletMovementStats;
        
        private SerializedProperty _bulletLifeTime;

        #endregion


        #region Enemies

        private SerializedProperty _enemies;

        private SerializedProperty _checkPositionTime;

        private SerializedProperty _traps;

        #endregion


        #region Enemies Spawn
        
        private SerializedProperty _spawnSettings;
        
        private SerializedProperty _spawnPositionPool;
        
        private SpawnSettingsDrawer _spawnSettingsDrawer = new ();

        #endregion


        #region Camera

        private SerializedProperty _cameraSmoothTime;

        #endregion


        #region Game Analytics

        private SerializedProperty _gameAnalyticsCosts;

        private SerializedProperty _pickables;

        private GameAnalyticsCostsDrawer _costsDrawer = new();

        #endregion


        #region Levels

        private SerializedProperty _levelFinish;

        #endregion



        public override void OnInspectorGUI()
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

            _player = serializedObject.FindProperty("_player");

            _isInputRaw = serializedObject.FindProperty("_isInputRaw");

            _gun = serializedObject.FindProperty("_gun");


            _bulletPool = serializedObject.FindProperty("_bulletPool");

            _bulletMovementStats = serializedObject.FindProperty("_bulletMovementStats");
            
            _bulletLifeTime = serializedObject.FindProperty("_bulletLifeTime");


            _enemies = serializedObject.FindProperty("_enemies");

            _checkPositionTime = serializedObject.FindProperty("_checkPositionTime");
            
            _traps = serializedObject.FindProperty("_traps");


            _spawnSettings = serializedObject.FindProperty("_spawnSettings");

            _spawnPositionPool = serializedObject.FindProperty("_spawnPositionPool");


            _cameraSmoothTime = serializedObject.FindProperty("_cameraSmoothTime");


            _gameAnalyticsCosts = serializedObject.FindProperty("_gameAnalyticsCosts");

            _pickables = serializedObject.FindProperty("_pickables");


            _levelFinish = serializedObject.FindProperty("_levelFinish");
        }


        private void DrawInspector()
        {

            EditorGUILayout.Space();


            _selectedCategory = (DisplayCategory)
                EditorGUILayout.EnumPopup(_selectedCategory);


            EditorGUILayout.Space();


            DrawSelectedCategory();
        }


        private void DrawSelectedCategory()
        {

            switch (_selectedCategory)
            {

                case DisplayCategory.Player:

                    DrawProperties(_player, _isInputRaw, _gun);
                    break;


                case DisplayCategory.Bullets:

                    DrawProperties(_bulletPool, _bulletMovementStats, _bulletLifeTime);
                    break;


                case DisplayCategory.Enemies:

                    DrawProperties( _enemies, _checkPositionTime, _traps);
                    
                    break;


                case DisplayCategory.SpawnSettings:

                    _spawnSettingsDrawer.DrawSpawnSettings(_spawnSettings);

                    DrawProperties(_spawnPositionPool);

                    break;


                case DisplayCategory.Camera:

                    DrawProperties(_cameraSmoothTime);
                    break;


                case DisplayCategory.Pickables:

                    DrawProperties(_pickables);
                    break;


                case DisplayCategory.GameAnalytics:
                    
                    _costsDrawer.DrawCosts(_gameAnalyticsCosts);
                    break;


                case DisplayCategory.Levels:

                    DrawProperties(_levelFinish);
                    break;
            }
        }


        private void DrawProperties(params SerializedProperty[] properties)
        {

            EditorGUILayout.BeginVertical(GUILayout.ExpandHeight(true));

            foreach(SerializedProperty property in properties)
            {

                EditorGUILayout.PropertyField(property, true);
            }
            
            EditorGUILayout.EndVertical();
        }
    }
}