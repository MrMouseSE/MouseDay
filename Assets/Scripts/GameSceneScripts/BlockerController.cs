using System.Collections;
using UnityEngine;

namespace GameSceneScripts
{
    public class BlockerController : MonoBehaviour
    {
        public Transform MyTransform;
        public GameObject[] MyTrashGameObjects;
        public Renderer[] MyRenderers;
        public ColorAnimationHolder MyColorAnimationHolder;
        public float AnimationPlayMaxDelay;
        public Animation MyAnimation;
        public string AppearAnimationName;
        public string DisappearAnimationName;
        public string InitAnimationName;

        private float _myAnimationDelay;

        public void SetPosition(Vector3 position)
        {
            MyTransform.localPosition = position;
            _myAnimationDelay = Random.Range(0, AnimationPlayMaxDelay);
        }

        public void PlayInitAnimation()
        {
            MyAnimation.Play(InitAnimationName);
        }
    
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(AnimationDelay(_myAnimationDelay,true));
        }

        private void OnTriggerExit(Collider other)
        {
            StartCoroutine(AnimationDelay(_myAnimationDelay,false));
        }

        private IEnumerator AnimationDelay(float delayTime, bool isInverted)
        {
            yield return new WaitForSeconds(delayTime);
            MyAnimation.Play(isInverted? DisappearAnimationName : AppearAnimationName);
            if (!isInverted)
            {
                foreach (var myTrashGameObject in MyTrashGameObjects)
                {
                    myTrashGameObject.gameObject.SetActive(false);
                }
                MyTrashGameObjects[Random.Range(0,MyTrashGameObjects.Length)].SetActive(true);
            }
            StartCoroutine(ChangeColorCoroutine(isInverted));
        }

        private IEnumerator ChangeColorCoroutine(bool isInverted)
        {
            float currentTime = MyColorAnimationHolder.AnimationTime;
            while (currentTime>0)
            {
                currentTime -= Time.deltaTime;
                float normalizedTime = currentTime / MyColorAnimationHolder.AnimationTime;
                float thisAnimationTime = isInverted ? 1-normalizedTime : normalizedTime;
                Color currentColor = Color.Lerp(MyColorAnimationHolder.ColorFrom, MyColorAnimationHolder.ColorTo,
                    thisAnimationTime);
                foreach (var myRenderer in MyRenderers)
                {
                    myRenderer.material.SetColor("_EmissionColor", currentColor);
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
