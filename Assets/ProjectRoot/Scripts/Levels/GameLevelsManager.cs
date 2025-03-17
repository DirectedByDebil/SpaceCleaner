using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

namespace Levels
{
    public sealed class GameLevelsManager : MonoBehaviour
    {

        [SerializeField, TextArea(1, 2), Space]
        private List<string> _levels = new();


        private void Awake()
        {
            
            GameLevels.SetLevels(_levels);
        }


        private void Start()
        {

            SceneManager.LoadSceneAsync(_levels[0]);
        }
    }
}
