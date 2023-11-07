using TMPro;
using UnityEngine;

namespace LeaderBoardScripts
{
    public class LeaderHolderContainer : MonoBehaviour
    {
        public RectTransform MyRectTransform;
        public float StringHeight;
        public Animation MyAnimation;
        public TextMeshProUGUI NameField;
        public TextMeshProUGUI ScoreField;
        public TextMeshProUGUI TimeField;

        private void Start()
        {
            MyAnimation.Play();
        }

        public void SetTime(float time)
        {
            float seconds = Mathf.Floor(time % 60) / 100;
            int minutes = (int) (time - seconds) / 60;
            string formatedTime = $"{minutes+seconds}";
            formatedTime = formatedTime.Replace(",", ":");
            formatedTime = formatedTime.Replace(".", ":");
            TimeField.text = formatedTime;
        }

        public void SetTime(string time)
        {
            float floatTime = float.Parse(time);
            SetTime(floatTime);
        }
    }
}
