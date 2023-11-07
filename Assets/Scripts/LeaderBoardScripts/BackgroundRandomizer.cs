using UnityEngine;
using UnityEngine.UI;

public class BackgroundRandomizer : MonoBehaviour
{
    public Image MyImage;

    public Sprite[] Backgrounds;

    public void Awake()
    {
        MyImage.sprite = Backgrounds[Random.Range(0, Backgrounds.Length)];
    }
}
