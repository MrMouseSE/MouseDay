using UnityEngine;

namespace GameSceneScripts
{
    public class CameraController : MonoBehaviour
    {
        public Transform LookTarget;
        public Transform MyTransform;

        private Vector3 _previousPosition;

        private void Awake()
        {
            _previousPosition = Vector3.zero;
        }

        public void SetCameraPosition(float offset)
        {
            MyTransform.Translate(Vector3.back * offset, Space.Self);
        }

        private void Update()
        {
            var position = LookTarget.position;
            var lookPosition = Vector3.Lerp(_previousPosition, position, Time.deltaTime);
            var frwrd = (lookPosition - MyTransform.position).normalized;
            var rght = Vector3.Cross(frwrd, Vector3.up);
            var up = Vector3.Cross(frwrd, rght);
            MyTransform.localRotation = Quaternion.LookRotation(frwrd,up);
            _previousPosition = position;
        }
    }
}
