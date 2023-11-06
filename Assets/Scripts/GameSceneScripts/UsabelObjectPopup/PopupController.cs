using UnityEngine;

public class PopupController : MonoBehaviour
{
    public Transform MyTransform;
    public SpriteRenderer MyRenderer;
    public Animation MyAnimation;

    public void StartPopup(Vector3 position, Sprite sprite)
    {
        MyRenderer.sprite = sprite;
        MyTransform.position = position;
        MyAnimation.Play();
    }
}
