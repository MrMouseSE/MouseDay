using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameSceneScripts.HalthSystem
{
    public class HealthController : MonoBehaviour
    {
        public Slider HealthSlider;
        public HealthColorController HealthColorController;

        public ParticleSystem ExtraHealthEffect;
        public Color ExtraHealthColor;

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
            float currentHP = _myHealthHolder.GetHealthValue();
            UpdateExtraHealthEffect(currentHP - _gameSettings.InitialHealth);
            float normalizeHealthValue = currentHP / _gameSettings.InitialHealth;
            HealthSlider.value = Mathf.Clamp01(normalizeHealthValue);
            HealthColorController.UpdateHealthColor(normalizeHealthValue);
            if (_myHealthHolder.GetHealthValue()<0)
            {
                HealthUnderZero?.Invoke();
            }
        }

        private void UpdateExtraHealthEffect(float value)
        {
            float normalizedValue = Mathf.Clamp01((value) / 100);
            var main = ExtraHealthEffect.main;
            ExtraHealthColor.a = normalizedValue;
            main.startColor = ExtraHealthColor;
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
