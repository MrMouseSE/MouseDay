using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GameSceneScripts
{
    public class UsableObjectController : MonoBehaviour
    {
        public Transform MyTransform;
        public Animation MyAnimation;
        public ParticleSystem MyParticles;
        public ParticleSystem MyDisappearParticles;
        public MeshFilter MyFilter;
        public Renderer MyRenderer;
        public ColorAnimationHolder MyColorAnimationHolder;
        public string UseAnimationName;
        public string IdleAnimationName;

        [HideInInspector] public bool IsInUsableAnimation;

        [HideInInspector]
        public UnityEvent ObjectUsed;

        public void SetObjectNewPosition(Vector3 position)
        {
            MyTransform.position = position;
            MyAnimation.Play(IdleAnimationName);
        }

        public void SetUsabaleObjectMesh(Mesh mesh, Material material)
        {
            MyFilter.mesh = mesh;
            MyRenderer.material = material;
        }
        
        private void OnMouseDown()
        {
            IsInUsableAnimation = true;
            MyAnimation.Play(UseAnimationName);
            StartCoroutine(StartColorAnimation());
        }

        private IEnumerator StartColorAnimation()
        {
            float currentTime = MyColorAnimationHolder.AnimationTime;
            while (currentTime>0)
            {
                currentTime -= Time.deltaTime;
                float normalizedTime = currentTime / MyColorAnimationHolder.AnimationTime;
                Color currentColor = Color.Lerp(MyColorAnimationHolder.ColorFrom, MyColorAnimationHolder.ColorTo,
                    normalizedTime);
                MyRenderer.material.SetColor("_EmissionColor", currentColor);
                yield return new WaitForEndOfFrame();
            }
            MyParticles.Play();
            yield return new WaitForSeconds(MyParticles.main.duration);
            IsInUsableAnimation = false;
            ObjectUsed.Invoke();
        }
    }
}
