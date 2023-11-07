using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MenuButtonsScripts
{
    public class DifficultyController : MonoBehaviour
    {
        public Image[] Stars;
        public float MinAlpha;

        public TextMeshProUGUI DifficultyMultyplyer;
        public Animation DifficultyAnimation;

        private string[] _difficulties = {"x0.75", "x1.5", "x3!!"};
        private float[] _difficultuesMult = { 0.75f, 1.5f, 3f };

        private int _currentDifficulty;

        public void ChangeDifficulty()
        {
            _currentDifficulty += 1;
            if (_currentDifficulty > 2) _currentDifficulty = 0;
            foreach (var star in Stars)
            {
                var color = star.color;
                color.a = MinAlpha;
                star.color = color;
            }

            for (int i = 0; i < _currentDifficulty; i++)
            {
                var color = Stars[i].color;
                color.a = 1;
                Stars[i].color = color;
            }

            DifficultyMultyplyer.text = _difficulties[_currentDifficulty];
            DifficultyAnimation.Play();
        }

        public void SetRunDifficulty()
        {
            PlayerPrefs.SetInt("Difficulty", _currentDifficulty);
            PlayerPrefs.SetFloat("DifficultyMult", _difficultuesMult[_currentDifficulty]);
            PlayerPrefs.Save();
        }
    }
}
