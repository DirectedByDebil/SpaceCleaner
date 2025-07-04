using UnityEngine;
using UnityEngine.SceneManagement;

namespace Views
{

    public class MainMenu : MonoBehaviour
    {

        public void LoadLevel(string sceneName)
        {

            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
