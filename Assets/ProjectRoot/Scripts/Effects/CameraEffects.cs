using Unity.VisualScripting;
using UnityEngine;

namespace Effects
{
    public sealed class CameraEffects
    {

        private readonly Camera _camera;

        private readonly Transform _cameraTransform;

        private Vector3 _velocity;


        public CameraEffects(Camera camera)
        {

            _camera = camera;

            _cameraTransform = _camera.transform;
        }


        public void Follow(Vector3 target, float smoothTime)
        {

            Vector3 newPosition = Vector3.SmoothDamp(_camera.transform.position,
                target, ref _velocity, smoothTime);


            newPosition.y = _cameraTransform.position.y;

            _cameraTransform.position = newPosition;
        }


        public void OnShot()
        {

        }

        public void OnDamaged()
        {

        }
    }
}
