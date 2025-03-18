using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;

namespace Levels
{
    public sealed class GameLevelsManager : MonoBehaviour
    {

        [SerializeField, TextArea(1, 2), Space]
        private List<string> _levels = new();

        [SerializeField, Space]
        private TextMeshProUGUI _textHandler;


        private void Awake()
        {
            /*
                foreach(string level in _levels)
                {

                    _textHandler.text += level + "\n";
                }
            */

            _levels = new List<string>()
            {

                "MainMenu",
                "CleaningLevel",
                "CleaningArena"
            };

            GameLevels.SetLevels(_levels);

            SceneManager.LoadSceneAsync(_levels[0]);
        }
    }
}
