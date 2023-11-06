using System.Collections;
using UnityEngine;

namespace GameSceneScripts.ClockSystem
{
    public class ClockController : MonoBehaviour
    {
        public RectTransform Rotator;

        private Coroutine _rotationCoroutine;

        public void StartTimeConter(float time)
        {
            Rotator.localRotation = Quaternion.identity;
            if (_rotationCoroutine!= null) StopCoroutine(_rotationCoroutine);
            _rotationCoroutine = StartCoroutine(EvaluateTime(time));
        }

        private IEnumerator EvaluateTime(float time)
        {
            float currentTime = time;
            float rotationSpeed = 360 / time;
            while (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                Rotator.Rotate(Vector3.back, rotationSpeed * Time.deltaTime,Space.Self);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}

