using UnityEngine;
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
    }
}
