using System;
using UnityEngine;

namespace GameSceneScripts
{
    public class CursorObjectController : MonoBehaviour
    {
        public SphereCollider CursorObjectCollider;

        private Vector2 _currentGridSize;

        private Transform _myTransform;
        private Plane _cursorMovementPlane;

        public void SetCurrentGridSize(Vector2 currentGridSize)
        {
            _currentGridSize = currentGridSize/2;
        }

        public void SetCursorRadius(float radius)
        {
            CursorObjectCollider.radius = radius;
        }
    
        private void Start()
        {
            _myTransform = transform;
            _cursorMovementPlane = new Plane(Vector3.up, Vector3.zero);
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var currentPosition = _myTransform.position;

            if (_cursorMovementPlane.Raycast(ray,out float distance))
            {
                currentPosition = ray.origin + ray.direction * distance;
            }

            currentPosition.x = Math.Clamp(currentPosition.x, -_currentGridSize.x, _currentGridSize.x);
            currentPosition.z = Math.Clamp(currentPosition.z, -_currentGridSize.y, _currentGridSize.y);
            _myTransform.position = currentPosition;
        }
    }
}
