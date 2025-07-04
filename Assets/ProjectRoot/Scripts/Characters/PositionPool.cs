using Core;
using UnityEngine;
using System.Collections.Generic;

namespace Characters
{
    public sealed class PositionPool : MonoBehaviour, IPool<Vector3>
    {

        [SerializeField, Space]
        private List<Vector3> _positions;


        private Camera _camera;


        private void Awake()
        {
            
            _camera = Camera.main;
        }


        private void OnValidate()
        {

            _positions.Clear();


            foreach(Transform child in transform)
            {

                _positions.Add(child.position);
            }
        }


        public bool TryGetObject(out Vector3 position)
        {

            position = _positions.Find(IsOutOfScreen);

            return position != null;
        }


        private bool IsOutOfScreen(Vector3 position)
        {

            Vector3 screenPoint = _camera.WorldToViewportPoint(position);
            
            float x = screenPoint.x;

            float y = screenPoint.y;


            if(x < 0 || x > 1 || y < 0 || y > 1)
            {
                return true;
            }

            return false;
        }
    }
}
