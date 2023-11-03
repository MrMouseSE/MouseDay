using System;
using UnityEngine;

namespace GameSceneScripts
{
    [Serializable]
    public class GameFieldDifficultyContainer
    {
        public int Difficulty;
        public Vector2 GridSize;
        public float CursorRadius;
        public float CameraOffset;
    }
}
