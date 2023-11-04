using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameSceneScripts.HalthSystem
{
    public class HealthController : MonoBehaviour
    {
        public Slider HealthSlider;
        public HealthColorController HealthColorController;

        [HideInInspector] public UnityEvent HealthUnderZero;

        private GameFieldDifficultyContainer _gameSettings;
        private HealthHolder _myHealthHolder;
        private bool _isSuddenDeathModeActivate;

        public void InitHealthController(GameFieldDifficultyContainer settings)
        {
            _myHealthHolder = new HealthHolder(settings.InitialHealth);
            _gameSettings = settings;
        }

        public void UpdateHealth(float value)
        {
            _myHealthHolder.UpdateHealth(value);
            float normalizeHealthValue = _myHealthHolder.GetHealthValue() / _gameSettings.InitialHealth;
            HealthSlider.value = Mathf.Clamp01(normalizeHealthValue);
            HealthColorController.UpdateHealthColor(normalizeHealthValue);
            if (_myHealthHolder.GetHealthValue()<0)
            {
                HealthUnderZero?.Invoke();
            }
        }

        public void SetSuddenMode(bool isSuddenModeActive)
        {
            _isSuddenDeathModeActivate = isSuddenModeActive;
        }

        private void Update()
        {
            if (!_isSuddenDeathModeActivate) return;
            var reduceHealthValue = _gameSettings.SuddenDeathReduseValue * Time.deltaTime;
            UpdateHealth(-reduceHealthValue);
        }
    }
}
