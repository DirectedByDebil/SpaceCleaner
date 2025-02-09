using UnityEngine;
using System.Collections.Generic;

namespace Core
{
    public sealed class GUIOutput : MonoBehaviour
    {

        private static Dictionary<string, object> _outputs = new();

        private static Vector3 _position;


        private static Rect _rect;


        private readonly Vector2 Position = new (20, 20);


        private void Awake()
        {

            _outputs.Clear();


            Vector2 size = new(200, 20);

            _rect = new (Position, size);
        }


        private void OnGUI()
        {

            if(_outputs.Count > 0)
            {

                DrawDictionary();
            }
        }


        private void OnDrawGizmos()
        {

            Gizmos.DrawWireSphere(_position, 1);
        }


        public static void AddOutput(string name, object value)
        {

            if (_outputs.TryAdd(name, value))
            {

                _rect.height += 20;
            }
            else
            {

                _outputs[name] = value;
            }
        }


        public static void DrawPoint(Vector3 position)
        {

            if(position != _position)
            {

                _position = position;
            }
        }


        private void DrawDictionary()
        {

            GUILayout.BeginArea(_rect, GUI.skin.box);
            

            foreach(KeyValuePair<string, object> row  in _outputs)
            {

                string output = string.Concat(row.Key, ": ", row.Value);

                GUILayout.Label(output);
            }


            GUILayout.EndArea();
        }
    }
}
