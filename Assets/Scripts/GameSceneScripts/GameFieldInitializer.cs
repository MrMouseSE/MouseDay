using GameSceneScripts.HalthSystem;
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

        private void Awake()
        {
            var settings =
                GameFieldDescription.GetCurrentDifficultyContainer(PlayerPrefs.GetInt("Difficulty"));
            var blockerControllers = GameBlockerGenerator.GenerateGameGrid(settings.GridSize);
            CursorObjectController.SetCurrentGridSize(settings.GridSize);
            CursorObjectController.SetCursorRadius(settings.CursorRadius);
            CursorObjectController.ActivateCursorAfterDelay(settings.CursorDelayTime);
            CameraController.SetCameraPosition(settings.CameraOffset);
            UsableObjectSpawner.InitUsableObjectSpawner(settings, blockerControllers, ScoreCounter, HealthController);
            HealthController.InitHealthController(settings);
            HealthController.HealthUnderZero.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}