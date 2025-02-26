using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Levels
{
    public static class GameLevels
    {

        private static List<string> _scenes;


        private static string _nextLevel;


        public static void SetLevels(IEnumerable<string> scenes)
        {

            _scenes = new List<string>(scenes);
        }


        public static void SetCurrentLevel()
        {

            Scene currentScene = SceneManager.GetActiveScene();

            int index = _scenes.FindIndex((scene) => scene == currentScene.name);


            if(index != -1)
            {

                SetNextLevel(index);
            }
            else
            {
                Debug.LogError("Current Scene not in build");
            }
        }


        public static void LoadNextLevel()
        {

            SceneManager.LoadSceneAsync(_nextLevel);
        }


        private static void SetNextLevel(int currentIndex)
        {

            int nextIndex = currentIndex + 1;

            if(nextIndex >= _scenes.Count)
            {

                nextIndex = 0;
            }


            _nextLevel = _scenes[nextIndex];
        }
    }
}
