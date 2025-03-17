using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Levels
{
    public static class GameLevels
    {

        private static List<string> _scenes;


        public static void SetLevels(IEnumerable<string> scenes)
        {

            _scenes = new List<string>(scenes);
        }


        public static void LoadNextLevel()
        {

            if(TryGetNextScene(out string sceneName))
            {

                SceneManager.LoadSceneAsync(sceneName);
            }
            else
            {
                Debug.LogError("Current Scene not in scenes list");
            }
        }


        public static void RestartCurrentLevel()
        {

            Scene current = SceneManager.GetActiveScene();

            SceneManager.LoadScene(current.name);
        }


        private static bool TryGetNextScene(out string sceneName)
        {

            Scene currentScene = SceneManager.GetActiveScene();

            int index = _scenes.FindIndex((scene) => scene == currentScene.name);


            if (index != -1)
            {

                sceneName = GetNextScene(index);

                return true;
            }


            sceneName = null;

            return false;
        }


        private static string GetNextScene(int currentIndex)
        {

            int nextIndex = currentIndex + 1;

            if(nextIndex >= _scenes.Count)
            {

                nextIndex = 0;
            }


            return _scenes[nextIndex];
        }
    }
}
