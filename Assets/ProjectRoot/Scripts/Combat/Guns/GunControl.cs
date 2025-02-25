﻿using UnityEngine;
using System;
using Core;

namespace Combat.Guns
{
    public sealed class GunControl
    {

        public event Action<Vector3> PullingTrigger;

        public event Action<Vector3> DirectionChanged;


        private readonly Camera _camera;


        private Vector3 _lastDirection;


        public GunControl()
        {

            _camera = Camera.main;
        }
        

        public void HandleInput()
        {

            if(TryGetDirection(out Vector3 direction))
            {

                _lastDirection = direction;

                DirectionChanged?.Invoke(_lastDirection);
            }


            if(Input.GetButton("Fire1"))
            {

                PullingTrigger?.Invoke(_lastDirection);
            }
        }


        private bool TryGetDirection(out Vector3 direction)
        {

            Vector3 screenPoint = Input.mousePosition;

            screenPoint.z = -_camera.transform.position.z;
            

            Ray ray = _camera.ScreenPointToRay(screenPoint);


            if (Physics.Raycast(ray, out RaycastHit hit))
            {

                GUIOutput.DrawPoint(hit.point); 
                
                direction = hit.point;

                return true;
            }

            direction = Vector3.zero;

            return false;
        }
    }
}
