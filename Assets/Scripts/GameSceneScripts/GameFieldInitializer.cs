using System;
using GameSceneScripts.HalthSystem;
using LeaderBoardScripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSceneScripts
{
    public class GameFieldInitializer : MonoBehaviour
    {
        public GameFieldDescription GameFieldDescription;
        public BlockerGenerator GameBlockerGenerator;
        public CursorObjectController CursorObjectController;
        public CameraController CameraController;
        public UsableObjectSpawner UsableObjectSpawner;
        public TextMeshProUGUI ScoreCounter;
        public HealthController HealthController;
        public TextMeshProUGUI ScoreMultiply;
        
        private GameScoreController _gameScoreController;
        private float _scoreMultiplyer = 0.75f;

        private void Awake()
        {
            var settings =
                GameFieldDescription.GetCurrentDifficultyContainer(PlayerPrefs.GetInt("Difficulty"));
            _scoreMultiplyer = PlayerPrefs.GetFloat("DifficultyMult");
            ScoreMultiply.text = "x" + _scoreMultiplyer;
            var blockerControllers = GameBlockerGenerator.GenerateGameGrid(settings.GridSize);
            CursorObjectController.SetCurrentGridSize(settings.GridSize);
            CursorObjectController.SetCursorRadius(settings.CursorRadius);
            CursorObjectController.ActivateCursorAfterDelay(settings.CursorDelayTime);
            CameraController.SetCameraPosition(settings.CameraOffset);
            _gameScoreController = new GameScoreController(Time.time);
            UsableObjectSpawner.InitUsableObjectSpawner(settings, blockerControllers, ScoreCounter, HealthController,_gameScoreController);
            HealthController.InitHealthController(settings);
            HealthController.HealthUnderZero.AddListener(LoadScoreScene);
        }

        private void LoadScoreScene()
        {
            var currentData = _gameScoreController.GetPlayerData();
            float sessionTime = Time.time - currentData.InitGameTime;
            int currentRunFinalScore = (int)Math.Round(currentData.CurrentScore * _scoreMultiplyer);
            LeaderBoardHandler.SaveCurrentProgressToPrefs(currentRunFinalScore,sessionTime);
            SceneManager.LoadScene("PlayersScores");
        }
    }
}