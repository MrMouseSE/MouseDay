using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace MenuButtonsScripts
{
    public class StarsColorAnimation : MonoBehaviour
    {
        public Image MyImage;
        public Color ColorFrom;
        public Color ColorTo;
        public float Speed;
        public float Offset;

        private float _offset;

        private void Start()
        {
            _offset = Random.Range(0, Offset);
        }

        void Update()
        {
            MyImage.color = Color.Lerp(ColorFrom, ColorTo, Mathf.Sin(Time.time * Speed + _offset));
        }
    }
}
