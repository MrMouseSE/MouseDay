using UnityEngine;

namespace GameSceneScripts
{
    public class GameFieldInitializer : MonoBehaviour
    {
        public GameFieldDescription GameFieldDescription;
        public BlockerGenerator GameBlockerGenerator;
        public CursorObjectController CursorObjectController;
        public CameraController CameraController;
        
        private void Awake()
        {
            var settings = 
                GameFieldDescription.GetCurrentDifficultyContainer(PlayerPrefs.GetInt("Difficulty"));
            GameBlockerGenerator.GenerateGameGrid(settings.GridSize);
            CursorObjectController.SetCurrentGridSize(settings.GridSize);
            CursorObjectController.SetCursorRadius(settings.CursorRadius);
            CameraController.SetCameraPosition(settings.CameraOffset);
        }
    }
}
