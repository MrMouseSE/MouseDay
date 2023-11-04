using System;
using UnityEngine;

namespace GameSceneScripts
{
    [Serializable]
    public class GameFieldDifficultyContainer
    {
        public int Difficulty;
        public float InitialHealth;
        public Vector2 GridSize;
        public float CursorRadius;
        public float DefaultTimeToNextSpawn = 6f;
        public float ReduceNextSpawnTimeValue = 0.3f;
        public float MinimumNextSpawnTimeValue;
        public float SuddenDeathReduseValue;
        [Space]
        public float CursorDelayTime =0.3f;
        public float CameraOffset;
    }
}
