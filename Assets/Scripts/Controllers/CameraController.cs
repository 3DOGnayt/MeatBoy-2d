using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class CameraController
    {
        private float X;
        private float Y;

        private float offsetY = 1.5f;
        private float offsetX = 1.5f;

        private int _camSpeed = 150;

        private Transform _playerTransform;
        private Transform _cameraTransform;


        public CameraController(Transform _player, Transform _camera)
        {
            _playerTransform = _player;
            _cameraTransform = _camera;
        }
        public void Update()
        {
            Y = _playerTransform.position.y;
            X = _playerTransform.position.x;


            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position,
                new Vector3(X + offsetX, Y + offsetY, _cameraTransform.position.z),
                Time.deltaTime * _camSpeed);
        }
    }
}
